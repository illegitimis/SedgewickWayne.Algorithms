public class AcyclicSP
{
	private double[] distTo;
	private DirectedEdge[] edgeTo;
	
	
	private void relax(DirectedEdge directedEdge)
	{
		int num = directedEdge.from();
		int num2 = directedEdge.to();
		if (this.distTo[num2] > this.distTo[num] + directedEdge.weight())
		{
			this.distTo[num2] = this.distTo[num] + directedEdge.weight();
			this.edgeTo[num2] = directedEdge;
		}
	}
	
	public virtual bool hasPathTo(int i)
	{
		return this.distTo[i] < double.PositiveInfinity;
	}
	
	
	public AcyclicSP(EdgeWeightedDigraph ewd, int i)
	{
		this.distTo = new double[ewd.V()];
		this.edgeTo = new DirectedEdge[ewd.V()];
		for (int j = 0; j < ewd.V(); j++)
		{
			this.distTo[j] = double.PositiveInfinity;
		}
		this.distTo[i] = (double)0f;
		Topological topological = new Topological(ewd);
		if (!topological.hasOrder())
		{
			string arg_72_0 = "Digraph is not acyclic.";
			
			throw new ArgumentException(arg_72_0);
		}
		Iterator iterator = topological.order().iterator();
		while (iterator.hasNext())
		{
			int i2 = ((Integer)iterator.next()).intValue();
			Iterator iterator2 = ewd.adj(i2).iterator();
			while (iterator2.hasNext())
			{
				DirectedEdge directedEdge = (DirectedEdge)iterator2.next();
				this.relax(directedEdge);
			}
		}
	}
	
	public virtual double distTo(int i)
	{
		return this.distTo[i];
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
	
	
	/**/public static void main(string[] strarr)
	{
		
		In i = new In(strarr[0]);
		int i2 = Integer.parseInt(strarr[1]);
		EdgeWeightedDigraph edgeWeightedDigraph = new EdgeWeightedDigraph(i);
		AcyclicSP acyclicSP = new AcyclicSP(edgeWeightedDigraph, i2);
		for (int j = 0; j < edgeWeightedDigraph.V(); j++)
		{
			if (acyclicSP.hasPathTo(j))
			{
				StdOut.printf("%d to %d (%.2f)  ", new object[]
				{
					Integer.valueOf(i2),
					Integer.valueOf(j),
					java.lang.Double.valueOf(acyclicSP.distTo(j))
				});
				Iterator iterator = acyclicSP.pathTo(j).iterator();
				while (iterator.hasNext())
				{
					DirectedEdge obj = (DirectedEdge)iterator.next();
					StdOut.print(new StringBuilder().append(obj).append("   ").toString());
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
}