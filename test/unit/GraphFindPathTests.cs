namespace SedgewickWayne.Algorithms.UnitTests
{
    using SedgewickWayne.Algorithms.Graphs;
    using Xunit;

    public class GraphFindPathTests
    {
        private static readonly UndirectedGraphOfVertices TinyCg = GraphBuilder.TinyCg();

        [Fact]
        public void TinyCg0Dfs()
        {
            IFindPath sut = new DepthFirstPaths(TinyCg, 0);
            Assert.Equal(new[] { 0 }, sut.PathTo(0));
            Assert.Equal(new[] { 0,2,1 }, sut.PathTo(1));
            Assert.Equal(new[] { 0,2 }, sut.PathTo(2));
            Assert.Equal(new[] { 0,2,3 }, sut.PathTo(3));
            Assert.Equal(new[] { 0,2,3,4 }, sut.PathTo(4));
            Assert.Equal(new[] { 0,2,3,5 }, sut.PathTo(5));
        }

        [Fact]
        public void TinyCg0Bfs()
        {
            IFindPath sut = new BreadthFirstPaths(TinyCg, 0);
            Assert.Equal(new[] { 0 }, sut.PathTo(0));
            Assert.Equal(new[] { 0, 1 }, sut.PathTo(1));
            Assert.Equal(new[] { 0, 2 }, sut.PathTo(2));
            Assert.Equal(new[] { 0, 2, 3 }, sut.PathTo(3));
            Assert.Equal(new[] { 0, 2, 4 }, sut.PathTo(4));
            Assert.Equal(new[] { 0, 5 }, sut.PathTo(5));
        }
    }
}
