using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SedgewickWayne.Algorithms.AnteRoom
{

    public class RabinKarp
    {
        private string pat;
        private long patHash;
        private int M;
        private long Q;
        private int R;
        private long RM;


        private static long longRandomPrime()
        {
            BigInteger bigInteger = BigInteger.probablePrime(31, new java.util.Random());
            return bigInteger.longValue();
        }


        private long hash(string this2, int num)
        {
            long num2 = 0L;
            for (int i = 0; i < num; i++)
            {
                long expr_1A = (long)this.R * num2 + (long)java.lang.String.instancehelper_charAt(this2, i);
                long expr_21 = this.Q;
                num2 = ((expr_21 != -1L) ? (expr_1A % expr_21) : 0L);
            }
            return num2;
        }


        private bool check(string this2, int num)
        {
            for (int i = 0; i < this.M; i++)
            {
                if (java.lang.String.instancehelper_charAt(this.pat, i) != java.lang.String.instancehelper_charAt(this2, num + i))
                {
                    return false;
                }
            }
            return true;
        }


        public RabinKarp(string str)
        {
            this.pat = str;
            this.R = 256;
            this.M = java.lang.String.instancehelper_length(str);
            this.Q = RabinKarp.longRandomPrime();
            this.RM = 1L;
            for (int i = 1; i <= this.M - 1; i++)
            {
                long expr_54 = (long)this.R * this.RM;
                long expr_5B = this.Q;
                this.RM = ((expr_5B != -1L) ? (expr_54 % expr_5B) : 0L);
            }
            this.patHash = this.hash(str, this.M);
        }


        public virtual int search(string str)
        {
            int num = java.lang.String.instancehelper_length(str);
            if (num < this.M)
            {
                return num;
            }
            long num2 = this.hash(str, this.M);
            if (this.patHash == num2 && this.check(str, 0))
            {
                return 0;
            }
            for (int i = this.M; i < num; i++)
            {
                long arg_73_0 = num2 + this.Q;
                long expr_60 = this.RM * (long)java.lang.String.instancehelper_charAt(str, i - this.M);
                long expr_67 = this.Q;
                long expr_73 = arg_73_0 - ((expr_67 != -1L) ? (expr_60 % expr_67) : 0L);
                long expr_7A = this.Q;
                num2 = ((expr_7A != -1L) ? (expr_73 % expr_7A) : 0L);
                long expr_98 = num2 * (long)this.R + (long)java.lang.String.instancehelper_charAt(str, i);
                long expr_9F = this.Q;
                num2 = ((expr_9F != -1L) ? (expr_98 % expr_9F) : 0L);
                int num3 = i - this.M + 1;
                if (this.patHash == num2 && this.check(str, num3))
                {
                    return num3;
                }
            }
            return num;
        }


        public RabinKarp(int i, char[] charr)
        {
            string arg_10_0 = "Operation not supported yet";

            throw new NotSupportedException(arg_10_0);
        }
        private bool check(int num)
        {
            return true;
        }


        /**/
        public static void main(string[] strarr)
        {
            string text = strarr[0];
            string text2 = strarr[1];
            java.lang.String.instancehelper_toCharArray(text);
            java.lang.String.instancehelper_toCharArray(text2);
            RabinKarp rabinKarp = new RabinKarp(text);
            int num = rabinKarp.search(text2);
            StdOut.println(new StringBuilder().append("text:    ").append(text2).toString());
            StdOut.print("pattern: ");
            for (int i = 0; i < num; i++)
            {
                StdOut.print(" ");
            }
            StdOut.println(text);
        }
    }
}
