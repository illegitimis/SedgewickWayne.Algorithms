public class Whitelist
{
	
	
	public Whitelist()
	{
	}
	
	
	/*public static void main(string[] strarr)
	{
		
		In @in = new In(strarr[0]);
		int[] iarr = @in.readAllInts();
		StaticSETofInts staticSETofInts = new StaticSETofInts(iarr);
		while (!StdIn.isEmpty())
		{
			int i = StdIn.readInt();
			if (!staticSETofInts.contains(i))
			{
				StdOut.println(i);
			}
		}
	}*/
}



public class BlackFilter
{
	
	
	public BlackFilter()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		SET sET = new SET();
		
		In @in = new In(strarr[0]);
		while (!@in.isEmpty())
		{
			string text = @in.readString();
			sET.add(text);
		}
		while (!StdIn.isEmpty())
		{
			string text = StdIn.readString();
			if (!sET.contains(text))
			{
				StdOut.println(text);
			}
		}
	}
}