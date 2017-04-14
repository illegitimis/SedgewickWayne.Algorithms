/*[Implements(new string[]
{
	"java.lang.Comparable"
}), Signature("Ljava/lang/Object;Ljava/lang/Comparable<LEdge;>;")]*/
public class Edge : IComparable, IComparable<Edge>
{
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private int v;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private int w;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private double weight;
	public virtual int either()
	{
		return this.v;
	}
	
	
	public virtual int other(int i)
	{
		if (i == this.v)
		{
			return this.w;
		}
		if (i == this.w)
		{
			return this.v;
		}
		string arg_2A_0 = "Illegal endpoint";
		
		throw new ArgumentException(arg_2A_0);
	}
	public virtual double weight()
	{
		return this.weight;
	}
	
	
	public Edge(int i1, int i2, double d)
	{
		if (i1 < 0)
		{
			string arg_16_0 = "Vertex name must be a nonnegative integer";
			
			throw new IndexOutOfRangeException(arg_16_0);
		}
		if (i2 < 0)
		{
			string arg_2A_0 = "Vertex name must be a nonnegative integer";
			
			throw new IndexOutOfRangeException(arg_2A_0);
		}
		if (java.lang.Double.isNaN(d))
		{
			string arg_43_0 = "Weight is NaN";
			
			throw new ArgumentException(arg_43_0);
		}
		this.v = i1;
		this.w = i2;
		this.weight = d;
	}
	
	
	public virtual int compareTo(Edge e)
	{
		if (this.weight() < e.weight())
		{
			return -1;
		}
		if (this.weight() > e.weight())
		{
			return 1;
		}
		return 0;
	}
	
	
	public override string ToString()
	{
		return java.lang.String.format("%d-%d %.5f", new object[]
		{
			Integer.valueOf(this.v),
			Integer.valueOf(this.w),
			java.lang.Double.valueOf(this.weight)
		});
	}
	
	
	/**/public static void main(string[] strarr)
	{
		Edge obj = new Edge(12, 23, 3.14);
		StdOut.println(obj);
	}
/*	[LineNumberTable(23), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic), EditorBrowsable(EditorBrowsableState.Never)]*/
	
	public virtual int compareTo(object obj)
	{
		return this.compareTo((Edge)obj);
	}
	
	int IComparable.Object;)IcompareTo(object obj)
	{
		return this.compareTo(obj);
	}
}