

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections.Generic;

    interface ISymbolTable<TKey, TValue> 
        : IHaveSize
        , ICheckEmpty
        , IEnumerable<TKey>
        where TKey:IComparable<TKey>, IEquatable<TKey>
    {
        TValue Get(TKey key);
        void Put(TKey key, TValue val);
        void Delete(TKey key);
        bool Contains(TKey key);
    }

    interface IOrderedSymbolTable<TKey, TValue>
        : ISymbolTable<TKey, TValue> 
        where TKey : IComparable<TKey>, IEquatable<TKey>
    {
        void DeleteMin();
        void DeleteMax();
        TKey Min { get; }
        TKey Max { get; }
        TKey Select(int k);
        int Rank(TKey key);

        TKey floor(TKey key);
        TKey ceiling(TKey key);
        int size(TKey lo, TKey hi);
    }
}
