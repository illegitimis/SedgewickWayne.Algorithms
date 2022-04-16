
namespace SedgewickWayne.Algorithms
{
    using SedgewickWayne.Algorithms.Graphs;
    using System;
    using System.Collections.Generic;

    public interface IMinimumSpanningTreeAlgorithm<TWeight>
          where TWeight : IComparable<TWeight>
    {
        /// <summary>
        /// Returns the edges in a minimum spanning tree (or forest).
        /// </summary>
        IEnumerable<WeightedEdge<TWeight>> Edges { get; }

        /// <summary>
        /// weight of a minimum spanning tree
        /// </summary>
        TWeight Weight { get; }
    }
}
