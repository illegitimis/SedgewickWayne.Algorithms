public class BreadthFirstPaths
{
	private const int INFINITY = 2147483647;
	private bool[] marked;
	private int[] edgeTo;
	private int[] distTo;
//[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
	internal static bool s_assertionsDisabled;
	
	
	
	
	private void bfs(Graph graph, int num)
	{
		Queue queue = new Queue();
		for (int i = 0; i < graph.V(); i++)
		{
			this.distTo[i] = 2147483647;
		}
		this.distTo[num] = 0;
		this.marked[num] = true;
		queue.enqueue(Integer.valueOf(num));
		while (!queue.isEmpty())
		{
			int i = ((Integer)queue.dequeue()).intValue();
			Iterator iterator = graph.adj(i).iterator();
			while (iterator.hasNext())
			{
				int num2 = ((Integer)iterator.next()).intValue();
				if (!this.marked[num2])
				{
					this.edgeTo[num2] = i;
					this.distTo[num2] = this.distTo[i] + 1;
					this.marked[num2] = true;
					queue.enqueue(Integer.valueOf(num2));
				}
			}
		}
	}
	
	
	private bool check(Graph graph, int num)
	{
		if (this.distTo[num] != 0)
		{
			StdOut.println(new StringBuilder().append("distance of source ").append(num).append(" to itself = ").append(this.distTo[num]).toString());
			return false;
		}
		for (int i = 0; i < graph.V(); i++)
		{
			Iterator iterator = graph.adj(i).iterator();
			while (iterator.hasNext())
			{
				int num2 = ((Integer)iterator.next()).intValue();
				if (this.hasPathTo(i) != this.hasPathTo(num2))
				{
					StdOut.println(new StringBuilder().append("edge ").append(i).append("-").append(num2).toString());
					StdOut.println(new StringBuilder().append("hasPathTo(").append(i).append(") = ").append(this.hasPathTo(i)).toString());
					StdOut.println(new StringBuilder().append("hasPathTo(").append(num2).append(") = ").append(this.hasPathTo(num2)).toString());
					return false;
				}
				if (this.hasPathTo(i) && this.distTo[num2] > this.distTo[i] + 1)
				{
					StdOut.println(new StringBuilder().append("edge ").append(i).append("-").append(num2).toString());
					StdOut.println(new StringBuilder().append("distTo[").append(i).append("] = ").append(this.distTo[i]).toString());
					StdOut.println(new StringBuilder().append("distTo[").append(num2).append("] = ").append(this.distTo[num2]).toString());
					return false;
				}
			}
		}
		for (int i = 0; i < graph.V(); i++)
		{
			if (this.hasPathTo(i))
			{
				if (i != num)
				{
					int num3 = this.edgeTo[i];
					if (this.distTo[i] != this.distTo[num3] + 1)
					{
						StdOut.println(new StringBuilder().append("shortest path edge ").append(num3).append("-").append(i).toString());
						StdOut.println(new StringBuilder().append("distTo[").append(num3).append("] = ").append(this.distTo[num3]).toString());
						StdOut.println(new StringBuilder().append("distTo[").append(i).append("] = ").append(this.distTo[i]).toString());
						return false;
					}
				}
			}
		}
		return true;
	}
/*	[Signature("(LGraph;Ljava/lang/Iterable<Ljava/lang/Integer;>;)V")]*/
	
	private void bfs(Graph graph, Iterable iterable)
	{
		Queue queue = new Queue();
		Iterator iterator = iterable.iterator();
		while (iterator.hasNext())
		{
			int num = ((Integer)iterator.next()).intValue();
			this.marked[num] = true;
			this.distTo[num] = 0;
			queue.enqueue(Integer.valueOf(num));
		}
		while (!queue.isEmpty())
		{
			int num2 = ((Integer)queue.dequeue()).intValue();
			Iterator iterator2 = graph.adj(num2).iterator();
			while (iterator2.hasNext())
			{
				int num3 = ((Integer)iterator2.next()).intValue();
				if (!this.marked[num3])
				{
					this.edgeTo[num3] = num2;
					this.distTo[num3] = this.distTo[num2] + 1;
					this.marked[num3] = true;
					queue.enqueue(Integer.valueOf(num3));
				}
			}
		}
	}
	
	public virtual bool hasPathTo(int i)
	{
		return this.marked[i];
	}
	
	
	public BreadthFirstPaths(Graph g, int i)
	{
		this.marked = new bool[g.V()];
		this.distTo = new int[g.V()];
		this.edgeTo = new int[g.V()];
		this.bfs(g, i);
		if (!BreadthFirstPaths.s_assertionsDisabled && !this.check(g, i))
		{
			
			throw new AssertionError();
		}
	}
	
	public virtual int distTo(int i)
	{
		return this.distTo[i];
	}
/*	[Signature("(I)Ljava/lang/Iterable<Ljava/lang/Integer;>;")]*/
	
	public virtual Iterable pathTo(int i)
	{
		if (!this.hasPathTo(i))
		{
			return null;
		}
		Stack stack = new Stack();
		int num = i;
		while (this.distTo[num] != 0)
		{
			stack.push(Integer.valueOf(num));
			num = this.edgeTo[num];
		}
		stack.push(Integer.valueOf(num));
		return stack;
	}
/*	[Signature("(LGraph;Ljava/lang/Iterable<Ljava/lang/Integer;>;)V")]*/
	
	public BreadthFirstPaths(Graph g, Iterable i)
	{
		this.marked = new bool[g.V()];
		this.distTo = new int[g.V()];
		this.edgeTo = new int[g.V()];
		for (int j = 0; j < g.V(); j++)
		{
			this.distTo[j] = 2147483647;
		}
		this.bfs(g, i);
	}
	
	
	/**/public static void main(string[] strarr)
	{
		
		In i = new In(strarr[0]);
		Graph graph = new Graph(i);
		int num = Integer.parseInt(strarr[1]);
		BreadthFirstPaths breadthFirstPaths = new BreadthFirstPaths(graph, num);
		for (int j = 0; j < graph.V(); j++)
		{
			if (breadthFirstPaths.hasPathTo(j))
			{
				StdOut.printf("%d to %d (%d):  ", new object[]
				{
					Integer.valueOf(num),
					Integer.valueOf(j),
					Integer.valueOf(breadthFirstPaths.distTo(j))
				});
				Iterator iterator = breadthFirstPaths.pathTo(j).iterator();
				while (iterator.hasNext())
				{
					int num2 = ((Integer)iterator.next()).intValue();
					if (num2 == num)
					{
						StdOut.print(num2);
					}
					else
					{
						StdOut.print(new StringBuilder().append("-").append(num2).toString());
					}
				}
				StdOut.println();
			}
			else
			{
				StdOut.printf("%d to %d (-):  not connected\n", new object[]
				{
					Integer.valueOf(num),
					Integer.valueOf(j)
				});
			}
		}
	}
	
	static BreadthFirstPaths()
	{
		BreadthFirstPaths.s_assertionsDisabled = !ClassLiteral<BreadthFirstPaths>.Value.desiredAssertionStatus();
	}
}