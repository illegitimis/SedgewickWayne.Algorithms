public class EdgeWeightedDigraph
{
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private int V;
	private int E;
//[Signature("[LBag<LDirectedEdge;>;")]
	private Bag[] adj;
	public virtual int V()
	{
		return this.V;
	}
/*	[Signature("(I)Ljava/lang/Iterable<LDirectedEdge;>;")]*/
	
	public virtual Iterable adj(int i)
	{
		if (i < 0 || i >= this.V)
		{
			string arg_43_0 = new StringBuilder().append("vertex ").append(i).append(" is not between 0 and ").append(this.V - 1).toString();
			
			throw new IndexOutOfRangeException(arg_43_0);
		}
		return this.adj[i];
	}
	
	
	public EdgeWeightedDigraph(In i) : this(i.readInt())
	{
		int num = i.readInt();
		if (num < 0)
		{
			string arg_23_0 = "Number of edges must be nonnegative";
			
			throw new ArgumentException(arg_23_0);
		}
		for (int j = 0; j < num; j++)
		{
			int num2 = i.readInt();
			int num3 = i.readInt();
			if (num2 < 0 || num2 >= this.V)
			{
				string arg_84_0 = new StringBuilder().append("vertex ").append(num2).append(" is not between 0 and ").append(this.V - 1).toString();
				
				throw new IndexOutOfRangeException(arg_84_0);
			}
			if (num3 < 0 || num3 >= this.V)
			{
				string arg_D0_0 = new StringBuilder().append("vertex ").append(num3).append(" is not between 0 and ").append(this.V - 1).toString();
				
				throw new IndexOutOfRangeException(arg_D0_0);
			}
			double d = i.readDouble();
			this.addEdge(new DirectedEdge(num2, num3, d));
		}
	}
	
	
	public EdgeWeightedDigraph(int i)
	{
		if (i < 0)
		{
			string arg_16_0 = "Number of vertices in a Digraph must be nonnegative";
			
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
	
	
	public virtual void addEdge(DirectedEdge de)
	{
		int num = de.from();
		this.adj[num].add(de);
		this.E++;
	}
/*	[Signature("()Ljava/lang/Iterable<LDirectedEdge;>;")]*/
	
	public virtual Iterable edges()
	{
		Bag bag = new Bag();
		for (int i = 0; i < this.V; i++)
		{
			Iterator iterator = this.adj(i).iterator();
			while (iterator.hasNext())
			{
				DirectedEdge obj = (DirectedEdge)iterator.next();
				bag.add(obj);
			}
		}
		return bag;
	}
	public virtual int E()
	{
		return this.E;
	}
	
	
	public EdgeWeightedDigraph(int i1, int i2) : this(i1)
	{
		if (i2 < 0)
		{
			string arg_17_0 = "Number of edges in a Digraph must be nonnegative";
			
			throw new ArgumentException(arg_17_0);
		}
		for (int j = 0; j < i2; j++)
		{
			int i3 = ByteCodeHelper.d2i(java.lang.Math.random() * (double)i1);
			int i4 = ByteCodeHelper.d2i(java.lang.Math.random() * (double)i1);
			double d = (double)java.lang.Math.round(100.0 * java.lang.Math.random()) / 100.0;
			DirectedEdge de = new DirectedEdge(i3, i4, d);
			this.addEdge(de);
		}
	}
	
	
	public EdgeWeightedDigraph(EdgeWeightedDigraph ewd) : this(ewd.V())
	{
		this.E = ewd.E();
		for (int i = 0; i < ewd.V(); i++)
		{
			Stack stack = new Stack();
			Iterator iterator = ewd.adj[i].iterator();
			while (iterator.hasNext())
			{
				DirectedEdge obj = (DirectedEdge)iterator.next();
				stack.push(obj);
			}
			iterator = stack.iterator();
			while (iterator.hasNext())
			{
				DirectedEdge obj = (DirectedEdge)iterator.next();
				this.adj[i].add(obj);
			}
		}
	}
	
	
	public virtual int outdegree(int i)
	{
		if (i < 0 || i >= this.V)
		{
			string arg_43_0 = new StringBuilder().append("vertex ").append(i).append(" is not between 0 and ").append(this.V - 1).toString();
			
			throw new IndexOutOfRangeException(arg_43_0);
		}
		return this.adj[i].size();
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
				DirectedEdge obj = (DirectedEdge)iterator.next();
				stringBuilder.append(new StringBuilder().append(obj).append("  ").toString());
			}
			stringBuilder.append(property);
		}
		return stringBuilder.toString();
	}
	
	
	/**/public static void main(string[] strarr)
	{
		
		In i = new In(strarr[0]);
		EdgeWeightedDigraph obj = new EdgeWeightedDigraph(i);
		StdOut.println(obj);
	}
}