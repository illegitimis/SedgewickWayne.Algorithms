
namespace SedgewickWayne.Algorithms
{
  using System.Collections.Generic;
  using System.Diagnostics.Contracts;
  using UF = SedgewickWayne.Algorithms.DynamicConnectivity.UF;

  /******************************************************************************
   *  Compilation:  javac KruskalMST.java
   *  Execution:    java  KruskalMST filename.txt
   *  Dependencies: EdgeWeightedGraph.java Edge.java UF.java
   *  Data files:   http://algs4.cs.princeton.edu/43mst/tinyEWG.txt
   *                http://algs4.cs.princeton.edu/43mst/mediumEWG.txt
   *                http://algs4.cs.princeton.edu/43mst/largeEWG.txt
   *
   *  Compute a minimum spanning forest using Kruskal's algorithm.
   *
   *  % java KruskalMST mediumEWG.txt
   *  168-231 0.00268
   *  151-208 0.00391
   *  7-157   0.00516
   *  122-205 0.00647
   *  8-152   0.00702
   *  156-219 0.00745
   *  28-198  0.00775
   *  38-126  0.00845
   *  10-123  0.00886
   *  ...
   *  10.46351
   *
   ******************************************************************************/

  /**
   *  The {@code KruskalMST} class represents a data type for computing a
   *  <em>minimum spanning tree</em> in an edge-weighted graph.
   *  The edge weights can be positive, zero, or negative and need not
   *  be distinct. If the graph is not connected, it computes a <em>minimum
   *  spanning forest</em>, which is the union of minimum spanning trees
   *  in each connected component. The {@code Weight} method returns the 
   *  weight of a minimum spanning tree and the {@code Edges} method
   *  returns its edges.
   
   *  This implementation uses <em>Krusal's algorithm</em> and the
   *  union-Find data type.
   *  The constructor takes time proportional to E log E
   *  and extra space (not including the graph) proportional to V,
   *  where V is the number of vertices and E is the number of edges.
   *  Afterwards, the {@code Weight} method takes constant time
   *  and the {@code Edges} method takes time proportional to V.
   
   *  For additional documentation,
   *  see <a href="http://algs4.cs.princeton.edu/43mst">Section 4.3</a> of
   
   *  For alternate implementations, see {@link LazyPrimMST}, {@link PrimMST},
   *  and {@link BoruvkaMST}.
   *
   
  
   */
  public class KruskalMST : IMinimumSpanningTreeAlgorithm
  {
    private double weight;                        // weight of MST
    private Queue<Edge> mst = new Queue<Edge>();  // edges in MST

    /**
     * Compute a minimum spanning tree (or forest) of an edge-weighted graph.
     * @param G the edge-weighted graph
     */
    public KruskalMST (EdgeWeightedGraph G)
    {
      // more efficient to build heap by passing array of edges
      MinPQ<Edge> pq = new MinPQ<Edge>();
      foreach (Edge e in G.Edges)
      {
        pq.Insert(e);
      }

      // run greedy algorithm
      UF uf = new UF(G.V);
      while (!pq.IsEmpty && mst.Size < G.V - 1)
      {
        Edge e = pq.DeleteMin ();
        int v = e.Either;
        int w = e.other(v);
        if (!uf.Connected(v, w)) 
        { // v-w does not create a cycle
          // merge v and w components
          uf.Union(v, w);
          mst.Enqueue(e);  // add edge e to mst
          weight += e.Weight;
        }
      }

      // check optimality conditions
      //assert ;
      Contract.Assert(check(G));
    }

    /**
     * Returns the edges in a minimum spanning tree (or forest).
     * @return the edges in a minimum spanning tree (or forest) as
     *    an iterable of edges
     */
    public IEnumerable<Edge> Edges { get { return mst; } }

    /**
     * Returns the sum of the edge weights in a minimum spanning tree (or forest).
     * @return the sum of the edge weights in a minimum spanning tree (or forest)
     */
    public double Weight { get { return weight; } }

    // check optimality conditions (takes time proportional to E V lg* V)
    private bool check (EdgeWeightedGraph G)
    {

      // check total weight
      //double total = 0.0;
      //foreach (Edge e in Edges) {
      //    total += e.Weight;
      //}
      //if (Math.abs(total - Weight) > FLOATING_POINT_EPSILON) {
      //    System.err.printf("Weight of edges does not equal Weight: %f vs. %f\n", total, Weight);
      //    return false;
      //}

      // check that it is acyclic
      //UF uf = new UF(G.V);
      //foreach (Edge e in Edges) {
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
      foreach (Edge e in Edges)
      {

        // all edges in MST except e
        //uf = new UF(G.V);
        //for (Edge f : mst) {
        //    int x = f.Either, y = f.other(x);
        //    if (f != e) uf.union(x, y);
        //}

        // check that e is min weight edge in crossing cut
        //for (Edge f : G.Edges) {
        //    int x = f.Either, y = f.other(x);
        //    if (!uf.connected(x, y)) {
        //        if (f.Weight < e.Weight) {
        //            System.err.println("Edge " + f + " violates cut optimality conditions");
        //            return false;
        //        }
        //    }
        //}

      }

      return true;
    }




  }

}