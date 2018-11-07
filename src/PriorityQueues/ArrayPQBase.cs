

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Elementary implementation has the property that either the 
    /// insert or the remove top operation takes linear time in the worst case.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public abstract class ArrayPQBase<TKey>
      : IPriorityQueue<TKey>
      , ICloneable<ArrayPQBase<TKey>>
      where TKey : IComparable<TKey>
    {
        protected TKey[] pq;                    // store items at indices 1 to n
        protected int n;                        // number of items on priority queue
        protected IComparer<TKey> comparator;   // optional comparator

        /// <summary>
        /// use a zero-based array
        /// </summary>
        /// <param name="capacity"></param>
        /// <param name="comparator"></param>
        public ArrayPQBase(int capacity = 0, IComparer<TKey> comparator = null)
        {
            pq = new TKey[capacity];
            n = 0;
            this.comparator = comparator;
        }

        public ArrayPQBase(TKey[] keys, IComparer<TKey> comparator = null)
        {
            pq = keys;
            n = pq.Length;
            this.comparator = comparator;
        }

        /// <summary>
        /// Returns the number of keys on this priority queue.
        /// </summary>
        public int Size => n;

        /// <summary>
        /// Returns true if this priority queue is empty.
        /// </summary>
        public bool IsEmpty => n == 0;

        #region propagate abstract 

        public abstract TKey Top { get; }

        public abstract void Insert(TKey key);

        public abstract TKey Delete();

        public abstract bool ComparePredicate(int i, int j);

        #endregion

        #region IEnumerable

        public IEnumerator<TKey> GetEnumerator()
        {
            return new ArrayPQEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ArrayPQEnumerator(this);
        }

        /// <summary>
        /// nested enumerator
        /// </summary>
        private class ArrayPQEnumerator : IEnumerator<TKey>
        {
            private ArrayPQBase<TKey> _clone;

            public ArrayPQEnumerator(ArrayPQBase<TKey> source)
            {
                this._clone = source.Clone();
            }

            public TKey Current {
                get {
                    if (!MoveNext()) throw new ArgumentOutOfRangeException();
                    return _clone.Delete();
                }
            }

            object IEnumerator.Current => this.Current;

            public void Dispose() { }

            public bool MoveNext() => !_clone.IsEmpty;

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        public abstract ArrayPQBase<TKey> Clone();

        // helper function to double/half the size of the heap array
        protected virtual void resize(int capacity)
        {
            Contract.Assert(capacity > n);

            TKey[] temp = new TKey[capacity];
            for (int i = 0; i < n; i++)
            {
                temp[i] = pq[i];
            }
            pq = temp;
        }
    }
}
