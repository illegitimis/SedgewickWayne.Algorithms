
namespace SedgewickWayne.Algorithms.MsTest
{
  using System;
  using Microsoft.VisualStudio.TestTools.UnitTesting;

  /// <summary>
  /// tests for UF, QuickUnionUF, QuickFindUF, WeightedQuickUnionUF
  /// </summary>
  [TestClass]
  public class DynamicConnectivityTest
  {
    [TestMethod]
    public void TinyWeightedQuickUnionPathCompressionUF()
    {

      UF uF = new UF(10);
      //var tuples = new int[,] { { 4, 3 }, { 3, 8 }, { 6, 5 }, { 9, 4 }, { 2, 1 }, { 8, 9 }, { 5, 0 }, { 7, 2 }, { 6, 1 }, { 1, 0 }, { 6, 7 } };
      var tuples = new int[,] { { 4, 3 }, { 3, 8 }, { 6, 5 }, { 9, 4 }, { 2, 1 }, { 8, 9 }, { 5, 0 }, { 7, 2 }, { 6, 1 }, { 7, 3 } };
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
            Assert.IsTrue(uF.Connected(4, 3));
            Assert.AreEqual(uF.Ids[3],4);
            Assert.AreEqual(uF.Ranks[4], 1);
            Assert.AreEqual(uF.Ranks[3], 0);
            break;

          case 1:
            Assert.IsTrue(uF.Connected(8, 3));
            Assert.IsTrue(uF.Connected(8, 4));
            Assert.AreEqual(uF.Ids[3], 4);
            Assert.AreEqual(uF.Ids[8], 4);
            Assert.AreEqual(uF.Ranks[4], 1);
            Assert.AreEqual(uF.Ranks[8], 0);
            break;

          case 2:
            Assert.IsTrue(uF.Connected(6, 5));            
            Assert.AreEqual(uF.Ids[5], 6);            
            Assert.AreEqual(uF.Ranks[6], 1);
            Assert.AreEqual(uF.Ranks[5], 0);
            break;

          case 3:
            Assert.IsTrue(uF.Connected(4, 9));
            Assert.AreEqual(uF.Ids[9], 4);
            Assert.AreEqual(uF.Ranks[4], 1);
            Assert.AreEqual(uF.Ranks[9], 0);
            break;

          case 4:
            Assert.IsTrue(uF.Connected(2, 1));
            Assert.AreEqual(uF.Ids[1], 2);
            Assert.AreEqual(uF.Ranks[2], 1);
            Assert.AreEqual(uF.Ranks[1], 0);
            break;

          case 5:
            Assert.IsTrue(uF.Connected(8, 9));
            Assert.AreEqual(uF.Ids[9], 4);
            Assert.AreEqual(uF.Ids[8], 4);
            break;

          case 6:
            Assert.IsTrue(uF.Connected(5, 0));
            Assert.AreEqual(uF.Ids[5], 6);
            Assert.AreEqual(uF.Ids[0], 6);
            break;

          case 7:
            Assert.IsTrue(uF.Connected(7, 2));
            Assert.AreEqual(uF.Ids[7], 2);
            break;

          case 8:
            Assert.IsTrue(uF.Connected(6, 1));
            Assert.AreEqual(uF.Ids[1], 6);
            Assert.AreEqual(uF.Ranks[6], 2);
            break;

          case 9:
            Assert.IsTrue(uF.Connected(7, 3));
            Assert.AreEqual(uF.Ids[4], 6);
            Assert.AreEqual(uF.Ids[7], 6);
            Assert.AreEqual(uF.Ids[3], 6);
            break;
          
          default: break;
        }        
      }

