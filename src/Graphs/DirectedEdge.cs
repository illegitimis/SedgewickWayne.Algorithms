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
    public class DirectedEdge<TWeight> :
        IComparable<DirectedEdge<TWeight>>,
        IEquatable<DirectedEdge<TWeight>>
        where TWeight : IComparable<TWeight>
    {
        /// <summary>
        /// Returns the tail vertex of the directed edge.
        /// </summary>
        public int From { get; }

        /// <summary>
        /// Returns the head vertex of the directed edge.
        /// </summary>
        public int To { get; }

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
        public DirectedEdge(int from, int to, TWeight weight)
        {
            if (from < 0) ThrowArgumentException(nameof(from), from);
            if (to < 0) ThrowArgumentException(nameof(to), to);
            // if (Double.IsNaN(weight)) throw new ArgumentException("Weight is NaN");
            From = from;
            To = to;
            Weight = weight;
        }

        private static void ThrowArgumentException(string param, int idx) =>
            throw new ArgumentException($"vertex index {idx} must be a non-negative integer", param);

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
        public int CompareTo(DirectedEdge<TWeight> other) =>
            (other is null) ? 1 : Weight.CompareTo(other.Weight);


        public static bool operator <(DirectedEdge<TWeight> left, DirectedEdge<TWeight> right) => left.CompareTo(right) < 0;

        public static bool operator <=(DirectedEdge<TWeight> left, DirectedEdge<TWeight> right) => left.CompareTo(right) <= 0;

        public static bool operator >(DirectedEdge<TWeight> left, DirectedEdge<TWeight> right) => left.CompareTo(right) > 0;

        public static bool operator >=(DirectedEdge<TWeight> left, DirectedEdge<TWeight> right) => left.CompareTo(right) >= 0;

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

        public bool Equals(DirectedEdge<TWeight> other)
        {
            if (other is null) return false;
            return GetHashCode() == other.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return (obj is DirectedEdge<TWeight> other) && Equals(other);
        }

        public static bool operator ==(DirectedEdge<TWeight> left, DirectedEdge<TWeight> right) => (left is null && right is null) || left.Equals(right);
        public static bool operator !=(DirectedEdge<TWeight> left, DirectedEdge<TWeight> right) => !(left == right);
    }
}