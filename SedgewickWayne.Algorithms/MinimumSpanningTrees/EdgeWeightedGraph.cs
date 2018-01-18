﻿
namespace SedgewickWayne.Algorithms
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/******************************************************************************
 *  Compilation:  javac EdgeWeightedGraph.java
 *  Execution:    java EdgeWeightedGraph filename.txt
 *  Dependencies: Bag.java Edge.java In.java StdOut.java
 *  Data files:   http://algs4.cs.princeton.edu/43mst/tinyEWG.txt
 *                http://algs4.cs.princeton.edu/43mst/mediumEWG.txt
 *                http://algs4.cs.princeton.edu/43mst/largeEWG.txt
 *
 *  An edge-weighted undirected graph, implemented using adjacency lists.
 *  Parallel edges and self-loops are permitted.
 *
 *  % java EdgeWeightedGraph tinyEWG.txt 
 *  8 16
 *  0: 6-0 0.58000  0-2 0.26000  0-4 0.38000  0-7 0.16000  
 *  1: 1-3 0.29000  1-2 0.36000  1-7 0.19000  1-5 0.32000  
 *  2: 6-2 0.40000  2-7 0.34000  1-2 0.36000  0-2 0.26000  2-3 0.17000  
 *  3: 3-6 0.52000  1-3 0.29000  2-3 0.17000  
 *  4: 6-4 0.93000  0-4 0.38000  4-7 0.37000  4-5 0.35000  
 *  5: 1-5 0.32000  5-7 0.28000  4-5 0.35000  
 *  6: 6-4 0.93000  6-0 0.58000  3-6 0.52000  6-2 0.40000
 *  7: 2-7 0.34000  1-7 0.19000  0-7 0.16000  5-7 0.28000  4-7 0.37000
 *
 ******************************************************************************/

