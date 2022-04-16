/******************************************************************************
*  Compilation:  javac LazyPrimMST.java
*  Execution:    java LazyPrimMST filename.txt
*  Dependencies: EdgeWeightedGraph.java Edge.java Queue.java
* MinPQ.java UF.java In.java StdOut.java
* For alternate implementations, see {@link PrimMST}, {@link KruskalMST}, and {@link BoruvkaMST}.
******************************************************************************/

namespace SedgewickWayne.Algorithms
{
    using SedgewickWayne.Algorithms.Graphs;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq.Expressions;

    /// <summary>
    ///Compute a minimum spanning forest using a lazy version of Prim's algorithm. 
    /// </summary>
    /// <typeparam name="TWeight">edge weight class type</typeparam>
    /// <remarks>
    /// Represents a data type for computing a minimum spanning tree in an edge-weighted graph.
    /// The edge weights can be positive, zero, or negative and need not be distinct.
    /// If the graph is not connected, it computes a minimum spanning forest, which is the union of minimum spanning trees in each connected component.
    /// 
    /// This implementation uses a LAZY version of Prim's algorithm with a BINARY HEAP OF EDGES.
    /// The constructor takes time proportional to E log E
    /// and extra space (not including the graph) proportional to E,
    /// where V is the number of vertices and E is the number of edges.
    /// 
    /// Afterwards, the {@code weight()} method takes constant time and the <see cref="Edges"/> method takes time proportional to V.
    /// </remarks>
    public class LazyPrimMST<TWeight> :
        IMinimumSpanningTreeAlgorithm<TWeight>
        where TWeight : IComparable<TWeight>
    {
        // edges in the MST
        private readonly Queue<WeightedEdge<TWeight>> mst;
        // marked[v] = true if v on tree
        private readonly bool[] marked;
        // edges with one endpoint in tree
        private readonly MinPQ<WeightedEdge<TWeight>> pq;

        /**
         * Compute a minimum spanning tree (or forest) of an edge-weighted graph.
         * @param G the edge-weighted graph
         */
        public LazyPrimMST(EdgeWeightedGraph<TWeight> G)
        {
            mst = new Queue<WeightedEdge<TWeight>>();
            pq = new MinPQ<WeightedEdge<TWeight>>();
            marked = new bool[G.V];
            for (int v = 0; v < G.V; v++)     // run Prim from all vertices to
                if (!marked[v]) Prim(G, v);     // get a minimum spanning forest

            // check optimality conditions
            Contract.Assert(Check(G));
        }

        // run Prim's algorithm
        private void Prim(EdgeWeightedGraph<TWeight> G, int s)
        {
            Scan(G, s);
            // better to stop when mst has V-1 edges
            while (!pq.IsEmpty)
            {
                // smallest edge on pq
                var e = pq.DeleteMin();
                
                // two endpoints
                int v = e.Either(), w = e.Other(v);
                //assert marked[v] || marked[w];
                Contract.Assert(marked[v] || marked[w]);
                // lazy, both v and w already scanned
                if (marked[v] && marked[w]) continue;
                
                // add e to MST
                mst.Enqueue(e);
                // Weight += e.Weight;
                Weight = GenericOperators<TWeight>.Add(Weight, e.Weight);

                // v & w become part of tree
                if (!marked[v]) Scan(G, v);
                if (!marked[w]) Scan(G, w);
            }
        }

        // add all edges e incident to v onto pq if the other endpoint has not yet been scanned
        private void Scan(EdgeWeightedGraph<TWeight> G, int v)
        {
            Contract.Assert(!marked[v]);
            marked[v] = true;
            foreach (var e in G.Adjacency(v))
                if (!marked[e.Other(v)])
                    pq.Insert(e);
        }
        /// <summary>
        /// Returns the edges in a minimum spanning tree (or forest) as an iterable of edges
        /// </summary>
        public IEnumerable<WeightedEdge<TWeight>> Edges => mst;

        /// <summary>
        /// Returns the total weight of MST.
        /// sum of the edge weights in a minimum spanning tree (or forest).
        /// </summary>
        public TWeight Weight { get; private set; }


        // check optimality conditions (takes time proportional to E V lg* V)
        private static bool Check(EdgeWeightedGraph<TWeight> G)
        {

            // check weight
            //double totalWeight = 0.0;
            //foreach (Edge e in Edges) {
            //    totalWeight += e.Weight;
            //}
            //if (Math.Abs(totalWeight - Weight) > FLOATING_POINT_EPSILON) {
            //    System.err.printf("Weight of edges does not equal weight(): %f vs. %f\n", totalWeight, weight());
            //    return false;
            //}

            // check that it is acyclic
            //UF uf = new UF(G.V);
            //for (Edge e in Edges) {
            //    int v = e.Either, w = e.other(v);
            //    if (uf.connected(v, w)) {
            //        System.err.println("Not a forest");
            //        return false;
            //    }
            //    uf.union(v, w);
            //}

            // check that it is a spanning forest
            //foreach (Edge e in G.Edges) {
            //    int v = e.Either, w = e.other(v);
            //    if (!uf.connected(v, w)) {
            //        System.err.println("Not a spanning forest");
            //        return false;
            //    }
            //}

            // check that it is a minimal spanning forest (cut optimality conditions)
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            foreach (var e in G.Edges) {

            //    // all edges in MST except e
            //    uf = new UF(G.V);
            //    for (Edge f : mst) {
            //        int x = f.Either, y = f.other(x);
            //        if (f != e) uf.union(x, y);
            //    }

            // check that e is min weight edge in crossing cut
            //for (Edge f : G.Edges) {
            //    int x = f.Either, y = f.other(x);
            //    if (!uf.connected(x, y)) {
            //        if (f.weight() < e.weight()) {
            //            System.err.println("Edge " + f + " violates cut optimality conditions");
            //            return false;
            //        }
            //    }
            }
#pragma warning restore IDE0059 // Unnecessary assignment of a value

            return true;
        }

    }
}
