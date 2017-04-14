
namespace SedgewickWayne.Algorithms
{
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;



 public class Bag : IBag
  {
    
    internal sealed class BagEnumerator : IEnumerator
    {
      Node current;
      internal Bag bag;

      public BagEnumerator(Bag bag)
      {
        this.bag = bag;
        this.current = bag.first;
      }
      public BagEnumerator(Bag bag, Node node)
      {
        this.bag = bag;
        this.current = node;
      }
      public bool MoveNext()
      {
        return this.current != null;
      }

      public void Reset()
      {
        this.current = this.bag.first;
      }

      public void Dispose()
      {
        //throw new NotImplementedException();
      }

      /*		[Signature("()object;")]*/

      object IEnumerator.Current
      {
        get
        {
          return Current;
        }
      }

      public object Current
      {
        get
        {
          if (current == null) throw new InvalidOperationException();

          object result = this.current.Item;
          this.current = this.current.Next;
          return result;
        }
      }
    }

    internal sealed class Node
    {
      //[Signature("TItem;")]
      public object Item { get; private set; }

      //[Signature("LBag$Node<TItem;>;")]
      public Node Next { get; private set; }

      public Node(object item, Node next)
      {
        Item = item;
        Next = next;
      }
    }

    private int N;
    //[Signature("LBag$Node<TItem;>;")]
    private Node first;

    // public bool IsEmpty
    public bool IsEmpty
    {
      get
      {
        return this.first == null;
      }
    }

    public Bag()
    {
      this.first = null;
      this.N = 0;
    }
    
    public void Add(object obj)
    {
      var oldFirst = this.first;
      this.first = new Node(obj, oldFirst);
      this.N++;
    }
    public int Size { get { return this.N; } }


    public IEnumerator GetEnumerator()
    {
      return new BagEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return new BagEnumerator(this);
    }


  }
}
