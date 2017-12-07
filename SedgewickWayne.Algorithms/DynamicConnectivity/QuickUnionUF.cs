

namespace SedgewickWayne.Algorithms.DynamicConnectivity
{
  using System;
  using System.Runtime.CompilerServices;

  /// <summary>
  /// [lazy approach] avoid doing work until we have to set of trees(forest).
  /// id array is parent/root of the component tree
  /// Defect: trees can get tall, and find is too expensive
  /// worst: M*N, same as quick find
  /// our id[] array is a parent-link representation of a forest(set) of trees.
  /// </summary>
  /// <see href="https://algs4.cs.princeton.edu/15uf/QuickUnionUF.java.html"/>
  public class QuickUnionUF : AbstractUFBase
  {
    public QuickUnionUF(int N) : base (N) { }

    /// <summary>
    /// Returns true if the the two sites are in the same component.
    /// Check p and q have same root.
    /// </summary>
    /// <param name="p">the integer representing one site</param>
    /// <param name="q">the integer representing the other site</param>
    /// <returns>
    /// true if the two sites are in the same component; false otherwise
    /// </returns>
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool Connected(int p, int q)
    {
      return this.Find(p) == this.Find(q);
    }

    /// <summary>
    /// return the component identifier for the component containing site <see cref="p"/>.
    /// id becomes id of parent, loop till the root, moving from child to parent
    /// </summary>
    /// <param name="p">integer representing one object</param>
    /// <returns>component identifier</returns>>
    public override int Find(int p)
    {
      Validate(p);
      while (p != id[p]) p = id[p];
      return p;
    }

    /// <summary>
    /// Merges the component containing site <paramref name="p"/> with the the 
    /// component containing site <paramref name="q"/>.
    /// </summary>
    /// <param name="p">integer representing one site</param>
    /// <param name="q">integer representing the other site</param>
    public override void Union(int p, int q)
    {
      int rootP = Find(p);
      int rootQ = Find(q);

      //already connected
      if (rootP == rootQ) return;

      id[rootP] = rootQ;
      count--;
    }
  }
}
