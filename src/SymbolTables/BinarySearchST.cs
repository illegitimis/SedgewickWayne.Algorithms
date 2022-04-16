/******************************************************************************
 *  
 *  BinarySearchST.java
 *  Symbol table implementation with binary search in an ordered array.
 *  <a href="http://algs4.cs.princeton.edu/31elementary">Section 3.1</a> 
 *  https://algs4.cs.princeton.edu/31elementary/BinarySearchST.java.html
 *  
 ******************************************************************************/



namespace SedgewickWayne.Algorithms
{

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;


    /**
     *  The {@code BST} class represents an ordered symbol table of generic
     *  key-value pairs.
     *  It supports the usual put, get, contains,
     *  delete, size, and is-empty methods.
     *  It also provides ordered methods for finding the minimum,
     *  maximum, floor, select, and ceiling.
     *  It also provides a keys method for iterating over all of the keys.
     *  A symbol table implements the associative array abstraction:
     *  when associating a value with a key that is already in the symbol table,
     *  the convention is to replace the old value with the new value.
     *  Unlike {@link java.util.Map}, this class uses the convention that
     *  values cannot be {@code null}—setting the
     *  value associated with a key to {@code null} is equivalent to deleting the key
     *  from the symbol table.
     
     *  This implementation uses a sorted array. It requires that
     *  the key type implements the {@code Comparable} interface and calls the
     *  {@code compareTo()} and method to compare two keys. It does not call either
     *  {@code equals()} or {@code hashCode()}.
     *  The put and remove operations each take linear time in
     *  the worst case; the contains, ceiling, floor,
     *  and rank operations take logarithmic time; the size,
     *  is-empty, minimum, maximum, and select
     *  operations take constant time. Construction takes constant time.
     *  For other implementations, see {@link ST}, {@link BST},
     *  {@link SequentialSearchST}, {@link RedBlackBST},
     *  {@link SeparateChainingHashST}, and {@link LinearProbingHashST},
     
     */
    public class BinarySearchST<TKey, TValue>
        : OrderedSTBase<TKey, TValue>
        where TKey : IComparable<TKey>, IEquatable<TKey>
        where TValue : IEquatable<TValue>
    {
        private const int INIT_CAPACITY = 2;
        private TKey[] keys;
        private TValue[] vals;
        private int N = 0;

        /// <summary>
        /// Initializes an empty symbol table.
        /// </summary>
        public BinarySearchST() : this(INIT_CAPACITY) { }

        /**
     * Initializes an empty symbol table with the specified initial capacity.
     * @param capacity the maximum capacity
     */
        public BinarySearchST(int capacity)
        {
            this.N = 0;
            keys = new TKey[capacity];
            vals = new TValue[capacity];
        }

        /// <summary>
        /// Returns the value associated with the given key in this symbol table.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key">the key</param>
        /// <returns>the value associated with the given key if the key is in the symbol table; null if the key is not in the symbol table</returns>
        public override TValue Get(TKey key)
        {
            if (IsEmpty) return default(TValue);
            int i = Rank(key);
            if (i < N && keys[i].CompareTo(key) == 0) return vals[i];
            return default(TValue);
        }        

        /**
 * Inserts the specified key-value pair into the symbol table, overwriting the old 
 * value with the new value if the symbol table already contains the specified key.
 * Deletes the specified key (and its associated value) from this symbol table
 * if the specified value is {@code null}.
 *
 * @param  key the key
 * @param  val the value
 * @throws ArgumentNullException if {@code key} is {@code null}
 */
        public override void Put(TKey key, TValue val)
        {
            KeyArgumentNull(key, nameof(Put));

            if (val == null)
            {
                Delete(key);
                return;
            }

            int i = Rank(key);

            // key is already in table
            if (i < N && keys[i].CompareTo(key) == 0)
            {
                vals[i] = val;
                return;
            }

            // insert new key-value pair
            if (N == keys.Length) resize(2 * keys.Length);

            for (int j = N; j > i; j--)
            {
                keys[j] = keys[j - 1];
                vals[j] = vals[j - 1];
            }
            keys[i] = key;
            vals[i] = val;
            N++;

            Debug.Assert(check());
        }
 

            /// <summary>
            /// Returns the number of key-value pairs in this symbol table.
            /// </summary>
        public override int Size => N;

  

        /**
 * Removes the specified key and associated value from this symbol table
 * (if the key is in the symbol table).
 *
 * @param  key the key
 * @throws ArgumentNullException if {@code key} is {@code null}
 */
        public override void Delete(TKey key)
        {
            KeyArgumentNull(key, nameof(Delete));
            if (IsEmpty) return;

            // compute rank
            int i = Rank(key);

            // key not in table
            if (i == N || keys[i].CompareTo(key) != 0)
            {
                return;
            }

            for (int j = i; j < N - 1; j++)
            {
                keys[j] = keys[j + 1];
                vals[j] = vals[j + 1];
            }

            N--;

            // to avoid loitering
            keys[N] = default(TKey);
            vals[N] = default(TValue);

            // resize if 1/4 full
            if (N > 0 && N == keys.Length / 4) resize(keys.Length / 2);

            Contract.Assert(check());
        }

        /**
         * Returns the number of keys in this symbol table strictly less than {@code key}.
         *
         * @param  key the key
         * @return the number of keys in the symbol table strictly less than {@code key}
         * @throws ArgumentNullException if {@code key} is {@code null}
         */
        public override int Rank(TKey key)
        {
            KeyArgumentNull(key, nameof(Rank));

            int lo = 0, hi = N - 1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                int cmp = key.CompareTo(keys[mid]);
                if (cmp < 0) hi = mid - 1;
                else if (cmp > 0) lo = mid + 1;
                else return mid;
            }
            return lo;
        }


