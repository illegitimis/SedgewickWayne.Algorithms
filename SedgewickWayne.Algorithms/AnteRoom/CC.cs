public class CC
{
	private bool[] marked;
	private int[] id;
	private int[] size;
	private int count;
	
	
	private void dfs(Graph graph, int num)
	{
		this.marked[num] = true;
		this.id[num] = this.count;
		int[] arg_24_0 = this.size;
		int num2 = this.count;
		int[] array = arg_24_0;
		array[num2]++;
		Iterator iterator = graph.adj(num).iterator();
		while (iterator.hasNext())
		{
			int num3 = ((Integer)iterator.next()).intValue();
			if (!this.marked[num3])
			{
				this.dfs(graph, num3);
			}
		}
	}
	
	public virtual int id(int i)
	{
		return this.id[i];
	}
	
	
	public CC(Graph g)
	{
		this.marked = new bool[g.V()];
		this.id = new int[g.V()];
		this.size = new int[g.V()];
		for (int i = 0; i < g.V(); i++)
		{
			if (!this.marked[i])
			{
				this.dfs(g, i);
				this.count++;
			}
		}
	}
	public virtual int count()
	{
		return this.count;
	}
	
	public virtual int size(int i)
	{
		return this.size[this.id[i]];
	}
	
	
	public virtual bool areConnected(int i1, int i2)
	{
		return this.id(i1) == this.id(i2);
	}
	
	
	/**/public static void main(string[] strarr)
	{
		
		In i = new In(strarr[0]);
		Graph graph = new Graph(i);
		CC cC = new CC(graph);
		int num = cC.count();
		StdOut.println(new StringBuilder().append(num).append(" components").toString());
		Queue[] array = (Queue[])new Queue[num];
		for (int j = 0; j < num; j++)
		{
			array[j] = new Queue();
		}
		for (int j = 0; j < graph.V(); j++)
		{
			array[cC.id(j)].enqueue(Integer.valueOf(j));
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
}