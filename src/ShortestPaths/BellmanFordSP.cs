using SedgewickWayne.Algorithms.Graphs;
using System;
using System.Collections.Generic;
using IntQueue = SedgewickWayne.Algorithms.Queue<int>;

namespace SedgewickWayne.Algorithms.ShortestPaths
{
    /// <summary>
    /// Bellman-Ford shortest path algorithm.
    /// </summary>
    /// <typeparam name="TWeight"></typeparam>
    public class BellmanFordSP<TWeight> :
        IShortestPathAlgorithm<TWeight>
        where TWeight : IComparable<TWeight>
    {
        private readonly TWeight[] distTo;               // distTo[v] = distance  of shortest s->v path
        private readonly DirectedEdge<TWeight>[] edgeTo;         // edgeTo[v] = last edge on shortest s->v path
        private readonly bool[] onQueue;             // onQueue[v] = is v currently on the queue?
        private readonly IntQueue queue;          // queue of vertices to relax
        private int cost;                      // number of calls to relax()
        private readonly IEnumerable<DirectedEdge<TWeight>> cycle = null;  // negative cycle (or null if no such cycle)
        private readonly TWeight positiveInfinity;

        /// <summary>
        /// Computes the shortest path tree from <paramref name="s"/>,
        /// or finds a negative cost cycle reachable from <paramref name="s"/>.
        /// </summary>
        /// <param name="G">edge-weighted digraph G</param>
        /// <param name="s">vertex s</param>
        /// <param name="initialMaxValue">positive infinity</param>
        /// <param name="zero">smallest non-negative value of <typeparamref name="TWeight"/></param>
        public BellmanFordSP(EdgeWeightedDigraph<TWeight> G, int s, TWeight initialMaxValue, TWeight zero)
        {
            distTo = new TWeight[G.V];
            edgeTo = new DirectedEdge<TWeight>[G.V];
            onQueue = new bool[G.V];
            for (int v = 0; v < G.V; v++) distTo[v] = initialMaxValue;
            distTo[s] = zero;
            positiveInfinity = initialMaxValue;

            // Bellman-Ford algorithm
            queue = new IntQueue();
            queue.Enqueue(s);
            onQueue[s] = true;
            while (!queue.IsEmpty && !HasNegativeCycle())
            {
                int v = queue.Dequeue();
                onQueue[v] = false;
                Relax(G, v);
            }

            // assert check(G, s);
        }

        public TWeight DistTo(int v)
        {
            ValidateVertex(v);
            return distTo[v];
        }

        /**
     * Returns a shortest path from the source {@code s} to vertex {@code v}.
     * @param  v the destination vertex
     * @return a shortest path from the source {@code s} to vertex {@code v}
     *         as an iterable of edges, and {@code null} if no such path
     * @throws UnsupportedOperationException if there is a negative cost cycle reachable
     *         from the source vertex {@code s}
     * @throws IllegalArgumentException unless {@code 0 <= v < V}
     */
        public IEnumerable<DirectedEdge<TWeight>> PathTo(int v)
        {
            ValidateVertex(v);
            // if (!hasPathTo(v)) return null;
            // foreach(var edge in edgeTo)
            var stack = new Stack<DirectedEdge<TWeight>>();
            var edge = edgeTo[v];
            while(edge != null)
            {
                stack.Push(edge);
                // yield return edge;
                var from = edge.From;
                edge = edgeTo[from];
            }
            return stack;
        }

        public bool HasPathTo(int v)
        {
            ValidateVertex(v);
            return distTo[v].CompareTo(positiveInfinity) < 0;
        }

        // relax vertex v and put other endpoints on queue if changed
        private void Relax(EdgeWeightedDigraph<TWeight> g, int v)
        {
            foreach (var edge in g.Adjacency(v))
            {
                int w = edge.To;
                // if (distTo[w] > distTo[v] + edge.Weight)
                var currentWeight = GenericOperators<TWeight>.Add(distTo[v], edge.Weight);
                if (currentWeight.CompareTo(distTo[w]) < 0)
                {
                    distTo[w] = currentWeight;
                    edgeTo[w] = edge;
                    if (!onQueue[w])
                    {
                        queue.Enqueue(w);
                        onQueue[w] = true;
                    }
                }
                if (++cost % g.V == 0)
                {
                    FindNegativeCycle();
                    if (HasNegativeCycle()) return;  // found a negative cycle
                }
            }
        }

        private bool HasNegativeCycle() => cycle != null;

        // by finding a cycle in predecessor graph
        private void FindNegativeCycle()
        {
#if TODO
            int V = edgeTo.Length;
            var spt = new EdgeWeightedDigraph<TWeight>(V);
            for (int v = 0; v < V; v++)
                if (edgeTo[v] != null)
                    spt.AddEdge(edgeTo[v]);

            EdgeWeightedDirectedCycle finder = new EdgeWeightedDirectedCycle(spt);
            cycle = finder.cycle();
#else
#endif
        }

        private void ValidateVertex(int i)
        {
            var V = distTo.Length;
            if (i < 0 || i >= V)
                throw new ArgumentException("vertex " + i + " is not between 0 and " + (V - 1));
            if (HasNegativeCycle())
                throw new NotSupportedException("Negative cost cycle exists");
        }
    }
}
