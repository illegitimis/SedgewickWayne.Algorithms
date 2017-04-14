//Bipartite

public class Bipartite
{
	private bool isBipartite;
	private bool[] color;
	private bool[] marked;
	private int[] edgeTo;
//[Signature("LStack<Ljava/lang/Integer;>;")]
	private Stack cycle;
//[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
	internal static bool s_assertionsDisabled;
	
	
	
	
	private void dfs(Graph graph, int num)
	{
		this.marked[num] = true;
		Iterator iterator = graph.adj(num).iterator();
		while (iterator.hasNext())
		{
			int num2 = ((Integer)iterator.next()).intValue();
			if (this.cycle != null)
			{
				return;
			}
			if (!this.marked[num2])
			{
				this.edgeTo[num2] = num;
				this.color[num2] = (this.color[num] ? false : true);
				this.dfs(graph, num2);
			}
			else if (this.color[num2] == this.color[num])
			{
				this.isBipartite = false;
				this.cycle = new Stack();
				this.cycle.push(Integer.valueOf(num2));
				for (int num3 = num; num3 != num2; num3 = this.edgeTo[num3])
				{
					this.cycle.push(Integer.valueOf(num3));
				}
				this.cycle.push(Integer.valueOf(num2));
			}
		}
	}
	
	
	private bool check(Graph graph)
	{
		if (this.isBipartite)
		{
			for (int i = 0; i < graph.V(); i++)
			{
				Iterator iterator = graph.adj(i).iterator();
				while (iterator.hasNext())
				{
					int num = ((Integer)iterator.next()).intValue();
					if (this.color[i] == this.color[num])
					{
						System.err.printf("edge %d-%d with %d and %d in same side of bipartition\n", new object[]
						{
							Integer.valueOf(i),
							Integer.valueOf(num),
							Integer.valueOf(i),
							Integer.valueOf(num)
						});
						return false;
					}
				}
			}
		}
		else
		{
			int i = -1;
			int num2 = -1;
			Iterator iterator2 = this.oddCycle().iterator();
			while (iterator2.hasNext())
			{
				int num3 = ((Integer)iterator2.next()).intValue();
				if (i == -1)
				{
					i = num3;
				}
				num2 = num3;
			}
			if (i != num2)
			{
				System.err.printf("cycle begins with %d and ends with %d\n", new object[]
				{
					Integer.valueOf(i),
					Integer.valueOf(num2)
				});
				return false;
			}
		}
		return true;
	}
/*	[Signature("()Ljava/lang/Iterable<Ljava/lang/Integer;>;")]*/
	public virtual Iterable oddCycle()
	{
		return this.cycle;
	}
	
	
	public Bipartite(Graph g)
	{
		this.isBipartite = true;
		this.color = new bool[g.V()];
		this.marked = new bool[g.V()];
		this.edgeTo = new int[g.V()];
		for (int i = 0; i < g.V(); i++)
		{
			if (!this.marked[i])
			{
				this.dfs(g, i);
			}
		}
		if (!Bipartite.s_assertionsDisabled && !this.check(g))
		{
			
			throw new AssertionError();
		}
	}
	public virtual bool isBipartite()
	{
		return this.isBipartite;
	}
	
	
	public virtual bool color(int i)
	{
		if (!this.isBipartite)
		{
			string arg_12_0 = "Graph is not bipartite";
			
			throw new NotSupportedException(arg_12_0);
		}
		return this.color[i];
	}
	
	
	/**//**/public static void main(string[] strarr)
	{
		int num = Integer.parseInt(strarr[0]);
		int num2 = Integer.parseInt(strarr[1]);
		int num3 = Integer.parseInt(strarr[2]);
		Graph graph = new Graph(num);
		int[] array = new int[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = i;
		}
		StdRandom.shuffle(array);
		for (int i = 0; i < num2; i++)
		{
			int j = StdRandom.uniform(num / 2);
			int num4 = StdRandom.uniform(num / 2);
			graph.addEdge(array[j], array[num / 2 + num4]);
		}
		for (int i = 0; i < num3; i++)
		{
			int j = ByteCodeHelper.d2i(java.lang.Math.random() * (double)num);
			int num4 = ByteCodeHelper.d2i(java.lang.Math.random() * (double)num);
			graph.addEdge(j, num4);
		}
		StdOut.println(graph);
		Bipartite bipartite = new Bipartite(graph);
		if (bipartite.isBipartite())
		{
			StdOut.println("Graph is bipartite");
			for (int j = 0; j < graph.V(); j++)
			{
				StdOut.println(new StringBuilder().append(j).append(": ").append(bipartite.color(j)).toString());
			}
		}
		else
		{
			StdOut.print("Graph has an odd-length cycle: ");
			Iterator iterator = bipartite.oddCycle().iterator();
			while (iterator.hasNext())
			{
				int num4 = ((Integer)iterator.next()).intValue();
				StdOut.print(new StringBuilder().append(num4).append(" ").toString());
			}
			StdOut.println();
		}
	}
	
	static Bipartite()
	{
		Bipartite.s_assertionsDisabled = !ClassLiteral<Bipartite>.Value.desiredAssertionStatus();
	}
}