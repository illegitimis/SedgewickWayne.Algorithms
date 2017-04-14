public class DijkstraSP
{
	private double[] distTo;
	private DirectedEdge[] edgeTo;
//[Signature("LIndexMinPQ<Ljava/lang/Double;>;")]
	private IndexMinPQ pq;
//[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
	internal static bool s_assertionsDisabled;
	
	
	
	
	public DijkstraSP(EdgeWeightedDigraph ewd, int i)
	{
		Iterator iterator = ewd.edges().iterator();
		while (iterator.hasNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)iterator.next();
			if (directedEdge.weight() < (double)0f)
			{
				string arg_5E_0 = new StringBuilder().append("edge ").append(directedEdge).append(" has negative weight").toString();
				
				throw new ArgumentException(arg_5E_0);
			}
		}
		this.distTo = new double[ewd.V()];
		this.edgeTo = new DirectedEdge[ewd.V()];
		for (int j = 0; j < ewd.V(); j++)
		{
			this.distTo[j] = double.PositiveInfinity;
		}
		this.distTo[i] = (double)0f;
		this.pq = new IndexMinPQ(ewd.V());
		this.pq.insert(i, java.lang.Double.valueOf(this.distTo[i]));
		while (!this.pq.isEmpty())
		{
			int j = this.pq.delMin();
			Iterator iterator2 = ewd.adj(j).iterator();
			while (iterator2.hasNext())
			{
				DirectedEdge directedEdge2 = (DirectedEdge)iterator2.next();
				this.relax(directedEdge2);
			}
		}
		if (!DijkstraSP.s_assertionsDisabled && !this.check(ewd, i))
		{
			
			throw new AssertionError();
		}
	}
/*	[Signature("(I)Ljava/lang/Iterable<LDirectedEdge;>;")]*/
	
	public virtual Iterable pathTo(int i)
	{
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
	
	public virtual double distTo(int i)
	{
		return this.distTo[i];
	}
	
	
	private void relax(DirectedEdge directedEdge)
	{
		int num = directedEdge.from();
		int num2 = directedEdge.to();
		if (this.distTo[num2] > this.distTo[num] + directedEdge.weight())
		{
			this.distTo[num2] = this.distTo[num] + directedEdge.weight();
			this.edgeTo[num2] = directedEdge;
			if (this.pq.contains(num2))
			{
				this.pq.decreaseKey(num2, java.lang.Double.valueOf(this.distTo[num2]));
			}
			else
			{
				this.pq.insert(num2, java.lang.Double.valueOf(this.distTo[num2]));
			}
		}
	}
	
	
	private bool check(EdgeWeightedDigraph edgeWeightedDigraph, int num)
	{
		Iterator iterator = edgeWeightedDigraph.edges().iterator();
		while (iterator.hasNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)iterator.next();
			if (directedEdge.weight() < (double)0f)
			{
				System.err.println("negative edge weight detected");
				return false;
			}
		}
		if (this.distTo[num] != (double)0f || this.edgeTo[num] != null)
		{
			System.err.println("distTo[s] and edgeTo[s] inconsistent");
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
				int num2 = directedEdge2.to();
				if (this.distTo[i] + directedEdge2.weight() < this.distTo[num2])
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
				DirectedEdge directedEdge = this.edgeTo[i];
				int num3 = directedEdge.from();
				if (i != directedEdge.to())
				{
					return false;
				}
				if (this.distTo[num3] + directedEdge.weight() != this.distTo[i])
				{
					System.err.println(new StringBuilder().append("edge ").append(directedEdge).append(" on shortest path not tight").toString());
					return false;
				}
			}
		}
		return true;
	}
	
	public virtual bool hasPathTo(int i)
	{
		return this.distTo[i] < double.PositiveInfinity;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		
		In i = new In(strarr[0]);
		EdgeWeightedDigraph edgeWeightedDigraph = new EdgeWeightedDigraph(i);
		int i2 = Integer.parseInt(strarr[1]);
		DijkstraSP dijkstraSP = new DijkstraSP(edgeWeightedDigraph, i2);
		for (int j = 0; j < edgeWeightedDigraph.V(); j++)
		{
			if (dijkstraSP.hasPathTo(j))
			{
				StdOut.printf("%d to %d (%.2f)  ", new object[]
				{
					Integer.valueOf(i2),
					Integer.valueOf(j),
					java.lang.Double.valueOf(dijkstraSP.distTo(j))
				});
				if (dijkstraSP.hasPathTo(j))
				{
					Iterator iterator = dijkstraSP.pathTo(j).iterator();
					while (iterator.hasNext())
					{
						DirectedEdge obj = (DirectedEdge)iterator.next();
						StdOut.print(new StringBuilder().append(obj).append("   ").toString());
					}
				}
				StdOut.println();
			}
			else
			{
				StdOut.printf("%d to %d         no path\n", new object[]
				{
					Integer.valueOf(i2),
					Integer.valueOf(j)
				});
			}
		}
	}
	
	static DijkstraSP()
	{
		DijkstraSP.s_assertionsDisabled = !ClassLiteral<DijkstraSP>.Value.desiredAssertionStatus();
	}
}