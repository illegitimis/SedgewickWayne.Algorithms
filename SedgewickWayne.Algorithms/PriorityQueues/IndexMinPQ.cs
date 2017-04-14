
namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /**
 *  The {@code IndexMinPQ} class represents an indexed priority queue of generic keys.
 *  It supports the usual <em>insert</em> and <em>delete-the-minimum</em>
 *  operations, along with <em>delete</em> and <em>change-the-key</em> 
 *  methods. In order to let the client refer to keys on the priority queue,
 *  an integer between {@code 0} and {@code maxN - 1}
 *  is associated with each key—the client uses this integer to specify which key to delete or change.
 *  It also supports methods for peeking at the minimum key, testing 
 *  if the priority queue is empty, and iterating through the keys.
 *  <p>
 *  This implementation uses a binary heap along with an array to associate
 *  keys with integers in the given range.
 *  The <em>insert</em>, <em>delete-the-minimum</em>, <em>delete</em>,
 *  <em>change-key</em>, <em>decrease-key</em>, and <em>increase-key</em>
 *  operations take logarithmic time.
 *  The <em>is-empty</em>, <em>size</em>, <em>min-index</em>, <em>min-key</em>,
 *  and <em>key-of</em> operations take constant time.
 *  Construction takes time proportional to the specified capacity.
 *  <p>
 *  For additional documentation, see <a href="http://algs4.cs.princeton.edu/24pq">Section 2.4</a> of
 *  <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.
 *
 *  @author Robert Sedgewick
 *  @author Kevin Wayne
 *
 *  @param <Key> the generic type of key on this priority queue
*/
    public class IndexMinPQ<Key> 
        : IndexPQBase<Key>
        , IMinPriorityQueue<Key>
        where Key : System.IComparable<Key>
    {
        
        /**
         * Initializes an empty indexed priority queue with indices between {@code 0} and {@code maxN - 1}.
         * @param  maxN the keys on this priority queue are index from {@code 0} {@code maxN - 1}
         * @throws ArgumentException if {@code maxN < 0}
         */
        public IndexMinPQ(int maxN) : base (maxN) { }

        public IndexMinPQ(Key[] keys) : base(keys) { }

        /**
         * Returns an index associated with a minimum key.
         *
         * @return an index associated with a minimum key
         * @throws InvalidOperationException if this priority queue is empty
         */
        public int MinIndex { get { return Index; } }

        /**
         * Returns a minimum key.
         *
         * @return a minimum key
         * @throws InvalidOperationException if this priority queue is empty
         */
        public Key Min { get { return TopKey; } }

        /**
         * Removes a minimum key and returns its associated index.
         * @return an index associated with a minimum key
         * @throws InvalidOperationException if this priority queue is empty
         */
        public Key DeleteMin() { return DeleteKey(); }

        /**
         * Decrease the key associated with index {@code i} to the specified value.
         *
         * @param  i the index of the key to decrease
         * @param  key decrease the key associated with index {@code i} to this key
         * @throws ArgumentOutOfRangeException unless {@code 0 <= i < maxN}
         * @throws ArgumentException if {@code key >= keyOf(i)}
         * @throws InvalidOperationException no key is associated with index {@code i}
         */
        public override void decreaseKey(int i, Key key)
        {
            if (i < 0 || i >= maxN) throw new ArgumentOutOfRangeException();
            if (!Contains(i)) throw new InvalidOperationException("index is not in the priority queue");
            if (keys[i].CompareTo(key) <= 0)
                throw new ArgumentException("Calling decreaseKey() with given argument would not strictly decrease the key");
            keys[i] = key;
            swim(qp[i]);
        }

        /**
         * Increase the key associated with index {@code i} to the specified value.
         *
         * @param  i the index of the key to increase
         * @param  key increase the key associated with index {@code i} to this key
         * @throws ArgumentOutOfRangeException unless {@code 0 <= i < maxN}
         * @throws ArgumentException if {@code key <= keyOf(i)}
         * @throws InvalidOperationException no key is associated with index {@code i}
         */
        public override void increaseKey(int i, Key key)
        {
            if (i < 0 || i >= maxN) throw new ArgumentOutOfRangeException();
            if (!Contains(i)) throw new InvalidOperationException("index is not in the priority queue");
            if (keys[i].CompareTo(key) >= 0)
                throw new ArgumentException("Calling increaseKey() with given argument would not strictly increase the key");
            keys[i] = key;
            sink(qp[i]);
        }



        /***************************************************************************
         * General helper functions.
         ***************************************************************************/
        protected override bool predicate(int i, int j) { return greater(i, j); }
        private bool greater(int i, int j) 
        {
            return keys[pq[i]].CompareTo(keys[pq[j]]) > 0;
        }

        internal override IndexPQBase<Key> Instance()
        {
            var copy = new IndexMinPQ<Key>(n + 1);
            for (int i = 1; i <= n; i++)
                copy.Insert(pq[i], keys[pq[i]]);
            return copy;
        }
    }
}
