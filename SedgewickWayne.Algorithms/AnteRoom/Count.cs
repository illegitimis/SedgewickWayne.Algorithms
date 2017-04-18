namespace SedgewickWayne.Algorithms.AnteRoom
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    
    public class Count
    {


        public Count()
        {
        }


        /**/
        public static void main(string[] strarr)
        {
            Alphabet.__<clinit>();
            Alphabet alphabet = new Alphabet(strarr[0]);
            int num = alphabet.R();
            int[] array = new int[num];
            string @this = StdIn.readAll();
            int num2 = java.lang.String.instancehelper_length(@this);
            for (int i = 0; i < num2; i++)
            {
                if (alphabet.contains(java.lang.String.instancehelper_charAt(@this, i)))
                {
                    int[] arg_54_0 = array;
                    int num3 = alphabet.toIndex(java.lang.String.instancehelper_charAt(@this, i));
                    int[] array2 = arg_54_0;
                    array2[num3]++;
                }
            }
            for (int i = 0; i < num; i++)
            {
                StdOut.println(new StringBuilder().append(alphabet.toChar(i)).append(" ").append(array[i]).toString());
            }
        }
    }
}
