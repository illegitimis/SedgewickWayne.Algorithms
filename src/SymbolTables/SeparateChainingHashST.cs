// https://algs4.cs.princeton.edu/code/edu/princeton/cs/algs4/SeparateChainingHashST.java.html
// https://algs4.cs.princeton.edu/34hash/SeparateChainingHashST.java.html
// https://algs4.cs.princeton.edu/code/javadoc/edu/princeton/cs/algs4/SeparateChainingHashST.html
// https://algs4.cs.princeton.edu/34hash/images/separate-chaining.png

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    ///  a symbol table of generic key-value pairs.
    /// This implementation uses a separate chaining hash table. 
    /// </summary>
    /// <remarks>
    /// It requires that the key type overrides the equals() and hashCode() methods. 
    /// The expected time per put, contains, or remove operation is constant, subject to the uniform hashing assumption.
    /// The size, and is-empty operations take constant time. 
    /// Construction takes constant time. 
    /// </remarks>
    public class SeparateChainingHashST<TKey, TValue>
        : STBase<TKey, TValue>
        where TKey : IComparable<TKey>, IEquatable<TKey>
        where TValue : IEquatable<TValue>
    {
        private const int INIT_CAPACITY = 4;

        /// <summary>
        /// number of key-value pairs
        /// </summary>
        private int N;

        /// <summary>
        /// hash table size
        /// </summary>
        private int M;

        /// <summary>
        /// array of linked-list symbol tables
        /// </summary>
        private SequentialSearchST<TKey, TValue>[] st;


        public SeparateChainingHashST(int initialNumberOfChains)
        {
            M = initialNumberOfChains;
            st = new SequentialSearchST<TKey, TValue>[initialNumberOfChains];
            for (int j = 0; j < initialNumberOfChains; st[j++] = new SequentialSearchST<TKey, TValue>());
        }

        public SeparateChainingHashST() : this(INIT_CAPACITY)
        {
        }

        public override int Size => N;

        private void resize(int chains)
        {
            var temp = new SeparateChainingHashST<TKey, TValue>(chains);
            for (int i = 0; i < M; i++)
            {
                foreach (TKey key in st[i].Keys())
                {
                    temp.Put(key, st[i].Get(key));
                }
            }

            M = temp.M;
            N = temp.N;
            st = temp.st;
        }
        
        public override TValue Get(TKey key)
        {
            int num = hash(key);
            return st[num].Get(key);
        }

        public override void Put(TKey key, TValue val)
        {
            KeyArgumentNull(key, nameof(Put));

            if (val == null)
            {
                Delete(key);
                return;
            }

            if (N >= 10 * M)
            {
                resize(2 * M);
            }

            int num = this.hash(key);

            if (!st[num].Contains(key))
            {
                N++;
            }

            st[num].Put(key, val);
        }

        public override void Delete(TKey key)
        {
            int num = hash(key);
            if (st[num].Contains(key))
            {
                N--;
            }

            st[num].Delete(key);

            if (this.M > INIT_CAPACITY && this.N <= 2 * this.M)
            {
                this.resize(this.M / 2);
            }
        }

        public override IEnumerator<TKey> GetEnumerator() => Keys().GetEnumerator();     

        /// <summary>
        /// hash value between 0 and m-1
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int hash(TKey key) => (key.GetHashCode() & 0x7fffffff) % M;        

       
        public IEnumerable<TKey> Keys()
        {
            var queue = new Queue<TKey>();
            for (int i = 0; i < M; i++)
            {
                foreach(var key in st[i].Keys())
                {
                    queue.Enqueue(key);
                }
            }
            return queue;
        }
    }
}
