// http://algs4.cs.princeton.edu/34hash/LinearProbingHashST.java.html
// https://algs4.cs.princeton.edu/34hash/images/linear-probing.png

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections;
    using System.Collections.Generic;


    /// <summary>
    /// Symbol-table implementation with linear-probing hash table.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <remarks>
    /// Supports the usual <see cref="Put(TKey, TValue)"/>, <see cref="Get(TKey)"/>, <see cref="Contains(TKey)"/>,
    /// <see cref="Delete(TKey)"/>, <see cref="Size"/>, <see cref="IsEmpty"/> methods.
    /// It also provides keys enumeration.
    /// A symbol table implements the associative array> abstraction: when associating a value with a key 
    /// that is already in the symbol table, the convention is to replace the old value with the new value.
    /// Setting the value associated with a key to null is equivalent to deleting the key from the symbol table.
    /// 
    /// This implementation uses a linear probing hash table.It requires that the key type overrides the 
    /// <see cref="IEquatable{TKey}.Equals(TKey)"/> and <see cref="object.GetHashCode()"/> methods. 
    /// 
    /// The expected time per put, contains or remove is constant, subject to the uniform hashing assumption.
    /// The size and is-empty</em> operations take constant time.
    /// Construction takes constant time.
    /// </remarks>
    public class LinearProbingHashST<TKey, TValue> :
        STBase<TKey, TValue>
        where TKey : IComparable<TKey>, IEquatable<TKey>
        where TValue : IEquatable<TValue>
    {
        private const int INIT_CAPACITY = 4;

        private int n;           // number of key-value pairs in the symbol table
        private int m;           // size of linear probing table
        private TKey[] keys;      // the keys
        private TValue[] vals;    // the values

        /// <summary>
        /// Initializes an empty symbol table.
        /// </summary>
        public LinearProbingHashST() : this(INIT_CAPACITY)
        {
        }

        /// <summary>
        ///  Initializes an empty symbol table with the specified initial capacity.
        /// </summary>
        /// <param name="capacity">the initial capacity</param>
        public LinearProbingHashST(int capacity)
        {
            m = capacity;
            n = 0;
            keys = new TKey[m];
            vals = new TValue[m];
        }

        /// <summary>
        /// Returns the number of key-value pairs in this symbol table.
        /// </summary>
        public override int Size => n;

        /// <summary>
        /// Removes the specified key and its associated value from this symbol table (if the key is in this symbol table).
        /// </summary>
        /// <param name="key">the key</param>
        public override void Delete(TKey key)
        {
            if (!Contains(key)) { return; }

            // find position i of key
            int i = hash(key);
            while (!key.Equals(keys[i]))
            {
                i = (i + 1) % m;
            }

            // delete key and associated value
            keys[i] = default(TKey);
            vals[i] = default(TValue);

            // rehash all keys in same cluster
            i = (i + 1) % m;

            while (keys[i] != null)
            {
                // delete keys[i] an vals[i] and reinsert
                TKey keyToRehash = keys[i];
                TValue valToRehash = vals[i];
                keys[i] = default(TKey);
                vals[i] = default(TValue);
                n--;
                Put(keyToRehash, valToRehash);
                i = (i + 1) % m;
            }

            n--;

            // halves size of array if it's 12.5% full or less
            if (n > 0 && n <= m / 8) resize(m / 2);

            AssertIntegrity();
        }

        /// <summary>
        /// resizes the hash table to the given capacity by re-hashing all of the keys
        /// </summary>
        /// <param name="capacity"></param>
        private void resize(int capacity)
        {
            LinearProbingHashST<TKey, TValue> temp = new LinearProbingHashST<TKey, TValue>(capacity);
            for (int i = 0; i < m; i++)
            {
                if (keys[i] != null)
                {
                    temp.Put(keys[i], vals[i]);
                }
            }

            keys = temp.keys;
            vals = temp.vals;
            m = temp.m;
        }

        /// <summary>Returns the value associated with the specified key.</summary>
        /// <param name="key">the key</param>
        /// <returns>the value associated with {@code key}; {@code null} if no such value</returns>
        public override TValue Get(TKey key)
        {
            for (int i = hash(key); keys[i] != null; i = (i + 1) % m)
                if (keys[i].Equals(key))
                    return vals[i];
            return default(TValue);
        }

        /// <summary>
        /// Inserts the specified key-value pair into the symbol table, 
        /// overwriting the old value with the new value if the symbol table already contains the specified key.
        /// Deletes the specified key (and its associated value) from this symbol table if the specified value is null.
        /// </summary>
        /// <param name="key">the key</param>
        /// <param name="val">the value</param>
        public override void Put(TKey key, TValue val)
        {
            KeyArgumentNull(key, nameof(Put));

            if (val == null)
            {
                Delete(key);
                return;
            }

            // double table size if 50% full
            if (n >= m / 2)
            {
                resize(2 * m);
            }
            

            int i;
            for (i = hash(key); keys[i] != null; i = (i + 1) % m)
            {
                if (keys[i].Equals(key))
                {
                    vals[i] = val;
                    return;
                }
            }
            keys[i] = key;
            vals[i] = val;
            n++;
        }

        /// <summary>hash function for keys - returns value between 0 and M-1</summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int hash(TKey key)
        {
            return (key.GetHashCode() & 0x7fffffff) % m;
        }

        /// <summary>
        /// don't check after each put() because integrity not maintained during a delete()
        /// </summary>
        private void AssertIntegrity()
        {
            // check that hash table is at most 50% full
            if (m < 2 * n)
            {
                throw new ArgumentOutOfRangeException(nameof(this.m), $"Hash table size: {m} array size: {n}");
            }

            // check that each key in table can be found by get()
            for (int i = 0; i < m; i++)
            {
                TKey keyi = keys[i];
                TValue vali = vals[i];
                TValue geti = Get(keyi);

                if (!geti.Equals(vali))
                {
                    throw new InvalidOperationException($"{keyi} {geti} {vali}");
                }
            }
        }

        public override IEnumerator<TKey> GetEnumerator()
        {
            var queue = new Queue<TKey>();
            for (int i = 0; i < m; i++)
                if (keys[i] != null) queue.Enqueue(keys[i]);
            return queue.GetEnumerator();
        }
    }
}