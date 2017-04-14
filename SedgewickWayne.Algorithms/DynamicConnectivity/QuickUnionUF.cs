

namespace SedgewickWayne.Algorithms
{
  using System.Runtime.CompilerServices;

  /// <summary>
  /// [lazy approach] avoid doing work until we have to
  /// set of trees(forest)
  /// id array is parent/root of the component tree
  /// Defect: trees can get tall, and find is too expensive
  /// worst: M*N, same as quick find
  /// </summary>
  public class QuickUnionUF : UFBase
  {
    public QuickUnionUF(int N) : base (N) { }


    /// <summary>
    /// keep going until it doesn’t change (algorithm ensures no cycles)
    /// chase parent pointers until reach root (depth of i array accesses)
    /// N worst case
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int Find(int i)
    {
      // id becomes id of parent, loop till the root, moving from child to parent
      while (i != this.id[i])
      {
        i = this.id[i];
      }
      return i;
    }

    /// <summary>
    /// check p and q have same root
    /// </summary>
    /// <param name="p"></param>
    /// <param name="q"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool Connected(int p, int q)
    {
      return this.Find(p) == this.Find(q);
    }

    /// <summary>
    /// set the id of p's root to the id of q's root
    /// (depth of p and q array accesses)
    /// only one value changes
    /// q becomes the root of p
    /// N'- cost of finding roots
    /// </summary>
    /// <param name="p"></param>
    /// <param name="q"></param>
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void Union(int p, int q)
    {
      int pid = this.Find(p);
      int qid = this.Find(q);
      //already connected
      if (pid == qid)
        return;
      
      this.id[pid] = qid;
      this.count--;
    }
   
    
  }

}
