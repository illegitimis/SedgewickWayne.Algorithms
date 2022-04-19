using System;

namespace SedgewickWayne.Algorithms.Graphs
{
    public abstract class AbstractGraphSearch<TInfo> : ISearchGraph
    {
        // find vertices connected to a source vertex s
        protected AbstractGraphSearch(AdjacencyListGraph<TInfo> G, int s)
        {
            S = s;
        }

        public int S { get; }

        public abstract int Count();

        public abstract bool Marked(int v);

        protected void ValidateVertex(int i, int noVertices)
        {
            if (i < 0 || i >= noVertices)
                throw new ArgumentException("vertex " + i + " is not between 0 and " + (noVertices - 1));
        }
    }

}
