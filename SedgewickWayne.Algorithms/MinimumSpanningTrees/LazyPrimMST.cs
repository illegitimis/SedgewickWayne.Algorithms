

namespace SedgewickWayne.Algorithms
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Diagnostics.Contracts;

  /******************************************************************************
   *  Compilation:  javac LazyPrimMST.java
   *  Execution:    java LazyPrimMST filename.txt
   *  Dependencies: EdgeWeightedGraph.java Edge.java Queue.java
   *                MinPQ.java UF.java In.java StdOut.java
   *  Data files:   http://algs4.cs.princeton.edu/43mst/tinyEWG.txt
   *                http://algs4.cs.princeton.edu/43mst/mediumEWG.txt
   *                http://algs4.cs.princeton.edu/43mst/largeEWG.txt
   *
   *  Compute a minimum spanning forest using a lazy version of Prim's algorithm.
   *

   *
   *  % java LazyPrimMST mediumEWG.txt
   *  0-225   0.02383
   *  49-225  0.03314
   *  44-49   0.02107
   *  44-204  0.01774
   *  49-97   0.03121
   *  202-204 0.04207
   *  176-202 0.04299
   *  176-191 0.02089
   *  68-176  0.04396
   *  58-68   0.04795
   *  10.46351
   *
   *  % java LazyPrimMST largeEWG.txt
   *  ...
   *  647.66307
   *
   ******************************************************************************/

  /**
   *  The {@code LazyPrimMST} class represents a data type for computing a
   *  <em>minimum spanning tree</em> in an edge-weighted graph.
   *  The edge weights can be positive, zero, or negative and need not
   *  be distinct. If the graph is not connected, it computes a <em>minimum
   *  spanning forest</em>, which is the union of minimum spanning trees
   *  in each connected component. The {@code weight()} method returns the 
   *  weight of a minimum spanning tree and the {@code Edges} method
   *  returns its edges.
   *  <p>
   *  This implementation uses a LAZY version of <em>Prim's algorithm</em> with a BINARY HEAP OF EDGES.
   *  The constructor takes time proportional to <em>E</em> log <em>E</em>
   *  and extra space (not including the graph) proportional to <em>E</em>,
   *  where <em>V</em> is the number of vertices and <em>E</em> is the number of edges.
   *  Afterwards, the {@code weight()} method takes constant time
   *  and the {@code Edges} method takes time proportional to <em>V</em>.
   *  <p>
   *  For additional documentation,
   *  see <a href="http://algs4.cs.princeton.edu/43mst">Section 4.3</a> of
   
   *  For alternate implementations, see {@link PrimMST}, {@link KruskalMST},
   *  and {@link BoruvkaMST}.
   *
   
  
   */
  public class LazyPrimMST : IMinimumSpanningTreeAlgorithm
  {

    private Queue<Edge> mst;      // edges in the MST
    private bool[] marked;        // marked[v] = true if v on tree
    private MinPQ<Edge> pq;       // edges with one endpoint in tree

    /**
     * Compute a minimum spanning tree (or forest) of an edge-weighted graph.
     * @param G the edge-weighted graph
     */
    public LazyPrimMST (EdgeWeightedGraph G)
    {
      mst = new Queue<Edge>();
      pq = new MinPQ<Edge>();
      marked = new bool[G.V];
      for (int v = 0; v < G.V; v++)     // run Prim from all vertices to
        if (!marked[v]) prim(G, v);     // get a minimum spanning forest

      // check optimality conditions
      //Contracts.Assert (G);
    }

    // run Prim's algorithm
    private void prim (EdgeWeightedGraph G, int s)
    {
      scan(G, s);
      while (!pq.IsEmpty)
      {                                           // better to stop when mst has V-1 edges
        Edge e = pq.DeleteMin();                  // smallest edge on pq
        int v = e.Either, w = e.other(v);         // two endpoints
        //assert marked[v] || marked[w];
        Contract.Assert(marked[v] || marked[w]);
        if (marked[v] && marked[w]) continue;     // lazy, both v and w already scanned
        mst.Enqueue(e);                           // add e to MST
        Weight += e.Weight;
        if (!marked[v]) scan(G, v);               // v becomes part of tree
        if (!marked[w]) scan(G, w);               // w becomes part of tree
      }
    }

    // add all edges e incident to v onto pq if the other endpoint has not yet been scanned
    private void scan (EdgeWeightedGraph G, int v)
    {
      Contract.Assert(!marked[v]);
      marked[v] = true;
      foreach (Edge e in G.Adjacency(v))
        if (!marked[e.other(v)]) pq.Insert(e);
    }

    /**
     * Returns the edges in a minimum spanning tree (or forest).
     * @return the edges in a minimum spanning tree (or forest) as
     *    an iterable of edges
     */
    public IEnumerable<Edge> Edges { get { return mst; } }

    /**
     * Returns the sum of the edge weights in a minimum spanning tree (or forest).
     * total weight of MST
     */
    public double Weight { get; private set; }

    // check optimality conditions (takes time proportional to E V lg* V)
    private bool check (EdgeWeightedGraph G)
    {

      // check weight
      //double totalWeight = 0.0;
      //foreach (Edge e in Edges) {
      //    totalWeight += e.Weight;
      //}
      //if (Math.Abs(totalWeight - Weight) > FLOATING_POINT_EPSILON) {
      //    System.err.printf("Weight of edges does not equal weight(): %f vs. %f\n", totalWeight, weight());
      //    return false;
      //}

      // check that it is acyclic
      //UF uf = new UF(G.V);
      //for (Edge e in Edges) {
      //    int v = e.Either, w = e.other(v);
      //    if (uf.connected(v, w)) {
      //        System.err.println("Not a forest");
      //        return false;
      //    }
      //    uf.union(v, w);
      //}

      // check that it is a spanning forest
      //foreach (Edge e in G.Edges) {
      //    int v = e.Either, w = e.other(v);
      //    if (!uf.connected(v, w)) {
      //        System.err.println("Not a spanning forest");
      //        return false;
      //    }
      //}

      // check that it is a minimal spanning forest (cut optimality conditions)
      //foreach (Edge e in Edges) {

      //    // all edges in MST except e
      //    uf = new UF(G.V);
      //    for (Edge f : mst) {
      //        int x = f.Either, y = f.other(x);
      //        if (f != e) uf.union(x, y);
      //    }

      // check that e is min weight edge in crossing cut
      //for (Edge f : G.Edges) {
      //    int x = f.Either, y = f.other(x);
      //    if (!uf.connected(x, y)) {
      //        if (f.weight() < e.weight()) {
      //            System.err.println("Edge " + f + " violates cut optimality conditions");
      //            return false;
      //        }
      //    }
      //}

      return true;
    }

  }
}
