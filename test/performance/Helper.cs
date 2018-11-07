namespace SedgewickWayne.Algorithms.Performance
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Xunit;

    internal static class Helper
    {
        /// <summary>
        /// Downloads and caches a big test file ... from Princeton 
        /// </summary>
        /// <param name="u">url</param>
        /// <param name="f">file name</param>
        public static string DownloadFile(Uri u, string f)
        {
            string dataFilePath = $"../../data/{f}";
            if (File.Exists(dataFilePath)) return dataFilePath;

            if (File.Exists(f))
            {
                File.Move(sourceFileName: f, destFileName: dataFilePath);
                return dataFilePath;
            }            

            using (var wc = new WebClient())
            {
                wc.DownloadProgressChanged += (object sender, DownloadProgressChangedEventArgs e) =>
                Trace.WriteLine($"{e.UserState} downloaded {e.BytesReceived} of {e.TotalBytesToReceive} bytes. {e.ProgressPercentage} % complete...{f}");

                wc.DownloadFileCompleted += (object sender, System.ComponentModel.AsyncCompletedEventArgs e) =>
                Trace.WriteLine($"{e.UserState} cancelled? {e.Cancelled} error? {(e.Error == null ? "N" : e.Error.Message)} ... {f}");

                wc.DownloadFile(u, dataFilePath);

                return dataFilePath;
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

        public static async Task<T> CheckTimeout<T>(Task<T> task, int timeoutinSeconds)
        {
            var resultTask = await Task.WhenAny(task, Task.Delay(1000 * timeoutinSeconds));
            if (resultTask != task) throw new InvalidOperationException(nameof(CheckTimeout));
            return task.Result;
        }
    }
}
