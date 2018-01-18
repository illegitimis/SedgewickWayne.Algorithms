// Compute a minimum spanning forest using Prim's algorithm.

namespace SedgewickWayne.Algorithms
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Diagnostics.Contracts;





 

  /**
   *  The {@code EagerPrimMST} class represents a data type for computing a
   *  <em>minimum spanning tree</em> in an edge-weighted graph.
   *  The edge weights can be positive, zero, or negative and need not
   *  be distinct. If the graph is not connected, it computes a <em>minimum
   *  spanning forest</em>, which is the union of minimum spanning trees
   *  in each connected component. The {@code weight()} method returns the 
   *  weight of a minimum spanning tree and the {@code edges()} method
   *  returns its edges.
   *  <p>
   *  This implementation uses <em>Prim's algorithm</em> with an INDEXED BINARY HEAP.
   *  The constructor takes time proportional to <em>E</em> log <em>V</em>
   *  and extra space (not including the graph) proportional to <em>V</em>,
   *  where <em>V</em> is the number of vertices and <em>E</em> is the number of edges.
   *  Afterwards, the {@code weight()} method takes constant time
   *  and the {@code edges()} method takes time proportional to <em>V</em>.
   *  <p>
   *  For additional documentation,
   *  see <a href="http://algs4.cs.princeton.edu/43mst">Section 4.3</a> of
   
   *  For alternate implementations, see {@link LazyEagerPrimMST}, {@link KruskalMST}, and {@link BoruvkaMST}.
   *
   
  
   *  
   * Eager implementation. 
   * To improve the lazy implementation of Prim's algorithm, we might try to DELETE 
   * INELIGIBLE EDGES FROM THE PRIORITY QUEUE, so that the priority queue contains 
   * only the crossing edges. But we can eliminate even more edges. 
   * The key is to note that our only interest is in the MINIMAL EDGE FROM EACH 
   * NON-TREE VERTEX TO A TREE VERTEX. When we add a vertex v to the tree, the only 
   * possible change with respect to each non-tree vertex w is that adding v 
   * brings w closer than before to the tree. 
   * In short, we do not need to keep on the priority queue all of the edges from w 
   * to vertices tree—we just need to keep track of the minimum-weight edge and check 
   * whether the addition of v to the tree necessitates that we update that minimum 
   * (because of an edge v-w that has lower weight), which we can do as we process 
   * each edge in s adjacency list. In other words, we maintain on the priority queue 
   * just one edge for each non-tree vertex: 
   * the shortest edge that connects it to the tree. 
   */
  public class EagerPrimMST : IMinimumSpanningTreeAlgorithm
  {
    private Edge[] edgeTo;        // edgeTo[v] = shortest edge from tree vertex to non-tree vertex
    private double[] distTo;      // distTo[v] = weight of shortest such edge
    private bool[] marked;     // marked[v] = true if v on tree, false otherwise
    private IndexMinPQ<Double> pq;

    /**
     * Compute a minimum spanning tree (or forest) of an edge-weighted graph.
     * @param G the edge-weighted graph
     */
    public EagerPrimMST (EdgeWeightedGraph G)
    {
      edgeTo = new Edge[G.V];
      distTo = new double[G.V];
      marked = new bool[G.V];
      pq = new IndexMinPQ<Double>(G.V);
      for (int v = 0; v < G.V; distTo[v++] = Double.MaxValue);
        

      for (int v = 0; v < G.V; v++)      // run from each vertex to Find
        if (!marked[v]) prim(G, v);      // minimum spanning forest

      // check optimality conditions
      // assert check(G);
      Contract.Assert(check(G));
    }

    // run Prim's algorithm in graph G, starting from vertex s
    private void prim (EdgeWeightedGraph G, int s)
    {
      distTo[s] = 0.0;
      pq.Insert(s, distTo[s]);
      while (!pq.IsEmpty)
      {
        throw new NotImplementedException();
        //int v = pq.DeleteMin();
        //scan(G, v);
      }
    }

    // scan vertex v
    private void scan (EdgeWeightedGraph G, int v)
    {
      marked[v] = true;
      foreach (Edge e in G.Adjacency(v))
      {
        int w = e.other(v);
        if (marked[w]) continue;         // v-w is obsolete edge
        if (e.Weight < distTo[w])
        {
          distTo[w] = e.Weight;
          edgeTo[w] = e;
          if (pq.Contains(w)) pq.decreaseKey (w, distTo[w]);
          else pq.Insert(w, distTo[w]);
        }
      }
    }

    /**
     * Returns the edges in a minimum spanning tree (or forest).
     * @return the edges in a minimum spanning tree (or forest) as
     *    an iterable of edges
     */
    public IEnumerable<Edge> Edges { get { return edgeTo; } }

    /**
     * Returns the sum of the edge weights in a minimum spanning tree (or forest).
     * @return the sum of the edge weights in a minimum spanning tree (or forest)
     */
    public double Weight { get { return Edges.Where(e=>e!=null).Sum (e => e.Weight); } }


    // check optimality conditions (takes time proportional to E V lg* V)
    private bool check (EdgeWeightedGraph G)
    {

      // check weight
      //double totalWeight = 0.0;
      //foreach (Edge e in edges()) {
      //    totalWeight += e.Weight;
      //}
      //if (Math.abs(totalWeight - weight()) > FLOATING_POINT_EPSILON) {
      //    System.err.printf("Weight of edges does not equal weight(): %f vs. %f\n", totalWeight, weight());
      //    return false;
      //}

      // check that it is acyclic
      //UF uf = new UF(G.V);
      //foreach (Edge e in edges()) {
      //    int v = e.either(), w = e.other(v);
      //    if (uf.connected(v, w)) {
      //        System.err.println("Not a forest");
      //        return false;
      //    }
      //    uf.union(v, w);
      //}

      // check that it is a spanning forest
      //foreach (Edge e in G.edges()) {
      //    int v = e.either(), w = e.other(v);
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
        //for (Edge f : edges()) {
        //    int x = f.either(), y = f.other(x);
        //    if (f != e) uf.union(x, y);
        //}

        // check that e is min weight edge in crossing cut
        //for (Edge f : G.edges()) {
        //    int x = f.either(), y = f.other(x);
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