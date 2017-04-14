//EdgeWeightedDirectedCycle

public class EdgeWeightedDirectedCycle
{
	private bool[] marked;
	private DirectedEdge[] edgeTo;
	private bool[] onStack;
//[Signature("LStack<LDirectedEdge;>;")]
	private Stack cycle;
//[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
	internal static bool s_assertionsDisabled;
	
	
	
	
	public EdgeWeightedDirectedCycle(EdgeWeightedDigraph ewd)
	{
		this.marked = new bool[ewd.V()];
		this.onStack = new bool[ewd.V()];
		this.edgeTo = new DirectedEdge[ewd.V()];
		for (int i = 0; i < ewd.V(); i++)
		{
			if (!this.marked[i])
			{
				this.dfs(ewd, i);
			}
		}
		if (!EdgeWeightedDirectedCycle.s_assertionsDisabled && !this.check(ewd))
		{
			
			throw new AssertionError();
		}
	}
/*	[Signature("()Ljava/lang/Iterable<LDirectedEdge;>;")]*/
	public virtual Iterable cycle()
	{
		return this.cycle;
	}
	
	
	private void dfs(EdgeWeightedDigraph edgeWeightedDigraph, int num)
	{
		this.onStack[num] = true;
		this.marked[num] = true;
		Iterator iterator = edgeWeightedDigraph.adj(num).iterator();
		while (iterator.hasNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)iterator.next();
			int num2 = directedEdge.to();
			if (this.cycle != null)
			{
				return;
			}
			if (!this.marked[num2])
			{
				this.edgeTo[num2] = directedEdge;
				this.dfs(edgeWeightedDigraph, num2);
			}
			else if (this.onStack[num2])
			{
				this.cycle = new Stack();
				while (directedEdge.from() != num2)
				{
					this.cycle.push(directedEdge);
					directedEdge = this.edgeTo[directedEdge.from()];
				}
				this.cycle.push(directedEdge);
			}
		}
		this.onStack[num] = false;
	}
	
	
	private bool check(EdgeWeightedDigraph edgeWeightedDigraph)
	{
		if (this.hasCycle())
		{
			DirectedEdge directedEdge = null;
			DirectedEdge directedEdge2 = null;
			Iterator iterator = this.cycle().iterator();
			while (iterator.hasNext())
			{
				DirectedEdge directedEdge3 = (DirectedEdge)iterator.next();
				if (directedEdge == null)
				{
					directedEdge = directedEdge3;
				}
				if (directedEdge2 != null && directedEdge2.to() != directedEdge3.from())
				{
					System.err.printf("cycle edges %s and %s not incident\n", new object[]
					{
						directedEdge2,
						directedEdge3
					});
					return false;
				}
				directedEdge2 = directedEdge3;
			}
			if (directedEdge2.to() != directedEdge.from())
			{
				System.err.printf("cycle edges %s and %s not incident\n", new object[]
				{
					directedEdge2,
					directedEdge
				});
				return false;
			}
		}
		return true;
	}
	public virtual bool hasCycle()
	{
		return this.cycle != null;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		int num = Integer.parseInt(strarr[0]);
		int num2 = Integer.parseInt(strarr[1]);
		int num3 = Integer.parseInt(strarr[2]);
		EdgeWeightedDigraph edgeWeightedDigraph = new EdgeWeightedDigraph(num);
		int[] array = new int[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = i;
		}
		StdRandom.shuffle(array);
		for (int i = 0; i < num2; i++)
		{
			int num4;
			int num5;
			do
			{
				num4 = StdRandom.uniform(num);
				num5 = StdRandom.uniform(num);
			}
			while (num4 >= num5);
			double d = java.lang.Math.random();
			edgeWeightedDigraph.addEdge(new DirectedEdge(num4, num5, d));
		}
		for (int i = 0; i < num3; i++)
		{
			int num4 = ByteCodeHelper.d2i(java.lang.Math.random() * (double)num);
			int num5 = ByteCodeHelper.d2i(java.lang.Math.random() * (double)num);
			double d = java.lang.Math.random();
			edgeWeightedDigraph.addEdge(new DirectedEdge(num4, num5, d));
		}
		StdOut.println(edgeWeightedDigraph);
		EdgeWeightedDirectedCycle edgeWeightedDirectedCycle = new EdgeWeightedDirectedCycle(edgeWeightedDigraph);
		if (edgeWeightedDirectedCycle.hasCycle())
		{
			StdOut.print("Cycle: ");
			Iterator iterator = edgeWeightedDirectedCycle.cycle().iterator();
			while (iterator.hasNext())
			{
				DirectedEdge obj = (DirectedEdge)iterator.next();
				StdOut.print(new StringBuilder().append(obj).append(" ").toString());
			}
			StdOut.println();
		}
		else
		{
			StdOut.println("No directed cycle");
		}
	}
	
	static EdgeWeightedDirectedCycle()
	{
		EdgeWeightedDirectedCycle.s_assertionsDisabled = !ClassLiteral<EdgeWeightedDirectedCycle>.Value.desiredAssertionStatus();
	}
}