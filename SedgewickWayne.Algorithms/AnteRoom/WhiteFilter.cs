using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SedgewickWayne.Algorithms.AnteRoom
{
    public class WhiteFilter
    {


        public WhiteFilter()
        {
        }


        /**/
        public static void main(string[] strarr)
        {
            SET sET = new SET();

            In @in = new In(strarr[0]);
            while (!@in.IsEmpty)
            {
                string text = @in.readString();
                sET.add(text);
            }
            while (!StdIn.IsEmpty)
            {
                string text = StdIn.readString();
                if (sET.contains(text))
                {
                    StdOut.println(text);
                }
            }
        }
    }
}
