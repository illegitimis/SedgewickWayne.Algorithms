
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

        [TestMethod]
        [TestCategory("3Sum")]
        public void ThreeSumFast1K()
        {
            string file = "1Kints.txt";
            TestHelper.DownloadFile(new Uri("http://algs4.cs.princeton.edu/14analysis/1Kints.txt"), file);

            int[] onek = File.ReadAllLines(file).Select(s => int.Parse(s)).ToArray();

            var sw = new Stopwatch();
            sw.Start();
            int count = ThreeSumFast.Count(onek);
            sw.Stop();

            Trace.WriteLine("3SumFast: " + count + " " + sw.ElapsedMilliseconds + " ms");

            sw = new Stopwatch();
            sw.Start();
            count = ThreeSum.Count(onek);
            sw.Stop();

            Trace.WriteLine("3SumSlow: " + count + " " + sw.ElapsedMilliseconds + " ms");
        }
    }
}



/******************************************************************************
 *  Compilation:  javac ThreeSumFast.java
 *  Execution:    java ThreeSumFast input.txt
 *  Dependencies: StdOut.java In.java Stopwatch.java
 *  Data files:   http://algs4.cs.princeton.edu/14analysis/1Kints.txt
 *                http://algs4.cs.princeton.edu/14analysis/2Kints.txt
 *                http://algs4.cs.princeton.edu/14analysis/4Kints.txt
 *                http://algs4.cs.princeton.edu/14analysis/8Kints.txt
 *                http://algs4.cs.princeton.edu/14analysis/16Kints.txt
 *                http://algs4.cs.princeton.edu/14analysis/32Kints.txt
 *                http://algs4.cs.princeton.edu/14analysis/1Mints.txt
 *
 *  A program with n^2 log n running time. Reads n integers
 *  and counts the number of triples that sum to exactly 0.
 *
 *  Limitations
 *  -----------
 *     - we ignore integer overflow
 *     - doesn't handle case when input has duplicates
 *
 *
 *  % java ThreeSumFast 1Kints.txt
 *  70
 *  
 *  % java ThreeSumFast 2Kints.txt
 *  528
 *                
 *  % java ThreeSumFast 4Kints.txt
 *  4039
 * 
 *  % java ThreeSumFast 8Kints.txt
 *  32074
 *
 *  % java ThreeSumFast 16Kints.txt
 *  255181
 *
 *  % java ThreeSumFast 32Kints.txt
 *  2052358
 *
 ******************************************************************************/
