namespace SedgewickWayne.Algorithms.UnitTests
{
    using SedgewickWayne.Algorithms.Graphs;
    using SedgewickWayne.Algorithms.ShortestPaths;
    using Xunit;
    using static SedgewickWayne.Algorithms.UnitTests.Constants;

    public class ShortestPathsTests
    {
        IShortestPathAlgorithm<double> _sut;

        /* % java BellmanFordSP tinyEWDn.txt 0  */

        [Fact]
        public void TinyEwdn()
        {
            var tinyewdn = EdgeWeightedDigraphBuilder.Tiny();
            _sut = new BellmanFordSP<double>(tinyewdn, 0, double.MaxValue, 0d);

            /* 0 to 0 (0.00) */
            Assert.Equal(0d, _sut.DistTo(0));

            /* 0 to 1 (0.93)  0->2  0.26   2->7  0.34   7->3  0.39   3->6  0.52   6->4 -1.25   4->5  0.35   5->1  0.32 */
            AssertEqualDistanceToVertex(0.93d, 1);
            Assert.Equal(new[] { e02,e27,e73,e36,e64,e45,e51 }, _sut.PathTo(1));

            /*  0 to 2 (0.26)  0->2  0.26   */
            AssertEqualDistanceToVertex(0.26d, 2);
            Assert.Equal(new[] { e02 }, _sut.PathTo(2));

            /*  0 to 3 (0.99)  0->2  0.26   2->7  0.34   7->3  0.39   */
            AssertEqualDistanceToVertex(0.99d, 3);
            Assert.Equal(new[] { e02,e27,e73 }, _sut.PathTo(3));

            /*  0 to 4 (0.26)  0->2  0.26   2->7  0.34   7->3  0.39   3->6  0.52   6->4 -1.25   */
            AssertEqualDistanceToVertex(0.26d, 4);
            Assert.Equal(new[] { e02,e27,e73,e36,e64 }, _sut.PathTo(4));

            /*  0 to 5 (0.61)  0->2  0.26   2->7  0.34   7->3  0.39   3->6  0.52   6->4 -1.25   4->5  0.35 */
            AssertEqualDistanceToVertex(0.61d, 5);
            Assert.Equal(new[] { e02,e27,e73,e36,e64,e45 }, _sut.PathTo(5));

            /*  0 to 6 (1.51)  0->2  0.26   2->7  0.34   7->3  0.39   3->6  0.52   */
            AssertEqualDistanceToVertex(1.51d, 6);
            Assert.Equal(new[] { e02,e27,e73,e36, }, _sut.PathTo(6));

            /*  0 to 7 (0.60)  0->2  0.26   2->7  0.34   */
            AssertEqualDistanceToVertex(0.6d, 7);
            Assert.Equal(new[] { e02,e27 }, _sut.PathTo(7));
        }

        private void AssertEqualDistanceToVertex(double expected, int vertex) =>
            Assert.Equal(expected, _sut.DistTo(vertex), DOUBLE_PRECISION_NO_DECIMAL_PLACES);

        private static readonly DirectedEdge<double> e02 = new(0, 2, 0.26);
        private static readonly DirectedEdge<double> e27 = new(2, 7, 0.34);
        private static readonly DirectedEdge<double> e36 = new(3, 6, 0.52);
        private static readonly DirectedEdge<double> e45 = new(4, 5, 0.35);
        private static readonly DirectedEdge<double> e51 = new(5, 1, 0.32);
        private static readonly DirectedEdge<double> e64 = new(6, 4, -1.25);
        private static readonly DirectedEdge<double> e73 = new(7, 3, 0.39);
    }
}
