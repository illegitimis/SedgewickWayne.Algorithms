
namespace SedgewickWayne.Algorithms.MsTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using SedgewickWayne.Algorithms;
    using System.IO;
    using System.Diagnostics;

    [TestClass]
    public class FundamentalsTests
    {
        [TestMethod]
        [TestCategory("StaticSETofInts")]
        [ExpectedException(typeof (ArgumentException))]
        public void SETofIntsThrowsExceptionIfInputArrayIsNotASet()
        {
            var r2050 = Enumerable.Range(20, 50);
            var r3080 = Enumerable.Range(30, 80);
            var duplicateValues = r2050.Concat(r3080).ToArray();

            var setInts = new StaticSETofInts(duplicateValues);
        }

        [TestMethod]
        [TestCategory("StaticSETofInts")]
        public void SETofIntsSetContainsTest()
        {
            var setInts = new StaticSETofInts(Enumerable.Range(20, 50).ToArray());

            Assert.IsFalse(setInts.Contains(0));

            Assert.IsTrue(setInts.Contains(20));
            Assert.IsTrue(setInts.Contains(35));
            Assert.IsTrue(setInts.Contains(50));

            Assert.IsFalse(setInts.Contains(100));
        }


        [TestMethod]
        [TestCategory("3Sum")]
        [ExpectedException(typeof(ArgumentException))]
        public void ThreeSumFastThrowsExceptionIfInputArrayContainsDuplicates ()
        {
            var r2050 = Enumerable.Range(20, 50);
            var r3080 = Enumerable.Range(30, 80);
            var duplicateValues = r2050.Concat(r3080).ToArray();

            ThreeSumFast.Count(duplicateValues);
        }

        /// <summary>
        ///  Data files:   
        ///  http://algs4.cs.princeton.edu/14analysis/1Kints.txt    *  70
        ///  http://algs4.cs.princeton.edu/14analysis/2Kints.txt    *  528
        ///  http://algs4.cs.princeton.edu/14analysis/4Kints.txt    *  4039
        ///  http://algs4.cs.princeton.edu/14analysis/8Kints.txt    *  32074
        ///  http://algs4.cs.princeton.edu/14analysis/16Kints.txt   *  255181
        ///  http://algs4.cs.princeton.edu/14analysis/32Kints.txt   *  2052358
        ///  http://algs4.cs.princeton.edu/14analysis/1Mints.txt
        /// </summary>
        [TestMethod]
        [TestCategory("3Sum")]
        public void ThreeSumFast1K()
        {
            string file = "1Kints.txt";
            TestHelper.DownloadFile(new Uri("http://algs4.cs.princeton.edu/14analysis/1Kints.txt"), file);

            int[] onek = File.ReadAllLines(file).Select(s => int.Parse(s)).ToArray();

            var fast = TestHelper.Time(() => ThreeSumFast.Count(onek), "3SumFast");
            var slow = TestHelper.Time(() => ThreeSum.Count(onek), "3SumSlow");

            Assert.AreEqual(70, fast.Item1);
            Assert.AreEqual(70, slow.Item1);
            Assert.IsTrue(fast.Item2 < slow.Item2);
        }
    }
}


