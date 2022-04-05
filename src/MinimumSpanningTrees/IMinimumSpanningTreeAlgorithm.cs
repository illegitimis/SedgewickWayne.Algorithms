
namespace SedgewickWayne.Algorithms
{
    using SedgewickWayne.Algorithms.Graphs;
    using System;
    using System.Collections.Generic;

    public interface IMinimumSpanningTreeAlgorithm<TWeight>
          where TWeight : IComparable<TWeight>
    {
        IEnumerable<WeightedEdge<TWeight>> Edges { get; }
        TWeight Weight { get; }
    }
}
