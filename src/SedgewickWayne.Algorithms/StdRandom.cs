
namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// http://introcs.cs.princeton.edu/java/stdlib/StdRandom.java.html
    /// </summary>
    public sealed class StdRandom
    {
        const double num = 1E-14;

        private static /*readonly*/ Random r = new Random(DateTime.UtcNow.Millisecond);

        static int seed;
        private static int Seed { get { return seed; }  set { seed = value; r = new Random(value); } }
        
        public static double Cauchy
        {
            get
            {
                return Math.Tan(3.1415926535897931 * (Uniform - 0.5));
            }
        }

        #region Bernoulli
        public static bool bernoulli(double d)
        {
            if (d < (double)0f || d > (double)1f) throw new ArgumentException("Probability must be between 0.0 and 1.0");
            return Uniform < d;
        }
        public static bool Bernoulli
        {
            get
            {
                return bernoulli(0.5);
            }
        }

        #endregion

        public static int discrete(double[] darr)
        {
            double num2 = (double)0f;
            for (int i = 0; i < darr.Length; i++)
            {
                if (darr[i] < (double)0f) throw new ArgumentException(String.Format("array entry: {0} is negative: {1}", i, darr[i]));
                num2 += darr[i];
            }
            if (num2 > (double)1f + num || num2 < (double)1f - num) throw new ArgumentException(String.Format("sum of array entries not equal to one: {0}", num2));

            int j;
            while (true)
            {
                double num3 = Uniform;
                num2 = (double)0f;
                for (j = 0; j < darr.Length; j++)
                {
                    num2 += darr[j];
                    if (num2 > num3)
                    {
                        return j;
                    }
                }
                break;
            }

            return 0;
        }

        public static double exp(double d)
        {
            if (d <= (double)0f)throw new ArgumentException("Rate lambda must be positive");
            return -Math.Log((double)1f - Uniform) / d;
        }

        #region Gauss

        public static double gaussian(double d1, double d2)
        {
            return d1 + d2 * Gaussian;
        }

        public static double Gaussian
        {
            get
            {
                double num;
                double num3;
                do
                {
                    num = uniform(-1.0, (double)1f);
                    double num2 = uniform(-1.0, (double)1f);
                    num3 = num * num + num2 * num2;
                }
                while (num3 >= (double)1f || num3 == (double)0f);

                return num * Math.Sqrt(-2.0 * Math.Log(num3) / num3);
            }
        }

        #endregion
        public static int geometric(double d)
        {
            if (d < (double)0f || d > (double)1f) throw new ArgumentException("Probability must be between 0.0 and 1.0");
            
            return (int)Math.Ceiling(Math.Log(Uniform) / Math.Log(1 - d));
        }

        public static double pareto(double d)
        {
            if (d <= (double)0f) throw new ArgumentException("Shape parameter alpha must be positive");            
            return Math.Pow(1 - Uniform, -1.0 / d) - 1;
        }
        public static int poisson(double d)
        {
            if (d <= (double)0f) throw new ArgumentException("Parameter lambda must be positive");
            
            int num = 0;
            double num2 = (double)1f;
            double num3 = Math.Exp(-d);
            do
            {
                num++;
                num2 *= Uniform;
            }
            while (num2 >= num3);
            return num - 1;
        }
        public static double Random { get { return Uniform; } }
        
        #region shuffle

        public static void shuffle(int[] iarr)
        {
            int N = iarr.Length;
            for (int i = 0; i < N; i++)
            {
                SortingHelper<int>.exch(iarr, i, i + uniform(N - i));
            }
        }

        public static void shuffle<T>(T[] objarr) where T : IComparable<T>
        {
            int N = objarr.Length;
            for (int i = 0; i < N; i++)
            {
                SortingHelper<T>.exch(objarr, i, i + uniform(N - i));
            }
        }

        public static void shuffle(double[] darr)
        {
            int num = darr.Length;
            for (int i = 0; i < num; i++)
            {
                int num2 = i + uniform(num - i);
                double num3 = darr[i];
                darr[i] = darr[num2];
                darr[num2] = num3;
            }
        }

        public static void shuffle(object[] objarr, int i1, int i2)
        {
            if (i1 < 0 || i1 > i2 || i2 >= objarr.Length)
            {
                string arg_17_0 = "Illegal subarray range";

                throw new IndexOutOfRangeException(arg_17_0);
            }
            for (int j = i1; j <= i2; j++)
            {
                int num = j + uniform(i2 - j + 1);
                object obj = objarr[j];
                objarr[j] = objarr[num];
                objarr[num] = obj;
            }
        }

        public static void shuffle(double[] darr, int i1, int i2)
        {
            if (i1 < 0 || i1 > i2 || i2 >= darr.Length)
            {
                string arg_17_0 = "Illegal subarray range";

                throw new IndexOutOfRangeException(arg_17_0);
            }
            for (int j = i1; j <= i2; j++)
            {
                int num = j + uniform(i2 - j + 1);
                double num2 = darr[j];
                darr[j] = darr[num];
                darr[num] = num2;
            }
        }

        public static void shuffle(int[] iarr, int i1, int i2)
        {
            if (i1 < 0 || i1 > i2 || i2 >= iarr.Length)
            {
                string arg_17_0 = "Illegal subarray range";

                throw new IndexOutOfRangeException(arg_17_0);
            }
            for (int j = i1; j <= i2; j++)
            {
                int num = j + uniform(i2 - j + 1);
                int num2 = iarr[j];
                iarr[j] = iarr[num];
                iarr[num] = num2;
            }
        }

        #endregion

        #region uniform

        public static double Uniform { get { return r.NextDouble(); } }
        public static int uniform(int i1, int i2)
        {
            if (i2 <= i1)
            {
                string arg_0E_0 = "Invalid range";

                throw new ArgumentException(arg_0E_0);
            }
            if ((long)i2 - (long)i1 >= (long)((ulong)2147483647))
            {
                string arg_2B_0 = "Invalid range";

                throw new ArgumentException(arg_2B_0);
            }
            return i1 + uniform(i2 - i1);
        }

        public static double uniform(double d1, double d2)
        {
            if (d2 <= d1) throw new ArgumentException("Invalid range");
            return d1 + Uniform * (d2 - d1);
        }

        public static int uniform(int i)
        {
            if (i <= 0) throw new ArgumentException("Parameter N must be positive");
            return r.Next(i);
        }

        #endregion
                       
    }
}
