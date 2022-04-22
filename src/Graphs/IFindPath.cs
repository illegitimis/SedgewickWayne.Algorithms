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
    }

    internal static class GraphUtility
    {
        public static void ValidateVertex(int i, int noVertices)
        {
            if (i < 0 || i >= noVertices)
                throw new ArgumentException("vertex " + i + " is not between 0 and " + (noVertices - 1));
        }
    }
}
