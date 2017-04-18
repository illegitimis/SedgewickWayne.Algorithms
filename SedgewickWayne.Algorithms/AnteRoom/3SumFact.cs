
namespace SedgewickWayne.Algorithms.AnteRoom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ThreeSumFast
    {

        private static bool containsDuplicates(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == array[i - 1])
                {
                    return true;
                }
            }
            return false;
        }


        public static int count(int[] iarr)
        {
            int num = iarr.Length;
            Arrays.sort(iarr);
            if (ThreeSumFast.containsDuplicates(iarr))
            {
                string arg_1B_0 = "array contains duplicate integers";

                throw new ArgumentException(arg_1B_0);
            }
            int num2 = 0;
            for (int i = 0; i < num; i++)
            {
                for (int j = i + 1; j < num; j++)
                {
                    int num3 = Arrays.binarySearch(iarr, -(iarr[i] + iarr[j]));
                    if (num3 > j)
                    {
                        num2++;
                    }
                }
            }
            return num2;
        }


        public ThreeSumFast()
        {
        }


        public static void printAll(int[] iarr)
        {
            int num = iarr.Length;
            Arrays.sort(iarr);
            if (ThreeSumFast.containsDuplicates(iarr))
            {
                string arg_1B_0 = "array contains duplicate integers";

                throw new ArgumentException(arg_1B_0);
            }
            for (int i = 0; i < num; i++)
            {
                for (int j = i + 1; j < num; j++)
                {
                    int num2 = Arrays.binarySearch(iarr, -(iarr[i] + iarr[j]));
                    if (num2 > j)
                    {
                        StdOut.println(new StringBuilder().append(iarr[i]).append(" ").append(iarr[j]).append(" ").append(iarr[num2]).toString());
                    }
                }
            }
        }


        /**/
        public static void main(string[] strarr)
        {

            In @in = new In(strarr[0]);
            int[] iarr = @in.readAllInts();
            int i = ThreeSumFast.count(iarr);
            StdOut.println(i);
        }
    }
}
