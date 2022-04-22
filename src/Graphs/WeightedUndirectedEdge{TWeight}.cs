namespace SedgewickWayne.Algorithms.Graphs
{
    using System;

    /// <summary>
    /// Immutable Weighted edge in an <see cref="EdgeWeightedGraph"/>.
    /// Each edge consists of two integers (naming the two vertices) and a real-value weight.
    /// </summary>
    /// <typeparam name="TWeight">weighted edge type</typeparam>
    /// <remarks>
    /// Source: <see href="https://algs4.cs.princeton.edu/43mst/Edge.java.html"/>
    /// The data type provides methods for accessing the two endpoints of the edge and the weight.
    /// The natural order for this data type is by ascending order of weight.
    /// </remarks>
    public class WeightedUndirectedEdge<TWeight> :
        UndirectedEdge,
        IComparable<WeightedUndirectedEdge<TWeight>>,
        IEquatable<WeightedUndirectedEdge<TWeight>>
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
        /// <param name="weight">the weight of this WeightedEdge</param>
        public WeightedUndirectedEdge(int v, int w, TWeight weight) : base(v, w) => Weight = weight;


        /// <summary>
        /// Compares two edges by weight.
        /// not consistent with <see cref="IEquatable{T}"/> implementation
        /// which uses the reference and value tuple / hash code equality
        /// </summary>
        /// <param name="other">the other WeightedEdge</param>
        /// <returns>
        /// a negative integer, zero, or positive integer depending on whether
        /// the weight of this is less than, equal to, or greater than the argument edge
        /// </returns>
        public int CompareTo(WeightedUndirectedEdge<TWeight> other) =>
            (other is null) ? 1 : Weight.CompareTo(other.Weight);


        public static bool operator <(WeightedUndirectedEdge<TWeight> left, WeightedUndirectedEdge<TWeight> right) => left.CompareTo(right) < 0;

        public static bool operator <=(WeightedUndirectedEdge<TWeight> left, WeightedUndirectedEdge<TWeight> right) => left.CompareTo(right) <= 0;

        public static bool operator >(WeightedUndirectedEdge<TWeight> left, WeightedUndirectedEdge<TWeight> right) => left.CompareTo(right) > 0;

        public static bool operator >=(WeightedUndirectedEdge<TWeight> left, WeightedUndirectedEdge<TWeight> right) => left.CompareTo(right) >= 0;

        /// <summary>
        /// Returns a string representation of this edge.
        /// </summary>
        /// <returns>a string representation of this WeightedEdge</returns>
        public override string ToString() => $"{V}-{W} {Weight:0.00}";

        public override int GetHashCode()
        {
#if NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER
            return HashCode.Combine(V, W, Weight);
#else
            return (V,W,Weight).GetHashCode();
#endif
        }

        public bool Equals(WeightedUndirectedEdge<TWeight> other)
        {
            if (other is null) return false;
            return GetHashCode() == other.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if(obj is null) return false;
            if(ReferenceEquals(this, obj)) return true;
            return (obj is WeightedUndirectedEdge<TWeight> other) && Equals(other);
        }

        public static bool operator == (WeightedUndirectedEdge<TWeight> left, WeightedUndirectedEdge<TWeight> right) => left.Equals(right);
        public static bool operator != (WeightedUndirectedEdge<TWeight> left, WeightedUndirectedEdge<TWeight> right) => !left.Equals(right);
    }
}