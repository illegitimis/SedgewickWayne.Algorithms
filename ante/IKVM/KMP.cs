using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SedgewickWayne.Algorithms.AnteRoom
{
    public class KMP
    {
        //[Modifiers(Modifiers.Private | Modifiers.Final)]
        private int R;
        private int[][] dfa;
        private char[] pattern;
        private string pat;


        public KMP(string str)
        {
            this.R = 256;
            this.pat = str;
            int num = java.lang.String.instancehelper_length(str);
            int arg_35_0 = this.R;
            int arg_30_0 = num;
            int[] array = new int[2];
            int num2 = arg_30_0;
            array[1] = num2;
            num2 = arg_35_0;
            array[0] = num2;
            this.dfa = (int[][])ByteCodeHelper.multianewarray(typeof(int[][]).TypeHandle, array);
            this.dfa[(int)java.lang.String.instancehelper_charAt(str, 0)][0] = 1;
            int num3 = 0;
            for (int i = 1; i < num; i++)
            {
                for (int j = 0; j < this.R; j++)
                {
                    this.dfa[j][i] = this.dfa[j][num3];
                }
                this.dfa[(int)java.lang.String.instancehelper_charAt(str, i)][i] = i + 1;
                num3 = this.dfa[(int)java.lang.String.instancehelper_charAt(str, i)][num3];
            }
        }


        public virtual int search(string str)
        {
            int num = java.lang.String.instancehelper_length(this.pat);
            int num2 = java.lang.String.instancehelper_length(str);
            int num3 = 0;
            int num4 = 0;
            while (num3 < num2 && num4 < num)
            {
                num4 = this.dfa[(int)java.lang.String.instancehelper_charAt(str, num3)][num4];
                num3++;
            }
            if (num4 == num)
            {
                return num3 - num;
            }
            return num2;
        }


        public KMP(char[] charr, int i)
        {
            this.R = i;
            this.pattern = new char[charr.Length];
            int j;
            for (j = 0; j < charr.Length; j++)
            {
                this.pattern[j] = charr[j];
            }
            j = charr.Length;
            int arg_41_0 = j;
            int[] array = new int[2];
            int num = arg_41_0;
            array[1] = num;
            array[0] = i;
            this.dfa = (int[][])ByteCodeHelper.multianewarray(typeof(int[][]).TypeHandle, array);
            this.dfa[(int)charr[0]][0] = 1;
            int num2 = 0;
            for (int k = 1; k < j; k++)
            {
                for (int l = 0; l < i; l++)
                {
                    this.dfa[l][k] = this.dfa[l][num2];
                }
                this.dfa[(int)charr[k]][k] = k + 1;
                num2 = this.dfa[(int)charr[k]][num2];
            }
        }

        public virtual int search(char[] charr)
        {
            int num = this.pattern.Length;
            int num2 = charr.Length;
            int num3 = 0;
            int num4 = 0;
            while (num3 < num2 && num4 < num)
            {
                num4 = this.dfa[(int)charr[num3]][num4];
                num3++;
            }
            if (num4 == num)
            {
                return num3 - num;
            }
            return num2;
        }


        /**/
        public static void main(string[] strarr)
        {
            string text = strarr[0];
            string text2 = strarr[1];
            char[] charr = java.lang.String.instancehelper_toCharArray(text);
            char[] charr2 = java.lang.String.instancehelper_toCharArray(text2);
            KMP kMP = new KMP(text);
            int num = kMP.search(text2);
            KMP kMP2 = new KMP(charr, 256);
            int num2 = kMP2.search(charr2);
            StdOut.println(new StringBuilder().append("text:    ").append(text2).toString());
            StdOut.print("pattern: ");
            for (int i = 0; i < num; i++)
            {
                StdOut.print(" ");
            }
            StdOut.println(text);
            StdOut.print("pattern: ");
            for (int i = 0; i < num2; i++)
            {
                StdOut.print(" ");
            }
            StdOut.println(text);
        }
    }
}
