
namespace SedgewickWayne.Algorithms.AnteRoom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class SuffixArrayX
    {
        private const int CUTOFF = 5;
        //[Modifiers(Modifiers.Private | Modifiers.Final)]
        private char[] text;
        //[Modifiers(Modifiers.Private | Modifiers.Final)]
        private int[] index;
        //[Modifiers(Modifiers.Private | Modifiers.Final)]
        private int N;
        //[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
        internal static bool s_assertionsDisabled;




        private void sort(int num, int num2, int num3)
        {
            if (num2 <= num + 5)
            {
                this.insertion(num, num2, num3);
                return;
            }
            int num4 = num;
            int num5 = num2;
            int num6 = (int)this.text[this.index[num] + num3];
            int i = num + 1;
            while (i <= num5)
            {
                int num7 = (int)this.text[this.index[i] + num3];
                if (num7 < num6)
                {
                    int arg_56_1 = num4;
                    num4++;
                    int arg_56_2 = i;
                    i++;
                    this.exch(arg_56_1, arg_56_2);
                }
                else if (num7 > num6)
                {
                    int arg_69_1 = i;
                    int arg_69_2 = num5;
                    num5 += -1;
                    this.exch(arg_69_1, arg_69_2);
                }
                else
                {
                    i++;
                }
            }
            this.sort(num, num4 - 1, num3);
            if (num6 > 0)
            {
                this.sort(num4, num5, num3 + 1);
            }
            this.sort(num5 + 1, num2, num3);
        }


        private void insertion(int num, int num2, int num3)
        {
            for (int i = num; i <= num2; i++)
            {
                int num4 = i;
                while (num4 > num && this.less(this.index[num4], this.index[num4 - 1], num3))
                {
                    this.exch(num4, num4 - 1);
                    num4 += -1;
                }
            }
        }

        private void exch(int num, int num2)
        {
            int num3 = this.index[num];
            this.index[num] = this.index[num2];
            this.index[num2] = num3;
        }

        private bool less(int num, int num2, int num3)
        {
            if (num == num2)
            {
                return false;
            }
            num += num3;
            num2 += num3;
            while (num < this.N && num2 < this.N)
            {
                if (this.text[num] < this.text[num2])
                {
                    return true;
                }
                if (this.text[num] > this.text[num2])
                {
                    return false;
                }
                num++;
                num2++;
            }
            return num > num2;
        }

        private int lcp(int num, int num2)
        {
            int num3 = 0;
            while (num < this.N && num2 < this.N)
            {
                if (this.text[num] != this.text[num2])
                {
                    return num3;
                }
                num++;
                num2++;
                num3++;
            }
            return num3;
        }


        private int compare(string this2, int num)
        {
            int num2 = java.lang.String.instancehelper_length(this2);
            int num3 = 0;
            while (num < this.N && num3 < num2)
            {
                if (java.lang.String.instancehelper_charAt(this2, num3) != this.text[num])
                {
                    return (int)(java.lang.String.instancehelper_charAt(this2, num3) - this.text[num]);
                }
                num++;
                num3++;
            }
            if (num < this.N)
            {
                return -1;
            }
            if (num3 < num2)
            {
                return 1;
            }
            return 0;
        }


        public SuffixArrayX(string str)
        {
            this.N = java.lang.String.instancehelper_length(str);
            str = new StringBuilder().append(str).append('\0').toString();
            this.text = java.lang.String.instancehelper_toCharArray(str);
            this.index = new int[this.N];
            for (int i = 0; i < this.N; i++)
            {
                this.index[i] = i;
            }
            this.sort(0, this.N - 1, 0);
        }


        public virtual int index(int i)
        {
            if (i < 0 || i >= this.N)
            {

                throw new IndexOutOfRangeException();
            }
            return this.index[i];
        }


        public virtual int rank(string str)
        {
            int i = 0;
            int num = this.N - 1;
            while (i <= num)
            {
                int num2 = i + (num - i) / 2;
                int num3 = this.compare(str, this.index[num2]);
                if (num3 < 0)
                {
                    num = num2 - 1;
                }
                else
                {
                    if (num3 <= 0)
                    {
                        return num2;
                    }
                    i = num2 + 1;
                }
            }
            return i;
        }


        public virtual string select(int i)
        {
            if (i < 0 || i >= this.N)
            {

                throw new IndexOutOfRangeException();
            }
            return java.lang.String.newhelper(this.text, this.index[i], this.N - this.index[i]);
        }


        public virtual int lcp(int i)
        {
            if (i < 1 || i >= this.N)
            {

                throw new IndexOutOfRangeException();
            }
            return this.lcp(this.index[i], this.index[i - 1]);
        }
        public virtual int length()
        {
            return this.N;
        }


        /**/
        public static void main(string[] strarr)
        {
            string text = java.lang.String.instancehelper_trim(java.lang.String.instancehelper_replaceAll(StdIn.readAll(), "\n", " "));
            SuffixArrayX suffixArrayX = new SuffixArrayX(text);
            SuffixArray suffixArray = new SuffixArray(text);
            int num = 1;
            int i = 0;
            while (num != 0 && i < java.lang.String.instancehelper_length(text))
            {
                if (suffixArray.index(i) != suffixArrayX.index(i))
                {
                    StdOut.println(new StringBuilder().append("suffixReference(").append(i).append(") = ").append(suffixArray.index(i)).toString());
                    StdOut.println(new StringBuilder().append("suffix(").append(i).append(") = ").append(suffixArrayX.index(i)).toString());
                    string obj = new StringBuilder().append("\"").append(java.lang.String.instancehelper_substring(text, suffixArrayX.index(i), java.lang.Math.min(suffixArrayX.index(i) + 50, java.lang.String.instancehelper_length(text)))).append("\"").toString();
                    string text2 = new StringBuilder().append("\"").append(java.lang.String.instancehelper_substring(text, suffixArray.index(i), java.lang.Math.min(suffixArray.index(i) + 50, java.lang.String.instancehelper_length(text)))).append("\"").toString();
                    StdOut.println(obj);
                    StdOut.println(text2);
                    num = 0;
                }
                i++;
            }
            StdOut.println("  i ind lcp rnk  select");
            StdOut.println("---------------------------");
            for (i = 0; i < java.lang.String.instancehelper_length(text); i++)
            {
                int num2 = suffixArrayX.index(i);
                string text2 = new StringBuilder().append("\"").append(java.lang.String.instancehelper_substring(text, num2, java.lang.Math.min(num2 + 50, java.lang.String.instancehelper_length(text)))).append("\"").toString();
                int i2 = suffixArrayX.rank(java.lang.String.instancehelper_substring(text, num2));
                if (!SuffixArrayX.s_assertionsDisabled && !java.lang.String.instancehelper_equals(java.lang.String.instancehelper_substring(text, num2), suffixArrayX.select(i)))
                {

                    throw new AssertionError();
                }
                if (i == 0)
                {
                    StdOut.printf("%3d %3d %3s %3d  %s\n", new object[]
                    {
                    Integer.valueOf(i),
                    Integer.valueOf(num2),
                    "-",
                    Integer.valueOf(i2),
                    text2
                    });
                }
                else
                {
                    int i3 = suffixArrayX.lcp(i);
                    StdOut.printf("%3d %3d %3d %3d  %s\n", new object[]
                    {
                    Integer.valueOf(i),
                    Integer.valueOf(num2),
                    Integer.valueOf(i3),
                    Integer.valueOf(i2),
                    text2
                    });
                }
            }
        }

        static SuffixArrayX()
        {
            SuffixArrayX.s_assertionsDisabled = !ClassLiteral<SuffixArrayX>.Value.desiredAssertionStatus();
        }
    }
}
