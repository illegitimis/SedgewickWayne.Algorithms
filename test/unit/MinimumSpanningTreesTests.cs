namespace SedgewickWayne.Algorithms.UnitTests
{
    using SedgewickWayne.Algorithms.Graphs;
    using Xunit;

    public class MinimumSpanningTreesTests
    {
        [Fact]
        public void LazyPrim_Tiny()
        {
            var tinyewg = EdgeWeightedGraphBuilder.Tiny();
            var sut = new LazyPrimMST<double>(tinyewg);
            const double expectedWeight = 1.81d;
            Assert.Equal(expectedWeight, sut.Weight, Constants.DOUBLE_PRECISION_NO_DECIMAL_PLACES);
            var edges = sut.Edges.ToArray();
            Assert.Equal(7, edges.Length);
            Assert.Equal(expectedWeight, edges.Sum(e => e.Weight));
            Assert.Equal(TinyEwgMstEdges, edges);
        }

        private static readonly WeightedEdge<double>[] TinyEwgMstEdges = new WeightedEdge<double>[]
        {
            new (0,7,0.16),
            new (1,7,0.19),
            new (0,2,0.26),
            new (2,3,0.17),
            new (5,7,0.28),
            new (4,5,0.35),
            new (6,2,0.40)
        };
    }
}
