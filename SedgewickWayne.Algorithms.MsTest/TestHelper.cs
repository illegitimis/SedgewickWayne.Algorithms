namespace SedgewickWayne.Algorithms.MsTest
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net;

    public static class TestHelper
    {
        public static void DownloadFile(Uri u, string f)
        {
            if (File.Exists(f)) return;

            using (var wc = new WebClient())
            {
                wc.DownloadProgressChanged += (object sender, DownloadProgressChangedEventArgs e) =>
                Trace.WriteLine($"{e.UserState} downloaded {e.BytesReceived} of {e.TotalBytesToReceive} bytes. {e.ProgressPercentage} % complete...{f}");
                
                wc.DownloadFileCompleted += (object sender, System.ComponentModel.AsyncCompletedEventArgs e) => 
                Trace.WriteLine($"{e.UserState} cancelled? {e.Cancelled} error? {(e.Error == null ? "N" : e.Error.Message)} ... {f}");

                wc.DownloadFile(u, f);
            }
        }

        public static Tuple<int, long> Time(Func<int> f, string name)
        {
            var sw = new Stopwatch();
            sw.Start();
            int count = f();
            sw.Stop();

            Trace.WriteLine($"{name ?? nameof(f)}: {sw.ElapsedMilliseconds} ms");

            return new Tuple<int, long>(count, sw.ElapsedMilliseconds);
        }

        internal const string LINKED_LIST = "linked list";
        internal const string UNORDERED_ARRAY = "unordered array";
        internal const string BINARY_SEARCH = "binary search";
        internal const string BST = "binary search tree";

        internal static ISymbolTable<TKey, TValue> Factory<TKey, TValue>(string symbolTableType)
           where TKey : IComparable<TKey>, IEquatable<TKey>
            where TValue : IEquatable<TValue>
        {
            switch (symbolTableType)
            {
                case LINKED_LIST:
                case nameof(SequentialSearchST<TKey, TValue>):
                    return new SequentialSearchST<TKey, TValue>();

                case UNORDERED_ARRAY: return new ArrayST<TKey, TValue>();
                case BINARY_SEARCH: return new BinarySearchST<TKey, TValue>();
                case BST: return new BST<TKey, TValue>();
                default: return null;
            }
        }
    }
}
