public class BoruvkaMST
{
//[Signature("LBag<LEdge;>;")]
	private Bag mst;
	private double weight;
//[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
	internal static bool s_assertionsDisabled;
	
	
	
	
	private static bool less(Edge edge, Edge edge2)
	{
		return edge.weight() < edge2.weight();
	}
	
	
	private bool check(EdgeWeightedGraph edgeWeightedGraph)
	{
		double num = (double)0f;
		Iterator iterator = this.edges().iterator();
		while (iterator.hasNext())
		{
			Edge edge = (Edge)iterator.next();
			num += edge.weight();
		}
		double num2 = 1E-12;
		if (java.lang.Math.abs(num - this.weight()) > num2)
		{
			System.err.printf("Weight of edges does not equal weight(): %f vs. %f\n", new object[]
			{
				java.lang.Double.valueOf(num),
				java.lang.Double.valueOf(this.weight())
			});
			return false;
		}
		UF uF = new UF(edgeWeightedGraph.V());
		Iterator iterator2 = this.edges().iterator();
		while (iterator2.hasNext())
		{
			Edge edge2 = (Edge)iterator2.next();
			int num3 = edge2.either();
			int i = edge2.other(num3);
			if (uF.connected(num3, i))
			{
				System.err.println("Not a forest");
				return false;
			}
			uF.union(num3, i);
		}
		iterator2 = edgeWeightedGraph.edges().iterator();
		while (iterator2.hasNext())
		{
			Edge edge2 = (Edge)iterator2.next();
			int num3 = edge2.either();
			int i = edge2.other(num3);
			if (!uF.connected(num3, i))
			{
				System.err.println("Not a spanning forest");
				return false;
			}
		}
		iterator2 = this.edges().iterator();
		while (iterator2.hasNext())
		{
			Edge edge2 = (Edge)iterator2.next();
			uF = new UF(edgeWeightedGraph.V());
			Iterator iterator3 = this.mst.iterator();
			while (iterator3.hasNext())
			{
				Edge edge3 = (Edge)iterator3.next();
				int num4 = edge3.either();
				int i2 = edge3.other(num4);
				if (edge3 != edge2)
				{
					uF.union(num4, i2);
				}
			}
			iterator3 = edgeWeightedGraph.edges().iterator();
			while (iterator3.hasNext())
			{
				Edge edge3 = (Edge)iterator3.next();
				int num4 = edge3.either();
				int i2 = edge3.other(num4);
				if (!uF.connected(num4, i2) && edge3.weight() < edge2.weight())
				{
					System.err.println(new StringBuilder().append("Edge ").append(edge3).append(" violates cut optimality conditions").toString());
					return false;
				}
			}
		}
		return true;
	}
/*	[Signature("()Ljava/lang/Iterable<LEdge;>;")]*/
	public virtual Iterable edges()
	{
		return this.mst;
	}
	public virtual double weight()
	{
		return this.weight;
	}
	
	
	public BoruvkaMST(EdgeWeightedGraph ewg)
	{
		this.mst = new Bag();
		UF uF = new UF(ewg.V());
		int num = 1;
		while (num < ewg.V() && this.mst.size() < ewg.V() - 1)
		{
			Edge[] array = new Edge[ewg.V()];
			Iterator iterator = ewg.edges().iterator();
			while (iterator.hasNext())
			{
				Edge edge = (Edge)iterator.next();
				int num2 = edge.either();
				int num3 = edge.other(num2);
				int num4 = uF.find(num2);
				int num5 = uF.find(num3);
				if (num4 != num5)
				{
					if (array[num4] == null || BoruvkaMST.less(edge, array[num4]))
					{
						array[num4] = edge;
					}
					if (array[num5] == null || BoruvkaMST.less(edge, array[num5]))
					{
						array[num5] = edge;
					}
				}
			}
			for (int i = 0; i < ewg.V(); i++)
			{
				Edge edge = array[i];
				if (edge != null)
				{
					int num2 = edge.either();
					int num3 = edge.other(num2);
					if (!uF.connected(num2, num3))
					{
						this.mst.add(edge);
						this.weight += edge.weight();
						uF.union(num2, num3);
					}
				}
			}
			num += num;
		}
		if (!BoruvkaMST.s_assertionsDisabled && !this.check(ewg))
		{
			
			throw new AssertionError();
		}
	}
	
	
	/**/public static void main(string[] strarr)
	{
		
		In i = new In(strarr[0]);
		EdgeWeightedGraph ewg = new EdgeWeightedGraph(i);
		BoruvkaMST boruvkaMST = new BoruvkaMST(ewg);
		Iterator iterator = boruvkaMST.edges().iterator();
		while (iterator.hasNext())
		{
			Edge obj = (Edge)iterator.next();
			StdOut.println(obj);
		}
		StdOut.printf("%.5f\n", new object[]
		{
			java.lang.Double.valueOf(boruvkaMST.weight())
		});
	}
	
	static BoruvkaMST()
	{
		BoruvkaMST.s_assertionsDisabled = !ClassLiteral<BoruvkaMST>.Value.desiredAssertionStatus();
	}
}