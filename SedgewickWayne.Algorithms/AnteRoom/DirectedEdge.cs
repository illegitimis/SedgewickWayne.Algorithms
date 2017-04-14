public class DirectedEdge
{
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private int v;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private int w;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private double weight;
	public virtual int from()
	{
		return this.v;
	}
	public virtual int to()
	{
		return this.w;
	}
	public virtual double weight()
	{
		return this.weight;
	}
	
	
	public DirectedEdge(int i1, int i2, double d)
	{
		if (i1 < 0)
		{
			string arg_16_0 = "Vertex names must be nonnegative integers";
			
			throw new IndexOutOfRangeException(arg_16_0);
		}
		if (i2 < 0)
		{
			string arg_2A_0 = "Vertex names must be nonnegative integers";
			
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
	
	
	public override string ToString()
	{
		return new StringBuilder().append(this.v).append("->").append(this.w).append(" ").append(java.lang.String.format("%5.2f", new object[]
		{
			java.lang.Double.valueOf(this.weight)
		})).toString();
	}
	
	
	/**/public static void main(string[] strarr)
	{
		DirectedEdge obj = new DirectedEdge(12, 23, 3.14);
		StdOut.println(obj);
	}
}