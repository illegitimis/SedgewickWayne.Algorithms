

namespace SedgewickWayne.Algorithms.DynamicConnectivity
{
  using System;
  using System.Runtime.CompilerServices;

  /// <summary>
  /// Represents an eager implementation of find. Approach is to maintain the invariant that p and q are connected if and only if id[p] is equal to id[q].
  /// <para>Defect: union is too expensive, N array accesses.
  /// Trees are flat, too expensive to keep them flat.
  /// There aren't any performance improvements on QF.
  /// </para>
  /// </summary>
  /// <see href="http://algs4.cs.princeton.edu/15uf/QuickFindUF.java"/>
  public sealed class QuickFindUF : AbstractUFBase
  {
    [MethodImpl(MethodImplOptions.NoInlining)]
    public QuickFindUF(int N) : base(N) { }

    /// <summary>
    /// Union. To merge components containing p and q, change all entries whose id equals id[p] to id[q].
    /// Defect: union too expensive, O(N).
    /// When calling union repeatedly for a set of objects becomes quadratic, N objects with N union commands, N^2 array accesses.
    /// Between N + 3 and 2N + 1 array accesses for each call to union() that combines two components.
    /// </summary>
    /// <param name="p">first component</param>
    /// <param name="q">second component</param>
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void Union(int p, int q)
    {
      Validate(p);
      Validate(q);

      // nothing to do if already connected
      // p and q are already in the same component
      if (this.Connected(p, q)) return;

      // needed for correctness
      int pid = this.id[p];

      // to reduce the number of array accesses
      int qid = this.id[q];

      for (int i = 0; i < this.id.Length; i++)
      {
        if (this.id[i] == pid)
        {
          this.id[i] = qid;
        }
      }

      // decrease component count
      this.count--;
    }

    /// <summary>
    /// Find: constant, one array access, array index O(1).
    /// </summary>
    /// <param name="p">component index</param>
    /// <returns>the component identifier for the component containing site p</returns>
    public override int Find(int p)
    {
      Validate(p);
      return id[p];
    }

    /// <summary>
    /// p & q are connected if they have the same id, id[p] == id[q]. Cost is 2 array indices.
    /// </summary>
    public override bool Connected(int p, int q)
    {
      Validate(p);
      Validate(q);
      return this.id[p] == this.id[q];
    }

  }
}
