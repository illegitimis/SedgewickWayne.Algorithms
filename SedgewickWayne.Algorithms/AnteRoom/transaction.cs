using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SedgewickWayne.Algorithms.AnteRoom
{

    /*[Implements(new string[]
    {
        "java.lang.Comparable"
    }), Signature("Ljava/lang/Object;Ljava/lang/Comparable<LTransaction;>;")]*/
    public class Transaction, Comparable
{
	/*[Implements(new string[]
	{
		"java.util.Comparator"
	}), InnerClass(null, Modifiers.Public | Modifiers.Static), Signature("Ljava/lang/Object;Ljava/util/Comparator<LTransaction;>;"), SourceFile("Transaction.java")]*/
	public class HowMuchOrder, Comparator
	{
		
		
		public HowMuchOrder()
    {
    }


    public virtual int compare(Transaction t1, Transaction t2)
    {
        if (Transaction.access_200(t1) < Transaction.access_200(t2))
        {
            return -1;
        }
        if (Transaction.access_200(t1) > Transaction.access_200(t2))
        {
            return 1;
        }
        return 0;
    }
    /*		[LineNumberTable(158), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic), EditorBrowsable(EditorBrowsableState.Never)]*/

    public virtual int compare(object obj1, object obj2)
    {
        return this.compare((Transaction)obj1, (Transaction)obj2);
    }

    bool Comparator.Object;)Zequals(object obj)
    {
        return java.lang.Object.instancehelper_equals(this, obj);
    }
}
/*[Implements(new string[]
{
    "java.util.Comparator"
}), InnerClass(null, Modifiers.Public | Modifiers.Static), Signature("Ljava/lang/Object;Ljava/util/Comparator<LTransaction;>;"), SourceFile("Transaction.java")]*/
public class WhenOrder, Comparator
	{
		
		
		public WhenOrder()
{
}


public virtual int compare(Transaction t1, Transaction t2)
{
    return Transaction.access_100(t1).CompareTo(Transaction.access_100(t2));
}
/*		[LineNumberTable(149), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic), EditorBrowsable(EditorBrowsableState.Never)]*/

public virtual int compare(object obj1, object obj2)
{
    return this.compare((Transaction)obj1, (Transaction)obj2);
}

bool Comparator.Object;)Zequals(object obj)
{
    return java.lang.Object.instancehelper_equals(this, obj);
}
	}
	/*[Implements(new string[]
	{
		"java.util.Comparator"
	}), InnerClass(null, Modifiers.Public | Modifiers.Static), Signature("Ljava/lang/Object;Ljava/util/Comparator<LTransaction;>;"), SourceFile("Transaction.java")]*/
	public class WhoOrder, Comparator
	{
		
		
		public WhoOrder()
{
}


public virtual int compare(Transaction t1, Transaction t2)
{
    return java.lang.String.instancehelper_compareTo(Transaction.access_000(t1), Transaction.access_000(t2));
}
/*		[LineNumberTable(140), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic), EditorBrowsable(EditorBrowsableState.Never)]*/

public virtual int compare(object obj1, object obj2)
{
    return this.compare((Transaction)obj1, (Transaction)obj2);
}

bool Comparator.Object;)Zequals(object obj)
{
    return java.lang.Object.instancehelper_equals(this, obj);
}
	}
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private string who;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
private Date when;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
private double amount;


public Transaction(string str)
{
    string[] array = java.lang.String.instancehelper_split(str, "\\s+");
    this.who = array[0];
    Date.__<clinit>();
    this.when = new Date(array[1]);
    double num = java.lang.Double.parseDouble(array[2]);
    if (num == (double)0f)
    {
        this.amount = (double)0f;
    }
    else
    {
        this.amount = num;
    }
    if (java.lang.Double.isNaN(this.amount) || java.lang.Double.isInfinite(this.amount))
    {
        string arg_7C_0 = "Amount cannot be NaN or infinite";

        throw new ArgumentException(arg_7C_0);
    }
}

public virtual int compareTo(Transaction t)
{
    if (this.amount < t.amount)
    {
        return -1;
    }
    if (this.amount > t.amount)
    {
        return 1;
    }
    return 0;
}


public Transaction(string str, Date d1, double d2)
{
    if (java.lang.Double.isNaN(d2) || java.lang.Double.isInfinite(d2))
    {
        string arg_24_0 = "Amount cannot be NaN or infinite";

        throw new ArgumentException(arg_24_0);
    }
    this.who = str;
    this.when = d1;
    if (d2 == (double)0f)
    {
        this.amount = (double)0f;
    }
    else
    {
        this.amount = d2;
    }
}
public virtual string who()
{
    return this.who;
}
public virtual Date when()
{
    return this.when;
}
public virtual double amount()
{
    return this.amount;
}


public override string ToString()
{
    return java.lang.String.format("%-10s %10s %8.2f", new object[]
    {
            this.who,
            this.when,
            java.lang.Double.valueOf(this.amount)
    });
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
    Transaction transaction = (Transaction)obj;
    return this.amount == transaction.amount && java.lang.String.instancehelper_equals(this.who, transaction.who) && this.when.Equals(transaction.when);
}


public override int hashCode()
{
    int num = 17;
    num = 31 * num + java.lang.String.instancehelper_hashCode(this.who);
    num = 31 * num + this.when.hashCode();
    return 31 * num + java.lang.Double.valueOf(this.amount).hashCode();
}


/**/
public static void main(string[] strarr)
{
    Transaction[] array = new Transaction[]
    {
            new Transaction("Turing   6/17/1990  644.08"),
            new Transaction("Tarjan   3/26/2002 4121.85"),
            new Transaction("Knuth    6/14/1999  288.34"),
            new Transaction("Dijkstra 8/22/2007 2678.40")
    };
    StdOut.println("Unsorted");
    for (int i = 0; i < array.Length; i++)
    {
        StdOut.println(array[i]);
    }
    StdOut.println();
    StdOut.println("Sort by date");
    Arrays.sort(array, new Transaction.WhenOrder());
    for (int i = 0; i < array.Length; i++)
    {
        StdOut.println(array[i]);
    }
    StdOut.println();
    StdOut.println("Sort by customer");
    Arrays.sort(array, new Transaction.WhoOrder());
    for (int i = 0; i < array.Length; i++)
    {
        StdOut.println(array[i]);
    }
    StdOut.println();
    StdOut.println("Sort by amount");
    Arrays.sort(array, new Transaction.HowMuchOrder());
    for (int i = 0; i < array.Length; i++)
    {
        StdOut.println(array[i]);
    }
    StdOut.println();
}
/*	[LineNumberTable(23), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic), EditorBrowsable(EditorBrowsableState.Never)]*/

public virtual int compareTo(object obj)
{
    return this.CompareTo((Transaction)obj);
}
/*	[LineNumberTable(23), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
internal static string access_000(Transaction transaction)
{
    return transaction.who;
}
/*	[LineNumberTable(23), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
internal static Date access_100(Transaction transaction)
{
    return transaction.when;
}
/*	[LineNumberTable(23), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
internal static double access_200(Transaction transaction)
{
    return transaction.amount;
}

int IComparable.Object;)IcompareTo(object obj)
{
    return this.CompareTo(obj);
}
}
}
