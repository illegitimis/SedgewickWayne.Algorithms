public class Alphabet
{
	internal static Alphabet __BINARY;
	internal static Alphabet __OCTAL;
	internal static Alphabet __DECIMAL;
	internal static Alphabet __HEXADECIMAL;
	internal static Alphabet __DNA;
	internal static Alphabet __LOWERCASE;
	internal static Alphabet __UPPERCASE;
	internal static Alphabet __PROTEIN;
	internal static Alphabet __BASE64;
	internal static Alphabet __ASCII;
	internal static Alphabet __EXTENDED_ASCII;
	internal static Alphabet __UNICODE16;
	private char[] alphabet;
	private int[] inverse;
	private int R;
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Alphabet BINARY
	{
		
		get
		{
			return Alphabet.__BINARY;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Alphabet OCTAL
	{
		
		get
		{
			return Alphabet.__OCTAL;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Alphabet DECIMAL
	{
		
		get
		{
			return Alphabet.__DECIMAL;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Alphabet HEXADECIMAL
	{
		
		get
		{
			return Alphabet.__HEXADECIMAL;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Alphabet DNA
	{
		
		get
		{
			return Alphabet.__DNA;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Alphabet LOWERCASE
	{
		
		get
		{
			return Alphabet.__LOWERCASE;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Alphabet UPPERCASE
	{
		
		get
		{
			return Alphabet.__UPPERCASE;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Alphabet PROTEIN
	{
		
		get
		{
			return Alphabet.__PROTEIN;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Alphabet BASE64
	{
		
		get
		{
			return Alphabet.__BASE64;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Alphabet ASCII
	{
		
		get
		{
			return Alphabet.__ASCII;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Alphabet EXTENDED_ASCII
	{
		
		get
		{
			return Alphabet.__EXTENDED_ASCII;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Alphabet UNICODE16
	{
		
		get
		{
			return Alphabet.__UNICODE16;
		}
	}
	
	
	
	
	private Alphabet(int num)
	{
		this.alphabet = new char[num];
		this.inverse = new int[num];
		this.R = num;
		for (int i = 0; i < num; i++)
		{
			this.alphabet[i] = (char)i;
		}
		for (int i = 0; i < num; i++)
		{
			this.inverse[i] = i;
		}
	}
	
	
	public virtual int toIndex(char ch)
	{
		if (ch < '\0' || (int)ch >= this.inverse.Length || this.inverse[(int)ch] == -1)
		{
			string arg_44_0 = new StringBuilder().append("Character ").append(ch).append(" not in alphabet").toString();
			
			throw new ArgumentException(arg_44_0);
		}
		return this.inverse[(int)ch];
	}
	
	
	public virtual char toChar(int i)
	{
		if (i < 0 || i >= this.R)
		{
			string arg_17_0 = "Alphabet index out of bounds";
			
			throw new IndexOutOfRangeException(arg_17_0);
		}
		return this.alphabet[i];
	}
	
	
	public virtual int[] toIndices(string str)
	{
		char[] array = java.lang.String.instancehelper_toCharArray(str);
		int[] array2 = new int[java.lang.String.instancehelper_length(str)];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = this.toIndex(array[i]);
		}
		return array2;
	}
	
	
	public virtual string toChars(int[] iarr)
	{
		StringBuilder stringBuilder = new StringBuilder(iarr.Length);
		for (int i = 0; i < iarr.Length; i++)
		{
			stringBuilder.append(this.toChar(iarr[i]));
		}
		return stringBuilder.toString();
	}
	
	
	public Alphabet(string str)
	{
		bool[] array = new bool[65535];
		for (int i = 0; i < java.lang.String.instancehelper_length(str); i++)
		{
			int num = (int)java.lang.String.instancehelper_charAt(str, i);
			if (array[num])
			{
				string arg_54_0 = new StringBuilder().append("Illegal alphabet: repeated character = '").append((char)num).append("'").toString();
				
				throw new ArgumentException(arg_54_0);
			}
			array[num] = true;
		}
		this.alphabet = java.lang.String.instancehelper_toCharArray(str);
		this.R = java.lang.String.instancehelper_length(str);
		this.inverse = new int[65535];
		for (int i = 0; i < this.inverse.Length; i++)
		{
			this.inverse[i] = -1;
		}
		for (int i = 0; i < this.R; i++)
		{
			this.inverse[(int)this.alphabet[i]] = i;
		}
	}
	
	
	public Alphabet() : this(256)
	{
	}
	
	public virtual bool contains(char ch)
	{
		return this.inverse[(int)ch] != -1;
	}
	public virtual int R()
	{
		return this.R;
	}
	
	public virtual int lgR()
	{
		int num = 0;
		for (int i = this.R - 1; i >= 1; i /= 2)
		{
			num++;
		}
		return num;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		int[] iarr = Alphabet.__BASE64.toIndices("NowIsTheTimeForAllGoodMen");
		string obj = Alphabet.__BASE64.toChars(iarr);
		StdOut.println(obj);
		int[] iarr2 = Alphabet.__DNA.toIndices("AACGAACGGTTTACCCCG");
		string obj2 = Alphabet.__DNA.toChars(iarr2);
		StdOut.println(obj2);
		int[] iarr3 = Alphabet.__DECIMAL.toIndices("01234567890123456789");
		string obj3 = Alphabet.__DECIMAL.toChars(iarr3);
		StdOut.println(obj3);
	}
	
	static Alphabet()
	{
		Alphabet.__BINARY = new Alphabet("01");
		Alphabet.__OCTAL = new Alphabet("01234567");
		Alphabet.__DECIMAL = new Alphabet("0123456789");
		Alphabet.__HEXADECIMAL = new Alphabet("0123456789ABCDEF");
		Alphabet.__DNA = new Alphabet("ACTG");
		Alphabet.__LOWERCASE = new Alphabet("abcdefghijklmnopqrstuvwxyz");
		Alphabet.__UPPERCASE = new Alphabet("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
		Alphabet.__PROTEIN = new Alphabet("ACDEFGHIKLMNPQRSTVWY");
		Alphabet.__BASE64 = new Alphabet("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/");
		Alphabet.__ASCII = new Alphabet(128);
		Alphabet.__EXTENDED_ASCII = new Alphabet(256);
		Alphabet.__UNICODE16 = new Alphabet(65536);
	}
}