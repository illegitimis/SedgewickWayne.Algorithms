using System;
using System.Collections.Generic;
using System.Text;

namespace SedgewickWayne.Algorithms.Graphs
{
    /// <summary>
    /// undirected graph of vertices named 0 through V – 1.
    /// It supports the following two primary operations: add an edge to the graph, iterate over all of the vertices adjacent to a vertex.
    /// It also provides methods for returning the degree of a vertex, the number of vertices V in the graph, and the number of edges E in the graph.
    /// </summary>
    /// <remarks>
    /// <see href="https://algs4.cs.princeton.edu/41graph/Graph.java.html"/>
    /// Parallel edges and self-loops are permitted.
    /// By convention, a self-loop v-v appears in the adjacency list of v twice and contributes two to the degree of v.
    ///
    /// This implementation uses an adjacency-lists representation, which is a vertex-indexed array of <see cref="Bag{int}"/> objects.
    ///   It uses &Theta;(E + V) space, where E is the number of edges and V is the number of vertices.
    ///   All instance methods take &Theta;(1) time.
    ///   Iterating over the vertices returned by <para>adj(int)</para> takes time proportional to the degree of the vertex.
    ///   
    /// Constructing an empty graph with V vertices takes &Theta;(V) time;
    /// constructing a graph with E edges and V vertices takes &Theta;(E + V) time.
    /// </remarks>
    public class Graph<TUndirectedEdge> : AdjacencyListGraph<TUndirectedEdge>
        where TUndirectedEdge : UndirectedEdge
    {
        public Graph(int numberOfVertices) : base(numberOfVertices)
        {
        }

        public Graph(AdjacencyListGraph<TUndirectedEdge> adjacencyListGraph) : base(adjacencyListGraph)
        {
        }

        public Graph(int V, int E) : base(V, E)
        {
        }

        /// <summary>
        /// Adds the undirected edge v-w to this graph.
        /// </summary>
        /// <param name="edge"></param>
        /// <exception cref="ArgumentException">unless both {@code 0 <= v < V} and {@code 0 <= w < V}</exception>
        public void AddEdge(TUndirectedEdge edge)
        {
            var v = edge.Either();
            var w = edge.Other(v);
            ValidateVertex(v);
            ValidateVertex(w);
            _adjacencyList[v].Add(edge);
            _adjacencyList[w].Add(edge);
            E++;
        }

        /// <summary>
        /// Returns all edges in this edge-weighted graph.
        /// </summary>
        public IEnumerable<TUndirectedEdge> Edges
        {
            get
            {
                var list = new LinkedList<TUndirectedEdge>();
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
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("{0} vertices, {1} edges ", V, E, Environment.NewLine);
            for (int v = 0; v < V; v++)
            {
                sb.AppendFormat("{0}: ", v);
                foreach (var undirectedEdge in Adjacency(v))
                {
                    sb.AppendFormat("{0} ", undirectedEdge);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}