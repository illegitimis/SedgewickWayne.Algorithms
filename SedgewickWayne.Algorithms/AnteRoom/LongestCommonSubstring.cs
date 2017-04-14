public class LongestCommonSubstring
{
	
	
	public LongestCommonSubstring()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		
		In @in = new In(strarr[0]);
		
		In in2 = new In(strarr[1]);
		string text = java.lang.String.instancehelper_replaceAll(java.lang.String.instancehelper_trim(@in.readAll()), "\\s+", " ");
		string text2 = java.lang.String.instancehelper_replaceAll(java.lang.String.instancehelper_trim(in2.readAll()), "\\s+", " ");
		int num = java.lang.String.instancehelper_length(text);
		java.lang.String.instancehelper_length(text2);
		string text3 = new StringBuilder().append(text).append('\u0001').append(text2).toString();
		int num2 = java.lang.String.instancehelper_length(text3);
		SuffixArray suffixArray = new SuffixArray(text3);
		string text4 = "";
		for (int i = 1; i < num2; i++)
		{
			if (suffixArray.index(i) >= num || suffixArray.index(i - 1) >= num)
			{
				if (suffixArray.index(i) <= num || suffixArray.index(i - 1) <= num)
				{
					int num3 = suffixArray.lcp(i);
					if (num3 > java.lang.String.instancehelper_length(text4))
					{
						text4 = java.lang.String.instancehelper_substring(text3, suffixArray.index(i), suffixArray.index(i) + num3);
					}
				}
			}
		}
		StdOut.println(java.lang.String.instancehelper_length(text4));
		StdOut.println(new StringBuilder().append("'").append(text4).append("'").toString());
	}
}