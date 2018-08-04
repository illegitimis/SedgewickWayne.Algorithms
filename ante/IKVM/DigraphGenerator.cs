public class DigraphGenerator
{
	/*[EnclosingMethod("DigraphGenerator", null, null), InnerClass(null, Modifiers.Static | Modifiers.Synthetic), Modifiers(Modifiers.Super | Modifiers.Synthetic), SourceFile("DigraphGenerator.java")]*/
	
	/*[Implements(new string[]
	{
		"java.lang.Comparable"
	}), InnerClass(null, Modifiers.Private | Modifiers.Static | Modifiers.Final), Signature("Ljava/lang/Object;Ljava/lang/Comparable<LDigraphGenerator$Edge;>;"), SourceFile("DigraphGenerator.java")]*/
	internal sealed class Edge : IComparable
	{
		private int v;
		private int w;
/*		[LineNumberTable(23), Modifiers(Modifiers.Synthetic)]*/
		
		internal Edge(int num, int num2, DigraphGenerator.1) : this(num, num2)
		{
		}
		
		
		private Edge(int num, int num2)
		{
			this.v = num;
			this.w = num2;
		}
		
		public virtual int compareTo(DigraphGenerator.Edge edge)
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
/*		[LineNumberTable(23), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public virtual int compareTo(object obj)
		{
			return this.compareTo((DigraphGenerator.Edge)obj);
		}
		
		int IComparable.Object;)IcompareTo(object obj)
		{
			return this.compareTo(obj);
		}
	}
	
	
	public static Digraph simple(int i1, int i2)
	{
		if ((long)i2 > (long)i1 * (long)(i1 - 1))
		{
			string arg_15_0 = "Too many edges";
			
			throw new ArgumentException(arg_15_0);
		}
		if (i2 < 0)
		{
			string arg_29_0 = "Too few edges";
			
			throw new ArgumentException(arg_29_0);
		}
		Digraph digraph = new Digraph(i1);
		SET sET = new SET();
		while (digraph.E() < i2)
		{
			int num = StdRandom.uniform(i1);
			int num2 = StdRandom.uniform(i1);
			DigraphGenerator.Edge c = new DigraphGenerator.Edge(num, num2, null);
			if (num != num2 && !sET.contains(c))
			{
				sET.add(c);
				digraph.addEdge(num, num2);
			}
		}
		return digraph;
	}
	
	
	public static Digraph dag(int i1, int i2)
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
		Digraph digraph = new Digraph(i1);
		SET sET = new SET();
		int[] array = new int[i1];
		for (int j = 0; j < i1; j++)
		{
			array[j] = j;
		}
		StdRandom.shuffle(array);
		while (digraph.E() < i2)
		{
			int j = StdRandom.uniform(i1);
			int num = StdRandom.uniform(i1);
			DigraphGenerator.Edge c = new DigraphGenerator.Edge(j, num, null);
			if (j < num && !sET.contains(c))
			{
				sET.add(c);
				digraph.addEdge(array[j], array[num]);
			}
		}
		return digraph;
	}
	
	
	public static Digraph rootedInDAG(int i1, int i2)
	{
		if ((long)i2 > (long)i1 * (long)(i1 - 1) / 2L)
		{
			string arg_18_0 = "Too many edges";
			
			throw new ArgumentException(arg_18_0);
		}
		if (i2 < i1 - 1)
		{
			string arg_2E_0 = "Too few edges";
			
			throw new ArgumentException(arg_2E_0);
		}
		Digraph digraph = new Digraph(i1);
		SET sET = new SET();
		int[] array = new int[i1];
		for (int j = 0; j < i1; j++)
		{
			array[j] = j;
		}
		StdRandom.shuffle(array);
		for (int j = 0; j < i1 - 1; j++)
		{
			int num = StdRandom.uniform(j + 1, i1);
			DigraphGenerator.Edge c = new DigraphGenerator.Edge(j, num, null);
			sET.add(c);
			digraph.addEdge(array[j], array[num]);
		}
		while (digraph.E() < i2)
		{
			int j = StdRandom.uniform(i1);
			int num = StdRandom.uniform(i1);
			DigraphGenerator.Edge c = new DigraphGenerator.Edge(j, num, null);
			if (j < num && !sET.contains(c))
			{
				sET.add(c);
				digraph.addEdge(array[j], array[num]);
			}
		}
		return digraph;
	}
	
	
	public static Digraph rootedOutDAG(int i1, int i2)
	{
		if ((long)i2 > (long)i1 * (long)(i1 - 1) / 2L)
		{
			string arg_18_0 = "Too many edges";
			
			throw new ArgumentException(arg_18_0);
		}
		if (i2 < i1 - 1)
		{
			string arg_2E_0 = "Too few edges";
			
			throw new ArgumentException(arg_2E_0);
		}
		Digraph digraph = new Digraph(i1);
		SET sET = new SET();
		int[] array = new int[i1];
		for (int j = 0; j < i1; j++)
		{
			array[j] = j;
		}
		StdRandom.shuffle(array);
		for (int j = 0; j < i1 - 1; j++)
		{
			int num = StdRandom.uniform(j + 1, i1);
			DigraphGenerator.Edge c = new DigraphGenerator.Edge(num, j, null);
			sET.add(c);
			digraph.addEdge(array[num], array[j]);
		}
		while (digraph.E() < i2)
		{
			int j = StdRandom.uniform(i1);
			int num = StdRandom.uniform(i1);
			DigraphGenerator.Edge c = new DigraphGenerator.Edge(num, j, null);
			if (j < num && !sET.contains(c))
			{
				sET.add(c);
				digraph.addEdge(array[num], array[j]);
			}
		}
		return digraph;
	}
	
	
	public static Digraph complete(int i)
	{
		return DigraphGenerator.simple(i, i * (i - 1));
	}
	
	
	public static Digraph path(int i)
	{
		Digraph digraph = new Digraph(i);
		int[] array = new int[i];
		for (int j = 0; j < i; j++)
		{
			array[j] = j;
		}
		StdRandom.shuffle(array);
		for (int j = 0; j < i - 1; j++)
		{
			digraph.addEdge(array[j], array[j + 1]);
		}
		return digraph;
	}
	
	
	public static Digraph cycle(int i)
	{
		Digraph digraph = new Digraph(i);
		int[] array = new int[i];
		for (int j = 0; j < i; j++)
		{
			array[j] = j;
		}
		StdRandom.shuffle(array);
		for (int j = 0; j < i - 1; j++)
		{
			digraph.addEdge(array[j], array[j + 1]);
		}
		digraph.addEdge(array[i - 1], array[0]);
		return digraph;
	}
	
	
	public static Digraph binaryTree(int i)
	{
		Digraph digraph = new Digraph(i);
		int[] array = new int[i];
		for (int j = 0; j < i; j++)
		{
			array[j] = j;
		}
		StdRandom.shuffle(array);
		for (int j = 1; j < i; j++)
		{
			digraph.addEdge(array[j], array[(j - 1) / 2]);
		}
		return digraph;
	}
	
	
	public static Digraph tournament(int i)
	{
		return DigraphGenerator.dag(i, i * (i - 1) / 2);
	}
	
	
	public static Digraph rootedInTree(int i)
	{
		return DigraphGenerator.rootedInDAG(i, i - 1);
	}
	
	
	public static Digraph rootedOutTree(int i)
	{
		return DigraphGenerator.rootedOutDAG(i, i - 1);
	}
	
	
	public DigraphGenerator()
	{
	}
	
	
	public static Digraph simple(int i, double d)
	{
		if (d < (double)0f || d > (double)1f)
		{
			string arg_1C_0 = "Probability must be between 0 and 1";
			
			throw new ArgumentException(arg_1C_0);
		}
		Digraph digraph = new Digraph(i);
		for (int j = 0; j < i; j++)
		{
			for (int k = 0; k < i; k++)
			{
				if (j != k && StdRandom.bernoulli(d))
				{
					digraph.addEdge(j, k);
				}
			}
		}
		return digraph;
	}
	
	
	public static Digraph strong(int i1, int i2, int i3)
	{
		if (i3 >= i1 || i3 <= 0)
		{
			string arg_12_0 = "Number of components must be between 1 and V";
			
			throw new ArgumentException(arg_12_0);
		}
		if (i2 <= 2 * (i1 - i3))
		{
			string arg_2A_0 = "Number of edges must be at least 2(V-c)";
			
			throw new ArgumentException(arg_2A_0);
		}
		if ((long)i2 > (long)i1 * (long)(i1 - 1) / 2L)
		{
			string arg_48_0 = "Too many edges";
			
			throw new ArgumentException(arg_48_0);
		}
		Digraph digraph = new Digraph(i1);
		SET sET = new SET();
		int[] array = new int[i1];
		for (int j = 0; j < i1; j++)
		{
			array[j] = StdRandom.uniform(i3);
		}
		for (int j = 0; j < i3; j++)
		{
			int num = 0;
			for (int k = 0; k < digraph.V(); k++)
			{
				if (array[k] == j)
				{
					num++;
				}
			}
			int[] array2 = new int[num];
			int num2 = 0;
			for (int l = 0; l < i1; l++)
			{
				if (array[l] == j)
				{
					int[] arg_CC_0 = array2;
					int arg_CC_1 = num2;
					num2++;
					arg_CC_0[arg_CC_1] = l;
				}
			}
			StdRandom.shuffle(array2);
			for (int l = 0; l < num - 1; l++)
			{
				int num3 = StdRandom.uniform(l + 1, num);
				DigraphGenerator.Edge c = new DigraphGenerator.Edge(num3, l, null);
				sET.add(c);
				digraph.addEdge(array2[num3], array2[l]);
			}
			for (int l = 0; l < num - 1; l++)
			{
				int num3 = StdRandom.uniform(l + 1, num);
				DigraphGenerator.Edge c = new DigraphGenerator.Edge(l, num3, null);
				sET.add(c);
				digraph.addEdge(array2[l], array2[num3]);
			}
		}
		while (digraph.E() < i2)
		{
			int j = StdRandom.uniform(i1);
			int num = StdRandom.uniform(i1);
			DigraphGenerator.Edge c2 = new DigraphGenerator.Edge(j, num, null);
			if (!sET.contains(c2) && j != num && array[j] <= array[num])
			{
				sET.add(c2);
				digraph.addEdge(j, num);
			}
		}
		return digraph;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		int num = Integer.parseInt(strarr[0]);
		int i = Integer.parseInt(strarr[1]);
		System.@out.println("complete graph");
		System.@out.println(DigraphGenerator.complete(num));
		System.@out.println();
		System.@out.println("simple");
		System.@out.println(DigraphGenerator.simple(num, i));
		System.@out.println();
		System.@out.println("path");
		System.@out.println(DigraphGenerator.path(num));
		System.@out.println();
		System.@out.println("cycle");
		System.@out.println(DigraphGenerator.cycle(num));
		System.@out.println();
		System.@out.println("binary tree");
		System.@out.println(DigraphGenerator.binaryTree(num));
		System.@out.println();
		System.@out.println("tournament");
		System.@out.println(DigraphGenerator.tournament(num));
		System.@out.println();
		System.@out.println("DAG");
		System.@out.println(DigraphGenerator.dag(num, i));
		System.@out.println();
		System.@out.println("rooted-in DAG");
		System.@out.println(DigraphGenerator.rootedInDAG(num, i));
		System.@out.println();
		System.@out.println("rooted-out DAG");
		System.@out.println(DigraphGenerator.rootedOutDAG(num, i));
		System.@out.println();
		System.@out.println("rooted-in tree");
		System.@out.println(DigraphGenerator.rootedInTree(num));
		System.@out.println();
		System.@out.println("rooted-out DAG");
		System.@out.println(DigraphGenerator.rootedOutTree(num));
		System.@out.println();
	}
}