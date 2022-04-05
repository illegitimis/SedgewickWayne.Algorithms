/******************************************************************************
  *  Data files:   http://algs4.cs.princeton.edu/43mst/tinyEWG.txt
  *                http://algs4.cs.princeton.edu/43mst/mediumEWG.txt
  *                http://algs4.cs.princeton.edu/43mst/largeEWG.txt
  *
  *  % java EagerPrimMST mediumEWG.txt
  *  1-72   0.06506
  *  2-86   0.05980
  *  3-67   0.09725
  *  4-55   0.06425
  *  5-102  0.03834
  *  6-129  0.05363
  *  7-157  0.00516
  *  ...
  *  10.46351
  *
  *  % java EagerPrimMST largeEWG.txt
  *  ...
  *  647.66307
  *  
  *   *
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
  *
  * Compilation:  javac EdgeWeightedGraph.java
  * Execution:    java EdgeWeightedGraph filename.txt
  * Dependencies: Bag.java Edge.java In.java StdOut.java
  ******************************************************************************/


using SedgewickWayne.Algorithms.Graphs;

namespace SedgewickWayne.Algorithms.UnitTests
{
   public static class EdgeWeightedGraphBuilder
    {
        /*
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
         */
        public static EdgeWeightedGraph<double> Tiny()
        {
            var ewg = new EdgeWeightedGraph<double>(8 /*, 16*/);
            ewg.AddEdge(4, 5, 0.35);
            ewg.AddEdge(4, 7, 0.37);
            ewg.AddEdge(5, 7, 0.28);
            ewg.AddEdge(0, 7, 0.16);
            ewg.AddEdge(1, 5, 0.32);
            ewg.AddEdge(0, 4, 0.38);
            ewg.AddEdge(2, 3, 0.17);
            ewg.AddEdge(1, 7, 0.19);
            ewg.AddEdge(0, 2, 0.26);
            ewg.AddEdge(1, 2, 0.36);
            ewg.AddEdge(1, 3, 0.29);
            ewg.AddEdge(2, 7, 0.34);
            ewg.AddEdge(6, 2, 0.40);
            ewg.AddEdge(3, 6, 0.52);
            ewg.AddEdge(6, 0, 0.58);
            ewg.AddEdge(6, 4, 0.93);
            return ewg;
        }

        /* TODO
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
       */
    }
}
