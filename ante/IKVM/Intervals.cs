
public class Interval1D
{
    /*[EnclosingMethod("Interval1D", null, null), InnerClass(null, Modifiers.Static | Modifiers.Synthetic), Modifiers(Modifiers.Super | Modifiers.Synthetic), SourceFile("Interval1D.java")]*/

    /*[Implements(new string[]
	{
		"java.util.Comparator"
	}), InnerClass(null, Modifiers.Private | Modifiers.Static), Modifiers(Modifiers.Super), Signature("Ljava/lang/Object;Ljava/util/Comparator<LInterval1D;>;"), SourceFile("Interval1D.java")]*/
    internal sealed class LeftComparator, Comparator
	{
/*		[LineNumberTable(122), Modifiers(Modifiers.Synthetic)]*/
		
		internal LeftComparator(Interval1D.1) : this()
		{
    }


    private LeftComparator()
    {
    }


    public virtual int compare(Interval1D interval1D, Interval1D interval1D2)
    {
        if (Interval1D.access_300(interval1D) < Interval1D.access_300(interval1D2))
        {
            return -1;
        }
        if (Interval1D.access_300(interval1D) > Interval1D.access_300(interval1D2))
        {
            return 1;
        }
        if (Interval1D.access_400(interval1D) < Interval1D.access_400(interval1D2))
        {
            return -1;
        }
        if (Interval1D.access_400(interval1D) > Interval1D.access_400(interval1D2))
        {
            return 1;
        }
        return 0;
    }
    /*		[LineNumberTable(122), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/

    public virtual int compare(object obj, object obj2)
    {
        return this.compare((Interval1D)obj, (Interval1D)obj2);
    }

    bool Comparator.Object;)Zequals(object obj)
    {
        return java.lang.Object.instancehelper_equals(this, obj);
    }
}
/*[Implements(new string[]
{
    "java.util.Comparator"
}), InnerClass(null, Modifiers.Private | Modifiers.Static), Modifiers(Modifiers.Super), Signature("Ljava/lang/Object;Ljava/util/Comparator<LInterval1D;>;"), SourceFile("Interval1D.java")]*/
internal sealed class LengthComparator, Comparator
	{
/*		[LineNumberTable(144), Modifiers(Modifiers.Synthetic)]*/
		
		internal LengthComparator(Interval1D.1) : this()
		{
}


private LengthComparator()
{
}


public virtual int compare(Interval1D interval1D, Interval1D interval1D2)
{
    double num = interval1D.Length();
    double num2 = interval1D2.Length();
    if (num < num2)
    {
        return -1;
    }
    if (num > num2)
    {
        return 1;
    }
    return 0;
}
/*		[LineNumberTable(144), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/

public virtual int compare(object obj, object obj2)
{
    return this.compare((Interval1D)obj, (Interval1D)obj2);
}

bool Comparator.Object;)Zequals(object obj)
{
    return java.lang.Object.instancehelper_equals(this, obj);
}
	}
	/*[Implements(new string[]
	{
		"java.util.Comparator"
	}), InnerClass(null, Modifiers.Private | Modifiers.Static), Modifiers(Modifiers.Super), Signature("Ljava/lang/Object;Ljava/util/Comparator<LInterval1D;>;"), SourceFile("Interval1D.java")]*/
	internal sealed class RightComparator, Comparator
	{
/*		[LineNumberTable(133), Modifiers(Modifiers.Synthetic)]*/
		
