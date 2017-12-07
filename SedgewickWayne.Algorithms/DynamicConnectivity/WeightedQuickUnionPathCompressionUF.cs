
namespace SedgewickWayne.Algorithms.DynamicConnectivity
{
  /// <summary>
  /// WeightedQuickUnionPathCompressionUF.java.
  /// The amortized cost per operation for this algorithm is known to be bounded 
  /// by a function known as the inverse Ackermann function and is less than 5 
  /// for any conceivable value of N that arises in practice. 
  /// Quick-union with path compression (but no weighting by size or rank)
  /// has the same <see cref="Find(int)"/> implementation.
  /// </summary>
  /// <see href="https://algs4.cs.princeton.edu/15uf/WeightedQuickUnionPathCompressionUF.java.html"/>
  /// <see href="https://algs4.cs.princeton.edu/15uf/QuickUnionPathCompressionUF.java.html"/>

  public sealed class WeightedQuickUnionPathCompressionUF : WeightedQuickUnionUF
  {
    public WeightedQuickUnionPathCompressionUF(int N) : base(N)
    {
    }

    /// <summary>
    /// FIND with path compression (the while is the only difference)
    /// </summary>
    /// <param name="p">integer representing one site</param>
    public override int Find(int p)
    {
      int root = p;
      while (root != id[root]) root = id[root];

      while (p != root)
      {
        int newp = id[p];
        id[p] = root;
        p = newp;
      }

      return root;
    }

  }
}
