

namespace SedgewickWayne.Algorithms
{
  using System;
  using System.Runtime.CompilerServices;


  /// <summary>
  /// WEIGHTED QUICK UNION (WITH PATH COMPRESSION) makes it possible to solve problems that could not otherwise be addressed.
  /// Quick union with path compression. 
  /// Just after computing the root of p, set the id of each examined node to point to that root
  /// Improvement is obvious: we always iterate to the root
  /// weighted QU + path compression: N + M lg* N
  /// QU + path compression: N + M log N
  /// M union find ops, N objects, worst case times above
  /// </summary>
  public class UF : QuickUnionUF
  {
    private byte[] rank;
    public byte[] Ranks { get { return rank; } }
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    public UF(int n) : base (n)
    {
      this.rank = new byte[n];
      for (int j = 0; j < n; this.rank[j] = 0, j++);
    }
  
    /// <summary>
    /// component identifier
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int Find(int i)
    {
      if (i < 0 || i >= id.Length)  throw new ArgumentOutOfRangeException("i");

      // Make every other node in path point to its grandparent(thereby halving path length).
      while (i != this.id[i])
      {
        // only one line of code, keeps tree almost flat
        // sole difference from WeightedQuickUnionUF
        // path compression !
        this.id[i] = this.id[this.id[i]];
        i = this.id[i];
      }
      return i;
    }

    
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void Union(int i1, int i2)
    {
      int num = this.Find(i1);
      int num2 = this.Find(i2);
      if (num == num2) return;

      if (this.rank[num] < this.rank[num2])
      {
        this.id[num] = num2;
      }
      else if (this.rank[num] > this.rank[num2])
      {
        this.id[num2] = num;
      }
      else
      {
        this.id[num2] = num;        
        this.rank[num] ++;
        
      }
      this.count--;
    }   
  
    
    
  }

}
