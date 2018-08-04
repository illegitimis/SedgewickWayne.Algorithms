public class BreadthFirstDirectedPaths
{
	private const int INFINITY = 2147483647;
	private bool[] marked;
	private int[] edgeTo;
	private int[] distTo;
	
	
	private void bfs(Digraph digraph, int num)
	{
		Queue queue = new Queue();
		this.marked[num] = true;
		this.distTo[num] = 0;
		queue.enqueue(Integer.valueOf(num));
		while (!queue.isEmpty())
		{
			int num2 = ((Integer)queue.dequeue()).intValue();
			Iterator iterator = digraph.adj(num2).iterator();
			while (iterator.hasNext())
			{
				int num3 = ((Integer)iterator.next()).intValue();
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
/*	[Signature("(LDigraph;Ljava/lang/Iterable<Ljava/lang/Integer;>;)V")]*/
	
	private void bfs(Digraph digraph, Iterable iterable)
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
			Iterator iterator2 = digraph.adj(num2).iterator();
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
	
	
	public BreadthFirstDirectedPaths(Digraph d, int i)
	{
		this.marked = new bool[d.V()];
		this.distTo = new int[d.V()];
		this.edgeTo = new int[d.V()];
		for (int j = 0; j < d.V(); j++)
		{
			this.distTo[j] = 2147483647;
		}
		this.bfs(d, i);
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
/*	[Signature("(LDigraph;Ljava/lang/Iterable<Ljava/lang/Integer;>;)V")]*/
	
	public BreadthFirstDirectedPaths(Digraph d, Iterable i)
	{
		this.marked = new bool[d.V()];
		this.distTo = new int[d.V()];
		this.edgeTo = new int[d.V()];
		for (int j = 0; j < d.V(); j++)
		{
			this.distTo[j] = 2147483647;
		}
		this.bfs(d, i);
	}
	
	
	/**/public static void main(string[] strarr)
	{
		
		In i = new In(strarr[0]);
		Digraph digraph = new Digraph(i);
		int num = Integer.parseInt(strarr[1]);
		BreadthFirstDirectedPaths breadthFirstDirectedPaths = new BreadthFirstDirectedPaths(digraph, num);
		for (int j = 0; j < digraph.V(); j++)
		{
			if (breadthFirstDirectedPaths.hasPathTo(j))
			{
				StdOut.printf("%d to %d (%d):  ", new object[]
				{
					Integer.valueOf(num),
					Integer.valueOf(j),
					Integer.valueOf(breadthFirstDirectedPaths.distTo(j))
				});
				Iterator iterator = breadthFirstDirectedPaths.pathTo(j).iterator();
				while (iterator.hasNext())
				{
					int num2 = ((Integer)iterator.next()).intValue();
					if (num2 == num)
					{
						StdOut.print(num2);
					}
					else
					{
						StdOut.print(new StringBuilder().append("->").append(num2).toString());
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
}