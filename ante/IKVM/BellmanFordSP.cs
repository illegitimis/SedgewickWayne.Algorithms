//BellmanFordSP

public class BellmanFordSP
{
	private double[] distTo;
	private DirectedEdge[] edgeTo;
	private bool[] onQueue;
//[Signature("LQueue<Ljava/lang/Integer;>;")]
	private Queue queue;
	private int cost;
//[Signature("Ljava/lang/Iterable<LDirectedEdge;>;")]
	private Iterable cycle;
//[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
	internal static bool s_assertionsDisabled;
	
	
	
	
	public BellmanFordSP(EdgeWeightedDigraph ewd, int i)
	{
		this.distTo = new double[ewd.V()];
		this.edgeTo = new DirectedEdge[ewd.V()];
		this.onQueue = new bool[ewd.V()];
		for (int j = 0; j < ewd.V(); j++)
		{
			this.distTo[j] = double.PositiveInfinity;
		}
		this.distTo[i] = (double)0f;
		this.queue = new Queue();
		this.queue.enqueue(Integer.valueOf(i));
		this.onQueue[i] = true;
		while (!this.queue.isEmpty() && !this.hasNegativeCycle())
		{
			int j = ((Integer)this.queue.dequeue()).intValue();
			this.onQueue[j] = false;
			this.relax(ewd, j);
		}
		if (!BellmanFordSP.s_assertionsDisabled && !this.check(ewd, i))
		{
			
			throw new AssertionError();
		}
	}
	public virtual bool hasNegativeCycle()
	{
		return this.cycle != null;
	}
/*	[Signature("()Ljava/lang/Iterable<LDirectedEdge;>;")]*/
	public virtual Iterable negativeCycle()
	{
		return this.cycle;
	}
	
	
	private void relax(EdgeWeightedDigraph edgeWeightedDigraph, int num)
	{
		Iterator iterator = edgeWeightedDigraph.adj(num).iterator();
		while (iterator.hasNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)iterator.next();
			int num2 = directedEdge.to();
			if (this.distTo[num2] > this.distTo[num] + directedEdge.weight())
			{
				this.distTo[num2] = this.distTo[num] + directedEdge.weight();
				this.edgeTo[num2] = directedEdge;
				if (!this.onQueue[num2])
				{
					this.queue.enqueue(Integer.valueOf(num2));
					this.onQueue[num2] = true;
				}
			}
			int num3 = this.cost;
			bool expr_93 = num3 != 0;
			this.cost = num3 + 1;
			int expr_A4 = edgeWeightedDigraph.V();
			if (expr_A4 == -1 || (expr_93 ? 1 : 0) % expr_A4 == 0)
			{
				this.findNegativeCycle();
			}
		}
	}
	
	
	private bool check(EdgeWeightedDigraph edgeWeightedDigraph, int num)
	{
		if (this.hasNegativeCycle())
		{
			double num2 = (double)0f;
			Iterator iterator = this.negativeCycle().iterator();
			while (iterator.hasNext())
			{
				DirectedEdge directedEdge = (DirectedEdge)iterator.next();
				num2 += directedEdge.weight();
			}
			if (num2 >= (double)0f)
			{
				System.err.println(new StringBuilder().append("error: weight of negative cycle = ").append(num2).toString());
				return false;
			}
		}
		else
		{
			if (this.distTo[num] != (double)0f || this.edgeTo[num] != null)
			{
				System.err.println("distanceTo[s] and edgeTo[s] inconsistent");
				return false;
			}
			for (int i = 0; i < edgeWeightedDigraph.V(); i++)
			{
				if (i != num)
				{
					if (this.edgeTo[i] == null && this.distTo[i] != double.PositiveInfinity)
					{
						System.err.println("distTo[] and edgeTo[] inconsistent");
						return false;
					}
				}
			}
			for (int i = 0; i < edgeWeightedDigraph.V(); i++)
			{
				Iterator iterator2 = edgeWeightedDigraph.adj(i).iterator();
				while (iterator2.hasNext())
				{
					DirectedEdge directedEdge2 = (DirectedEdge)iterator2.next();
					int num3 = directedEdge2.to();
					if (this.distTo[i] + directedEdge2.weight() < this.distTo[num3])
					{
						System.err.println(new StringBuilder().append("edge ").append(directedEdge2).append(" not relaxed").toString());
						return false;
					}
				}
			}
			for (int i = 0; i < edgeWeightedDigraph.V(); i++)
			{
				if (this.edgeTo[i] != null)
				{
					DirectedEdge directedEdge3 = this.edgeTo[i];
					int num4 = directedEdge3.from();
					if (i != directedEdge3.to())
					{
						return false;
					}
					if (this.distTo[num4] + directedEdge3.weight() != this.distTo[i])
					{
						System.err.println(new StringBuilder().append("edge ").append(directedEdge3).append(" on shortest path not tight").toString());
						return false;
					}
				}
			}
		}
		StdOut.println("Satisfies optimality conditions");
		StdOut.println();
		return true;
	}
	
	
	private void findNegativeCycle()
	{
		int num = this.edgeTo.Length;
		EdgeWeightedDigraph edgeWeightedDigraph = new EdgeWeightedDigraph(num);
		for (int i = 0; i < num; i++)
		{
			if (this.edgeTo[i] != null)
			{
				edgeWeightedDigraph.addEdge(this.edgeTo[i]);
			}
		}
		EdgeWeightedDirectedCycle edgeWeightedDirectedCycle = new EdgeWeightedDirectedCycle(edgeWeightedDigraph);
		this.cycle = edgeWeightedDirectedCycle.cycle();
	}
	
	public virtual bool hasPathTo(int i)
	{
		return this.distTo[i] < double.PositiveInfinity;
	}
	
	
	public virtual double distTo(int i)
	{
		if (this.hasNegativeCycle())
		{
			string arg_12_0 = "Negative cost cycle exists";
			
			throw new NotSupportedException(arg_12_0);
		}
		return this.distTo[i];
	}
