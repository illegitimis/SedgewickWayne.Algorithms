
namespace SedgewickWayne.Algorithms
{
  using System.Runtime.CompilerServices;

  /// <summary>
  /// modify QU to avoid tall trees 
  /// always avoid putting the larger tree lower
  /// balance by linking root of smaller tree to root of taller tree
  /// average distance to the root much smaller than not weighted
  /// Find. Identical to quick-union. 
  /// connected: proportional to depths of p and q
  /// weighted QU: N + M log N
  /// worst case for N objects and M unions
  /// </summary>
  public class WeightedQuickUnionUF : QuickUnionUF
  {
    /// <summary>
    /// number of items in component with tree rooted at i
    /// </summary>
    protected int[] sz;
    public int[] Sizes { get { return sz; } }
        
    [MethodImpl(MethodImplOptions.NoInlining)]
    public WeightedQuickUnionUF(int N) : base (N)
    {
      this.sz = new int[N];
      for (int j = 0; j < N; this.sz[j++] = 1);
    }
    
       
    /// <summary>
    /// Depth of any node x is at most lg N. lg = base-2 logarithm 
    /// merge smth smaller into smth larger, size at most doubles, depth++
    /// Even if Find the same with QU, becomes lgN from weighting
    /// </summary>
    /// <param name="p"></param>
    /// <param name="q"></param>
    [MethodImpl(MethodImplOptions.NoInlining)]    
    public override void Union(int p, int q)
    {
      int i = Find(p);
      int j = Find(q);
      if (i == j)  return;
      
      if (this.sz[i] < this.sz[j])
      {
        this.id[i] = j;        
        this.sz[j] += this.sz[i];
      }
      else
      {
        this.id[j] = i;        
        this.sz[i] += this.sz[j];
      }
      this.count--;
    }   
    
    
  }

}
