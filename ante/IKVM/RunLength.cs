namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Text;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.ComponentModel;

    public class RunLength
    {
        private const int R = 256;
        private const int lgR = 8;


        public static void compress()
        {
            int num = 0;
            int num2 = 0;
            while (!BinaryStdIn.IsEmpty)
            {
                int num3 = BinaryStdIn.readBoolean() ? 1 : 0;
                if (num3 != num2)
                {
                    BinaryStdOut.write((char)num, 8);
                    num = 1;
                    num2 = ((num2 != 0) ? 0 : 1);
                }
                else
                {
                    if (num == 255)
                    {
                        BinaryStdOut.write((char)num, 8);
                        num = 0;
                        BinaryStdOut.write((char)num, 8);
                    }
                    num = (int)((ushort)(num + 1));
                }
            }
            BinaryStdOut.write((char)num, 8);
            BinaryStdOut.close();
        }


        public static void expand()
        {
            int num = 0;
            while (!BinaryStdIn.IsEmpty)
            {
                int num2 = BinaryStdIn.readInt(8);
                for (int i = 0; i < num2; i++)
                {
                    BinaryStdOut.write(num != 0);
                }
                num = ((num != 0) ? 0 : 1);
            }
            BinaryStdOut.close();
        }


        public RunLength()
        {
        }


        /**/
        public static void main(string[] strarr)
        {
            if (java.lang.String.instancehelper_equals(strarr[0], "-"))
            {
                RunLength.compress();
            }
            else
            {
                if (!java.lang.String.instancehelper_equals(strarr[0], "+"))
                {
                    string arg_36_0 = "Illegal command line argument";

                    throw new ArgumentException(arg_36_0);
                }
                RunLength.expand();
            }
        }
    }

}





