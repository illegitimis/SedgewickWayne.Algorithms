
namespace SedgewickWayne.Algorithms
{
  using System;
  using System.Collections;
  using System.Collections.Generic;

  /// <summary>
  /// A bag is a collection where removing items is not supported—its purpose is to provide clients with the ability to collect items and then to iterate through the collected items.
  /// </summary>
  /// <typeparam name="TBag"></typeparam>
  public class Bag<TBag> : IBag<TBag>
  {
    /*
    [Implements(new string[] {"java.util.Iterator"})]
    [InnerClass(null, Modifiers.Private)]
    [Modifiers(Modifiers.Super)] 
    [Signature("<Item:Ljava/lang/Object;>Ljava/lang/Object;Ljava/util/Iterator<TItem;>;")]
    [SourceFile("java")]
    */
    internal sealed class BagEnumerator : IEnumerator<TBag>
    {
      // [Signature("LBag$Node<TBag;>;")]
      private Node current;

      // [Modifiers(Modifiers.Final | Modifiers.Synthetic)]
      // [Signature("(LBag$Node<TBag;>;)V")]
      internal Bag<TBag> bag;

      public BagEnumerator(Bag<TBag> bag)
      {
        this.bag = bag;
        this.current = bag.first;
      }
      public BagEnumerator(Bag<TBag> bag, Node node)
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

      /*		[Signature("()TBag;")]*/

      object IEnumerator.Current
      {
        get
        {
          return Current;
        }
      }

      public TBag Current
      {
        get
        {
          if (current == null) throw new InvalidOperationException();

          TBag result = this.current.Item;
          this.current = this.current.Next;
          return result;
        }
      }
    }

    //[InnerClass(null, Modifiers.Private | Modifiers.Static), Modifiers(Modifiers.Super), Signature("<Item:Ljava/lang/Object;>Ljava/lang/Object;"), SourceFile("java")]
    internal sealed class Node
    {
      //[Signature("TItem;")]
      public TBag Item { get; private set; }

      //[Signature("LBag$Node<TItem;>;")]
      public Node Next { get; private set; }

      public Node(TBag item, Node next)
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
    /*	[Signature("(TItem;)V")]*/

    public void Add(TBag obj)
    {
      var oldFirst = this.first;
      this.first = new Node(obj, oldFirst);
      this.N++;
    }
    public int Size { get { return this.N; } }


    /* [LineNumberTable(101), Signature("()Ljava/util/Iterator<TItem;>;")] */
    public IEnumerator<TBag> GetEnumerator()
    {
      return new BagEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return new BagEnumerator(this);
    }

  }
}
