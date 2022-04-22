namespace SedgewickWayne.Algorithms.Graphs
{
    /* https://algs4.cs.princeton.edu/42digraph/Digraph.java.html */
    public class Digraph : Digraph<DirectedEdge>
    {
        public Digraph(int numberOfVertices) : base(numberOfVertices) { }

        public void AddEdge(int v, int w) => AddEdge(new DirectedEdge(v, w));
    }
}
