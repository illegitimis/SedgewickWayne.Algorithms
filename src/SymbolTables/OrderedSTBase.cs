namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public abstract class OrderedSTBase<TKey, TValue>
        : IOrderedSymbolTable<TKey, TValue>
        where TKey : IComparable<TKey>, IEquatable<TKey>
        where TValue : IEquatable<TValue>
    {
        #region concrete

        /// <summary>
        /// Returns true if this symbol table is empty.
        /// </summary>
        public bool IsEmpty => Size == 0;

        /// <summary>
        /// Returns the number of keys in the symbol table in the given range.
        /// </summary>
        /// <param name="lo">minimum endpoint</param>
        /// <param name="hi">maximum endpoint</param>
        /// <returns>the number of keys in the symbol table between lo (inclusive) and hi (inclusive)</returns>
        public int RangeSize(TKey lo, TKey hi)
        {
            KeyArgumentNull(lo, nameof(RangeSize));
            KeyArgumentNull(hi, nameof(RangeSize));

            if (lo.CompareTo(hi) > 0) return 0;
            if (Contains(hi)) return Rank(hi) - Rank(lo) + 1;
            else return Rank(hi) - Rank(lo);
        }

        /// <summary>
        /// Does this symbol table contain the given key?
        /// </summary>
        /// <param name="key">the key</param>
        /// <returns>True if this symbol table contains the key and false otherwise</returns>
        public bool Contains(TKey key)
        {
            KeyArgumentNull(key, nameof(Contains));
            return !Get(key).Equals(default(TValue));
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion

        #region abstract

        public abstract int Size { get; }
        public abstract TKey Min { get; }
        public abstract TKey Max { get; }
        public abstract int Rank(TKey key);
        public abstract TValue Get(TKey key);
        public abstract void DeleteMin();
        public abstract void DeleteMax();
        public abstract TKey Select(int k);
        public abstract TKey Floor(TKey key);
        public abstract TKey Ceiling(TKey key);
        public abstract void Put(TKey key, TValue val);
        public abstract void Delete(TKey key);
        public abstract IEnumerator<TKey> GetEnumerator(); 

        #endregion
        
        #region protected

        protected void SymbolTableUnderflow()
        {
            // empty symbol table
            if (IsEmpty) throw new InvalidOperationException("Symbol table underflow");
        }
        protected void KeyArgumentNull(TKey key, string methodName)
        {
            if (key != null) return;
            throw new ArgumentNullException($"Argument {nameof(key)} to {methodName} is null");
        }

        protected void SelectOutOfRange(int k)
        {
            if (k < 0 || k > Size)
                throw new ArgumentOutOfRangeException(nameof(k), $"Called Select with invalid argument: {k}");
        }

        #endregion        
    }
}
