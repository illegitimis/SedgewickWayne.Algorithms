//DepthFirstDirectedPaths

public class DepthFirstDirectedPaths
{
	private bool[] marked;
	private int[] edgeTo;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private int s;
	
	
	private void dfs(Digraph digraph, int num)
	{
		this.marked[num] = true;
		Iterator iterator = digraph.adj(num).iterator();
		while (iterator.hasNext())
		{
			int num2 = ((Integer)iterator.next()).intValue();
			if (!this.marked[num2])
			{
				this.edgeTo[num2] = num;
				this.dfs(digraph, num2);
			}
		}
	}
	
	public virtual bool hasPathTo(int i)
	{
		return this.marked[i];
	}
	
	
	public DepthFirstDirectedPaths(Digraph d, int i)
	{
		this.marked = new bool[d.V()];
		this.edgeTo = new int[d.V()];
		this.s = i;
		this.dfs(d, i);
	}
/*	[Signature("(I)Ljava/lang/Iterable<Ljava/lang/Integer;>;")]*/
	
	public virtual Iterable pathTo(int i)
	{
		if (!this.hasPathTo(i))
		{
			return null;
		}
		Stack stack = new Stack();
		for (int num = i; num != this.s; num = this.edgeTo[num])
		{
			stack.push(Integer.valueOf(num));
		}
		stack.push(Integer.valueOf(this.s));
		return stack;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		
		In i = new In(strarr[0]);
		Digraph digraph = new Digraph(i);
		int num = Integer.parseInt(strarr[1]);
		DepthFirstDirectedPaths depthFirstDirectedPaths = new DepthFirstDirectedPaths(digraph, num);
		for (int j = 0; j < digraph.V(); j++)
		{
			if (depthFirstDirectedPaths.hasPathTo(j))
			{
				StdOut.printf("%d to %d:  ", new object[]
				{
					Integer.valueOf(num),
					Integer.valueOf(j)
				});
				Iterator iterator = depthFirstDirectedPaths.pathTo(j).iterator();
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
				StdOut.printf("%d to %d:  not connected\n", new object[]
				{
					Integer.valueOf(num),
					Integer.valueOf(j)
				});
			}
		}
	}
}