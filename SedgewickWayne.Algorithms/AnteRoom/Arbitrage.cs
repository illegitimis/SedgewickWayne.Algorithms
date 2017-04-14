public class Arbitrage
{
	
	
	private Arbitrage()
	{
	}


  /*public static void main(string[] strarr)
	{
		int num = StdIn.readInt();
		string[] array = new string[num];
		EdgeWeightedDigraph edgeWeightedDigraph = new EdgeWeightedDigraph(num);
		for (int i = 0; i < num; i++)
		{
			array[i] = StdIn.readString();
			for (int j = 0; j < num; j++)
			{
				double a = StdIn.readDouble();
				DirectedEdge directedEdge = new DirectedEdge(i, j, -java.lang.Math.log(a));
				edgeWeightedDigraph.addEdge(directedEdge);
			}
		}
		BellmanFordSP bellmanFordSP = new BellmanFordSP(edgeWeightedDigraph, 0);
		if (bellmanFordSP.hasNegativeCycle())
		{
			double num2 = 1000.0;
			Iterator iterator = bellmanFordSP.negativeCycle().iterator();
			while (iterator.hasNext())
			{
				DirectedEdge directedEdge = (DirectedEdge)iterator.next();
				StdOut.printf("%10.5f %s ", new object[]
				{
					java.lang.Double.valueOf(num2),
					array[directedEdge.from()]
				});
				num2 *= java.lang.Math.exp(-directedEdge.weight());
				StdOut.printf("= %10.5f %s\n", new object[]
				{
					java.lang.Double.valueOf(num2),
					array[directedEdge.to()]
				});
			}
		}
		else
		{
			StdOut.println("No arbitrage opportunity");
		}
	}*/
}