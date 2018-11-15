namespace SedgewickWayne.Algorithms
{
    using System;

    /// <summary>
    /// Abstract base for ordered symbol tables
    /// </summary>
    public abstract class OrderedSTBase<TKey, TValue>
        : STBase<TKey, TValue>
        , IOrderedSymbolTable<TKey, TValue>
        where TKey : IComparable<TKey>, IEquatable<TKey>
        where TValue : IEquatable<TValue>
    {
        #region concrete

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

        #endregion

        #region abstract
        
        public abstract TKey Min { get; }
        public abstract TKey Max { get; }
        public abstract int Rank(TKey key);        
        public abstract void DeleteMin();
        public abstract void DeleteMax();
        public abstract TKey Select(int k);
        public abstract TKey Floor(TKey key);
        public abstract TKey Ceiling(TKey key);
                
        #endregion
        
        #region protected

        protected void SymbolTableUnderflow()
        {
            // empty symbol table
            if (IsEmpty) throw new InvalidOperationException("Symbol table underflow");
        }

        protected void SelectOutOfRange(int k)
        {
            if (k < 0 || k > Size)
                throw new ArgumentOutOfRangeException(nameof(k), $"Called Select with invalid argument: {k}");
        }

        #endregion        
    }
}
