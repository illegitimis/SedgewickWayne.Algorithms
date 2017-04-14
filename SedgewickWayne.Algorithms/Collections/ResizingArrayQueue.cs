// Collections

namespace SedgewickWayne.Algorithms
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;

  /*[Implements(new string[]
  {
    "java.lang.Iterable"
  }), Signature("<Item:Ljava/lang/Object;>Ljava/lang/Object;Ljava/lang/Iterable<TItem;>;")]*/
  public class ResizingArrayQueue : IQueue
  {
    /*[EnclosingMethod("ResizingArrayQueue", null, null), InnerClass(null, Modifiers.Static | Modifiers.Synthetic), Modifiers(Modifiers.Super | Modifiers.Synthetic), SourceFile("ResizingArrayQueue.java")]*/

    /*[Implements(new string[]
    {
      "java.util.Iterator"
    }), InnerClass(null, Modifiers.Private), Modifiers(Modifiers.Super), Signature("Ljava/lang/Object;Ljava/util/Iterator<TItem;>;"), SourceFile("ResizingArrayQueue.java")]*/
    internal sealed class ArrayIterator : System.Collections.IEnumerator
    {
      int i;
      ResizingArrayQueue q;

      internal ArrayIterator(ResizingArrayQueue q, int n) 
      {
        this.q = q;
        i = n;
      }

      private ArrayIterator(ResizingArrayQueue resizingArrayQueue) : this (resizingArrayQueue,resizingArrayQueue.N){ }
      
      public bool MoveNext()
      {
        bool hasNext = this.i < q.N;
        this.i++;
        return hasNext;
      }

      public void Reset()
      {
        i = 0;
      }
      
      public object Current { get
        {
          if (this.i >= q.N) throw new InvalidOperationException();
          
          object[] arg_46_0 = q.q;
          int offset = this.i + q.first;
          int qlen = q.q.Length;
          object result = arg_46_0[(qlen != -1) ? (offset % qlen) : 0];
          
          return result;
        } }
    }
    //[Signature("[TItem;")]
    private object[] q;
    private int N;
    private int first;
    private int last;
    

    private void resize(int num)
    {
      if (num < this.N)
      {
        throw new ArgumentOutOfRangeException();
      }
      object[] array = (object[])new object[num];
      for (int i = 0; i < this.N; i++)
      {
        object[] arg_54_0 = array;
        int arg_54_1 = i;
        object[] arg_53_0 = this.q;
        int expr_41 = this.first + i;
        int expr_49 = this.q.Length;
        arg_54_0[arg_54_1] = arg_53_0[(expr_49 != -1) ? (expr_41 % expr_49) : 0];
      }
      this.q = array;
      this.first = 0;
      this.last = this.N;
    }
    public bool IsEmpty { get
    {
  return this.N == 0;
    }
    }


    public ResizingArrayQueue()
    {
      this.N = 0;
      this.first = 0;
      this.last = 0;
      this.q = (object[])new object[2];
    }
    /*	[Signature("(TItem;)V")]*/

    public void Enqueue(object obj)
    {
      if (this.N == this.q.Length)
      {
        this.resize(2 * this.q.Length);
      }
      object[] arg_38_0 = this.q;
      int num = this.last;
      int arg_38_1 = num;
      this.last = num + 1;
      arg_38_0[arg_38_1] = obj;
      if (this.last == this.q.Length)
      {
        this.last = 0;
      }
      this.N++;
    }
    /*	[Signature("()TItem;")]*/

    public object Dequeue()
    {
      if (IsEmpty)
      {
        string arg_12_0 = "Queue underflow";

        throw new InvalidOperationException(arg_12_0);
      }
      object result = this.q[this.first];
      this.q[this.first] = null;
      this.N--;
      this.first++;
      if (this.first == this.q.Length)
      {
        this.first = 0;
      }
      if (this.N > 0 && this.N == this.q.Length / 4)
      {
        this.resize(this.q.Length / 2);
      }
      return result;
    }
    public int Size
    {
      get
      {
        {
          return this.N;
        }
      }
    }
/*	[Signature("()TItem;")]*/

public object Peek()
{
  if (IsEmpty) throw new InvalidOperationException("Queue underflow");
  return this.q[this.first];
}
/*	[LineNumberTable(124), Signature("()Ljava/util/Iterator<TItem;>;")]*/

public System.Collections.IEnumerator GetEnumerator()
{
  return new ArrayIterator(this, this.first);
}


/*
public static void main(string[] strarr)
{
  ResizingArrayQueue resizingArrayQueue = new ResizingArrayQueue();
  while (!StdIn.IsEmpty)
  {
    string text = StdIn.readString();
    if (!java.lang.String.instancehelper_equals(text, "-"))
    {
      resizingArrayQueue.enqueue(text);
    }
    else if (!resizingArrayQueue.IsEmpty)
    {
      StdOut.print(new StringBuilder().append((string)resizingArrayQueue.dequeue()).append(" ").toString());
    }
  }
  StdOut.println(new StringBuilder().append("(").append(resizingArrayQueue.Size).append(" left on queue)").toString());
}*/

/*	[LineNumberTable(36), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
internal static int access_100(ResizingArrayQueue resizingArrayQueue)
{
  return resizingArrayQueue.N;
}




static ResizingArrayQueue()
{
  //ResizingArrayQueue.s_assertionsDisabled = !ClassLiteral<ResizingArrayQueue>.Value.desiredAssertionStatus();
}

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
{
      return new ArrayIterator(this, this.N);
}
}




}
