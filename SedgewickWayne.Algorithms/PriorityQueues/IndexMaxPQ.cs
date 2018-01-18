
namespace SedgewickWayne.Algorithms
{
    using System;

    /******************************************************************************
     *  The {@code IndexMaxPQ} class represents an indexed priority queue of generic keys.
     *  It supports the usual <em>insert</em> and <em>delete-the-maximum</em>
     *  operations, along with <em>delete</em> and <em>change-the-key</em> 
     *  methods. In order to let the client refer to items on the priority queue,
     *  an integer between 0 and <see cref="maxN" /> - 1
     *  is associated with each key—the client
     *  uses this integer to specify which key to delete or change.
     *  It also supports methods for peeking at a maximum key,
     *  testing if the priority queue is empty, and iterating through
     *  the keys.
     *  <p>
     *  This implementation uses a binary heap along with an array to associate
     *  keys with integers in the given range.
     *  The <em>insert</em>, <em>delete-the-maximum</em>, <em>delete</em>,
     *  <em>change-key</em>, <em>decrease-key</em>, and <em>increase-key</em>
     *  operations take logarithmic time.
     *  The <em>is-empty</em>, <em>size</em>, <em>max-index</em>, <em>max-key</em>,
     *  and <em>key-of</em> operations take constant time.
     *  Construction takes time proportional to the specified capacity.
     *  <p>
     <a href="http://algs4.cs.princeton.edu/24pq">Section 2.4</a> 
     ******************************************************************************/

    /// <summary>
    /// Maximum-oriented indexed PQ implementation using a binary heap.
    /// </summary>
    /// <typeparam name="Key">the generic type of key on this priority queue</typeparam>
    /// <see href="http://algs4.cs.princeton.edu/24pq/IndexMaxPQ.java"/>
    public class IndexMaxPQ<Key> 
        : IndexPQBase<Key>
        , IIndexedMaxPriorityQueue<Key>
        where Key : IComparable<Key>
    {
       

        /**
* Initializes an empty indexed priority queue with indices between 0
* and <see cref="maxN" /> - 1.
*
* @param  maxN the keys on this priority queue are index from 0 to <see cref="maxN" /> - 1
* Throws <see cref="ArgumentException" /> if {@code maxN < 0}
*/
        public IndexMaxPQ(int maxN) : base (maxN) { }

        public IndexMaxPQ(Key[] keys) : base(keys) { }


        /**
         * Returns an index associated with a maximum key.
         *
         * @return an index associated with a maximum key
         * Throws <see cref="InvalidOperationException" /> if this priority queue is empty
         */
        public int MaxIndex { get { return Index; } }

        /**
         * Returns a maximum key.
         *
         * @return a maximum key
         * Throws <see cref="InvalidOperationException" /> if this priority queue is empty
         */
        public Key Max { get { return TopKey; } }

        /**
         * Removes a maximum key and returns its associated index.
         *
         * @return an index associated with a maximum key
         * Throws <see cref="InvalidOperationException" /> if this priority queue is empty
         */
        public Key DeleteMax()
        {
            return DeleteKey();
        }


        /**
         * Increase the key associated with index <paramref name="i"/> to the specified value.
         *
         * @param  i the index of the key to increase
         * @param  key increase the key associated with index <paramref name="i"/> to this key
         * Throws <see cref="ArgumentOutOfRangeException"/> unless <paramref name="i"/> between 0 and <see cref="maxN"/>.
         * Throws <see cref="ArgumentException" /> if {@code key <= keyOf(i)}
         * Throws <see cref="InvalidOperationException" /> no key is associated with index <paramref name="i"/>
         */
        public override void increaseKey(int i, Key key)
        {
            if (!Contains(i)) throw new InvalidOperationException("index is not in the priority queue");
            if (keys[i].CompareTo(key) >= 0)
                throw new ArgumentException("Calling increaseKey() with given argument would not strictly increase the key");

            keys[i] = key;
            swim(qp[i]);
        }

        /**
         * Decrease the key associated with index <paramref name="i"/> to the specified value.
         *
         * @param  i the index of the key to decrease
         * @param  key decrease the key associated with index <paramref name="i"/> to this key
         * Throws <see cref="ArgumentOutOfRangeException"/> unless <paramref name="i"/> between 0 and <see cref="maxN"/>.
         * Throws <see cref="ArgumentException" /> if {@code key >= keyOf(i)}
         * Throws <see cref="InvalidOperationException" /> no key is associated with index <paramref name="i"/>
         */
        public override void decreaseKey(int i, Key key)
        {
            if (!Contains(i)) throw new InvalidOperationException("index is not in the priority queue");
            if (keys[i].CompareTo(key) <= 0)
                throw new ArgumentException("Calling decreaseKey() with given argument would not strictly decrease the key");

            keys[i] = key;
            sink(qp[i]);
        }

           
        /// <summary>
        /// Strictly less.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        protected override bool Predicate(int i, int j) { return keys[pq[i]].CompareTo(keys[pq[j]]) < 0; }

        public override IndexPQBase<Key> Clone()
        {
            var copy = new IndexMaxPQ<Key>(n + 1);
            for (int i = 1; i <= n; i++)
                copy.Insert(pq[i], keys[pq[i]]);
            return copy;
        }
    }

}
