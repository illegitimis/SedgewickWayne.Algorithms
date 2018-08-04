public class CPM
{
	
	
	private CPM()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		int num = StdIn.readInt();
		int num2 = 2 * num;
		int num3 = 2 * num + 1;
		EdgeWeightedDigraph edgeWeightedDigraph = new EdgeWeightedDigraph(2 * num + 2);
		for (int i = 0; i < num; i++)
		{
			double d = StdIn.readDouble();
			edgeWeightedDigraph.addEdge(new DirectedEdge(num2, i, (double)0f));
			edgeWeightedDigraph.addEdge(new DirectedEdge(i + num, num3, (double)0f));
			edgeWeightedDigraph.addEdge(new DirectedEdge(i, i + num, d));
			int num4 = StdIn.readInt();
			for (int j = 0; j < num4; j++)
			{
				int i2 = StdIn.readInt();
				edgeWeightedDigraph.addEdge(new DirectedEdge(num + i, i2, (double)0f));
			}
		}
		AcyclicLP acyclicLP = new AcyclicLP(edgeWeightedDigraph, num2);
		StdOut.println(" job   start  finish");
		StdOut.println("--------------------");
		for (int k = 0; k < num; k++)
		{
			StdOut.printf("%4d %7.1f %7.1f\n", new object[]
			{
				Integer.valueOf(k),
				java.lang.Double.valueOf(acyclicLP.distTo(k)),
				java.lang.Double.valueOf(acyclicLP.distTo(k + num))
			});
		}
		StdOut.printf("Finish time: %7.1f\n", new object[]
		{
			java.lang.Double.valueOf(acyclicLP.distTo(num3))
		});
	}
}