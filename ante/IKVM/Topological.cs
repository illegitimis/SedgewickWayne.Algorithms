

namespace SedgewickWayne.Algorithms.AnteRoom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Topological
    {
        //[Signature("Ljava/lang/Iterable<Ljava/lang/Integer;>;")]
        private Iterable order;


        public Topological(EdgeWeightedDigraph ewd)
        {
            EdgeWeightedDirectedCycle edgeWeightedDirectedCycle = new EdgeWeightedDirectedCycle(ewd);
            if (!edgeWeightedDirectedCycle.hasCycle())
            {
                DepthFirstOrder depthFirstOrder = new DepthFirstOrder(ewd);
                this.order = depthFirstOrder.reversePost();
            }
        }
        public virtual bool hasOrder()
        {
            return this.order != null;
        }
        /*	[Signature("()Ljava/lang/Iterable<Ljava/lang/Integer;>;")]*/
        public virtual Iterable order()
        {
            return this.order;
        }


        public Topological(Digraph d)
        {
            DirectedCycle directedCycle = new DirectedCycle(d);
            if (!directedCycle.hasCycle())
            {
                DepthFirstOrder depthFirstOrder = new DepthFirstOrder(d);
                this.order = depthFirstOrder.reversePost();
            }
        }


        /**/
        public static void main(string[] strarr)
        {
            string str = strarr[0];
            string str2 = strarr[1];
            SymbolDigraph symbolDigraph = new SymbolDigraph(str, str2);
            Topological topological = new Topological(symbolDigraph.G());
            Iterator iterator = topological.order().iterator();
            while (iterator.hasNext())
            {
                int i = ((Integer)iterator.next()).intValue();
                StdOut.println(symbolDigraph.name(i));
            }
        }
    }
}