/**
 *  The {@code EdgeWeightedGraph} class represents an edge-weighted
 *  graph of vertices named 0 through <em>V</em> - 1, where each
 *  undirected edge is of type {@link Edge} and has a real-valued weight.
 *  It supports the following two primary operations: add an edge to the graph,
 *  iterate over all of the edges incident to a vertex. It also provides
 *  methods for returning the number of vertices <em>V</em> and the number
 *  of edges <em>E</em>. Parallel edges and self-loops are permitted.
 *  <p>
 *  This implementation uses an adjacency-lists representation, which 
 *  is a vertex-indexed array of @link{Bag} objects.
 *  All operations take constant time (in the worst case) except
 *  iterating over the edges incident to a given vertex, which takes
 *  time proportional to the number of such edges.
 *  <p>
 *  For additional documentation,
 *  see <a href="http://algs4.cs.princeton.edu/43mst">Section 4.3</a> of
 
 *
 

 */
  public class EdgeWeightedGraph
  {
    /**
       * Returns the number of vertices in this edge-weighted graph.
       *
       * @return the number of vertices in this edge-weighted graph
       */
    public int V { get; private set; }

    /**
     * Returns the number of edges in this edge-weighted graph.     
     */
    public int E { get; private set; }


    //private Bag<Edge>[] adj;
    //LinkedList<Edge>[] Adjacency {get; set;}
    // edges incident to vertex v
    LinkedList<Edge>[] adj;


    /**
     * Initializes an empty edge-weighted graph with {@code V} vertices and 0 edges.
     *
     * @param  V the number of vertices
     * Throws <see cref="ArgumentException" /> if {@code V < 0}
     */
    public EdgeWeightedGraph (int V)
    {
      if (V < 0) throw new ArgumentException("Number of vertices must be nonnegative");
      this.V = V;
      this.E = 0;
      //adj = (Bag<Edge>[]) new Bag[V];
      adj = new LinkedList<Edge>[V];
      for (int i = 0; i < V; adj[i++] = new LinkedList<Edge>());
    }

    /**
     * Initializes a random edge-weighted graph with {@code V} vertices and <em>E</em> edges.
     *
     * @param  V the number of vertices
     * @param  E the number of edges
     * Throws <see cref="ArgumentException" /> if {@code V < 0}
     * Throws <see cref="ArgumentException" /> if {@code E < 0}
     */
    public EdgeWeightedGraph (int V, int E)
      : this(V)
    {
      if (E < 0) throw new ArgumentException("Number of edges must be nonnegative");
      // will get incremented by AddEdge
      this.E = 0;

    }

    private void AutoGenerateEdges (int noEdges)
    {
      // clear edges
      for (int i = 0; i < V; adj[i++].Clear());
      
      Random r = new Random();
      for (int i = 0; i < noEdges; i++)
      {
        //int v = StdRandom.uniform(V);
        //int w = StdRandom.uniform(V);
        //double weight = Math.round(100 * StdRandom.uniform()) / 100.0;
        int v = r.Next(this.V);
        int w = r.Next(this.V);
        double weight = r.NextDouble();
        Edge e = new Edge(v, w, weight);
        AddEdge(e);
      }
    }


    /**
     * Initializes a new edge-weighted graph that is a deep copy of {@code G}.
     *
     * @param  G the edge-weighted graph to copy
     */
    public EdgeWeightedGraph (EdgeWeightedGraph G)
      : this(G.V)
    {
      this.E = G.E;
      for (int i = 0; i < G.V; i++)
      {
        // reverse so that adjacency list is in same order as original
        Stack<Edge> reverse = new Stack<Edge>();
        foreach (Edge edge in G.adj[i]) reverse.Push (edge);

        foreach (Edge edge in reverse) adj[i].AddLast(edge);
      }
    }

    // throw an ArgumentException unless {@code 0 <= v < V}
    void validateVertex (int i)
    {
      if (i < 0 || i >= V)
        throw new ArgumentException("vertex " + i + " is not between 0 and " + (V - 1));
    }

    /**
     * Adds the undirected edge {@code e} to this edge-weighted graph.
     *
     * @param  e the edge
     * Throws <see cref="ArgumentException" /> unless both endpoints are between 0 and {@code V-1}
     */
    public void AddEdge (Edge edge)
    {
      int either = edge.Either;
      int other = edge.other(either);

      validateVertex(either);
      validateVertex(other);
      adj[either].AddLast(edge);
      adj[other].AddLast(edge);
      E++;
    }

    public void AddEdge (int sourceVertex, int destinationVertex, double weight)
    {
      AddEdge(new Edge(sourceVertex, destinationVertex, weight));
    }

    /**
     * Returns the edges incident on vertex {@code v}.
     *
     * @param  v the vertex
     * @return the edges incident on vertex {@code v} as an Iterable
     * Throws <see cref="ArgumentException" /> unless {@code 0 <= v < V}
     */
    public IEnumerable<Edge> Adjacency (int v)
    {
      validateVertex(v);
      return adj[v];
    }

    /**
     * Returns the degree of vertex {@code v}.
     *
     * @param  v the vertex
     * @return the degree of vertex {@code v}               
     * Throws <see cref="ArgumentException" /> unless {@code 0 <= v < V}
     */
    public int Degree (int v)
    {
      validateVertex(v);
      return adj[v].Count;
    }

    /**
     * Returns all edges in this edge-weighted graph.
     * To iterate over the edges in this edge-weighted graph, use foreach notation:
     * {@code for (Edge e : G.edges())}.
     *
     * @return all edges in this edge-weighted graph, as an iterable
     */
    public IEnumerable<Edge> Edges
    {
      get
      {
        var list = new LinkedList<Edge>();
        for (int v = 0; v < V; v++)
        {
          int selfLoops = 0;
          foreach (Edge e in Adjacency(v))
          {
            if (e.other(v) > v)
            {
              list.AddLast(e);
            }
            // only add one copy of each self loop (self loops will be consecutive)
            else if (e.other(v) == v)
            {
              if (selfLoops % 2 == 0) list.AddLast(e);
              selfLoops++;
            }
          }
        }
        return list;
      }
    }

    /**
     * Returns a string representation of the edge-weighted graph.
     * This method takes time proportional to <em>E</em> + <em>V</em>.
     *
     * @return the number of vertices <em>V</em>, followed by the number of edges <em>E</em>,
     *         followed by the <em>V</em> adjacency lists of edges
     */
    public override string ToString ( )
    {
      StringBuilder s = new StringBuilder();
      s.AppendFormat("{0} {1}{2}", V, E, Environment.NewLine);
      for (int v = 0; v < V; v++)
      {
        s.AppendFormat(v + ": ");
        foreach (Edge e in adj[v]) s.AppendFormat("{0} ", e);
        s.Append(Environment.NewLine);
      }
      return s.ToString();
    }
  }
    

}

