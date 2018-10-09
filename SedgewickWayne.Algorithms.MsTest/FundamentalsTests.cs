
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


