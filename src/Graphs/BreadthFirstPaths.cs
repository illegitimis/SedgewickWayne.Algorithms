/* 
 * Single-source shortest paths.
 * Given a graph and a source vertex s, support queries of the form Is there a path from s to a given target vertex v?
 * If so, find a shortest such path (one with a minimal number of edges).
 * In contrast, BFS is based on this goal.
 * To find a shortest path from s to v, we start at s and check for v among all the vertices that we can reach by following one edge,
 * then we check for v among all the vertices that we can reach from s by following two edges, and so forth.
 */

using System.Collections.Generic;
using System.Linq;
using static SedgewickWayne.Algorithms.Graphs.GraphUtility;

namespace SedgewickWayne.Algorithms.Graphs
{
    // https://algs4.cs.princeton.edu/41graph/BreadthFirstPaths.java.html
    public class BreadthFirstPaths : AbstractFindPath<int>
    {
        private bool[] marked;    // marked[v] = is there an s-v path?
        private int[] edgeTo;      // edgeTo[v] = previous edge on shortest s-v path
        private int[] distTo;      // distTo[v] = number of edges shortest s-v path
        
        AdjacencyListGraph<int> g;

        public BreadthFirstPaths(AdjacencyListGraph<int> G, int s) : base(G, s)
        {
            ValidateVertex(s, G.V);
            marked = new bool[G.V];
            edgeTo = new int[G.V];
            distTo = new int[G.V];
            g = G;
            Bfs(s);
        }

        // breadth-first search from a single source
        private void Bfs(int s)
        {
            var q = new Queue<int>();
            for(int i =0; i < g.V; i++) distTo[i] = int.MaxValue;
            distTo[s] = 0;
            marked[s] = true;
            q.Enqueue(s);

            while (!q.IsEmpty)
            {
                var v = q.Dequeue();
                foreach(int w in g.Adjacency(v))
                {
                    if (marked[w]) continue;
                    marked[w] = true;
                    edgeTo[w] = v;
                    distTo[w] = 1 + distTo[v];
                    q.Enqueue(w);
                }
            }
        }

        public override bool HasPathTo(int v)
        {
            ValidateVertex(v, g.V);
            return marked[v];
        }

        public override IEnumerable<int> PathTo(int v)
        {
            ValidateVertex(v, g.V);
            if (!HasPathTo(v)) return Enumerable.Empty<int>();

            var path = new Stack<int>();
            for (int i = v; i != S; i = edgeTo[i])
            {
                path.Push(i);
            }
            path.Push(S);
            return path;
        }
    }
}
