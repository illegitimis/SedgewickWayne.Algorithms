namespace SedgewickWayne.Algorithms.Graphs
{
    using static SedgewickWayne.Algorithms.Graphs.GraphUtility;

    public interface IConnectedComponents<TInfo>
    {
        AdjacencyListGraph<TInfo> G { get; }

        /// <summary>
        /// are v and w connected?
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        bool Connected(int v, int w);

        /// <summary>
        /// number of connected components
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// component identifier for v(between 0 and count()-1 )
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        int Id(int v);
    }

    /// <summary>
    /// This implementation uses a recursive DFS.
    /// <see cref="https://algs4.cs.princeton.edu/41graph/CC.java.html"/>
    /// </summary>
    /// <typeparam name="TInfo"></typeparam>
    public class CC : IConnectedComponents<int>
    {
        private readonly AdjacencyListGraph<int> g;
        private bool[] marked;   // marked[v] = has vertex v been marked?
        private int[] id;           // id[v] = id of connected component containing v
        private int[] size;         // size[id] = number of vertices in given component
        private int count;          // number of connected components

        public CC(AdjacencyListGraph<int> g)
        {
            this.g = g;
            marked = new bool[g.V];
            id = new int[g.V];
            size = new int[g.V];

            for (int v = 0; v < g.V; v++)
            {
                if (marked[v]) continue;
                Dfs(v);
                count++;
            }
        }

        private void Dfs(int v)
        {
            marked[v] = true;
            id[v] = count;
            size[count]++;

            foreach (var w in g.Adjacency(v))
            {
                if (marked[w]) continue;
                Dfs(w);
                // count++;
            }
        }

        public AdjacencyListGraph<int> G => g;

        public bool Connected(int v, int w)
        {
            ValidateVertex(v, g.V);
            ValidateVertex(w, g.V);
            return id[v] == id[w];
        }

        public int Count() => count;

        public int Id(int v)
        {
            ValidateVertex(v, g.V);
            return id[v];
        }
    }
}
