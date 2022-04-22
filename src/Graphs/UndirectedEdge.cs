namespace SedgewickWayne.Algorithms.Graphs
{
    using System;

    public class UndirectedEdge : AbstractEdge
    {
        public UndirectedEdge(int v, int w) : base(v, w)
        {
        }

        /// <summary>
        ///  Returns either endpoint of this edge.
        /// </summary>
        public int Either() => V;

        /// <summary>
        /// Returns the endpoint of this edge that is different from the given vertex.
        /// </summary>
        /// <param name="vertex"one endpoint of this edge></param>
        /// <returns>the other endpoint of this WeightedEdge</returns>
        /// <exception cref="ArgumentException">
        /// if the vertex is not one of the endpoints of this edge
        /// </exception>
        public int Other(int vertex)
        {
            if (vertex == V) return W;
            else if (vertex == W) return V;
            else throw new ArgumentException("Illegal endpoint");
        }

        public override string ToString() => $"{V}-{W}";
    }
}