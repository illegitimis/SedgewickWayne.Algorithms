

namespace SedgewickWayne.Algorithms
{
  using System.Runtime.CompilerServices;

  /// <summary>
  /// eager
  /// Defect: union is too expensive, N array accesses
  /// Trees are flat, too expesnive to keep them flat
  /// </summary>
  public class QuickFindUF : UFBase
  {

    
    [MethodImpl(MethodImplOptions.NoInlining)]
    public QuickFindUF(int N) : base (N) { }

    /// <summary>
    /// Union. To merge components containing p and q, change all entries whose id equals id[p] to id[q].
    /// Defect: union too expensive, O(N)
    /// quadratic, N objects with N union commands, N^2 array accesses
    /// </summary>
    /// <param name="p">first component</param>
    /// <param name="q">second component</param>
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void Union(int p, int q)
    {
      // nothing to do if already connected
      if (this.Connected(p, q))
        return;
      
      int pid = this.id[p];
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
    /// Find: constant, array index O(1)
    /// </summary>
    /// <param name="i">component index</param>
    /// <returns></returns>
    public override int Find(int i)
    {
      return this.id[i];
    }

    /// <summary>
    /// p & q are connected  if they have the same id, id[p] == id[q]
    /// 2 array indices
    /// </summary>
    public override bool Connected(int p, int q)
    {
      return this.id[p] == this.id[q];
    }


  }
}
