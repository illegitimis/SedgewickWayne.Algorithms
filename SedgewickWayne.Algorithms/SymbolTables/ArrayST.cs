// http://algs4.cs.princeton.edu/31elementary/ArrayST.java.html

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    /// <summary>
    ///  Symbol table implementation with unordered array. 
    ///  Uses repeated doubling to resize the array.
    /// </summary>
    public class ArrayST<Key, Value>
        : ISymbolTable<Key, Value>
        where Key : IComparable<Key>, IEquatable<Key>
    {
        private const int INIT_SIZE = 8;
        
        #region fields

        /// <summary>
        /// symbol table values
        /// </summary>
        Value[] values;
        /// <summary>
        /// // symbol table keys
        /// </summary>
        Key[] keys;
        /// <summary>
        /// number of elements in symbol table
        /// </summary>
        int N;

        #endregion
        public ArrayST()
        {
            keys = new Key[INIT_SIZE];
            values = new Value[INIT_SIZE];
        }

        #region symbol table

        public bool IsEmpty { get { return N == 0; } }

        public int Size { get { return N; } }

        public bool Contains(Key key)
        {
            return keys.Contains(key);
        }

        /// <summary>
        /// remove given key (and associated value)
        /// </summary>
        /// <param name="key"></param>
        public void Delete(Key key)
        {
            for (int i = 0; i < N; i++)
            {
                if (key.Equals(keys[i]))
                {
                    keys[i] = keys[N - 1];
                    values[i] = values[N - 1];
                    //keys[N - 1] = null;
                    //values[N - 1] = null;
                    N--;
                    if (N > 0 && N == keys.Length / 4) resize(keys.Length / 2);
                    return;
                }
            }
        }

        public Value Get(Key key)
        {
            for (int i = 0; i < N; i++)
                if (keys[i].Equals(key)) return values[i];

            //return null;
            return default(Value);
        }

        #endregion

        #region IEnumerable / Iterator

        IEnumerable<Key> GetYield()
        {
            for (int i = 0; i < N; i++)
                yield return keys[i];
        }

        public IEnumerator<Key> GetEnumerator()
        {
            /*
              Queue<Key> queue = new Queue<Key>();
              for (int i = 0; i < N; i++) queue.enqueue(keys[i]);
              return queue;
             */
            return GetYield().GetEnumerator();
        }

        /// <summary>
        /// insert the key-value pair into the symbol table
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        public void Put(Key key, Value val)
        {
            // to deal with duplicates
            Delete(key);

            // double size of arrays if necessary
            if (N >= values.Length) resize(2 * N);

            // add new key and value at the end of array
            values[N] = val;
            keys[N] = key;
            N++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetYield().GetEnumerator();
        }

        #endregion

        /// <summary>
        /// resize the parallel arrays to the given capacity
        /// </summary>
        /// <param name="capacity"></param>
        private void resize(int capacity)
        {
            Key[] tempk = new Key[capacity];
            Value[] tempv = new Value[capacity];

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
