public class FileIndex
{
	
	
	public FileIndex()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		ST sT = new ST();
		StdOut.println("Indexing files");
		int num = strarr.Length;
		for (int i = 0; i < num; i++)
		{
			string text = strarr[i];
			StdOut.println(new StringBuilder().append("  ").append(text).toString());
			File file = new File(text);
			In @in = new In(file);
			while (!@in.isEmpty())
			{
				string c = @in.readString();
				if (!sT.contains(c))
				{
					sT.put(c, new SET());
				}
				SET sET = (SET)sT.get(c);
				sET.add(file);
			}
		}
		while (!StdIn.isEmpty())
		{
			string c2 = StdIn.readString();
			if (sT.contains(c2))
			{
				SET sET2 = (SET)sT.get(c2);
				Iterator iterator = sET2.iterator();
				while (iterator.hasNext())
				{
					File file2 = (File)iterator.next();
					StdOut.println(new StringBuilder().append("  ").append(file2.getName()).toString());
				}
			}
		}
	}
}

public class FlowEdge
{
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private int v;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private int w;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private double capacity;
	private double flow;
	
	
	public FlowEdge(int i1, int i2, double d)
	{
		if (i1 < 0)
		{
			string arg_16_0 = "Vertex name must be a nonnegative integer";
			
			throw new IndexOutOfRangeException(arg_16_0);
		}
		if (i2 < 0)
		{
			string arg_2A_0 = "Vertex name must be a nonnegative integer";
			
			throw new IndexOutOfRangeException(arg_2A_0);
		}
		if (d < (double)0f)
		{
			string arg_43_0 = "Edge capacity must be nonnegaitve";
			
			throw new ArgumentException(arg_43_0);
		}
		this.v = i1;
		this.w = i2;
		this.capacity = d;
		this.flow = (double)0f;
	}
	public virtual int from()
	{
		return this.v;
	}
	public virtual double flow()
	{
		return this.flow;
	}
	public virtual int to()
	{
		return this.w;
	}
	
	
	public FlowEdge(int i1, int i2, double d1, double d2)
	{
		if (i1 < 0)
		{
			string arg_16_0 = "Vertex name must be a nonnegative integer";
			
			throw new IndexOutOfRangeException(arg_16_0);
		}
		if (i2 < 0)
		{
			string arg_2A_0 = "Vertex name must be a nonnegative integer";
			
			throw new IndexOutOfRangeException(arg_2A_0);
		}
		if (d1 < (double)0f)
		{
			string arg_43_0 = "Edge capacity must be nonnegaitve";
			
			throw new ArgumentException(arg_43_0);
		}
		if (d2 > d1)
		{
			string arg_5A_0 = "Flow exceeds capacity";
			
			throw new ArgumentException(arg_5A_0);
		}
		if (d2 < (double)0f)
		{
			string arg_74_0 = "Flow must be nonnnegative";
			
			throw new ArgumentException(arg_74_0);
		}
		this.v = i1;
		this.w = i2;
		this.capacity = d1;
		this.flow = d2;
	}
	
	
	public FlowEdge(FlowEdge fe)
	{
		this.v = fe.v;
		this.w = fe.w;
		this.capacity = fe.capacity;
		this.flow = fe.flow;
	}
	public virtual double capacity()
	{
		return this.capacity;
	}
	
	
	public virtual int other(int i)
	{
		if (i == this.v)
		{
			return this.w;
		}
		if (i == this.w)
		{
			return this.v;
		}
		string arg_2A_0 = "Illegal endpoint";
		
		throw new ArgumentException(arg_2A_0);
	}
	
	
	public virtual double residualCapacityTo(int i)
	{
		if (i == this.v)
		{
			return this.flow;
		}
		if (i == this.w)
		{
			return this.capacity - this.flow;
		}
		string arg_31_0 = "Illegal endpoint";
		
		throw new ArgumentException(arg_31_0);
	}
	
	
	public virtual void addResidualFlowTo(int i, double d)
	{
		if (i == this.v)
		{
			this.flow -= d;
		}
		else
		{
			if (i != this.w)
			{
				string arg_40_0 = "Illegal endpoint";
				
				throw new ArgumentException(arg_40_0);
			}
			this.flow += d;
		}
		if (java.lang.Double.isNaN(d))
		{
			string arg_59_0 = "Change in flow = NaN";
			
			throw new ArgumentException(arg_59_0);
		}
		if (this.flow < (double)0f)
		{
			string arg_76_0 = "Flow is negative";
			
			throw new ArgumentException(arg_76_0);
		}
		if (this.flow > this.capacity)
		{
			string arg_94_0 = "Flow exceeds capacity";
			
			throw new ArgumentException(arg_94_0);
		}
	}
	
	
	public override string ToString()
	{
		return new StringBuilder().append(this.v).append("->").append(this.w).append(" ").append(this.flow).append("/").append(this.capacity).toString();
	}
	
	
	/**/public static void main(string[] strarr)
	{
		FlowEdge obj = new FlowEdge(12, 23, 3.14);
		StdOut.println(obj);
	}
}

public class FlowNetwork
{
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private int V;
	private int E;
//[Signature("[LBag<LFlowEdge;>;")]
	private Bag[] adj;
	
	
	public FlowNetwork(int i)
	{
		if (i < 0)
		{
			string arg_16_0 = "Number of vertices in a Graph must be nonnegative";
			
			throw new ArgumentException(arg_16_0);
		}
		this.V = i;
		this.E = 0;
		this.adj = (Bag[])new Bag[i];
		for (int j = 0; j < i; j++)
		{
			this.adj[j] = new Bag();
		}
	}
	
	
	public virtual void addEdge(FlowEdge fe)
	{
		int num = fe.from();
		int num2 = fe.to();
		if (num < 0 || num >= this.V)
		{
			string arg_51_0 = new StringBuilder().append("vertex ").append(num).append(" is not between 0 and ").append(this.V - 1).toString();
			
			throw new IndexOutOfRangeException(arg_51_0);
		}
		if (num2 < 0 || num2 >= this.V)
		{
			string arg_9A_0 = new StringBuilder().append("vertex ").append(num2).append(" is not between 0 and ").append(this.V - 1).toString();
			
			throw new IndexOutOfRangeException(arg_9A_0);
		}
		this.adj[num].add(fe);
		this.adj[num2].add(fe);
		this.E++;
	}
/*	[Signature("(I)Ljava/lang/Iterable<LFlowEdge;>;")]*/
	
	public virtual Iterable adj(int i)
	{
		if (i < 0 || i >= this.V)
		{
			string arg_43_0 = new StringBuilder().append("vertex ").append(i).append(" is not between 0 and ").append(this.V - 1).toString();
			
			throw new IndexOutOfRangeException(arg_43_0);
		}
		return this.adj[i];
	}
	
	
	public FlowNetwork(In i) : this(i.readInt())
	{
		int num = i.readInt();
		if (num < 0)
		{
			string arg_23_0 = "Number of edges must be nonnegative";
			
			throw new ArgumentException(arg_23_0);
		}
		for (int j = 0; j < num; j++)
		{
			int num2 = i.readInt();
			int num3 = i.readInt();
			if (num2 < 0 || num2 >= this.V)
			{
				string arg_84_0 = new StringBuilder().append("vertex ").append(num2).append(" is not between 0 and ").append(this.V - 1).toString();
				
				throw new IndexOutOfRangeException(arg_84_0);
			}
			if (num3 < 0 || num3 >= this.V)
			{
				string arg_D0_0 = new StringBuilder().append("vertex ").append(num3).append(" is not between 0 and ").append(this.V - 1).toString();
				
				throw new IndexOutOfRangeException(arg_D0_0);
			}
			double d = i.readDouble();
			this.addEdge(new FlowEdge(num2, num3, d));
		}
	}
	
	
	public FlowNetwork(int i1, int i2) : this(i1)
	{
		if (i2 < 0)
		{
			string arg_17_0 = "Number of edges must be nonnegative";
			
			throw new ArgumentException(arg_17_0);
		}
		for (int j = 0; j < i2; j++)
		{
			int i3 = StdRandom.uniform(i1);
			int i4 = StdRandom.uniform(i1);
			double d = (double)StdRandom.uniform(100);
			this.addEdge(new FlowEdge(i3, i4, d));
		}
	}
	public virtual int V()
	{
		return this.V;
	}
	public virtual int E()
	{
		return this.E;
	}
/*	[Signature("()Ljava/lang/Iterable<LFlowEdge;>;")]*/
	
