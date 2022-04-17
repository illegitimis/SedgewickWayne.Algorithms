using System;

namespace SedgewickWayne.Algorithms.Graphs
{
    /// <summary>
    /// Common abstraction for weighted edge graphs and digraphs.
    /// </summary>
    /// <remarks>
    /// <see href="https://algs4.cs.princeton.edu/41graph"/>
    /// <see href="https://algs4.cs.princeton.edu/43mst/"/>
    /// <see href="https://algs4.cs.princeton.edu/40graphs/"/>
    /// </remarks>
    public abstract class AbstractGraph
    {
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
        protected AbstractGraph(int numberOfVertices)
        {
            if (numberOfVertices < 0) throw new ArgumentException("Number of vertices must be non-negative");
            V = numberOfVertices;
            E = 0;
        }

        /// <summary>
        /// Initializes a random edge-weighted graph with V vertices and E edges.
        /// </summary>
        /// <param name="V"></param>
        /// <param name="E"></param>
        /// <exception cref="ArgumentException">E < 0</exception>
        protected AbstractGraph(int V, int E) :
            this(V)
        {
            if (E < 0) throw new ArgumentException("Number of edges must be nonnegative");
            // will get incremented by AddEdge
            this.E = 0;
        }

        protected AbstractGraph(AbstractGraph abstractGraph)
        {
            if (V < 0) throw new ArgumentException("Number of vertices must be non-negative");
            V = abstractGraph.V;
            E = abstractGraph.E;
        }

        public override string ToString() => $"{V} {E}";

        protected void ValidateVertex(int i)
        {
            if (i < 0 || i >= V)
                throw new ArgumentException("vertex " + i + " is not between 0 and " + (V - 1));
        }
    }
}