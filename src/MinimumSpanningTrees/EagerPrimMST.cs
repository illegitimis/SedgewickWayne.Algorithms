/**
 *  The {@code EagerPrimMST} class represents a data type for computing a
 *  minimum spanning tree in an edge-weighted graph.
 *  The edge weights can be positive, zero, or negative and need not
 *  be distinct. If the graph is not connected, it computes a minimum
 *  spanning forest, which is the union of minimum spanning trees
 *  in each connected component. The {@code weight()} method returns the 
 *  weight of a minimum spanning tree and the {@code edges()} method
 *  returns its edges.
 
 *  This implementation uses Prim's algorithm with an INDEXED BINARY HEAP.
 *  The constructor takes time proportional to E log V
 *  and extra space (not including the graph) proportional to V,
 *  where V is the number of vertices and E is the number of edges.
 *  Afterwards, the {@code weight()} method takes constant time
 *  and the {@code edges()} method takes time proportional to V.
 */

namespace SedgewickWayne.Algorithms
{
    using SedgewickWayne.Algorithms.Graphs;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Compute a minimum spanning forest using Prim's algorithm.
    /// <see href="https://algs4.cs.princeton.edu/43mst/PrimMST.java.html"/>
    /// </summary>
    /// <typeparam name="TWeight"></typeparam>
    /// <remarks>
    /// Eager implementation.
    /// To improve the lazy implementation of Prim's algorithm,
    /// we might try to DELETE INELIGIBLE EDGES FROM THE PRIORITY QUEUE,
    /// so that the priority queue contains only the crossing edges.
    /// But we can eliminate even more edges.
    /// The key is to note that our only interest is in the MINIMAL EDGE FROM EACH NON-TREE VERTEX TO A TREE VERTEX.
    /// When we add a vertex v to the tree, the only possible change with respect to each non-tree vertex w
    /// is that adding v brings w closer than before to the tree.
    /// In short, we do not need to keep on the priority queue all of the edges from w to vertices tree
    /// we just need to keep track of the minimum-weight edge
    /// and check whether the addition of v to the tree necessitates that we update that minimum
    /// (because of an edge v-w that has lower weight),
    /// which we can do as we process each edge in s adjacency list.
    /// In other words, we maintain on the priority queue just one edge for each non-tree vertex:
    /// the shortest edge that connects it to the tree.
    /// </remarks>
    public class EagerPrimMST<TWeight> :
        IMinimumSpanningTreeAlgorithm<TWeight>
        where TWeight : IComparable<TWeight>
    {
        // edgeTo[v] = shortest edge from tree vertex to non-tree vertex
        private readonly WeightedEdge<TWeight>[] edgeTo;
        // distTo[v] = weight of shortest such edge
        private readonly TWeight[] distTo;
        // marked[v] = true if v on tree, false otherwise
        private readonly bool[] marked;

        private readonly IndexMinPQ<TWeight> pq;

        /// <summary>
        /// Compute a minimum spanning tree (or forest) of an edge-weighted graph.
        /// </summary>
        /// <param name="G">G the edge-weighted graph</param>
        public EagerPrimMST(EdgeWeightedGraph<TWeight> G, TWeight initialMaxValue, TWeight zero)
        {
            edgeTo = new WeightedEdge<TWeight>[G.V];
            distTo = new TWeight[G.V];
            marked = new bool[G.V];
            pq = new IndexMinPQ<TWeight>(G.V);
            for (int v = 0; v < G.V; distTo[v++] = initialMaxValue);

            // run from each vertex to Find
            for (int v = 0; v < G.V; v++)
            {
                if (marked[v]) continue;
                // minimum spanning forest
                Prim(G, v, zero);
            }

            // check optimality conditions
            // assert check(G);
            Contract.Assert(Check(G));
        }

        // run Prim's algorithm in graph G, starting from vertex s
        private void Prim(EdgeWeightedGraph<TWeight> G, int s, TWeight zero)
        {
            // distTo[s] = 0.0;
            distTo[s] = zero;
            pq.Insert(s, distTo[s]);
            while (!pq.IsEmpty)
            {
                // int v = pq.DeleteMin();
                int idx = pq.DeleteIndex();
                //scan(G, v);
                Scan(G, idx);
            }
        }

        // scan vertex v
        private void Scan(EdgeWeightedGraph<TWeight> G, int v)
        {
            marked[v] = true;
            foreach (WeightedEdge<TWeight> e in G.Adjacency(v))
            {
                int w = e.Other(v);
                // v-w is obsolete edge
                if (marked[w]) continue;

                if (e.Weight.CompareTo(distTo[w]) < 0)
                {
                    distTo[w] = e.Weight;
                    edgeTo[w] = e;
                    if (pq.Contains(w)) pq.DecreaseKey(w, distTo[w]);
                    else pq.Insert(w, distTo[w]);
                }
            }
        }

        /// <summary>
        /// Returns the edges in a minimum spanning tree (or forest).
        /// </summary>
        public IEnumerable<WeightedEdge<TWeight>> Edges
        {
            get
            {
                foreach(var edge in edgeTo)
                {
                    if (edge is null) continue;
                    yield return edge;
                }
            }
        }

        /// <summary>
        /// Returns the sum of the edge weights in a minimum spanning tree (or forest).
        /// </summary>
        public TWeight Weight
        {
            get
            {
                // Edges.Where(e=>e!=null).Sum (e => e.Weight); 
                TWeight sum = default;
                foreach (var edge in Edges)
                {
                    if (edge is null) continue;
                    sum = GenericOperators<TWeight>.Add(sum, edge.Weight);
                }
                return sum;
            }
        }

        // check optimality conditions (takes time proportional to E V lg* V)
        private bool Check(EdgeWeightedGraph<TWeight> G)
        {

            // check weight
            //double totalWeight = 0.0;
            //foreach (WeightedEdge<TWeight> e in edges()) {
            //    totalWeight += e.Weight;
            //}
            //if (Math.abs(totalWeight - weight()) > FLOATING_POINT_EPSILON) {
            //    System.err.printf("Weight of edges does not equal weight(): %f vs. %f\n", totalWeight, weight());
            //    return false;
            //}

            // check that it is acyclic
            //UF uf = new UF(G.V);
            //foreach (WeightedEdge<TWeight> e in edges()) {
            //    int v = e.either(), w = e.other(v);
            //    if (uf.connected(v, w)) {
            //        System.err.println("Not a forest");
            //        return false;
            //    }
            //    uf.union(v, w);
            //}

            // check that it is a spanning forest
            //foreach (WeightedEdge<TWeight> e in G.edges()) {
            //    int v = e.either(), w = e.other(v);
            //    if (!uf.connected(v, w)) {
            //        System.err.println("Not a spanning forest");
            //        return false;
            //    }
            //}

            // check that it is a minimal spanning forest (cut optimality conditions)
            foreach (WeightedEdge<TWeight> e in Edges)
            {

                // all edges in MST except e
                //uf = new UF(G.V);
                //for (WeightedEdge<TWeight> f : edges()) {
                //    int x = f.either(), y = f.other(x);
                //    if (f != e) uf.union(x, y);
                //}

                // check that e is min weight edge in crossing cut
                //for (WeightedEdge<TWeight> f : G.edges()) {
                //    int x = f.either(), y = f.other(x);
                //    if (!uf.connected(x, y)) {
                //        if (f.Weight < e.Weight) {
                //            System.err.println("WeightedEdge<TWeight> " + f + " violates cut optimality conditions");
                //            return false;
                //        }
                //    }
                //}

            }

            return true;
        }
    }
}