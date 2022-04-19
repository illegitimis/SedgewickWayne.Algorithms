namespace SedgewickWayne.Algorithms.UnitTests
{
    using SedgewickWayne.Algorithms.Graphs;
    using Xunit;

    public class GraphSearchTests
    {
        private static readonly UndirectedGraphOfVertices TinyG = GraphBuilder.Tiny();

        [Fact]
        public void TinyG0() => Internal(0, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 7, 8, 9, 10, 11, 12 });

        [Fact]
        public void TinyG9() => Internal(9, new int[] { 10, 11, 12 }, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 });

        private static void Internal(int v, int[] connected, int[] notConnected)
        {
            ISearchGraph sut = new Dfs(TinyG, v);
            Assert.Equal(v, sut.S);
            foreach (int i in connected) Assert.True(sut.Marked(i));
            foreach (int i in notConnected) Assert.False(sut.Marked(i));
            Assert.Equal(1 + connected.Length, sut.Count());
        }
    }
}
