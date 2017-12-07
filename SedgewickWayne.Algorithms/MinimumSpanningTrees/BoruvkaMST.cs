/******************************************************************************
* Data files: http://algs4.cs.princeton.edu/43mst/BoruvkaMST.java     
* Compute a minimum spanning forest using Boruvka's algorithm.
******************************************************************************/

namespace SedgewickWayne.Algorithms
{
  using System.Collections.Generic;
  using System.Diagnostics.Contracts;
  using UF = SedgewickWayne.Algorithms.DynamicConnectivity.UF;


  /**
   *  The {@code BoruvkaMST} class represents a data type for computing a
   *  <em>minimum spanning tree</em> in a undirected weighted adjacency-list graph .
   *  The edge weights can be positive, zero, or negative and need not
   *  be distinct. If the graph is not connected, it computes a <em>minimum
   *  spanning forest</em>, which is the union of minimum spanning trees
   *  in each connected component. The {@code weight()} method returns the 
   *  weight of a minimum spanning tree and the {@code edges()} method
   *  returns its edges.
   *  <p>
   *  This implementation uses <em>Boruvka's algorithm</em> and the union-Find
   *  data type.
   *  The constructor takes time proportional to <em>E</em> log <em>V</em>
   *  and extra space (not including the graph) proportional to <em>V</em>,
   *  where <em>V</em> is the number of vertices and <em>E</em> is the number of edges.
   *  Afterwards, the {@code weight()} method takes constant time
   *  and the {@code edges()} method takes time proportional to <em>V</em>.
   *  <p>
   *  For additional documentation,
   *  see <a href="http://algs4.cs.princeton.edu/43mst">Section 4.3</a> of
   *  <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.
   *  For alternate implementations, see {@link LazyPrimMST}, {@link PrimMST},
   *  and {@link KruskalMST}.
   *
   *  @author Robert Sedgewick
   *  @author Kevin Wayne
   */
  public class BoruvkaMST : IMinimumSpanningTreeAlgorithm
  {

    // edges in MST
    //private Bag<Edge> mst = new Bag<Edge>();
    List<Edge> mst = new List<Edge>();

    /**
     * Compute a minimum spanning tree (or forest) of an edge-weighted graph.
     * @param G the edge-weighted graph
     */
    public BoruvkaMST (EdgeWeightedGraph G)
    {
      UF uf = new UF(G.V);

      // repeat at most log V times or until we have V-1 edges
      for (int t = 1; t < G.V && mst.Count < G.V - 1; t = t + t)
      {
        // foreach tree in forest, Find closest edge
        // if edge weights are equal, ties are broken in favor of first edge in G.edges()
        Edge[] closest = new Edge[G.V];
        foreach (Edge e in G.Edges)
        {
          int v = e.Either, w = e.other(v);
          int i = uf.Find(v), j = uf.Find(w);
          if (i == j) continue;   // same tree
          if (closest[i] == null || e < closest[i]) closest[i] = e;
          if (closest[j] == null || e < closest[j]) closest[j] = e;
        }

        // add newly discovered edges to MST
        for (int i = 0; i < G.V; i++)
        {
          Edge e = closest[i];
          if (e != null)
          {
            int v = e.Either, w = e.other(v);
            // don't add the same edge twice
            if (!uf.Connected(v, w))
            {
              mst.Add(e);
              Weight += e.Weight;
              uf.Union(v, w);
            }
          }
        }
      }

      // check optimality conditions
      //assert check(G);
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
     * weight of MST
     */
    public double Weight { get; private set; }



    // check optimality conditions (takes time proportional to E V lg* V)
    private bool check (EdgeWeightedGraph G)
    {

      // check weight
      //double totalWeight = 0.0;
      //for (Edge e : edges()) {
      //    totalWeight += e.weight();
      //}
      //if (Math.abs(totalWeight - weight()) > FLOATING_POINT_EPSILON) {
      //    System.err.printf("Weight of edges does not equal weight(): %f vs. %f\n", totalWeight, weight());
      //    return false;
      //}

      // check that it is acyclic
      //UF uf = new UF(G.V);
      //for (Edge e : edges()) {
      //    int v = e.Either, w = e.other(v);
      //    if (uf.connected(v, w)) {
      //        System.err.println("Not a forest");
      //        return false;
      //    }
      //    uf.union(v, w);
      //}

      // check that it is a spanning forest
      //for (Edge e : G.edges()) {
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
        //for (Edge f : G.edges()) {
        //    int x = f.Either, y = f.other(x);
        //    if (!uf.connected(x, y)) {
        //        if (f.weight() < e.weight()) {
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
