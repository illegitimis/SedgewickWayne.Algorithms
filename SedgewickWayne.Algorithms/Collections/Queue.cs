// Collections

namespace SedgewickWayne.Algorithms
{
  using System;
  using System.Linq;
  using System.Text;

  // aliases so no collisions with system types
  using IEnumerable = System.Collections.IEnumerable;
  using IEnumerator = System.Collections.IEnumerator;
  //using IEnumerable<TQueue> = System.Collections.Generic.IEnumerable<TQueue>;
  using G = System.Collections.Generic;
  using System.Collections;

  /*
  [Implements(new string[] { "java.lang.Iterable" })]
  [Signature("<Item:Ljava/lang/Object;>Ljava/lang/Object;Ljava/lang/Iterable<TItem;>;")]
  */
  public class Queue<TQueue> : IQueue<TQueue>
  {
    

    /*
    [Implements(new string[] { "java.util.Iterator" }), 
    InnerClass(null, Modifiers.Private), Modifiers(Modifiers.Super), 
    Signature("<Item:Ljava/lang/Object;>Ljava/lang/Object;Ljava/util/Iterator<TItem;>;"), 
    SourceFile("Queue.java")]
    */
    internal sealed class QueueEnumerator : IEnumerator, G.IEnumerator<TQueue>
    {
      //[Signature("LQueue$Node<TItem;>;")]
      private Node current;

      /*		
      [Signature("(LQueue$Node<TItem;>;)V")]
      [Modifiers(Modifiers.Final | Modifiers.Synthetic)]
      */
      internal Queue<TQueue> queue;


      public QueueEnumerator(Queue<TQueue> queue, Node node)
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

      /*		[Signature("()TItem;")] */

      public TQueue Current
      {
        get
        {
          // only move advances through the list
          if (current == null) throw new InvalidOperationException();
          return current.Item;
        }
      }

      object IEnumerator.Current { get { return Current; } }
    }

    /*
    [InnerClass(null, Modifiers.Private | Modifiers.Static), Modifiers(Modifiers.Super), 
    Signature("<Item:Ljava/lang/Object;>Ljava/lang/Object;"), SourceFile("Queue.java")]
    looks non generic but inherits outer TQueue
    */

    internal sealed class Node
    {
      public Node(TQueue obj, Node n)
      {
        Item = obj;
        Next = n;
      }

      //[Signature("TItem;")]
      internal TQueue Item { get; private set; }

      //[Signature("LQueue$Node<TItem;>;")]
      internal Node Next { get; set; }
      

      // access_200(Node node) GET next
      // access_000(Node node) GET accessor item
      // access_002(Node node, object result) GET accessor item
      // access_202(Node node, Node result) SET next

    }



private int N;
//[Signature("LQueue$Node<TItem;>;")]
private Node first;
//[Signature("LQueue$Node<TItem;>;")]
private Node last;

    /*
    [EnclosingMethod("Queue", null, null)] 
    [InnerClass(null, Modifiers.Static | Modifiers.Synthetic), Modifiers(Modifiers.Super | Modifiers.Synthetic), 
    [SourceFile("Queue.java")]
    */
    public Queue()
{
  this.first = null;
  this.last = null;
  this.N = 0;
}
    /*	[Signature("(TItem;)V")]*/

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
public bool IsEmpty { get
      {
        return this.first == null;
      }
    }

/*	[Signature("()TItem;")]*/

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

/*	[LineNumberTable(126), Signature("()Ljava/util/Iterator<TItem;>;")]*/

public int Size { get{
  return this.N;
}}

/*	[Signature("()TItem;")]*/

public TQueue Peek()
{
  if (IsEmpty)
  {
    throw new InvalidOperationException("Queue<TQueue> underflow");
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

    public G.IEnumerator<TQueue> GetEnumerator()
    {
      return new QueueEnumerator(this, this.first);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }


    /*
    public static void main(string[] strarr)
    {
      Queue<TQueue> Queue<TQueue> = new Queue();
      while (!StdIn.IsEmpty)
      {
        string text = StdIn.readString();
        if (!java.lang.String.instancehelper_equals(text, "-"))
        {
          queue.enqueue(text);
        }
        else if (!queue.IsEmpty)
        {
          StdOut.print(new StringBuilder().append((string)queue.dequeue()).append(" ").toString());
        }
      }
      StdOut.println(new StringBuilder().append("(").append(queue.Size).append(" left on queue)").toString());
    }
    */


  }
}
