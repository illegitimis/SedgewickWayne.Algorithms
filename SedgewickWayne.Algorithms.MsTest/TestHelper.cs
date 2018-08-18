using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace SedgewickWayne.Algorithms.MsTest
{
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
    }
}
