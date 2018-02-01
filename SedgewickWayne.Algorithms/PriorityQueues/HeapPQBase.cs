

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Generic priority queue implementation with a binary heap.
    /// <remarks>
    /// base class for <see cref="MinPQ{TKey}"/> and <see cref="MaxPQ{TKey}"/>
    /// Can be optimized by replacing full exchanges 
    /// with half exchanges ??? (ala insertion sort).
    /// </remarks>
    /// </summary>
    /// <typeparam name="TKey">comparable key generic type</typeparam>
    public abstract class HeapPQBase<TKey> 
        : ArrayPQBase<TKey>
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// use a one-based array to simplify parent and child calculations.
        /// </summary>
        /// <param name="capacity"></param>
        /// <param name="comparator"></param>
        public HeapPQBase(int capacity = 0, IComparer<TKey> comparator = null)
        {
            pq = new TKey[1 + capacity];
            n = 0;
            this.comparator = comparator;
        }

        /// <summary>
        /// use a one-based array to simplify parent and child calculations.
        /// </summary>
        /// <param name="keys">pristine array of keys</param>
        /// <param name="comparator"></param>
        public HeapPQBase(TKey[] keys, IComparer<TKey> comparator = null)
        {
            n = keys.Length;

            pq = new TKey[keys.Length + 1];

            for (int i = 0; i < n; i++) pq[i + 1] = keys[i];

            for (int k = n / 2; k >= 1; k--) sink(k);

            Contract.Assert(IsHeap);
        }

        public override TKey Top {
            get {
                if (IsEmpty) throw new InvalidOperationException("Priority queue underflow");
                return pq[1];
            }
        }

        /// <summary>
        /// Adds a new key to this priority queue.
        /// </summary>
        /// <param name="x">the key to add to this priority queue</param>
        public override void Insert(TKey x)
        {
            // double size of array if necessary
            if (n == pq.Length - 1) resize(2 * pq.Length);

            // add x, and percolate it up to maintain heap invariant
            pq[++n] = x;
            swim(n);

            Contract.Assert(IsHeap);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override TKey Delete()
        {
            if (IsEmpty) throw new InvalidOperationException("Priority queue underflow");

            TKey top = DeleteStep();

            // to avoid loiterig and help with garbage collection
            //pq[n + 1] = null;     
            pq[n + 1] = default(TKey);

            // half capacity if less than quarter
            if ((n > 0) && (n == (pq.Length - 1) / 4)) resize(pq.Length / 2);

            // assert isMaxHeap();
            Contract.Assert(IsHeap);

            return top;
        }

        protected abstract TKey DeleteStep();

        /// <summary>
        /// is pq[1..N] a max/min heap?
        /// </summary>
        protected bool IsHeap => IsSubtreeAHeapRootedAt(1); 

        /// <summary>
        /// is subtree of pq[1..n] rooted at k a heap?
        /// </summary>
        /// <param name="k">heap index</param>
        /// <returns>true if heap</returns>
        protected bool IsSubtreeAHeapRootedAt(int k)
        {
            if (k > n) return true;
            int left = 2 * k;
            int right = 2 * k + 1;
            if (left <= n && ComparePredicate(k, left)) return false;
            if (right <= n && ComparePredicate(k, right)) return false;
            return IsSubtreeAHeapRootedAt(left) && IsSubtreeAHeapRootedAt(right);
        }

        /***************************************************************************
         * Helper functions to restore the heap invariant.
        ***************************************************************************/

        protected void swim(int k)
        {
            while (k > 1 && ComparePredicate(k / 2, k))
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
                if (j < n && ComparePredicate(j, j + 1)) j++;
                if (!ComparePredicate(k, j)) break;
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

        protected override void resize(int capacity)
        {
            Contract.Assert(capacity > n);

            TKey[] temp = new TKey[capacity];
            for (int i = 1; i <= n; i++)
            {
                temp[i] = pq[i];
            }
            pq = temp;
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
        //public new IEnumerator<TKey> GetEnumerator() { return new HeapPQIterator(this); }

        //private class HeapPQIterator : IEnumerator<TKey>
        //{
        //    // create a new pq
        //    private HeapPQBase<TKey> copy;

        //    //  public TKey next()
        //    public TKey Current {
        //        get {
        //            if (!MoveNext()) throw new InvalidOperationException();
        //            // delete min or max depending on pq type
        //            return copy.Delete();
        //        }
        //    }

        //    object IEnumerator.Current { get { return this.Current; } }

        //    // add all items to copy of heap
        //    // takes linear time since already in heap order so no keys move
        //    public HeapPQIterator(HeapPQBase<TKey> src)
        //    {
        //        //copy = src.Instance(src.Size, src.comparator);
        //        //for (int i = 1; i <= src.n; i++)
        //        //    copy.Insert(src.pq[i]);
        //        copy = (HeapPQBase<TKey>)src.Clone();
        //    }

        //    public bool MoveNext() { return !copy.IsEmpty; }

        //    public void Dispose() { }

        //    public void Reset() { throw new NotImplementedException(); }
        //}        

    }
}
