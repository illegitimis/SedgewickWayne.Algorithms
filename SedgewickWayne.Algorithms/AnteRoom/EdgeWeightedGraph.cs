public class EdgeWeightedGraph
{
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private int V;
	private int E;
//[Signature("[LBag<LEdge;>;")]
	private Bag[] adj;
	public virtual int V()
	{
		return this.V;
	}
/*	[Signature("()Ljava/lang/Iterable<LEdge;>;")]*/
	
	public virtual Iterable edges()
	{
		Bag bag = new Bag();
		for (int i = 0; i < this.V; i++)
		{
			int num = 0;
			Iterator iterator = this.adj(i).iterator();
			while (iterator.hasNext())
			{
				Edge edge = (Edge)iterator.next();
				if (edge.other(i) > i)
				{
					bag.add(edge);
				}
				else if (edge.other(i) == i)
				{
					bool expr_5B = num != 0;
					int expr_5D = 2;
					if (expr_5D == -1 || (expr_5B ? 1 : 0) % expr_5D == 0)
					{
						bag.add(edge);
					}
					num++;
				}
			}
		}
		return bag;
	}
	
	
	public EdgeWeightedGraph(In i) : this(i.readInt())
	{
		int num = i.readInt();
		if (num < 0)
		{
			string arg_23_0 = "Number of edges must be nonnegative";
			
			throw new ArgumentException(arg_23_0);
		}
		for (int j = 0; j < num; j++)
		{
			int i2 = i.readInt();
			int i3 = i.readInt();
			double d = i.readDouble();
			Edge e = new Edge(i2, i3, d);
			this.addEdge(e);
		}
	}
	
	
	public EdgeWeightedGraph(int i)
	{
		if (i < 0)
		{
			string arg_16_0 = "Number of vertices must be nonnegative";
			
			throw new ArgumentException(arg_16_0);
		}
		this.V = i;
		this.E = 0;
		this.adj = (Bag[])new Bag[i];
		for (int j = 0; j < i; j++)
		{
			this.adj[j] = new Bag();
		}
	}
	
	
	public virtual void addEdge(Edge e)
	{
		int num = e.either();
		int num2 = e.other(num);
		if (num < 0 || num >= this.V)
		{
			string arg_52_0 = new StringBuilder().append("vertex ").append(num).append(" is not between 0 and ").append(this.V - 1).toString();
			
			throw new IndexOutOfRangeException(arg_52_0);
		}
		if (num2 < 0 || num2 >= this.V)
		{
			string arg_9B_0 = new StringBuilder().append("vertex ").append(num2).append(" is not between 0 and ").append(this.V - 1).toString();
			
			throw new IndexOutOfRangeException(arg_9B_0);
		}
		this.adj[num].add(e);
		this.adj[num2].add(e);
		this.E++;
	}
	public virtual int E()
	{
		return this.E;
	}
/*	[Signature("(I)Ljava/lang/Iterable<LEdge;>;")]*/
	
	public virtual Iterable adj(int i)
	{
		if (i < 0 || i >= this.V)
		{
			string arg_43_0 = new StringBuilder().append("vertex ").append(i).append(" is not between 0 and ").append(this.V - 1).toString();
			
			throw new IndexOutOfRangeException(arg_43_0);
		}
		return this.adj[i];
	}
	
	
	public EdgeWeightedGraph(int i1, int i2) : this(i1)
	{
		if (i2 < 0)
		{
			string arg_17_0 = "Number of edges must be nonnegative";
			
			throw new ArgumentException(arg_17_0);
		}
		for (int j = 0; j < i2; j++)
		{
			int i3 = ByteCodeHelper.d2i(java.lang.Math.random() * (double)i1);
			int i4 = ByteCodeHelper.d2i(java.lang.Math.random() * (double)i1);
			double d = (double)java.lang.Math.round(100.0 * java.lang.Math.random()) / 100.0;
			Edge e = new Edge(i3, i4, d);
			this.addEdge(e);
		}
	}
	
	
	public EdgeWeightedGraph(EdgeWeightedGraph ewg) : this(ewg.V())
	{
		this.E = ewg.E();
		for (int i = 0; i < ewg.V(); i++)
		{
			Stack stack = new Stack();
			Iterator iterator = ewg.adj[i].iterator();
			while (iterator.hasNext())
			{
				Edge obj = (Edge)iterator.next();
				stack.push(obj);
			}
			iterator = stack.iterator();
			while (iterator.hasNext())
			{
				Edge obj = (Edge)iterator.next();
				this.adj[i].add(obj);
			}
		}
	}
	
	
	public override string ToString()
	{
		string property = System.getProperty("line.separator");
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.append(new StringBuilder().append(this.V).append(" ").append(this.E).append(property).toString());
		for (int i = 0; i < this.V; i++)
		{
			stringBuilder.append(new StringBuilder().append(i).append(": ").toString());
			Iterator iterator = this.adj[i].iterator();
			while (iterator.hasNext())
			{
				Edge obj = (Edge)iterator.next();
				stringBuilder.append(new StringBuilder().append(obj).append("  ").toString());
			}
			stringBuilder.append(property);
		}
		return stringBuilder.toString();
	}
	
	
	/**/public static void main(string[] strarr)
	{
		
		In i = new In(strarr[0]);
		EdgeWeightedGraph obj = new EdgeWeightedGraph(i);
		StdOut.println(obj);
	}
}