        // resize the underlying arrays
        private void resize(int capacity)
        {
            Contract.Assert(capacity >= N);
            
            TKey[] tempk = new TKey[capacity];
            TValue[] tempv = new TValue[capacity];
            for (int i = 0; i < N; i++)
            {
                tempk[i] = keys[i];
                tempv[i] = vals[i];
            }
            vals = tempv;
            keys = tempk;
        }

        /***************************************************************************
         *  Check internal invariants.
         ***************************************************************************/

        private bool check()
        {
            return this.isSorted() && this.rankCheck();
        }

        // are the items in the array in ascending order?
        private bool isSorted()
        {
            for (int i = 1; i < Size; i++)
                if (keys[i].CompareTo(keys[i - 1]) < 0) return false;
            return true;
        }

        // check that Rank(select(i)) = i
        private bool rankCheck()
        {
            for (int i = 0; i < Size; i++)
                if (i != Rank(Select(i))) return false;
            for (int i = 0; i < Size; i++)
                if (keys[i].CompareTo(Select(Rank(keys[i]))) != 0) return false;
            return true;
        }

        /**
 * Removes the smallest key and associated value from this symbol table.
 *
 * Throws <see cref="InvalidOperationException" /> if the symbol table is empty
 */
        public override void DeleteMin()
        {
            if (IsEmpty) throw new InvalidOperationException("Symbol table underflow error");
            Delete(Min);
        }

        /**
         * Removes the largest key and associated value from this symbol table.
         *
         * Throws <see cref="InvalidOperationException" /> if the symbol table is empty
         */
        public override void DeleteMax()
        {
            if (IsEmpty) throw new InvalidOperationException("Symbol table underflow error");
            Delete(Max);
        }




        /***************************************************************************
         *  Ordered symbol table methods.
         ***************************************************************************/

        /**
          * Returns the smallest key in this symbol table.
          *
          * @return the smallest key in this symbol table
          * Throws <see cref="InvalidOperationException" /> if this symbol table is empty
          */
        public override TKey Min
        {
            get
            {
                SymbolTableUnderflow();
                return keys[0];
            }
        }

        /**
         * Returns the largest key in this symbol table.
         *
         * @return the largest key in this symbol table
         * Throws <see cref="InvalidOperationException" /> if this symbol table is empty
         */
        public override TKey Max
        {
            get
            {
                SymbolTableUnderflow();
                return keys[N - 1];
            }
        }

        /**
         * Return the kth smallest key in this symbol table.
         *
         * @param  k the order statistic
         * @return the {@code k}th smallest key in this symbol table
         * @throws ArgumentNullException unless {@code k} is between 0 and
         *        n–1
         */
        public override TKey Select(int k)
        {
            SelectOutOfRange(k);
            return keys[k];
        }

        /**
         * Returns the largest key in this symbol table less than or equal to {@code key}.
         *
         * @param  key the key
         * @return the largest key in this symbol table less than or equal to {@code key}
         * Throws <see cref="InvalidOperationException" /> if there is no such key
         * @throws ArgumentNullException if {@code key} is {@code null}
         */
        public override TKey Floor(TKey key)
        {
            KeyArgumentNull(key, nameof(Floor));
            int i = Rank(key);
            if (i < N && key.CompareTo(keys[i]) == 0) return keys[i];
            if (i == 0) return default(TKey);
            else return keys[i - 1];
        }

        /**
         * Returns the smallest key in this symbol table greater than or equal to {@code key}.
         *
         * @param  key the key
         * @return the smallest key in this symbol table greater than or equal to {@code key}
         * Throws <see cref="InvalidOperationException" /> if there is no such key
         * @throws ArgumentNullException if {@code key} is {@code null}
         */
        public override TKey Ceiling(TKey key)
        {
            KeyArgumentNull(key, nameof(Ceiling));
            int i = Rank(key);
            if (i == N) return default(TKey);
            else return keys[i];
        }

        /**
         * Returns all keys in this symbol table in the given range,
         
         *
         * @param lo minimum endpoint
         * @param hi maximum endpoint
         * @return all keys in this symbol table between {@code lo} 
         *         (inclusive) and {@code hi} (inclusive)
         * @throws ArgumentNullException if either {@code lo} or {@code hi}
         *         is {@code null}
         */
        public IEnumerable<TKey> Keys(TKey lo, TKey hi)
        {
            KeyArgumentNull(lo, nameof(Keys));
            KeyArgumentNull(hi, nameof(Keys));

            Queue<TKey> queue = new Queue<TKey>();
            if (lo.CompareTo(hi) > 0) return queue;

            for (int i = Rank(lo); i < Rank(hi); i++) queue.Enqueue(keys[i]);

            if (Contains(hi)) queue.Enqueue(keys[Rank(hi)]);

            return queue;
        }

        /**
         * Returns all keys in this symbol table as an {@code Iterable}.
         * To iterate over all of the keys in the symbol table named {@code st},
         * use the foreach notation: {@code for (TKey key : st.keys())}.
         *
         * @return all keys in this symbol table
         */
        public override IEnumerator<TKey> GetEnumerator() => Keys(Min, Max).GetEnumerator();
    }
}