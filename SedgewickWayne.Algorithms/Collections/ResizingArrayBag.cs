// Collections

namespace SedgewickWayne.Algorithms
{
  using System;
  using System.Collections;

  public class ResizingArrayBag : IBag
  {
    internal sealed class ArrayIterator : System.Collections.IEnumerator
    {
      private int i;
      internal ResizingArrayBag bag;

      internal ArrayIterator(ResizingArrayBag resizingArrayBag, int i)
      {
        this.bag = resizingArrayBag;
        this.i = i;
      }
      private ArrayIterator(ResizingArrayBag resizingArrayBag) : this(resizingArrayBag, 0) { }

      public bool MoveNext()
      {
        bool hasNext = i < bag.N;
        this.i++;
        return hasNext;
      }


      public void Reset()
      {
        i = 0;
      }


      public object Current { get
        {
          if (i >= bag.N) throw new InvalidOperationException();



          return bag.a[i];
        }
      }
    }
//[Signature("[TItem;")]
private object[] a;
private int N;

        //[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
        //internal static bool s_assertionsDisabled;




private void resize(int num)
{
  if (/*!s_assertionsDisabled && */ num < this.N)
      {

        throw new ArgumentOutOfRangeException("num");
  }
  object[] array = new object[num];
  for (int i = 0; i < this.N; i++)
  {
    array[i] = this.a[i];
  }
  this.a = array;
}


public ResizingArrayBag()
{
  this.N = 0;
  this.a = new object[2];
}


public void Add(object obj)
{
  if (this.N == this.a.Length)
  {
    this.resize(2 * this.a.Length);
  }
  object[] arg_38_0 = this.a;
  int n = this.N;
  int arg_38_1 = n;
  this.N = n + 1;
  arg_38_0[arg_38_1] = obj;
}
/*	[LineNumberTable(80), Signature("()Ljava/util/Iterator<TItem;>;")]*/

public IEnumerator GetEnumerator()
{
  return new ArrayIterator(this, this.N);
}

       

    public bool IsEmpty { get { return this.N == 0; } }

public int Size
    {
      get
      {
        {
          return this.N;
        }
      }
    }


/*
public static void main(string[] strarr)
{
  ResizingArrayBag resizingArrayBag = new ResizingArrayBag();
  add("Hello");
  add("World");
  add("how");
  add("are");
  add("you");
  Iterator iterator = iterator();
  while (iterator.MoveNext())
  {
    string obj = (string)iterator.Current;
    StdOut.println(obj);
  }
}*/



static ResizingArrayBag()
{
  //s_assertionsDisabled = !ClassLiteral<ResizingArrayBag>.Value.desiredAssertionStatus();
}


}


}
