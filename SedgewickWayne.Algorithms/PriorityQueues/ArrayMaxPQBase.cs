

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Elementary implementation has the property that 
    /// either the insert or the remove the maximum 
    /// operation takes linear time in the worst case.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public abstract class ArrayMaxPQBase<TKey>
        : IPriorityQueue<TKey>
        , IMaxPriorityQueue<TKey>
        , ICloneable<ArrayMaxPQBase<TKey>>
    where TKey : IComparable<TKey>
    {
        protected TKey[] pq;          // elements
        protected int n;             // number of elements

        public ArrayMaxPQBase(int capacity)
        {
            pq = new TKey[capacity];
            n = 0;
        }

        public int Size => n;

        public bool IsEmpty => n == 0;

        public TKey Max => Top;

        public abstract TKey Top { get; }

        public abstract void Insert(TKey key);

        public abstract TKey Delete();

        public TKey DeleteMax()
        {
            return Delete();
        }


        #region IEnumerable

        public IEnumerator<TKey> GetEnumerator()
        {
            return new ArrayPQEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ArrayPQEnumerator(this);
        }

        public abstract ArrayMaxPQBase<TKey> Clone();

        private class ArrayPQEnumerator : IEnumerator<TKey>
        {
            private ArrayMaxPQBase<TKey> _clone;

            public ArrayPQEnumerator(ArrayMaxPQBase<TKey> source)
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
    }
}
