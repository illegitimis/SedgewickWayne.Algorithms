namespace SedgewickWayne.Algorithms.UnitTests
{
    using SedgewickWayne.Algorithms.Graphs;
    using System;
    using Xunit;
    using static SedgewickWayne.Algorithms.UnitTests.Constants;

    public class MinimumSpanningTreesTests
    {
        [Theory]
        [InlineData("LazyPrimMST")]
        [InlineData("EagerPrimMST")]
        [InlineData("KruskalMST")]
        public void Tiny(string algo)
        {
            var tinyewg = WeightedGraphBuilder.Tiny();
            var sut = Sut(algo, tinyewg);
            Assert.NotNull(sut);
            Assert.Equal(expectedWeight, sut.Weight, THREE_DECIMAL_PLACES_PRECISION);

            var edges = sut.Edges.ToArray();
            Assert.Equal(7, edges.Length);
            Assert.Equal(expectedWeight, edges.Sum(e => e.Weight), THREE_DECIMAL_PLACES_PRECISION);
            Assert.All(TinyEwgMstEdges, expectedEdge => Assert.Contains(expectedEdge, edges));
        }

        private static IMinimumSpanningTreeAlgorithm<double> Sut(string s, WeightedGraph<double> edgeWeightedGraph) => s switch
        {
            "LazyPrimMST" => new LazyPrimMST<double>(edgeWeightedGraph),
            "EagerPrimMST" => new EagerPrimMST<double>(edgeWeightedGraph, double.MaxValue, double.MinValue),
            "KruskalMST" => new KruskalMST<double>(edgeWeightedGraph),
            _ => null
        };

        const double expectedWeight = 1.81d;

        private static readonly WeightedUndirectedEdge<double>[] TinyEwgMstEdges = new WeightedUndirectedEdge<double>[]
        {
            new (0,7,0.16),
            new (2,3,0.17),
            new (1,7,0.19),
            new (0,2,0.26),
            new (5,7,0.28),
            new (4,5,0.35),
            new (6,2,0.40)
        };
    }
}
