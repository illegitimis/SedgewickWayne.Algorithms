public class DirectedDFS
{
	private bool[] marked;
	private int count;
	
	
	private void dfs(Digraph digraph, int num)
	{
		this.count++;
		this.marked[num] = true;
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
/*	[Signature("(LDigraph;Ljava/lang/Iterable<Ljava/lang/Integer;>;)V")]*/
	
	public DirectedDFS(Digraph d, Iterable i)
	{
		this.marked = new bool[d.V()];
		Iterator iterator = i.iterator();
		while (iterator.hasNext())
		{
			int num = ((Integer)iterator.next()).intValue();
			if (!this.marked[num])
			{
				this.dfs(d, num);
			}
		}
	}
	
	public virtual bool marked(int i)
	{
		return this.marked[i];
	}
	
	
	public DirectedDFS(Digraph d, int i)
	{
		this.marked = new bool[d.V()];
		this.dfs(d, i);
	}
	public virtual int count()
	{
		return this.count;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		
		In i = new In(strarr[0]);
		Digraph digraph = new Digraph(i);
		Bag bag = new Bag();
		for (int j = 1; j < strarr.Length; j++)
		{
			int k = Integer.parseInt(strarr[j]);
			bag.add(Integer.valueOf(k));
		}
		DirectedDFS directedDFS = new DirectedDFS(digraph, bag);
		for (int k = 0; k < digraph.V(); k++)
		{
			if (directedDFS.marked(k))
			{
				StdOut.print(new StringBuilder().append(k).append(" ").toString());
			}
		}
		StdOut.println();
	}
}