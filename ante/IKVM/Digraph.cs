public class Digraph
{
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private int V;
	private int E;
//[Signature("[LBag<Ljava/lang/Integer;>;")]
	private Bag[] adj;
	public virtual int V()
	{
		return this.V;
	}
/*	[Signature("(I)Ljava/lang/Iterable<Ljava/lang/Integer;>;")]*/
	
	public virtual Iterable adj(int i)
	{
		if (i < 0 || i >= this.V)
		{
			
			throw new IndexOutOfRangeException();
		}
		return this.adj[i];
	}
	
	
	public Digraph(In i)
	{
		try
		{
			this.V = i.readInt();
			if (this.V < 0)
			{
				string arg_27_0 = "Number of vertices in a Digraph must be nonnegative";
				
				throw new ArgumentException(arg_27_0);
			}
			this.adj = (Bag[])new Bag[this.V];
			int j;
			for (j = 0; j < this.V; j++)
			{
				this.adj[j] = new Bag();
			}
			j = i.readInt();
			if (j < 0)
			{
				string arg_76_0 = "Number of edges in a Digraph must be nonnegative";
				
				throw new ArgumentException(arg_76_0);
			}
			for (int k = 0; k < j; k++)
			{
				int i2 = i.readInt();
				int i3 = i.readInt();
				this.addEdge(i2, i3);
			}
		}
		catch (InvalidOperationException arg_A2_0)
		{
			goto IL_A6;
		}
		return;
		IL_A6:
		string arg_B6_0 = "Invalid input format in Digraph constructor";
		
		throw new InputMismatchException(arg_B6_0);
	}
	
	
	public virtual void addEdge(int i1, int i2)
	{
		if (i1 < 0 || i1 >= this.V)
		{
			string arg_43_0 = new StringBuilder().append("vertex ").append(i1).append(" is not between 0 and ").append(this.V - 1).toString();
			
			throw new IndexOutOfRangeException(arg_43_0);
		}
		if (i2 < 0 || i2 >= this.V)
		{
			string arg_8C_0 = new StringBuilder().append("vertex ").append(i2).append(" is not between 0 and ").append(this.V - 1).toString();
			
			throw new IndexOutOfRangeException(arg_8C_0);
		}
		this.adj[i1].add(Integer.valueOf(i2));
		this.E++;
	}
	
	
	public Digraph(int i)
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
	public virtual int E()
	{
		return this.E;
	}
	
	
	public Digraph(Digraph d) : this(d.V())
	{
		this.E = d.E();
		for (int i = 0; i < d.V(); i++)
		{
			Stack stack = new Stack();
			Iterator iterator = d.adj[i].iterator();
			while (iterator.hasNext())
			{
				int i2 = ((Integer)iterator.next()).intValue();
				stack.push(Integer.valueOf(i2));
			}
			iterator = stack.iterator();
			while (iterator.hasNext())
			{
				int i2 = ((Integer)iterator.next()).intValue();
				this.adj[i].add(Integer.valueOf(i2));
			}
		}
	}
	
	
	public virtual Digraph reverse()
	{
		Digraph digraph = new Digraph(this.V);
		for (int i = 0; i < this.V; i++)
		{
			Iterator iterator = this.adj(i).iterator();
			while (iterator.hasNext())
			{
				int i2 = ((Integer)iterator.next()).intValue();
				digraph.addEdge(i2, i);
			}
		}
		return digraph;
	}
	
	
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		string property = System.getProperty("line.separator");
		stringBuilder.append(new StringBuilder().append(this.V).append(" vertices, ").append(this.E).append(" edges ").append(property).toString());
		for (int i = 0; i < this.V; i++)
		{
			stringBuilder.append(java.lang.String.format("%d: ", new object[]
			{
				Integer.valueOf(i)
			}));
			Iterator iterator = this.adj[i].iterator();
			while (iterator.hasNext())
			{
				int i2 = ((Integer)iterator.next()).intValue();
				stringBuilder.append(java.lang.String.format("%d ", new object[]
				{
					Integer.valueOf(i2)
				}));
			}
			stringBuilder.append(property);
		}
		return stringBuilder.toString();
	}
	
	
	/**/public static void main(string[] strarr)
	{
		
		In i = new In(strarr[0]);
		Digraph obj = new Digraph(i);
		StdOut.println(obj);
	}
}