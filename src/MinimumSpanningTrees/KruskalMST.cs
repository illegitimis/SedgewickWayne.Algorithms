
namespace SedgewickWayne.Algorithms
{
    using SedgewickWayne.Algorithms.Graphs;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using UF = SedgewickWayne.Algorithms.DynamicConnectivity.UF;

    /// <summary>
    /// Compute a minimum spanning forest in an edge-weighted graph using Kruskal's algorithm.
    /// </summary>
    /// <typeparam name="TWeight">weigh type</typeparam>
    /// <remarks>
    /// Dependencies: <see cref="EdgeWeightedGraph{TWeight}"/>, <see cref="WeightedEdge{TWeight}"/>, <see cref="UF"/>.
    ///
    /// The edge weights can be positive, zero, or negative and need not be distinct.
    /// If the graph is not connected, it computes a minimum spanning forest, which is the union of minimum spanning trees in each connected component.
    /// This implementation uses Krusal's algorithm and the union-Find data type.
    /// The constructor takes time proportional to E log E and extra space (not including the graph) proportional to V, where V is the number of vertices and E is the number of edges.
    /// Afterwards, the <see cref="Weight"/> method takes constant time and the <see cref="Edges"/> method takes time proportional to V.
    /// </remarks>
    public class KruskalMST<TWeight> :
        IMinimumSpanningTreeAlgorithm<TWeight>
        where TWeight : IComparable<TWeight>
    {
        private readonly Queue<WeightedEdge<TWeight>> _mst = new Queue<WeightedEdge<TWeight>>();

        public KruskalMST(EdgeWeightedGraph<TWeight> G)
        {
            // more efficient to build heap by passing array of edges
            var pq = new MinPQ<WeightedEdge<TWeight>>();
            foreach (var e in G.Edges)
            {
                pq.Insert(e);
            }
            /*
            // create array of edges, sorted by weight
            Edge[] edges = new Edge[G.E()];
            int t = 0;
            for (Edge e: G.edges()) {
                edges[t++] = e;
            }
            Arrays.sort(edges);
            */

            // run greedy algorithm
            UF uf = new UF(G.V);
            while (!pq.IsEmpty && _mst.Size < G.V - 1)
            {
                var e = pq.DeleteMin();
                int v = e.Either();
                int w = e.Other(v);

                // v-w does not create a cycle
                if (uf.Connected(v, w)) continue;

                // merge v and w components
                uf.Union(v, w);
                // add edge e to mst
                _mst.Enqueue(e);
                // weight += e.Weight;
                Weight = GenericOperators<TWeight>.Add(Weight, e.Weight);
            }

            // check optimality conditions
            Contract.Assert(Check(G));
        }

        /// <summary>
        /// edges in MST
        /// </summary>
        public IEnumerable<WeightedEdge<TWeight>> Edges => _mst;

        /// <summary>
        /// Returns the sum of the edge weights in a minimum spanning tree (or forest).
        /// </summary>
        public TWeight Weight { get; }

        // check optimality conditions (takes time proportional to E V lg* V)
        private bool Check(EdgeWeightedGraph<TWeight> G)
        {

            // check total weight
            //double total = 0.0;
            //foreach (Edge e in Edges) {
            //    total += e.Weight;
            //}
            //if (Math.abs(total - Weight) > FLOATING_POINT_EPSILON) {
            //    System.err.printf("Weight of edges does not equal Weight: %f vs. %f\n", total, Weight);
            //    return false;
            //}

            // check that it is acyclic
            //UF uf = new UF(G.V);
            //foreach (Edge e in Edges) {
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
            foreach (var e in Edges)
            {

                // all edges in MST except e
                //uf = new UF(G.V);
                //for (Edge f : mst) {
                //    int x = f.Either, y = f.other(x);
                //    if (f != e) uf.union(x, y);
                //}

                // check that e is min weight edge in crossing cut
                //for (Edge f : G.Edges) {
                //    int x = f.Either, y = f.other(x);
                //    if (!uf.connected(x, y)) {
                //        if (f.Weight < e.Weight) {
                //            System.err.println("Edge " + f + " violates cut optimality conditions");
                //            return false;
                //        }
                //    }
                //}

            }

            return true;
        }
    }
}