/*
 Graph.java
Copyright © 2000–2019, Robert Sedgewick and Kevin Wayne.
Last updated: Wed Jan 20 05:27:29 EST 2021.
Below is the syntax highlighted version of Graph.java from §4.1 Undirected Graphs. 
For additional documentation, see <a href="https://algs4.cs.princeton.edu/41graph">Section 4.1</a> of <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.

https://algs4.cs.princeton.edu/40graphs/
https://algs4.cs.princeton.edu/43mst/
*/

using System;
using System.Text;

namespace SedgewickWayne.Algorithms.Graphs
{
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

        public override string ToString()
        {
            return $"{V} {E}";
            /*
            var sb = new StringBuilder();
            sb.AppendLine($"{V} {E}");
            
            for (int v = 0; v < V; v++)
            {
                sb.AppendFormat("{0}: ", v);
                foreach (var edge in adj[v]) s.AppendFormat("{0} ", e);
                s.Append(Environment.NewLine);
            }
            return s.ToString();
            */
        }
    }
}
