public class BoyerMoore
{
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private int R;
	private int[] right;
	private char[] pattern;
	private string pat;
	
	
	public BoyerMoore(string str)
	{
		this.R = 256;
		this.pat = str;
		this.right = new int[this.R];
		for (int i = 0; i < this.R; i++)
		{
			this.right[i] = -1;
		}
		for (int i = 0; i < java.lang.String.instancehelper_length(str); i++)
		{
			this.right[(int)java.lang.String.instancehelper_charAt(str, i)] = i;
		}
	}
	
	
	public BoyerMoore(char[] charr, int i)
	{
		this.R = i;
		this.pattern = new char[charr.Length];
		for (int j = 0; j < charr.Length; j++)
		{
			this.pattern[j] = charr[j];
		}
		this.right = new int[i];
		for (int j = 0; j < i; j++)
		{
			this.right[j] = -1;
		}
		for (int j = 0; j < charr.Length; j++)
		{
			this.right[(int)charr[j]] = j;
		}
	}
	
	
	public virtual int search(string str)
	{
		int num = java.lang.String.instancehelper_length(this.pat);
		int num2 = java.lang.String.instancehelper_length(str);
		int num3;
		for (int i = 0; i <= num2 - num; i += num3)
		{
			num3 = 0;
			for (int j = num - 1; j >= 0; j += -1)
			{
				if (java.lang.String.instancehelper_charAt(this.pat, j) != java.lang.String.instancehelper_charAt(str, i + j))
				{
					num3 = java.lang.Math.max(1, j - this.right[(int)java.lang.String.instancehelper_charAt(str, i + j)]);
					break;
				}
			}
			if (num3 == 0)
			{
				return i;
			}
		}
		return num2;
	}
	
	
	public virtual int search(char[] charr)
	{
		int num = this.pattern.Length;
		int num2 = charr.Length;
		int num3;
		for (int i = 0; i <= num2 - num; i += num3)
		{
			num3 = 0;
			for (int j = num - 1; j >= 0; j += -1)
			{
				if (this.pattern[j] != charr[i + j])
				{
					num3 = java.lang.Math.max(1, j - this.right[(int)charr[i + j]]);
					break;
				}
			}
			if (num3 == 0)
			{
				return i;
			}
		}
		return num2;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		string text = strarr[0];
		string text2 = strarr[1];
		char[] charr = java.lang.String.instancehelper_toCharArray(text);
		char[] charr2 = java.lang.String.instancehelper_toCharArray(text2);
		BoyerMoore boyerMoore = new BoyerMoore(text);
		BoyerMoore boyerMoore2 = new BoyerMoore(charr, 256);
		int num = boyerMoore.search(text2);
		int num2 = boyerMoore2.search(charr2);
		StdOut.println(new StringBuilder().append("text:    ").append(text2).toString());
		StdOut.print("pattern: ");
		for (int i = 0; i < num; i++)
		{
			StdOut.print(" ");
		}
		StdOut.println(text);
		StdOut.print("pattern: ");
		for (int i = 0; i < num2; i++)
		{
			StdOut.print(" ");
		}
		StdOut.println(text);
	}
}