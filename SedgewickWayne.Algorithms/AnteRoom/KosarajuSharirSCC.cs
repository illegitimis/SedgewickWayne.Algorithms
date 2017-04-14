public class KosarajuSharirSCC
{
	private bool[] marked;
	private int[] id;
	private int count;
//[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
	internal static bool s_assertionsDisabled;
	
	
	
	
	private void dfs(Digraph digraph, int num)
	{
		this.marked[num] = true;
		this.id[num] = this.count;
		Iterator iterator = digraph.adj(num).iterator();
		while (iterator.hasNext())
		{
			int num2 = ((Integer)iterator.next()).intValue();
			if (!this.marked[num2])
			{
				this.dfs(digraph, num2);
			}
		}
	}
	
	
	private bool check(Digraph digraph)
	{
		TransitiveClosure transitiveClosure = new TransitiveClosure(digraph);
		for (int i = 0; i < digraph.V(); i++)
		{
			for (int j = 0; j < digraph.V(); j++)
			{
				if (this.stronglyConnected(i, j) != ((!transitiveClosure.reachable(i, j) || !transitiveClosure.reachable(j, i)) ? false : true))
				{
					return false;
				}
			}
		}
		return true;
	}
	
	public virtual bool stronglyConnected(int i1, int i2)
	{
		return this.id[i1] == this.id[i2];
	}
	
	
	public KosarajuSharirSCC(Digraph d)
	{
		DepthFirstOrder depthFirstOrder = new DepthFirstOrder(d.reverse());
		this.marked = new bool[d.V()];
		this.id = new int[d.V()];
		Iterator iterator = depthFirstOrder.reversePost().iterator();
		while (iterator.hasNext())
		{
			int num = ((Integer)iterator.next()).intValue();
			if (!this.marked[num])
			{
				this.dfs(d, num);
				this.count++;
			}
		}
		if (!KosarajuSharirSCC.s_assertionsDisabled && !this.check(d))
		{
			
			throw new AssertionError();
		}
	}
	public virtual int count()
	{
		return this.count;
	}
	
	public virtual int id(int i)
	{
		return this.id[i];
	}
	
	
	/**/public static void main(string[] strarr)
	{
		
		In i = new In(strarr[0]);
		Digraph digraph = new Digraph(i);
		KosarajuSharirSCC kosarajuSharirSCC = new KosarajuSharirSCC(digraph);
		int num = kosarajuSharirSCC.count();
		StdOut.println(new StringBuilder().append(num).append(" components").toString());
		Queue[] array = (Queue[])new Queue[num];
		for (int j = 0; j < num; j++)
		{
			array[j] = new Queue();
		}
		for (int j = 0; j < digraph.V(); j++)
		{
			array[kosarajuSharirSCC.id(j)].enqueue(Integer.valueOf(j));
		}
		for (int j = 0; j < num; j++)
		{
			Iterator iterator = array[j].iterator();
			while (iterator.hasNext())
			{
				int i2 = ((Integer)iterator.next()).intValue();
				StdOut.print(new StringBuilder().append(i2).append(" ").toString());
			}
			StdOut.println();
		}
	}
	
	static KosarajuSharirSCC()
	{
		KosarajuSharirSCC.s_assertionsDisabled = !ClassLiteral<KosarajuSharirSCC>.Value.desiredAssertionStatus();
	}
}