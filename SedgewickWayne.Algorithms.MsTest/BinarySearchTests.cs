
namespace SedgewickWayne.Algorithms.MsTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Net;
    using System.Threading.Tasks;
    using System.IO;
    using System.Linq;

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

        static readonly Uri uriw = new Uri("http://algs4.cs.princeton.edu/11model/largeW.txt");
        static readonly Uri urit = new Uri("http://algs4.cs.princeton.edu/11model/largeT.txt");

        const string largew = "largeW.txt";
        const string larget = "largeT.txt";


        void down(Uri u, string f)
        {
            if (File.Exists(f)) return;

            using (var wc = new WebClient())
            {
                wc.DownloadProgressChanged += (object sender, DownloadProgressChangedEventArgs e) =>
                {
                    Console.WriteLine("{0}    downloaded {1} of {2} bytes. {3} % complete...{4}",
                        (string)e.UserState, e.BytesReceived, e.TotalBytesToReceive, e.ProgressPercentage, f);
                };
                wc.DownloadFileCompleted += (object sender, System.ComponentModel.AsyncCompletedEventArgs e) => {
                    Console.WriteLine("{0}    cancelled? {1} error? {2} ... {3}",
                        (string)e.UserState, e.Cancelled, e.Error == null ? "N" : e.Error.Message, f);
                };

                wc.DownloadFile(u, f);
            }
        }

        [TestMethod]
        public void BinarySearchLarge()
        {
            // 85.8 MB
            var t1 = Task.Factory.StartNew(() => down(urit, larget));
            // 6.6MB  [367, 966 total values]
            var t2 = Task.Factory.StartNew(() => down(uriw, largew));
            // 
            Task.WaitAll(t1, t2);

            int[] ts = File.ReadAllLines(larget).Select(s => int.Parse(s)).ToArray();
            int[] ws = File.ReadAllLines(largew).Select(s => int.Parse(s)).ToArray();

            Quick3Way<int>.Sort(ts);
            Quick3Way<int>.Sort(ws);
                        
            foreach (int i in new[] { 499569, 984875, 295754, 207807, 140925, 161828 })
            {
                Assert.AreNotEqual(-1, BinarySearch.Rank(i, ts), "ts" + i);
                Assert.AreEqual(-1, BinarySearch.Rank(i, ws), "ws" + i);

                // 4812246 9486211 2849977 2004447 1357203 1561507    
                //Console.WriteLine("{0} {1}",BinarySearch.Rank(i, ts), BinarySearch.Rank(i, ws));
            }
        }

    }
}