      // at the end
      CollectionAssert.AreEqual(new byte[] { 0, 0, 1, 0, 1, 0, 2, 0, 0, 0 }, uF.Ranks);
      CollectionAssert.AreEqual(new[] { 6, 6, 6, 6, 6, 6, 6, 6, 4, 4 }, uF.Ids);
      Assert.AreEqual(uF.Count, 1);
    }

    [TestMethod]
    public void TinyQuickFindUF()
    {
      UFBase qf = new QuickFindUF(10);
      qf.Union(4, 3);
      Assert.AreEqual(qf.Ids[3], 3);
      Assert.AreEqual(qf.Ids[4], 3);

      qf.Union(3, 8);
      Assert.AreEqual(qf.Ids[3], 8);
      Assert.AreEqual(qf.Ids[4], 8);
      Assert.AreEqual(qf.Ids[8], 8);

      qf.Union(6, 5);
      Assert.AreEqual(qf.Ids[6], 5);
      Assert.AreEqual(qf.Ids[5], 5);

      qf.Union(9, 4);
      Assert.AreEqual(qf.Ids[9], 8);
      Assert.AreEqual(qf.Ids[4], 8);

      qf.Union(2, 1);
      Assert.AreEqual(qf.Ids[2], 1);
      Assert.AreEqual(qf.Ids[1], 1);

      Assert.IsTrue(qf.Connected(8, 9));
      qf.Union(8, 9);

      qf.Union(5, 0);
      Assert.AreEqual(qf.Ids[6], 0);
      Assert.AreEqual(qf.Ids[5], 0);

      qf.Union(7, 2);
      Assert.AreEqual(qf.Ids[7], 1);

      qf.Union(6, 1);
      Assert.AreEqual(qf.Ids[5], 1);
      Assert.AreEqual(qf.Ids[6], 1);
      Assert.AreEqual(qf.Ids[0], 1);

      Assert.IsTrue(qf.Connected(1, 0));
      qf.Union(1, 0);

      Assert.IsTrue(qf.Connected(1, 0));
      qf.Union(6, 7);

      CollectionAssert.AreEqual(new int[] { 1, 1, 1, 8, 8, 1, 1, 1, 8, 8 }, qf.Ids);

      Assert.AreEqual(qf.Count, 2);
    }

    [TestMethod]
    public void TinyQuickUnionUF()
    {
      UFBase qu = new QuickUnionUF(10);

      qu.Union(4, 3);
      Assert.AreEqual(qu.Ids[3], 3);
      Assert.AreEqual(qu.Ids[4], 3);
     

      qu.Union(3, 8);
      Assert.AreEqual(qu.Ids[3], 8);
      Assert.AreEqual(qu.Ids[8], 8);
      // this does not propagate
      Assert.AreEqual(qu.Ids[4], 3);      

      qu.Union(6, 5);
      Assert.AreEqual(qu.Ids[6], 5);
      
      qu.Union(9, 4);
      Assert.AreEqual(qu.Ids[9], 8);
      
      qu.Union(2, 1);
      Assert.AreEqual(qu.Ids[2], 1);
      
      Assert.IsTrue(qu.Connected(8, 9));
      qu.Union(8, 9);

      //
      Assert.IsFalse(qu.Connected(5, 4));

      qu.Union(5, 0);
      // 0 becomes root of 5, 6 child of 5
      Assert.AreEqual(qu.Ids[6], 5);
      Assert.AreEqual(qu.Ids[5], 0);

      qu.Union(7, 2);
      Assert.AreEqual(qu.Ids[7], 1);
      Assert.AreEqual(qu.Ids[2], 1);

      qu.Union(6, 1);
      Assert.AreEqual(qu.Ids[5], 0);
      Assert.AreEqual(qu.Ids[6], 5);
      Assert.AreEqual(qu.Ids[0], 1);

      Assert.IsTrue(qu.Connected(1, 0));
      //wqu.Union(1, 0);

      Assert.IsTrue(qu.Connected(6, 7));
      //wqu.Union(6, 7);

      Assert.IsFalse(qu.Connected(7, 3));
      qu.Union(7, 3);
      Assert.AreEqual(qu.Ids[7], 1);
      Assert.AreEqual(qu.Ids[3], 8);
      Assert.AreEqual(qu.Ids[1], 8);

      CollectionAssert.AreEqual(new int[] { 1, 8, 1, 8, 3, 0, 5, 1, 8, 8 }, qu.Ids);
      
      Assert.AreEqual(qu.Count, 1);
    }


    [TestMethod]
    public void TinyWeightedQuickUnionUF()
    {
      var wqu = new WeightedQuickUnionUF(10);

      // first time else branch
      wqu.Union(4, 3);
      Assert.AreEqual(wqu.Ids[3], 4);
      Assert.AreEqual(wqu.Ids[4], 4);      
      Assert.AreEqual(wqu.Sizes[3], 1);
      Assert.AreEqual(wqu.Sizes[4], 2);

      // make 8 point to 4
      wqu.Union(3, 8);
      Assert.AreEqual(wqu.Ids[3], 4);
      Assert.AreEqual(wqu.Ids[8], 4);
      Assert.AreEqual(wqu.Ids[4], 4);
      Assert.AreEqual(wqu.Sizes[4], 3);

      wqu.Union(6, 5);
      Assert.AreEqual(wqu.Ids[6], 6);
      Assert.AreEqual(wqu.Ids[5], 6);
      Assert.AreEqual(wqu.Sizes[6], 2);

      // make 9 point to 4
      wqu.Union(9, 4);
      Assert.AreEqual(wqu.Sizes[4], 4);
      Assert.AreEqual(wqu.Ids[9], 4);

      wqu.Union(2, 1);
      Assert.AreEqual(wqu.Ids[1], 2);
      Assert.AreEqual(wqu.Sizes[2], 2);

      Assert.IsTrue(wqu.Connected(8, 9));
      Assert.IsFalse(wqu.Connected(5, 4));

      // 0 points to 6, root of 5
      wqu.Union(5, 0);      
      Assert.AreEqual(wqu.Ids[0], 6);
      Assert.AreEqual(wqu.Ids[5], 6);
      Assert.AreEqual(wqu.Sizes[6], 3);

      // 2 in the bigger tree, 7 goes below
      wqu.Union(7, 2);
      Assert.AreEqual(wqu.Ids[7], 2);
      Assert.AreEqual(wqu.Ids[1], 2);
      Assert.AreEqual(wqu.Sizes[2], 3);

      // roots have equal sizes, else branch
      wqu.Union(6, 1);
      Assert.AreEqual(wqu.Ids[2], 6);
      Assert.AreEqual(wqu.Ids[6], 6);
      Assert.AreEqual(wqu.Ids[1], 2);
      Assert.AreEqual(wqu.Sizes[6], 6);

      Assert.IsTrue(wqu.Connected(1, 0));
      Assert.IsTrue(wqu.Connected(6, 7));
      Assert.IsFalse(wqu.Connected(7, 3));

      // 3 in the smaller tree, make root of 3 point to root of 7, 4 poins to 6
      wqu.Union(7, 3);
      Assert.AreEqual(wqu.Ids[4], 6);
      Assert.AreEqual(wqu.Ids[3], 4);
      Assert.AreEqual(wqu.Ids[7], 2);

      CollectionAssert.AreEqual(new int[] { 6, 2, 6, 4, 6, 6, 6 , 2, 4, 4 }, wqu.Ids);
      CollectionAssert.AreEqual(new int[] { 1, 1, 3, 1, 4, 1, 10, 1, 1, 1 }, wqu.Sizes);

      Assert.AreEqual(wqu.Count, 1);
    }

    [TestMethod]
    public void ExerciseWeightedQuickUnion ()
    {
      var wqu = new WeightedQuickUnionUF(10);
      wqu.Union(9, 3);
      wqu.Union(8, 2);
      wqu.Union(1, 5);
      wqu.Union(9, 4);
      wqu.Union(4, 0);
      wqu.Union(6, 3);
      wqu.Union(8, 5);
      wqu.Union(9, 7);
      wqu.Union(6, 8);
      CollectionAssert.AreEqual(new int[] { 9,8,8,9,9,1,9,9,9,9}, wqu.Ids);
      CollectionAssert.AreEqual(new int[] { 1, 2, 1, 1,1,1,1,1,4,10}, wqu.Sizes);
      Assert.AreEqual(1, wqu.Count);
    }

  }

}
