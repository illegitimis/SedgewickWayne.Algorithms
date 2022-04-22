using System.Collections.Generic;

namespace SedgewickWayne.Algorithms.Graphs
{
    public class Digraph<TDirectedEdge> : AdjacencyListGraph<TDirectedEdge>
        where TDirectedEdge : DirectedEdge
    {
        // indegree[v] = indegree of vertex v
        private readonly int[] _indegree;

        public Digraph(int numberOfVertices) : base(numberOfVertices) => _indegree = new int[V];

        public void AddEdge(TDirectedEdge edge)
        {
            ValidateVertex(edge.From);
            ValidateVertex(edge.To);
            _adjacencyList[edge.From].Add(edge);
            _indegree[edge.To]++;
            E++;
        }

        public int OutDegree(int v)
        {
            ValidateVertex(v);
            return _adjacencyList[v].Size;
        }

        public int InDegree(int v)
        {
            ValidateVertex(v);
            return _indegree[v];
        }

        /// <summary>
        /// all directed edges in this edge-weighted digraph.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TDirectedEdge> Edges()
        {
            for (int v = 0; v < V; v++)
            {
                foreach (var edge in Adjacency(v))
                {
                    if (edge is null) continue;
                    yield return edge;
                }
            }
        }
    }
}
