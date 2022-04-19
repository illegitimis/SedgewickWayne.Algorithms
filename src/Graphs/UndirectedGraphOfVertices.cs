/*
 Graph.java
Copyright © 2000–2019, Robert Sedgewick and Kevin Wayne.
Last updated: Wed Jan 20 05:27:29 EST 2021.
Below is the syntax highlighted version of Graph.java from §4.1 Undirected Graphs. 
For additional documentation, see <a href="https://algs4.cs.princeton.edu/41graph">Section 4.1</a> of <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.

https://algs4.cs.princeton.edu/40graphs/
https://algs4.cs.princeton.edu/43mst/
*/

/******************************************************************************
 *  Compilation:  javac Graph.java        
 *  Execution:    java Graph input.txt
 *  Dependencies: Bag.java Stack.java In.java StdOut.java
 *  Data files:   https://algs4.cs.princeton.edu/41graph/tinyG.txt
 *                https://algs4.cs.princeton.edu/41graph/mediumG.txt
 *                https://algs4.cs.princeton.edu/41graph/largeG.txt
 *
 *  A graph, implemented using an array of sets.
 *  Parallel edges and self-loops allowed.
 *
 *  % java Graph tinyG.txt
 *  13 vertices, 13 edges 
 *  0: 6 2 1 5 
 *  1: 0 
 *  2: 0 
 *  3: 5 4 
 *  4: 5 6 3 
 *  5: 3 4 0 
 *  6: 0 4 
 *  7: 8 
 *  8: 7 
 *  9: 11 10 12 
 *  10: 9 
 *  11: 9 12 
 *  12: 11 9 
 *
 *  % java Graph mediumG.txt
 *  250 vertices, 1273 edges 
 *  0: 225 222 211 209 204 202 191 176 163 160 149 114 97 80 68 59 58 49 44 24 15 
 *  1: 220 203 200 194 189 164 150 130 107 72 
 *  2: 141 110 108 86 79 51 42 18 14 
 *  ...
 *  
 ******************************************************************************/

using System;
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
    public class UndirectedGraphOfVertices : AdjacencyListGraph<int>
    {
        public UndirectedGraphOfVertices(int numberOfVertices) : base(numberOfVertices)
        {
        }

        public UndirectedGraphOfVertices(AdjacencyListGraph<int> abstractGraph) : base(abstractGraph)
        {
        }

        public UndirectedGraphOfVertices(int V, int E) : base(V, E)
        {
        }

        /**
         * Adds the undirected edge v-w to this graph.
         *
         * @param  v one vertex in the edge
         * @param  w the other vertex in the edge
         * @throws ArgumentException unless both {@code 0 <= v < V} and {@code 0 <= w < V}
         */
        public void AddEdge(int v, int w)
        {
            ValidateVertex(v);
            ValidateVertex(w);
            E++;
            _adjacencyList[v].Add(w);
            _adjacencyList[w].Add(v);
        }

        /**
         * Returns a string representation of this graph.
         *
         * @return the number of vertices V, followed by the number of edges E, followed by the V adjacency lists
         */
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("{0} vertices, {1} edges ", V, E, Environment.NewLine);
            for (int v = 0; v < V; v++)
            {
                sb.AppendFormat("{0}: ", v);
                foreach (int w in Adjacency(v))
                {
                    sb.AppendFormat("{0} ", w);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }

}