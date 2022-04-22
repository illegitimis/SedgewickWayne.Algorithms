namespace SedgewickWayne.Algorithms.UnitTests
{
    using SedgewickWayne.Algorithms.Graphs;
    using Xunit;

    public class ConnectedComponentsTests
    {
        private static readonly UndirectedGraphOfVertices TinyG = GraphBuilder.Tiny();

        [Fact]
        public void Tiny()
        {
            var sut = new CC(TinyG);
            Assert.Equal(3, sut.Count());
            for (int i = 0; i <= 6; i++) { Assert.Equal(0, sut.Id(i)); Assert.True(sut.Connected(0, i)); }
            for (int i = 7; i <= 8; i++) { Assert.Equal(1, sut.Id(i)); Assert.True(sut.Connected(7, i)); }
            for (int i = 9; i <= 12; i++) { Assert.Equal(2, sut.Id(i)); Assert.True(sut.Connected(9, i)); }
        }
    }
}
