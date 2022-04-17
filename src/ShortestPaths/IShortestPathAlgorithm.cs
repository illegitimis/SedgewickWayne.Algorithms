
namespace SedgewickWayne.Algorithms
{
    using SedgewickWayne.Algorithms.Graphs;
    using System;
    using System.Collections.Generic;

    public interface IShortestPathAlgorithm<TWeight>
         where TWeight : IComparable<TWeight>
    {
        TWeight DistTo(int v);
        IEnumerable<DirectedEdge<TWeight>> PathTo(int v);
        bool HasPathTo(int v);
    }
}
