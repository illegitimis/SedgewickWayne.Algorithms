public class KWIK
{
	
	
	public KWIK()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		
		In @in = new In(strarr[0]);
		int num = Integer.parseInt(strarr[1]);
		string text = java.lang.String.instancehelper_replaceAll(@in.readAll(), "\\s+", " ");
		int num2 = java.lang.String.instancehelper_length(text);
		SuffixArray suffixArray = new SuffixArray(text);
		while (StdIn.hasNextLine())
		{
			string text2 = StdIn.readLine();
			for (int i = suffixArray.rank(text2); i < num2; i++)
			{
				int num3 = suffixArray.index(i);
				int endIndex = java.lang.Math.min(num2, num3 + java.lang.String.instancehelper_length(text2));
				if (!java.lang.String.instancehelper_equals(text2, java.lang.String.instancehelper_substring(text, num3, endIndex)))
				{
					break;
				}
				int beginIndex = java.lang.Math.max(0, suffixArray.index(i) - num);
				int endIndex2 = java.lang.Math.min(num2, suffixArray.index(i) + num + java.lang.String.instancehelper_length(text2));
				StdOut.println(java.lang.String.instancehelper_substring(text, beginIndex, endIndex2));
			}
			StdOut.println();
		}
	}
}