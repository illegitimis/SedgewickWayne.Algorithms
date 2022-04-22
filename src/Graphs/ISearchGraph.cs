using System;

namespace SedgewickWayne.Algorithms.Graphs
{
    public interface ISearchGraph
    {
        /// <summary>
        /// is v connected to s?
        /// </summary>
        /// <param name="v">second vertex</param>
        bool Marked(int v);

        /// <summary>
        ///  how many vertices are connected to s?
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// reference vertex (from / either)
        /// </summary>
        int S { get; }
    }

    /// <summary>
    /// find vertices connected to a source vertex s
    /// </summary>
    /// <typeparam name="TInfo"></typeparam>
    public abstract class AbstractGraphSearch<TUndirectedEdge> : ISearchGraph
        where TUndirectedEdge : UndirectedEdge
    {
        protected AbstractGraphSearch(Graph<TUndirectedEdge> G, int s) => S = s;

        public int S { get; }

        public abstract int Count();

        public abstract bool Marked(int v);

        protected void ValidateVertex(int i, int noVertices)
        {
            if (i < 0 || i >= noVertices)
                throw new ArgumentException("vertex " + i + " is not between 0 and " + (noVertices - 1));
        }
    }

    public abstract class AbstractGraphSearch : AbstractGraphSearch<UndirectedEdge>
    {
        protected AbstractGraphSearch(Graph G, int s) : base(G, s)
        {
        }
    }
}
