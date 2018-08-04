using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SedgewickWayne.Algorithms.AnteRoom
{
    public class Vector
    {
        private int N;
        private double[] data;


        public virtual double dot(Vector v)
        {
            if (this.N != v.N)
            {
                string arg_18_0 = "Dimensions don't agree";

                throw new ArgumentException(arg_18_0);
            }
            double num = (double)0f;
            for (int i = 0; i < this.N; i++)
            {
                num += this.data[i] * v.data[i];
            }
            return num;
        }


        public virtual Vector minus(Vector v)
        {
            if (this.N != v.N)
            {
                string arg_18_0 = "Dimensions don't agree";

                throw new ArgumentException(arg_18_0);
            }
            Vector vector = new Vector(this.N);
            for (int i = 0; i < this.N; i++)
            {
                vector.data[i] = this.data[i] - v.data[i];
            }
            return vector;
        }


        public virtual double magnitude()
        {
            return java.lang.Math.sqrt(this.dot(this));
        }


        public Vector(int i)
        {
            this.N = i;
            this.data = new double[this.N];
        }


        public virtual Vector times(double d)
        {
            Vector vector = new Vector(this.N);
            for (int i = 0; i < this.N; i++)
            {
                vector.data[i] = d * this.data[i];
            }
            return vector;
        }


        public Vector(params double[] darr)
        {
            this.N = darr.Length;
            this.data = new double[this.N];
            for (int i = 0; i < this.N; i++)
            {
                this.data[i] = darr[i];
            }
        }


        public virtual Vector plus(Vector v)
        {
            if (this.N != v.N)
            {
                string arg_18_0 = "Dimensions don't agree";

                throw new ArgumentException(arg_18_0);
            }
            Vector vector = new Vector(this.N);
            for (int i = 0; i < this.N; i++)
            {
                vector.data[i] = this.data[i] + v.data[i];
            }
            return vector;
        }


        public virtual double distanceTo(Vector v)
        {
            if (this.N != v.N)
            {
                string arg_18_0 = "Dimensions don't agree";

                throw new ArgumentException(arg_18_0);
            }
            return this.minus(v).magnitude();
        }


        public virtual Vector direction()
        {
            if (this.magnitude() == (double)0f)
            {
                string arg_17_0 = "Zero-vector has no direction";

                throw new java.lang.ArithmeticException(arg_17_0);
            }
            return this.times((double)1f / this.magnitude());
        }
        public virtual int length()
        {
            return this.N;
        }

        public virtual double cartesian(int i)
        {
            return this.data[i];
        }


        public override string ToString()
        {
            string text = "";
            for (int i = 0; i < this.N; i++)
            {
                text = new StringBuilder().append(text).append(this.data[i]).append(" ").toString();
            }
            return text;
        }


        /**/
        public static void main(string[] strarr)
        {
            double[] darr = new double[]
            {
            (double)1f,
            2.0,
            3.0,
            4.0
            };
            double[] darr2 = new double[]
            {
            5.0,
            2.0,
            4.0,
            (double)1f
            };
            Vector vector = new Vector(darr);
            Vector vector2 = new Vector(darr2);
            StdOut.println(new StringBuilder().append("   x       = ").append(vector).toString());
            StdOut.println(new StringBuilder().append("   y       = ").append(vector2).toString());
            Vector vector3 = vector.plus(vector2);
            StdOut.println(new StringBuilder().append("   z       = ").append(vector3).toString());
            vector3 = vector3.times(10.0);
            StdOut.println(new StringBuilder().append(" 10z       = ").append(vector3).toString());
            StdOut.println(new StringBuilder().append("  |x|      = ").append(vector.magnitude()).toString());
            StdOut.println(new StringBuilder().append(" <x, y>    = ").append(vector.dot(vector2)).toString());
            StdOut.println(new StringBuilder().append("dist(x, y) = ").append(vector.distanceTo(vector2)).toString());
            StdOut.println(new StringBuilder().append("dir(x)     = ").append(vector.direction()).toString());
        }
    }
}
