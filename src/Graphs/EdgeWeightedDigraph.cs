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
    public class EdgeWeightedDigraph<TWeight> :
        AdjacencyListGraph<DirectedEdge<TWeight>>
         where TWeight : IComparable<TWeight>
    {
        public EdgeWeightedDigraph(int numberOfVertices) :
            base(numberOfVertices) =>
            _indegree = new int[V];

        // indegree[v] = indegree of vertex v
        private readonly int[] _indegree;

        public void AddEdge(DirectedEdge<TWeight> edge)
        {
            ValidateVertex(edge.From);
            ValidateVertex(edge.To);
            _adjacencyList[edge.From].Add(edge);
            _indegree[edge.To]++;
            E++;
        }

        public void AddEdge(int from, int to, TWeight weight) =>
            AddEdge(new DirectedEdge<TWeight>(from, to, weight));

        public int OutDegree(int v)
        {
            ValidateVertex(v);
            return _adjacencyList[v].Size;
        }

        public int InDegree(int v)
        {
            ValidateVertex(v);
            return _indegree[v];
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
