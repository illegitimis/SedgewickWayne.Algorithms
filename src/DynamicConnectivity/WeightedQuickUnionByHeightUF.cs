

namespace SedgewickWayne.Algorithms.DynamicConnectivity
{
 
  /// <summary>
  /// Weighted quick-union by height (instead of by size).
  /// WeightedQuickUnionByHeightUF FIND is QUFind
  /// </summary>
  /// <see href="https://algs4.cs.princeton.edu/15uf/WeightedQuickUnionByHeightUF.java.html"/>
  public sealed class WeightedQuickUnionByHeightUF : QuickUnionUF
  {
    // height[i] = height of subtree rooted at i
    private int[] height;

    public int[] Heights { get { return height; } }

    public WeightedQuickUnionByHeightUF(int N) : base(N)
    {
      this.height = new int[N];
      for (int j = 0; j < N; j++) this.height[j] = 0;
    }

    public override void Union(int p, int q)
    {
      int i = Find(p);
      int j = Find(q);
      if (i == j) return;

      // make shorter root point to taller one
      if (height[i] < height[j]) id[i] = j;
      else if (height[i] > height[j]) id[j] = i;
      else
      {
        id[j] = i;
        height[i]++;
      }
      count--;
    }

  }
}