	public virtual Iterable edges()
	{
		Bag bag = new Bag();
		for (int i = 0; i < this.V; i++)
		{
			Iterator iterator = this.adj(i).iterator();
			while (iterator.hasNext())
			{
				FlowEdge flowEdge = (FlowEdge)iterator.next();
				if (flowEdge.to() != i)
				{
					bag.add(flowEdge);
				}
			}
		}
		return bag;
	}
	
	
	public override string ToString()
	{
		string property = System.getProperty("line.separator");
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.append(new StringBuilder().append(this.V).append(" ").append(this.E).append(property).toString());
		for (int i = 0; i < this.V; i++)
		{
			stringBuilder.append(new StringBuilder().append(i).append(":  ").toString());
			Iterator iterator = this.adj[i].iterator();
			while (iterator.hasNext())
			{
				FlowEdge flowEdge = (FlowEdge)iterator.next();
				if (flowEdge.to() != i)
				{
					stringBuilder.append(new StringBuilder().append(flowEdge).append("  ").toString());
				}
			}
			stringBuilder.append(property);
		}
		return stringBuilder.toString();
	}
	
	
	/**/public static void main(string[] strarr)
	{
		
		In i = new In(strarr[0]);
		FlowNetwork obj = new FlowNetwork(i);
		StdOut.println(obj);
	}
}

public class FloydWarshall
{
	private bool hasNegativeCycle;
	private double[][] distTo;
	private DirectedEdge[][] edgeTo;
//[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
	internal static bool s_assertionsDisabled;
	
	
	public virtual bool hasNegativeCycle()
	{
		return this.hasNegativeCycle;
	}
	
	public virtual bool hasPath(int i1, int i2)
	{
		return this.distTo[i1][i2] < double.PositiveInfinity;
	}
	
	
	public FloydWarshall(AdjMatrixEdgeWeightedDigraph amewd)
	{
		int num = amewd.V();
		int arg_1E_0 = num;
		int arg_19_0 = num;
		int[] array = new int[2];
		int num2 = arg_19_0;
		array[1] = num2;
		num2 = arg_1E_0;
		array[0] = num2;
		this.distTo = (double[][])ByteCodeHelper.multianewarray(typeof(double[][]).TypeHandle, array);
		int arg_47_0 = num;
		int arg_42_0 = num;
		array = new int[2];
		num2 = arg_42_0;
		array[1] = num2;
		num2 = arg_47_0;
		array[0] = num2;
		this.edgeTo = (DirectedEdge[][])ByteCodeHelper.multianewarray(typeof(DirectedEdge[][]).TypeHandle, array);
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num; j++)
			{
				this.distTo[i][j] = double.PositiveInfinity;
			}
		}
		for (int i = 0; i < amewd.V(); i++)
		{
			Iterator iterator = amewd.adj(i).iterator();
			while (iterator.hasNext())
			{
				DirectedEdge directedEdge = (DirectedEdge)iterator.next();
				this.distTo[directedEdge.from()][directedEdge.to()] = directedEdge.weight();
				this.edgeTo[directedEdge.from()][directedEdge.to()] = directedEdge;
			}
			if (this.distTo[i][i] >= (double)0f)
			{
				this.distTo[i][i] = (double)0f;
				this.edgeTo[i][i] = null;
			}
		}
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num; j++)
			{
				if (this.edgeTo[j][i] != null)
				{
					for (int k = 0; k < num; k++)
					{
						if (this.distTo[j][k] > this.distTo[j][i] + this.distTo[i][k])
						{
							this.distTo[j][k] = this.distTo[j][i] + this.distTo[i][k];
							this.edgeTo[j][k] = this.edgeTo[i][k];
						}
					}
					if (this.distTo[j][j] < (double)0f)
					{
						this.hasNegativeCycle = true;
						return;
					}
				}
			}
		}
	}
	
	
	public virtual double dist(int i1, int i2)
	{
		if (this.hasNegativeCycle())
		{
			string arg_12_0 = "Negative cost cycle exists";
			
			throw new NotSupportedException(arg_12_0);
		}
		return this.distTo[i1][i2];
	}
/*	[Signature("()Ljava/lang/Iterable<LDirectedEdge;>;")]*/
	
	public virtual Iterable negativeCycle()
	{
		int i = 0;
		while (i < this.distTo.Length)
		{
			if (this.distTo[i][i] < (double)0f)
			{
				int num = this.edgeTo.Length;
				EdgeWeightedDigraph edgeWeightedDigraph = new EdgeWeightedDigraph(num);
				for (int j = 0; j < num; j++)
				{
					if (this.edgeTo[i][j] != null)
					{
						edgeWeightedDigraph.addEdge(this.edgeTo[i][j]);
					}
				}
				EdgeWeightedDirectedCycle edgeWeightedDirectedCycle = new EdgeWeightedDirectedCycle(edgeWeightedDigraph);
				if (!FloydWarshall.s_assertionsDisabled && !edgeWeightedDirectedCycle.hasCycle())
				{
					
					throw new AssertionError();
				}
				return edgeWeightedDirectedCycle.cycle();
			}
			else
			{
				i++;
			}
		}
		return null;
	}
