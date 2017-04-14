// Collections

namespace SedgewickWayne.Algorithms
{
  using System;
  using System.Linq;
  using System.Text;

  // aliases so no collisions with system types
  

  
  public class LinkedQueue : IQueue
  {
    
    internal sealed class QueueEnumerator : System.Collections.IEnumerator
    {
      Node current;

      internal LinkedQueue queue;

      public QueueEnumerator(LinkedQueue queue, Node node)
      {
                this.queue = queue;
                this.current = node;
      }
      public bool MoveNext()
      {
        bool hasNext = this.current != null;
        current = current.Next;
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

      public object Current
      {
        get
        {
          // only move advances through the list
          if (current == null) throw new InvalidOperationException();
          return current.Item;
        }
      }

      object System.Collections.IEnumerator.Current { get { return Current; } }
    }

    /*
    [InnerClass(null, Modifiers.Private | Modifiers.Static), Modifiers(Modifiers.Super), 
    Signature("<Item:Ljava/lang/Object;>Ljava/lang/Object;"), SourceFile("Queue.java")]
    looks non generic but inherits outer object
    */

    internal sealed class Node
    {
      public Node(object obj, Node n)
      {
        Item = obj;
        Next = n;
      }

      internal object Item { get; private set; }

      internal Node Next { get; set; }
    }



    private int N;
    private Node first;
    private Node last;

    public LinkedQueue()
    {
      this.first = null;
      this.last = null;
      this.N = 0;
    }
    
    public void Enqueue(object obj)
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
    public bool IsEmpty
    {
      get
      {
        return this.first == null;
      }
    }

    public object Dequeue()
    {
      if (IsEmpty)
      {
        throw new InvalidOperationException("Queue underflow");
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

    public int Size
    {
      get
      {
        return this.N;
      }
    }

    public object Peek()
    {
      if (IsEmpty)
      {
        throw new InvalidOperationException("Queue underflow");
      }
      return this.first.Item;
    }


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

    public System.Collections.IEnumerator GetEnumerator()
    {
      return new QueueEnumerator(this, this.first);
    }
    
  }
}
