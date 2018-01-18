// http://algs4.cs.princeton.edu/34hash/LinearProbingHashST.java.html

namespace SedgewickWayne.Algorithms.SymbolTables
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    class LinearProbingHashST
    {
    }
}



////[Signature("<TKey:Ljava/lang/Object;Value:Ljava/lang/Object;>Ljava/lang/Object;")]
//public class LinearProbingHashST
//{
//    private const int INIT_CAPACITY = 4;
//    private int N;
//    private int M;
//    //[Signature("[TKey;")]
//    private object[] keys;
//    //[Signature("[TValue;")]
//    private object[] vals;
//    //[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
//    internal static bool s_assertionsDisabled;




//    public LinearProbingHashST(int i)
//    {
//        this.M = i;
//        this.keys = (object[])new object[this.M];
//        this.vals = (object[])new object[this.M];
//    }
//    public virtual int size()
//    {
//        return this.N;
//    }
//    /*	[Signature("(TKey;)TValue;")]*/

//    public virtual object get(object obj)
//    {
//        int num = this.hash(obj);
//        while (this.keys[num] != null)
//        {
//            if (java.lang.Object.instancehelper_equals(this.keys[num], obj))
//            {
//                return this.vals[num];
//            }
//            int expr_2D = num + 1;
//            int expr_34 = this.M;
//            num = ((expr_34 != -1) ? (expr_2D % expr_34) : 0);
//        }
//        return null;
//    }
//    /*	[Signature("(TKey;TValue;)V")]*/

//    public virtual void put(object obj1, object obj2)
//    {
//        if (obj2 == null)
//        {
//            this.delete(obj1);
//        }
//        if (this.N >= this.M / 2)
//        {
//            this.resize(2 * this.M);
//        }
//        int num = this.hash(obj1);
//        while (this.keys[num] != null)
//        {
//            if (java.lang.Object.instancehelper_equals(this.keys[num], obj1))
//            {
//                this.vals[num] = obj2;
//                return;
//            }
//            int expr_56 = num + 1;
//            int expr_5D = this.M;
//            num = ((expr_5D != -1) ? (expr_56 % expr_5D) : 0);
//        }
//        this.keys[num] = obj1;
//        this.vals[num] = obj2;
//        this.N++;
//    }
//    /*	[Signature("(TKey;)V")]*/

//    public virtual void delete(object obj)
//    {
//        if (!this.contains(obj))
//        {
//            return;
//        }
//        int num = this.hash(obj);
//        while (!java.lang.Object.instancehelper_equals(obj, this.keys[num]))
//        {
//            int expr_24 = num + 1;
//            int expr_2B = this.M;
//            num = ((expr_2B != -1) ? (expr_24 % expr_2B) : 0);
//        }
//        this.keys[num] = null;
//        this.vals[num] = null;
//        int expr_4C = num + 1;
//        int expr_53 = this.M;
//        num = ((expr_53 != -1) ? (expr_4C % expr_53) : 0);
//        while (this.keys[num] != null)
//        {
//            object obj2 = this.keys[num];
//            object obj3 = this.vals[num];
//            this.keys[num] = null;
//            this.vals[num] = null;
//            this.N--;
//            this.put(obj2, obj3);
//            int expr_A4 = num + 1;
//            int expr_AB = this.M;
//            num = ((expr_AB != -1) ? (expr_A4 % expr_AB) : 0);
//        }
//        this.N--;
//        if (this.N > 0 && this.N <= this.M / 8)
//        {
//            this.resize(this.M / 2);
//        }
//        if (!LinearProbingHashST.s_assertionsDisabled && !this.check())
//        {

//            throw new AssertionError();
//        }
//    }


//    private void resize(int i)
//    {
//        LinearProbingHashST linearProbingHashST = new LinearProbingHashST(i);
//        for (int j = 0; j < this.M; j++)
//        {
//            if (this.keys[j] != null)
//            {
//                linearProbingHashST.put(this.keys[j], this.vals[j]);
//            }
//        }
//        this.keys = linearProbingHashST.keys;
//        this.vals = linearProbingHashST.vals;
//        this.M = linearProbingHashST.M;
//    }
//    /*	[LineNumberTable(54), Signature("(TKey;)I")]*/

//    private int hash(object this2)
//    {
//        int expr_0B = java.lang.Object.instancehelper_hashCode(this2) & 2147483647;
//        int expr_12 = this.M;
//        return (expr_12 != -1) ? (expr_0B % expr_12) : 0;
//    }
//    /*	[LineNumberTable(49), Signature("(TKey;)Z")]*/

//    public virtual bool contains(object obj)
//    {
//        return this.get(obj) != null;
//    }


//    private bool check()
//    {
//        if (this.M < 2 * this.N)
//        {
//            System.err.println(new StringBuilder().append("Hash table size M = ").append(this.M).append("; array size N = ").append(this.N).toString());
//            return false;
//        }
//        for (int i = 0; i < this.M; i++)
//        {
//            if (this.keys[i] != null)
//            {
//                if (this.get(this.keys[i]) != this.vals[i])
//                {
//                    System.err.println(new StringBuilder().append("get[").append(this.keys[i]).append("] = ").append(this.get(this.keys[i])).append("; vals[i] = ").append(this.vals[i]).toString());
//                    return false;
//                }
//            }
//        }
//        return true;
//    }


//    public LinearProbingHashST() : this(4)
//    {
//    }
//    /*	[Signature("()Ljava/lang/Iterable<TKey;>;")]*/

//    public virtual Iterable keys()
//    {
//        Queue queue = new Queue();
//        for (int i = 0; i < this.M; i++)
//        {
//            if (this.keys[i] != null)
//            {
//                queue.enqueue(this.keys[i]);
//            }
//        }
//        return queue;
//    }


//    public virtual bool isEmpty()
//    {
//        return this.size() == 0;
//    }


//    /**/
//    public static void main(string[] strarr)
//    {
//        LinearProbingHashST linearProbingHashST = new LinearProbingHashST();
//        int num = 0;
//        while (!StdIn.isEmpty())
//        {
//            string text = StdIn.readString();
//            linearProbingHashST.put(text, Integer.valueOf(num));
//            num++;
//        }
//        Iterator iterator = linearProbingHashST.keys().iterator();
//        while (iterator.hasNext())
//        {
//            string text = (string)iterator.next();
//            StdOut.println(new StringBuilder().append(text).append(" ").append(linearProbingHashST.get(text)).toString());
//        }
//    }

//    static LinearProbingHashST()
//    {
//        LinearProbingHashST.s_assertionsDisabled = !ClassLiteral<LinearProbingHashST>.Value.desiredAssertionStatus();
//    }
//}