/*	[Signature("(II)Ljava/lang/Iterable<LDirectedEdge;>;")]*/
	
	public virtual Iterable path(int i1, int i2)
	{
		if (this.hasNegativeCycle())
		{
			string arg_12_0 = "Negative cost cycle exists";
			
			throw new NotSupportedException(arg_12_0);
		}
		if (!this.hasPath(i1, i2))
		{
			return null;
		}
		Stack stack = new Stack();
		for (DirectedEdge directedEdge = this.edgeTo[i1][i2]; directedEdge != null; directedEdge = this.edgeTo[i1][directedEdge.from()])
		{
			stack.push(directedEdge);
		}
		return stack;
	}
	
	
	private bool check(EdgeWeightedDigraph edgeWeightedDigraph, int num)
	{
		if (!this.hasNegativeCycle())
		{
			for (int i = 0; i < edgeWeightedDigraph.V(); i++)
			{
				Iterator iterator = edgeWeightedDigraph.adj(i).iterator();
				while (iterator.hasNext())
				{
					DirectedEdge directedEdge = (DirectedEdge)iterator.next();
					int num2 = directedEdge.to();
					for (int j = 0; j < edgeWeightedDigraph.V(); j++)
					{
						if (this.distTo[j][num2] > this.distTo[j][i] + directedEdge.weight())
						{
							System.err.println(new StringBuilder().append("edge ").append(directedEdge).append(" is eligible").toString());
							return false;
						}
					}
				}
			}
		}
		return true;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		int num = Integer.parseInt(strarr[0]);
		int num2 = Integer.parseInt(strarr[1]);
		AdjMatrixEdgeWeightedDigraph adjMatrixEdgeWeightedDigraph = new AdjMatrixEdgeWeightedDigraph(num);
		for (int i = 0; i < num2; i++)
		{
			int j = ByteCodeHelper.d2i((double)num * java.lang.Math.random());
			int k = ByteCodeHelper.d2i((double)num * java.lang.Math.random());
			double num3 = (double)java.lang.Math.round(100.0 * (java.lang.Math.random() - 0.15)) / 100.0;
			if (j == k)
			{
				adjMatrixEdgeWeightedDigraph.addEdge(new DirectedEdge(j, k, java.lang.Math.abs(num3)));
			}
			else
			{
				adjMatrixEdgeWeightedDigraph.addEdge(new DirectedEdge(j, k, num3));
			}
		}
		StdOut.println(adjMatrixEdgeWeightedDigraph);
		FloydWarshall floydWarshall = new FloydWarshall(adjMatrixEdgeWeightedDigraph);
		StdOut.printf("  ", new object[0]);
		for (int j = 0; j < adjMatrixEdgeWeightedDigraph.V(); j++)
		{
			StdOut.printf("%6d ", new object[]
			{
				Integer.valueOf(j)
			});
		}
		StdOut.println();
		for (int j = 0; j < adjMatrixEdgeWeightedDigraph.V(); j++)
		{
			StdOut.printf("%3d: ", new object[]
			{
				Integer.valueOf(j)
			});
			for (int k = 0; k < adjMatrixEdgeWeightedDigraph.V(); k++)
			{
				if (floydWarshall.hasPath(j, k))
				{
					StdOut.printf("%6.2f ", new object[]
					{
						java.lang.Double.valueOf(floydWarshall.dist(j, k))
					});
				}
				else
				{
					StdOut.printf("  Inf ", new object[0]);
				}
			}
			StdOut.println();
		}
		if (floydWarshall.hasNegativeCycle())
		{
			StdOut.println("Negative cost cycle:");
			Iterator iterator = floydWarshall.negativeCycle().iterator();
			while (iterator.hasNext())
			{
				DirectedEdge obj = (DirectedEdge)iterator.next();
				StdOut.println(obj);
			}
			StdOut.println();
		}
		else
		{
			for (int j = 0; j < adjMatrixEdgeWeightedDigraph.V(); j++)
			{
				for (int k = 0; k < adjMatrixEdgeWeightedDigraph.V(); k++)
				{
					if (floydWarshall.hasPath(j, k))
					{
						StdOut.printf("%d to %d (%5.2f)  ", new object[]
						{
							Integer.valueOf(j),
							Integer.valueOf(k),
							java.lang.Double.valueOf(floydWarshall.dist(j, k))
						});
						Iterator iterator2 = floydWarshall.path(j, k).iterator();
						while (iterator2.hasNext())
						{
							DirectedEdge obj2 = (DirectedEdge)iterator2.next();
							StdOut.print(new StringBuilder().append(obj2).append("  ").toString());
						}
						StdOut.println();
					}
					else
					{
						StdOut.printf("%d to %d no path\n", new object[]
						{
							Integer.valueOf(j),
							Integer.valueOf(k)
						});
					}
				}
			}
		}
	}
	
	static FloydWarshall()
	{
		FloydWarshall.s_assertionsDisabled = !ClassLiteral<FloydWarshall>.Value.desiredAssertionStatus();
	}
}

public class FordFulkerson
{
	private bool[] marked;
	private FlowEdge[] edgeTo;
	private double value;
//[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
	internal static bool s_assertionsDisabled;
	
	
	
	
	public FordFulkerson(FlowNetwork fn, int i1, int i2)
	{
		if (i1 < 0 || i1 >= fn.V())
		{
			string arg_34_0 = new StringBuilder().append("Source s is invalid: ").append(i1).toString();
			
			throw new IndexOutOfRangeException(arg_34_0);
		}
		if (i2 < 0 || i2 >= fn.V())
		{
			string arg_66_0 = new StringBuilder().append("Sink t is invalid: ").append(i2).toString();
			
			throw new IndexOutOfRangeException(arg_66_0);
		}
		if (i1 == i2)
		{
			string arg_7A_0 = "Source equals sink";
			
			throw new ArgumentException(arg_7A_0);
		}
		this.value = this.excess(fn, i2);
		if (!this.isFeasible(fn, i1, i2))
		{
			string arg_A4_0 = "Initial flow is infeasible";
			
			throw new ArgumentException(arg_A4_0);
		}
		while (this.hasAugmentingPath(fn, i1, i2))
		{
			double num = double.PositiveInfinity;
			for (int num2 = i2; num2 != i1; num2 = this.edgeTo[num2].other(num2))
			{
				num = java.lang.Math.min(num, this.edgeTo[num2].residualCapacityTo(num2));
			}
			for (int num2 = i2; num2 != i1; num2 = this.edgeTo[num2].other(num2))
			{
				this.edgeTo[num2].addResidualFlowTo(num2, num);
			}
			this.value += num;
		}
		if (!FordFulkerson.s_assertionsDisabled && !this.check(fn, i1, i2))
		{
			
			throw new AssertionError();
		}
	}
	public virtual double value()
	{
		return this.value;
	}
	
	
	private double excess(FlowNetwork flowNetwork, int num)
	{
		double num2 = (double)0f;
		Iterator iterator = flowNetwork.adj(num).iterator();
		while (iterator.hasNext())
		{
			FlowEdge flowEdge = (FlowEdge)iterator.next();
			if (num == flowEdge.from())
			{
				num2 -= flowEdge.flow();
			}
			else
			{
				num2 += flowEdge.flow();
			}
		}
		return num2;
	}
	
	
	private bool isFeasible(FlowNetwork flowNetwork, int num, int num2)
	{
		double num3 = 1E-11;
		for (int i = 0; i < flowNetwork.V(); i++)
		{
			Iterator iterator = flowNetwork.adj(i).iterator();
			while (iterator.hasNext())
			{
				FlowEdge flowEdge = (FlowEdge)iterator.next();
				if (flowEdge.flow() < -num3 || flowEdge.flow() > flowEdge.capacity() + num3)
				{
					System.err.println(new StringBuilder().append("Edge does not satisfy capacity constraints: ").append(flowEdge).toString());
					return false;
				}
			}
		}
		if (java.lang.Math.abs(this.value + this.excess(flowNetwork, num)) > num3)
		{
			System.err.println(new StringBuilder().append("Excess at source = ").append(this.excess(flowNetwork, num)).toString());
			System.err.println(new StringBuilder().append("Max flow         = ").append(this.value).toString());
			return false;
		}
		if (java.lang.Math.abs(this.value - this.excess(flowNetwork, num2)) > num3)
		{
			System.err.println(new StringBuilder().append("Excess at sink   = ").append(this.excess(flowNetwork, num2)).toString());
			System.err.println(new StringBuilder().append("Max flow         = ").append(this.value).toString());
			return false;
		}
		for (int i = 0; i < flowNetwork.V(); i++)
		{
			if (i != num)
			{
				if (i != num2)
				{
					if (java.lang.Math.abs(this.excess(flowNetwork, i)) > num3)
					{
						System.err.println(new StringBuilder().append("Net flow out of ").append(i).append(" doesn't equal zero").toString());
						return false;
					}
				}
			}
		}
		return true;
	}
	
	
	private bool hasAugmentingPath(FlowNetwork flowNetwork, int num, int num2)
	{
		this.edgeTo = new FlowEdge[flowNetwork.V()];
		this.marked = new bool[flowNetwork.V()];
		Queue queue = new Queue();
		queue.enqueue(Integer.valueOf(num));
		this.marked[num] = true;
		while (!queue.isEmpty())
		{
			int i = ((Integer)queue.dequeue()).intValue();
			Iterator iterator = flowNetwork.adj(i).iterator();
			while (iterator.hasNext())
			{
				FlowEdge flowEdge = (FlowEdge)iterator.next();
				int num3 = flowEdge.other(i);
				if (flowEdge.residualCapacityTo(num3) > (double)0f && !this.marked[num3])
				{
					this.edgeTo[num3] = flowEdge;
					this.marked[num3] = true;
					queue.enqueue(Integer.valueOf(num3));
				}
			}
		}
		return this.marked[num2];
	}
	
	
	private bool check(FlowNetwork flowNetwork, int num, int num2)
	{
		if (!this.isFeasible(flowNetwork, num, num2))
		{
			System.err.println("Flow is infeasible");
			return false;
		}
		if (!this.inCut(num))
		{
			System.err.println(new StringBuilder().append("source ").append(num).append(" is not on source side of min cut").toString());
			return false;
		}
		if (this.inCut(num2))
		{
			System.err.println(new StringBuilder().append("sink ").append(num2).append(" is on source side of min cut").toString());
			return false;
		}
		double num3 = (double)0f;
		for (int i = 0; i < flowNetwork.V(); i++)
		{
			Iterator iterator = flowNetwork.adj(i).iterator();
			while (iterator.hasNext())
			{
				FlowEdge flowEdge = (FlowEdge)iterator.next();
				if (i == flowEdge.from() && this.inCut(flowEdge.from()) && !this.inCut(flowEdge.to()))
				{
					num3 += flowEdge.capacity();
				}
			}
		}
		double num4 = 1E-11;
		if (java.lang.Math.abs(num3 - this.value) > num4)
		{
			System.err.println(new StringBuilder().append("Max flow value = ").append(this.value).append(", min cut value = ").append(num3).toString());
			return false;
		}
		return true;
	}
	
	
	public virtual bool inCut(int i)
	{
		int num = this.marked.Length;
		if (i < 0 || i >= num)
		{
			string arg_41_0 = new StringBuilder().append("vertex ").append(i).append(" is not between 0 and ").append(num - 1).toString();
			
			throw new IndexOutOfRangeException(arg_41_0);
		}
		return this.marked[i];
	}
	
	
	/**/public static void main(string[] strarr)
	{
		int num = Integer.parseInt(strarr[0]);
		int i = Integer.parseInt(strarr[1]);
		int num2 = 0;
		int num3 = num - 1;
		FlowNetwork flowNetwork = new FlowNetwork(num, i);
		StdOut.println(flowNetwork);
		FordFulkerson fordFulkerson = new FordFulkerson(flowNetwork, num2, num3);
		StdOut.println(new StringBuilder().append("Max flow from ").append(num2).append(" to ").append(num3).toString());
		for (int j = 0; j < flowNetwork.V(); j++)
		{
			Iterator iterator = flowNetwork.adj(j).iterator();
			while (iterator.hasNext())
			{
				FlowEdge flowEdge = (FlowEdge)iterator.next();
				if (j == flowEdge.from() && flowEdge.flow() > (double)0f)
				{
					StdOut.println(new StringBuilder().append("   ").append(flowEdge).toString());
				}
			}
		}
		StdOut.print("Min cut: ");
		for (int j = 0; j < flowNetwork.V(); j++)
		{
			if (fordFulkerson.inCut(j))
			{
				StdOut.print(new StringBuilder().append(j).append(" ").toString());
			}
		}
		StdOut.println();
		StdOut.println(new StringBuilder().append("Max flow value = ").append(fordFulkerson.value()).toString());
	}
	
