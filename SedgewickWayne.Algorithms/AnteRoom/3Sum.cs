using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SedgewickWayne.Algorithms.AnteRoom
{
    public class ThreeSum
    {

        public static int count(int[] iarr)
        {
            int num = iarr.Length;
            int num2 = 0;
            for (int i = 0; i < num; i++)
            {
                for (int j = i + 1; j < num; j++)
                {
                    for (int k = j + 1; k < num; k++)
                    {
                        if (iarr[i] + iarr[j] + iarr[k] == 0)
                        {
                            num2++;
                        }
                    }
                }
            }
            return num2;
        }


        public ThreeSum()
        {
        }


        public static void printAll(int[] iarr)
        {
            int num = iarr.Length;
            for (int i = 0; i < num; i++)
            {
                for (int j = i + 1; j < num; j++)
                {
                    for (int k = j + 1; k < num; k++)
                    {
                        if (iarr[i] + iarr[j] + iarr[k] == 0)
                        {
                            StdOut.println(new StringBuilder().append(iarr[i]).append(" ").append(iarr[j]).append(" ").append(iarr[k]).toString());
                        }
                    }
                }
            }
        }


        /**/
        public static void main(string[] strarr)
        {

            In @in = new In(strarr[0]);
            int[] iarr = @in.readAllInts();
            Stopwatch stopwatch = new Stopwatch();
            int i = ThreeSum.count(iarr);
            StdOut.println(new StringBuilder().append("elapsed time = ").append(stopwatch.elapsedTime()).toString());
            StdOut.println(i);
        }
    }
}
