using System;
using System.Collections.Generic;

namespace SedgewickWayne.Algorithms.Graphs
{
    /// <summary>
    /// Common abstraction for Adjacency List representation.
    /// (e.g. weighted edge graphs and digraphs).
    /// </summary>
    /// <remarks>
    /// <see href="https://algs4.cs.princeton.edu/41graph"/>
    /// <see href="https://algs4.cs.princeton.edu/43mst/"/>
    /// <see href="https://algs4.cs.princeton.edu/40graphs/"/>
    /// </remarks>
    public abstract class AdjacencyListGraph<TInfo>
    {
        // adj[v] = adjacency list for vertex v
        protected Bag<TInfo>[] _adjacencyList;

        /// <summary>
        /// Returns the number of vertices in this graph.
        /// </summary>
        public int V { get; }

        /// <summary>
        /// Returns the number of edges in this graph.
        /// </summary>
        public int E { get; protected set; }

        /// <summary>
        /// Initializes a random edge-weighted graph with V vertices and 0 edges.
        /// </summary>
        /// <param name="numberOfVertices">V the number of vertices</param>
        /// <exception cref="ArgumentException">V < 0</exception>
        protected AdjacencyListGraph(int numberOfVertices)
        {
            if (numberOfVertices < 0) throw new ArgumentException("Number of vertices must be non-negative");
            V = numberOfVertices;
            E = 0;
            AllocateAdjacencyLists();
        }

        /// <summary>
        /// Initializes a random edge-weighted graph with V vertices and E edges.
        /// </summary>
        /// <param name="V">#vertices</param>
        /// <param name="E">#edges</param>
        /// <exception cref="ArgumentException">E < 0</exception>
        protected AdjacencyListGraph(int V, int E) :
            this(V)
        {
            if (E < 0) throw new ArgumentException("Number of edges must be nonnegative");
            // will get incremented by AddEdge
            this.E = 0;
        }

        /// <summary>
        /// Initializes a new edge-weighted digraph that is a deep copy of <paramref name="abstractGraph"/>.
        /// </summary>
        /// <param name="abstractGraph"></param>
        /// <exception cref="ArgumentException"></exception>
        protected AdjacencyListGraph(AdjacencyListGraph<TInfo> abstractGraph)
        {
            if (V < 0) throw new ArgumentException("Number of vertices must be non-negative");
            V = abstractGraph.V;
            E = abstractGraph.E;

            AllocateAdjacencyLists();

            for (int v = 0; v < abstractGraph.V; v++)
            {
                // reverse so that adjacency list is in same order as original
                var reverse = new Stack<TInfo>();
                foreach (var info in abstractGraph._adjacencyList[v])
                {
                    reverse.Push(info);
                }
                foreach (var item in reverse)
                {
                    _adjacencyList[v].Add(item);
                }
            }
        }

        private void AllocateAdjacencyLists()
        {
            //  for every vertex // update adjacency lists
            _adjacencyList = new Bag<TInfo>[V];
            for (int v = 0; v < V; v++)
                _adjacencyList[v] = new Bag<TInfo>();
        }

        public override string ToString() => $"{V} {E}";


        /// <summary>
        /// Returns the edges incident on vertex <paramref name="v"/>.
        /// </summary>
        /// <param name="v">v the vertex</param>
        /// <returns>
        /// the edges incident on vertex <paramref name="v"/> as an <see cref="IEnumerable{TInfo}"/>
        /// </returns>
        public IEnumerable<TInfo> Adjacency(int v)
        {
            ValidateVertex(v);
            return _adjacencyList[v];
        }

        /// <summary>
        ///  Returns the degree of vertex {@code v}.
        /// </summary>
        /// <param name="v"> v the vertex</param>
        /// <returns>the degree of vertex {@code v}</returns>
        public int Degree(int v)
        {
            ValidateVertex(v);
            return _adjacencyList[v].Size;
        }

        protected void ValidateVertex(int i)
        {
            if (i < 0 || i >= V)
                throw new ArgumentException("vertex " + i + " is not between 0 and " + (V - 1));
        }
    }
}