	static FordFulkerson()
	{
		FordFulkerson.s_assertionsDisabled = !ClassLiteral<FordFulkerson>.Value.desiredAssertionStatus();
	}
}



public class GabowSCC
{
	private bool[] marked;
	private int[] id;
	private int[] preorder;
	private int pre;
	private int count;
//[Signature("LStack<Ljava/lang/Integer;>;")]
	private Stack stack1;
//[Signature("LStack<Ljava/lang/Integer;>;")]
	private Stack stack2;
//[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
	internal static bool s_assertionsDisabled;
	
	
	
	
	private void dfs(Digraph digraph, int num)
	{
		this.marked[num] = true;
		int[] arg_23_0 = this.preorder;
		int num2 = this.pre;
		int arg_23_2 = num2;
		this.pre = num2 + 1;
		arg_23_0[num] = arg_23_2;
		this.stack1.push(Integer.valueOf(num));
		this.stack2.push(Integer.valueOf(num));
		Iterator iterator = digraph.adj(num).iterator();
		while (iterator.hasNext())
		{
			int num3 = ((Integer)iterator.next()).intValue();
			if (!this.marked[num3])
			{
				this.dfs(digraph, num3);
			}
			else if (this.id[num3] == -1)
			{
				while (this.preorder[((Integer)this.stack2.peek()).intValue()] > this.preorder[num3])
				{
					this.stack2.pop();
				}
			}
		}
		if (((Integer)this.stack2.peek()).intValue() == num)
		{
			this.stack2.pop();
			int num4;
			do
			{
				num4 = ((Integer)this.stack1.pop()).intValue();
				this.id[num4] = this.count;
			}
			while (num4 != num);
			this.count++;
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
	
	
	public GabowSCC(Digraph d)
	{
		this.marked = new bool[d.V()];
		this.stack1 = new Stack();
		this.stack2 = new Stack();
		this.id = new int[d.V()];
		this.preorder = new int[d.V()];
		for (int i = 0; i < d.V(); i++)
		{
			this.id[i] = -1;
		}
		for (int i = 0; i < d.V(); i++)
		{
			if (!this.marked[i])
			{
				this.dfs(d, i);
			}
		}
		if (!GabowSCC.s_assertionsDisabled && !this.check(d))
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
		GabowSCC gabowSCC = new GabowSCC(digraph);
		int num = gabowSCC.count();
		StdOut.println(new StringBuilder().append(num).append(" components").toString());
		Queue[] array = (Queue[])new Queue[num];
		for (int j = 0; j < num; j++)
		{
			array[j] = new Queue();
		}
		for (int j = 0; j < digraph.V(); j++)
		{
			array[gabowSCC.id(j)].enqueue(Integer.valueOf(j));
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
	
	static GabowSCC()
	{
		GabowSCC.s_assertionsDisabled = !ClassLiteral<GabowSCC>.Value.desiredAssertionStatus();
	}
}

public class GaussianElimination
{
	private const double EPSILON = 1E-10;
	
	
	public static double[] lsolve(double[][] darr1, double[] darr2)
	{
		int num = darr2.Length;
		for (int i = 0; i < num; i++)
		{
			int j = i;
			for (int k = i + 1; k < num; k++)
			{
				if (java.lang.Math.abs(darr1[k][i]) > java.lang.Math.abs(darr1[j][i]))
				{
					j = k;
				}
			}
			double[] array = darr1[i];
			darr1[i] = darr1[j];
			darr1[j] = array;
			double num2 = darr2[i];
			darr2[i] = darr2[j];
			darr2[j] = num2;
			if (java.lang.Math.abs(darr1[i][i]) <= 1E-10)
			{
				string arg_73_0 = "Matrix is singular or nearly singular";
				
				throw new java.lang.ArithmeticException(arg_73_0);
			}
			for (int l = i + 1; l < num; l++)
			{
				double num3 = darr1[l][i] / darr1[i][i];
				int num4 = l;
				darr2[num4] -= num3 * darr2[i];
				for (int m = i; m < num; m++)
				{
					double[] arg_BE_0 = darr1[l];
					num4 = m;
					double[] array2 = arg_BE_0;
					array2[num4] -= num3 * darr1[i][m];
				}
			}
		}
		double[] array3 = new double[num];
		for (int j = num - 1; j >= 0; j += -1)
		{
			double num5 = (double)0f;
			for (int n = j + 1; n < num; n++)
			{
				num5 += darr1[j][n] * array3[n];
			}
			array3[j] = (darr2[j] - num5) / darr1[j][j];
		}
		return array3;
	}
	
	
	public GaussianElimination()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		int num = 3;
		double[][] darr = new double[][]
		{
			new double[]
			{
				(double)0f,
				(double)1f,
				(double)1f
			},
			new double[]
			{
				2.0,
				4.0,
				-2.0
			},
			new double[]
			{
				(double)0f,
				3.0,
				15.0
			}
		};
		double[] darr2 = new double[]
		{
			4.0,
			2.0,
			36.0
		};
		double[] array = GaussianElimination.lsolve(darr, darr2);
		for (int i = 0; i < num; i++)
		{
			StdOut.println(array[i]);
		}
	}
}

public class Genome
{
	
	
	public static void compress()
	{
		Alphabet alphabet = new Alphabet("ACTG");
		string @this = BinaryStdIn.readString();
		int num = java.lang.String.instancehelper_length(@this);
		BinaryStdOut.write(num);
		for (int i = 0; i < num; i++)
		{
			int i2 = alphabet.toIndex(java.lang.String.instancehelper_charAt(@this, i));
			BinaryStdOut.write(i2, 2);
		}
		BinaryStdOut.close();
	}
	
	
	public static void expand()
	{
		Alphabet alphabet = new Alphabet("ACTG");
		int num = BinaryStdIn.readInt();
		for (int i = 0; i < num; i++)
		{
			int i2 = (int)BinaryStdIn.readChar(2);
			BinaryStdOut.write(alphabet.toChar(i2), 8);
		}
		BinaryStdOut.close();
	}
	
	
	public Genome()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		if (java.lang.String.instancehelper_equals(strarr[0], "-"))
		{
			Genome.compress();
		}
		else
		{
			if (!java.lang.String.instancehelper_equals(strarr[0], "+"))
			{
				string arg_36_0 = "Illegal command line argument";
				
				throw new ArgumentException(arg_36_0);
			}
			Genome.expand();
		}
	}
}

public class GrahamScan
{
//[Signature("LStack<LPoint2D;>;")]
	private Stack hull;
//[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
	internal static bool s_assertionsDisabled;
	
	
	
	
	public GrahamScan(Point2D[] pdarr)
	{
		this.hull = new Stack();
		int num = pdarr.Length;
		Point2D[] array = new Point2D[num];
		int i;
		for (i = 0; i < num; i++)
		{
			array[i] = pdarr[i];
		}
		Arrays.sort(array);
		Arrays.sort(array, 1, num, array[0].__POLAR_ORDER);
		this.hull.push(array[0]);
		for (i = 1; i < num; i++)
		{
			if (!array[0].equals(array[i]))
			{
				break;
			}
		}
		if (i == num)
		{
			return;
		}
		int j;
		for (j = i + 1; j < num; j++)
		{
			if (Point2D.ccw(array[0], array[i], array[j]) != 0)
			{
				break;
			}
		}
		this.hull.push(array[j - 1]);
		for (int k = j; k < num; k++)
		{
			Point2D point2D = (Point2D)this.hull.pop();
			while (Point2D.ccw((Point2D)this.hull.peek(), point2D, array[k]) <= 0)
			{
				point2D = (Point2D)this.hull.pop();
			}
			this.hull.push(point2D);
			this.hull.push(array[k]);
		}
		if (!GrahamScan.s_assertionsDisabled && !this.isConvex())
		{
			
			throw new AssertionError();
		}
	}
/*	[Signature("()Ljava/lang/Iterable<LPoint2D;>;")]*/
	
	public virtual Iterable hull()
	{
		Stack stack = new Stack();
		Iterator iterator = this.hull.iterator();
		while (iterator.hasNext())
		{
			Point2D obj = (Point2D)iterator.next();
			stack.push(obj);
		}
		return stack;
	}
	
	
	private bool isConvex()
	{
		int num = this.hull.size();
		if (num <= 2)
		{
			return true;
		}
		Point2D[] array = new Point2D[num];
		int num2 = 0;
		Iterator iterator = this.hull().iterator();
		while (iterator.hasNext())
		{
			Point2D point2D = (Point2D)iterator.next();
			Point2D[] arg_44_0 = array;
			int arg_44_1 = num2;
			num2++;
			arg_44_0[arg_44_1] = point2D;
		}
		for (int i = 0; i < num; i++)
		{
			Point2D arg_75_0 = array[i];
			Point2D[] arg_63_0 = array;
			int expr_57 = i + 1;
			int expr_59 = num;
			Point2D arg_75_1 = arg_63_0[(expr_59 != -1) ? (expr_57 % expr_59) : 0];
			Point2D[] arg_74_0 = array;
			int expr_68 = i + 2;
			int expr_6A = num;
			if (Point2D.ccw(arg_75_0, arg_75_1, arg_74_0[(expr_6A != -1) ? (expr_68 % expr_6A) : 0]) <= 0)
			{
				return false;
			}
		}
		return true;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		int num = StdIn.readInt();
		Point2D[] array = new Point2D[num];
		for (int i = 0; i < num; i++)
		{
			int num2 = StdIn.readInt();
			int num3 = StdIn.readInt();
			array[i] = new Point2D((double)num2, (double)num3);
		}
		GrahamScan grahamScan = new GrahamScan(array);
		Iterator iterator = grahamScan.hull().iterator();
		while (iterator.hasNext())
		{
			Point2D obj = (Point2D)iterator.next();
			StdOut.println(obj);
		}
	}
	
	static GrahamScan()
	{
		GrahamScan.s_assertionsDisabled = !ClassLiteral<GrahamScan>.Value.desiredAssertionStatus();
	}
}

public class Graph
{
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private int V;
	private int E;
//[Signature("[LBag<Ljava/lang/Integer;>;")]
	private Bag[] adj;
	public virtual int V()
	{
		return this.V;
	}
/*	[Signature("(I)Ljava/lang/Iterable<Ljava/lang/Integer;>;")]*/
	
	public virtual Iterable adj(int i)
	{
		if (i < 0 || i >= this.V)
		{
			
			throw new IndexOutOfRangeException();
		}
		return this.adj[i];
	}
	
	
	public Graph(int i)
	{
		if (i < 0)
		{
			string arg_16_0 = "Number of vertices must be nonnegative";
			
			throw new ArgumentException(arg_16_0);
		}
		this.V = i;
		this.E = 0;
		this.adj = (Bag[])new Bag[i];
		for (int j = 0; j < i; j++)
		{
			this.adj[j] = new Bag();
		}
	}
	
	
	public virtual void addEdge(int i1, int i2)
	{
		if (i1 < 0 || i1 >= this.V)
		{
			
			throw new IndexOutOfRangeException();
		}
		if (i2 < 0 || i2 >= this.V)
		{
			
			throw new IndexOutOfRangeException();
		}
		this.E++;
		this.adj[i1].add(Integer.valueOf(i2));
		this.adj[i2].add(Integer.valueOf(i1));
	}
	
	
	public Graph(In i) : this(i.readInt())
	{
		int num = i.readInt();
		if (num < 0)
		{
			string arg_23_0 = "Number of edges must be nonnegative";
			
			throw new ArgumentException(arg_23_0);
		}
		for (int j = 0; j < num; j++)
		{
			int i2 = i.readInt();
			int i3 = i.readInt();
			this.addEdge(i2, i3);
		}
	}
	public virtual int E()
	{
		return this.E;
	}
	
	
	public Graph(Graph g) : this(g.V())
	{
		this.E = g.E();
		for (int i = 0; i < g.V(); i++)
		{
			Stack stack = new Stack();
			Iterator iterator = g.adj[i].iterator();
			while (iterator.hasNext())
			{
				int i2 = ((Integer)iterator.next()).intValue();
				stack.push(Integer.valueOf(i2));
			}
			iterator = stack.iterator();
			while (iterator.hasNext())
			{
				int i2 = ((Integer)iterator.next()).intValue();
				this.adj[i].add(Integer.valueOf(i2));
			}
		}
	}
	
	
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		string property = System.getProperty("line.separator");
		stringBuilder.append(new StringBuilder().append(this.V).append(" vertices, ").append(this.E).append(" edges ").append(property).toString());
		for (int i = 0; i < this.V; i++)
		{
			stringBuilder.append(new StringBuilder().append(i).append(": ").toString());
			Iterator iterator = this.adj[i].iterator();
			while (iterator.hasNext())
			{
				int i2 = ((Integer)iterator.next()).intValue();
				stringBuilder.append(new StringBuilder().append(i2).append(" ").toString());
			}
			stringBuilder.append(property);
		}
		return stringBuilder.toString();
	}
	
	
	/**/public static void main(string[] strarr)
	{
		
		In i = new In(strarr[0]);
		Graph obj = new Graph(i);
		StdOut.println(obj);
	}
}

public class GraphGenerator
{
	/*[EnclosingMethod("GraphGenerator", null, null), InnerClass(null, Modifiers.Static | Modifiers.Synthetic), Modifiers(Modifiers.Super | Modifiers.Synthetic), SourceFile("GraphGenerator.java")]*/
	
