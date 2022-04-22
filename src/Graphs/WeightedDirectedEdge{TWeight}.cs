namespace SedgewickWayne.Algorithms.Graphs
{
    using System;

    /// <summary>
    /// Weighted edge in an <see cref="EdgeWeightedDigraph"/>.
    /// Each edge consists of two integers (naming the two vertices) and a real-value weight.
    /// </summary>
    /// <typeparam name="TWeight">weighted edge type</typeparam>
    /// <remarks>
    /// Source: <see href="https://algs4.cs.princeton.edu/44sp/DirectedEdge.java.html"/>
    /// </remarks>
    public class WeightedDirectedEdge<TWeight> :
        DirectedEdge,
        IComparable<WeightedDirectedEdge<TWeight>>,
        IEquatable<WeightedDirectedEdge<TWeight>>
        where TWeight : IComparable<TWeight>
    {
        /// <summary>
        /// Returns the weight of this edge.
        /// </summary>
        public TWeight Weight { get; }

        /// <summary>
        /// Initializes an edge between vertices <paramref name="v"/> and <paramref name="w"/>
        /// of the given <paramref name="weight"/>.
        /// </summary>
        /// <param name="v">one vertex</param>
        /// <param name="w">the other vertex</param>
        /// <param name="weight">the weight of this edge</param>
        public WeightedDirectedEdge(int from, int to, TWeight weight) : base(from, to) => Weight = weight;

        /// <summary>
        /// Compares two edges by weight.
        /// not consistent with <see cref="IEquatable{T}"/> implementation
        /// which uses the reference and value tuple / hash code equality
        /// </summary>
        /// <param name="other">the other edge</param>
        /// <returns>
        /// a negative integer, zero, or positive integer depending on whether
        /// the weight of this is less than, equal to, or greater than the argument edge
        /// </returns>
        public int CompareTo(WeightedDirectedEdge<TWeight> other) =>
            (other is null) ? 1 : Weight.CompareTo(other.Weight);


        public static bool operator <(WeightedDirectedEdge<TWeight> left, WeightedDirectedEdge<TWeight> right) => left.CompareTo(right) < 0;

        public static bool operator <=(WeightedDirectedEdge<TWeight> left, WeightedDirectedEdge<TWeight> right) => left.CompareTo(right) <= 0;

        public static bool operator >(WeightedDirectedEdge<TWeight> left, WeightedDirectedEdge<TWeight> right) => left.CompareTo(right) > 0;

        public static bool operator >=(WeightedDirectedEdge<TWeight> left, WeightedDirectedEdge<TWeight> right) => left.CompareTo(right) >= 0;

        /// <summary>
        /// Returns a string representation of this edge.
        /// </summary>
        /// <returns>a string representation of this DirectedEdge</returns>
        public override string ToString() => $"{From}->{To} {Weight:0.00}";

        public override int GetHashCode()
        {
#if NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER
            return HashCode.Combine(From, To, Weight);
#else
            return (From, To, Weight).GetHashCode();
#endif
        }

        public bool Equals(WeightedDirectedEdge<TWeight> other)
        {
            if (other is null) return false;
            return GetHashCode() == other.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return (obj is WeightedDirectedEdge<TWeight> other) && Equals(other);
        }

        public static bool operator ==(WeightedDirectedEdge<TWeight> left, WeightedDirectedEdge<TWeight> right) => (left is null && right is null) || left.Equals(right);
        public static bool operator !=(WeightedDirectedEdge<TWeight> left, WeightedDirectedEdge<TWeight> right) => !(left == right);
    }
}