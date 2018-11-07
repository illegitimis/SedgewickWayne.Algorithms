
namespace SedgewickWayne.Algorithms.UnitTests
{
    using Xunit;

    
    public class BinarySearchTests
    {
        // http://algs4.cs.princeton.edu/11model/tinyW.txt
        // http://algs4.cs.princeton.edu/11model/tinyT.txt
        [Fact]
        public void BinarySearchTinyWT()
        {
            var input = new int[] {84,48,68,10,18,98,12,23,54,57,33,16,77,11,29};
            Quick3Way<int>.Sort(input);

            Assert.Equal(-1, BinarySearch.Rank(50, input));
            Assert.NotEqual(-1, BinarySearch.Rank(input[0], input));
            Assert.NotEqual(-1, BinarySearch.Rank(input[14], input));

            input = new int[] { 23, 50, 10, 99, 18, 23, 98, 84, 11, 10, 48, 77, 13, 54, 98, 77, 77, 68 };
            Quick3Way<int>.Sort(input);
            
            Assert.NotEqual(-1, BinarySearch.Rank(50, input));

            var r0 = BinarySearch.Rank(input[0], input);
            Assert.NotEqual(-1, r0);
            // on equal indices higher one returned
            //Assert.Equal(0, r0);

            var r17 = BinarySearch.Rank(input[17], input);
            Assert.NotEqual(-1, r17);
            Assert.Equal(17, r17);
        }

    }
}
