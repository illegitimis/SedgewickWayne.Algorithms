public class DirectedCycle
{
	private bool[] marked;
	private int[] edgeTo;
	private bool[] onStack;
//[Signature("LStack<Ljava/lang/Integer;>;")]
	private Stack cycle;
	
	
	private void dfs(Digraph digraph, int num)
	{
		this.onStack[num] = true;
		this.marked[num] = true;
		Iterator iterator = digraph.adj(num).iterator();
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
				this.dfs(digraph, num2);
			}
			else if (this.onStack[num2])
			{
				this.cycle = new Stack();
				for (int num3 = num; num3 != num2; num3 = this.edgeTo[num3])
				{
					this.cycle.push(Integer.valueOf(num3));
				}
				this.cycle.push(Integer.valueOf(num2));
				this.cycle.push(Integer.valueOf(num));
			}
		}
		this.onStack[num] = false;
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
	
	
	public DirectedCycle(Digraph d)
	{
		this.marked = new bool[d.V()];
		this.onStack = new bool[d.V()];
		this.edgeTo = new int[d.V()];
		for (int i = 0; i < d.V(); i++)
		{
			if (!this.marked[i])
			{
				this.dfs(d, i);
			}
		}
	}
	
	
	private bool check(Digraph digraph)
	{
		if (this.hasCycle())
		{
			int num = -1;
			int num2 = -1;
			Iterator iterator = this.cycle().iterator();
			while (iterator.hasNext())
			{
				int num3 = ((Integer)iterator.next()).intValue();
				if (num == -1)
				{
					num = num3;
				}
				num2 = num3;
			}
			if (num != num2)
			{
				System.err.printf("cycle begins with %d and ends with %d\n", new object[]
				{
					Integer.valueOf(num),
					Integer.valueOf(num2)
				});
				return false;
			}
		}
		return true;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		
		In i = new In(strarr[0]);
		Digraph d = new Digraph(i);
		DirectedCycle directedCycle = new DirectedCycle(d);
		if (directedCycle.hasCycle())
		{
			StdOut.print("Cycle: ");
			Iterator iterator = directedCycle.cycle().iterator();
			while (iterator.hasNext())
			{
				int i2 = ((Integer)iterator.next()).intValue();
				StdOut.print(new StringBuilder().append(i2).append(" ").toString());
			}
			StdOut.println();
		}
		else
		{
			StdOut.println("No cycle");
		}
	}
}