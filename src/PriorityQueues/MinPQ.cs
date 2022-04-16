namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A minimum priority queue of generic keys using a binary heap.
    /// </summary>
    /// <remarks>
    /// supports the usual insert and delete-the-minimum operations, 
    /// along with methods for peeking at the minimum key,
    /// testing if the priority queue is empty, 
    /// and iterating through the keys.
    ///
    /// The insert and delete operations take logarithmic amortized time.
    /// The min, size, and is-empty operations take constant time.
    /// Construction takes time proportional to the specified capacity 
    /// or the number of items used to initialize the data structure.
    /// </remarks>
    /// <typeparam name="Key">the generic type of key on this priority queue</typeparam>
    /// <see href="http://algs4.cs.princeton.edu/24pq/MinPQ.java"/>
    public class MinPQ<TKey> :
        HeapPQBase<TKey>,
        IMinPriorityQueue<TKey>
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// Initializes an empty priority queue with the given initial capacity.
        /// </summary>
        /// <param name="initCapacity">the initial capacity of this priority queue</param>
        public MinPQ(int initCapacity = 0) : base(initCapacity) { }

        /// <summary>
        /// Initializes an empty priority queue with the given initial capacity, using the given comparator.
        /// </summary>
        /// <param name="a">the initial capacity of this priority queue</param>
        /// <param name="c">comparator the order to use when comparing keys</param>
        public MinPQ(int a, IComparer<TKey> c) : base(a, c) { }

        /// <summary>
        /// Initializes an empty priority queue using the given comparator.
        /// </summary>
        /// <param name="c">comparator the order to use when comparing keys</param>
        public MinPQ(IComparer<TKey> c) : base(0, c) { }

        /// <summary>
        /// Initializes a priority queue from the array of keys.
        /// Takes time proportional to the number of keys, using sink-based heap construction.
        /// </summary>
        /// <param name="keys">the array of keys</param>
        /// <param name="comparer">custom comapre two keys</param>
        public MinPQ(TKey[] keys, IComparer<TKey> comparer = null)
            : base(keys, comparer) { }

        /// <summary>
        /// Returns the smallest key on this priority queue.
        /// </summary>
        /// <remarks>Throws <see cref="InvalidOperationException" /> if this priority queue is empty</remarks>
        public TKey Min { get { return Top; } }

        /// <summary>
        /// index of smallest key
        /// </summary>
        public int MinIndex { get { return 1; } }

        /// <summary>
        /// Removes and returns smallest key on this priority queue.
        /// </summary>
        /// <returns>smallest key on this priority queue</returns>
        /// /// <remarks>Throws <see cref="InvalidOperationException" /> if this priority queue is empty</remarks>
        public TKey DeleteMin() => Delete();

        protected override TKey DeleteStep()
        {
            exch(1, n);
            TKey min = pq[n--];
            sink(1);
            return min;
        }

        /// <summary>
        /// Is Key at index <paramref name="i"/> greater than key at <paramref name="j"/> 
        /// </summary>
        /// <param name="i">first index</param>
        /// <param name="j">second index</param>
        /// <returns>greater than</returns>
        public override bool ComparePredicate(int i, int j) =>
            (comparer is null)
                ? pq[i].CompareTo(pq[j]) > 0
                : comparer.Compare(pq[i], pq[j]) > 0;

        public override ArrayPQBase<TKey> Clone()
        {
            // return new MinPQ<TKey>(this.pq, this.comparator);
            var clone = new MinPQ<TKey>(this.pq.Length);
            clone.n = this.n;
            clone.pq = this.pq;
            clone.comparer = this.comparer;
            return clone;
        }
    }
}