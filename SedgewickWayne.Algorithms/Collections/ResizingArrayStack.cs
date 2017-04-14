

namespace SedgewickWayne.Algorithms
{

  using System;
  using System.Collections;
  using System.Runtime.CompilerServices;
  using System.Text;
  /// <summary>
  /// Resizing-array implementation.
  /// ・Every operation takes constant amortized time.
  /// ・Less wasted space.
  /// slower, better memory use
  /// </summary>
  public class ResizingArrayStack : IStack
  {
    #region IEnumerable
    IEnumerator IEnumerable.GetEnumerator()
    {
      return new ReverseArrayIterator(this);
    }

    IEnumerator GetEnumerator()
    {
      return new ReverseArrayIterator(this);
    }

    /// <summary>
    /// Enumerators can be used to read the data in the collection, but they cannot be used to modify the underlying collection.
    /// </summary>
    internal sealed class ReverseArrayIterator : IEnumerator
    {
      int i;
      /// <summary>
      /// An enumerator remains valid as long as the collection remains unchanged. 
      /// If changes are made to the collection, such as adding, modifying, or deleting elements, the enumerator is irrecoverably invalidated and its behavior is undefined.
      /// </summary>
      readonly ResizingArrayStack parent;

      /// <summary>
      /// Current returns the same object until either MoveNext or Reset is called.
      /// Initially, the enumerator is positioned before the first element in the collection.
      /// At this position, Current is undefined. 
      /// Therefore, you must call MoveNext to advance the enumerator to the first element of the collection before reading the value of Current.
      /// </summary>
      public object Current 
      {
        get
        {
          return parent.a[i];
        }
      }

      /// <summary>
      /// MoveNext sets Current to the next element.
      /// If MoveNext passes the end of the collection, the enumerator is positioned after the last element in the collection and MoveNext returns false.
      /// When the enumerator is at this position, subsequent calls to MoveNext also return false.
      /// </summary>
      /// <returns></returns>
      public bool MoveNext()
      {
        bool hasNext = (i > 0);
        i--;
        return hasNext;
      }

      /// <summary>
      /// Reset also brings the enumerator back to this position. (before 1st elem)
      /// </summary>
      public void Reset()
      {
        // nothing to do, current position is starting position ???
        i = parent.N;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public ReverseArrayIterator(ResizingArrayStack resizingArrayStack)
      {
        this.i = resizingArrayStack.N;
        this.parent = resizingArrayStack;
      }

    }    
    #endregion

    private object[] a;
    private int N;

    internal static bool s_assertionsDisabled = false;

    static ResizingArrayStack()
    {
      //s_assertionsDisabled = !ClassLiteral<ResizingArrayStack>.Value.desiredAssertionStatus();
    }
    public ResizingArrayStack()
    {
      this.a = (object[])new object[2];
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      var iterator = new ReverseArrayIterator(this);
      while (iterator.MoveNext())
      {
        sb.Append(iterator.Current);
        sb.Append(' ');
      }
      sb.Remove(sb.Length - 1, 1);
      return sb.ToString();
    }

    #region IStack
    public bool IsEmpty { get { return this.N == 0; } }
    public void push(object obj)
    {
      if (this.N == this.a.Length)
      { // capacity check, repeated doubling
        resize(2 * this.a.Length);
      }

      // increment count and assign
      this.a[N] = obj;
      this.N++;
    }
    public object pop()
    {
      StackUnderflowCheck();
      // store last
      object last = a[N - 1];
      // gc help
      a[N - 1] = null;
      // no items update
      N--;
      // smart resize, halve when size is one-quarter full
      if (this.N > 0 && this.N == this.a.Length / 4)
      {
        this.resize(this.a.Length / 2);
      }

      return last;
    }
    public int Size { get { return this.N; } }
    public object peek()
    {
      StackUnderflowCheck();
      return this.a[this.N - 1];
    }


    void StackUnderflowCheck()
    {
      if (IsEmpty) throw new NotSupportedException("Stack underflow");
    }
    
    /// <summary>
    /// Invariant. Array is between 25% and 100% full.
    /// </summary>
    /// <param name="num"></param>
    void resize(int num)
    {
      if (!ResizingArrayStack.s_assertionsDisabled)
      {
        if (num < this.N) throw new ArgumentException(num.ToString());
      }

      object[] array = new object[num];
      for (int i = 0; i < this.N; i++)
      {
        array[i] = this.a[i];
      }
      this.a = array;
    }

    #endregion
  }



}

