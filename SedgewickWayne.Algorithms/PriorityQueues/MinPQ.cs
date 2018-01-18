
/******************************************************************************
 *  Compilation:  javac MinPQ.java
 *  Execution:    java MinPQ < input.txt
 *  Dependencies: StdIn.java StdOut.java
 *  Data files:   http://algs4.cs.princeton.edu/24pq/tinyPQ.txt
 *  http://algs4.cs.princeton.edu/24pq/MinPQ.java
 *  Generic min priority queue implementation with a binary heap.
 *  Can be used with a comparator instead of the natural order.
 *
 *  % java MinPQ < tinyPQ.txt
 *  E A E (6 left on pq)
 *
 *  We use a one-based array to simplify parent and child calculations.
 *
 *  Can be optimized by replacing full exchanges with half exchanges
 *  (ala insertion sort).
 *
 ******************************************************************************/



namespace SedgewickWayne.Algorithms
{


    using System;
    using System.Collections;
    using System.Collections.Generic;


    /**
     *  The {@code MinPQ} class represents a priority queue of generic keys.
     *  It supports the usual <em>insert</em> and <em>delete-the-minimum</em>
     *  operations, along with methods for peeking at the minimum key,
     *  testing if the priority queue is empty, and iterating through
     *  the keys.
     *  <p>
     *  This implementation uses a binary heap.
     *  The <em>insert</em> and <em>delete-the-minimum</em> operations take
     *  logarithmic amortized time.
     *  The <em>min</em>, <em>size</em>, and <em>is-empty</em> operations take constant time.
     *  Construction takes time proportional to the specified capacity or the number of
     *  items used to initialize the data structure.
     *  <p>
     <a href="http://algs4.cs.princeton.edu/24pq">Section 2.4</a> of
     
     *
     
    
     *
     *  @param <TKey> the generic type of key on this priority queue
     *  
     ******************************************************************************/

    public class MinPQ<Key>
        : PQBase<Key>, IMinPriorityQueue<Key>
        where Key : IComparable<Key>
    {
        /**
         * Initializes an empty priority queue with the given initial capacity.
         *
         * @param  initCapacity the initial capacity of this priority queue
         */
        public MinPQ(int initCapacity) : base(initCapacity) { }

        /**
         * Initializes an empty priority queue.
         */
        public MinPQ() : base() { }

        /**
         * Initializes an empty priority queue with the given initial capacity,
         * using the given comparator.
         *
         * @param  initCapacity the initial capacity of this priority queue
         * @param  comparator the order to use when comparing keys
         */
        public MinPQ(int a, IComparer<Key> c) : base(a, c) { }

        /**
         * Initializes an empty priority queue using the given comparator.
         *
         * @param  comparator the order to use when comparing keys
         */
        public MinPQ(IComparer<Key> c) : base(0, c) { }

        /**
         * Initializes a priority queue from the array of keys.
         * <p>
         * Takes time proportional to the number of keys, using sink-based heap construction.
         *
         * @param  keys the array of keys
         */
        public MinPQ(Key[] keys) : base(keys) { }


        /**
         * Returns a smallest key on this priority queue.
         *
         * @return a smallest key on this priority queue
         * Throws <see cref="InvalidOperationException" /> if this priority queue is empty
         */
        public Key Min { get { return Top; } }
        public int MinIndex { get { return 1; } }

        /**
         * Removes and returns a smallest key on this priority queue.
         *
         * @return a smallest key on this priority queue
         * Throws <see cref="InvalidOperationException" /> if this priority queue is empty
         */
        public Key DeleteMin()
        {
            if (IsEmpty) throw new InvalidOperationException("Priority queue underflow");
            exch(1, n);
            Key min = pq[n--];
            sink(1);

            // avoid loitering and help with garbage collection
            //pq[n + 1] = null;         
            pq[n + 1] = default(Key);

            if ((n > 0) && (n == (pq.Length - 1) / 4)) resize(pq.Length / 2);
            // assert isMinHeap();
            return min;
        }

        public override Key Delete()
        {
            return DeleteMin();
        }

        internal override bool predicate(int i, int j)
        {
            //return greater(i, j);
            return (comparator == null)
                ? pq[i].CompareTo(pq[j]) > 0
                : comparator.Compare(pq[i], pq[j]) > 0;
        }

        internal override PQBase<Key> Instance(int size, IComparer<Key> comparator)
        {
            return new MinPQ<Key>(size, comparator);
        }
    }
}