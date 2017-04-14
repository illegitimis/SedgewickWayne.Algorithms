public class KruskalMST
{
	private double weight;
//[Signature("LQueue<LEdge;>;")]
	private Queue mst;
//[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
	internal static bool s_assertionsDisabled;
	
	
	
	
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
	
	
	public KruskalMST(EdgeWeightedGraph ewg)
	{
		this.mst = new Queue();
		MinPQ minPQ = new MinPQ();
		Iterator iterator = ewg.edges().iterator();
		while (iterator.hasNext())
		{
			Edge edge = (Edge)iterator.next();
			minPQ.insert(edge);
		}
		UF uF = new UF(ewg.V());
		while (!minPQ.isEmpty() && this.mst.size() < ewg.V() - 1)
		{
			Edge edge = (Edge)minPQ.delMin();
			int num = edge.either();
			int i = edge.other(num);
			if (!uF.connected(num, i))
			{
				uF.union(num, i);
				this.mst.enqueue(edge);
				this.weight += edge.weight();
			}
		}
		if (!KruskalMST.s_assertionsDisabled && !this.check(ewg))
		{
			
			throw new AssertionError();
		}
	}
	
	
	/**/public static void main(string[] strarr)
	{
		
		In i = new In(strarr[0]);
		EdgeWeightedGraph ewg = new EdgeWeightedGraph(i);
		KruskalMST kruskalMST = new KruskalMST(ewg);
		Iterator iterator = kruskalMST.edges().iterator();
		while (iterator.hasNext())
		{
			Edge obj = (Edge)iterator.next();
			StdOut.println(obj);
		}
		StdOut.printf("%.5f\n", new object[]
		{
			java.lang.Double.valueOf(kruskalMST.weight())
		});
	}
	
	static KruskalMST()
	{
		KruskalMST.s_assertionsDisabled = !ClassLiteral<KruskalMST>.Value.desiredAssertionStatus();
	}
}