		internal RightComparator(Interval1D.1) : this()
		{
}


private RightComparator()
{
}


public virtual int compare(Interval1D interval1D, Interval1D interval1D2)
{
    if (Interval1D.access_400(interval1D) < Interval1D.access_400(interval1D2))
    {
        return -1;
    }
    if (Interval1D.access_400(interval1D) > Interval1D.access_400(interval1D2))
    {
        return 1;
    }
    if (Interval1D.access_300(interval1D) < Interval1D.access_300(interval1D2))
    {
        return -1;
    }
    if (Interval1D.access_300(interval1D) > Interval1D.access_300(interval1D2))
    {
        return 1;
    }
    return 0;
}
/*		[LineNumberTable(133), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/

public virtual int compare(object obj, object obj2)
{
    return this.compare((Interval1D)obj, (Interval1D)obj2);
}

bool Comparator.Object;)Zequals(object obj)
{
    return java.lang.Object.instancehelper_equals(this, obj);
}
	}
//[Signature("Ljava/util/Comparator<LInterval1D;>;")]
	internal static Comparator __LEFT_ENDPOINT_ORDER;
//[Signature("Ljava/util/Comparator<LInterval1D;>;")]
internal static Comparator __RIGHT_ENDPOINT_ORDER;
//[Signature("Ljava/util/Comparator<LInterval1D;>;")]
internal static Comparator __LENGTH_ORDER;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
private double left;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
private double right;
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
public static Comparator LEFT_ENDPOINT_ORDER
{

    get
    {
        return Interval1D.__LEFT_ENDPOINT_ORDER;
    }
}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
public static Comparator RIGHT_ENDPOINT_ORDER
{

    get
    {
        return Interval1D.__RIGHT_ENDPOINT_ORDER;
    }
}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
public static Comparator LENGTH_ORDER
{

    get
    {
        return Interval1D.__LENGTH_ORDER;
    }
}




public Interval1D(double d1, double d2)
{
    if (java.lang.Double.isInfinite(d1) || java.lang.Double.isInfinite(d2))
    {
        string arg_24_0 = "Endpoints must be finite";

        throw new ArgumentException(arg_24_0);
    }
    if (java.lang.Double.isNaN(d1) || java.lang.Double.isNaN(d2))
    {
        string arg_46_0 = "Endpoints cannot be NaN";

        throw new ArgumentException(arg_46_0);
    }
    if (d1 <= d2)
    {
        this.left = d1;
        this.right = d2;
        return;
    }
    string arg_70_0 = "Illegal interval";

    throw new ArgumentException(arg_70_0);
}
public virtual double left()
{
    return this.left;
}
public virtual double right()
{
    return this.right;
}

public virtual bool intersects(Interval1D id)
{
    return this.right >= id.left && id.right >= this.left;
}
public virtual bool contains(double d)
{
    return this.left <= d && d <= this.right;
}
public virtual double length()
{
    return this.right - this.left;
}


public override string ToString()
{
    return new StringBuilder().append("[").append(this.left).append(", ").append(this.right).append("]").toString();
}


/**/
public static void main(string[] strarr)
{
    Interval1D[] array = new Interval1D[]
    {
            new Interval1D(15.0, 33.0),
            new Interval1D(45.0, 60.0),
            new Interval1D(20.0, 70.0),
            new Interval1D(46.0, 55.0)
    };
    StdOut.println("Unsorted");
    for (int i = 0; i < array.Length; i++)
    {
        StdOut.println(array[i]);
    }
    StdOut.println();
    StdOut.println("Sort by left endpoint");
    Arrays.sort(array, Interval1D.__LEFT_ENDPOINT_ORDER);
    for (int i = 0; i < array.Length; i++)
    {
        StdOut.println(array[i]);
    }
    StdOut.println();
    StdOut.println("Sort by right endpoint");
    Arrays.sort(array, Interval1D.__RIGHT_ENDPOINT_ORDER);
    for (int i = 0; i < array.Length; i++)
    {
        StdOut.println(array[i]);
    }
    StdOut.println();
    StdOut.println("Sort by length");
    Arrays.sort(array, Interval1D.__LENGTH_ORDER);
    for (int i = 0; i < array.Length; i++)
    {
        StdOut.println(array[i]);
    }
    StdOut.println();
}
/*	[LineNumberTable(24), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
internal static double access_300(Interval1D interval1D)
{
    return interval1D.left;
}
/*	[LineNumberTable(24), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
internal static double access_400(Interval1D interval1D)
{
    return interval1D.right;
}

static Interval1D()
{
    Interval1D.__LEFT_ENDPOINT_ORDER = new Interval1D.LeftComparator(null);
    Interval1D.__RIGHT_ENDPOINT_ORDER = new Interval1D.RightComparator(null);
    Interval1D.__LENGTH_ORDER = new Interval1D.LengthComparator(null);
}
}





public class Interval2D
{
    //[Modifiers(Modifiers.Private | Modifiers.Final)]
    private Interval1D x;
    //[Modifiers(Modifiers.Private | Modifiers.Final)]
    private Interval1D y;


    public Interval2D(Interval1D id1, Interval1D id2)
    {
        this.x = id1;
        this.y = id2;
    }


    public virtual void draw()
    {
        double d = (this.x.left() + this.x.right()) / 2.0;
        double d2 = (this.y.left() + this.y.right()) / 2.0;
        StdDraw.rectangle(d, d2, this.x.Length() / 2.0, this.y.Length() / 2.0);
    }


    public virtual bool contains(Point2D pd)
    {
        return this.x.contains(pd.x()) && this.y.contains(pd.y());
    }


    public virtual double area()
    {
        return this.x.Length() * this.y.Length();
    }


    public virtual bool intersects(Interval2D id)
    {
        return this.x.intersects(id.x) && this.y.intersects(id.y);
    }


    public override string ToString()
    {
        return new StringBuilder().append(this.x).append(" x ").append(this.y).toString();
    }


    /**/
    public static void main(string[] strarr)
    {
        double d = java.lang.Double.parseDouble(strarr[0]);
        double d2 = java.lang.Double.parseDouble(strarr[1]);
        double d3 = java.lang.Double.parseDouble(strarr[2]);
        double d4 = java.lang.Double.parseDouble(strarr[3]);
        int num = Integer.parseInt(strarr[4]);
        Interval1D id = new Interval1D(d, d2);
        Interval1D id2 = new Interval1D(d3, d4);
        Interval2D interval2D = new Interval2D(id, id2);
        interval2D.draw();
        Counter counter = new Counter("hits");
        for (int i = 0; i < num; i++)
        {
            double d5 = StdRandom.uniform((double)0f, (double)1f);
            double d6 = StdRandom.uniform((double)0f, (double)1f);
            Point2D point2D = new Point2D(d5, d6);
            if (interval2D.contains(point2D))
            {
                counter.increment();
            }
            else
            {
                point2D.draw();
            }
        }
        StdOut.println(counter);
        StdOut.printf("box area = %.2f\n", new object[]
        {
            java.lang.Double.valueOf(interval2D.area())
        });
    }
}

