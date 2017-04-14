

namespace SedgewickWayne.Algorithms
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Runtime.CompilerServices;
  using System.Text;

  /// <summary>
  /// there's no linear time algo for dynamic connectivity
  /// [Fredman-Saks]
  /// </summary>
  public abstract class UFBase
  {

    protected int[] id;
    public virtual int[] Ids { get { return this.id; } }

    /// <summary>
    /// number of components
    /// </summary>
    protected int count;
    public virtual int Count { get { return this.count; } }


    /// <summary>
    /// initialize union-find data structure with N objects(0 to N – 1)
    /// each entry equal to its index / each equal to itself. O(N)
    /// </summary>
    /// <param name="N"></param>
    [MethodImpl(MethodImplOptions.NoInlining)]
    public UFBase(int N)
    {
      if (N <= 0) throw new ArgumentException("N > 0");
      this.count = N;
      this.id = new int[N];
      for (int j = 0; j < N; this.id[j] = j++);
    }



    /// <summary>
    /// are p and q in the same component?
    /// Reflexive/symmetric/transitive EQUIVALENCE relation
    /// </summary>
    /// <param name="p">first component index</param>
    /// <param name="q">second component index</param>
    /// <returns>Returns true if objects with indices are in the same connected component</returns>
    public abstract bool Connected(int p, int q);

    /// <summary>
    /// add connection between p and q
    /// </summary>
    /// <param name="i1"></param>
    /// <param name="i2"></param>
    public abstract void Union(int i1, int i2);

    /// <summary>
    /// component identifier for p(0 to N – 1)
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public abstract int Find(int i);
  }
}
