namespace SedgewickWayne.Algorithms.Performance
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class ThreeSumTests
    {
        const string k01 = "1Kints.txt"; 
        const string k02 = "2Kints.txt"; 
        const string k04 = "4Kints.txt"; 
        const string k08 = "8Kints.txt"; 
        const string k16 = "16Kints.txt";
        const string k32 = "32Kints.txt";
        const string M01 = "1Mints.txt";


        public ThreeSumTests()
        {
            var strings = new string[] { k01, k02, k04, k08, k16, k32, M01 };
#if TPL
            Task.WaitAll(
                strings
                    .Select(file => Task.Run(() => Helper.DownloadFile(new Uri($"http://algs4.cs.princeton.edu/14analysis/{file}"), file)))
                    .ToArray());
#else
            foreach (var file in strings)
            {
                Helper.DownloadFile(new Uri($"http://algs4.cs.princeton.edu/14analysis/{file}"), file);
            }
#endif
        }

        [Theory(DisplayName = "3SUM fast vs slow")]
        [InlineData(k01, 70, 1)]
        [InlineData(k02, 528, 10)]
        public void FastVsSlow(string file, int expectedCount, int timeoutInSeconds)
        {
            string actualFilePath = $"../../data/{file}";
            if (!File.Exists(actualFilePath)) throw new InvalidOperationException(file);

            int[] intArray = File.ReadAllLines(actualFilePath).Select(s => int.Parse(s)).ToArray();

            var fast = Helper.Time(() => ThreeSumFast.Count(intArray), "3SumFast");
            Assert.Equal(expectedCount, fast.Item1);

            var slow = Helper.Time(() => ThreeSum.Count(intArray), "3SumSlow");
            Assert.Equal(expectedCount, slow.Item1);

            Assert.True(fast.Item2 < slow.Item2);
            Assert.True(fast.Item2 + slow.Item2 < timeoutInSeconds * 1000);
        }

        [Theory(DisplayName = "3SUM")]
        [InlineData(k04, 4039, 1)]
        [InlineData(k08, 32074, 4)]
        [InlineData(k16, 255181, 16)]
        [InlineData(k32, 2052358, 60)]
        /* Haven't managed to run this within ~40h [InlineData(M01, ?, ?)] */
        public void Fast(string file, int expectedCount, int secondsRuntime)
        {
            string actualFilePath = $"../../data/{file}";
            if (!File.Exists(actualFilePath)) throw new InvalidOperationException(file);

            int[] intArray = File.ReadAllLines(actualFilePath).Select(s => int.Parse(s)).ToArray();

            var tuple = Helper.Time(() => ThreeSumFast.Count(intArray), "fast");
            Assert.Equal(expectedCount, tuple.Item1);
            Assert.True(tuple.Item2 < secondsRuntime*1000);
        }
    }
}
