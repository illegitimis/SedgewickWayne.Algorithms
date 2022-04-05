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
    public class UndirectedGraph : AbstractGraph
    {
        private Bag<int>[] adj;

        /**
   * Initializes an empty graph with V vertices and 0 edges.
   * param V the number of vertices
   *
   * @param  V number of vertices
   * @throws ArgumentException if {@code V < 0}
   */

        public UndirectedGraph(int numberOfVertices) : base(numberOfVertices) => UpdateAdjacencyLists(V);

        /**
  * Initializes a new graph that is a deep copy of {@code G}.
  *
  * @param  G the graph to copy
  * @throws ArgumentException if {@code G} is {@code null}
  */
        public UndirectedGraph(UndirectedGraph G) : base(G)
        {
            UpdateAdjacencyLists(V);

            for (int v = 0; v < G.V; v++)
            {
                // reverse so that adjacency list is in same order as original
                var reverse = new Stack<int>();
                foreach (int w in G.adj[v])
                {
                    reverse.Push(w);
                }
                foreach (int w in reverse)
                {
                    AdjacencyList(v).Add(w);
                }
            }
        }

        private void UpdateAdjacencyLists(int V)
        {
            adj = new Bag<int>[V];
            for (int v = 0; v < V; v++)
            {
                adj[v] = new Bag<int>();
            }
        }

        /**  
    * Initializes a graph from the specified input stream.
    * The format is the number of vertices V,
    * followed by the number of edges E,
    * followed by E pairs of vertices, with each entry separated by whitespace.
    *
    * @param  in the input stream
    * @throws ArgumentException if {@code in} is {@code null}
    * @throws ArgumentException if the endpoints of any edge are not in prescribed range
    * @throws ArgumentException if the number of vertices or edges is negative
    * @throws ArgumentException if the input stream is in the wrong format
    */
        //public Graph(In in)
        //{
        //    if (in == null) throw new ArgumentException("argument is null");
        //    try
        //    {
        //        this.V = in.readInt();
        //        if (V < 0) throw new ArgumentException("number of vertices in a Graph must be non-negative");
        //        adj = (Bag<int>[])new Bag[V];
        //        for (int v = 0; v < V; v++)
        //        {
        //            adj[v] = new Bag<int>();
        //        }
        //        int E = in.readInt();
        //        if (E < 0) throw new ArgumentException("number of edges in a Graph must be non-negative");
        //        for (int i = 0; i < E; i++)
        //        {
        //            int v = in.readInt();
        //            int w = in.readInt();
        //            validateVertex(v);
        //            validateVertex(w);
        //            addEdge(v, w);
        //        }
        //    }
        //    catch (NoSuchElementException e)
        //    {
        //        throw new ArgumentException("invalid input format in Graph constructor", e);
        //    }
        //}

        

        // throw an ArgumentException unless {@code 0 <= v < V}
        private void validateVertex(int v)
        {
            if (v < 0 || v >= V)
                throw new ArgumentException("vertex " + v + " is not between 0 and " + (V - 1));
        }

        /**
         * Adds the undirected edge v-w to this graph.
         *
         * @param  v one vertex in the edge
         * @param  w the other vertex in the edge
         * @throws ArgumentException unless both {@code 0 <= v < V} and {@code 0 <= w < V}
         */
        public void addEdge(int v, int w)
        {
            validateVertex(v);
            validateVertex(w);
            E++;
            AdjacencyList(v).Add(w);
            AdjacencyList(w).Add(v);
        }


        /**
         * Returns the vertices adjacent to vertex {@code v}.
         *
         * @param  v the vertex
         * @return the vertices adjacent to vertex {@code v}, as an iterable
         * @throws ArgumentException unless {@code 0 <= v < V}
         */
        public Bag<int> AdjacencyList(int v)
        {
            validateVertex(v);
            return adj[v];
        }

        /**
         * Returns the degree of vertex {@code v}.
         *
         * @param  v the vertex
         * @return the degree of vertex {@code v}
         * @throws ArgumentException unless {@code 0 <= v < V}
         */
        public int degree(int v)
        {
            validateVertex(v);
            return adj[v].Size;
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
                foreach (int w in AdjacencyList(v))
                {
                    sb.AppendFormat("{0} ", w);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }


        /**
         * Unit tests the {@code Graph} data type.
         *
         * @param args the command-line arguments
         */
        //public static void main(String[] args)
        //{
        //    In in = new In(args[0]);
        //    Graph G = new Graph(in);
        //    StdOut.println(G);
        //}

    }
}