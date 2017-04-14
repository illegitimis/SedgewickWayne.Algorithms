
namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    /**********************************************************************
     * 
     * indexed priority queue of generic keys.
     * 
     * This implementation uses a binary heap along with an array 
     * to associate keys with integers in the given range.
     * 
     ***********************************************************************/

    public abstract class IndexPQBase<Key> 
        : IIndexedPriorityQueue<Key>
        where Key : System.IComparable<Key>
    {
        protected int maxN;        // maximum number of elements on PQ
        protected int n;           // number of elements on PQ
        protected int[] pq;        // binary heap using 1-based indexing
        protected int[] qp;        // inverse of pq - qp[pq[i]] = pq[qp[i]] = i
        protected Key[] keys;      // keys[i] = priority of i

        /**
         * Initializes an empty indexed priority queue with indices between {@code 0} and {@code maxN - 1}.
         * @param  maxN the keys on this priority queue are index from {@code 0} {@code maxN - 1}
         * @throws ArgumentException if {@code maxN < 0}
         */
        public IndexPQBase(int maxN)
        {
            if (maxN < 0) throw new ArgumentException();
            this.maxN = maxN;
            n = 0;

            keys = new Key[maxN + 1];    // make this of length maxN??
            pq = new int[maxN + 1];
            qp = new int[maxN + 1];      // make this of length maxN??
            for (int i = 0; i <= maxN; i++) qp[i] = -1;
        }

        public IndexPQBase(Key[] keys) : this (keys.Length)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                Insert(i, keys[i]);
            }
        }


        /**
         * Returns true if this priority queue is empty.
         *
         * @return {@code true} if this priority queue is empty;
         *         {@code false} otherwise
         */
        public bool IsEmpty { get { return n == 0; } }
        
        /**
         * Is {@code i} an index on this priority queue?
         *
         * @param  i an index
         * @return {@code true} if {@code i} is an index on this priority queue;
         *         {@code false} otherwise
         * @throws ArgumentOutOfRangeException unless {@code 0 <= i < maxN}
         */
        public bool Contains(int i)
        {
            if (i < 0 || i >= maxN) throw new ArgumentOutOfRangeException();
            return qp[i] != -1;
        }

        /**
         * Returns the number of keys on this priority queue.
         *
         * @return the number of keys on this priority queue
         */
        public int Size { get { return n; } }
        

        /**
         * Associates key with index {@code i}.
         *
         * @param  i an index
         * @param  key the key to associate with index {@code i}
         * @throws ArgumentOutOfRangeException unless {@code 0 <= i < maxN}
         * @throws ArgumentException if there already is an item associated with index {@code i}
         */
        public void Insert(int i, Key key)
        {
            if (i < 0 || i >= maxN) throw new ArgumentOutOfRangeException();
            if (Contains(i)) throw new ArgumentException("index is already in the priority queue");
            n++;
            qp[i] = n;
            pq[n] = i;
            keys[i] = key;
            swim(n);
        }

        /**
         * Returns an index associated with a minimum key.
         * @return an index associated with a minimum key
         * @throws InvalidOperationException if this priority queue is empty
         */

        public virtual int Index { get {
                if (n == 0) throw new InvalidOperationException("Priority queue underflow");
                return pq[1];
            } }

        /**
         * Returns a minimum key.
         *
         * @return a minimum key
         * @throws InvalidOperationException if this priority queue is empty
         */
        public virtual Key TopKey { get { 
            if (n == 0) throw new InvalidOperationException("Priority queue underflow");
            return keys[pq[1]];
        }}

        /**
         * Removes a minimum key and returns its associated index.
         * @return an index associated with a minimum key
         * @throws InvalidOperationException if this priority queue is empty
         */
        public virtual int DeleteIndex()
        {
            if (n == 0) throw new InvalidOperationException("Priority queue underflow");
            int min = pq[1];
            exch(1, n--);
            sink(1);
            
            // assert min == pq[n + 1];
            qp[min] = -1;        // delete
            
            // to help with garbage collection
            //keys[min] = null;    
            keys[min] = default(Key);

            pq[n + 1] = -1;        // not needed?

            return min;
        }

        public virtual Key DeleteKey()
        {
            if (n == 0) throw new InvalidOperationException("Priority queue underflow");

            int min = pq[1];
            exch(1, n--);
            sink(1);

            Debug.Assert(min == pq[n + 1]);

            qp[min] = -1;               // delete
            var key = keys[min];        // memo
            keys[min] = default(Key);   // GC
            pq[n + 1] = -1;             // not needed?

            return key;
        }

        /**
         * Returns the key associated with index {@code i}.
         *
         * @param  i the index of the key to return
         * @return the key associated with index {@code i}
         * @throws ArgumentOutOfRangeException unless {@code 0 <= i < maxN}
         * @throws InvalidOperationException no key is associated with index {@code i}
         */
        public Key KeyOf(int i)
        {
            if (i < 0 || i >= maxN) throw new ArgumentOutOfRangeException();
            if (!Contains(i)) throw new InvalidOperationException("index is not in the priority queue");
            else return keys[i];
        }

        /**
         * Change the key associated with index {@code i} to the specified value.
         *
         * @param  i the index of the key to change
         * @param  key change the key associated with index {@code i} to this key
         * @throws ArgumentOutOfRangeException unless {@code 0 <= i < maxN}
         * @throws InvalidOperationException no key is associated with index {@code i}
         */
        public void ChangeKey(int i, Key key)
        {
            if (i < 0 || i >= maxN) throw new ArgumentOutOfRangeException();
            if (!Contains(i)) throw new InvalidOperationException("index is not in the priority queue");
            keys[i] = key;
            swim(qp[i]);
            sink(qp[i]);
        }

        public abstract void decreaseKey(int i, Key key);
        public abstract void increaseKey(int i, Key key);

       
        /**
         * Remove the key associated with index {@code i}.
         *
         * @param  i the index of the key to remove
         * @throws ArgumentOutOfRangeException unless {@code 0 <= i < maxN}
         * @throws InvalidOperationException no key is associated with index {@code i}
         */
        public void Delete(int i)
        {
            if (i < 0 || i >= maxN) throw new ArgumentOutOfRangeException();
            if (!Contains(i)) throw new InvalidOperationException("index is not in the priority queue");
            int index = qp[i];
            exch(index, n--);
            swim(index);
            sink(index);
            //keys[i] = null;
            keys[i] = default(Key);
            qp[i] = -1;
        }


        /***************************************************************************
         * General helper functions.
         ***************************************************************************/
        protected abstract bool predicate(int i, int j);
              
        protected void exch(int i, int j)
        {
            int swap = pq[i];
            pq[i] = pq[j];
            pq[j] = swap;
            qp[pq[i]] = i;
            qp[pq[j]] = j;
        }


        /***************************************************************************
         * Heap helper functions.
         ***************************************************************************/
        protected void swim(int k)
        {
            while (k > 1 && predicate(k / 2, k))
            {
                exch(k, k / 2);
                k = k / 2;
            }
        }

        protected void sink(int k)
        {
            while (2 * k <= n)
            {
                int j = 2 * k;
                if (j < n && predicate(j, j + 1)) j++;
                if (!predicate(k, j)) break;
                exch(k, j);
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
        public IEnumerator<int> GetEnumerator() { return new HeapIEnumerator(this); }

        IEnumerator IEnumerable.GetEnumerator() { return new HeapIEnumerator(this); }

        private class HeapIEnumerator : IEnumerator<int>
        {
            // create a new pq
            private IndexPQBase<Key> copy;

            // public int next()
            public int Current
            {
                get
                {
                    if (!MoveNext()) throw new ArgumentOutOfRangeException();
                    return copy.DeleteIndex();
                }
            }

            object IEnumerator.Current { get { return this.Current; } }

            // add all elements to copy of heap
            // takes linear time since already in heap order so no keys move
            public HeapIEnumerator(IndexPQBase<Key> src)
            {
                int n = src.pq.Length;
                copy = src.Instance();                   
            }


            public void Dispose() { }

            // hasNext
            public bool MoveNext() { return !copy.IsEmpty; }

            public void Reset() { throw new NotImplementedException(); }
        }

        internal abstract IndexPQBase<Key> Instance();

        #endregion
    }
}
