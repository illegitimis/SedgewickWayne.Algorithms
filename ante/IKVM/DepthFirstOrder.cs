public class DepthFirstOrder
{
	private bool[] marked;
	private int[] pre;
	private int[] post;
//[Signature("LQueue<Ljava/lang/Integer;>;")]
	private Queue preorder;
//[Signature("LQueue<Ljava/lang/Integer;>;")]
	private Queue postorder;
	private int preCounter;
	private int postCounter;
	
	
	private void dfs(Digraph digraph, int num)
	{
		this.marked[num] = true;
		int[] arg_23_0 = this.pre;
		int num2 = this.preCounter;
		int arg_23_2 = num2;
		this.preCounter = num2 + 1;
		arg_23_0[num] = arg_23_2;
		this.preorder.enqueue(Integer.valueOf(num));
		Iterator iterator = digraph.adj(num).iterator();
		while (iterator.hasNext())
		{
			int num3 = ((Integer)iterator.next()).intValue();
			if (!this.marked[num3])
			{
				this.dfs(digraph, num3);
			}
		}
		this.postorder.enqueue(Integer.valueOf(num));
		int[] arg_9A_0 = this.post;
		num2 = this.postCounter;
		int arg_9A_2 = num2;
		this.postCounter = num2 + 1;
		arg_9A_0[num] = arg_9A_2;
	}
	
	
	private void dfs(EdgeWeightedDigraph edgeWeightedDigraph, int num)
	{
		this.marked[num] = true;
		int[] arg_23_0 = this.pre;
		int num2 = this.preCounter;
		int arg_23_2 = num2;
		this.preCounter = num2 + 1;
		arg_23_0[num] = arg_23_2;
		this.preorder.enqueue(Integer.valueOf(num));
		Iterator iterator = edgeWeightedDigraph.adj(num).iterator();
		while (iterator.hasNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)iterator.next();
			int num3 = directedEdge.to();
			if (!this.marked[num3])
			{
				this.dfs(edgeWeightedDigraph, num3);
			}
		}
		this.postorder.enqueue(Integer.valueOf(num));
		int[] arg_9F_0 = this.post;
		num2 = this.postCounter;
		int arg_9F_2 = num2;
		this.postCounter = num2 + 1;
		arg_9F_0[num] = arg_9F_2;
	}
/*	[Signature("()Ljava/lang/Iterable<Ljava/lang/Integer;>;")]*/
	public virtual Iterable post()
	{
		return this.postorder;
	}
	
	public virtual int post(int i)
	{
		return this.post[i];
	}
/*	[Signature("()Ljava/lang/Iterable<Ljava/lang/Integer;>;")]*/
	public virtual Iterable pre()
	{
		return this.preorder;
	}
	
	public virtual int pre(int i)
	{
		return this.pre[i];
	}
	
	
	public DepthFirstOrder(Digraph d)
	{
		this.pre = new int[d.V()];
		this.post = new int[d.V()];
		this.postorder = new Queue();
		this.preorder = new Queue();
		this.marked = new bool[d.V()];
		for (int i = 0; i < d.V(); i++)
		{
			if (!this.marked[i])
			{
				this.dfs(d, i);
			}
		}
	}
/*	[Signature("()Ljava/lang/Iterable<Ljava/lang/Integer;>;")]*/
	
	public virtual Iterable reversePost()
	{
		Stack stack = new Stack();
		Iterator iterator = this.postorder.iterator();
		while (iterator.hasNext())
		{
			int i = ((Integer)iterator.next()).intValue();
			stack.push(Integer.valueOf(i));
		}
		return stack;
	}
	
	
	public DepthFirstOrder(EdgeWeightedDigraph ewd)
	{
		this.pre = new int[ewd.V()];
		this.post = new int[ewd.V()];
		this.postorder = new Queue();
		this.preorder = new Queue();
		this.marked = new bool[ewd.V()];
		for (int i = 0; i < ewd.V(); i++)
		{
			if (!this.marked[i])
			{
				this.dfs(ewd, i);
			}
		}
	}
	
	
	private bool check(Digraph digraph)
	{
		int num = 0;
		Iterator iterator = this.post().iterator();
		while (iterator.hasNext())
		{
			int i = ((Integer)iterator.next()).intValue();
			if (this.post(i) != num)
			{
				StdOut.println("post(v) and post() inconsistent");
				return false;
			}
			num++;
		}
		num = 0;
		iterator = this.pre().iterator();
		while (iterator.hasNext())
		{
			int i = ((Integer)iterator.next()).intValue();
			if (this.pre(i) != num)
			{
				StdOut.println("pre(v) and pre() inconsistent");
				return false;
			}
			num++;
		}
		return true;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		
		In i = new In(strarr[0]);
		Digraph digraph = new Digraph(i);
		DepthFirstOrder depthFirstOrder = new DepthFirstOrder(digraph);
		StdOut.println("   v  pre post");
		StdOut.println("--------------");
		for (int j = 0; j < digraph.V(); j++)
		{
			StdOut.printf("%4d %4d %4d\n", new object[]
			{
				Integer.valueOf(j),
				Integer.valueOf(depthFirstOrder.pre(j)),
				Integer.valueOf(depthFirstOrder.post(j))
			});
		}
		StdOut.print("Preorder:  ");
		Iterator iterator = depthFirstOrder.pre().iterator();
		while (iterator.hasNext())
		{
			int i2 = ((Integer)iterator.next()).intValue();
			StdOut.print(new StringBuilder().append(i2).append(" ").toString());
		}
		StdOut.println();
		StdOut.print("Postorder: ");
		iterator = depthFirstOrder.post().iterator();
		while (iterator.hasNext())
		{
			int i2 = ((Integer)iterator.next()).intValue();
			StdOut.print(new StringBuilder().append(i2).append(" ").toString());
		}
		StdOut.println();
		StdOut.print("Reverse postorder: ");
		iterator = depthFirstOrder.reversePost().iterator();
		while (iterator.hasNext())
		{
			int i2 = ((Integer)iterator.next()).intValue();
			StdOut.print(new StringBuilder().append(i2).append(" ").toString());
		}
		StdOut.println();
	}
}