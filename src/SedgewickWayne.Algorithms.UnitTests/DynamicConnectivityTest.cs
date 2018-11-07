/******************************************************************************
  *  Data files:   http://algs4.cs.princeton.edu/15uf/tinyUF.txt
 *                http://algs4.cs.princeton.edu/15uf/mediumUF.txt
 *                http://algs4.cs.princeton.edu/15uf/largeUF.txt
 *
 ******************************************************************************/

namespace SedgewickWayne.Algorithms.UnitTests
{
  using System;
  using Xunit;
  using UF = SedgewickWayne.Algorithms.DynamicConnectivity.UF;
  using QuickFindUF = SedgewickWayne.Algorithms.DynamicConnectivity.QuickFindUF;
  using QuickUnionUF = SedgewickWayne.Algorithms.DynamicConnectivity.QuickUnionUF;
  using WeightedQuickUnionUF = SedgewickWayne.Algorithms.DynamicConnectivity.WeightedQuickUnionUF;
  using WeightedQuickUnionPathCompressionUF = SedgewickWayne.Algorithms.DynamicConnectivity.WeightedQuickUnionPathCompressionUF;

  /// <summary>
  /// tests for <see cref="IUnionFind"/> which represents a union–Find data type (aka the disjoint-sets data type).
  /// </summary>
  
  public class DynamicConnectivityTest
  {
    /******************************************************************************
     *  Data files:   http://algs4.cs.princeton.edu/15uf/tinyUF.txt
    ******************************************************************************/

    static readonly int[,] tinyUF = new int[,] { { 4, 3 }, { 3, 8 }, { 6, 5 }, { 9, 4 }, { 2, 1 }, { 8, 9 }, { 5, 0 }, { 7, 2 }, { 6, 1 }, { 1, 0 }, { 6, 7 } };

    static readonly int[,] tuples = new int[,] { { 4, 3 }, { 3, 8 }, { 6, 5 }, { 9, 4 }, { 2, 1 }, { 8, 9 }, { 5, 0 }, { 7, 2 }, { 6, 1 }, { 7, 3 } };

    static readonly int[,] exercise = { {9, 3}, {8, 2}, {1, 5}, {9, 4}, {4, 0}, {6, 3}, {8, 5}, {9, 7}, {6, 8} };

     

    [Fact]
    public void OptimalAlgorithm_UF_StepByStep_Tuples()
    {

      UF uF = new UF(10);
      
      
      for (int i = 0; i < 10; i++)
      {
        int p = tuples[i, 0];
        int q = tuples[i, 1];
        if (!uF.Connected(p, q))
        {
          uF.Union(p, q);
        }

        switch (i)
        {
          case 0:
            Assert.True(uF.Connected(4, 3));
            Assert.Equal(uF.Ids[3],4);
            Assert.Equal(uF.Ranks[4], 1);
            Assert.Equal(uF.Ranks[3], 0);
            break;

          case 1:
            Assert.True(uF.Connected(8, 3));
            Assert.True(uF.Connected(8, 4));
            Assert.Equal(uF.Ids[3], 4);
            Assert.Equal(uF.Ids[8], 4);
            Assert.Equal(uF.Ranks[4], 1);
            Assert.Equal(uF.Ranks[8], 0);
            break;

          case 2:
            Assert.True(uF.Connected(6, 5));            
            Assert.Equal(uF.Ids[5], 6);            
            Assert.Equal(uF.Ranks[6], 1);
            Assert.Equal(uF.Ranks[5], 0);
            break;

          case 3:
            Assert.True(uF.Connected(4, 9));
            Assert.Equal(uF.Ids[9], 4);
            Assert.Equal(uF.Ranks[4], 1);
            Assert.Equal(uF.Ranks[9], 0);
            break;

          case 4:
            Assert.True(uF.Connected(2, 1));
            Assert.Equal(uF.Ids[1], 2);
            Assert.Equal(uF.Ranks[2], 1);
            Assert.Equal(uF.Ranks[1], 0);
            break;

          case 5:
            Assert.True(uF.Connected(8, 9));
            Assert.Equal(uF.Ids[9], 4);
            Assert.Equal(uF.Ids[8], 4);
            break;

          case 6:
            Assert.True(uF.Connected(5, 0));
            Assert.Equal(uF.Ids[5], 6);
            Assert.Equal(uF.Ids[0], 6);
            break;

          case 7:
            Assert.True(uF.Connected(7, 2));
            Assert.Equal(uF.Ids[7], 2);
            break;

          case 8:
            Assert.True(uF.Connected(6, 1));
            Assert.Equal(uF.Ids[1], 6);
            Assert.Equal(uF.Ranks[6], 2);
            break;

          case 9:
            Assert.True(uF.Connected(7, 3));
            Assert.Equal(uF.Ids[4], 6);
            Assert.Equal(uF.Ids[7], 6);
            Assert.Equal(uF.Ids[3], 6);
            break;
          
          default: break;
        }        
      }

      // at the end
      Assert.Equal(new byte[] { 0, 0, 1, 0, 1, 0, 2, 0, 0, 0 }, uF.Ranks);
      Assert.Equal(new[] { 6, 6, 6, 6, 6, 6, 6, 6, 4, 4 }, uF.Ids);
      Assert.Equal(uF.Count, 1);
    }

