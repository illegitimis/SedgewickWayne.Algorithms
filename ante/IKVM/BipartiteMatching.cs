public class BipartiteMatching
{
	
	
	public BipartiteMatching()
	{
	}
	
	
	/**//**/public static void main(string[] strarr)
	{
		int num = Integer.parseInt(strarr[0]);
		int num2 = Integer.parseInt(strarr[1]);
		int i = 2 * num;
		int i2 = 2 * num + 1;
		FlowNetwork flowNetwork = new FlowNetwork(2 * num + 2);
		for (int j = 0; j < num2; j++)
		{
			int k = StdRandom.uniform(num);
			int num3 = StdRandom.uniform(num) + num;
			flowNetwork.addEdge(new FlowEdge(k, num3, double.PositiveInfinity));
			StdOut.println(new StringBuilder().append(k).append("-").append(num3).toString());
		}
		for (int j = 0; j < num; j++)
		{
			flowNetwork.addEdge(new FlowEdge(i, j, (double)1f));
			flowNetwork.addEdge(new FlowEdge(j + num, i2, (double)1f));
		}
		FordFulkerson fordFulkerson = new FordFulkerson(flowNetwork, i, i2);
		StdOut.println();
		StdOut.println(new StringBuilder().append("Size of maximum matching = ").append(ByteCodeHelper.d2i(fordFulkerson.value())).toString());
		for (int k = 0; k < num; k++)
		{
			Iterator iterator = flowNetwork.adj(k).iterator();
			while (iterator.hasNext())
			{
				FlowEdge flowEdge = (FlowEdge)iterator.next();
				if (flowEdge.from() == k && flowEdge.flow() > (double)0f)
				{
					StdOut.println(new StringBuilder().append(flowEdge.from()).append("-").append(flowEdge.to()).toString());
				}
			}
		}
	}
}