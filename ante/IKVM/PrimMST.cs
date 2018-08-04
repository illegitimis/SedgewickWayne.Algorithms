using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SedgewickWayne.Algorithms.AnteRoom
{

    public class PrimMST
    {
        private Edge[] edgeTo;
        private double[] distTo;
        private bool[] marked;
        //[Signature("LIndexMinPQ<Ljava/lang/Double;>;")]
        private IndexMinPQ pq;
        //[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
        internal static bool s_assertionsDisabled;




        private void prim(EdgeWeightedGraph edgeWeightedGraph, int num)
        {
            this.distTo[num] = (double)0f;
            this.pq.insert(num, java.lang.Double.valueOf(this.distTo[num]));
            while (!this.pq.IsEmpty)
            {
                int num2 = this.pq.delMin();
                this.scan(edgeWeightedGraph, num2);
            }
        }


        private bool check(EdgeWeightedGraph edgeWeightedGraph)
        {
            double num = (double)0f;
            Iterator iterator = this.edges().iterator();
            while (iterator.hasNext())
            {
                Edge edge = (Edge)iterator.next();
                num += edge.weight();
            }
            double num2 = 1E-12;
            if (java.lang.Math.abs(num - this.weight()) > num2)
            {
                System.err.printf("Weight of edges does not equal weight(): %f vs. %f\n", new object[]
                {
                java.lang.Double.valueOf(num),
                java.lang.Double.valueOf(this.weight())
                });
                return false;
            }
            UF uF = new UF(edgeWeightedGraph.V());
            Iterator iterator2 = this.edges().iterator();
            while (iterator2.hasNext())
            {
                Edge edge2 = (Edge)iterator2.next();
                int num3 = edge2.either();
                int i = edge2.other(num3);
                if (uF.connected(num3, i))
                {
                    System.err.println("Not a forest");
                    return false;
                }
                uF.union(num3, i);
            }
            iterator2 = edgeWeightedGraph.edges().iterator();
            while (iterator2.hasNext())
            {
                Edge edge2 = (Edge)iterator2.next();
                int num3 = edge2.either();
                int i = edge2.other(num3);
                if (!uF.connected(num3, i))
                {
                    System.err.println("Not a spanning forest");
                    return false;
                }
            }
            iterator2 = this.edges().iterator();
            while (iterator2.hasNext())
            {
                Edge edge2 = (Edge)iterator2.next();
                uF = new UF(edgeWeightedGraph.V());
                Iterator iterator3 = this.edges().iterator();
                while (iterator3.hasNext())
                {
                    Edge edge3 = (Edge)iterator3.next();
                    int num4 = edge3.either();
                    int i2 = edge3.other(num4);
                    if (edge3 != edge2)
                    {
                        uF.union(num4, i2);
                    }
                }
                iterator3 = edgeWeightedGraph.edges().iterator();
                while (iterator3.hasNext())
                {
                    Edge edge3 = (Edge)iterator3.next();
                    int num4 = edge3.either();
                    int i2 = edge3.other(num4);
                    if (!uF.connected(num4, i2) && edge3.weight() < edge2.weight())
                    {
                        System.err.println(new StringBuilder().append("Edge ").append(edge3).append(" violates cut optimality conditions").toString());
                        return false;
                    }
                }
            }
            return true;
        }


        private void scan(EdgeWeightedGraph edgeWeightedGraph, int num)
        {
            this.marked[num] = true;
            Iterator iterator = edgeWeightedGraph.adj(num).iterator();
            while (iterator.hasNext())
            {
                Edge edge = (Edge)iterator.next();
                int num2 = edge.other(num);
                if (!this.marked[num2])
                {
                    if (edge.weight() < this.distTo[num2])
                    {
                        this.distTo[num2] = edge.weight();
                        this.edgeTo[num2] = edge;
                        if (this.pq.contains(num2))
                        {
                            this.pq.decreaseKey(num2, java.lang.Double.valueOf(this.distTo[num2]));
                        }
                        else
                        {
                            this.pq.insert(num2, java.lang.Double.valueOf(this.distTo[num2]));
                        }
                    }
                }
            }
        }
        /*	[Signature("()Ljava/lang/Iterable<LEdge;>;")]*/

        public virtual Iterable edges()
        {
            Queue queue = new Queue();
            for (int i = 0; i < this.edgeTo.Length; i++)
            {
                Edge edge = this.edgeTo[i];
                if (edge != null)
                {
                    queue.enqueue(edge);
                }
            }
            return queue;
        }


        public virtual double weight()
        {
            double num = (double)0f;
            Iterator iterator = this.edges().iterator();
            while (iterator.hasNext())
            {
                Edge edge = (Edge)iterator.next();
                num += edge.weight();
            }
            return num;
        }


        public PrimMST(EdgeWeightedGraph ewg)
        {
            this.edgeTo = new Edge[ewg.V()];
            this.distTo = new double[ewg.V()];
            this.marked = new bool[ewg.V()];
            this.pq = new IndexMinPQ(ewg.V());
            for (int i = 0; i < ewg.V(); i++)
            {
                this.distTo[i] = double.PositiveInfinity;
            }
            for (int i = 0; i < ewg.V(); i++)
            {
                if (!this.marked[i])
                {
                    this.prim(ewg, i);
                }
            }
            if (!PrimMST.s_assertionsDisabled && !this.check(ewg))
            {

                throw new AssertionError();
            }
        }


        /**/
        public static void main(string[] strarr)
        {

            In i = new In(strarr[0]);
            EdgeWeightedGraph ewg = new EdgeWeightedGraph(i);
            PrimMST primMST = new PrimMST(ewg);
            Iterator iterator = primMST.edges().iterator();
            while (iterator.hasNext())
            {
                Edge obj = (Edge)iterator.next();
                StdOut.println(obj);
            }
            StdOut.printf("%.5f\n", new object[]
            {
            java.lang.Double.valueOf(primMST.weight())
            });
        }

        static PrimMST()
        {
            PrimMST.s_assertionsDisabled = !ClassLiteral<PrimMST>.Value.desiredAssertionStatus();
        }
    }


}
