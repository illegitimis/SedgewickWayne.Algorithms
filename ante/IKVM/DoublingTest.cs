using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SedgewickWayne.Algorithms.AnteRoom
{
    public class DoublingTest
    {
        public static double timeTrial(int i)
        {
            int num = 1000000;
            int[] array = new int[i];
            for (int j = 0; j < i; j++)
            {
                array[j] = StdRandom.uniform(-num, num);
            }
            Stopwatch stopwatch = new Stopwatch();
            ThreeSum.count(array);
            return stopwatch.elapsedTime();
        }


        private DoublingTest()
        {
        }


        /**/
        public static void main(string[] strarr)
        {
            int num = 250;
            while (true)
            {
                double d = DoublingTest.timeTrial(num);
                StdOut.printf("%7d %5.1f\n", new object[]
                {
                Integer.valueOf(num),
                java.lang.Double.valueOf(d)
                });
                num += num;
            }
        }
    }
}
