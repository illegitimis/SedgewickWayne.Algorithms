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
    public class WeightedEdge<TWeight> :
        IComparable<WeightedEdge<TWeight>>,
        IEquatable<WeightedEdge<TWeight>>
        where TWeight : IComparable<TWeight>
    {
        public int V { get; }
        /// <summary>
        /// 
        /// </summary>
        public int W { get; }
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
        public WeightedEdge(int v, int w, TWeight weight)
        {
            if (v < 0) ThrowArgumentException(nameof(v), v);
            if (w < 0) ThrowArgumentException(nameof(w), w);
            // if (Double.IsNaN(weight)) throw new ArgumentException("Weight is NaN");
            V = v;
            W = w;
            Weight = weight;
        }

        private static void ThrowArgumentException(string param, int idx) =>
            throw new ArgumentException($"vertex index {idx} must be a non-negative integer", param);

        /// <summary>
        ///  Returns either endpoint of this edge.
        /// </summary>
        /// <returns>either endpoint of this WeightedEdge</returns>
        public int Either() => V;

        /// <summary>
        /// Returns the endpoint of this edge that is different from the given vertex.
        /// </summary>
        /// <param name="vertex"one endpoint of this edge></param>
        /// <returns>the other endpoint of this WeightedEdge</returns>
        /// <exception cref="ArgumentException">
        /// if the vertex is not one of the endpoints of this edge
        /// </exception>
        public int Other(int vertex)
        {
            if (vertex == V) return W;
            else if (vertex == W) return V;
            else throw new ArgumentException("Illegal endpoint");
        }

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
        public int CompareTo(WeightedEdge<TWeight> other) =>
            (other is null) ? 1 : Weight.CompareTo(other.Weight);


        public static bool operator <(WeightedEdge<TWeight> left, WeightedEdge<TWeight> right) => left.CompareTo(right) < 0;

        public static bool operator <=(WeightedEdge<TWeight> left, WeightedEdge<TWeight> right) => left.CompareTo(right) <= 0;

        public static bool operator >(WeightedEdge<TWeight> left, WeightedEdge<TWeight> right) => left.CompareTo(right) > 0;

        public static bool operator >=(WeightedEdge<TWeight> left, WeightedEdge<TWeight> right) => left.CompareTo(right) >= 0;

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

        public bool Equals(WeightedEdge<TWeight> other)
        {
            if (other is null) return false;
            return GetHashCode() == other.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if(obj is null) return false;
            if(ReferenceEquals(this, obj)) return true;
            return (obj is WeightedEdge<TWeight> other) && Equals(other);
        }

        public static bool operator == (WeightedEdge<TWeight> left, WeightedEdge<TWeight> right) => left.Equals(right);
        public static bool operator != (WeightedEdge<TWeight> left, WeightedEdge<TWeight> right) => !left.Equals(right);
    }
}