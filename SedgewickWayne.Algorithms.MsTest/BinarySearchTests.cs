
namespace SedgewickWayne.Algorithms.MsTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BinarySearchTests
    {
        // http://algs4.cs.princeton.edu/11model/tinyW.txt
        // http://algs4.cs.princeton.edu/11model/tinyT.txt
        [TestMethod]
        public void BinarySearchTinyWT()
        {
            var input = new int[] {84,48,68,10,18,98,12,23,54,57,33,16,77,11,29};
            Quick3Way<int>.Sort(input);

            Assert.AreEqual(-1, BinarySearch.Rank(50, input));
            Assert.AreNotEqual(-1, BinarySearch.Rank(input[0], input));
            Assert.AreNotEqual(-1, BinarySearch.Rank(input[14], input));

            input = new int[] { 23, 50, 10, 99, 18, 23, 98, 84, 11, 10, 48, 77, 13, 54, 98, 77, 77, 68 };
            Quick3Way<int>.Sort(input);
            
            Assert.AreNotEqual(-1, BinarySearch.Rank(50, input));

            var r0 = BinarySearch.Rank(input[0], input);
            Assert.AreNotEqual(-1, r0);
            // on equal indices higher one returned
            //Assert.AreEqual(0, r0);

            var r17 = BinarySearch.Rank(input[17], input);
            Assert.AreNotEqual(-1, r17);
            Assert.AreEqual(17, r17);
        }

    }
}
