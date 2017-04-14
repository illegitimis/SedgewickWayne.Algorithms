public class Cycle
{
	private bool[] marked;
	private int[] edgeTo;
//[Signature("LStack<Ljava/lang/Integer;>;")]
	private Stack cycle;
	
	
	private bool hasSelfLoop(Graph graph)
	{
		for (int i = 0; i < graph.V(); i++)
		{
			Iterator iterator = graph.adj(i).iterator();
			while (iterator.hasNext())
			{
				int num = ((Integer)iterator.next()).intValue();
				if (i == num)
				{
					this.cycle = new Stack();
					this.cycle.push(Integer.valueOf(i));
					this.cycle.push(Integer.valueOf(i));
					return true;
				}
			}
		}
		return false;
	}
	
	
	private bool hasParallelEdges(Graph graph)
	{
		this.marked = new bool[graph.V()];
		for (int i = 0; i < graph.V(); i++)
		{
			Iterator iterator = graph.adj(i).iterator();
			while (iterator.hasNext())
			{
				int num = ((Integer)iterator.next()).intValue();
				if (this.marked[num])
				{
					this.cycle = new Stack();
					this.cycle.push(Integer.valueOf(i));
					this.cycle.push(Integer.valueOf(num));
					this.cycle.push(Integer.valueOf(i));
					return true;
				}
				this.marked[num] = true;
			}
			iterator = graph.adj(i).iterator();
			while (iterator.hasNext())
			{
				int num = ((Integer)iterator.next()).intValue();
				this.marked[num] = false;
			}
		}
		return false;
	}
	
	
	private void dfs(Graph graph, int num, int num2)
	{
		this.marked[num2] = true;
		Iterator iterator = graph.adj(num2).iterator();
		while (iterator.hasNext())
		{
			int num3 = ((Integer)iterator.next()).intValue();
			if (this.cycle != null)
			{
				return;
			}
			if (!this.marked[num3])
			{
				this.edgeTo[num3] = num2;
				this.dfs(graph, num2, num3);
			}
			else if (num3 != num)
			{
				this.cycle = new Stack();
				for (int num4 = num2; num4 != num3; num4 = this.edgeTo[num4])
				{
					this.cycle.push(Integer.valueOf(num4));
				}
				this.cycle.push(Integer.valueOf(num3));
				this.cycle.push(Integer.valueOf(num2));
			}
		}
	}
	
	
	public Cycle(Graph g)
	{
		if (this.hasSelfLoop(g))
		{
			return;
		}
		if (this.hasParallelEdges(g))
		{
			return;
		}
		this.marked = new bool[g.V()];
		this.edgeTo = new int[g.V()];
		for (int i = 0; i < g.V(); i++)
		{
			if (!this.marked[i])
			{
				this.dfs(g, -1, i);
			}
		}
	}
	public virtual bool hasCycle()
	{
		return this.cycle != null;
	}
/*	[Signature("()Ljava/lang/Iterable<Ljava/lang/Integer;>;")]*/
	public virtual Iterable cycle()
	{
		return this.cycle;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		
		In i = new In(strarr[0]);
		Graph g = new Graph(i);
		Cycle cycle = new Cycle(g);
		if (cycle.hasCycle())
		{
			Iterator iterator = cycle.cycle().iterator();
			while (iterator.hasNext())
			{
				int i2 = ((Integer)iterator.next()).intValue();
				StdOut.print(new StringBuilder().append(i2).append(" ").toString());
			}
			StdOut.println();
		}
		else
		{
			StdOut.println("Graph is acyclic");
		}
	}
}