public class DegreesOfSeparation
{
	
	
	private DegreesOfSeparation()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		string str = strarr[0];
		string str2 = strarr[1];
		string str3 = strarr[2];
		SymbolGraph symbolGraph = new SymbolGraph(str, str2);
		Graph g = symbolGraph.G();
		if (!symbolGraph.contains(str3))
		{
			StdOut.println(new StringBuilder().append(str3).append(" not in database.").toString());
			return;
		}
		int i = symbolGraph.index(str3);
		BreadthFirstPaths breadthFirstPaths = new BreadthFirstPaths(g, i);
		while (!StdIn.isEmpty())
		{
			string str4 = StdIn.readLine();
			if (symbolGraph.contains(str4))
			{
				int i2 = symbolGraph.index(str4);
				if (breadthFirstPaths.hasPathTo(i2))
				{
					Iterator iterator = breadthFirstPaths.pathTo(i2).iterator();
					while (iterator.hasNext())
					{
						int i3 = ((Integer)iterator.next()).intValue();
						StdOut.println(new StringBuilder().append("   ").append(symbolGraph.name(i3)).toString());
					}
				}
				else
				{
					StdOut.println("Not connected");
				}
			}
			else
			{
				StdOut.println("   Not in database.");
			}
		}
	}
}