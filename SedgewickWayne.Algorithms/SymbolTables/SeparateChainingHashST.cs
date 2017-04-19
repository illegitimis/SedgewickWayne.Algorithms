
namespace SedgewickWayne.Algorithms.SymbolTables
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    //[Signature("<Key:Ljava/lang/Object;Value:Ljava/lang/Object;>Ljava/lang/Object;")]
    public class SeparateChainingHashST
    {
        private const int INIT_CAPACITY = 4;
        private int N;
        private int M;
        //[Signature("[LSequentialSearchST<TKey;TValue;>;")]
        private SequentialSearchST[] st;


        public SeparateChainingHashST(int i)
        {
            this.M = i;
            this.st = (SequentialSearchST[])new SequentialSearchST[i];
            for (int j = 0; j < i; j++)
            {
                this.st[j] = new SequentialSearchST();
            }
        }
        /*	[Signature("(TKey;TValue;)V")]*/

        public virtual void put(object obj1, object obj2)
        {
            if (obj2 == null)
            {
                this.delete(obj1);
                return;
            }
            if (this.N >= 10 * this.M)
            {
                this.resize(2 * this.M);
            }
            int num = this.hash(obj1);
            if (!this.st[num].contains(obj1))
            {
                this.N++;
            }
            this.st[num].put(obj1, obj2);
        }
        public virtual int Size
        {
		return this.N;
        }
        /*	[Signature("(TKey;)TValue;")]*/

        public virtual object get(object obj)
        {
            int num = this.hash(obj);
            return this.st[num].get(obj);
        }
        /*	[LineNumberTable(56), Signature("(TKey;)I")]*/

        private int hash(object this2)
        {
            int expr_0B = java.lang.Object.instancehelper_hashCode(this2) & 2147483647;
            int expr_12 = this.M;
            return (expr_12 != -1) ? (expr_0B % expr_12) : 0;
        }
        /*	[Signature("(TKey;)V")]*/

        public virtual void delete(object obj)
        {
            int num = this.hash(obj);
            if (this.st[num].contains(obj))
            {
                this.N--;
            }
            this.st[num].delete(obj);
            if (this.M > 4 && this.N <= 2 * this.M)
            {
                this.resize(this.M / 2);
            }
        }


        private void resize(int i)
        {
            SeparateChainingHashST separateChainingHashST = new SeparateChainingHashST(i);
            for (int j = 0; j < this.M; j++)
            {
                Iterator iterator = this.st[j].keys().iterator();
                while (iterator.hasNext())
                {
                    object obj = iterator.next();
                    separateChainingHashST.put(obj, this.st[j].get(obj));
                }
            }
            this.M = separateChainingHashST.M;
            this.N = separateChainingHashST.N;
            this.st = separateChainingHashST.st;
        }


        public SeparateChainingHashST() : this(4)
        {
        }
        /*	[Signature("()Ljava/lang/Iterable<TKey;>;")]*/

        public virtual Iterable keys()
        {
            Queue queue = new Queue();
            for (int i = 0; i < this.M; i++)
            {
                Iterator iterator = this.st[i].keys().iterator();
                while (iterator.hasNext())
                {
                    object obj = iterator.next();
                    queue.enqueue(obj);
                }
            }
            return queue;
        }


        public virtual bool IsEmpty
        {
		return this.Size == 0;
        }
        /*	[LineNumberTable(71), Signature("(TKey;)Z")]*/

        public virtual bool contains(object obj)
        {
            return this.get(obj) != null;
        }


        /**/
        public static void main(string[] strarr)
        {
            SeparateChainingHashST separateChainingHashST = new SeparateChainingHashST();
            int num = 0;
            while (!StdIn.IsEmpty)
            {
                string text = StdIn.readString();
                separateChainingHashST.put(text, Integer.valueOf(num));
                num++;
            }
            Iterator iterator = separateChainingHashST.keys().iterator();
            while (iterator.hasNext())
            {
                string text = (string)iterator.next();
                StdOut.println(new StringBuilder().append(text).append(" ").append(separateChainingHashST.get(text)).toString());
            }
        }
    }
}