	/*[Implements(new string[]
	{
		"java.lang.Comparable"
	}), InnerClass(null, Modifiers.Private | Modifiers.Static | Modifiers.Final), Signature("Ljava/lang/Object;Ljava/lang/Comparable<LGraphGenerator$Edge;>;"), SourceFile("GraphGenerator.java")]*/
	internal sealed class Edge : IComparable
	{
		private int v;
		private int w;
/*		[LineNumberTable(25), Modifiers(Modifiers.Synthetic)]*/
		
		internal Edge(int num, int num2, GraphGenerator.1) : this(num, num2)
		{
		}
		
		
		private Edge(int num, int num2)
		{
			if (num < num2)
			{
				this.v = num;
				this.w = num2;
			}
			else
			{
				this.v = num2;
				this.w = num;
			}
		}
		
		public virtual int compareTo(GraphGenerator.Edge edge)
		{
			if (this.v < edge.v)
			{
				return -1;
			}
			if (this.v > edge.v)
			{
				return 1;
			}
			if (this.w < edge.w)
			{
				return -1;
			}
			if (this.w > edge.w)
			{
				return 1;
			}
			return 0;
		}
/*		[LineNumberTable(25), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public virtual int compareTo(object obj)
		{
			return this.compareTo((GraphGenerator.Edge)obj);
		}
		
		int IComparable.Object;)IcompareTo(object obj)
		{
			return this.compareTo(obj);
		}
	}
	
	
	public static Graph simple(int i, double d)
	{
		if (d < (double)0f || d > (double)1f)
		{
			string arg_1C_0 = "Probability must be between 0 and 1";
			
			throw new ArgumentException(arg_1C_0);
		}
		Graph graph = new Graph(i);
		for (int j = 0; j < i; j++)
		{
			for (int k = j + 1; k < i; k++)
			{
				if (StdRandom.bernoulli(d))
				{
					graph.addEdge(j, k);
				}
			}
		}
		return graph;
	}
	
	
	public static Graph bipartite(int i1, int i2, int i3)
	{
		if ((long)i3 > (long)i1 * (long)i2)
		{
			string arg_13_0 = "Too many edges";
			
			throw new ArgumentException(arg_13_0);
		}
		if (i3 < 0)
		{
			string arg_27_0 = "Too few edges";
			
			throw new ArgumentException(arg_27_0);
		}
		Graph graph = new Graph(i1 + i2);
		int[] array = new int[i1 + i2];
		for (int j = 0; j < i1 + i2; j++)
		{
			array[j] = j;
		}
		StdRandom.shuffle(array);
		SET sET = new SET();
		while (graph.E() < i3)
		{
			int num = StdRandom.uniform(i1);
			int num2 = i1 + StdRandom.uniform(i2);
			GraphGenerator.Edge c = new GraphGenerator.Edge(array[num], array[num2], null);
			if (!sET.contains(c))
			{
				sET.add(c);
				graph.addEdge(array[num], array[num2]);
			}
		}
		return graph;
	}
	
	
	public static Graph complete(int i)
	{
		return GraphGenerator.simple(i, (double)1f);
	}
	
	
	public static Graph simple(int i1, int i2)
	{
		if ((long)i2 > (long)i1 * (long)(i1 - 1) / 2L)
		{
			string arg_18_0 = "Too many edges";
			
			throw new ArgumentException(arg_18_0);
		}
		if (i2 < 0)
		{
			string arg_2C_0 = "Too few edges";
			
			throw new ArgumentException(arg_2C_0);
		}
		Graph graph = new Graph(i1);
		SET sET = new SET();
		while (graph.E() < i2)
		{
			int num = StdRandom.uniform(i1);
			int num2 = StdRandom.uniform(i1);
			GraphGenerator.Edge c = new GraphGenerator.Edge(num, num2, null);
			if (num != num2 && !sET.contains(c))
			{
				sET.add(c);
				graph.addEdge(num, num2);
			}
		}
		return graph;
	}
	
	
	public static Graph completeBipartite(int i1, int i2)
	{
		return GraphGenerator.bipartite(i1, i2, i1 * i2);
	}
	
	
	public static Graph bipartite(int i1, int i2, double d)
	{
		if (d < (double)0f || d > (double)1f)
		{
			string arg_1C_0 = "Probability must be between 0 and 1";
			
			throw new ArgumentException(arg_1C_0);
		}
		int[] array = new int[i1 + i2];
		for (int j = 0; j < i1 + i2; j++)
		{
			array[j] = j;
		}
		StdRandom.shuffle(array);
		Graph graph = new Graph(i1 + i2);
		for (int k = 0; k < i1; k++)
		{
			for (int l = 0; l < i2; l++)
			{
				if (StdRandom.bernoulli(d))
				{
					graph.addEdge(array[k], array[i1 + l]);
				}
			}
		}
		return graph;
	}
	
	
	public static Graph path(int i)
	{
		Graph graph = new Graph(i);
		int[] array = new int[i];
		for (int j = 0; j < i; j++)
		{
			array[j] = j;
		}
		StdRandom.shuffle(array);
		for (int j = 0; j < i - 1; j++)
		{
			graph.addEdge(array[j], array[j + 1]);
		}
		return graph;
	}
	
	
	public static Graph cycle(int i)
	{
		Graph graph = new Graph(i);
		int[] array = new int[i];
		for (int j = 0; j < i; j++)
		{
			array[j] = j;
		}
		StdRandom.shuffle(array);
		for (int j = 0; j < i - 1; j++)
		{
			graph.addEdge(array[j], array[j + 1]);
		}
		graph.addEdge(array[i - 1], array[0]);
		return graph;
	}
	
	
	public static Graph binaryTree(int i)
	{
		Graph graph = new Graph(i);
		int[] array = new int[i];
		for (int j = 0; j < i; j++)
		{
			array[j] = j;
		}
		StdRandom.shuffle(array);
		for (int j = 1; j < i; j++)
		{
			graph.addEdge(array[j], array[(j - 1) / 2]);
		}
		return graph;
	}
	
	
	public static Graph tree(int i)
	{
		Graph graph = new Graph(i);
		if (i == 1)
		{
			return graph;
		}
		int[] array = new int[i - 2];
		for (int j = 0; j < i - 2; j++)
		{
			array[j] = StdRandom.uniform(i);
		}
		int[] array2 = new int[i];
		for (int k = 0; k < i; k++)
		{
			array2[k] = 1;
		}
		for (int k = 0; k < i - 2; k++)
		{
			int[] arg_5A_0 = array2;
			int num = array[k];
			int[] array3 = arg_5A_0;
			array3[num]++;
		}
		MinPQ minPQ = new MinPQ();
		for (int l = 0; l < i; l++)
		{
			if (array2[l] == 1)
			{
				minPQ.insert(Integer.valueOf(l));
			}
		}
		for (int l = 0; l < i - 2; l++)
		{
			int num2 = ((Integer)minPQ.delMin()).intValue();
			graph.addEdge(num2, array[l]);
			int[] arg_CD_0 = array2;
			int num = num2;
			int[] array3 = arg_CD_0;
			array3[num]--;
			int[] arg_E2_0 = array2;
			num = array[l];
			array3 = arg_E2_0;
			array3[num]--;
			if (array2[array[l]] == 1)
			{
				minPQ.insert(Integer.valueOf(array[l]));
			}
		}
		graph.addEdge(((Integer)minPQ.delMin()).intValue(), ((Integer)minPQ.delMin()).intValue());
		return graph;
	}
	
	
	public static Graph regular(int i1, int i2)
	{
		bool expr_02 = i1 * i2 != 0;
		int expr_04 = 2;
		if (expr_04 != -1 && (expr_02 ? 1 : 0) % expr_04 != 0)
		{
			string arg_1A_0 = "Number of vertices * k must be even";
			
			throw new ArgumentException(arg_1A_0);
		}
		Graph graph = new Graph(i1);
		int[] array = new int[i1 * i2];
		for (int j = 0; j < i1; j++)
		{
			for (int k = 0; k < i2; k++)
			{
				array[j + i1 * k] = j;
			}
		}
		StdRandom.shuffle(array);
		for (int j = 0; j < i1 * i2 / 2; j++)
		{
			graph.addEdge(array[2 * j], array[2 * j + 1]);
		}
		return graph;
	}
	
	
	public static Graph star(int i)
	{
		if (i <= 0)
		{
			string arg_0E_0 = "Number of vertices must be at least 1";
			
			throw new ArgumentException(arg_0E_0);
		}
		Graph graph = new Graph(i);
		int[] array = new int[i];
		for (int j = 0; j < i; j++)
		{
			array[j] = j;
		}
		StdRandom.shuffle(array);
		for (int j = 1; j < i; j++)
		{
			graph.addEdge(array[0], array[j]);
		}
		return graph;
	}
	
	
	public static Graph wheel(int i)
	{
		if (i <= 1)
		{
			string arg_0E_0 = "Number of vertices must be at least 2";
			
			throw new ArgumentException(arg_0E_0);
		}
		Graph graph = new Graph(i);
		int[] array = new int[i];
		for (int j = 0; j < i; j++)
		{
			array[j] = j;
		}
		StdRandom.shuffle(array);
		for (int j = 1; j < i - 1; j++)
		{
			graph.addEdge(array[j], array[j + 1]);
		}
		graph.addEdge(array[i - 1], array[1]);
		for (int j = 1; j < i; j++)
		{
			graph.addEdge(array[0], array[j]);
		}
		return graph;
	}
	
	
	public GraphGenerator()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		int num = Integer.parseInt(strarr[0]);
		int num2 = Integer.parseInt(strarr[1]);
		int num3 = num / 2;
		int num4 = num - num3;
		System.@out.println("complete graph");
		System.@out.println(GraphGenerator.complete(num));
		System.@out.println();
		System.@out.println("simple");
		System.@out.println(GraphGenerator.simple(num, num2));
		System.@out.println();
		System.@out.println("Erdos-Renyi");
		double d = (double)num2 / (double)(num * (num - 1) / 2);
		System.@out.println(GraphGenerator.simple(num, d));
		System.@out.println();
		System.@out.println("complete bipartite");
		System.@out.println(GraphGenerator.completeBipartite(num3, num4));
		System.@out.println();
		System.@out.println("bipartite");
		System.@out.println(GraphGenerator.bipartite(num3, num4, num2));
		System.@out.println();
		System.@out.println("Erdos Renyi bipartite");
		double d2 = (double)num2 / (double)(num3 * num4);
		System.@out.println(GraphGenerator.bipartite(num3, num4, d2));
		System.@out.println();
		System.@out.println("path");
		System.@out.println(GraphGenerator.path(num));
		System.@out.println();
		System.@out.println("cycle");
		System.@out.println(GraphGenerator.cycle(num));
		System.@out.println();
		System.@out.println("binary tree");
		System.@out.println(GraphGenerator.binaryTree(num));
		System.@out.println();
		System.@out.println("tree");
		System.@out.println(GraphGenerator.tree(num));
		System.@out.println();
		System.@out.println("4-regular");
		System.@out.println(GraphGenerator.regular(num, 4));
		System.@out.println();
		System.@out.println("star");
		System.@out.println(GraphGenerator.star(num));
		System.@out.println();
		System.@out.println("wheel");
		System.@out.println(GraphGenerator.wheel(num));
		System.@out.println();
	}
}

public class GREP
{
	
	
	public GREP()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		string str = new StringBuilder().append("(.*").append(strarr[0]).append(".*)").toString();
		NFA nFA = new NFA(str);
		while (StdIn.hasNextLine())
		{
			string text = StdIn.readLine();
			if (nFA.recognizes(text))
			{
				StdOut.println(text);
			}
		}
	}
}

public class Heap
{
	
	
	private static void sink(IComparable[] array, int num, int num2)
	{
		while (2 * num <= num2)
		{
			int num3 = 2 * num;
			if (num3 < num2 && Heap.less(array, num3, num3 + 1))
			{
				num3++;
			}
			if (!Heap.less(array, num, num3))
			{
				break;
			}
			Heap.exch(array, num, num3);
			num = num3;
		}
	}
	
	private static void exch(object[] array, int num, int num2)
	{
		object obj = array[num - 1];
		array[num - 1] = array[num2 - 1];
		array[num2 - 1] = obj;
	}
	
	
	private static bool less(IComparable[] array, int num, int num2)
	{
		return Comparable.__Helper.compareTo(array[num - 1], array[num2 - 1]) < 0;
	}
	
	
	private static bool less(IComparable o, IComparable comparable)
	{
		return Comparable.__Helper.compareTo(o, comparable) < 0;
	}
	
	
	public static void sort(IComparable[] carr)
	{
		int i = carr.Length;
		for (int j = i / 2; j >= 1; j += -1)
		{
			Heap.sink(carr, j, i);
		}
		while (i > 1)
		{
			int arg_24_1 = 1;
			int arg_24_2 = i;
			i += -1;
			Heap.exch(carr, arg_24_1, arg_24_2);
			Heap.sink(carr, 1, i);
		}
	}
	
	
	private static void show(IComparable[] array)
	{
		for (int i = 0; i < array.Length; i++)
		{
			StdOut.println(array[i]);
		}
	}
	
	
	private Heap()
	{
	}
	
	
	private static bool isSorted(IComparable[] array)
	{
		for (int i = 1; i < array.Length; i++)
		{
			if (Heap.less(array[i], array[i - 1]))
			{
				return false;
			}
		}
		return true;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		string[] array = StdIn.readAllStrings();
		Heap.sort(array);
		Heap.show(array);
	}
}

public class HexDump
{
	
	
	public HexDump()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		int num = 16;
		if (strarr.Length == 1)
		{
			num = Integer.parseInt(strarr[0]);
		}
		int num2 = 0;
		while (!BinaryStdIn.isEmpty())
		{
			if (num == 0)
			{
				BinaryStdIn.readChar();
			}
			else
			{
				if (num2 == 0)
				{
					StdOut.printf("", new object[0]);
				}
				else
				{
					bool expr_40 = num2 != 0;
					int expr_42 = num;
					if (expr_42 == -1 || (expr_40 ? 1 : 0) % expr_42 == 0)
					{
						StdOut.printf("\n", new object[]
						{
							Integer.valueOf(num2)
						});
					}
					else
					{
						StdOut.print(" ");
					}
				}
				int num3 = (int)BinaryStdIn.readChar();
				StdOut.printf("%02x", new object[]
				{
					Integer.valueOf(num3 & 255)
				});
			}
			num2++;
		}
		if (num != 0)
		{
			StdOut.println();
		}
		StdOut.println(new StringBuilder().append(num2 * 8).append(" bits").toString());
	}
}

public class Huffman
{
	/*[Implements(new string[]
	{
		"java.lang.Comparable"
	}), InnerClass(null, Modifiers.Private | Modifiers.Static), Modifiers(Modifiers.Super), Signature("Ljava/lang/Object;Ljava/lang/Comparable<LHuffman$Node;>;"), SourceFile("Huffman.java")]*/
	internal sealed class Node : IComparable
	{
//[Modifiers(Modifiers.Private | Modifiers.Final)]
		private char ch;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
		private int freq;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
		private Huffman.Node left;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
		private Huffman.Node right;
//[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
		internal static bool s_assertionsDisabled;
		
