

namespace SedgewickWayne.Algorithms
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;



  /******************************************************************************
   *  Compilation:  javac Edge.java
   *  Execution:    java Edge
   *  Dependencies: StdOut.java
   *
   *  Immutable weighted edge.
   *
   ******************************************************************************/

  /**
   *  The {@code Edge} class represents a weighted edge in an 
   *  {@link EdgeWeightedGraph}. Each edge consists of two integers
   *  (naming the two vertices) and a real-value weight. The data type
   *  provides methods for accessing the two endpoints of the edge and
   *  the weight. The natural order for this data type is by
   *  ascending order of weight.
   *  <p>
   <a href="http://algs4.cs.princeton.edu/43mst">Section 4.3</a> of
   
   *
   
  
   */
  //public class Edge implements Comparable<Edge> 
  public class Edge : IComparable<Edge>, IEquatable<Edge>
  {

    private readonly int v;
    private readonly int w;
    private readonly double weight;

    /**
     * Initializes an edge between vertices {@code v} and {@code w} of the given {@code weight}.
     *
     * @param  v one vertex
     * @param  w the other vertex
     * @param  weight the weight of this edge
     * Throws <see cref="ArgumentException" /> if either {@code v} or {@code w} is a negative integer
     * Throws <see cref="ArgumentException" /> if {@code weight} is {@code NaN}
     */
    public Edge (int v, int w, double weight)
    {
      if (v < 0) throw new ArgumentException("vertex index must be a nonnegative integer");
      if (w < 0) throw new ArgumentException("vertex index must be a nonnegative integer");
      if (Double.IsNaN(weight)) throw new ArgumentException("Weight is NaN");
      this.v = v;
      this.w = w;
      this.weight = weight;
    }

    /**
     * Returns the weight of this edge.
     */
    public double Weight { get { return weight; } }


    /**
     * Returns either endpoint of this edge.     
     */
    public int Either { get { return v; } }

    /**
     * Returns the endpoint of this edge that is different from the given vertex.
     *
     * @param  vertex one endpoint of this edge
     * @return the other endpoint of this edge
     * Throws <see cref="ArgumentException" /> if the vertex is not one of the endpoints of this edge
     */
    public int other (int vertex)
    {
      if (vertex == v) return w;
      else if (vertex == w) return v;
      else throw new ArgumentException("Illegal endpoint");
    }

    /**
     * Compares two edges by weight.
     * Note that {@code compareTo()} is not consistent with {@code equals()},
     * which uses the reference equality implementation inherited from {@code Object}.
     *
     * @param  that the other edge
     * @return a negative integer, zero, or positive integer depending on whether
     *         the weight of this is less than, equal to, or greater than the
     *         argument edge
     */
    #region IComparable<Edge> IEquatable<Edge> Members

    public int CompareTo (Edge other)
    {
      return this.Weight.CompareTo(other.Weight);
    }

    // is the weight of edge e strictly less than that of edge f?
    // private static bool less (Edge e, Edge f) { return e.Weight < f.Weight; }
    public static bool operator < (Edge e, Edge edgeLessThan) { return e.Weight < edgeLessThan.Weight; }
    public static bool operator > (Edge e, Edge edgeLessThan) { return e.Weight > edgeLessThan.Weight; }

    public bool Equals (Edge other) { return this.Weight == other.Weight; }
    //public static bool operator == (Edge e, Edge edgeLessThan) { return e.Equals(edgeLessThan); }
    //public static bool operator != (Edge e, Edge edgeLessThan) { return !e.Equals(edgeLessThan); }

    public override bool Equals (object obj)
    {
      if (this == null) return obj == null;
      if (obj is Edge)
        return ((IEquatable<Edge>)this).Equals(obj as IEquatable<Edge>);
      else
        return false;
    }

    public override int GetHashCode ( )
    {
      return this.Weight.GetHashCode();
    }

    #endregion


    /**
     * Returns a string representation of this edge.
     *
     * @return a string representation of this edge
     */
    public override string ToString ( )
    {
      return String.Format("{0}-{1} {2:0.00}", v, w, weight);
    }


  }


}