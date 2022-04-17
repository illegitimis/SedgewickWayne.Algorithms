using System;
using System.Collections.Generic;

namespace SedgewickWayne.Algorithms.Graphs
{
    /// <summary>
    /// edge-weighted digraph of vertices named 0 through V - 1,
    /// where each directed edge is of type <see cref="DirectedEdge"/> and has a real-valued weight.
    /// </summary>
    /// <typeparam name="TWeight"></typeparam>
    /// <remarks>
    /// <see href="https://algs4.cs.princeton.edu/44sp/EdgeWeightedDigraph.java.html"/>
    /// <see href="https://algs4.cs.princeton.edu/44sp/"/>
    /// <see href="https://algs4.cs.princeton.edu/43mst/"/>
    /// <see href="https://algs4.cs.princeton.edu/41graph"/>
    /// <see href="https://algs4.cs.princeton.edu/40graphs/"/>
    ///
    /// It supports the following two primary operations:add a directed edge to the digraph and iterate over all of edges incident from a given vertex.
    /// Also provides methods for returning the indegree or outdegree of a vertex, the number of vertices V in the digraph, and the number of edges E in the digraph.
    /// Parallel edges and self-loops are permitted.
    /// This implementation uses an adjacency-lists representation, which is a vertex-indexed array of <see cref="Bag"/> objects.
    /// It uses Theta(E + V) space, where E is the number of edges and V is the number of vertices.
    /// All instance methods take Theta (1) time.
    /// (Though, iterating over the edges returned by adjacency list for a vertex takes time proportional to the outdegree of the vertex.)
    /// 
    /// Constructing an empty edge-weighted digraph with V vertices takes Theta (V) time;
    /// constructing an edge-weighted digraph  with E edges and V vertices takes  Theta (E + V) time.
    /// </remarks>
    public class EdgeWeightedDigraph<TWeight> : AbstractGraph
         where TWeight : IComparable<TWeight>
    {
        public EdgeWeightedDigraph(int numberOfVertices) : base(numberOfVertices)
        {
            indegree = new int[V];
            adj = new Bag<DirectedEdge<TWeight>>[V];
            for (int v = 0; v < V; v++)
                adj[v] = new Bag<DirectedEdge<TWeight>>();
        }

        // adj[v] = adjacency list for vertex v
        private readonly Bag<DirectedEdge<TWeight>>[] adj;

        // indegree[v] = indegree of vertex v
        private readonly int[] indegree;

        /**
    * Initializes a new edge-weighted digraph that is a deep copy of {@code G}.
    *
    * @param  G the edge-weighted digraph to copy
    */

        /*
        public EdgeWeightedDigraph(EdgeWeightedDigraph G)
        {
            this(G.V());
            this.E = G.E();
            for (int v = 0; v < G.V(); v++)
                this.indegree[v] = G.indegree(v);
            for (int v = 0; v < G.V(); v++)
            {
                // reverse so that adjacency list is in same order as original
                Stack<DirectedEdge> reverse = new Stack<DirectedEdge>();
                for (DirectedEdge e : G.adj[v])
                {
                    reverse.push(e);
                }
                for (DirectedEdge e : reverse)
                {
                    adj[v].add(e);
                }
            }
        }
        */

        public void AddEdge(DirectedEdge<TWeight> edge)
        {
            ValidateVertex(edge.From);
            ValidateVertex(edge.To);
            adj[edge.From].Add(edge);
            indegree[edge.To]++;
            E++;
        }

        public void AddEdge(int from, int to, TWeight weight) =>
            AddEdge(new DirectedEdge<TWeight>(from, to, weight));

        public IEnumerable<DirectedEdge<TWeight>> Adjacency(int v)
        {
            ValidateVertex(v);
            return adj[v];
        }

        public int OutDegree(int v)
        {
            ValidateVertex(v);
            return adj[v].Size;
        }

        public int InDegree(int v)
        {
            ValidateVertex(v);
            return indegree[v];
        }

        /// <summary>
        /// all directed edges in this edge-weighted digraph.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DirectedEdge<TWeight>> Edges()
        {
            for (int v = 0; v < V; v++)
            {
                foreach (var edge in Adjacency(v))
                {
                    if (edge is null) continue;
                    yield return edge;
                }
            }
        }
    }
}
