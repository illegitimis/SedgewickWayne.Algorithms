

namespace SedgewickWayne.Algorithms.DynamicConnectivity
{
  using System;


  /// <summary>
  /// Represents the abstract base class for dynamic connectivity problems. 
  /// </summary>
  /// <remarks>
  /// There's no linear time algo for dynamic connectivity [Fredman-Saks].
  /// </remarks>
  public abstract class AbstractUFBase : IUnionFind
  {
    /// <summary>
    /// QU: Array value at index is parent of component with index.
    /// QU: name of another site in the same component
    /// QF: the component identifier for the component containing site p.
    /// </summary>
    protected int[] id;
    public virtual int[] Ids { get { return this.id; } }

    /// <summary>
    /// Number of components.
    /// </summary>
    protected int count;
    public virtual int Count { get { return this.count; } }


    /// <summary>
    /// Initializes union-find data structure with N objects(0 to N–1). Each entry equal to its index / each equal to itself. O(N).
    /// </summary>
    /// <param name="N">Number of objects in the network.</param>

    public AbstractUFBase(int N)
    {
      if (N <= 0) throw new ArgumentException("N > 0");
      this.count = N;
      this.id = new int[N];
      for (int j = 0; j < N; this.id[j] = j++) ;
    }

    /// <summary>
    /// Returns if p and q are in the same component. It's a Reflexive/symmetric/transitive EQUIVALENCE relation.
    /// </summary>
    /// <param name="p">First component index.</param>
    /// <param name="q">Second component index.</param>
    /// <returns>Returns true if objects with indices are in the same connected component.</returns>
    public abstract bool Connected(int p, int q);

    /// <summary>
    /// Adds connection between p and q.
    /// Merges the component containing site <see cref="p"/> with the the component containing site <see cref="q"/>.
    /// </summary>
    /// <param name="p">Integer representing one site.</param>
    /// <param name="q">Integer representing the other site.</param>
    public abstract void Union(int p, int q);

    /// <summary>
    /// Gets the component identifier for <paramref name="i"/> (0 to N – 1).
    /// </summary>
    /// <param name="i">Integer representing one object.</param>
    /// <returns>Component identifier.</returns>
    public abstract int Find(int i);

    /// <summary>
    /// Validates that <see cref="p"/> is a valid index.
    /// </summary>
    /// <param name="p">Integer representing one site.</param>
    protected void Validate(int p)
    {
      if (0 > p || p >= id.Length)
      {
        // IndexOutOfBoundsException
        throw new IndexOutOfRangeException("index " + p + " is not between 0 and " + (count - 1));
      }
    }


  }

}



