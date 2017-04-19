// http://algs4.cs.princeton.edu/14analysis/ThreeSum.java.html

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class ThreeSum
    {

        /// <summary>
        /// The <see cref="ThreeSum"/> class provides static methods for counting
        /// and printing the number of triples in an array of integers that sum to 0
        /// (ignoring integer overflow).
        /// This implementation uses a triply nested loop and takes proportional to n^3,
        /// where n is the number of integers.
        /// </summary>
        /// <param name="iarr"></param>
        /// <returns></returns>
        public static int Count(int[] iarr)
        {
            int N = iarr.Length;
            int cnt = 0;

            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    for (int k = j + 1; k < N; k++)
                    {
                        if (iarr[i] + iarr[j] + iarr[k] == 0)
                        {
                            cnt++;
                        }
                    }
                }
            }
            return cnt;
        }


    }
}
