namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Abstract base for symbol tables
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public abstract class STBase<TKey, TValue>
        : ISymbolTable<TKey, TValue>
        where TKey : IComparable<TKey>, IEquatable<TKey>
        where TValue : IEquatable<TValue>
    {
        /// <summary>
        /// Returns true if this symbol table is empty.
        /// </summary>
        public bool IsEmpty => Size == 0;

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

        public abstract int Size { get; }
        public abstract TValue Get(TKey key);
        public abstract void Put(TKey key, TValue val);
        public abstract void Delete(TKey key);
        public abstract IEnumerator<TKey> GetEnumerator();

        protected void KeyArgumentNull(TKey key, string methodName)
        {
            if (key != null) return;
            throw new ArgumentNullException($"Argument {nameof(key)} to {methodName} is null");
        }
    }
}
