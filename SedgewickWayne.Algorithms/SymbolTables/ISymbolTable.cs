

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Associates a value with a key
    /// The client can insert key–value pairs 
    /// into the symbol table with the expectation 
    /// of later being able to search for the 
    /// value associated with a given key. 
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    interface ISymbolTable<TKey, TValue> 
        : IHaveSize
        , ICheckEmpty
        , IEnumerable<TKey>
        where TKey:IComparable<TKey>, IEquatable<TKey>
    {
        /// <summary>
        /// gets value associated with key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TValue Get(TKey key);
        /// <summary>
        /// adds a key value pair
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        void Put(TKey key, TValue val);
        /// <summary>
        /// deletes key and associated value
        /// </summary>
        /// <param name="key"></param>
        void Delete(TKey key);
        bool Contains(TKey key);
    }

    /// <summary>
    /// Ordered symbol tables. 
    /// In typical applications, keys are comparable, 
    /// so the option exists of comparing two keys a and b. 
    /// Several symbol-table implementations take advantage of 
    /// order among the keys that is implied by <see cref="IComparable"/>  
    /// to provide efficient implementations of the 
    /// <see cref="ISymbolTable{TKey, TValue}.Get(TKey)"/> 
    /// and <see cref="ISymbolTable{TKey, TValue}.Get(TKey)"/>operations. 
    /// More important, in such implementations, we can think of the 
    /// symbol table as keeping the keys in order and consider a 
    /// significantly expanded API that defines numerous natural and 
    /// useful operations involving relative key order.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    interface IOrderedSymbolTable<TKey, TValue>
        : ISymbolTable<TKey, TValue> 
        where TKey : IComparable<TKey>, IEquatable<TKey>
    {
        /// <summary>
        /// delete min key and assocaited value
        /// </summary>
        void DeleteMin();
        /// <summary>
        /// delete MAX key and assocaited value
        /// </summary>
        void DeleteMax();
        /// <summary>
        /// smalest key
        /// </summary>
        TKey Min { get; }
        /// <summary>
        /// largest key
        /// </summary>
        TKey Max { get; }
        /// <summary>
        /// find the key with a given rank
        /// </summary>
        /// <param name="k">rank</param>
        /// <returns>key with rank</returns>
        TKey Select(int k);
        /// <summary>
        /// find the number of keys less than a given key
        /// </summary>
        /// <param name="key">comparison reference</param>
        /// <returns></returns>
        int Rank(TKey key);

        /// <summary>
        /// find the largest key that is less than or equal to the given key
        /// </summary>
        /// <param name="key">given key</param>
        /// <returns>largest key that is less than or equal to the given key</returns>        
        TKey Floor(TKey key);
        /// <summary>
        /// find the smallest key that is greater than or equal to the given key
        /// </summary>
        /// <param name="key">given</param>
        /// <returns>smallest key gte than given</returns>
        TKey Ceiling(TKey key);
        /// <summary>
        /// how many keys fall in a range
        /// </summary>
        /// <param name="lo">lower limit</param>
        /// <param name="hi">higher limit</param>
        /// <returns>How many keys fall within a given range?</returns>
        int RangeSize(TKey lo, TKey hi);
    }
}
