

namespace SedgewickWayne.Algorithms
{
    using SedgewickWayne.Algorithms.Graphs;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq.Expressions;

    /******************************************************************************
     *  Compilation:  javac LazyPrimMST.java
     *  Execution:    java LazyPrimMST filename.txt
     *  Dependencies: EdgeWeightedGraph.java Edge.java Queue.java
     * MinPQ.java UF.java In.java StdOut.java
     ******************************************************************************/



    /**
     *  The {@code LazyPrimMST} class represents a data type for computing a
     *  <em>minimum spanning tree</em> in an edge-weighted graph.
     *  The edge weights can be positive, zero, or negative and need not
     *  be distinct. If the graph is not connected, it computes a <em>minimum
     *  spanning forest</em>, which is the union of minimum spanning trees
     *  in each connected component. The {@code weight()} method returns the 
     *  weight of a minimum spanning tree and the {@code Edges} method
     *  returns its edges.
     
     *  This implementation uses a LAZY version of <em>Prim's algorithm</em> with a BINARY HEAP OF EDGES.
     *  The constructor takes time proportional to E log E
     *  and extra space (not including the graph) proportional to E,
     *  where V is the number of vertices and E is the number of edges.
     *  Afterwards, the {@code weight()} method takes constant time
     *  and the {@code Edges} method takes time proportional to V.
     
     *  For additional documentation,
     *  see <a href="http://algs4.cs.princeton.edu/43mst">Section 4.3</a> of
     
     *  For alternate implementations, see {@link PrimMST}, {@link KruskalMST},
     *  and {@link BoruvkaMST}.
     *
     
    
     */

    /* Compute a minimum spanning forest using a lazy version of Prim's algorithm. */
    public class LazyPrimMST<TWeight> :
        IMinimumSpanningTreeAlgorithm<TWeight>
        where TWeight : IComparable<TWeight>
    {
        // edges in the MST
        private Queue<WeightedEdge<TWeight>> mst;
        // marked[v] = true if v on tree
        private bool[] marked;
        // edges with one endpoint in tree
        private MinPQ<WeightedEdge<TWeight>> pq;

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
                if (!marked[v]) prim(G, v);     // get a minimum spanning forest

            // check optimality conditions
            //Contracts.Assert (G);
        }

        // run Prim's algorithm
        private void prim(EdgeWeightedGraph<TWeight> G, int s)
        {
            scan(G, s);
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
                Weight = Add(Weight, e.Weight);

                // v & w become part of tree
                if (!marked[v]) scan(G, v);
                if (!marked[w]) scan(G, w);
            }
        }

        // https://jonskeet.uk/csharp/miscutil/usage/genericoperators.html
        static T Add<T>(T a, T b)
        {
            //TODO: re-use delegate!
            // declare the parameters
            ParameterExpression paramA = Expression.Parameter(typeof(T), "a"), paramB = Expression.Parameter(typeof(T), "b");
            // add the parameters together
            BinaryExpression body = Expression.Add(paramA, paramB);
            // compile it
            Func<T, T, T> add = Expression.Lambda<Func<T, T, T>>(body, paramA, paramB).Compile();
            // call it
            return add(a, b);
        }

        // add all edges e incident to v onto pq if the other endpoint has not yet been scanned
        private void scan(EdgeWeightedGraph<TWeight> G, int v)
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
        private bool check(EdgeWeightedGraph<TWeight> G)
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
            //foreach (Edge e in Edges) {

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
            //}

            return true;
        }

    }
}
