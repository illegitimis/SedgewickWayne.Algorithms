
namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// A maximum priority queue of generic keys using a binary heap.
    /// </summary>
    /// <remarks>
    /// supports the usual insert and delete-the-maximum operations, 
    /// along with methods for peeking at the minimum key,
    /// testing if the priority queue is empty, 
    /// and iterating through the keys.
    /// Can be optimized by replacing full exchanges with half exchanges (ala insertion sort). ???
    /// The insert and delete operations take logarithmic amortized time.
    /// The max, size, and is-empty operations take constant time.
    /// Construction takes time proportional to the specified capacity 
    /// or the number of items used to initialize the data structure.
    /// </remarks>
    /// <typeparam name="Key">the generic type of key on this priority queue</typeparam>
    /// <see href="http://algs4.cs.princeton.edu/24pq/MaxPQ.java"/>
    /// <seealso href="http://algs4.cs.princeton.edu/24pq/tinyPQ.txt"/>
    public class MaxPQ<TKey>
        : HeapPQBase<TKey>
        , IMaxPriorityQueue<TKey>
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// Initializes an empty priority queue with the given initial capacity.
        /// </summary>
        /// <param name="initCapacity">the initial capacity of this priority queue</param>
        public MaxPQ(int initCapacity) : base(initCapacity) { }

        /// <summary>
        /// Initializes an empty priority queue.
        /// </summary>
        public MaxPQ() : base(0) { }

        /// <summary>
        /// Initializes an empty priority queue with the given initial capacity,using the given comparator.
        /// </summary>
        /// <param name="initCapacity">the initial capacity of this priority queue</param>
        /// <param name="comparator">the order in which to compare the keys</param>
        public MaxPQ(int initCapacity, IComparer<TKey> comparator) : base(initCapacity, comparator) { }

        /// <summary>
        /// Initializes an empty priority queue using the given comparator.
        /// </summary>
        /// <param name="comparator">the order in which to compare the keys</param>
        public MaxPQ(IComparer<TKey> comparator) : base(0, comparator) { }

        /// <summary>
        /// Initializes a priority queue from the array of keys.
        /// Takes time proportional to the number of keys, using sink-based heap construction.
        /// </summary>
        /// <param name="keys">the array of keys</param>
        /// <param name="comparator"></param>
        public MaxPQ(TKey[] keys, IComparer<TKey> comparator = null) : base(keys, comparator) { }


        /// <summary>
        /// Returns a largest key on this priority queue.
        /// </summary>
        /// <remarks>
        /// Throws <see cref="InvalidOperationException" /> if this priority queue is empty
        /// </remarks>
        public TKey Max { get { return Top; } }

        public int MaxIndex { get { return 1; } }

        protected override TKey DeleteStep()
        {
            TKey max = pq[1];
            exch(1, n--);
            sink(1);
            return max;
        }

        /// <summary>
        /// Removes and returns a largest key on this priority queue.
        /// </summary>
        /// <returns>
        /// Throws <see cref="InvalidOperationException" /> if this priority queue is empty
        /// </returns>
        public TKey DeleteMax() => Delete();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns>less(i, j)</returns>
        public override bool ComparePredicate(int i, int j)
        {
            return (comparator == null)
                    ? pq[i].CompareTo(pq[j]) < 0
                    : comparator.Compare(pq[i], pq[j]) < 0;
        }

        public override ArrayPQBase<TKey> Clone()
        {
            // return new MaxPQ<TKey>(Size, comparator);
            TKey[] keys = new TKey[this.Size];
            Array.ConstrainedCopy(this.pq, 1, keys, 0, this.Size);
            return new MaxPQ<TKey>(keys, comparator);
        }


    }
}
