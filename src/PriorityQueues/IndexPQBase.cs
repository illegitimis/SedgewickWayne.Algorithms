
namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Indexed priority queue of generic keys.
    /// This implementation uses a binary heap along with an array 
    /// to associate keys with integers in the given range.
    /// </summary>
    /// <remarks>
    /// It also supports methods for peeking at the minimum key, 
    /// testing if the priority queue is empty, and iterating through the keys.
    /// The <see cref="Insert(int, TKey)"/>, <see cref="DeleteKey"/>, 
    /// <see cref="Delete(int)"/>, <see cref="DecreaseKey(int, TKey)"/> and 
    /// <see cref="IncreaseKey(int, TKey)"/> operations take logarithmic time.
    /// The <see cref="IsEmpty"/>, <seealso cref="Size"/>, <see cref="Index"/>, 
    /// <see cref="KeyOf(int)"/> and <see cref="TopKey"/> 
    /// operations take constant time.
    /// </remarks>
    /// <typeparam name="Key">the generic type of key on this priority queue</typeparam>
    public abstract class IndexPQBase<TKey> :
        IIndexedPriorityQueue<TKey>,
        ICloneable<IndexPQBase<TKey>>
        where TKey : IComparable<TKey>
    {
        protected int maxN;        // maximum number of elements on PQ
        protected int n;           // number of elements on PQ
        protected int[] pq;        // binary heap using 1-based indexing
        protected int[] qp;        // inverse of pq - qp[pq[i]] = pq[qp[i]] = i
        protected TKey[] keys;     // keys[i] = priority of i

        /// <summary>
        /// Initializes an empty indexed priority queue with indices between 0 and <paramref name="maxN"/> - 1.
        /// </summary>
        /// <remarks>
        /// throws ArgumentException if <paramref name="maxN"/> less than 0.
        /// </remarks>
        /// <param name="maxN">maimum index</param>
        public IndexPQBase(int maxN)
        {
            if (maxN < 0) throw new ArgumentOutOfRangeException(nameof(maxN), maxN, "non-negative");
            this.maxN = maxN;
            n = 0;

            keys = new TKey[maxN + 1];    // make this of length maxN??
            pq = new int[maxN + 1];
            qp = new int[maxN + 1];      // make this of length maxN??
            for (int i = 0; i <= maxN; i++) qp[i] = -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keys"></param>
        public IndexPQBase(TKey[] keys) : this(keys.Length)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                Insert(i, keys[i]);
            }
        }

       
        /// <summary>
        /// Returns true if this priority queue is empty. False otherwise.
        /// </summary>
        public bool IsEmpty { get { return n == 0; } }

        /// <summary>
        /// Is <paramref name="i"/> an index on this priority queue?
        /// </summary>
        /// <remarks>
        /// Throws <see cref="ArgumentOutOfRangeException"/> unless <paramref name="i"/>
        /// between 0 and <see cref="maxN"/>.
        /// </remarks>
        /// <param name="i">an index</param>
        /// <returns>True if <paramref name="i"/> is an index on this priority queue</returns>
        public bool Contains(int i)
        {
            if (i < 0 || i >= maxN) throw new ArgumentOutOfRangeException(nameof(i), i, $"[0, {maxN})");
            return qp[i] != -1;
        }

        /// <summary>
        /// Returns the number of keys on this priority queue.
        /// </summary>
        public int Size { get { return n; } }

        /// <summary>
        /// Associates key with index <paramref name="i"/>.
        /// </summary>
        /// <remarks>
        /// throws <see cref="ArgumentOutOfRangeException"/> unless <paramref name="i"/> between 0 and <see cref="maxN"/>.
        /// throws <see cref="ArgumentException"/> if there already is an item associated with index <paramref name="i"/>.
        /// </remarks>
        /// <param name="i">an index</param>
        /// <param name="key">the key to associate with index <paramref name="i"/>.</param>
        public void Insert(int i, TKey key)
        {
            if (i < 0 || i >= maxN) throw new ArgumentOutOfRangeException(nameof(i), i, $"[0, {maxN})");
            if (Contains(i)) throw new ArgumentException("index is already in the priority queue");
            n++;
            qp[i] = n;
            pq[n] = i;
            keys[i] = key;
            Swim(n);
        }

        /// <summary>
        /// Returns an index associated with a minimum/maximum key.
        /// </summary>
        /// <remarks>
        /// Throws <see cref="InvalidOperationException"/> if this priority queue is empty.
        /// </remarks>
        public virtual int Index {
            get {
                if (n == 0) throw new InvalidOperationException("Priority queue underflow");
                return pq[1];
            }
        }

        /// <summary>
        /// Returns a minimum key.
        /// </summary>
        /// <remarks>
        /// Throws <see cref="InvalidOperationException"/> if this priority queue is empty.
        /// </remarks>
        public virtual TKey TopKey {
            get {
                if (n == 0) throw new InvalidOperationException("Priority queue underflow");
                return keys[pq[1]];
            }
        }

        /// <summary>
        /// Removes a top key and returns its associated index.
        /// </summary>
        /// <remarks>
        /// Throws <see cref="InvalidOperationException"/> if this priority queue is empty.
        /// </remarks>
        /// <returns>Index of the top key.</returns>
        public virtual int DeleteIndex()
        {
            if (n == 0) throw new InvalidOperationException("Priority queue underflow");
            int min = pq[1];
            Exchange(1, n--);
            Sink(1);

            Contract.Assert(min == pq[n + 1]);
            // delete
            qp[min] = -1;
            // to help with garbage collection
            keys[min] = default;
            // not needed?
            pq[n + 1] = -1;

            return min;
        }

        /// <summary> </summary>
        /// <returns>Key that got removed.</returns>
        public virtual TKey DeleteKey()
        {
            if (n == 0) throw new InvalidOperationException("Priority queue underflow");

            int min = pq[1];
            Exchange(1, n--);
            Sink(1);

            Contract.Assert(min == pq[n + 1]);

            qp[min] = -1;
            var key = keys[min];
            keys[min] = default;
            pq[n + 1] = -1;

            return key;
        }

        /// <summary>
        /// Returns the key associated with index <paramref name="i"/>.
        /// </summary>
        /// <remarks>
        /// Throws <see cref="ArgumentOutOfRangeException"/> unless <paramref name="i"/> between 0 and <see cref="maxN"/>.
        /// Throws InvalidOperationException no key is associated with index <paramref name="i"/>.
        /// </remarks>
        /// <param name="i">the index of the key to return</param>
        /// <returns>the key associated with index <paramref name="i"/>.</returns>
        public TKey KeyOf(int i)
        {
            if (i < 0 || i >= maxN) throw new ArgumentOutOfRangeException(nameof(i), i, $"[0, {maxN})");
            if (!Contains(i)) throw new InvalidOperationException("index is not in the priority queue");
            else return keys[i];
        }

        /// <summary>
        /// Change the key associated with index <paramref name="i"/> to the specified value.
        /// </summary>
        /// <remarks>
        /// Throws <see cref="InvalidOperationException" /> no key is associated with index <paramref name="i"/>.
        /// Throws <see cref="ArgumentOutOfRangeException"/> unless <paramref name="i"/> between 0 and <see cref="maxN"/>.
        /// </remarks>
        /// <param name="i">the index of the key to change</param>
        /// <param name="key">change the key associated with index <paramref name="i"/> to this key</param>
        public void ChangeKey(int i, TKey key)
        {
            if (i < 0 || i >= maxN) throw new ArgumentOutOfRangeException(nameof(i), i, $"[0, {maxN})");
            if (!Contains(i)) throw new InvalidOperationException("index is not in the priority queue");
            keys[i] = key;
            Swim(qp[i]);
            Sink(qp[i]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="key"></param>
        public abstract void DecreaseKey(int i, TKey key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="key"></param>
        public abstract void IncreaseKey(int i, TKey key);
     
            /// <summary>
            /// Remove the key associated with index <paramref name="i"/>.
            /// <remarks>
            /// Throws <see cref="ArgumentOutOfRangeException"/> unless <paramref name="i"/> between 0 and <see cref="maxN"/>.
            /// Throws <see cref="InvalidOperationException" /> no key is associated with index <paramref name="i"/>.
            /// </remarks>
            /// </summary>
            /// <param name="i">the index of the key to remove</param>
        public void Delete(int i)
        {
            if (i < 0 || i >= maxN) throw new ArgumentOutOfRangeException(nameof(i), i, $"[0, {maxN})");
            if (!Contains(i)) throw new InvalidOperationException("index is not in the priority queue");
            int index = qp[i];
            Exchange(index, n--);
            Swim(index);
            Sink(index);
            //keys[i] = null;
            keys[i] = default;
            qp[i] = -1;
        }


      /// <summary>
      /// 
      /// </summary>
      /// <param name="i"></param>
      /// <param name="j"></param>
      /// <returns></returns>
        protected abstract bool Predicate(int i, int j);
  
        
        /***************************************************************************
         * General helper functions.
         ***************************************************************************/

#pragma warning disable IDE0180 // Use tuple to swap values
        protected void Exchange(int i, int j)
        {
            int swap = pq[i];
            pq[i] = pq[j];
            pq[j] = swap;
            qp[pq[i]] = i;
            qp[pq[j]] = j;
        }
#pragma warning restore IDE0180 // Use tuple to swap values


        /***************************************************************************
         * Heap helper functions.
         ***************************************************************************/
        protected void Swim(int k)
        {
            while (k > 1 && Predicate(k / 2, k))
            {
                Exchange(k, k / 2);
                k /= 2;
            }
        }

        protected void Sink(int k)
        {
            while (2 * k <= n)
            {
                int j = 2 * k;
                if (j < n && Predicate(j, j + 1)) j++;
                if (!Predicate(k, j)) break;
                Exchange(k, j);
                k = j;
            }
        }

        #region IEnumerable

        /**
         * Returns an iterator that iterates over the keys on the
         * priority queue in ascending order.
         * The iterator doesn't implement {@code remove()} since it's optional.
         *
         * @return an iterator that iterates over the keys in ascending order
         */
        public IEnumerator<int> GetEnumerator() { return new HeapEnumerator(this); }

        IEnumerator IEnumerable.GetEnumerator() { return new HeapEnumerator(this); }

        private class HeapEnumerator : IEnumerator<int>
        {
            // create a new pq
            private readonly IndexPQBase<TKey> copy;

            // public int next()
            public int Current { get {
                    if (!MoveNext()) throw new ArgumentOutOfRangeException();
                    return copy.DeleteIndex();
                }
            }

            object IEnumerator.Current { get { return this.Current; } }

            /// <summary>
            /// add all elements to copy of heap
            /// takes linear time since already in heap order so no keys move
            /// </summary>
            /// <param name="src">source</param>
            public HeapEnumerator(IndexPQBase<TKey> src) => copy = src.Clone();

            public void Dispose() { }

            // hasNext
            public bool MoveNext() { return !copy.IsEmpty; }

            public void Reset() { throw new NotImplementedException(); }
        }

        public abstract IndexPQBase<TKey> Clone();

        #endregion
    }
}
