
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
        [TestCategory("SetofInts")]
        [ExpectedException(typeof (ArgumentException))]
        public void SETofIntsThrowsExceptionIfInputArrayIsNotASet()
        {
            var r2050 = Enumerable.Range(20, 50);
            var r3080 = Enumerable.Range(30, 80);
            var duplicateValues = r2050.Concat(r3080).ToArray();

            var setInts = new SetofInts(duplicateValues);
            setInts.Rank(0);
        }

        [TestMethod]
        [TestCategory("SetofInts")]
        public void SETofIntsSetContainsTest()
        {
            var setInts = new SetofInts(Enumerable.Range(20, 50).ToArray());

            Assert.IsFalse(setInts.Contains(0));

            Assert.IsTrue(setInts.Contains(20));
            Assert.IsTrue(setInts.Contains(35));
            Assert.IsTrue(setInts.Contains(50));

            Assert.IsFalse(setInts.Contains(100));
        }

        #region 3sum

        [TestMethod]
        [TestCategory("3Sum")]
        [ExpectedException(typeof(ArgumentException))]
        public void ThreeSumFastThrowsExceptionIfInputArrayContainsDuplicates()
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
            ThreeSumFastCommon("1Kints.txt", "http://algs4.cs.princeton.edu/14analysis/1Kints.txt", 70, true);
        }
        [TestMethod]
        [TestCategory("3Sum")]
        public void ThreeSumFast2K()
        {
            ThreeSumFastCommon("2Kints.txt", "http://algs4.cs.princeton.edu/14analysis/2Kints.txt", 528);
        }
        [TestMethod]
        [TestCategory("3Sum")]
        public void ThreeSumFast4K()
        {
            ThreeSumFastCommon("4Kints.txt", "http://algs4.cs.princeton.edu/14analysis/4Kints.txt", 4039);
        }
        [TestMethod]
        [TestCategory("3Sum")]
        public void ThreeSumFast8K()
        {
            ThreeSumFastCommon("8Kints.txt", "http://algs4.cs.princeton.edu/14analysis/8Kints.txt", 32074);
        }

        [TestMethod]
        [TestCategory("3Sum")]
        public void ThreeSumFast16K()
        {
            ThreeSumFastCommon("16Kints.txt", "http://algs4.cs.princeton.edu/14analysis/16Kints.txt", 255181);
        }
        [TestMethod]
        [TestCategory("3Sum")]
        [Ignore]
        public void ThreeSumFast32K()
        {
            ThreeSumFastCommon("32Kints.txt", "http://algs4.cs.princeton.edu/14analysis/32Kints.txt", 2052358);
        }

        void ThreeSumFastCommon(
            string file = "1Kints.txt",
            string uri = "http://algs4.cs.princeton.edu/14analysis/1Kints.txt",
            int expectedCount = 70,
            bool b = false)
        {
            TestHelper.DownloadFile(new Uri(uri), file);

            int[] intArray = File.ReadAllLines(file).Select(s => int.Parse(s)).ToArray();

            var fast = TestHelper.Time(() => ThreeSumFast.Count(intArray), "3SumFast");
            Assert.AreEqual(expectedCount, fast.Item1);

            if (b)
            {
                var slow = TestHelper.Time(() => ThreeSum.Count(intArray), "3SumSlow");
                Assert.AreEqual(expectedCount, slow.Item1);
                Assert.IsTrue(fast.Item2 < slow.Item2);
            }
        } 
        #endregion

        [TestMethod]
        [TestCategory("Parantheses")]
        public void BalancedParanthesesTest ()
        {
            Assert.IsTrue(Parantheses.IsBalanced("[()]{ } {[()()]()}"));
            Assert.IsFalse(Parantheses.IsBalanced("[(])"));
        }

        // ( 1 + ( ( 2 + 3 ) * ( 4 * 5 ) ) )
        [TestMethod]
        [TestCategory("Parantheses")]
        public void ArithmeticExpressionEvaluateTest()
        {
            Assert.AreEqual(101, Parantheses.Evaluate("( 1 + ( ( 2 + 3 ) * ( 4 * 5 ) ) )"), 1E-6);
            Assert.AreEqual(1.618033988749895, Parantheses.Evaluate("( ( 1 + sqrt ( 5 ) ) / 2.0 )"), 1E-6);
        }
    }
}


