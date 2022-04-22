namespace SedgewickWayne.Algorithms.Graphs
{
    public class DirectedEdge : AbstractEdge
    {
        public DirectedEdge(int v, int w) : base(v, w)
        {
        }

        /// <summary>
        /// Returns the tail vertex of the directed edge.
        /// </summary>
        public int From => V;

        /// <summary>
        /// Returns the head vertex of the directed edge.
        /// </summary>
        public int To => W;

        public override string ToString() => $"{From}->{To}";
    }
}