/*	[Signature("(I)Ljava/lang/Iterable<LDirectedEdge;>;")]*/
	
	public virtual Iterable pathTo(int i)
	{
		if (this.hasNegativeCycle())
		{
			string arg_12_0 = "Negative cost cycle exists";
			
			throw new NotSupportedException(arg_12_0);
		}
		if (!this.hasPathTo(i))
		{
			return null;
		}
		Stack stack = new Stack();
		for (DirectedEdge directedEdge = this.edgeTo[i]; directedEdge != null; directedEdge = this.edgeTo[directedEdge.from()])
		{
			stack.push(directedEdge);
		}
		return stack;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		
		In i = new In(strarr[0]);
		int i2 = Integer.parseInt(strarr[1]);
		EdgeWeightedDigraph edgeWeightedDigraph = new EdgeWeightedDigraph(i);
		BellmanFordSP bellmanFordSP = new BellmanFordSP(edgeWeightedDigraph, i2);
		if (bellmanFordSP.hasNegativeCycle())
		{
			Iterator iterator = bellmanFordSP.negativeCycle().iterator();
			while (iterator.hasNext())
			{
				DirectedEdge obj = (DirectedEdge)iterator.next();
				StdOut.println(obj);
			}
		}
		else
		{
			for (int j = 0; j < edgeWeightedDigraph.V(); j++)
			{
				if (bellmanFordSP.hasPathTo(j))
				{
					StdOut.printf("%d to %d (%5.2f)  ", new object[]
					{
						Integer.valueOf(i2),
						Integer.valueOf(j),
						java.lang.Double.valueOf(bellmanFordSP.distTo(j))
					});
					Iterator iterator2 = bellmanFordSP.pathTo(j).iterator();
					while (iterator2.hasNext())
					{
						DirectedEdge obj2 = (DirectedEdge)iterator2.next();
						StdOut.print(new StringBuilder().append(obj2).append("   ").toString());
					}
					StdOut.println();
				}
				else
				{
					StdOut.printf("%d to %d           no path\n", new object[]
					{
						Integer.valueOf(i2),
						Integer.valueOf(j)
					});
				}
			}
		}
	}
	
	static BellmanFordSP()
	{
		BellmanFordSP.s_assertionsDisabled = !ClassLiteral<BellmanFordSP>.Value.desiredAssertionStatus();
	}
}