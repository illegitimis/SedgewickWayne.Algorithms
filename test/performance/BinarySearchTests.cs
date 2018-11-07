using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SedgewickWayne.Algorithms.Performance
{
    public class BinarySearchTests
    {
        const string largew = "largeW.txt";
        const string larget = "largeT.txt";

        private int[] ts;
        private int[] ws;

        public BinarySearchTests()
        {
            // run download tasks in parallel
            var tasks = (new string[] { largew, larget })
                    .Select(x => Task.Run(() => Helper.DownloadFile(new Uri($"http://algs4.cs.princeton.edu/11model/{x}"), x)))
                    .ToArray();
            Task.WaitAll(tasks);

            var files = tasks.Select(t => t.Result).ToArray();

            // separate I/O read from sorting time while running test
            Task.WaitAll(
                Task.Run(() => ws = ArrayFromTextFile(files[0])),
                Task.Run(() => ts = ArrayFromTextFile(files[1])));
        }

        [Fact]
        public void T_10MillionValues_85dot8MB_FileSize()
        {
            /*
             * array index      value
             * 10..11           0
             * 100..102         12
             * 1000..1002       98
             * 10000..10013     1037
             * 54321            5626
             * 61234            6361
             * 67890            7095
             * 99999            10371
             * 123456           12891
             * 135790           14126
             * 222222           23025
             * 333333           34540
             * 414243           42997
             * 565758           58807
             */
            ArrayRanks(
                ts, // 20 ins, 10 outs
                new[] { 499569, 984875, 295754, 207807, 140925, 161828, 0, 12, 98, 1037,
                        5626, 6361, 7095, 10371, 12891, 14126, 23025, 34540, 42997, 58807 }, 
                new[] { 4812246, 9486211, 2849977, 2004447, 1357203, 1561507, 1033, 1234, 130307, 238731 });
        }

        [Fact]
        public void W_1MillionValues_6dot6MB_FileSize()
        {
            ArrayRanks(
                ws, // 10 ins & 10 outs
                new[] { 489910, 330644, 940701, 959, 660514, 478292, 563352, 494315, 935085, 403161 },
                new[] { 5, 31, 64369, 173977, 174210, 175032, 261999, 262428, 263000, 739000 });
        }

        private void ArrayRanks(int[] array, int[] ins, int[] outs)
        {
            // in place sort
            Quick3Way<int>.Sort(array);

            // contained
            foreach (int i in ins)
            {
                int rank = BinarySearch.Rank(i, array);
                Assert.NotEqual(-1, rank);
            }

            // missing
            foreach (int i in outs)
            {
                int rank = BinarySearch.Rank(i, array);
                Assert.Equal(-1, rank);
            }
        }

        private int[] ArrayFromTextFile(string fileName)
        {
            /* string actualFileName = File.Exists(fileName) ? fileName : $"../../{fileName}"; */
            return File
                .ReadAllLines(/*actualFileName*/ fileName)
                .Select(s => int.Parse(s))
                .ToArray();
        }
    }
}