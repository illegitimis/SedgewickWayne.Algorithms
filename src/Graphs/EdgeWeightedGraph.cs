namespace SedgewickWayne.Algorithms.Graphs
{
    using System;
    using System.Collections.Generic;
    using System.Text;

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
    public class EdgeWeightedGraph<TWeight> : AbstractGraph
         where TWeight : IComparable<TWeight>
    {
        private readonly Bag<WeightedEdge<TWeight>>[] adj;

        public EdgeWeightedGraph(int numberOfVertices) :
            base(numberOfVertices)
        {
            adj = new Bag<WeightedEdge<TWeight>>[numberOfVertices];
            for (int v = 0; v < V; v++)
            {
                adj[v] = new Bag<WeightedEdge<TWeight>>();
            }
        }

        /// <summary>
        /// Initializes a new edge-weighted graph that is a deep copy of {@code G}.
        /// </summary>
        /// <param name="abstractGraph">G the edge-weighted graph to copy</param>
        public EdgeWeightedGraph(AbstractGraph abstractGraph) :
            base(abstractGraph)
        {
            /* TODO
             * : this(G.V)
             this.E = G.E;
      for (int i = 0; i < G.V; i++)
      {
        // reverse so that adjacency list is in same order as original
        Stack<Edge> reverse = new Stack<Edge>();
        foreach (Edge edge in G.adj[i]) reverse.Push (edge);

        foreach (Edge edge in reverse) adj[i].AddLast(edge);
      }
             */
        }

        /// <summary>
        /// Adds the undirected edge {@code e} to this edge-weighted graph.
        /// </summary>
        /// <param name="edge">e the edge</param>
        /// <exception cref="ArgumentException">unless both endpoints are between 0 and {@code V-1}</exception>
        public void AddEdge(WeightedEdge<TWeight> edge)
        {
            int either = edge.Either();
            ValidateVertex(either);

            int other = edge.Other(either);
            ValidateVertex(other);

            adj[either].Add(edge);
            adj[other].Add(edge);

            E++;
        }

        public void AddEdge(int a, int b, TWeight w) =>
            AddEdge(new WeightedEdge<TWeight>(a, b, w));

        /// <summary>
        /// Returns the edges incident on vertex {@code v}.
        /// </summary>
        /// <param name="v">v the vertex</param>
        /// <returns>
        /// the edges incident on vertex {@code v} as an Iterable
        /// </returns>
        public IEnumerable<WeightedEdge<TWeight>> Adjacency(int v)
        {
            ValidateVertex(v);
            return adj[v];
        }

        /// <summary>
        ///  Returns the degree of vertex {@code v}.
        /// </summary>
        /// <param name="v"> v the vertex</param>
        /// <returns>the degree of vertex {@code v}</returns>
        public int Degree(int v)
        {
            ValidateVertex(v);
            return adj[v].Size;
        }

        /// <summary>
        /// Returns all edges in this edge-weighted graph.
        /// </summary>
        public IEnumerable<WeightedEdge<TWeight>> Edges
        {
            get
            {
                var list = new LinkedList<WeightedEdge<TWeight>>();
                for (int v = 0; v < V; v++)
                {
                    int selfLoops = 0;
                    foreach (var e in Adjacency(v))
                    {
                        if (e.Other(v) > v)
                        {
                            list.AddLast(e);
                        }
                        // only add one copy of each self loop (self loops will be consecutive)
                        else if (e.Other(v) == v)
                        {
                            if (selfLoops % 2 == 0) list.AddLast(e);
                            selfLoops++;
                        }
                    }
                }
                return list;
            }
        }

        /// <summary>
        /// Returns a string representation of the edge-weighted graph.
        /// This method takes time proportional to E + V.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            
            for (int v = 0; v < V; v++)
            {
                sb.AppendFormat("{0}: ", v);
                foreach (var edge in adj[v]) sb.AppendFormat("{0} ", edge);
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}