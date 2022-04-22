using System;

namespace SedgewickWayne.Algorithms.Graphs
{
    public abstract class AbstractEdge
    {
        /// <summary>
        /// first vertex
        /// </summary>
        protected int V { get; }

        /// <summary>
        /// second vertex
        /// </summary>
        protected int W { get; }

        protected AbstractEdge(int v, int w)
        {
            if (v < 0) ThrowArgumentException(nameof(v), v);
            if (w < 0) ThrowArgumentException(nameof(w), w);
            // if (Double.IsNaN(weight)) throw new ArgumentException("Weight is NaN");
            V = v;
            W = w;
        }

        private static void ThrowArgumentException(string param, int idx) =>
            throw new ArgumentException($"vertex index {idx} must be a non-negative integer", param);
    }
}