    [Fact]
    public void QuickFindUF_StepByStep_Tiny()
    {
      IUnionFind qf = new QuickFindUF(10);
      qf.Union(4, 3);
      Assert.Equal(qf.Ids[3], 3);
      Assert.Equal(qf.Ids[4], 3);

      qf.Union(3, 8);
      Assert.Equal(qf.Ids[3], 8);
      Assert.Equal(qf.Ids[4], 8);
      Assert.Equal(qf.Ids[8], 8);

      qf.Union(6, 5);
      Assert.Equal(qf.Ids[6], 5);
      Assert.Equal(qf.Ids[5], 5);

      qf.Union(9, 4);
      Assert.Equal(qf.Ids[9], 8);
      Assert.Equal(qf.Ids[4], 8);

      qf.Union(2, 1);
      Assert.Equal(qf.Ids[2], 1);
      Assert.Equal(qf.Ids[1], 1);

      Assert.True(qf.Connected(8, 9));
      qf.Union(8, 9);

      qf.Union(5, 0);
      Assert.Equal(qf.Ids[6], 0);
      Assert.Equal(qf.Ids[5], 0);

      qf.Union(7, 2);
      Assert.Equal(qf.Ids[7], 1);

      qf.Union(6, 1);
      Assert.Equal(qf.Ids[5], 1);
      Assert.Equal(qf.Ids[6], 1);
      Assert.Equal(qf.Ids[0], 1);
      Assert.True(qf.Connected(1, 0));

      qf.Union(1, 0);
      Assert.True(qf.Connected(1, 0));

      qf.Union(6, 7);

      Assert.Equal(new int[] { 1, 1, 1, 8, 8, 1, 1, 1, 8, 8 }, qf.Ids);
      Assert.Equal(qf.Count, 2);
    }

    [Fact]
    public void QuickUnionUF_StepByStep_Tuples()
    {
      IUnionFind qu = new QuickUnionUF(10);

      qu.Union(4, 3);
      Assert.Equal(qu.Ids[3], 3);
      Assert.Equal(qu.Ids[4], 3);
     

      qu.Union(3, 8);
      Assert.Equal(qu.Ids[3], 8);
      Assert.Equal(qu.Ids[8], 8);
      // this does not propagate
      Assert.Equal(qu.Ids[4], 3);      

      qu.Union(6, 5);
      Assert.Equal(qu.Ids[6], 5);
      
      qu.Union(9, 4);
      Assert.Equal(qu.Ids[9], 8);
      
      qu.Union(2, 1);
      Assert.Equal(qu.Ids[2], 1);
      
      Assert.True(qu.Connected(8, 9));
      qu.Union(8, 9);

      //
      Assert.False(qu.Connected(5, 4));

      qu.Union(5, 0);
      // 0 becomes root of 5, 6 child of 5
      Assert.Equal(qu.Ids[6], 5);
      Assert.Equal(qu.Ids[5], 0);

      qu.Union(7, 2);
      Assert.Equal(qu.Ids[7], 1);
      Assert.Equal(qu.Ids[2], 1);

      qu.Union(6, 1);
      Assert.Equal(qu.Ids[5], 0);
      Assert.Equal(qu.Ids[6], 5);
      Assert.Equal(qu.Ids[0], 1);

      Assert.True(qu.Connected(1, 0));
      //wqu.Union(1, 0);

      Assert.True(qu.Connected(6, 7));
      //wqu.Union(6, 7);

      Assert.False(qu.Connected(7, 3));
      qu.Union(7, 3);
      Assert.Equal(qu.Ids[7], 1);
      Assert.Equal(qu.Ids[3], 8);
      Assert.Equal(qu.Ids[1], 8);

      Assert.Equal(new int[] { 1, 8, 1, 8, 3, 0, 5, 1, 8, 8 }, qu.Ids);
      
      Assert.Equal(qu.Count, 1);
    }


