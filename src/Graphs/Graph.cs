namespace SedgewickWayne.Algorithms.Graphs
{
    /// <summary>
    /// <see href="https://algs4.cs.princeton.edu/41graph/Graph.java.html"/>
    /// §4.1 Undirected Graphs.
    /// <see href="https://algs4.cs.princeton.edu/41graph" />
    /// </summary>
    public class Graph : Graph<UndirectedEdge>
    {
        public Graph(int numberOfVertices) : base(numberOfVertices)
        {
        }

        public Graph(AdjacencyListGraph<UndirectedEdge> adjacencyListGraph) : base(adjacencyListGraph)
        {
        }

        public Graph(int V, int E) : base(V, E)
        {
        }

        /**
        * @param  v one vertex in the edge
        * @param  w the other vertex in the edge
        * @throws ArgumentException 
        */
        public void AddEdge(int v, int w) => AddEdge(new UndirectedEdge(v, w));
    }
}