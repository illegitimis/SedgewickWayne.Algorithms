using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SedgewickWayne.Algorithms.AnteRoom
{
    public class TransitiveClosure
    {
        private DirectedDFS[] tc;


        public TransitiveClosure(Digraph d)
        {
            this.tc = new DirectedDFS[d.V()];
            for (int i = 0; i < d.V(); i++)
            {
                this.tc[i] = new DirectedDFS(d, i);
            }
        }


        public virtual bool reachable(int i1, int i2)
        {
            return this.tc[i1].marked(i2);
        }


        /**/
        public static void main(string[] strarr)
        {

            In i = new In(strarr[0]);
            Digraph digraph = new Digraph(i);
            TransitiveClosure transitiveClosure = new TransitiveClosure(digraph);
            StdOut.print("     ");
            for (int j = 0; j < digraph.V(); j++)
            {
                StdOut.printf("%3d", new object[]
                {
                Integer.valueOf(j)
                });
            }
            StdOut.println();
            StdOut.println("--------------------------------------------");
            for (int j = 0; j < digraph.V(); j++)
            {
                StdOut.printf("%3d: ", new object[]
                {
                Integer.valueOf(j)
                });
                for (int k = 0; k < digraph.V(); k++)
                {
                    if (transitiveClosure.reachable(j, k))
                    {
                        StdOut.printf("  T", new object[0]);
                    }
                    else
                    {
                        StdOut.printf("   ", new object[0]);
                    }
                }
                StdOut.println();
            }
        }
    }
}
