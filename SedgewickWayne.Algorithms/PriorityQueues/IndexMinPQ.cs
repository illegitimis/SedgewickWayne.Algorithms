
namespace SedgewickWayne.Algorithms
{
    using System;


    /// <summary>
    /// Minimum-oriented indexed PQ implementation using a binary heap
    /// Represents an indexed priority queue of generic keys.
    /// Supports the usual <see cref="Insert"/>, <see cref="DeleteMin"/> operations, 
    /// along with <see cref="IndexPQBase{Key}.DeleteKey"/> and 
    /// <see cref="IndexPQBase{Key}.ChangeKey(int, Key)"/> methods.
    /// </summary>
    /// <remarks>
    /// Construction takes time proportional to the specified capacity.
    /// In order to let the client refer to keys on the priority queue, 
    /// an integer between 0 and <paramref name="IndexMinPQ{TKey}.maxN"/> - 1 
    /// is associated with each key—the client uses this integer to specify which key to delete or change.
    /// </remarks>
    /// <typeparam name="TKey">generic priority queue element type</typeparam>
    public class IndexMinPQ<TKey>
            : IndexPQBase<TKey>
            , IIndexedMinPriorityQueue<TKey>
            where TKey : IComparable<TKey>
    {

        /**
         * Initializes an empty indexed priority queue with indices between 0 and <see cref="maxN" /> - 1.
         * @param  maxN the keys on this priority queue are index from 0 <see cref="maxN" /> - 1
         * Throws <see cref="ArgumentException" /> if {@code maxN < 0}
         */
        public IndexMinPQ(int maxN) : base(maxN) { }

        public IndexMinPQ(TKey[] keys) : base(keys) { }

        /**
         * Returns an index associated with a minimum key.
         *
         * @return an index associated with a minimum key
         * Throws <see cref="InvalidOperationException" /> if this priority queue is empty
         */
        public int MinIndex { get { return Index; } }

        /**
         * Returns a minimum key.
         *
         * @return a minimum key
         * Throws <see cref="InvalidOperationException" /> if this priority queue is empty
         */
        public TKey Min { get { return TopKey; } }

       
        public TKey DeleteMin() { return DeleteKey(); }

        /**
         * Decrease the key associated with index <paramref name="i"/> to the specified value.
         *
         * @param  i the index of the key to decrease
         * @param  key decrease the key associated with index <paramref name="i"/> to this key
         * Throws <see cref="ArgumentOutOfRangeException"/> unless <paramref name="i"/> between 0 and <see cref="maxN"/>.
         * Throws <see cref="ArgumentException" /> if {@code key >= keyOf(i)}
         * Throws <see cref="InvalidOperationException" /> no key is associated with index <paramref name="i"/>
         */
        public override void decreaseKey(int i, TKey key)
        {
            if (i < 0 || i >= maxN) throw new ArgumentOutOfRangeException();
            if (!Contains(i)) throw new InvalidOperationException("index is not in the priority queue");
            if (keys[i].CompareTo(key) <= 0)
                throw new ArgumentException("Calling decreaseKey() with given argument would not strictly decrease the key");
            keys[i] = key;
            swim(qp[i]);
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
        public override void increaseKey(int i, TKey key)
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
        protected override bool Predicate(int i, int j) { return greater(i, j); }
        private bool greater(int i, int j)
        {
            return keys[pq[i]].CompareTo(keys[pq[j]]) > 0;
        }

        public override IndexPQBase<TKey> Clone()
        {
            var copy = new IndexMinPQ<TKey>(n + 1);
            for (int i = 1; i <= n; i++)
                copy.Insert(pq[i], keys[pq[i]]);
            return copy;
        }
    }
}