    [Fact]
    public void WeightedQuickUnionUF_StepByStep_Tuples()
    {
      var wqu = new WeightedQuickUnionUF(10);

      // first time else branch
      wqu.Union(4, 3);
      Assert.Equal(wqu.Ids[3], 4);
      Assert.Equal(wqu.Ids[4], 4);      
      Assert.Equal(wqu.Sizes[3], 1);
      Assert.Equal(wqu.Sizes[4], 2);

      // make 8 point to 4
      wqu.Union(3, 8);
      Assert.Equal(wqu.Ids[3], 4);
      Assert.Equal(wqu.Ids[8], 4);
      Assert.Equal(wqu.Ids[4], 4);
      Assert.Equal(wqu.Sizes[4], 3);

      wqu.Union(6, 5);
      Assert.Equal(wqu.Ids[6], 6);
      Assert.Equal(wqu.Ids[5], 6);
      Assert.Equal(wqu.Sizes[6], 2);

      // make 9 point to 4
      wqu.Union(9, 4);
      Assert.Equal(wqu.Sizes[4], 4);
      Assert.Equal(wqu.Ids[9], 4);

      wqu.Union(2, 1);
      Assert.Equal(wqu.Ids[1], 2);
      Assert.Equal(wqu.Sizes[2], 2);

      Assert.True(wqu.Connected(8, 9));
      Assert.False(wqu.Connected(5, 4));

      // 0 points to 6, root of 5
      wqu.Union(5, 0);      
      Assert.Equal(wqu.Ids[0], 6);
      Assert.Equal(wqu.Ids[5], 6);
      Assert.Equal(wqu.Sizes[6], 3);

      // 2 in the bigger tree, 7 goes below
      wqu.Union(7, 2);
      Assert.Equal(wqu.Ids[7], 2);
      Assert.Equal(wqu.Ids[1], 2);
      Assert.Equal(wqu.Sizes[2], 3);

      // roots have equal sizes, else branch
      wqu.Union(6, 1);
      Assert.Equal(wqu.Ids[2], 6);
      Assert.Equal(wqu.Ids[6], 6);
      Assert.Equal(wqu.Ids[1], 2);
      Assert.Equal(wqu.Sizes[6], 6);

      Assert.True(wqu.Connected(1, 0));
      Assert.True(wqu.Connected(6, 7));
      Assert.False(wqu.Connected(7, 3));

      // 3 in the smaller tree, make root of 3 point to root of 7, 4 poins to 6
      wqu.Union(7, 3);
      Assert.Equal(wqu.Ids[4], 6);
      Assert.Equal(wqu.Ids[3], 4);
      // Assert.Equal(wqu.Ids[7], 2);

      //Assert.Equal(new int[] { 6, 2, 6, 4, 6, 6, 6 , 2, 4, 4 }, wqu.Ids);
      Assert.Equal(new int[] { 1, 1, 3, 1, 4, 1, 10, 1, 1, 1 }, wqu.Sizes);

      Assert.Equal(wqu.Count, 1);
    }

    [Fact]
    public void WeightedQuickUnion_Batch_Exercise ()
    {
      var wqu = new WeightedQuickUnionPathCompressionUF(10);
      for (int i = 0; i < exercise.GetLength(0); i++) wqu.Union(exercise[i, 0], exercise[i, 1]);

      Assert.Equal(new int[] { 9,8,8,9,9,1,9,9,9, 9}, wqu.Ids);
      Assert.Equal(new int[] { 1,2,1,1,1,1,1,1,4,10}, wqu.Sizes);
      Assert.Equal(1, wqu.Count);
    }

  }

}
