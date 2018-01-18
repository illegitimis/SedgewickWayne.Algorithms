
    /******************************************************************************
     *  Compilation:  javac MaxPQ.java
     *  Execution:    java MaxPQ < input.txt
     *  Dependencies: StdIn.java StdOut.java
     *  Data files:   http://algs4.cs.princeton.edu/24pq/tinyPQ.txt
     *  
     *  http://algs4.cs.princeton.edu/24pq/MaxPQ.java
     *  
     *  Generic max priority queue implementation with a binary heap.
     *  Can be used with a comparator instead of the natural order,
     *  but the generic TKey type must still be Comparable.
     *
     *  % java MaxPQ < tinyPQ.txt 
     *  Q X P (6 left on pq)
     *
     *  We use a one-based array to simplify parent and child calculations.
     *
     *  Can be optimized by replacing full exchanges with half exchanges (ala insertion sort).
     *
     ******************************************************************************/


namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /******************************************************************************
     * 
     *  The {@code MaxPQ} class represents a priority queue of generic keys.
     *  It supports the usual <em>insert</em> and <em>delete-the-maximum</em>
     *  operations, along with methods for peeking at the maximum key,
     *  testing if the priority queue is empty, and iterating through
     *  the keys.
     *  <p>
     *  This implementation uses a binary heap.
     *  The <em>insert</em> and <em>delete-the-maximum</em> operations take
     *  logarithmic amortized time.
     *  The <em>max</em>, <em>size</em>, and <em>is-empty</em> operations take constant time.
     *  Construction takes time proportional to the specified capacity or the number of
     *  items used to initialize the data structure.
     *  <p>
     <a href="http://algs4.cs.princeton.edu/24pq">Section 2.4</a> of
     
     *
     
    
     *
     *  @param <TKey> the generic type of key on this priority queue
     *  
     ******************************************************************************/

    public class MaxPQ<Key>
        : PQBase<Key>
        , IMaxPriorityQueue<Key>
        where Key : IComparable<Key>
    {
        /**
         * Initializes an empty priority queue with the given initial capacity.
         *
         * @param  initCapacity the initial capacity of this priority queue
         */
        public MaxPQ(int initCapacity) : base (initCapacity) { }

        /**
         * Initializes an empty priority queue.
         */
        public MaxPQ() : base(1) { }

        /**
         * Initializes an empty priority queue with the given initial capacity,
         * using the given comparator.
         *
         * @param  initCapacity the initial capacity of this priority queue
         * @param  comparator the order in which to compare the keys
         */
        public MaxPQ(int initCapacity, IComparer<Key> comparator) : base(initCapacity, comparator) { }

        /**
         * Initializes an empty priority queue using the given comparator.
         *
         * @param  comparator the order in which to compare the keys
         */
        public MaxPQ(IComparer<Key> comparator) : base(0, comparator) { }

        /**
         * Initializes a priority queue from the array of keys.
         * Takes time proportional to the number of keys, using sink-based heap construction.
         *
         * @param  keys the array of keys
         */
        public MaxPQ(Key[] keys) : base (keys) { }
        
        
        /**
         * Returns a largest key on this priority queue.
         *
         * @return a largest key on this priority queue
         * Throws <see cref="InvalidOperationException" /> if this priority queue is empty
         */
        public Key Max { get { return Top; } }

        public int MaxIndex { get { return 1; } }


        /**
         * Removes and returns a largest key on this priority queue.
         *
         * @return a largest key on this priority queue
         * Throws <see cref="InvalidOperationException" /> if this priority queue is empty
         */
        public Key DeleteMax()
        {
            if (IsEmpty) throw new InvalidOperationException("Priority queue underflow");
            Key max = pq[1];
            exch(1, n--);
            sink(1);
            // to avoid loiterig and help with garbage collection
            //pq[n + 1] = null;     
            pq[n + 1] = default(Key);
            if ((n > 0) && (n == (pq.Length - 1) / 4)) resize(pq.Length / 2);
            // assert isMaxHeap();
            return max;
        }

        public override Key Delete()
        {
            return DeleteMax();
        }

        internal override PQBase<Key> Instance(int size, IComparer<Key> comparator)
        {
            return new MaxPQ<Key>(size, comparator);
        }

        //return less(i, j);
        internal override bool predicate(int i, int j)
        {
            return (comparator == null)
                    ? pq[i].CompareTo(pq[j]) < 0
                    : comparator.Compare(pq[i], pq[j]) < 0;
        }
                
    }
}
