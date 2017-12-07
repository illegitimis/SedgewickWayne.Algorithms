
namespace SedgewickWayne.Algorithms.DynamicConnectivity
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Runtime.CompilerServices;
  using System.Text;

  /// <summary>
  /// weighted quick union by size (without path compression).
  /// </summary>
  /// <remarks>
  /// Find. Identical to quick-union. 
  /// connected: proportional to depths of p and q
  /// </remarks>
  /// <see href="https://algs4.cs.princeton.edu/15uf/WeightedQuickUnionUF.java.html"/>
  public class WeightedQuickUnionUF : QuickUnionUF
  {
    [MethodImpl(MethodImplOptions.NoInlining)]
    public WeightedQuickUnionUF(int N) : base(N)
    {
      this.size = new int[N];
      for (int j = 0; j < N; j++) this.size[j] = 1;
    }

    // size[i] = number of sites in tree rooted at i
    // Note: not necessarily correct if i is not a root node
    // The size of a tree is its number of nodes. 
    // The depth of a node in a tree is the number of links on the path from it to the root. 
    // The height of a tree is the maximum depth among its nodes. 
    protected int[] size;

    public int[] Sizes { get { return size; } }

    /// <summary>
    /// Weighted quick-union (without path compression)
    /// </summary>
    /// <remarks>
    /// Depth of any node x is at most lg N. 
    /// lg = base-2 logarithm 
    /// merge smth smaller into smth larger, size at most doubles, depth++
    /// Even if Find the same with QU, becomes lgN from weighting 
    /// modify QU to avoid tall trees 
    /// always avoid putting the larger tree lower
    /// balance by linking root of smaller tree to root of taller tree
    /// average distance to the root much smaller than not weighted  
    /// weighted QU: N + M log N
    /// worst case for N objects and M unions
    /// WQU by size
    /// </remarks>
    /// <param name="p">integer representing one site</param>
    /// <param name="q">the integer representing the other site</param>
    public override void Union(int p, int q)
    {
      int rootP = Find(p);
      int rootQ = Find(q);
      if (rootP == rootQ) return;

      // make smaller root point to larger one
      if (size[rootP] < size[rootQ])
      {
        id[rootP] = rootQ;
        size[rootQ] += size[rootP];
      }
      else
      {
        id[rootQ] = rootP;
        size[rootP] += size[rootQ];
      }
      count--;
    }
  }
}
