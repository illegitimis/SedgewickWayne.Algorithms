
namespace SedgewickWayne.Algorithms.AnteRoom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /*[Implements(new string[]
    {
        "java.lang.Iterable"
    }), Signature("<Key::Ljava/lang/Comparable<TKey;>;>Ljava/lang/Object;Ljava/lang/Iterable<TKey;>;")]*/
    public class SET : IEnumerable
    {
        //[Signature("Ljava/util/TreeSet<TKey;>;")]
        private TreeSet set;


        public SET()
        {
            this.set = new TreeSet();
        }
        /*	[Signature("(TKey;)V")]*/

        public virtual void add(IComparable c)
        {
            if (c == null)
            {
                string arg_0D_0 = "called add() with a null key";

                throw new NullPointerException(arg_0D_0);
            }
            this.set.add(c);
        }
        /*	[Signature("(TKey;)Z")]*/

        public virtual bool contains(IComparable c)
        {
            if (c == null)
            {
                string arg_0D_0 = "called contains() with a null key";

                throw new NullPointerException(arg_0D_0);
            }
            return this.set.contains(c);
        }
        /*	[LineNumberTable(111), Signature("()Ljava/util/Iterator<TKey;>;")]*/

        public virtual Iterator iterator()
        {
            return this.set.iterator();
        }


        public virtual int Size
        {
		return this.set.Size;
            }



    public virtual bool IsEmpty
        {
		return this.Size == 0;
        }
        /*	[Signature("(TKey;)TKey;")]*/

        public virtual IComparable ceiling(IComparable c)
        {
            if (c == null)
            {
                string arg_0D_0 = "called ceiling() with a null key";

                throw new NullPointerException(arg_0D_0);
            }
            IComparable comparable = (IComparable)this.set.ceiling(c);
            if (comparable == null)
            {
                string arg_47_0 = new StringBuilder().append("all keys are less than ").append(c).toString();

                throw new InvalidOperationException(arg_47_0);
            }
            return comparable;
        }
        /*	[Signature("(TKey;)TKey;")]*/

        public virtual IComparable floor(IComparable c)
        {
            if (c == null)
            {
                string arg_0D_0 = "called floor() with a null key";

                throw new NullPointerException(arg_0D_0);
            }
            IComparable comparable = (IComparable)this.set.floor(c);
            if (comparable == null)
            {
                string arg_47_0 = new StringBuilder().append("all keys are greater than ").append(c).toString();

                throw new InvalidOperationException(arg_47_0);
            }
            return comparable;
        }
        /*	[Signature("(TKey;)V")]*/

        public virtual void delete(IComparable c)
        {
            if (c == null)
            {
                string arg_0D_0 = "called delete() with a null key";

                throw new NullPointerException(arg_0D_0);
            }
            this.set.remove(c);
        }
        /*	[Signature("()TKey;")]*/

        public virtual IComparable Max
        {
		if (this.IsEmpty)

        {
                string arg_12_0 = "called Max with empty set";

                throw new InvalidOperationException(arg_12_0);
            }
		return (IComparable)this.set.last();
            }
/*	[Signature("()TKey;")]*/

    public virtual IComparable Min
        {
		if (this.IsEmpty)

        {
                string arg_12_0 = "called Min with empty set";

                throw new InvalidOperationException(arg_12_0);
            }
		return (IComparable)this.set.first();
            }
/*	[Signature("(LSET<TKey;>;)LSET<TKey;>;")]*/

    public virtual SET union(SET set)
        {
            if (set == null)
            {
                string arg_0D_0 = "called union() with a null argument";

                throw new NullPointerException(arg_0D_0);
            }
            SET sET = new SET();
            Iterator iterator = this.iterator();
            while (iterator.hasNext())
            {
                IComparable c = (IComparable)iterator.next();
                sET.add(c);
            }
            iterator = set.iterator();
            while (iterator.hasNext())
            {
                IComparable c = (IComparable)iterator.next();
                sET.add(c);
            }
            return sET;
        }
        /*	[Signature("(LSET<TKey;>;)LSET<TKey;>;")]*/

        public virtual SET intersects(SET set)
        {
            if (set == null)
            {
                string arg_0D_0 = "called intersects() with a null argument";

                throw new NullPointerException(arg_0D_0);
            }
            SET sET = new SET();
            if (this.Size < set.Size)
            {
                Iterator iterator = this.iterator();
                while (iterator.hasNext())
                {
                    IComparable c = (IComparable)iterator.next();
                    if (set.contains(c))
                    {
                        sET.add(c);
                    }
                }
            }
            else
            {
                Iterator iterator = set.iterator();
                while (iterator.hasNext())
                {
                    IComparable c = (IComparable)iterator.next();
                    if (this.contains(c))
                    {
                        sET.add(c);
                    }
                }
            }
            return sET;
        }


        public override bool equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }
            if (obj == null)
            {
                return false;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            SET sET = (SET)obj;
            if (this.Size != sET.Size)
            {
                return false;
            }
            try
            {
                Iterator iterator = this.iterator();
                while (iterator.hasNext())
                {
                    IComparable c = (IComparable)iterator.next();
                    if (!sET.contains(c))
                    {
                        return false;
                    }
                }
            }
            catch (System.Exception arg_5F_0)
            {
                if (ByteCodeHelper.MapException<ClassCastException>(arg_5F_0, ByteCodeHelper.MapFlags.Unused) == null)
                {
                    throw;
                }
                return false;
            }
            return true;
        }


        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            Iterator iterator = this.iterator();
            while (iterator.hasNext())
            {
                IComparable obj = (IComparable)iterator.next();
                stringBuilder.append(new StringBuilder().append(obj).append(" ").toString());
            }
            return stringBuilder.toString();
        }


        /**/
        public static void main(string[] strarr)
        {
            SET sET = new SET();
            sET.add("www.cs.princeton.edu");
            sET.add("www.cs.princeton.edu");
            sET.add("www.princeton.edu");
            sET.add("www.math.princeton.edu");
            sET.add("www.yale.edu");
            sET.add("www.amazon.com");
            sET.add("www.simpsons.com");
            sET.add("www.stanford.edu");
            sET.add("www.google.com");
            sET.add("www.ibm.com");
            sET.add("www.apple.com");
            sET.add("www.slashdot.com");
            sET.add("www.whitehouse.gov");
            sET.add("www.espn.com");
            sET.add("www.snopes.com");
            sET.add("www.movies.com");
            sET.add("www.cnn.com");
            sET.add("www.iitb.ac.in");
            StdOut.println(sET.contains("www.cs.princeton.edu"));
            StdOut.println(!sET.contains("www.harvardsucks.com"));
            StdOut.println(sET.contains("www.simpsons.com"));
            StdOut.println();
            StdOut.println(new StringBuilder().append("ceiling(www.simpsonr.com) = ").append((string)sET.ceiling("www.simpsonr.com")).toString());
            StdOut.println(new StringBuilder().append("ceiling(www.simpsons.com) = ").append((string)sET.ceiling("www.simpsons.com")).toString());
            StdOut.println(new StringBuilder().append("ceiling(www.simpsont.com) = ").append((string)sET.ceiling("www.simpsont.com")).toString());
            StdOut.println(new StringBuilder().append("floor(www.simpsonr.com)   = ").append((string)sET.floor("www.simpsonr.com")).toString());
            StdOut.println(new StringBuilder().append("floor(www.simpsons.com)   = ").append((string)sET.floor("www.simpsons.com")).toString());
            StdOut.println(new StringBuilder().append("floor(www.simpsont.com)   = ").append((string)sET.floor("www.simpsont.com")).toString());
            StdOut.println();
            Iterator iterator = sET.iterator();
            while (iterator.hasNext())
            {
                string obj = (string)iterator.next();
                StdOut.println(obj);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new IterableEnumerator(this);
        }
    }

}
