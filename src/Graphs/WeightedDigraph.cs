using System;

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
    public class WeightedDigraph<TWeight> : 
        Digraph<WeightedDirectedEdge<TWeight>>
         where TWeight : IComparable<TWeight>
    {
        public WeightedDigraph(int numberOfVertices) : base(numberOfVertices) { }

        public void AddEdge(int from, int to, TWeight weight) => AddEdge(new WeightedDirectedEdge<TWeight>(from, to, weight));
    }
}