		public static void __<clinit>()
		{
		}
		
		
		internal Node(char c, int num, Huffman.Node node, Huffman.Node node2)
		{
			this.ch = c;
			this.freq = num;
			this.left = node;
			this.right = node2;
		}
/*		[LineNumberTable(27), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static int access_000(Huffman.Node node)
		{
			return node.freq;
		}
/*		[LineNumberTable(27), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		
		internal static bool access_100(Huffman.Node node)
		{
			return node.isLeaf();
		}
/*		[LineNumberTable(27), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static char access_200(Huffman.Node node)
		{
			return node.ch;
		}
/*		[LineNumberTable(27), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static Huffman.Node access_300(Huffman.Node node)
		{
			return node.left;
		}
/*		[LineNumberTable(27), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static Huffman.Node access_400(Huffman.Node node)
		{
			return node.right;
		}
		
		
		private bool isLeaf()
		{
			if (!Huffman.Node.s_assertionsDisabled && (this.left != null || this.right != null) && (this.left == null || this.right == null))
			{
				
				throw new AssertionError();
			}
			return this.left == null && this.right == null;
		}
		
		public virtual int compareTo(Huffman.Node node)
		{
			return this.freq - node.freq;
		}
/*		[LineNumberTable(27), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public virtual int compareTo(object obj)
		{
			return this.compareTo((Huffman.Node)obj);
		}
		
		static Node()
		{
			Huffman.Node.s_assertionsDisabled = !ClassLiteral<Huffman>.Value.desiredAssertionStatus();
		}
		
		int IComparable.Object;)IcompareTo(object obj)
		{
			return this.compareTo(obj);
		}
	}
	private const int R = 256;
	
	
	private static Huffman.Node buildTrie(int[] array)
	{
		MinPQ minPQ = new MinPQ();
		for (int i = 0; i < 256; i = (int)((ushort)(i + 1)))
		{
			if (array[i] > 0)
			{
				MinPQ arg_27_0 = minPQ;
				Huffman.Node.__<clinit>();
				arg_27_0.insert(new Huffman.Node((char)i, array[i], null, null));
			}
		}
		while (minPQ.size() > 1)
		{
			Huffman.Node node = (Huffman.Node)minPQ.delMin();
			Huffman.Node node2 = (Huffman.Node)minPQ.delMin();
			Huffman.Node.__<clinit>();
			Huffman.Node obj = new Huffman.Node('\0', Huffman.Node.access_000(node) + Huffman.Node.access_000(node2), node, node2);
			minPQ.insert(obj);
		}
		return (Huffman.Node)minPQ.delMin();
	}
	
	
	private static void buildCode(string[] array, Huffman.Node node, string text)
	{
		if (!Huffman.Node.access_100(node))
		{
			Huffman.buildCode(array, Huffman.Node.access_300(node), new StringBuilder().append(text).append('0').toString());
			Huffman.buildCode(array, Huffman.Node.access_400(node), new StringBuilder().append(text).append('1').toString());
		}
		else
		{
			array[(int)Huffman.Node.access_200(node)] = text;
		}
	}
	
	
	private static void writeTrie(Huffman.Node node)
	{
		if (Huffman.Node.access_100(node))
		{
			BinaryStdOut.write(true);
			BinaryStdOut.write(Huffman.Node.access_200(node), 8);
			return;
		}
		BinaryStdOut.write(false);
		Huffman.writeTrie(Huffman.Node.access_300(node));
		Huffman.writeTrie(Huffman.Node.access_400(node));
	}
	
	
	private static Huffman.Node readTrie()
	{
		int num = BinaryStdIn.readBoolean() ? 1 : 0;
		if (num != 0)
		{
			Huffman.Node.__<clinit>();
			return new Huffman.Node(BinaryStdIn.readChar(), -1, null, null);
		}
		Huffman.Node.__<clinit>();
		return new Huffman.Node('\0', -1, Huffman.readTrie(), Huffman.readTrie());
	}
	
	
	public static void compress()
	{
		string @this = BinaryStdIn.readString();
		char[] array = java.lang.String.instancehelper_toCharArray(@this);
		int[] array2 = new int[256];
		for (int i = 0; i < array.Length; i++)
		{
			int[] arg_25_0 = array2;
			int num = (int)array[i];
			int[] array3 = arg_25_0;
			array3[num]++;
		}
		Huffman.Node node = Huffman.buildTrie(array2);
		string[] array4 = new string[256];
		Huffman.buildCode(array4, node, "");
		Huffman.writeTrie(node);
		BinaryStdOut.write(array.Length);
		for (int j = 0; j < array.Length; j++)
		{
			string this2 = array4[(int)array[j]];
			for (int k = 0; k < java.lang.String.instancehelper_length(this2); k++)
			{
				if (java.lang.String.instancehelper_charAt(this2, k) == '0')
				{
					BinaryStdOut.write(false);
				}
				else
				{
					if (java.lang.String.instancehelper_charAt(this2, k) != '1')
					{
						string arg_C0_0 = "Illegal state";
						
						throw new IllegalStateException(arg_C0_0);
					}
					BinaryStdOut.write(true);
				}
			}
		}
		BinaryStdOut.close();
	}
	
	
	public static void expand()
	{
		Huffman.Node node = Huffman.readTrie();
		int num = BinaryStdIn.readInt();
		for (int i = 0; i < num; i++)
		{
			Huffman.Node node2 = node;
			while (!Huffman.Node.access_100(node2))
			{
				int num2 = BinaryStdIn.readBoolean() ? 1 : 0;
				if (num2 != 0)
				{
					node2 = Huffman.Node.access_400(node2);
				}
				else
				{
					node2 = Huffman.Node.access_300(node2);
				}
			}
			BinaryStdOut.write(Huffman.Node.access_200(node2), 8);
		}
		BinaryStdOut.close();
	}
	
	
	public Huffman()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		if (java.lang.String.instancehelper_equals(strarr[0], "-"))
		{
			Huffman.compress();
		}
		else
		{
			if (!java.lang.String.instancehelper_equals(strarr[0], "+"))
			{
				string arg_36_0 = "Illegal command line argument";
				
				throw new ArgumentException(arg_36_0);
			}
			Huffman.expand();
		}
	}
}