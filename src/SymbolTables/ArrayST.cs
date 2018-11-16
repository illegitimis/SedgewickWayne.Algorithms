// http://algs4.cs.princeton.edu/31elementary/ArrayST.java.html

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///  Symbol table implementation with unordered array. 
    ///  Uses repeated doubling to resize the array.
    /// </summary>
    public class ArrayST<TKey, TValue>
        : STBase<TKey, TValue>
        where TKey : IComparable<TKey>, IEquatable<TKey>
        where TValue : IEquatable<TValue>
    {
        private const int INIT_SIZE = 8;
        
        #region fields

        /// <summary>
        /// symbol table values
        /// </summary>
        TValue[] values;
        /// <summary>
        /// // symbol table keys
        /// </summary>
        TKey[] keys;
        /// <summary>
        /// number of elements in symbol table
        /// </summary>
        int N;

        #endregion
        public ArrayST()
        {
            keys = new TKey[INIT_SIZE];
            values = new TValue[INIT_SIZE];
        }

        #region symbol table

        public override int Size => N;

        /// <summary>
        /// remove given key (and associated value)
        /// </summary>
        /// <param name="key"></param>
        public override void Delete(TKey key)
        {
            for (int i = 0; i < N; i++)
            {
                if (key.Equals(keys[i]))
                {
                    keys[i] = keys[N - 1];
                    values[i] = values[N - 1];

                    keys[N - 1] = default(TKey);
                    values[N - 1] = default(TValue);

                    N--;
                    if (N > 0 && N == keys.Length / 4) ResizeArrays(keys.Length / 2);
                    return;
                }
            }
        }

        public override TValue Get(TKey key)
        {
            for (int i = 0; i < N; i++)
                if (keys[i].Equals(key)) return values[i];

            return default(TValue);
        }

        #endregion

        #region IEnumerable / Iterator

        /// <summary>
        /// Queue<TKey> queue = new Queue<TKey>();
        /// for (int i = 0; i<N; i++) queue.enqueue(keys[i]);
        /// return queue;
        /// </summary>
        /// <returns></returns>
        public override IEnumerator<TKey> GetEnumerator() => (keys as IEnumerable<TKey>).GetEnumerator();

        /// <summary>
        /// insert the key-value pair into the symbol table
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        public override void Put(TKey key, TValue val)
        {
            // to deal with duplicates
            Delete(key);

            // double size of arrays if necessary
            if (N >= values.Length) ResizeArrays(2 * N);

            // add new key and value at the end of array
            values[N] = val;
            keys[N] = key;
            N++;
        }

        #endregion

        /// <summary>
        /// resize the parallel arrays to the given capacity
        /// </summary>
        /// <param name="capacity"></param>
        private void ResizeArrays(int capacity)
        {
            TKey[] tempk = new TKey[capacity];
            TValue[] tempv = new TValue[capacity];

            for (int i = 0; i < N; i++)
            {
                tempk[i] = keys[i];
                tempv[i] = values[i];
            } 
            
            keys = tempk;
            values = tempv;
        }
    }
}
