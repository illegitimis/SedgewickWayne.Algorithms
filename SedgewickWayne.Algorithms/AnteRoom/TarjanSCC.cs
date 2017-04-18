
namespace SedgewickWayne.Algorithms.AnteRoom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TarjanSCC
    {
        private bool[] marked;
        private int[] id;
        private int[] low;
        private int pre;
        private int count;
        //[Signature("LStack<Ljava/lang/Integer;>;")]
        private Stack stack;
        //[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
        internal static bool s_assertionsDisabled;




        private void dfs(Digraph digraph, int num)
        {
            this.marked[num] = true;
            int[] arg_23_0 = this.low;
            int num2 = this.pre;
            int arg_23_2 = num2;
            this.pre = num2 + 1;
            arg_23_0[num] = arg_23_2;
            int num3 = this.low[num];
            this.stack.push(Integer.valueOf(num));
            Iterator iterator = digraph.adj(num).iterator();
            while (iterator.hasNext())
            {
                int num4 = ((Integer)iterator.next()).intValue();
                if (!this.marked[num4])
                {
                    this.dfs(digraph, num4);
                }
                if (this.low[num4] < num3)
                {
                    num3 = this.low[num4];
                }
            }
            if (num3 < this.low[num])
            {
                this.low[num] = num3;
                return;
            }
            int num5;
            do
            {
                num5 = ((Integer)this.stack.pop()).intValue();
                this.id[num5] = this.count;
                this.low[num5] = digraph.V();
            }
            while (num5 != num);
            this.count++;
        }


        private bool check(Digraph digraph)
        {
            TransitiveClosure transitiveClosure = new TransitiveClosure(digraph);
            for (int i = 0; i < digraph.V(); i++)
            {
                for (int j = 0; j < digraph.V(); j++)
                {
                    if (this.stronglyConnected(i, j) != ((!transitiveClosure.reachable(i, j) || !transitiveClosure.reachable(j, i)) ? false : true))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public virtual bool stronglyConnected(int i1, int i2)
        {
            return this.id[i1] == this.id[i2];
        }


        public TarjanSCC(Digraph d)
        {
            this.marked = new bool[d.V()];
            this.stack = new Stack();
            this.id = new int[d.V()];
            this.low = new int[d.V()];
            for (int i = 0; i < d.V(); i++)
            {
                if (!this.marked[i])
                {
                    this.dfs(d, i);
                }
            }
            if (!TarjanSCC.s_assertionsDisabled && !this.check(d))
            {

                throw new AssertionError();
            }
        }
        public virtual int count()
        {
            return this.count;
        }

        public virtual int id(int i)
        {
            return this.id[i];
        }


        /**/
        public static void main(string[] strarr)
        {

            In i = new In(strarr[0]);
            Digraph digraph = new Digraph(i);
            TarjanSCC tarjanSCC = new TarjanSCC(digraph);
            int num = tarjanSCC.count();
            StdOut.println(new StringBuilder().append(num).append(" components").toString());
            Queue[] array = (Queue[])new Queue[num];
            for (int j = 0; j < num; j++)
            {
                array[j] = new Queue();
            }
            for (int j = 0; j < digraph.V(); j++)
            {
                array[tarjanSCC.id(j)].enqueue(Integer.valueOf(j));
            }
            for (int j = 0; j < num; j++)
            {
                Iterator iterator = array[j].iterator();
                while (iterator.hasNext())
                {
                    int i2 = ((Integer)iterator.next()).intValue();
                    StdOut.print(new StringBuilder().append(i2).append(" ").toString());
                }
                StdOut.println();
            }
        }

        static TarjanSCC()
        {
            TarjanSCC.s_assertionsDisabled = !ClassLiteral<TarjanSCC>.Value.desiredAssertionStatus();
        }
    }
}
