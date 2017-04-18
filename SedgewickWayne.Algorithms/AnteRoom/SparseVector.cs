
namespace SedgewickWayne.Algorithms.AnteRoom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SparseVector
    {
        private int N;
        //[Signature("LST<Ljava/lang/Integer;Ljava/lang/Double;>;")]
        private ST st;


        public virtual double get(int i)
        {
            if (i < 0 || i >= this.N)
            {
                string arg_17_0 = "Illegal index";

                throw new IndexOutOfRangeException(arg_17_0);
            }
            if (this.st.contains(Integer.valueOf(i)))
            {
                return ((java.lang.Double)this.st.get(Integer.valueOf(i))).doubleValue();
            }
            return (double)0f;
        }


        public virtual double dot(SparseVector sv)
        {
            if (this.N != sv.N)
            {
                string arg_18_0 = "Vector lengths disagree";

                throw new ArgumentException(arg_18_0);
            }
            double num = (double)0f;
            if (this.st.Size <= sv.st.Size)
            {
                Iterator iterator = this.st.keys().iterator();
                while (iterator.hasNext())
                {
                    int i = ((Integer)iterator.next()).intValue();
                    if (sv.st.contains(Integer.valueOf(i)))
                    {
                        num += this.get(i) * sv.get(i);
                    }
                }
            }
            else
            {
                Iterator iterator = sv.st.keys().iterator();
                while (iterator.hasNext())
                {
                    int i = ((Integer)iterator.next()).intValue();
                    if (this.st.contains(Integer.valueOf(i)))
                    {
                        num += this.get(i) * sv.get(i);
                    }
                }
            }
            return num;
        }


        public SparseVector(int i)
        {
            this.N = i;
            this.st = new ST();
        }


        public virtual void put(int i, double d)
        {
            if (i < 0 || i >= this.N)
            {
                string arg_17_0 = "Illegal index";

                throw new IndexOutOfRangeException(arg_17_0);
            }
            if (d == (double)0f)
            {
                this.st.delete(Integer.valueOf(i));
            }
            else
            {
                this.st.put(Integer.valueOf(i), java.lang.Double.valueOf(d));
            }
        }


        public virtual SparseVector plus(SparseVector sv)
        {
            if (this.N != sv.N)
            {
                string arg_18_0 = "Vector lengths disagree";

                throw new ArgumentException(arg_18_0);
            }
            SparseVector sparseVector = new SparseVector(this.N);
            Iterator iterator = this.st.keys().iterator();
            while (iterator.hasNext())
            {
                int i = ((Integer)iterator.next()).intValue();
                sparseVector.put(i, this.get(i));
            }
            iterator = sv.st.keys().iterator();
            while (iterator.hasNext())
            {
                int i = ((Integer)iterator.next()).intValue();
                sparseVector.put(i, sv.get(i) + sparseVector.get(i));
            }
            return sparseVector;
        }


        public virtual int nnz()
        {
            return this.st.Size;
        }
        public virtual int Size
        {
		return this.N;
        }


        public virtual double dot(double[] darr)
        {
            double num = (double)0f;
            Iterator iterator = this.st.keys().iterator();
            while (iterator.hasNext())
            {
                int num2 = ((Integer)iterator.next()).intValue();
                num += darr[num2] * this.get(num2);
            }
            return num;
        }


        public virtual double norm()
        {
            return java.lang.Math.sqrt(this.dot(this));
        }


        public virtual SparseVector scale(double d)
        {
            SparseVector sparseVector = new SparseVector(this.N);
            Iterator iterator = this.st.keys().iterator();
            while (iterator.hasNext())
            {
                int i = ((Integer)iterator.next()).intValue();
                sparseVector.put(i, d * this.get(i));
            }
            return sparseVector;
        }


        public override string ToString()
        {
            string text = "";
            Iterator iterator = this.st.keys().iterator();
            while (iterator.hasNext())
            {
                int i = ((Integer)iterator.next()).intValue();
                text = new StringBuilder().append(text).append("(").append(i).append(", ").append(this.st.get(Integer.valueOf(i))).append(") ").toString();
            }
            return text;
        }


        /**/
        public static void main(string[] strarr)
        {
            SparseVector sparseVector = new SparseVector(10);
            SparseVector sparseVector2 = new SparseVector(10);
            sparseVector.put(3, 0.5);
            sparseVector.put(9, 0.75);
            sparseVector.put(6, 0.11);
            sparseVector.put(6, (double)0f);
            sparseVector2.put(3, 0.6);
            sparseVector2.put(4, 0.9);
            StdOut.println(new StringBuilder().append("a = ").append(sparseVector).toString());
            StdOut.println(new StringBuilder().append("b = ").append(sparseVector2).toString());
            StdOut.println(new StringBuilder().append("a dot b = ").append(sparseVector.dot(sparseVector2)).toString());
            StdOut.println(new StringBuilder().append("a + b   = ").append(sparseVector.plus(sparseVector2)).toString());
        }
    }
}
