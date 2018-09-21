// Collections
// aliases so no collisions with system types

namespace SedgewickWayne.Algorithms
{
  using System;
  using System.Text;
  using IEnumerable = System.Collections.IEnumerable;
  using IEnumerator = System.Collections.IEnumerator;
  using G = System.Collections.Generic;


  /// <summary>
  /// Linked list implementation of a queue. 
  /// <see href="https://algs4.cs.princeton.edu/13stacks/Queue.java.html"/> implements a generic FIFO queue using a linked list. 
  /// It maintains the queue as a linked list in order from least recently to most recently added items, 
  /// with the beginning of the queue referenced by an instance variable first and the end of the queue referenced by an instance variable last. 
  /// To enqueue() an item, we add it to the end of the list; to dequeue() an item, we remove it from the beginning of the list. 
  /// </summary>
  /// <typeparam name="TQueue">generic queue type</typeparam>
  public class Queue<TQueue> : IQueue<TQueue>
  {

    /// <summary>
    /// Supports custom iteration over the linked list queue implementation.
    /// </summary>
    /// <remarks>
    /// Java has <code>public boolean hasNext()</code> and <code>public Item next()</code>.
    /// .NET uses <see cref="MoveNext"/> and <see cref="current"/>.
    /// </remarks>
    internal sealed class QueueEnumerator : IEnumerator, G.IEnumerator<TQueue>
    {
      private Node current;

      public TQueue Current {
        get {
          // only move advances through the list
          if (current == null) throw new InvalidOperationException();
          return current.Item;
        }
      }

      object IEnumerator.Current { get { return Current; } }

      internal Queue<TQueue> queue;

      public QueueEnumerator(Queue<TQueue> queue, Node node)
      {
        this.queue = queue;
        this.current = node;
      }

      public bool MoveNext()
      {
        current = current.Next;
        bool hasNext = this.current != null;
        return hasNext;
      }

      public void Reset()
      {
        current = this.queue.first;
      }

      public void Dispose()
      {
        if (current != null)
        {
          current = null;
        }
      }
    }

    /// <summary>
    /// helper linked list node class
    /// </summary>
    internal sealed class Node
    {
      public Node(TQueue obj, Node n)
      {
        Item = obj;
        Next = n;
      }
      
      internal TQueue Item { get; private set; }

      internal Node Next { get; set; }
    }


    #region fields

    private int N;

    private Node first;

    private Node last;

    #endregion

    /// <summary>
    /// Initializes an empty queue.
    /// </summary>
    public Queue()
    {
      this.first = null;
      this.last = null;
      this.N = 0;
    }

    /// <summary>
    /// Adds the item to this queue.
    /// </summary>
    /// <param name="obj">the item to add</param>
    public void Enqueue(TQueue obj)
    {
      // old end ref
      Node oldLastNode = this.last;
      // new end
      this.last = new Node(obj, null);

      // special case for empty queue
      if (IsEmpty)
      {
        this.first = this.last;
      }
      else
      {
        // set old end next link to new end
        oldLastNode.Next = this.last;
      }

      this.N++;
    }

    /// <summary>
    /// Returns true if this queue is empty.
    /// </summary>
    public bool IsEmpty {
      get {
        return this.first == null;
      }
    }

    /// <summary>
    /// Removes and returns the item on this queue that was least recently added.
    /// </summary>
    /// <returns>the item on this queue that was least recently added</returns>
    public TQueue Dequeue()
    {
      if (IsEmpty)
      {
        throw new InvalidOperationException("Queue<TQueue> underflow");
      }

      var result = this.first.Item;

      // update first to former second
      this.first = this.first.Next;
      this.N--;

      // special empty case
      if (IsEmpty)
      {
        this.last = null;
      }
      return result;
    }

    /// <summary>
    /// Returns the number of items in this queue.
    /// </summary>
    public int Size {
      get {
        return this.N;
      }
    }

    /// <summary>
    /// Returns the item least recently added to this queue.
    /// </summary>
    /// <returns>the item least recently added to this queue</returns>
    public TQueue Peek()
    {
      if (IsEmpty) throw new InvalidOperationException("Queue<TQueue> underflow");
      return this.first.Item;
    }

    /// <summary>
    /// Returns a string representation of this queue.
    /// </summary>
    /// <returns>the sequence of items in FIFO order, separated by spaces</returns>
    public override string ToString()
    {
      StringBuilder stringBuilder = new StringBuilder();
      var iterator = new QueueEnumerator(this, this.first);

      while (iterator.MoveNext())
      {
        stringBuilder.Append(iterator.Current).Append(" ");
      }
      return stringBuilder.Remove(stringBuilder.Length - 1, 1).ToString();
    }

    /// <summary>
    /// Returns an iterator that iterates over the items in this queue in FIFO order.
    /// </summary>
    /// <returns>an iterator that iterates over the items in this queue in FIFO order</returns>
    public G.IEnumerator<TQueue> GetEnumerator()
    {
      return new QueueEnumerator(this, this.first);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

  }

}
