public class DeDup
{
	
	
	public DeDup()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		SET sET = new SET();
		while (!StdIn.isEmpty())
		{
			string text = StdIn.readString();
			if (!sET.contains(text))
			{
				sET.add(text);
				StdOut.println(text);
			}
		}
	}
}