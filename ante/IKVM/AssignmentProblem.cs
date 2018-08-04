public class AssignmentProblem
{
	private const int UNMATCHED = -1;
	private int N;
	private double[][] weight;
	private double[] px;
	private double[] py;
	private int[] xy;
	private int[] yx;
//[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
	internal static bool s_assertionsDisabled;
	
	
	
	
	private bool isDualFeasible()
	{
		for (int i = 0; i < this.N; i++)
		{
			for (int j = 0; j < this.N; j++)
			{
				if (this.reduced(i, j) < (double)0f)
				{
					StdOut.println("Dual variables are not feasible");
					return false;
				}
			}
		}
		return true;
	}
	
	
	private bool isComplementarySlack()
	{
		for (int i = 0; i < this.N; i++)
		{
			if (this.xy[i] != -1 && this.reduced(i, this.xy[i]) != (double)0f)
			{
				StdOut.println("Primal and dual variables are not complementary slack");
				return false;
			}
		}
		return true;
	}
	
	
	private void augment()
	{
		EdgeWeightedDigraph edgeWeightedDigraph = new EdgeWeightedDigraph(2 * this.N + 2);
		int num = 2 * this.N;
		int num2 = 2 * this.N + 1;
		for (int i = 0; i < this.N; i++)
		{
			if (this.xy[i] == -1)
			{
				edgeWeightedDigraph.addEdge(new DirectedEdge(num, i, (double)0f));
			}
		}
		for (int i = 0; i < this.N; i++)
		{
			if (this.yx[i] == -1)
			{
				edgeWeightedDigraph.addEdge(new DirectedEdge(this.N + i, num2, this.py[i]));
			}
		}
		for (int i = 0; i < this.N; i++)
		{
			for (int j = 0; j < this.N; j++)
			{
				if (this.xy[i] == j)
				{
					edgeWeightedDigraph.addEdge(new DirectedEdge(this.N + j, i, (double)0f));
				}
				else
				{
					edgeWeightedDigraph.addEdge(new DirectedEdge(i, this.N + j, this.reduced(i, j)));
				}
			}
		}
		DijkstraSP dijkstraSP = new DijkstraSP(edgeWeightedDigraph, num);
		Iterator iterator = dijkstraSP.pathTo(num2).iterator();
		while (iterator.hasNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)iterator.next();
			int num3 = directedEdge.from();
			int num4 = directedEdge.to() - this.N;
			if (num3 < this.N)
			{
				this.xy[num3] = num4;
				this.yx[num4] = num3;
			}
		}
		for (int j = 0; j < this.N; j++)
		{
			double[] arg_180_0 = this.px;
			int num5 = j;
			double[] array = arg_180_0;
			array[num5] += dijkstraSP.distTo(j);
		}
		for (int j = 0; j < this.N; j++)
		{
			double[] arg_1B6_0 = this.py;
			int num5 = j;
			double[] array = arg_1B6_0;
			array[num5] += dijkstraSP.distTo(this.N + j);
		}
	}
	
	
	private bool check()
	{
		return this.isPerfectMatching() && this.isDualFeasible() && this.isComplementarySlack();
	}
	
	private double reduced(int num, int num2)
	{
		return this.weight[num][num2] + this.px[num] - this.py[num2];
	}
	
	
	private bool isPerfectMatching()
	{
		bool[] array = new bool[this.N];
		for (int i = 0; i < this.N; i++)
		{
			if (array[this.xy[i]])
			{
				StdOut.println("Not a perfect matching");
				return false;
			}
			array[this.xy[i]] = true;
		}
		for (int i = 0; i < this.N; i++)
		{
			if (this.xy[this.yx[i]] != i)
			{
				StdOut.println("xy[] and yx[] are not inverses");
				return false;
			}
		}
		for (int i = 0; i < this.N; i++)
		{
			if (this.yx[this.xy[i]] != i)
			{
				StdOut.println("xy[] and yx[] are not inverses");
				return false;
			}
		}
		return true;
	}
	
	
	public AssignmentProblem(double[][] darr)
	{
		this.N = darr.Length;
		int arg_29_0 = this.N;
		int arg_24_0 = this.N;
		int[] array = new int[2];
		int num = arg_24_0;
		array[1] = num;
		num = arg_29_0;
		array[0] = num;
		this.weight = (double[][])ByteCodeHelper.multianewarray(typeof(double[][]).TypeHandle, array);
		for (int i = 0; i < this.N; i++)
		{
			for (int j = 0; j < this.N; j++)
			{
				this.weight[i][j] = darr[i][j];
			}
		}
		this.px = new double[this.N];
		this.py = new double[this.N];
		this.xy = new int[this.N];
		this.yx = new int[this.N];
		for (int i = 0; i < this.N; i++)
		{
			this.xy[i] = -1;
		}
		for (int i = 0; i < this.N; i++)
		{
			this.yx[i] = -1;
		}
		for (int i = 0; i < this.N; i++)
		{
			if (!AssignmentProblem.s_assertionsDisabled && !this.isDualFeasible())
			{
				
				throw new AssertionError();
			}
			if (!AssignmentProblem.s_assertionsDisabled && !this.isComplementarySlack())
			{
				
				throw new AssertionError();
			}
			this.augment();
		}
		if (!AssignmentProblem.s_assertionsDisabled && !this.check())
		{
			
			throw new AssertionError();
		}
	}
	
	public virtual double weight()
	{
		double num = (double)0f;
		for (int i = 0; i < this.N; i++)
		{
			if (this.xy[i] != -1)
			{
				num += this.weight[i][this.xy[i]];
			}
		}
		return num;
	}
	
	public virtual int sol(int i)
	{
		return this.xy[i];
	}
	
	public virtual double dualRow(int i)
	{
		return this.px[i];
	}
	
	public virtual double dualCol(int i)
	{
		return this.py[i];
	}
	
	
	/**/public static void main(string[] strarr)
	{
		
		In @in = new In(strarr[0]);
		int num = @in.readInt();
		int arg_23_0 = num;
		int arg_1E_0 = num;
		int[] array = new int[2];
		int num2 = arg_1E_0;
		array[1] = num2;
		num2 = arg_23_0;
		array[0] = num2;
		double[][] array2 = (double[][])ByteCodeHelper.multianewarray(typeof(double[][]).TypeHandle, array);
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num; j++)
			{
				array2[i][j] = @in.readDouble();
			}
		}
		AssignmentProblem assignmentProblem = new AssignmentProblem(array2);
		StdOut.println(new StringBuilder().append("weight = ").append(assignmentProblem.weight()).toString());
		for (int j = 0; j < num; j++)
		{
			StdOut.println(new StringBuilder().append(j).append("-").append(assignmentProblem.sol(j)).append("' ").append(array2[j][assignmentProblem.sol(j)]).toString());
		}
		for (int j = 0; j < num; j++)
		{
			StdOut.println(new StringBuilder().append("px[").append(j).append("] = ").append(assignmentProblem.dualRow(j)).toString());
		}
		for (int j = 0; j < num; j++)
		{
			StdOut.println(new StringBuilder().append("py[").append(j).append("] = ").append(assignmentProblem.dualCol(j)).toString());
		}
		for (int j = 0; j < num; j++)
		{
			for (int k = 0; k < num; k++)
			{
				StdOut.println(new StringBuilder().append("reduced[").append(j).append("-").append(k).append("] = ").append(assignmentProblem.reduced(j, k)).toString());
			}
		}
	}
	
	static AssignmentProblem()
	{
		AssignmentProblem.s_assertionsDisabled = !ClassLiteral<AssignmentProblem>.Value.desiredAssertionStatus();
	}
}