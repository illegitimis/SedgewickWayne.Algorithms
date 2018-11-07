



namespace SedgewickWayne.Algorithms
{

  using System;
  using System.Collections;
  using System.Diagnostics.Contracts;
  using System.Runtime.CompilerServices;
  using System.Text;
  

  /// <summary>
  /// Linked-list implementation.
  /// ・Every operation takes constant time in the worst case.
  /// ・Uses extra time and space to deal with the links.
  /// faster, uses more memory
  /// </summary>
  public class LinkedStack : IStack
  {
    /// <summary>
    /// Returns an enumerator that iterates through a collection.
    /// </summary>
    /// <returns>An System.Collections.IEnumerator object that can be used to iterate through the collection.</returns>
    public IEnumerator GetEnumerator()
    {
      return new ListIterator(this);
    }

    /*internal*/
    public sealed class ListIterator : IEnumerator
    {

      private LinkedStack.Node current;

      internal LinkedStack parentStack;

      public object Current
      {
        get
        {
          var memo = this.current.item;
          this.current = this.current.next;
          return memo;
        }
      }

      internal ListIterator(LinkedStack linkedStack)
      {
        this.parentStack = linkedStack;
        this.current = linkedStack.first;
      }

      /// <summary>
      /// public virtual bool hasNext()
      /// </summary>
      /// <returns></returns>
      public bool MoveNext()
      {
        return (this.current != null);
      }

      public void Reset()
      {
        current = parentStack.first;
      }
    }

    internal sealed class Node
    {
      /*private*/
      internal object item;

      internal LinkedStack.Node next;

      internal LinkedStack parent;

      internal static object GetNodeObject(LinkedStack.Node node) { return node.item; }

      
      internal Node(LinkedStack linkedStack, Node next)
      {
        parent = linkedStack;
        item = null;
        this.next = next;
      }
    }


    private int N;

    private LinkedStack.Node first;

    internal static bool s_assertionsDisabled = false;



    private bool check()
    {
      if (this.N == 0)
      {
        if (this.first != null) return false;        
      }
      else if (this.N == 1)
      {
        if (this.first == null) return false;
        if (this.first.next != null) return false;        
      }
      else if (this.first.next == null) return false;

      int num = 0;
      for (LinkedStack.Node node = this.first; node != null; node = node.next)
      {
        num++;
      }
      return num == this.N;
    }
    public bool IsEmpty { get { return this.first == null; } }


    void ArgumentOutOfRangeException()
    {
      if (!LinkedStack.s_assertionsDisabled)
      {
        Contract.Assert(check());
      }
    }

    public LinkedStack()
    {
      this.first = null;
      this.N = 0;
      ArgumentOutOfRangeException();
    }


    public void Push(object obj)
    {
      // save a link to the list
      LinkedStack.Node node = this.first;
      // create a new node for the beginning
      this.first = new Node(this, null);
      //  set value
      this.first.item = obj;
      // set next link
      this.first.next = node;
      
      this.N++;
      ArgumentOutOfRangeException();
    }


    public object Pop()
    {
      if (IsEmpty)
      {
        throw new NotSupportedException("Stack underflow");
      }
      // save current 1st value
      object result = this.first.item;
      // update first to former second
      this.first = this.first.next;
      // decrease count
      this.N--;
      ArgumentOutOfRangeException();
      return result;
    }
    public int Size
    { 
      get { return this.N; }
    }


    public object Peek()
    {
      if (IsEmpty) throw new NotSupportedException("Stack underflow");

      return this.first.item;
    }


    public override string ToString()
    {
      StringBuilder stringBuilder = new StringBuilder();
      var iterator = new ListIterator(this);
      while (iterator.MoveNext())
      {
        object obj = iterator.Current;
        stringBuilder.AppendFormat("{0} ", obj);
      }
      stringBuilder.Remove(stringBuilder.Length - 1, 1);
      return stringBuilder.ToString();
    }

   
    static LinkedStack()
    {
      //LinkedStack.s_assertionsDisabled = !ClassLiteral<LinkedStack>.Value.desiredAssertionStatus();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return new ListIterator(this);
    }
  }
}