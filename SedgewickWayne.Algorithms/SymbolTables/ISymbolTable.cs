

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Associates a value with a key.
    /// The client can insert key–value pairs into the symbol table, 
    /// with the expectation of later being able to search for the value associated with a given key. 
    /// </summary>
    /// <remarks>
    /// Associative array abstraction.
    /// </remarks>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public interface ISymbolTable<TKey, TValue> 
        : IHaveSize
        , ICheckEmpty
        , IEnumerable<TKey>
        where TKey:IComparable<TKey>, IEquatable<TKey>
    {
        /// <summary>
        /// gets value associated with key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>null if key not present</returns>
        TValue Get(TKey key);

        /// <summary>
        /// adds a key value pair, overwrites if present
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        void Put(TKey key, TValue val);

        /// <summary>
        /// deletes key and associated value, lazy?
        /// </summary>
        /// <param name="key"></param>
        void Delete(TKey key);

        /// <summary>
        /// is there a value paired with key?
        /// </summary>
        /// <param name="key">key value</param>
        /// <returns>true if key in symbol table</returns>
        bool Contains(TKey key);
    }
}
