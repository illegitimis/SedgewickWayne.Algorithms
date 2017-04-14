
namespace Graph.Princeton
{

  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;
  using System.Collections;

 /******************************************************************************
 *  Compilation:  javac MinPQ.java
 *  Execution:    java MinPQ < input.txt
 *  Dependencies: StdIn.java StdOut.java
 *  Data files:   http://algs4.cs.princeton.edu/24pq/tinyPQ.txt
 *  Src:          http://algs4.cs.princeton.edu/24pq/MinPQ.java
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

/**
 *  The {@code MinPQ} class represents a priority queue of generic keys.
 *  It supports the usual <em>insert</em> and <em>delete-the-minimum</em>
 *  operations, along with methods for peeking at the minimum key,
 *  testing if the priority queue is empty, and iterating through
 *  the keys.
 *  <p>
 *  This implementation uses a BINARY HEAP.
 *  The <em>insert</em> and <em>delete-the-minimum</em> operations take
 *  logarithmic amortized time.
 *  The <em>min</em>, <em>size</em>, and <em>is-empty</em> operations take constant time.
 *  Construction takes time proportional to the specified capacity or the number of
 *  items used to initialize the data structure.
 *  <p>
 *  For additional documentation, see <a href="http://algs4.cs.princeton.edu/24pq">Section 2.4</a> of
 *  <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.
 *
 *  @author Robert Sedgewick
 *  @author Kevin Wayne
 *
 *  @param <Key> the generic type of key on this priority queue
 */
public class MinPQ<Key> : IEnumerable<Key> 
  where Key : class
{
    private Key[] pq;                    // store items at indices 1 to n
    private int n;                       // number of items on priority queue
    private IComparer<Key> comparator;  // optional comparator

    /**
     * Initializes an empty priority queue with the given initial capacity.
     *
     * @param  initCapacity the initial capacity of this priority queue
     */
    public MinPQ(int initCapacity) {
        pq = new Key[initCapacity + 1];
        n = 0;
    }

    /**
     * Initializes an empty priority queue.
     */
    public MinPQ() : this(1) { }

    /**
     * Initializes an empty priority queue with the given initial capacity,
     * using the given comparator.
     *
     * @param  initCapacity the initial capacity of this priority queue
     * @param  comparator the order to use when comparing keys
     */
    public MinPQ(int initCapacity, IComparer<Key> comparator) 
      : this (initCapacity) {
        this.comparator = comparator;
    }

    /**
     * Initializes an empty priority queue using the given comparator.
     *
     * @param  comparator the order to use when comparing keys
     */
    public MinPQ(IComparer<Key> comparator) : this(1, comparator) { }

    /**
     * Initializes a priority queue from the array of keys.
     * <p>
     * Takes time proportional to the number of keys, using sink-based heap construction.
     *
     * @param  keys the array of keys
     */
    public MinPQ(Key[] keys) {
        n = keys.Length;
        pq = new Key[keys.Length + 1];
        for (int i = 0; i < n; i++) pq[i+1] = keys[i];
        for (int k = n/2; k >= 1; k--) sink(k);
        Contract.Assert(isMinHeap);
    }

    /**
     * Returns true if this priority queue is empty.
     *
     * @return {@code true} if this priority queue is empty;
     *         {@code false} otherwise
     */
    public bool IsEmpty { get {return n == 0;}}

    /**
     * Returns the number of keys on this priority queue.
     *
     * @return the number of keys on this priority queue
     */
    public int Size { get { return n; } }

    /**
     * Returns a smallest key on this priority queue.
     *
     * @return a smallest key on this priority queue
     * @throws NoSuchElementException if this priority queue is empty
     */
    public Key Min() {
        if (IsEmpty) throw new Exception("Priority queue underflow");
        return pq[1];
    }

    // helper function to double the size of the heap array
    private void resize(int capacity) 
    {
        Contract.Assert (capacity > n);
        Key[] temp = new Key[capacity];
        for (int i = 1; i <= n; i++) temp[i] = pq[i];
        pq = temp;
    }

    /**
     * Adds a new key to this priority queue.
     *
     * @param  x the key to add to this priority queue
     */
    public void Insert(Key x) 
    {
        // double size of array if necessary
        if (n == pq.Length - 1) resize(2 * pq.Length);

        // add x, and percolate it up to maintain heap invariant
        pq[++n] = x;
        swim(n);

        Contract.Assert(isMinHeap);
    }

    /**
     * Removes and returns a smallest key on this priority queue.
     *
     * @return a smallest key on this priority queue
     * @throws NoSuchElementException if this priority queue is empty
     */
    public Key delMin() {
        if (IsEmpty) throw new Exception("Priority queue underflow");
        exch(1, n);
        Key min = pq[n--];
        sink(1);
        // avoid loitering and help with garbage collection
        pq[n+1] = null;         
        if ((n > 0) && (n == (pq.Length - 1) / 4)) resize(pq.Length  / 2);
        Contract.Assert(isMinHeap);
        return min;
    }


   /***************************************************************************
    * Helper functions to restore the heap invariant.
    ***************************************************************************/

    private void swim(int k) {
        while (k > 1 && greater(k/2, k)) {
            exch(k, k/2);
            k = k/2;
        }
    }

    private void sink(int k) {
        while (2*k <= n) {
            int j = 2*k;
            if (j < n && greater(j, j+1)) j++;
            if (!greater(k, j)) break;
            exch(k, j);
            k = j;
        }
    }

   /***************************************************************************
    * Helper functions for compares and swaps.
    ***************************************************************************/
    private bool greater(int i, int j) {
      return (comparator == null) 
        ? ((IComparable<Key>) pq[i]).CompareTo(pq[j]) > 0
        : comparator.Compare(pq[i], pq[j]) > 0;
    }

    private void exch(int i, int j) {
        Key swap = pq[i];
        pq[i] = pq[j];
        pq[j] = swap;
    }

    // is pq[1..N] a min heap?
    private bool isMinHeap { get {return IsMinHeap(1);} }

    // is subtree of pq[1..n] rooted at k a min heap?
    private bool IsMinHeap(int k) {
        if (k > n) return true;
        int left = 2*k;
        int right = 2*k + 1;
        if (left  <= n && greater(k, left))  return false;
        if (right <= n && greater(k, right)) return false;
        return IsMinHeap(left) && IsMinHeap(right);
    }


    /**
     * Returns an iterator that iterates over the keys on this priority queue
     * in ascending order.
     * <p>
     * The iterator doesn't implement {@code remove()} since it's optional.
     *
     * @return an iterator that iterates over the keys in ascending order
     */
    //public IEnumerator<Key> Iterator { get { return new HeapIterator(); } }

    //private class HeapIterator : IEnumerator<Key> {
    //    // create a new pq
    //    private MinPQ<Key> copy;

    //    // add all items to copy of heap
    //    // takes linear time since already in heap order so no keys move
    //    public HeapIterator() {
    //        if (comparator == null) copy = new MinPQ<Key>(size());
    //        else                    copy = new MinPQ<Key>(size(), comparator);
    //        for (int i = 1; i <= n; i++)
    //            copy.insert(pq[i]);
    //    }

    //    public bool hasNext()  { return !copy.isEmpty();                     }
    //    public void remove()      { throw new UnsupportedOperationException();  }

    //    public Key next() {
         
    //    }

    //    #region IEnumerator<Key> Members

    //    public Key Current
    //    {
    //      get { throw new NotImplementedException(); }
    //    }

    //    #endregion

    //    #region IDisposable Members

    //    public void Dispose ( )
    //    {
    //      throw new NotImplementedException();
    //    }

    //    #endregion

    //    #region IEnumerator Members

    //    object System.Collections.IEnumerator.Current
    //    {
    //      get { throw new NotImplementedException(); }
    //    }

    //    public bool MoveNext ( )
    //    {
    //      if (copy.IsEmpty) throw new Exception("NoSuchElement");
    //      return copy.delMin();
    //    }

    //    public void Reset ( )
    //    {
    //      throw new NotImplementedException();
    //    }

    //    #endregion
    //}


    #region IEnumerable<Key> Members

    public IEnumerator<Key> GetEnumerator ( )
    {
      return (new List<Key>(pq)).GetEnumerator();
    }

    #endregion

    #region IEnumerable Members

    

    #endregion

    #region IEnumerable Members

    IEnumerator IEnumerable.GetEnumerator ( )
    {
      return pq.GetEnumerator();
    }

    #endregion
}
}






