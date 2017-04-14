

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// base class for <see cref="MinPQ{TKey}"/> and <see cref="MaxPQ{TKey}"/>
    /// </summary>
    /// <typeparam name="TKey">comparable class</typeparam>
    public abstract class PQBase<TKey>
        : IPriorityQueue<TKey>
        where TKey : IComparable<TKey>
    {

        protected TKey[] pq;                   // store items at indices 1 to n
        protected int n;                      // number of items on priority queue
        protected IComparer<TKey> comparator;  // optional comparator

        public PQBase(int initCapacity = 0, IComparer<TKey> comparator = null)
        {
            pq = new TKey[initCapacity + 1];
            n = 0;
            this.comparator = comparator;
        }

        public PQBase(TKey[] keys)
        {
            n = keys.Length;
            pq = new TKey[keys.Length + 1];
            for (int i = 0; i < n; i++)
                pq[i + 1] = keys[i];
            for (int k = n / 2; k >= 1; k--)
                sink(k);
            // // assert isMaxHeap();
        }

        public TKey Top
        {
            get
            {
                if (IsEmpty) throw new InvalidOperationException("Priority queue underflow");
                return pq[1];
            }
        }

        // helper function to double the size of the heap array
        protected void resize(int capacity)
        {
            // assert capacity > n;
            TKey[] temp = new TKey[capacity];
            for (int i = 1; i <= n; i++)
            {
                temp[i] = pq[i];
            }
            pq = temp;
        }

        /**
 * Adds a new key to this priority queue.
 *
 * @param  x the key to add to this priority queue
 */
        public void Insert(TKey x)
        {
            // double size of array if necessary
            if (n == pq.Length - 1) resize(2 * pq.Length);

            // add x, and percolate it up to maintain heap invariant
            pq[++n] = x;
            swim(n);
            // assert isMinHeap();
        }


        /**
        * Returns true if this priority queue is empty.
        *
        * @return {@code true} if this priority queue is empty;
        *         {@code false} otherwise
        */
        public bool IsEmpty { get { return n == 0; } }

        /**
         * Returns the number of keys on this priority queue.
         *
         * @return the number of keys on this priority queue
         */
        public int Size { get { return n; } }

        public abstract TKey Delete();

        internal abstract bool predicate(int i, int j);

        // is pq[1..N] a max heap?
        protected bool IsHeap { get { return isHeap(1); } }

        // is subtree of pq[1..n] rooted at k a max heap?
        protected bool isHeap(int k)
        {
            if (k > n) return true;
            int left = 2 * k;
            int right = 2 * k + 1;
            if (left <= n && predicate(k, left)) return false;
            if (right <= n && predicate(k, right)) return false;
            return isHeap(left) && isHeap(right);
        }

        /***************************************************************************
         * Helper functions to restore the heap invariant.
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

        /***************************************************************************
         * Helper functions for compares and swaps.
         ***************************************************************************/
        protected void exch(int i, int j)
        {
            TKey swap = pq[i];
            pq[i] = pq[j];
            pq[j] = swap;
        }

        /***************************************************************************
          * IEnumerator.
        ***************************************************************************/

        /**
         * Returns an iterator that iterates over the keys on this priority queue
         * The iterator doesn't implement {@code remove()} since it's optional.
         *
         * @return an iterator that iterates over the keys in ascending/descending order
         */
        public IEnumerator<TKey> GetEnumerator() { return new PQBaseIterator(this); }
        IEnumerator IEnumerable.GetEnumerator() { return new PQBaseIterator(this); }


        internal abstract PQBase<TKey> Instance(int size, IComparer<TKey> comparator);


        private class PQBaseIterator : IEnumerator<TKey>
        {

            // create a new pq
            private PQBase<TKey> copy;

            //  public TKey next()
            public TKey Current
            {
                get
                {
                    if (!MoveNext()) throw new InvalidOperationException();
                    //return copy.delMax();
                    //return copy.delMin();
                    return copy.Delete();
                }
            }

            object IEnumerator.Current { get { return this.Current; } }

            // add all items to copy of heap
            // takes linear time since already in heap order so no keys move
            public PQBaseIterator(PQBase<TKey> src)
            {
                //if (src.comparator == null) copy = new MaxPQ<TKey>(src.Size);
                //else copy = new MaxPQ<TKey>(src.Size, src.comparator);
                copy = src.Instance(src.Size, src.comparator);
                for (int i = 1; i <= src.n; i++)
                    copy.Insert(src.pq[i]);
            }

            //public HeapIEnumerator(TKey[] keys) 
            //{

            //}

            public bool MoveNext() { return !copy.IsEmpty; }
            public void remove() { throw new NotSupportedException(); }

            public void Dispose() { /*throw new NotImplementedException();*/ }

            public void Reset() { throw new NotImplementedException(); }
        }


    }
}
