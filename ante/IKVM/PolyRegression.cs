using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SedgewickWayne.Algorithms.AnteRoom
{

    public class PolynomialRegression
    {
        //[Modifiers(Modifiers.Private | Modifiers.Final)]
        private int N;
        //[Modifiers(Modifiers.Private | Modifiers.Final)]
        private int degree;
        //[Modifiers(Modifiers.Private | Modifiers.Final)]
        private object beta;
        private double SSE;
        private double SST;

        public virtual double beta(int i)
        {
            this.beta;
            i;
            0;
            throw new NoClassDefFoundError("Jama.Matrix");
        }
        public virtual double R2()
        {
            if (this.SST == (double)0f)
            {
                return (double)1f;
            }
            return (double)1f - this.SSE / this.SST;
        }


        public PolynomialRegression(double[] darr1, double[] darr2, int i)
        {
            this.degree = i;
            this.N = darr1.Length;
            int arg_2C_0 = this.N;
            int arg_27_0 = i + 1;
            int[] array = new int[2];
            int num = arg_27_0;
            array[1] = num;
            num = arg_2C_0;
            array[0] = num;
            double[][] array2 = (double[][])ByteCodeHelper.multianewarray(typeof(double[][]).TypeHandle, array);
            for (int j = 0; j < this.N; j++)
            {
                for (int k = 0; k <= i; k++)
                {
                    array2[j][k] = java.lang.Math.pow(darr1[j], (double)k);
                }
            }
            throw new NoClassDefFoundError("Jama.Matrix");
        }
        public virtual int degree()
        {
            return this.degree;
        }


        public virtual double predict(double d)
        {
            double num = (double)0f;
            for (int i = this.degree; i >= 0; i += -1)
            {
                num = this.beta(i) + d * num;
            }
            return num;
        }


        public override string ToString()
        {
            string str = "";
            int i = this.degree;
            while (i >= 0 && java.lang.Math.abs(this.beta(i)) < 1E-05)
            {
                i += -1;
            }
            for (i = i; i >= 0; i += -1)
            {
                if (i == 0)
                {
                    str = new StringBuilder().append(str).append(java.lang.String.format("%.2f ", new object[]
                    {
                    java.lang.Double.valueOf(this.beta(i))
                    })).toString();
                }
                else if (i == 1)
                {
                    str = new StringBuilder().append(str).append(java.lang.String.format("%.2f N + ", new object[]
                    {
                    java.lang.Double.valueOf(this.beta(i))
                    })).toString();
                }
                else
                {
                    str = new StringBuilder().append(str).append(java.lang.String.format("%.2f N^%d + ", new object[]
                    {
                    java.lang.Double.valueOf(this.beta(i)),
                    Integer.valueOf(i)
                    })).toString();
                }
            }
            return new StringBuilder().append(str).append("  (R^2 = ").append(java.lang.String.format("%.3f", new object[]
            {
            java.lang.Double.valueOf(this.R2())
            })).append(")").toString();
        }


        /**/
        public static void main(string[] strarr)
        {
            double[] darr = new double[]
            {
            10.0,
            20.0,
            40.0,
            80.0,
            160.0,
            200.0
            };
            double[] darr2 = new double[]
            {
            100.0,
            350.0,
            1500.0,
            6700.0,
            20160.0,
            40000.0
            };
            PolynomialRegression obj = new PolynomialRegression(darr, darr2, 3);
            StdOut.println(obj);
        }
    }
}
