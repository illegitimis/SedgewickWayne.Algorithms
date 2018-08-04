using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SedgewickWayne.Algorithms.AnteRoom
{

    public class Knuth
    {


        public static void shuffle(object[] objarr)
        {
            int num = objarr.Length;
            for (int i = 0; i < num; i++)
            {
                int num2 = i + ByteCodeHelper.d2i(java.lang.Math.random() * (double)(num - i));
                object obj = objarr[num2];
                objarr[num2] = objarr[i];
                objarr[i] = obj;
            }
        }


        private Knuth()
        {
        }


        /**/
        public static void main(string[] strarr)
        {
            string[] array = StdIn.readAllStrings();
            Knuth.shuffle(array);
            for (int i = 0; i < array.Length; i++)
            {
                StdOut.println(array[i]);
            }
        }
    }
}
