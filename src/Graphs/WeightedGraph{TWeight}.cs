namespace SedgewickWayne.Algorithms.Graphs
{
    using System;

    /// <summary>
    /// An edge-weighted undirected graph, implemented using adjacency lists.
    /// <see href="https://algs4.cs.princeton.edu/43mst/EdgeWeightedGraph.java.html"/>
    /// <see href="http://algs4.cs.princeton.edu/43mst" />
    /// </summary>
    /// <remarks>
    /// Represents an edge-weighted graph of vertices named 0 through V-1,
    /// where each undirected edge is of type <see cref="WeightedEdge{TWeight}"/>
    /// and has a real-valued weight.
    /// 
    /// It supports the following two primary operations:
    /// add an edge to the graph,
    /// iterate over all of the edges incident to a vertex.
    /// 
    /// It also provides methods for returning:
    /// the number of vertices V
    /// and the number of edges E.
    /// Parallel edges and self-loops are permitted.
    /// 
    /// This implementation uses an adjacency-lists representation,
    /// which is a vertex-indexed array of <see cref="Bag{TBag}"/> objects.
    /// 
    /// All operations take constant time(in the worst case)
    /// except iterating over the edges incident to a given vertex,
    /// which takes time proportional to the number of such edges.
    /// </remarks>
    public class WeightedGraph<TWeight> :
       Graph<WeightedUndirectedEdge<TWeight>>
        where TWeight : IComparable<TWeight>
    {
        public WeightedGraph(int numberOfVertices) : base(numberOfVertices)
        {
        }

        /// <summary>
        /// Initializes a new edge-weighted graph that is a deep copy of {@code G}.
        /// </summary>
        /// <param name="abstractGraph">G the edge-weighted graph to copy</param>
        public WeightedGraph(AdjacencyListGraph<WeightedUndirectedEdge<TWeight>> adjacencyListGraph) :
            base(adjacencyListGraph)
        {
        }

        public WeightedGraph(int V, int E) : base(V, E)
        {
        }

        /// <summary>
        /// Adds the undirected edge {@code e} to this edge-weighted graph.
        /// </summary>
        /// <param name="edge">e the edge</param>
        /// <exception cref="ArgumentException">unless both endpoints are between 0 and {@code V-1}</exception>
        public void AddEdge(int v, int w, TWeight weight) => AddEdge(new WeightedUndirectedEdge<TWeight>(v, w, weight));
    }
}