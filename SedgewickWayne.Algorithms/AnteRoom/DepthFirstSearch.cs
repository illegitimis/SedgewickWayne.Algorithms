public class DepthFirstSearch
{
	private bool[] marked;
	private int count;
	
	
	private void dfs(Graph graph, int num)
	{
		this.count++;
		this.marked[num] = true;
		Iterator iterator = graph.adj(num).iterator();
		while (iterator.hasNext())
		{
			int num2 = ((Integer)iterator.next()).intValue();
			if (!this.marked[num2])
			{
				this.dfs(graph, num2);
			}
		}
	}
	
	
	public DepthFirstSearch(Graph g, int i)
	{
		this.marked = new bool[g.V()];
		this.dfs(g, i);
	}
	
	public virtual bool marked(int i)
	{
		return this.marked[i];
	}
	public virtual int count()
	{
		return this.count;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		
		In i = new In(strarr[0]);
		Graph graph = new Graph(i);
		int i2 = Integer.parseInt(strarr[1]);
		DepthFirstSearch depthFirstSearch = new DepthFirstSearch(graph, i2);
		for (int j = 0; j < graph.V(); j++)
		{
			if (depthFirstSearch.marked(j))
			{
				StdOut.print(new StringBuilder().append(j).append(" ").toString());
			}
		}
		StdOut.println();
		if (depthFirstSearch.count() != graph.V())
		{
			StdOut.println("NOT connected");
		}
		else
		{
			StdOut.println("connected");
		}
	}
}