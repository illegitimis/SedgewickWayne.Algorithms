using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SedgewickWayne.Algorithms.AnteRoom
{
    public class RandomSeq
    {


        private RandomSeq()
        {
        }


        /**/
        public static void main(string[] strarr)
        {
            int num = Integer.parseInt(strarr[0]);
            if (strarr.Length == 1)
            {
                for (int i = 0; i < num; i++)
                {
                    double d = StdRandom.uniform();
                    StdOut.println(d);
                }
            }
            else
            {
                if (strarr.Length != 3)
                {
                    string arg_87_0 = "Invalid number of arguments";

                    throw new ArgumentException(arg_87_0);
                }
                double d2 = java.lang.Double.parseDouble(strarr[1]);
                double d3 = java.lang.Double.parseDouble(strarr[2]);
                for (int j = 0; j < num; j++)
                {
                    double d4 = StdRandom.uniform(d2, d3);
                    StdOut.printf("%.2f\n", new object[]
                    {
                    java.lang.Double.valueOf(d4)
                    });
                }
            }
        }
    }
}
