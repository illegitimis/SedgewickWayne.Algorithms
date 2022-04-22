﻿namespace SedgewickWayne.Algorithms.Graphs
{
    /// <summary>
    /// <see cref="https://algs4.cs.princeton.edu/41graph/DepthFirstSearch.java.html"/>
    /// Run depth first search on an undirected graph.
    /// Runs in O(E + V) time.
    /// </summary>
    /// <typeparam name="TInfo"></typeparam>
    public class Dfs : AbstractGraphSearch
    {
        private readonly bool[] marked;    // marked[v] = is there an s-v path?
        private int count;           // number of vertices connected to s

        public Dfs(Graph G, int s) : base(G, s)
        {
            marked = new bool[G.V];
            ValidateVertex(s, G.V);
            DepthFirstSearch(G, s);
        }

        public override int Count() => count;

        public override bool Marked(int v) => marked[v];

        // depth first search from v
        private void DepthFirstSearch(Graph G, int v)
        {
            count++;
            marked[v] = true;
            foreach (var undirectedEdge in G.Adjacency(v))
            {
                var w = undirectedEdge.Other(v);
                if (marked[w]) continue;
                DepthFirstSearch(G, w);
            }
        }
    }

}
