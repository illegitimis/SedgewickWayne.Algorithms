using System.Collections.Generic;
using System.Linq;
using static SedgewickWayne.Algorithms.Graphs.GraphUtility;

namespace SedgewickWayne.Algorithms.Graphs
{
    // https://algs4.cs.princeton.edu/41graph/DepthFirstPaths.java.html
    public class DepthFirstPaths : AbstractFindPath
    {
        private bool[] marked;    // marked[v] = is there an s-v path?
        private int[] edgeTo;     // edgeTo[v] = last edge on s-v path
        Graph g;

        public DepthFirstPaths(Graph G, int s) : base(G, s)
        {
            marked = new bool[G.V];
            edgeTo = new int[G.V];
            ValidateVertex(s, G.V);
            g = G;
            Dfs(s);
        }

        // depth first search from v
        private void Dfs(int v)
        {
            marked[v] = true;
            foreach(var undirectedEdge in g.Adjacency(v))
            {
                var w = undirectedEdge.Other(v);
                if (marked[w]) continue;
                edgeTo[w] = v;
                Dfs(w);
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
