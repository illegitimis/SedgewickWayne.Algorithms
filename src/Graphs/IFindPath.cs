using System;
using System.Collections.Generic;
using System.Linq;

namespace SedgewickWayne.Algorithms.Graphs
{
    /// <summary>
    /// find paths in G from source s
    /// </summary>
    public interface IFindPath
    {
        // Paths(Graph G, int s)

        /// <summary>
        /// is there a path from s to v?
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        bool HasPathTo(int v);

        /// <summary>
        /// path from s to v; null if no such path
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        IEnumerable<int> PathTo(int v);
    }


    public abstract class AbstractFindPath<TInfo> : IFindPath
    {
        protected AbstractFindPath(AdjacencyListGraph<TInfo> G, int s) => S = s;

        /// <summary>
        /// source vertex
        /// </summary>
        public int S { get; }

        public abstract bool HasPathTo(int v);

        public abstract IEnumerable<int> PathTo(int v);

        protected void ValidateVertex(int i, int noVertices)
        {
            if (i < 0 || i >= noVertices)
                throw new ArgumentException("vertex " + i + " is not between 0 and " + (noVertices - 1));
        }
    }

    // https://algs4.cs.princeton.edu/41graph/DepthFirstPaths.java.html
    public class DepthFirstPaths : AbstractFindPath<int>
    {
        private bool[] marked;    // marked[v] = is there an s-v path?
        private int[] edgeTo;     // edgeTo[v] = last edge on s-v path
        AdjacencyListGraph<int> g;

        public DepthFirstPaths(AdjacencyListGraph<int> G, int s) : base(G, s)
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
            foreach(var w in g.Adjacency(v))
            {
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
