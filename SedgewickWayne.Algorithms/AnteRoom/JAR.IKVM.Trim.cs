using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.ComponentModel;






public class Count
{
	
	
	public Count()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		Alphabet.__<clinit>();
		Alphabet alphabet = new Alphabet(strarr[0]);
		int num = alphabet.R();
		int[] array = new int[num];
		string @this = StdIn.readAll();
		int num2 = java.lang.String.instancehelper_length(@this);
		for (int i = 0; i < num2; i++)
		{
			if (alphabet.contains(java.lang.String.instancehelper_charAt(@this, i)))
			{
				int[] arg_54_0 = array;
				int num3 = alphabet.toIndex(java.lang.String.instancehelper_charAt(@this, i));
				int[] array2 = arg_54_0;
				array2[num3]++;
			}
		}
		for (int i = 0; i < num; i++)
		{
			StdOut.println(new StringBuilder().append(alphabet.toChar(i)).append(" ").append(array[i]).toString());
		}
	}
}






/*[Implements(new string[]
{
	"java.lang.Comparable"
}), Signature("Ljava/lang/Object;Ljava/lang/Comparable<LCounter;>;")]*/
public class Counter : IComparable
{
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private string name;
	private int count;
	
	
	public Counter(string str)
	{
		this.name = str;
	}
	
	public virtual void increment()
	{
		this.count++;
	}
	
	public virtual int compareTo(Counter c)
	{
		if (this.count < c.count)
		{
			return -1;
		}
		if (this.count > c.count)
		{
			return 1;
		}
		return 0;
	}
	public virtual int tally()
	{
		return this.count;
	}
	
	
	public override string ToString()
	{
		return new StringBuilder().append(this.count).append(" ").append(this.name).toString();
	}
	
	
	/**/public static void main(string[] strarr)
	{
		int num = Integer.parseInt(strarr[0]);
		int num2 = Integer.parseInt(strarr[1]);
		Counter[] array = new Counter[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = new Counter(new StringBuilder().append("counter").append(i).toString());
		}
		for (int i = 0; i < num2; i++)
		{
			array[StdRandom.uniform(num)].increment();
		}
		for (int i = 0; i < num; i++)
		{
			StdOut.println(array[i]);
		}
	}
/*	[LineNumberTable(30), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic), EditorBrowsable(EditorBrowsableState.Never)]*/
	
	public virtual int compareTo(object obj)
	{
		return this.CompareTo((Counter)obj);
	}
	
	int IComparable.CompareTo(object obj)
	{
		return this.CompareTo(obj);
	}
}



public class DoublingRatio
{
	
	
	public static double timeTrial(int i)
	{
		int num = 1000000;
		int[] array = new int[i];
		for (int j = 0; j < i; j++)
		{
			array[j] = StdRandom.uniform(-num, num);
		}
		Stopwatch stopwatch = new Stopwatch();
		ThreeSum.count(array);
		return stopwatch.elapsedTime();
	}
	
	
	private DoublingRatio()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		double num = DoublingRatio.timeTrial(125);
		int num2 = 250;
		while (true)
		{
			double num3 = DoublingRatio.timeTrial(num2);
			StdOut.printf("%6d %7.1f %5.1f\n", new object[]
			{
				Integer.valueOf(num2),
				java.lang.Double.valueOf(num3),
				java.lang.Double.valueOf(num3 / num)
			});
			num = num3;
			num2 += num2;
		}
	}
}


public class DoublingTest
{
	
	
	public static double timeTrial(int i)
	{
		int num = 1000000;
		int[] array = new int[i];
		for (int j = 0; j < i; j++)
		{
			array[j] = StdRandom.uniform(-num, num);
		}
		Stopwatch stopwatch = new Stopwatch();
		ThreeSum.count(array);
		return stopwatch.elapsedTime();
	}
	
	
	private DoublingTest()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		int num = 250;
		while (true)
		{
			double d = DoublingTest.timeTrial(num);
			StdOut.printf("%7d %5.1f\n", new object[]
			{
				Integer.valueOf(num),
				java.lang.Double.valueOf(d)
			});
			num += num;
		}
	}
}






public sealed class In
{
	private Scanner scanner;
	private const string charsetName = "UTF-8";
//[Modifiers(Modifiers.Private | Modifiers.Static | Modifiers.Final)]
	private static Locale usLocale;
//[Modifiers(Modifiers.Private | Modifiers.Static | Modifiers.Final)]
	private static Pattern WHITESPACE_PATTERN;
//[Modifiers(Modifiers.Private | Modifiers.Static | Modifiers.Final)]
	private static Pattern EMPTY_PATTERN;
//[Modifiers(Modifiers.Private | Modifiers.Static | Modifiers.Final)]
	private static Pattern EVERYTHING_PATTERN;
//[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
	internal static bool s_assertionsDisabled;
	
	
	
	
	public In(string str)
	{
		try
		{
			File file = new File(str);
			if (!file.exists())
			{
				URL uRL = java.lang.Object.instancehelper_getClass(this).getResource(str);
				if (uRL == null)
				{
					uRL = new URL(str);
				}
				URLConnection uRLConnection = uRL.openConnection();
				InputStream inputStream = uRLConnection.getInputStream();
				Scanner.__<clinit>();
				this.scanner = new Scanner(new BufferedInputStream(inputStream), "UTF-8");
				this.scanner.useLocale(In.usLocale);
				goto IL_95;
			}
			this.scanner = new Scanner(file, "UTF-8");
			this.scanner.useLocale(In.usLocale);
		}
		catch (IOException arg_92_0)
		{
			goto IL_97;
		}
		return;
		IL_95:
		return;
		IL_97:
		System.err.println(new StringBuilder().append("Could not open ").append(str).toString());
	}
	
	
	public virtual int readInt()
	{
		return this.scanner.nextInt();
	}
	
	
	public virtual double readDouble()
	{
		return this.scanner.nextDouble();
	}
	
	
	public virtual int[] readAllInts()
	{
		string[] array = this.readAllStrings();
		int[] array2 = new int[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = Integer.parseInt(array[i]);
		}
		return array2;
	}
	
	
	public virtual bool IsEmpty
	{
		return !this.scanner.hasNext();
	}
	
	
	public virtual string readString()
	{
		return this.scanner.next();
	}
	
	
	public virtual string readAll()
	{
		if (!this.scanner.hasNextLine())
		{
			return "";
		}
		string result = this.scanner.useDelimiter(In.EVERYTHING_PATTERN).next();
		this.scanner.useDelimiter(In.WHITESPACE_PATTERN);
		return result;
	}
	
	
	public virtual void close()
	{
		this.scanner.close();
	}
	
	
	public In(File f)
	{
		try
		{
			this.scanner = new Scanner(f, "UTF-8");
			this.scanner.useLocale(In.usLocale);
		}
		catch (IOException arg_2E_0)
		{
			goto IL_32;
		}
		return;
		IL_32:
		System.err.println(new StringBuilder().append("Could not open ").append(f).toString());
	}
	
	
	public virtual bool hasNextLine()
	{
		return this.scanner.hasNextLine();
	}
	
	
	public virtual string readLine()
	{
		string result;
		try
		{
			result = this.scanner.nextLine();
		}
		catch (System.Exception arg_11_0)
		{
			if (ByteCodeHelper.MapException<java.lang.Exception>(arg_11_0, ByteCodeHelper.MapFlags.Unused) == null)
			{
				throw;
			}
			goto IL_1E;
		}
		return result;
		IL_1E:
		result = null;
		return result;
	}
	
	
	public virtual string[] readAllStrings()
	{
		Pattern arg_1B_0 = In.WHITESPACE_PATTERN;
		object _<ref> = this.readAll();
		CharSequence input;
		input.__<ref> = _<ref>;
		string[] array = arg_1B_0.split(input);
		if (array.Length == 0 || java.lang.String.instancehelper_length(array[0]) > 0)
		{
			return array;
		}
		string[] array2 = new string[array.Length - 1];
		for (int i = 0; i < array.Length - 1; i++)
		{
			array2[i] = array[i + 1];
		}
		return array2;
	}
	
	
	public virtual double[] readAllDoubles()
	{
		string[] array = this.readAllStrings();
		double[] array2 = new double[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = java.lang.Double.parseDouble(array[i]);
		}
		return array2;
	}
	
	
	public In()
	{
		Scanner.__<clinit>();
		BufferedInputStream.__<clinit>();
		this.scanner = new Scanner(new BufferedInputStream(System.@in), "UTF-8");
		this.scanner.useLocale(In.usLocale);
	}
	
	
	public virtual char readChar()
	{
		this.scanner.useDelimiter(In.EMPTY_PATTERN);
		string this2 = this.scanner.next();
		if (!In.s_assertionsDisabled && java.lang.String.instancehelper_length(this2) != 1)
		{
			object arg_37_0 = "Internal (Std)In.readChar() error! Please contact the authors.";
			
			throw new AssertionError(arg_37_0);
		}
		this.scanner.useDelimiter(In.WHITESPACE_PATTERN);
		return java.lang.String.instancehelper_charAt(this2, 0);
	}
	
	
	public In(Socket s)
	{
		try
		{
			InputStream inputStream = s.getInputStream();
			Scanner.__<clinit>();
			this.scanner = new Scanner(new BufferedInputStream(inputStream), "UTF-8");
			this.scanner.useLocale(In.usLocale);
		}
		catch (IOException arg_3F_0)
		{
			goto IL_43;
		}
		return;
		IL_43:
		System.err.println(new StringBuilder().append("Could not open ").append(s).toString());
	}
	
	
	public In(URL url)
	{
		try
		{
			URLConnection uRLConnection = url.openConnection();
			InputStream inputStream = uRLConnection.getInputStream();
			Scanner.__<clinit>();
			this.scanner = new Scanner(new BufferedInputStream(inputStream), "UTF-8");
			this.scanner.useLocale(In.usLocale);
		}
		catch (IOException arg_46_0)
		{
			goto IL_4A;
		}
		return;
		IL_4A:
		System.err.println(new StringBuilder().append("Could not open ").append(url).toString());
	}
	
	
	public In(Scanner s)
	{
		this.scanner = s;
	}
	public virtual bool exists()
	{
		return this.scanner != null;
	}
	
	
	public virtual bool hasNextChar()
	{
		this.scanner.useDelimiter(In.EMPTY_PATTERN);
		int result = this.scanner.hasNext() ? 1 : 0;
		this.scanner.useDelimiter(In.WHITESPACE_PATTERN);
		return result != 0;
	}
	
	
	public virtual float readFloat()
	{
		return this.scanner.nextFloat();
	}
	
	
	public virtual long readLong()
	{
		return this.scanner.nextLong();
	}
	
	
	public virtual short readShort()
	{
		return this.scanner.nextShort();
	}
	
	
	public virtual byte readByte()
	{
		return (byte)((sbyte)this.scanner.nextByte());
	}
	
	
	public virtual bool readBoolean()
	{
		string this2 = this.readString();
		if (java.lang.String.instancehelper_equalsIgnoreCase(this2, "true"))
		{
			return true;
		}
		if (java.lang.String.instancehelper_equalsIgnoreCase(this2, "false"))
		{
			return false;
		}
		if (java.lang.String.instancehelper_equals(this2, "1"))
		{
			return true;
		}
		if (java.lang.String.instancehelper_equals(this2, "0"))
		{
			return false;
		}
		
		throw new InputMismatchException();
	}
//[LineNumberTable(364), Obsolete]
	
	public static int[] readInts(string str)
	{
		return new In(str).readAllInts();
	}
//[LineNumberTable(373), Obsolete]
	
	public static double[] readDoubles(string str)
	{
		return new In(str).readAllDoubles();
	}
//[LineNumberTable(382), Obsolete]
	
	public static string[] readStrings(string str)
	{
		return new In(str).readAllStrings();
	}
//[LineNumberTable(390), Obsolete]
	
	public static int[] readInts()
	{
		return new In().readAllInts();
	}
//[LineNumberTable(398), Obsolete]
	
	public static double[] readDoubles()
	{
		return new In().readAllDoubles();
	}
//[LineNumberTable(406), Obsolete]
	
	public static string[] readStrings()
	{
		return new In().readAllStrings();
	}
	
	
	/**/public static void main(string[] strarr)
	{
		string str = "http://introcs.cs.princeton.edu/stdlib/InTest.txt";
		System.@out.println(new StringBuilder().append("readAll() from URL ").append(str).toString());
		System.@out.println("---------------------------------------------------------------------------");
		In @in;
		java.lang.Exception ex;
		try
		{
			@in = new In(str);
			System.@out.println(@in.readAll());
		}
		catch (System.Exception arg_55_0)
		{
			java.lang.Exception expr_5A = ByteCodeHelper.MapException<java.lang.Exception>(arg_55_0, ByteCodeHelper.MapFlags.None);
			if (expr_5A == null)
			{
				throw;
			}
			ex = expr_5A;
			goto IL_64;
		}
		goto IL_75;
		IL_64:
		java.lang.Exception x = ex;
		System.@out.println(x);
		IL_75:
		System.@out.println();
		System.@out.println(new StringBuilder().append("readLine() from URL ").append(str).toString());
		System.@out.println("---------------------------------------------------------------------------");
		java.lang.Exception ex2;
		try
		{
			@in = new In(str);
			while (!@in.IsEmpty)
			{
				string x2 = @in.readLine();
				System.@out.println(x2);
			}
		}
		catch (System.Exception arg_DA_0)
		{
			java.lang.Exception expr_DF = ByteCodeHelper.MapException<java.lang.Exception>(arg_DA_0, ByteCodeHelper.MapFlags.None);
			if (expr_DF == null)
			{
				throw;
			}
			ex2 = expr_DF;
			goto IL_EA;
		}
		goto IL_FC;
		IL_EA:
		x = ex2;
		System.@out.println(x);
		IL_FC:
		System.@out.println();
		System.@out.println(new StringBuilder().append("readString() from URL ").append(str).toString());
		System.@out.println("---------------------------------------------------------------------------");
		java.lang.Exception ex3;
		try
		{
			@in = new In(str);
			while (!@in.IsEmpty)
			{
				string x2 = @in.readString();
				System.@out.println(x2);
			}
		}
		catch (System.Exception arg_161_0)
		{
			java.lang.Exception expr_166 = ByteCodeHelper.MapException<java.lang.Exception>(arg_161_0, ByteCodeHelper.MapFlags.None);
			if (expr_166 == null)
			{
				throw;
			}
			ex3 = expr_166;
			goto IL_171;
		}
		goto IL_183;
		IL_171:
		x = ex3;
		System.@out.println(x);
		IL_183:
		System.@out.println();
		System.@out.println("readLine() from current directory");
		System.@out.println("---------------------------------------------------------------------------");
		java.lang.Exception ex4;
		try
		{
			@in = new In("./InTest.txt");
			while (!@in.IsEmpty)
			{
				string x2 = @in.readLine();
				System.@out.println(x2);
			}
		}
		catch (System.Exception arg_1D7_0)
		{
			java.lang.Exception expr_1DC = ByteCodeHelper.MapException<java.lang.Exception>(arg_1D7_0, ByteCodeHelper.MapFlags.None);
			if (expr_1DC == null)
			{
				throw;
			}
			ex4 = expr_1DC;
			goto IL_1E7;
		}
		goto IL_1F9;
		IL_1E7:
		x = ex4;
		System.@out.println(x);
		IL_1F9:
		System.@out.println();
		System.@out.println("readLine() from relative path");
		System.@out.println("---------------------------------------------------------------------------");
		java.lang.Exception ex5;
		try
		{
			@in = new In("../stdlib/InTest.txt");
			while (!@in.IsEmpty)
			{
				string x2 = @in.readLine();
				System.@out.println(x2);
			}
		}
		catch (System.Exception arg_24D_0)
		{
			java.lang.Exception expr_252 = ByteCodeHelper.MapException<java.lang.Exception>(arg_24D_0, ByteCodeHelper.MapFlags.None);
			if (expr_252 == null)
			{
				throw;
			}
			ex5 = expr_252;
			goto IL_25D;
		}
		goto IL_26F;
		IL_25D:
		x = ex5;
		System.@out.println(x);
		IL_26F:
		System.@out.println();
		System.@out.println("readChar() from file");
		System.@out.println("---------------------------------------------------------------------------");
		java.lang.Exception ex6;
		try
		{
			@in = new In("InTest.txt");
			while (!@in.IsEmpty)
			{
				int c = (int)@in.readChar();
				System.@out.print((char)c);
			}
		}
		catch (System.Exception arg_2C3_0)
		{
			java.lang.Exception expr_2C8 = ByteCodeHelper.MapException<java.lang.Exception>(arg_2C3_0, ByteCodeHelper.MapFlags.None);
			if (expr_2C8 == null)
			{
				throw;
			}
			ex6 = expr_2C8;
			goto IL_2D3;
		}
		goto IL_2E5;
		IL_2D3:
		x = ex6;
		System.@out.println(x);
		IL_2E5:
		System.@out.println();
		System.@out.println();
		System.@out.println("readLine() from absolute OS X / Linux path");
		System.@out.println("---------------------------------------------------------------------------");
		@in = new In("/n/fs/introcs/www/java/stdlib/InTest.txt");
		java.lang.Exception ex7;
		try
		{
			while (!@in.IsEmpty)
			{
				string x2 = @in.readLine();
				System.@out.println(x2);
			}
		}
		catch (System.Exception arg_343_0)
		{
			java.lang.Exception expr_348 = ByteCodeHelper.MapException<java.lang.Exception>(arg_343_0, ByteCodeHelper.MapFlags.None);
			if (expr_348 == null)
			{
				throw;
			}
			ex7 = expr_348;
			goto IL_353;
		}
		goto IL_365;
		IL_353:
		x = ex7;
		System.@out.println(x);
		IL_365:
		System.@out.println();
		System.@out.println("readLine() from absolute Windows path");
		System.@out.println("---------------------------------------------------------------------------");
		java.lang.Exception ex8;
		try
		{
			@in = new In("G:\\www\\introcs\\stdlib\\InTest.txt");
			while (!@in.IsEmpty)
			{
				string x2 = @in.readLine();
				System.@out.println(x2);
			}
			System.@out.println();
		}
		catch (System.Exception arg_3C5_0)
		{
			java.lang.Exception expr_3CA = ByteCodeHelper.MapException<java.lang.Exception>(arg_3C5_0, ByteCodeHelper.MapFlags.None);
			if (expr_3CA == null)
			{
				throw;
			}
			ex8 = expr_3CA;
			goto IL_3D5;
		}
		goto IL_3E7;
		IL_3D5:
		x = ex8;
		System.@out.println(x);
		IL_3E7:
		System.@out.println();
	}
	
	static In()
	{
		In.s_assertionsDisabled = !ClassLiteral<In>.Value.desiredAssertionStatus();
		In.usLocale = new Locale("en", "US");
		In.WHITESPACE_PATTERN = Pattern.compile("\\p{javaWhitespace}+");
		In.EMPTY_PATTERN = Pattern.compile("");
		In.EVERYTHING_PATTERN = Pattern.compile("\\A");
	}
}




























public class Out
{
	private static string charsetName;
//[Modifiers(Modifiers.Private | Modifiers.Static | Modifiers.Final)]
	private static Locale US_LOCALE;
	private PrintWriter @out;
	
	
	
	
	public Out(string str)
	{
		IOException ex;
		try
		{
			FileOutputStream fileOutputStream = new FileOutputStream(str);
			OutputStreamWriter outputStreamWriter = new OutputStreamWriter(fileOutputStream, Out.charsetName);
			this.@out = new PrintWriter(outputStreamWriter, true);
		}
		catch (IOException arg_2D_0)
		{
			ex = ByteCodeHelper.MapException<IOException>(arg_2D_0, ByteCodeHelper.MapFlags.NoRemapping);
			goto IL_37;
		}
		return;
		IL_37:
		IOException this2 = ex;
		Throwable.instancehelper_printStackTrace(this2);
	}
	
	
	public virtual void println(object obj)
	{
		this.@out.println(obj);
	}
	
	
	public virtual void close()
	{
		this.@out.close();
	}
	
	
	public Out(OutputStream os)
	{
		IOException ex;
		try
		{
			OutputStreamWriter outputStreamWriter = new OutputStreamWriter(os, Out.charsetName);
			this.@out = new PrintWriter(outputStreamWriter, true);
		}
		catch (IOException arg_26_0)
		{
			ex = ByteCodeHelper.MapException<IOException>(arg_26_0, ByteCodeHelper.MapFlags.NoRemapping);
			goto IL_30;
		}
		return;
		IL_30:
		IOException this2 = ex;
		Throwable.instancehelper_printStackTrace(this2);
	}
	
	
	public Out() : this(System.@out)
	{
	}
	
	
	public Out(Socket s)
	{
		IOException ex;
		try
		{
			OutputStream outputStream = s.getOutputStream();
			OutputStreamWriter outputStreamWriter = new OutputStreamWriter(outputStream, Out.charsetName);
			this.@out = new PrintWriter(outputStreamWriter, true);
		}
		catch (IOException arg_2D_0)
		{
			ex = ByteCodeHelper.MapException<IOException>(arg_2D_0, ByteCodeHelper.MapFlags.NoRemapping);
			goto IL_37;
		}
		return;
		IL_37:
		IOException this2 = ex;
		Throwable.instancehelper_printStackTrace(this2);
	}
	
	
	public virtual void println()
	{
		this.@out.println();
	}
	
	
	public virtual void println(bool b)
	{
		this.@out.println(b);
	}
	
	
	public virtual void println(char ch)
	{
		this.@out.println(ch);
	}
	
	
	public virtual void println(double d)
	{
		this.@out.println(d);
	}
	
	
	public virtual void println(float f)
	{
		this.@out.println(f);
	}
	
	
	public virtual void println(int i)
	{
		this.@out.println(i);
	}
	
	
	public virtual void println(long l)
	{
		this.@out.println(l);
	}
	
	
	public virtual void println(byte b)
	{
		int x = (int)((sbyte)b);
		this.@out.println(x);
	}
	
	
	public virtual void print()
	{
		this.@out.flush();
	}
	
	
	public virtual void print(object obj)
	{
		this.@out.print(obj);
		this.@out.flush();
	}
	
	
	public virtual void print(bool b)
	{
		this.@out.print(b);
		this.@out.flush();
	}
	
	
	public virtual void print(char ch)
	{
		this.@out.print(ch);
		this.@out.flush();
	}
	
	
	public virtual void print(double d)
	{
		this.@out.print(d);
		this.@out.flush();
	}
	
	
	public virtual void print(float f)
	{
		this.@out.print(f);
		this.@out.flush();
	}
	
	
	public virtual void print(int i)
	{
		this.@out.print(i);
		this.@out.flush();
	}
	
	
	public virtual void print(long l)
	{
		this.@out.print(l);
		this.@out.flush();
	}
	
	
	public virtual void print(byte b)
	{
		int i = (int)((sbyte)b);
		this.@out.print(i);
		this.@out.flush();
	}
	
	
	public virtual void printf(string str, params object[] objarr)
	{
		this.@out.printf(Out.US_LOCALE, str, objarr);
		this.@out.flush();
	}
	
	
	public virtual void printf(Locale l, string str, params object[] objarr)
	{
		this.@out.printf(l, str, objarr);
		this.@out.flush();
	}
	
	
	/**/public static void main(string[] strarr)
	{
		Out @out = new Out();
		@out.println("Test 1");
		@out.close();
		@out = new Out("test.txt");
		@out.println("Test 2");
		@out.close();
	}
	
	static Out()
	{
		Out.charsetName = "UTF-8";
		Out.US_LOCALE = new Locale("en", "US");
	}
}






















using System.ComponentModel;

/*[Implements(new string[]
{
	"java.lang.Comparable"
}), Signature("Ljava/lang/Object;Ljava/lang/Comparable<LPoint2D;>;")]*/
public class Point2D, Comparable
{
	/*[EnclosingMethod("Point2D", null, null), InnerClass(null, Modifiers.Static | Modifiers.Synthetic), Modifiers(Modifiers.Super | Modifiers.Synthetic), SourceFile("Point2D.java")]*/
	
	/*[Implements(new string[]
	{
		"java.util.Comparator"
	}), InnerClass(null, Modifiers.Private), Modifiers(Modifiers.Super), Signature("Ljava/lang/Object;Ljava/util/Comparator<LPoint2D;>;"), SourceFile("Point2D.java")]*/
	internal sealed class Atan2Order, Comparator
	{
//[Modifiers(Modifiers.Final | Modifiers.Synthetic)]
		internal Point2D point2D;
/*		[LineNumberTable(212), Modifiers(Modifiers.Synthetic)]*/
		
		internal Atan2Order(Point2D point2D, Point2D.1) : this(point2D)
		{
		}
		
		
		private Atan2Order(Point2D point2D)
		{
		}
		
		
		public virtual int compare(Point2D point2D, Point2D point2D2)
		{
			double num = Point2D.access_800(this.this$0, point2D);
			double num2 = Point2D.access_800(this.this$0, point2D2);
			if (num < num2)
			{
				return -1;
			}
			if (num > num2)
			{
				return 1;
			}
			return 0;
		}
/*		[LineNumberTable(212), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public virtual int compare(object obj, object obj2)
		{
			return this.compare((Point2D)obj, (Point2D)obj2);
		}
		
		bool Comparator.Object;)Zequals(object obj)
		{
			return java.lang.Object.instancehelper_equals(this, obj);
		}
	}
	/*[Implements(new string[]
	{
		"java.util.Comparator"
	}), InnerClass(null, Modifiers.Private), Modifiers(Modifiers.Super), Signature("Ljava/lang/Object;Ljava/util/Comparator<LPoint2D;>;"), SourceFile("Point2D.java")]*/
	internal sealed class DistanceToOrder, Comparator
	{
//[Modifiers(Modifiers.Final | Modifiers.Synthetic)]
		internal Point2D point2D;
/*		[LineNumberTable(244), Modifiers(Modifiers.Synthetic)]*/
		
		internal DistanceToOrder(Point2D point2D, Point2D.1) : this(point2D)
		{
		}
		
		
		private DistanceToOrder(Point2D point2D)
		{
		}
		
		
		public virtual int compare(Point2D pd, Point2D pd2)
		{
			double num = this.this$0.distanceSquaredTo(pd);
			double num2 = this.this$0.distanceSquaredTo(pd2);
			if (num < num2)
			{
				return -1;
			}
			if (num > num2)
			{
				return 1;
			}
			return 0;
		}
/*		[LineNumberTable(244), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public virtual int compare(object obj, object obj2)
		{
			return this.compare((Point2D)obj, (Point2D)obj2);
		}
		
		bool Comparator.Object;)Zequals(object obj)
		{
			return java.lang.Object.instancehelper_equals(this, obj);
		}
	}
	/*[Implements(new string[]
	{
		"java.util.Comparator"
	}), InnerClass(null, Modifiers.Private), Modifiers(Modifiers.Super), Signature("Ljava/lang/Object;Ljava/util/Comparator<LPoint2D;>;"), SourceFile("Point2D.java")]*/
	internal sealed class PolarOrder, Comparator
	{
//[Modifiers(Modifiers.Final | Modifiers.Synthetic)]
		internal Point2D point2D;
/*		[LineNumberTable(223), Modifiers(Modifiers.Synthetic)]*/
		
		internal PolarOrder(Point2D point2D, Point2D.1) : this(point2D)
		{
		}
		
		
		private PolarOrder(Point2D point2D)
		{
		}
		
		
		public virtual int compare(Point2D point2D, Point2D point2D2)
		{
			double num = Point2D.access_600(point2D) - Point2D.access_600(this.this$0);
			double num2 = Point2D.access_700(point2D) - Point2D.access_700(this.this$0);
			double num3 = Point2D.access_600(point2D2) - Point2D.access_600(this.this$0);
			double num4 = Point2D.access_700(point2D2) - Point2D.access_700(this.this$0);
			if (num2 >= (double)0f && num4 < (double)0f)
			{
				return -1;
			}
			if (num4 >= (double)0f && num2 < (double)0f)
			{
				return 1;
			}
			if (num2 != (double)0f || num4 != (double)0f)
			{
				return -Point2D.ccw(this.this$0, point2D, point2D2);
			}
			if (num >= (double)0f && num3 < (double)0f)
			{
				return -1;
			}
			if (num3 >= (double)0f && num < (double)0f)
			{
				return 1;
			}
			return 0;
		}
/*		[LineNumberTable(223), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public virtual int compare(object obj, object obj2)
		{
			return this.compare((Point2D)obj, (Point2D)obj2);
		}
		
		bool Comparator.Object;)Zequals(object obj)
		{
			return java.lang.Object.instancehelper_equals(this, obj);
		}
	}
	/*[Implements(new string[]
	{
		"java.util.Comparator"
	}), InnerClass(null, Modifiers.Private | Modifiers.Static), Modifiers(Modifiers.Super), Signature("Ljava/lang/Object;Ljava/util/Comparator<LPoint2D;>;"), SourceFile("Point2D.java")]*/
	internal sealed class ROrder, Comparator
	{
/*		[LineNumberTable(202), Modifiers(Modifiers.Synthetic)]*/
		
		internal ROrder(Point2D.1) : this()
		{
		}
		
		
		private ROrder()
		{
		}
		
		
		public virtual int compare(Point2D point2D, Point2D point2D2)
		{
			double num = Point2D.access_600(point2D) * Point2D.access_600(point2D) + Point2D.access_700(point2D) * Point2D.access_700(point2D) - (Point2D.access_600(point2D2) * Point2D.access_600(point2D2) + Point2D.access_700(point2D2) * Point2D.access_700(point2D2));
			if (num < (double)0f)
			{
				return -1;
			}
			if (num > (double)0f)
			{
				return 1;
			}
			return 0;
		}
/*		[LineNumberTable(202), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public virtual int compare(object obj, object obj2)
		{
			return this.compare((Point2D)obj, (Point2D)obj2);
		}
		
		bool Comparator.Object;)Zequals(object obj)
		{
			return java.lang.Object.instancehelper_equals(this, obj);
		}
	}
	/*[Implements(new string[]
	{
		"java.util.Comparator"
	}), InnerClass(null, Modifiers.Private | Modifiers.Static), Modifiers(Modifiers.Super), Signature("Ljava/lang/Object;Ljava/util/Comparator<LPoint2D;>;"), SourceFile("Point2D.java")]*/
	internal sealed class XOrder, Comparator
	{
/*		[LineNumberTable(184), Modifiers(Modifiers.Synthetic)]*/
		
		internal XOrder(Point2D.1) : this()
		{
		}
		
		
		private XOrder()
		{
		}
		
		
		public virtual int compare(Point2D point2D, Point2D point2D2)
		{
			if (Point2D.access_600(point2D) < Point2D.access_600(point2D2))
			{
				return -1;
			}
			if (Point2D.access_600(point2D) > Point2D.access_600(point2D2))
			{
				return 1;
			}
			return 0;
		}
/*		[LineNumberTable(184), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public virtual int compare(object obj, object obj2)
		{
			return this.compare((Point2D)obj, (Point2D)obj2);
		}
		
		bool Comparator.Object;)Zequals(object obj)
		{
			return java.lang.Object.instancehelper_equals(this, obj);
		}
	}
	/*[Implements(new string[]
	{
		"java.util.Comparator"
	}), InnerClass(null, Modifiers.Private | Modifiers.Static), Modifiers(Modifiers.Super), Signature("Ljava/lang/Object;Ljava/util/Comparator<LPoint2D;>;"), SourceFile("Point2D.java")]*/
	internal sealed class YOrder, Comparator
	{
/*		[LineNumberTable(193), Modifiers(Modifiers.Synthetic)]*/
		
		internal YOrder(Point2D.1) : this()
		{
		}
		
		
		private YOrder()
		{
		}
		
		
		public virtual int compare(Point2D point2D, Point2D point2D2)
		{
			if (Point2D.access_700(point2D) < Point2D.access_700(point2D2))
			{
				return -1;
			}
			if (Point2D.access_700(point2D) > Point2D.access_700(point2D2))
			{
				return 1;
			}
			return 0;
		}
/*		[LineNumberTable(193), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public virtual int compare(object obj, object obj2)
		{
			return this.compare((Point2D)obj, (Point2D)obj2);
		}
		
		bool Comparator.Object;)Zequals(object obj)
		{
			return java.lang.Object.instancehelper_equals(this, obj);
		}
	}
//[Signature("Ljava/util/Comparator<LPoint2D;>;")]
	internal static Comparator __X_ORDER;
//[Signature("Ljava/util/Comparator<LPoint2D;>;")]
	internal static Comparator __Y_ORDER;
//[Signature("Ljava/util/Comparator<LPoint2D;>;")]
	internal static Comparator __R_ORDER;
//[Signature("Ljava/util/Comparator<LPoint2D;>;")]
	internal Comparator __POLAR_ORDER;
//[Signature("Ljava/util/Comparator<LPoint2D;>;")]
	internal Comparator __ATAN2_ORDER;
//[Signature("Ljava/util/Comparator<LPoint2D;>;")]
	internal Comparator __DISTANCE_TO_ORDER;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private double x;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private double y;
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Comparator X_ORDER
	{
		
		get
		{
			return Point2D.__X_ORDER;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Comparator Y_ORDER
	{
		
		get
		{
			return Point2D.__Y_ORDER;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Comparator R_ORDER
	{
		
		get
		{
			return Point2D.__R_ORDER;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Final)]
	public Comparator POLAR_ORDER
	{
		
		get
		{
			return this.__POLAR_ORDER;
		}
		
		private set
		{
			this.__POLAR_ORDER = value;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Final)]
	public Comparator ATAN2_ORDER
	{
		
		get
		{
			return this.__ATAN2_ORDER;
		}
		
		private set
		{
			this.__ATAN2_ORDER = value;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Final)]
	public Comparator DISTANCE_TO_ORDER
	{
		
		get
		{
			return this.__DISTANCE_TO_ORDER;
		}
		
		private set
		{
			this.__DISTANCE_TO_ORDER = value;
		}
	}
	
	
	
	
	public override bool equals(object obj)
	{
		if (obj == this)
		{
			return true;
		}
		if (obj == null)
		{
			return false;
		}
		if (obj.GetType() != this.GetType())
		{
			return false;
		}
		Point2D point2D = (Point2D)obj;
		return this.x == point2D.x && this.y == point2D.y;
	}
	public virtual double x()
	{
		return this.x;
	}
	public virtual double y()
	{
		return this.y;
	}
	
	
	public virtual double distanceTo(Point2D pd)
	{
		double num = this.x - pd.x;
		double num2 = this.y - pd.y;
		return java.lang.Math.sqrt(num * num + num2 * num2);
	}
	
	
	public Point2D(double d1, double d2)
	{
		this.__POLAR_ORDER = new Point2D.PolarOrder(this, null);
		this.__ATAN2_ORDER = new Point2D.Atan2Order(this, null);
		this.__DISTANCE_TO_ORDER = new Point2D.DistanceToOrder(this, null);
		if (java.lang.Double.isInfinite(d1) || java.lang.Double.isInfinite(d2))
		{
			string arg_4B_0 = "Coordinates must be finite";
			
			throw new ArgumentException(arg_4B_0);
		}
		if (java.lang.Double.isNaN(d1) || java.lang.Double.isNaN(d2))
		{
			string arg_6D_0 = "Coordinates cannot be NaN";
			
			throw new ArgumentException(arg_6D_0);
		}
		if (d1 == (double)0f)
		{
			d1 = (double)0f;
		}
		if (d2 == (double)0f)
		{
			d2 = (double)0f;
		}
		this.x = d1;
		this.y = d2;
	}
	
	public static double area2(Point2D pd1, Point2D pd2, Point2D pd3)
	{
		return (pd2.x - pd1.x) * (pd3.y - pd1.y) - (pd2.y - pd1.y) * (pd3.x - pd1.x);
	}
	
	public static int ccw(Point2D pd1, Point2D pd2, Point2D pd3)
	{
		double num = (pd2.x - pd1.x) * (pd3.y - pd1.y) - (pd2.y - pd1.y) * (pd3.x - pd1.x);
		if (num < (double)0f)
		{
			return -1;
		}
		if (num > (double)0f)
		{
			return 1;
		}
		return 0;
	}
	
	
	public virtual void draw()
	{
		StdDraw.point(this.x, this.y);
	}
	
	
	private double angleTo(Point2D point2D)
	{
		double num = point2D.x - this.x;
		double num2 = point2D.y - this.y;
		return java.lang.Math.atan2(num2, num);
	}
	
	
	public virtual void drawTo(Point2D pd)
	{
		StdDraw.line(this.x, this.y, pd.x, pd.y);
	}
	
	public virtual int compareTo(Point2D pd)
	{
		if (this.y < pd.y)
		{
			return -1;
		}
		if (this.y > pd.y)
		{
			return 1;
		}
		if (this.x < pd.x)
		{
			return -1;
		}
		if (this.x > pd.x)
		{
			return 1;
		}
		return 0;
	}
	
	
	public virtual double r()
	{
		return java.lang.Math.sqrt(this.x * this.x + this.y * this.y);
	}
	
	
	public virtual double theta()
	{
		return java.lang.Math.atan2(this.y, this.x);
	}
	
	public virtual double distanceSquaredTo(Point2D pd)
	{
		double num = this.x - pd.x;
		double num2 = this.y - pd.y;
		return num * num + num2 * num2;
	}
	
	
	public override string ToString()
	{
		return new StringBuilder().append("(").append(this.x).append(", ").append(this.y).append(")").toString();
	}
	
	
	public override int hashCode()
	{
		int num = java.lang.Double.valueOf(this.x).hashCode();
		int num2 = java.lang.Double.valueOf(this.y).hashCode();
		return 31 * num + num2;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		int num = Integer.parseInt(strarr[0]);
		int num2 = Integer.parseInt(strarr[1]);
		int num3 = Integer.parseInt(strarr[2]);
		StdDraw.setCanvasSize(800, 800);
		StdDraw.setXscale((double)0f, 100.0);
		StdDraw.setYscale((double)0f, 100.0);
		StdDraw.setPenRadius(0.005);
		Point2D[] array = new Point2D[num3];
		for (int i = 0; i < num3; i++)
		{
			int j = StdRandom.uniform(100);
			int num4 = StdRandom.uniform(100);
			array[i] = new Point2D((double)j, (double)num4);
			array[i].draw();
		}
		Point2D point2D = new Point2D((double)num, (double)num2);
		StdDraw.setPenColor(StdDraw.__RED);
		StdDraw.setPenRadius(0.02);
		point2D.draw();
		StdDraw.setPenRadius();
		StdDraw.setPenColor(StdDraw.__BLUE);
		Arrays.sort(array, point2D.__POLAR_ORDER);
		for (int j = 0; j < num3; j++)
		{
			point2D.drawTo(array[j]);
			StdDraw.show(100);
		}
	}
/*	[LineNumberTable(26), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic), EditorBrowsable(EditorBrowsableState.Never)]*/
	
	public virtual int compareTo(object obj)
	{
		return this.CompareTo((Point2D)obj);
	}
/*	[LineNumberTable(26), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
	internal static double access_600(Point2D point2D)
	{
		return point2D.x;
	}
/*	[LineNumberTable(26), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
	internal static double access_700(Point2D point2D)
	{
		return point2D.y;
	}
/*	[LineNumberTable(26), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
	
	internal static double access_800(Point2D point2D, Point2D point2D2)
	{
		return point2D.angleTo(point2D2);
	}
	
	static Point2D()
	{
		Point2D.__X_ORDER = new Point2D.XOrder(null);
		Point2D.__Y_ORDER = new Point2D.YOrder(null);
		Point2D.__R_ORDER = new Point2D.ROrder(null);
	}
	
	int IComparable.Object;)IcompareTo(object obj)
	{
		return this.CompareTo(obj);
	}
}


//[Signature("<Key::Ljava/lang/Comparable<TKey;>;Value:Ljava/lang/Object;>Ljava/lang/Object;")]
public class RedBlackBST
{
	[InnerClass(null, Modifiers.Private), Modifiers(Modifiers.Super), SourceFile("RedBlackBST.java")]
	internal sealed class Node
	{
//[Signature("TKey;")]
		private IComparable key;
//[Signature("TValue;")]
		private object val;
//[Signature("LRedBlackBST<TKey;TValue;>.Node;")]
		private RedBlackBST.Node left;
//[Signature("LRedBlackBST<TKey;TValue;>.Node;")]
		private RedBlackBST.Node right;
		private bool color;
		private int N;
//[Modifiers(Modifiers.Final | Modifiers.Synthetic)]
		internal RedBlackBST redBlackBST;
/*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static bool access_000(RedBlackBST.Node node)
		{
			return node.color;
		}
/*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static int access_100(RedBlackBST.Node node)
		{
			return node.N;
		}
/*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static IComparable access_200(RedBlackBST.Node node)
		{
			return node.key;
		}
/*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static RedBlackBST.Node access_300(RedBlackBST.Node node)
		{
			return node.left;
		}
/*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static RedBlackBST.Node access_400(RedBlackBST.Node node)
		{
			return node.right;
		}
/*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static object access_500(RedBlackBST.Node node)
		{
			return node.val;
		}
/*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static bool access_002(RedBlackBST.Node node, bool result)
		{
			node.color = result;
			return result;
		}
/*		[Signature("(TKey;TValue;ZI)V")]*/
		
		public Node(RedBlackBST redBlackBST, IComparable comparable, object obj, bool flag, int n)
		{
			this.key = comparable;
			this.val = obj;
			this.color = flag;
			this.N = n;
		}
/*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static RedBlackBST.Node access_302(RedBlackBST.Node node, RedBlackBST.Node result)
		{
			node.left = result;
			return result;
		}
/*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static RedBlackBST.Node access_402(RedBlackBST.Node node, RedBlackBST.Node result)
		{
			node.right = result;
			return result;
		}
/*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static object access_502(RedBlackBST.Node node, object result)
		{
			node.val = result;
			return result;
		}
/*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static int access_102(RedBlackBST.Node node, int num)
		{
			node.N = num;
			return num;
		}
/*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static IComparable access_202(RedBlackBST.Node node, IComparable result)
		{
			node.key = result;
			return result;
		}
	}
	private const bool RED = true;
	private const bool BLACK = false;
//[Signature("LRedBlackBST<TKey;TValue;>.Node;")]
	private RedBlackBST.Node root;
//[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
	internal static bool s_assertionsDisabled;
	
	
/*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)I")]*/
	
	private int size(RedBlackBST.Node node)
	{
		if (node == null)
		{
			return 0;
		}
		return RedBlackBST.Node.access_100(node);
	}
/*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;TKey;)TValue;")]*/
	
	private object get(RedBlackBST.Node node, IComparable o)
	{
		while (node != null)
		{
			int num = Comparable.__Helper.CompareTo(o, RedBlackBST.Node.access_200(node));
			if (num < 0)
			{
				node = RedBlackBST.Node.access_300(node);
			}
			else
			{
				if (num <= 0)
				{
					return RedBlackBST.Node.access_500(node);
				}
				node = RedBlackBST.Node.access_400(node);
			}
		}
		return null;
	}
/*	[LineNumberTable(85), Signature("(TKey;)TValue;")]*/
	
	public virtual object get(IComparable c)
	{
		return this.get(this.root, c);
	}
/*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;TKey;TValue;)LRedBlackBST<TKey;TValue;>.Node;")]*/
	
	private RedBlackBST.Node put(RedBlackBST.Node node, IComparable comparable, object obj)
	{
		if (node == null)
		{
			return new RedBlackBST.Node(this, comparable, obj, true, 1);
		}
		int num = Comparable.__Helper.CompareTo(comparable, RedBlackBST.Node.access_200(node));
		if (num < 0)
		{
			RedBlackBST.Node.access_302(node, this.put(RedBlackBST.Node.access_300(node), comparable, obj));
		}
		else if (num > 0)
		{
			RedBlackBST.Node.access_402(node, this.put(RedBlackBST.Node.access_400(node), comparable, obj));
		}
		else
		{
			RedBlackBST.Node.access_502(node, obj);
		}
		if (this.isRed(RedBlackBST.Node.access_400(node)) && !this.isRed(RedBlackBST.Node.access_300(node)))
		{
			node = this.rotateLeft(node);
		}
		if (this.isRed(RedBlackBST.Node.access_300(node)) && this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_300(node))))
		{
			node = this.rotateRight(node);
		}
		if (this.isRed(RedBlackBST.Node.access_300(node)) && this.isRed(RedBlackBST.Node.access_400(node)))
		{
			this.flipColors(node);
		}
		RedBlackBST.Node.access_102(node, this.size(RedBlackBST.Node.access_300(node)) + this.size(RedBlackBST.Node.access_400(node)) + 1);
		return node;
	}
	
	
	private bool check()
	{
		if (!this.isBST())
		{
			StdOut.println("Not in symmetric order");
		}
		if (!this.isSizeConsistent())
		{
			StdOut.println("Subtree counts not consistent");
		}
		if (!this.isRankConsistent())
		{
			StdOut.println("Ranks not consistent");
		}
		if (!this.is23())
		{
			StdOut.println("Not a 2-3 tree");
		}
		if (!this.isBalanced())
		{
			StdOut.println("Not balanced");
		}
		return this.isBST() && this.isSizeConsistent() && this.isRankConsistent() && this.is23() && this.isBalanced();
	}
/*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)Z")]*/
	
	private bool isRed(RedBlackBST.Node node)
	{
		return node != null && RedBlackBST.Node.access_000(node);
	}
/*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)LRedBlackBST<TKey;TValue;>.Node;")]*/
	
	private RedBlackBST.Node rotateLeft(RedBlackBST.Node node)
	{
		if (!RedBlackBST.s_assertionsDisabled && (node == null || !this.isRed(RedBlackBST.Node.access_400(node))))
		{
			
			throw new AssertionError();
		}
		RedBlackBST.Node node2 = RedBlackBST.Node.access_400(node);
		RedBlackBST.Node.access_402(node, RedBlackBST.Node.access_300(node2));
		RedBlackBST.Node.access_302(node2, node);
		RedBlackBST.Node.access_002(node2, RedBlackBST.Node.access_000(RedBlackBST.Node.access_300(node2)));
		RedBlackBST.Node.access_002(RedBlackBST.Node.access_300(node2), true);
		RedBlackBST.Node.access_102(node2, RedBlackBST.Node.access_100(node));
		RedBlackBST.Node.access_102(node, this.size(RedBlackBST.Node.access_300(node)) + this.size(RedBlackBST.Node.access_400(node)) + 1);
		return node2;
	}
/*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)LRedBlackBST<TKey;TValue;>.Node;")]*/
	
	private RedBlackBST.Node rotateRight(RedBlackBST.Node node)
	{
		if (!RedBlackBST.s_assertionsDisabled && (node == null || !this.isRed(RedBlackBST.Node.access_300(node))))
		{
			
			throw new AssertionError();
		}
		RedBlackBST.Node node2 = RedBlackBST.Node.access_300(node);
		RedBlackBST.Node.access_302(node, RedBlackBST.Node.access_400(node2));
		RedBlackBST.Node.access_402(node2, node);
		RedBlackBST.Node.access_002(node2, RedBlackBST.Node.access_000(RedBlackBST.Node.access_400(node2)));
		RedBlackBST.Node.access_002(RedBlackBST.Node.access_400(node2), true);
		RedBlackBST.Node.access_102(node2, RedBlackBST.Node.access_100(node));
		RedBlackBST.Node.access_102(node, this.size(RedBlackBST.Node.access_300(node)) + this.size(RedBlackBST.Node.access_400(node)) + 1);
		return node2;
	}
/*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)V")]*/
	
	private void flipColors(RedBlackBST.Node node)
	{
		if (!RedBlackBST.s_assertionsDisabled && (node == null || RedBlackBST.Node.access_300(node) == null || RedBlackBST.Node.access_400(node) == null))
		{
			
			throw new AssertionError();
		}
		if (!RedBlackBST.s_assertionsDisabled && (this.isRed(node) || !this.isRed(RedBlackBST.Node.access_300(node)) || !this.isRed(RedBlackBST.Node.access_400(node))) && (!this.isRed(node) || this.isRed(RedBlackBST.Node.access_300(node)) || this.isRed(RedBlackBST.Node.access_400(node))))
		{
			
			throw new AssertionError();
		}
		RedBlackBST.Node.access_002(node, !RedBlackBST.Node.access_000(node));
		RedBlackBST.Node.access_002(RedBlackBST.Node.access_300(node), !RedBlackBST.Node.access_000(RedBlackBST.Node.access_300(node)));
		RedBlackBST.Node.access_002(RedBlackBST.Node.access_400(node), !RedBlackBST.Node.access_000(RedBlackBST.Node.access_400(node)));
	}
	public virtual bool IsEmpty
	{
		return this.root == null;
	}
/*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)LRedBlackBST<TKey;TValue;>.Node;")]*/
	
	private RedBlackBST.Node deleteMin(RedBlackBST.Node node)
	{
		if (RedBlackBST.Node.access_300(node) == null)
		{
			return null;
		}
		if (!this.isRed(RedBlackBST.Node.access_300(node)) && !this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_300(node))))
		{
			node = this.moveRedLeft(node);
		}
		RedBlackBST.Node.access_302(node, this.deleteMin(RedBlackBST.Node.access_300(node)));
		return this.balance(node);
	}
/*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)LRedBlackBST<TKey;TValue;>.Node;")]*/
	
	private RedBlackBST.Node moveRedLeft(RedBlackBST.Node node)
	{
		if (!RedBlackBST.s_assertionsDisabled && node == null)
		{
			
			throw new AssertionError();
		}
		if (!RedBlackBST.s_assertionsDisabled && (!this.isRed(node) || this.isRed(RedBlackBST.Node.access_300(node)) || this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_300(node)))))
		{
			
			throw new AssertionError();
		}
		this.flipColors(node);
		if (this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_400(node))))
		{
			RedBlackBST.Node.access_402(node, this.rotateRight(RedBlackBST.Node.access_400(node)));
			node = this.rotateLeft(node);
		}
		return node;
	}
/*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)LRedBlackBST<TKey;TValue;>.Node;")]*/
	
	private RedBlackBST.Node balance(RedBlackBST.Node node)
	{
		if (!RedBlackBST.s_assertionsDisabled && node == null)
		{
			
			throw new AssertionError();
		}
		if (this.isRed(RedBlackBST.Node.access_400(node)))
		{
			node = this.rotateLeft(node);
		}
		if (this.isRed(RedBlackBST.Node.access_300(node)) && this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_300(node))))
		{
			node = this.rotateRight(node);
		}
		if (this.isRed(RedBlackBST.Node.access_300(node)) && this.isRed(RedBlackBST.Node.access_400(node)))
		{
			this.flipColors(node);
		}
		RedBlackBST.Node.access_102(node, this.size(RedBlackBST.Node.access_300(node)) + this.size(RedBlackBST.Node.access_400(node)) + 1);
		return node;
	}
/*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)LRedBlackBST<TKey;TValue;>.Node;")]*/
	
	private RedBlackBST.Node deleteMax(RedBlackBST.Node node)
	{
		if (this.isRed(RedBlackBST.Node.access_300(node)))
		{
			node = this.rotateRight(node);
		}
		if (RedBlackBST.Node.access_400(node) == null)
		{
			return null;
		}
		if (!this.isRed(RedBlackBST.Node.access_400(node)) && !this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_400(node))))
		{
			node = this.moveRedRight(node);
		}
		RedBlackBST.Node.access_402(node, this.deleteMax(RedBlackBST.Node.access_400(node)));
		return this.balance(node);
	}
/*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)LRedBlackBST<TKey;TValue;>.Node;")]*/
	
	private RedBlackBST.Node moveRedRight(RedBlackBST.Node node)
	{
		if (!RedBlackBST.s_assertionsDisabled && node == null)
		{
			
			throw new AssertionError();
		}
		if (!RedBlackBST.s_assertionsDisabled && (!this.isRed(node) || this.isRed(RedBlackBST.Node.access_400(node)) || this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_400(node)))))
		{
			
			throw new AssertionError();
		}
		this.flipColors(node);
		if (this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_300(node))))
		{
			node = this.rotateRight(node);
		}
		return node;
	}
/*	[LineNumberTable(100), Signature("(TKey;)Z")]*/
	
	public virtual bool contains(IComparable c)
	{
		return this.get(c) != null;
	}
/*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;TKey;)LRedBlackBST<TKey;TValue;>.Node;")]*/
	
	private RedBlackBST.Node delete(RedBlackBST.Node node, IComparable comparable)
	{
		if (!RedBlackBST.s_assertionsDisabled && !this.contains(node, comparable))
		{
			
			throw new AssertionError();
		}
		if (Comparable.__Helper.CompareTo(comparable, RedBlackBST.Node.access_200(node)) < 0)
		{
			if (!this.isRed(RedBlackBST.Node.access_300(node)) && !this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_300(node))))
			{
				node = this.moveRedLeft(node);
			}
			RedBlackBST.Node.access_302(node, this.delete(RedBlackBST.Node.access_300(node), comparable));
		}
		else
		{
			if (this.isRed(RedBlackBST.Node.access_300(node)))
			{
				node = this.rotateRight(node);
			}
			if (Comparable.__Helper.CompareTo(comparable, RedBlackBST.Node.access_200(node)) == 0 && RedBlackBST.Node.access_400(node) == null)
			{
				return null;
			}
			if (!this.isRed(RedBlackBST.Node.access_400(node)) && !this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_400(node))))
			{
				node = this.moveRedRight(node);
			}
			if (Comparable.__Helper.CompareTo(comparable, RedBlackBST.Node.access_200(node)) == 0)
			{
				RedBlackBST.Node node2 = this.min(RedBlackBST.Node.access_400(node));
				RedBlackBST.Node.access_202(node, RedBlackBST.Node.access_200(node2));
				RedBlackBST.Node.access_502(node, RedBlackBST.Node.access_500(node2));
				RedBlackBST.Node.access_402(node, this.deleteMin(RedBlackBST.Node.access_400(node)));
			}
			else
			{
				RedBlackBST.Node.access_402(node, this.delete(RedBlackBST.Node.access_400(node), comparable));
			}
		}
		return this.balance(node);
	}
/*	[LineNumberTable(105), Signature("(LRedBlackBST<TKey;TValue;>.Node;TKey;)Z")]*/
	
	private bool contains(RedBlackBST.Node node, IComparable comparable)
	{
		return this.get(node, comparable) != null;
	}
/*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)LRedBlackBST<TKey;TValue;>.Node;")]*/
	
	private RedBlackBST.Node min(RedBlackBST.Node node)
	{
		if (!RedBlackBST.s_assertionsDisabled && node == null)
		{
			
			throw new AssertionError();
		}
		if (RedBlackBST.Node.access_300(node) == null)
		{
			return node;
		}
		return this.min(RedBlackBST.Node.access_300(node));
	}
/*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)I")]*/
	
	private int height(RedBlackBST.Node node)
	{
		if (node == null)
		{
			return -1;
		}
		return 1 + java.lang.Math.max(this.height(RedBlackBST.Node.access_300(node)), this.height(RedBlackBST.Node.access_400(node)));
	}
/*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)LRedBlackBST<TKey;TValue;>.Node;")]*/
	
	private RedBlackBST.Node max(RedBlackBST.Node node)
	{
		if (!RedBlackBST.s_assertionsDisabled && node == null)
		{
			
			throw new AssertionError();
		}
		if (RedBlackBST.Node.access_400(node) == null)
		{
			return node;
		}
		return this.max(RedBlackBST.Node.access_400(node));
	}
/*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;TKey;)LRedBlackBST<TKey;TValue;>.Node;")]*/
	
	private RedBlackBST.Node floor(RedBlackBST.Node node, IComparable comparable)
	{
		if (node == null)
		{
			return null;
		}
		int num = Comparable.__Helper.CompareTo(comparable, RedBlackBST.Node.access_200(node));
		if (num == 0)
		{
			return node;
		}
		if (num < 0)
		{
			return this.floor(RedBlackBST.Node.access_300(node), comparable);
		}
		RedBlackBST.Node node2 = this.floor(RedBlackBST.Node.access_400(node), comparable);
		if (node2 != null)
		{
			return node2;
		}
		return node;
	}
/*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;TKey;)LRedBlackBST<TKey;TValue;>.Node;")]*/
	
	private RedBlackBST.Node ceiling(RedBlackBST.Node node, IComparable comparable)
	{
		if (node == null)
		{
			return null;
		}
		int num = Comparable.__Helper.CompareTo(comparable, RedBlackBST.Node.access_200(node));
		if (num == 0)
		{
			return node;
		}
		if (num > 0)
		{
			return this.ceiling(RedBlackBST.Node.access_400(node), comparable);
		}
		RedBlackBST.Node node2 = this.ceiling(RedBlackBST.Node.access_300(node), comparable);
		if (node2 != null)
		{
			return node2;
		}
		return node;
	}
	
	
	public virtual int Size
	{
		return this.size(this.root);
	}
/*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;I)LRedBlackBST<TKey;TValue;>.Node;")]*/
	
	private RedBlackBST.Node select(RedBlackBST.Node node, int num)
	{
		if (!RedBlackBST.s_assertionsDisabled && node == null)
		{
			
			throw new AssertionError();
		}
		if (!RedBlackBST.s_assertionsDisabled && (num < 0 || num >= this.size(node)))
		{
			
			throw new AssertionError();
		}
		int num2 = this.size(RedBlackBST.Node.access_300(node));
		if (num2 > num)
		{
			return this.select(RedBlackBST.Node.access_300(node), num);
		}
		if (num2 < num)
		{
			return this.select(RedBlackBST.Node.access_400(node), num - num2 - 1);
		}
		return node;
	}
/*	[Signature("(TKey;LRedBlackBST<TKey;TValue;>.Node;)I")]*/
	
	private int rank(IComparable comparable, RedBlackBST.Node node)
	{
		if (node == null)
		{
			return 0;
		}
		int num = Comparable.__Helper.CompareTo(comparable, RedBlackBST.Node.access_200(node));
		if (num < 0)
		{
			return this.rank(comparable, RedBlackBST.Node.access_300(node));
		}
		if (num > 0)
		{
			return 1 + this.size(RedBlackBST.Node.access_300(node)) + this.rank(comparable, RedBlackBST.Node.access_400(node));
		}
		return this.size(RedBlackBST.Node.access_300(node));
	}
/*	[Signature("()TKey;")]*/
	
	public virtual IComparable Min
	{
		if (this.IsEmpty)
		{
			return null;
		}
		return RedBlackBST.Node.access_200(this.min(this.root));
	}
/*	[Signature("()TKey;")]*/
	
	public virtual IComparable Max
	{
		if (this.IsEmpty)
		{
			return null;
		}
		return RedBlackBST.Node.access_200(this.max(this.root));
	}
/*	[Signature("(TKey;TKey;)Ljava/lang/Iterable<TKey;>;")]*/
	
	public virtual Iterable keys(IComparable c1, IComparable c2)
	{
		Queue queue = new Queue();
		this.keys(this.root, queue, c1, c2);
		return queue;
	}
/*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;LQueue<TKey;>;TKey;TKey;)V")]*/
	
	private void keys(RedBlackBST.Node node, Queue queue, IComparable comparable, IComparable comparable2)
	{
		if (node == null)
		{
			return;
		}
		int num = Comparable.__Helper.CompareTo(comparable, RedBlackBST.Node.access_200(node));
		int num2 = Comparable.__Helper.CompareTo(comparable2, RedBlackBST.Node.access_200(node));
		if (num < 0)
		{
			this.keys(RedBlackBST.Node.access_300(node), queue, comparable, comparable2);
		}
		if (num <= 0 && num2 >= 0)
		{
			queue.enqueue(RedBlackBST.Node.access_200(node));
		}
		if (num2 > 0)
		{
			this.keys(RedBlackBST.Node.access_400(node), queue, comparable, comparable2);
		}
	}
/*	[LineNumberTable(419), Signature("(TKey;)I")]*/
	
	public virtual int rank(IComparable c)
	{
		return this.rank(c, this.root);
	}
	
	
	private bool isBST()
	{
		return this.isBST(this.root, null, null);
	}
	
	
	private bool isSizeConsistent()
	{
		return this.isSizeConsistent(this.root);
	}
	
	
	private bool isRankConsistent()
	{
		for (int i = 0; i < this.Size; i++)
		{
			if (i != this.rank(this.select(i)))
			{
				return false;
			}
		}
		Iterator iterator = this.keys().iterator();
		while (iterator.hasNext())
		{
			IComparable comparable = (IComparable)iterator.next();
			if (Comparable.__Helper.CompareTo(comparable, this.select(this.rank(comparable))) != 0)
			{
				return false;
			}
		}
		return true;
	}
	
	
	private bool is23()
	{
		return this.is23(this.root);
	}
	
	
	private bool isBalanced()
	{
		int num = 0;
		for (RedBlackBST.Node node = this.root; node != null; node = RedBlackBST.Node.access_300(node))
		{
			if (!this.isRed(node))
			{
				num++;
			}
		}
		return this.isBalanced(this.root, num);
	}
/*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;TKey;TKey;)Z")]*/
	
	private bool isBST(RedBlackBST.Node node, IComparable comparable, IComparable comparable2)
	{
		return node == null || ((comparable == null || Comparable.__Helper.CompareTo(RedBlackBST.Node.access_200(node), comparable) > 0) && (comparable2 == null || Comparable.__Helper.CompareTo(RedBlackBST.Node.access_200(node), comparable2) < 0) && (this.isBST(RedBlackBST.Node.access_300(node), comparable, RedBlackBST.Node.access_200(node)) && this.isBST(RedBlackBST.Node.access_400(node), RedBlackBST.Node.access_200(node), comparable2)));
	}
/*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)Z")]*/
	
	private bool isSizeConsistent(RedBlackBST.Node node)
	{
		return node == null || (RedBlackBST.Node.access_100(node) == this.size(RedBlackBST.Node.access_300(node)) + this.size(RedBlackBST.Node.access_400(node)) + 1 && (this.isSizeConsistent(RedBlackBST.Node.access_300(node)) && this.isSizeConsistent(RedBlackBST.Node.access_400(node))));
	}
/*	[Signature("(I)TKey;")]*/
	
	public virtual IComparable select(int i)
	{
		if (i < 0 || i >= this.Size)
		{
			return null;
		}
		RedBlackBST.Node node = this.select(this.root, i);
		return RedBlackBST.Node.access_200(node);
	}
/*	[LineNumberTable(437), Signature("()Ljava/lang/Iterable<TKey;>;")]*/
	
	public virtual Iterable keys()
	{
		return this.keys(this.Min, this.Max);
	}
/*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)Z")]*/
	
	private bool is23(RedBlackBST.Node node)
	{
		return node == null || (!this.isRed(RedBlackBST.Node.access_400(node)) && (node == this.root || !this.isRed(node) || !this.isRed(RedBlackBST.Node.access_300(node))) && (this.is23(RedBlackBST.Node.access_300(node)) && this.is23(RedBlackBST.Node.access_400(node))));
	}
/*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;I)Z")]*/
	
	private bool isBalanced(RedBlackBST.Node node, int num)
	{
		if (node == null)
		{
			return num == 0;
		}
		if (!this.isRed(node))
		{
			num += -1;
		}
		return this.isBalanced(RedBlackBST.Node.access_300(node), num) && this.isBalanced(RedBlackBST.Node.access_400(node), num);
	}
	
	
	public RedBlackBST()
	{
	}
/*	[Signature("(TKey;TValue;)V")]*/
	
	public virtual void put(IComparable c, object obj)
	{
		this.root = this.put(this.root, c, obj);
		RedBlackBST.Node.access_002(this.root, false);
		if (!RedBlackBST.s_assertionsDisabled && !this.check())
		{
			
			throw new AssertionError();
		}
	}
	
	
	public virtual void deleteMin()
	{
		if (this.IsEmpty)
		{
			string arg_12_0 = "BST underflow";
			
			throw new InvalidOperationException(arg_12_0);
		}
		if (!this.isRed(RedBlackBST.Node.access_300(this.root)) && !this.isRed(RedBlackBST.Node.access_400(this.root)))
		{
			RedBlackBST.Node.access_002(this.root, true);
		}
		this.root = this.deleteMin(this.root);
		if (!this.IsEmpty)
		{
			RedBlackBST.Node.access_002(this.root, false);
		}
		if (!RedBlackBST.s_assertionsDisabled && !this.check())
		{
			
			throw new AssertionError();
		}
	}
	
	
	public virtual void deleteMax()
	{
		if (this.IsEmpty)
		{
			string arg_12_0 = "BST underflow";
			
			throw new InvalidOperationException(arg_12_0);
		}
		if (!this.isRed(RedBlackBST.Node.access_300(this.root)) && !this.isRed(RedBlackBST.Node.access_400(this.root)))
		{
			RedBlackBST.Node.access_002(this.root, true);
		}
		this.root = this.deleteMax(this.root);
		if (!this.IsEmpty)
		{
			RedBlackBST.Node.access_002(this.root, false);
		}
		if (!RedBlackBST.s_assertionsDisabled && !this.check())
		{
			
			throw new AssertionError();
		}
	}
/*	[Signature("(TKey;)V")]*/
	
	public virtual void delete(IComparable c)
	{
		if (!this.contains(c))
		{
			System.err.println(new StringBuilder().append("symbol table does not contain ").append(c).toString());
			return;
		}
		if (!this.isRed(RedBlackBST.Node.access_300(this.root)) && !this.isRed(RedBlackBST.Node.access_400(this.root)))
		{
			RedBlackBST.Node.access_002(this.root, true);
		}
		this.root = this.delete(this.root, c);
		if (!this.IsEmpty)
		{
			RedBlackBST.Node.access_002(this.root, false);
		}
		if (!RedBlackBST.s_assertionsDisabled && !this.check())
		{
			
			throw new AssertionError();
		}
	}
	
	
	public virtual int height()
	{
		return this.height(this.root);
	}
/*	[Signature("(TKey;)TKey;")]*/
	
	public virtual IComparable floor(IComparable c)
	{
		RedBlackBST.Node node = this.floor(this.root, c);
		if (node == null)
		{
			return null;
		}
		return RedBlackBST.Node.access_200(node);
	}
/*	[Signature("(TKey;)TKey;")]*/
	
	public virtual IComparable ceiling(IComparable c)
	{
		RedBlackBST.Node node = this.ceiling(this.root, c);
		if (node == null)
		{
			return null;
		}
		return RedBlackBST.Node.access_200(node);
	}
/*	[Signature("(TKey;TKey;)I")]*/
	
	public virtual int size(IComparable c1, IComparable c2)
	{
		if (Comparable.__Helper.CompareTo(c1, c2) > 0)
		{
			return 0;
		}
		if (this.contains(c2))
		{
			return this.rank(c2) - this.rank(c1) + 1;
		}
		return this.rank(c2) - this.rank(c1);
	}
	
	
	/**/public static void main(string[] strarr)
	{
		RedBlackBST redBlackBST = new RedBlackBST();
		int num = 0;
		while (!StdIn.IsEmpty)
		{
			string text = StdIn.readString();
			redBlackBST.put(text, Integer.valueOf(num));
			num++;
		}
		Iterator iterator = redBlackBST.keys().iterator();
		while (iterator.hasNext())
		{
			string text = (string)iterator.next();
			StdOut.println(new StringBuilder().append(text).append(" ").append(redBlackBST.get(text)).toString());
		}
		StdOut.println();
	}
	
	static RedBlackBST()
	{
		RedBlackBST.s_assertionsDisabled = !ClassLiteral<RedBlackBST>.Value.desiredAssertionStatus();
	}
}


public class RunLength
{
	private const int R = 256;
	private const int lgR = 8;
	
	
	public static void compress()
	{
		int num = 0;
		int num2 = 0;
		while (!BinaryStdIn.IsEmpty)
		{
			int num3 = BinaryStdIn.readBoolean() ? 1 : 0;
			if (num3 != num2)
			{
				BinaryStdOut.write((char)num, 8);
				num = 1;
				num2 = ((num2 != 0) ? 0 : 1);
			}
			else
			{
				if (num == 255)
				{
					BinaryStdOut.write((char)num, 8);
					num = 0;
					BinaryStdOut.write((char)num, 8);
				}
				num = (int)((ushort)(num + 1));
			}
		}
		BinaryStdOut.write((char)num, 8);
		BinaryStdOut.close();
	}
	
	
	public static void expand()
	{
		int num = 0;
		while (!BinaryStdIn.IsEmpty)
		{
			int num2 = BinaryStdIn.readInt(8);
			for (int i = 0; i < num2; i++)
			{
				BinaryStdOut.write(num != 0);
			}
			num = ((num != 0) ? 0 : 1);
		}
		BinaryStdOut.close();
	}
	
	
	public RunLength()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		if (java.lang.String.instancehelper_equals(strarr[0], "-"))
		{
			RunLength.compress();
		}
		else
		{
			if (!java.lang.String.instancehelper_equals(strarr[0], "+"))
			{
				string arg_36_0 = "Illegal command line argument";
				
				throw new ArgumentException(arg_36_0);
			}
			RunLength.expand();
		}
	}
}






public class Simplex
{
	private const double EPSILON = 1E-10;
	private double[][] a;
	private int M;
	private int N;
	private int[] basis;
//[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
	internal static bool s_assertionsDisabled;
	
	
	
	
	private void solve()
	{
		while (true)
		{
			int num = this.bland();
			if (num == -1)
			{
				break;
			}
			int num2 = this.minRatioRule(num);
			if (num2 == -1)
			{
				goto Block_1;
			}
			this.pivot(num2, num);
			this.basis[num2] = num;
		}
		return;
		Block_1:
		string arg_23_0 = "Linear program is unbounded";
		
		throw new java.lang.ArithmeticException(arg_23_0);
	}
	
	
	private bool check(double[][] array, double[] array2, double[] array3)
	{
		return this.isPrimalFeasible(array, array2) && this.isDualFeasible(array, array3) && this.isOptimal(array2, array3);
	}
	
	private int bland()
	{
		for (int i = 0; i < this.M + this.N; i++)
		{
			if (this.a[this.M][i] > (double)0f)
			{
				return i;
			}
		}
		return -1;
	}
	
	private int minRatioRule(int num)
	{
		int num2 = -1;
		for (int i = 0; i < this.M; i++)
		{
			if (this.a[i][num] > (double)0f)
			{
				if (num2 == -1)
				{
					num2 = i;
				}
				else if (this.a[i][this.M + this.N] / this.a[i][num] < this.a[num2][this.M + this.N] / this.a[num2][num])
				{
					num2 = i;
				}
			}
		}
		return num2;
	}
	
	private void pivot(int num, int num2)
	{
		for (int i = 0; i <= this.M; i++)
		{
			for (int j = 0; j <= this.M + this.N; j++)
			{
				if (i != num && j != num2)
				{
					double[] arg_32_0 = this.a[i];
					int num3 = j;
					double[] array = arg_32_0;
					array[num3] -= this.a[num][j] * this.a[i][num2] / this.a[num][num2];
				}
			}
		}
		for (int i = 0; i <= this.M; i++)
		{
			if (i != num)
			{
				this.a[i][num2] = (double)0f;
			}
		}
		for (int i = 0; i <= this.M + this.N; i++)
		{
			if (i != num2)
			{
				double[] arg_B1_0 = this.a[num];
				int num3 = i;
				double[] array = arg_B1_0;
				array[num3] /= this.a[num][num2];
			}
		}
		this.a[num][num2] = (double)1f;
	}
	
	public virtual double[] primal()
	{
		double[] array = new double[this.N];
		for (int i = 0; i < this.M; i++)
		{
			if (this.basis[i] < this.N)
			{
				array[this.basis[i]] = this.a[i][this.M + this.N];
			}
		}
		return array;
	}
	
	public virtual double[] dual()
	{
		double[] array = new double[this.M];
		for (int i = 0; i < this.M; i++)
		{
			array[i] = -this.a[this.M][this.N + i];
		}
		return array;
	}
	
	public virtual double value()
	{
		return -this.a[this.M][this.M + this.N];
	}
	
	
	private bool isPrimalFeasible(double[][] array, double[] array2)
	{
		double[] array3 = this.primal();
		for (int i = 0; i < array3.Length; i++)
		{
			if (array3[i] < (double)0f)
			{
				StdOut.println(new StringBuilder().append("x[").append(i).append("] = ").append(array3[i]).append(" is negative").toString());
				return false;
			}
		}
		for (int i = 0; i < this.M; i++)
		{
			double num = (double)0f;
			for (int j = 0; j < this.N; j++)
			{
				num += array[i][j] * array3[j];
			}
			if (num > array2[i] + 1E-10)
			{
				StdOut.println("not primal feasible");
				StdOut.println(new StringBuilder().append("b[").append(i).append("] = ").append(array2[i]).append(", sum = ").append(num).toString());
				return false;
			}
		}
		return true;
	}
	
	
	private bool isDualFeasible(double[][] array, double[] array2)
	{
		double[] array3 = this.dual();
		for (int i = 0; i < array3.Length; i++)
		{
			if (array3[i] < (double)0f)
			{
				StdOut.println(new StringBuilder().append("y[").append(i).append("] = ").append(array3[i]).append(" is negative").toString());
				return false;
			}
		}
		for (int i = 0; i < this.N; i++)
		{
			double num = (double)0f;
			for (int j = 0; j < this.M; j++)
			{
				num += array[j][i] * array3[j];
			}
			if (num < array2[i] - 1E-10)
			{
				StdOut.println("not dual feasible");
				StdOut.println(new StringBuilder().append("c[").append(i).append("] = ").append(array2[i]).append(", sum = ").append(num).toString());
				return false;
			}
		}
		return true;
	}
	
	
	private bool isOptimal(double[] array, double[] array2)
	{
		double[] array3 = this.primal();
		double[] array4 = this.dual();
		double num = this.value();
		double num2 = (double)0f;
		for (int i = 0; i < array3.Length; i++)
		{
			num2 += array2[i] * array3[i];
		}
		double num3 = (double)0f;
		for (int j = 0; j < array4.Length; j++)
		{
			num3 += array4[j] * array[j];
		}
		if (java.lang.Math.abs(num - num2) > 1E-10 || java.lang.Math.abs(num - num3) > 1E-10)
		{
			StdOut.println(new StringBuilder().append("value = ").append(num).append(", cx = ").append(num2).append(", yb = ").append(num3).toString());
			return false;
		}
		return true;
	}
	
	
	public Simplex(double[][] darr1, double[] darr2, double[] darr3)
	{
		this.M = darr2.Length;
		this.N = darr3.Length;
		int arg_3C_0 = this.M + 1;
		int arg_37_0 = this.N + this.M + 1;
		int[] array = new int[2];
		int num = arg_37_0;
		array[1] = num;
		num = arg_3C_0;
		array[0] = num;
		this.a = (double[][])ByteCodeHelper.multianewarray(typeof(double[][]).TypeHandle, array);
		for (int i = 0; i < this.M; i++)
		{
			for (int j = 0; j < this.N; j++)
			{
				this.a[i][j] = darr1[i][j];
			}
		}
		for (int i = 0; i < this.M; i++)
		{
			this.a[i][this.N + i] = (double)1f;
		}
		for (int i = 0; i < this.N; i++)
		{
			this.a[this.M][i] = darr3[i];
		}
		for (int i = 0; i < this.M; i++)
		{
			this.a[i][this.M + this.N] = darr2[i];
		}
		this.basis = new int[this.M];
		for (int i = 0; i < this.M; i++)
		{
			this.basis[i] = this.N + i;
		}
		this.solve();
		if (!Simplex.s_assertionsDisabled && !this.check(darr1, darr2, darr3))
		{
			
			throw new AssertionError();
		}
	}
	
	
	public static void test(double[][] darr1, double[] darr2, double[] darr3)
	{
		Simplex simplex = new Simplex(darr1, darr2, darr3);
		StdOut.println(new StringBuilder().append("value = ").append(simplex.value()).toString());
		double[] array = simplex.primal();
		for (int i = 0; i < array.Length; i++)
		{
			StdOut.println(new StringBuilder().append("x[").append(i).append("] = ").append(array[i]).toString());
		}
		double[] array2 = simplex.dual();
		for (int j = 0; j < array2.Length; j++)
		{
			StdOut.println(new StringBuilder().append("y[").append(j).append("] = ").append(array2[j]).toString());
		}
	}
	
	
	public static void test1()
	{
		double[][] darr = new double[][]
		{
			new double[]
			{
				-1.0,
				(double)1f,
				(double)0f
			},
			new double[]
			{
				(double)1f,
				4.0,
				(double)0f
			},
			new double[]
			{
				2.0,
				(double)1f,
				(double)0f
			},
			new double[]
			{
				3.0,
				-4.0,
				(double)0f
			},
			new double[]
			{
				(double)0f,
				(double)0f,
				(double)1f
			}
		};
		double[] darr2 = new double[]
		{
			(double)1f,
			(double)1f,
			(double)1f
		};
		double[] darr3 = new double[]
		{
			5.0,
			45.0,
			27.0,
			24.0,
			4.0
		};
		Simplex.test(darr, darr3, darr2);
	}
	
	
	public static void test2()
	{
		double[] darr = new double[]
		{
			13.0,
			23.0
		};
		double[] darr2 = new double[]
		{
			480.0,
			160.0,
			1190.0
		};
		double[][] darr3 = new double[][]
		{
			new double[]
			{
				5.0,
				15.0
			},
			new double[]
			{
				4.0,
				4.0
			},
			new double[]
			{
				35.0,
				20.0
			}
		};
		Simplex.test(darr3, darr2, darr);
	}
	
	
	public static void test3()
	{
		double[] darr = new double[]
		{
			2.0,
			3.0,
			-1.0,
			-12.0
		};
		double[] darr2 = new double[]
		{
			3.0,
			2.0
		};
		double[][] darr3 = new double[][]
		{
			new double[]
			{
				-2.0,
				-9.0,
				(double)1f,
				9.0
			},
			new double[]
			{
				(double)1f,
				(double)1f,
				-1.0,
				-2.0
			}
		};
		Simplex.test(darr3, darr2, darr);
	}
	
	
	public static void test4()
	{
		double[] darr = new double[]
		{
			10.0,
			-57.0,
			-9.0,
			-24.0
		};
		double[] darr2 = new double[]
		{
			(double)0f,
			(double)0f,
			(double)1f
		};
		double[][] darr3 = new double[][]
		{
			new double[]
			{
				0.5,
				-5.5,
				-2.5,
				9.0
			},
			new double[]
			{
				0.5,
				-1.5,
				-0.5,
				(double)1f
			},
			new double[]
			{
				(double)1f,
				(double)0f,
				(double)0f,
				(double)0f
			}
		};
		Simplex.test(darr3, darr2, darr);
	}
	
	private int dantzig()
	{
		int num = 0;
		for (int i = 1; i < this.M + this.N; i++)
		{
			if (this.a[this.M][i] > this.a[this.M][num])
			{
				num = i;
			}
		}
		if (this.a[this.M][num] <= (double)0f)
		{
			return -1;
		}
		return num;
	}
	
	
	public virtual void show()
	{
		StdOut.println(new StringBuilder().append("M = ").append(this.M).toString());
		StdOut.println(new StringBuilder().append("N = ").append(this.N).toString());
		for (int i = 0; i <= this.M; i++)
		{
			for (int j = 0; j <= this.M + this.N; j++)
			{
				StdOut.printf("%7.2f ", new object[]
				{
					java.lang.Double.valueOf(this.a[i][j])
				});
			}
			StdOut.println();
		}
		StdOut.println(new StringBuilder().append("value = ").append(this.value()).toString());
		for (int i = 0; i < this.M; i++)
		{
			if (this.basis[i] < this.N)
			{
				StdOut.println(new StringBuilder().append("x_").append(this.basis[i]).append(" = ").append(this.a[i][this.M + this.N]).toString());
			}
		}
		StdOut.println();
	}
	
	
	/**/public static void main(string[] strarr)
	{
		java.lang.ArithmeticException ex;
		try
		{
			Simplex.test1();
		}
		catch (System.Exception arg_0A_0)
		{
			java.lang.ArithmeticException expr_0F = ByteCodeHelper.MapException<java.lang.ArithmeticException>(arg_0A_0, ByteCodeHelper.MapFlags.None);
			if (expr_0F == null)
			{
				throw;
			}
			ex = expr_0F;
			goto IL_19;
		}
		goto IL_25;
		IL_19:
		java.lang.ArithmeticException @this = ex;
		Throwable.instancehelper_printStackTrace(@this);
		IL_25:
		StdOut.println("--------------------------------");
		java.lang.ArithmeticException ex2;
		try
		{
			Simplex.test2();
		}
		catch (System.Exception arg_39_0)
		{
			java.lang.ArithmeticException expr_3E = ByteCodeHelper.MapException<java.lang.ArithmeticException>(arg_39_0, ByteCodeHelper.MapFlags.None);
			if (expr_3E == null)
			{
				throw;
			}
			ex2 = expr_3E;
			goto IL_48;
		}
		goto IL_54;
		IL_48:
		@this = ex2;
		Throwable.instancehelper_printStackTrace(@this);
		IL_54:
		StdOut.println("--------------------------------");
		java.lang.ArithmeticException ex3;
		try
		{
			Simplex.test3();
		}
		catch (System.Exception arg_68_0)
		{
			java.lang.ArithmeticException expr_6D = ByteCodeHelper.MapException<java.lang.ArithmeticException>(arg_68_0, ByteCodeHelper.MapFlags.None);
			if (expr_6D == null)
			{
				throw;
			}
			ex3 = expr_6D;
			goto IL_77;
		}
		goto IL_83;
		IL_77:
		@this = ex3;
		Throwable.instancehelper_printStackTrace(@this);
		IL_83:
		StdOut.println("--------------------------------");
		java.lang.ArithmeticException ex4;
		try
		{
			Simplex.test4();
		}
		catch (System.Exception arg_97_0)
		{
			java.lang.ArithmeticException expr_9C = ByteCodeHelper.MapException<java.lang.ArithmeticException>(arg_97_0, ByteCodeHelper.MapFlags.None);
			if (expr_9C == null)
			{
				throw;
			}
			ex4 = expr_9C;
			goto IL_A7;
		}
		goto IL_B4;
		IL_A7:
		@this = ex4;
		Throwable.instancehelper_printStackTrace(@this);
		IL_B4:
		StdOut.println("--------------------------------");
		int num = Integer.parseInt(strarr[0]);
		int num2 = Integer.parseInt(strarr[1]);
		double[] array = new double[num2];
		double[] array2 = new double[num];
		int arg_F8_0 = num;
		int arg_F0_0 = num2;
		int[] array3 = new int[2];
		int num3 = arg_F0_0;
		array3[1] = num3;
		num3 = arg_F8_0;
		array3[0] = num3;
		double[][] array4 = (double[][])ByteCodeHelper.multianewarray(typeof(double[][]).TypeHandle, array3);
		for (int i = 0; i < num2; i++)
		{
			array[i] = (double)StdRandom.uniform(1000);
		}
		for (int i = 0; i < num; i++)
		{
			array2[i] = (double)StdRandom.uniform(1000);
		}
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				array4[i][j] = (double)StdRandom.uniform(100);
			}
		}
		Simplex simplex = new Simplex(array4, array2, array);
		StdOut.println(simplex.value());
	}
	
	static Simplex()
	{
		Simplex.s_assertionsDisabled = !ClassLiteral<Simplex>.Value.desiredAssertionStatus();
	}
}






public class SparseVector
{
	private int N;
//[Signature("LST<Ljava/lang/Integer;Ljava/lang/Double;>;")]
	private ST st;
	
	
	public virtual double get(int i)
	{
		if (i < 0 || i >= this.N)
		{
			string arg_17_0 = "Illegal index";
			
			throw new IndexOutOfRangeException(arg_17_0);
		}
		if (this.st.contains(Integer.valueOf(i)))
		{
			return ((java.lang.Double)this.st.get(Integer.valueOf(i))).doubleValue();
		}
		return (double)0f;
	}
	
	
	public virtual double dot(SparseVector sv)
	{
		if (this.N != sv.N)
		{
			string arg_18_0 = "Vector lengths disagree";
			
			throw new ArgumentException(arg_18_0);
		}
		double num = (double)0f;
		if (this.st.Size <= sv.st.Size)
		{
			Iterator iterator = this.st.keys().iterator();
			while (iterator.hasNext())
			{
				int i = ((Integer)iterator.next()).intValue();
				if (sv.st.contains(Integer.valueOf(i)))
				{
					num += this.get(i) * sv.get(i);
				}
			}
		}
		else
		{
			Iterator iterator = sv.st.keys().iterator();
			while (iterator.hasNext())
			{
				int i = ((Integer)iterator.next()).intValue();
				if (this.st.contains(Integer.valueOf(i)))
				{
					num += this.get(i) * sv.get(i);
				}
			}
		}
		return num;
	}
	
	
	public SparseVector(int i)
	{
		this.N = i;
		this.st = new ST();
	}
	
	
	public virtual void put(int i, double d)
	{
		if (i < 0 || i >= this.N)
		{
			string arg_17_0 = "Illegal index";
			
			throw new IndexOutOfRangeException(arg_17_0);
		}
		if (d == (double)0f)
		{
			this.st.delete(Integer.valueOf(i));
		}
		else
		{
			this.st.put(Integer.valueOf(i), java.lang.Double.valueOf(d));
		}
	}
	
	
	public virtual SparseVector plus(SparseVector sv)
	{
		if (this.N != sv.N)
		{
			string arg_18_0 = "Vector lengths disagree";
			
			throw new ArgumentException(arg_18_0);
		}
		SparseVector sparseVector = new SparseVector(this.N);
		Iterator iterator = this.st.keys().iterator();
		while (iterator.hasNext())
		{
			int i = ((Integer)iterator.next()).intValue();
			sparseVector.put(i, this.get(i));
		}
		iterator = sv.st.keys().iterator();
		while (iterator.hasNext())
		{
			int i = ((Integer)iterator.next()).intValue();
			sparseVector.put(i, sv.get(i) + sparseVector.get(i));
		}
		return sparseVector;
	}
	
	
	public virtual int nnz()
	{
		return this.st.Size;
	}
	public virtual int Size
	{
		return this.N;
	}
	
	
	public virtual double dot(double[] darr)
	{
		double num = (double)0f;
		Iterator iterator = this.st.keys().iterator();
		while (iterator.hasNext())
		{
			int num2 = ((Integer)iterator.next()).intValue();
			num += darr[num2] * this.get(num2);
		}
		return num;
	}
	
	
	public virtual double norm()
	{
		return java.lang.Math.sqrt(this.dot(this));
	}
	
	
	public virtual SparseVector scale(double d)
	{
		SparseVector sparseVector = new SparseVector(this.N);
		Iterator iterator = this.st.keys().iterator();
		while (iterator.hasNext())
		{
			int i = ((Integer)iterator.next()).intValue();
			sparseVector.put(i, d * this.get(i));
		}
		return sparseVector;
	}
	
	
	public override string ToString()
	{
		string text = "";
		Iterator iterator = this.st.keys().iterator();
		while (iterator.hasNext())
		{
			int i = ((Integer)iterator.next()).intValue();
			text = new StringBuilder().append(text).append("(").append(i).append(", ").append(this.st.get(Integer.valueOf(i))).append(") ").toString();
		}
		return text;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		SparseVector sparseVector = new SparseVector(10);
		SparseVector sparseVector2 = new SparseVector(10);
		sparseVector.put(3, 0.5);
		sparseVector.put(9, 0.75);
		sparseVector.put(6, 0.11);
		sparseVector.put(6, (double)0f);
		sparseVector2.put(3, 0.6);
		sparseVector2.put(4, 0.9);
		StdOut.println(new StringBuilder().append("a = ").append(sparseVector).toString());
		StdOut.println(new StringBuilder().append("b = ").append(sparseVector2).toString());
		StdOut.println(new StringBuilder().append("a dot b = ").append(sparseVector.dot(sparseVector2)).toString());
		StdOut.println(new StringBuilder().append("a + b   = ").append(sparseVector.plus(sparseVector2)).toString());
	}
}































































public class SuffixArrayX
{
	private const int CUTOFF = 5;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private char[] text;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private int[] index;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private int N;
//[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
	internal static bool s_assertionsDisabled;
	
	
	
	
	private void sort(int num, int num2, int num3)
	{
		if (num2 <= num + 5)
		{
			this.insertion(num, num2, num3);
			return;
		}
		int num4 = num;
		int num5 = num2;
		int num6 = (int)this.text[this.index[num] + num3];
		int i = num + 1;
		while (i <= num5)
		{
			int num7 = (int)this.text[this.index[i] + num3];
			if (num7 < num6)
			{
				int arg_56_1 = num4;
				num4++;
				int arg_56_2 = i;
				i++;
				this.exch(arg_56_1, arg_56_2);
			}
			else if (num7 > num6)
			{
				int arg_69_1 = i;
				int arg_69_2 = num5;
				num5 += -1;
				this.exch(arg_69_1, arg_69_2);
			}
			else
			{
				i++;
			}
		}
		this.sort(num, num4 - 1, num3);
		if (num6 > 0)
		{
			this.sort(num4, num5, num3 + 1);
		}
		this.sort(num5 + 1, num2, num3);
	}
	
	
	private void insertion(int num, int num2, int num3)
	{
		for (int i = num; i <= num2; i++)
		{
			int num4 = i;
			while (num4 > num && this.less(this.index[num4], this.index[num4 - 1], num3))
			{
				this.exch(num4, num4 - 1);
				num4 += -1;
			}
		}
	}
	
	private void exch(int num, int num2)
	{
		int num3 = this.index[num];
		this.index[num] = this.index[num2];
		this.index[num2] = num3;
	}
	
	private bool less(int num, int num2, int num3)
	{
		if (num == num2)
		{
			return false;
		}
		num += num3;
		num2 += num3;
		while (num < this.N && num2 < this.N)
		{
			if (this.text[num] < this.text[num2])
			{
				return true;
			}
			if (this.text[num] > this.text[num2])
			{
				return false;
			}
			num++;
			num2++;
		}
		return num > num2;
	}
	
	private int lcp(int num, int num2)
	{
		int num3 = 0;
		while (num < this.N && num2 < this.N)
		{
			if (this.text[num] != this.text[num2])
			{
				return num3;
			}
			num++;
			num2++;
			num3++;
		}
		return num3;
	}
	
	
	private int compare(string this2, int num)
	{
		int num2 = java.lang.String.instancehelper_length(this2);
		int num3 = 0;
		while (num < this.N && num3 < num2)
		{
			if (java.lang.String.instancehelper_charAt(this2, num3) != this.text[num])
			{
				return (int)(java.lang.String.instancehelper_charAt(this2, num3) - this.text[num]);
			}
			num++;
			num3++;
		}
		if (num < this.N)
		{
			return -1;
		}
		if (num3 < num2)
		{
			return 1;
		}
		return 0;
	}
	
	
	public SuffixArrayX(string str)
	{
		this.N = java.lang.String.instancehelper_length(str);
		str = new StringBuilder().append(str).append('\0').toString();
		this.text = java.lang.String.instancehelper_toCharArray(str);
		this.index = new int[this.N];
		for (int i = 0; i < this.N; i++)
		{
			this.index[i] = i;
		}
		this.sort(0, this.N - 1, 0);
	}
	
	
	public virtual int index(int i)
	{
		if (i < 0 || i >= this.N)
		{
			
			throw new IndexOutOfRangeException();
		}
		return this.index[i];
	}
	
	
	public virtual int rank(string str)
	{
		int i = 0;
		int num = this.N - 1;
		while (i <= num)
		{
			int num2 = i + (num - i) / 2;
			int num3 = this.compare(str, this.index[num2]);
			if (num3 < 0)
			{
				num = num2 - 1;
			}
			else
			{
				if (num3 <= 0)
				{
					return num2;
				}
				i = num2 + 1;
			}
		}
		return i;
	}
	
	
	public virtual string select(int i)
	{
		if (i < 0 || i >= this.N)
		{
			
			throw new IndexOutOfRangeException();
		}
		return java.lang.String.newhelper(this.text, this.index[i], this.N - this.index[i]);
	}
	
	
	public virtual int lcp(int i)
	{
		if (i < 1 || i >= this.N)
		{
			
			throw new IndexOutOfRangeException();
		}
		return this.lcp(this.index[i], this.index[i - 1]);
	}
	public virtual int length()
	{
		return this.N;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		string text = java.lang.String.instancehelper_trim(java.lang.String.instancehelper_replaceAll(StdIn.readAll(), "\n", " "));
		SuffixArrayX suffixArrayX = new SuffixArrayX(text);
		SuffixArray suffixArray = new SuffixArray(text);
		int num = 1;
		int i = 0;
		while (num != 0 && i < java.lang.String.instancehelper_length(text))
		{
			if (suffixArray.index(i) != suffixArrayX.index(i))
			{
				StdOut.println(new StringBuilder().append("suffixReference(").append(i).append(") = ").append(suffixArray.index(i)).toString());
				StdOut.println(new StringBuilder().append("suffix(").append(i).append(") = ").append(suffixArrayX.index(i)).toString());
				string obj = new StringBuilder().append("\"").append(java.lang.String.instancehelper_substring(text, suffixArrayX.index(i), java.lang.Math.min(suffixArrayX.index(i) + 50, java.lang.String.instancehelper_length(text)))).append("\"").toString();
				string text2 = new StringBuilder().append("\"").append(java.lang.String.instancehelper_substring(text, suffixArray.index(i), java.lang.Math.min(suffixArray.index(i) + 50, java.lang.String.instancehelper_length(text)))).append("\"").toString();
				StdOut.println(obj);
				StdOut.println(text2);
				num = 0;
			}
			i++;
		}
		StdOut.println("  i ind lcp rnk  select");
		StdOut.println("---------------------------");
		for (i = 0; i < java.lang.String.instancehelper_length(text); i++)
		{
			int num2 = suffixArrayX.index(i);
			string text2 = new StringBuilder().append("\"").append(java.lang.String.instancehelper_substring(text, num2, java.lang.Math.min(num2 + 50, java.lang.String.instancehelper_length(text)))).append("\"").toString();
			int i2 = suffixArrayX.rank(java.lang.String.instancehelper_substring(text, num2));
			if (!SuffixArrayX.s_assertionsDisabled && !java.lang.String.instancehelper_equals(java.lang.String.instancehelper_substring(text, num2), suffixArrayX.select(i)))
			{
				
				throw new AssertionError();
			}
			if (i == 0)
			{
				StdOut.printf("%3d %3d %3s %3d  %s\n", new object[]
				{
					Integer.valueOf(i),
					Integer.valueOf(num2),
					"-",
					Integer.valueOf(i2),
					text2
				});
			}
			else
			{
				int i3 = suffixArrayX.lcp(i);
				StdOut.printf("%3d %3d %3d %3d  %s\n", new object[]
				{
					Integer.valueOf(i),
					Integer.valueOf(num2),
					Integer.valueOf(i3),
					Integer.valueOf(i2),
					text2
				});
			}
		}
	}
	
	static SuffixArrayX()
	{
		SuffixArrayX.s_assertionsDisabled = !ClassLiteral<SuffixArrayX>.Value.desiredAssertionStatus();
	}
}






public class SymbolDigraph
{
//[Signature("LST<Ljava/lang/String;Ljava/lang/Integer;>;")]
	private ST st;
	private string[] keys;
	private Digraph G;
	
	
	public SymbolDigraph(string str1, string str2)
	{
		this.st = new ST();
		In @in = new In(str1);
		while (@in.hasNextLine())
		{
			string[] array = java.lang.String.instancehelper_split(@in.readLine(), str2);
			for (int i = 0; i < array.Length; i++)
			{
				if (!this.st.contains(array[i]))
				{
					this.st.put(array[i], Integer.valueOf(this.st.Size));
				}
			}
		}
		this.keys = new string[this.st.Size];
		Iterator iterator = this.st.keys().iterator();
		while (iterator.hasNext())
		{
			string text = (string)iterator.next();
			this.keys[((Integer)this.st.get(text)).intValue()] = text;
		}
		this.G = new Digraph(this.st.Size);
		@in = new In(str1);
		while (@in.hasNextLine())
		{
			string[] array = java.lang.String.instancehelper_split(@in.readLine(), str2);
			int i = ((Integer)this.st.get(array[0])).intValue();
			for (int j = 1; j < array.Length; j++)
			{
				int i2 = ((Integer)this.st.get(array[j])).intValue();
				this.G.addEdge(i, i2);
			}
		}
	}
	public virtual Digraph G()
	{
		return this.G;
	}
	
	
	public virtual int index(string str)
	{
		return ((Integer)this.st.get(str)).intValue();
	}
	
	public virtual string name(int i)
	{
		return this.keys[i];
	}
	
	
	public virtual bool contains(string str)
	{
		return this.st.contains(str);
	}
	
	
	/**/public static void main(string[] strarr)
	{
		string str = strarr[0];
		string str2 = strarr[1];
		SymbolDigraph symbolDigraph = new SymbolDigraph(str, str2);
		Digraph digraph = symbolDigraph.G();
		while (!StdIn.IsEmpty)
		{
			string str3 = StdIn.readLine();
			Iterator iterator = digraph.adj(symbolDigraph.index(str3)).iterator();
			while (iterator.hasNext())
			{
				int i = ((Integer)iterator.next()).intValue();
				StdOut.println(new StringBuilder().append("   ").append(symbolDigraph.name(i)).toString());
			}
		}
	}
}






public class SymbolGraph
{
//[Signature("LST<Ljava/lang/String;Ljava/lang/Integer;>;")]
	private ST st;
	private string[] keys;
	private Graph G;
	
	
	public SymbolGraph(string str1, string str2)
	{
		this.st = new ST();
		In @in = new In(str1);
		while (!@in.IsEmpty)
		{
			string[] array = java.lang.String.instancehelper_split(@in.readLine(), str2);
			for (int i = 0; i < array.Length; i++)
			{
				if (!this.st.contains(array[i]))
				{
					this.st.put(array[i], Integer.valueOf(this.st.Size));
				}
			}
		}
		StdOut.println(new StringBuilder().append("Done reading ").append(str1).toString());
		this.keys = new string[this.st.Size];
		Iterator iterator = this.st.keys().iterator();
		while (iterator.hasNext())
		{
			string text = (string)iterator.next();
			this.keys[((Integer)this.st.get(text)).intValue()] = text;
		}
		this.G = new Graph(this.st.Size);
		@in = new In(str1);
		while (@in.hasNextLine())
		{
			string[] array = java.lang.String.instancehelper_split(@in.readLine(), str2);
			int i = ((Integer)this.st.get(array[0])).intValue();
			for (int j = 1; j < array.Length; j++)
			{
				int i2 = ((Integer)this.st.get(array[j])).intValue();
				this.G.addEdge(i, i2);
			}
		}
	}
	public virtual Graph G()
	{
		return this.G;
	}
	
	
	public virtual bool contains(string str)
	{
		return this.st.contains(str);
	}
	
	
	public virtual int index(string str)
	{
		return ((Integer)this.st.get(str)).intValue();
	}
	
	public virtual string name(int i)
	{
		return this.keys[i];
	}
	
	
	/**/public static void main(string[] strarr)
	{
		string str = strarr[0];
		string str2 = strarr[1];
		SymbolGraph symbolGraph = new SymbolGraph(str, str2);
		Graph graph = symbolGraph.G();
		while (StdIn.hasNextLine())
		{
			string str3 = StdIn.readLine();
			if (symbolGraph.contains(str3))
			{
				int i = symbolGraph.index(str3);
				Iterator iterator = graph.adj(i).iterator();
				while (iterator.hasNext())
				{
					int i2 = ((Integer)iterator.next()).intValue();
					StdOut.println(new StringBuilder().append("   ").append(symbolGraph.name(i2)).toString());
				}
			}
			else
			{
				StdOut.println(new StringBuilder().append("input not contain '").append(str3).append("'").toString());
			}
		}
	}
}







public class TarjanSCC
{
	private bool[] marked;
	private int[] id;
	private int[] low;
	private int pre;
	private int count;
//[Signature("LStack<Ljava/lang/Integer;>;")]
	private Stack stack;
//[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
	internal static bool s_assertionsDisabled;
	
	
	
	
	private void dfs(Digraph digraph, int num)
	{
		this.marked[num] = true;
		int[] arg_23_0 = this.low;
		int num2 = this.pre;
		int arg_23_2 = num2;
		this.pre = num2 + 1;
		arg_23_0[num] = arg_23_2;
		int num3 = this.low[num];
		this.stack.push(Integer.valueOf(num));
		Iterator iterator = digraph.adj(num).iterator();
		while (iterator.hasNext())
		{
			int num4 = ((Integer)iterator.next()).intValue();
			if (!this.marked[num4])
			{
				this.dfs(digraph, num4);
			}
			if (this.low[num4] < num3)
			{
				num3 = this.low[num4];
			}
		}
		if (num3 < this.low[num])
		{
			this.low[num] = num3;
			return;
		}
		int num5;
		do
		{
			num5 = ((Integer)this.stack.pop()).intValue();
			this.id[num5] = this.count;
			this.low[num5] = digraph.V();
		}
		while (num5 != num);
		this.count++;
	}
	
	
	private bool check(Digraph digraph)
	{
		TransitiveClosure transitiveClosure = new TransitiveClosure(digraph);
		for (int i = 0; i < digraph.V(); i++)
		{
			for (int j = 0; j < digraph.V(); j++)
			{
				if (this.stronglyConnected(i, j) != ((!transitiveClosure.reachable(i, j) || !transitiveClosure.reachable(j, i)) ? false : true))
				{
					return false;
				}
			}
		}
		return true;
	}
	
	public virtual bool stronglyConnected(int i1, int i2)
	{
		return this.id[i1] == this.id[i2];
	}
	
	
	public TarjanSCC(Digraph d)
	{
		this.marked = new bool[d.V()];
		this.stack = new Stack();
		this.id = new int[d.V()];
		this.low = new int[d.V()];
		for (int i = 0; i < d.V(); i++)
		{
			if (!this.marked[i])
			{
				this.dfs(d, i);
			}
		}
		if (!TarjanSCC.s_assertionsDisabled && !this.check(d))
		{
			
			throw new AssertionError();
		}
	}
	public virtual int count()
	{
		return this.count;
	}
	
	public virtual int id(int i)
	{
		return this.id[i];
	}
	
	
	/**/public static void main(string[] strarr)
	{
		
		In i = new In(strarr[0]);
		Digraph digraph = new Digraph(i);
		TarjanSCC tarjanSCC = new TarjanSCC(digraph);
		int num = tarjanSCC.count();
		StdOut.println(new StringBuilder().append(num).append(" components").toString());
		Queue[] array = (Queue[])new Queue[num];
		for (int j = 0; j < num; j++)
		{
			array[j] = new Queue();
		}
		for (int j = 0; j < digraph.V(); j++)
		{
			array[tarjanSCC.id(j)].enqueue(Integer.valueOf(j));
		}
		for (int j = 0; j < num; j++)
		{
			Iterator iterator = array[j].iterator();
			while (iterator.hasNext())
			{
				int i2 = ((Integer)iterator.next()).intValue();
				StdOut.print(new StringBuilder().append(i2).append(" ").toString());
			}
			StdOut.println();
		}
	}
	
	static TarjanSCC()
	{
		TarjanSCC.s_assertionsDisabled = !ClassLiteral<TarjanSCC>.Value.desiredAssertionStatus();
	}
}





public class ThreeSum
{
	
	public static int count(int[] iarr)
	{
		int num = iarr.Length;
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			for (int j = i + 1; j < num; j++)
			{
				for (int k = j + 1; k < num; k++)
				{
					if (iarr[i] + iarr[j] + iarr[k] == 0)
					{
						num2++;
					}
				}
			}
		}
		return num2;
	}
	
	
	public ThreeSum()
	{
	}
	
	
	public static void printAll(int[] iarr)
	{
		int num = iarr.Length;
		for (int i = 0; i < num; i++)
		{
			for (int j = i + 1; j < num; j++)
			{
				for (int k = j + 1; k < num; k++)
				{
					if (iarr[i] + iarr[j] + iarr[k] == 0)
					{
						StdOut.println(new StringBuilder().append(iarr[i]).append(" ").append(iarr[j]).append(" ").append(iarr[k]).toString());
					}
				}
			}
		}
	}
	
	
	/**/public static void main(string[] strarr)
	{
		
		In @in = new In(strarr[0]);
		int[] iarr = @in.readAllInts();
		Stopwatch stopwatch = new Stopwatch();
		int i = ThreeSum.count(iarr);
		StdOut.println(new StringBuilder().append("elapsed time = ").append(stopwatch.elapsedTime()).toString());
		StdOut.println(i);
	}
}






public class ThreeSumFast
{
	
	private static bool containsDuplicates(int[] array)
	{
		for (int i = 1; i < array.Length; i++)
		{
			if (array[i] == array[i - 1])
			{
				return true;
			}
		}
		return false;
	}
	
	
	public static int count(int[] iarr)
	{
		int num = iarr.Length;
		Arrays.sort(iarr);
		if (ThreeSumFast.containsDuplicates(iarr))
		{
			string arg_1B_0 = "array contains duplicate integers";
			
			throw new ArgumentException(arg_1B_0);
		}
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			for (int j = i + 1; j < num; j++)
			{
				int num3 = Arrays.binarySearch(iarr, -(iarr[i] + iarr[j]));
				if (num3 > j)
				{
					num2++;
				}
			}
		}
		return num2;
	}
	
	
	public ThreeSumFast()
	{
	}
	
	
	public static void printAll(int[] iarr)
	{
		int num = iarr.Length;
		Arrays.sort(iarr);
		if (ThreeSumFast.containsDuplicates(iarr))
		{
			string arg_1B_0 = "array contains duplicate integers";
			
			throw new ArgumentException(arg_1B_0);
		}
		for (int i = 0; i < num; i++)
		{
			for (int j = i + 1; j < num; j++)
			{
				int num2 = Arrays.binarySearch(iarr, -(iarr[i] + iarr[j]));
				if (num2 > j)
				{
					StdOut.println(new StringBuilder().append(iarr[i]).append(" ").append(iarr[j]).append(" ").append(iarr[num2]).toString());
				}
			}
		}
	}
	
	
	/**/public static void main(string[] strarr)
	{
		
		In @in = new In(strarr[0]);
		int[] iarr = @in.readAllInts();
		int i = ThreeSumFast.count(iarr);
		StdOut.println(i);
	}
}



public class Topological
{
//[Signature("Ljava/lang/Iterable<Ljava/lang/Integer;>;")]
	private Iterable order;
	
	
	public Topological(EdgeWeightedDigraph ewd)
	{
		EdgeWeightedDirectedCycle edgeWeightedDirectedCycle = new EdgeWeightedDirectedCycle(ewd);
		if (!edgeWeightedDirectedCycle.hasCycle())
		{
			DepthFirstOrder depthFirstOrder = new DepthFirstOrder(ewd);
			this.order = depthFirstOrder.reversePost();
		}
	}
	public virtual bool hasOrder()
	{
		return this.order != null;
	}
/*	[Signature("()Ljava/lang/Iterable<Ljava/lang/Integer;>;")]*/
	public virtual Iterable order()
	{
		return this.order;
	}
	
	
	public Topological(Digraph d)
	{
		DirectedCycle directedCycle = new DirectedCycle(d);
		if (!directedCycle.hasCycle())
		{
			DepthFirstOrder depthFirstOrder = new DepthFirstOrder(d);
			this.order = depthFirstOrder.reversePost();
		}
	}
	
	
	/**/public static void main(string[] strarr)
	{
		string str = strarr[0];
		string str2 = strarr[1];
		SymbolDigraph symbolDigraph = new SymbolDigraph(str, str2);
		Topological topological = new Topological(symbolDigraph.G());
		Iterator iterator = topological.order().iterator();
		while (iterator.hasNext())
		{
			int i = ((Integer)iterator.next()).intValue();
			StdOut.println(symbolDigraph.name(i));
		}
	}
}





using System.ComponentModel;

/*[Implements(new string[]
{
	"java.lang.Comparable"
}), Signature("Ljava/lang/Object;Ljava/lang/Comparable<LTransaction;>;")]*/
public class Transaction, Comparable
{
	/*[Implements(new string[]
	{
		"java.util.Comparator"
	}), InnerClass(null, Modifiers.Public | Modifiers.Static), Signature("Ljava/lang/Object;Ljava/util/Comparator<LTransaction;>;"), SourceFile("Transaction.java")]*/
	public class HowMuchOrder, Comparator
	{
		
		
		public HowMuchOrder()
		{
		}
		
		
		public virtual int compare(Transaction t1, Transaction t2)
		{
			if (Transaction.access_200(t1) < Transaction.access_200(t2))
			{
				return -1;
			}
			if (Transaction.access_200(t1) > Transaction.access_200(t2))
			{
				return 1;
			}
			return 0;
		}
/*		[LineNumberTable(158), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic), EditorBrowsable(EditorBrowsableState.Never)]*/
		
		public virtual int compare(object obj1, object obj2)
		{
			return this.compare((Transaction)obj1, (Transaction)obj2);
		}
		
		bool Comparator.Object;)Zequals(object obj)
		{
			return java.lang.Object.instancehelper_equals(this, obj);
		}
	}
	/*[Implements(new string[]
	{
		"java.util.Comparator"
	}), InnerClass(null, Modifiers.Public | Modifiers.Static), Signature("Ljava/lang/Object;Ljava/util/Comparator<LTransaction;>;"), SourceFile("Transaction.java")]*/
	public class WhenOrder, Comparator
	{
		
		
		public WhenOrder()
		{
		}
		
		
		public virtual int compare(Transaction t1, Transaction t2)
		{
			return Transaction.access_100(t1).CompareTo(Transaction.access_100(t2));
		}
/*		[LineNumberTable(149), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic), EditorBrowsable(EditorBrowsableState.Never)]*/
		
		public virtual int compare(object obj1, object obj2)
		{
			return this.compare((Transaction)obj1, (Transaction)obj2);
		}
		
		bool Comparator.Object;)Zequals(object obj)
		{
			return java.lang.Object.instancehelper_equals(this, obj);
		}
	}
	/*[Implements(new string[]
	{
		"java.util.Comparator"
	}), InnerClass(null, Modifiers.Public | Modifiers.Static), Signature("Ljava/lang/Object;Ljava/util/Comparator<LTransaction;>;"), SourceFile("Transaction.java")]*/
	public class WhoOrder, Comparator
	{
		
		
		public WhoOrder()
		{
		}
		
		
		public virtual int compare(Transaction t1, Transaction t2)
		{
			return java.lang.String.instancehelper_compareTo(Transaction.access_000(t1), Transaction.access_000(t2));
		}
/*		[LineNumberTable(140), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic), EditorBrowsable(EditorBrowsableState.Never)]*/
		
		public virtual int compare(object obj1, object obj2)
		{
			return this.compare((Transaction)obj1, (Transaction)obj2);
		}
		
		bool Comparator.Object;)Zequals(object obj)
		{
			return java.lang.Object.instancehelper_equals(this, obj);
		}
	}
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private string who;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private Date when;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private double amount;
	
	
	public Transaction(string str)
	{
		string[] array = java.lang.String.instancehelper_split(str, "\\s+");
		this.who = array[0];
		Date.__<clinit>();
		this.when = new Date(array[1]);
		double num = java.lang.Double.parseDouble(array[2]);
		if (num == (double)0f)
		{
			this.amount = (double)0f;
		}
		else
		{
			this.amount = num;
		}
		if (java.lang.Double.isNaN(this.amount) || java.lang.Double.isInfinite(this.amount))
		{
			string arg_7C_0 = "Amount cannot be NaN or infinite";
			
			throw new ArgumentException(arg_7C_0);
		}
	}
	
	public virtual int compareTo(Transaction t)
	{
		if (this.amount < t.amount)
		{
			return -1;
		}
		if (this.amount > t.amount)
		{
			return 1;
		}
		return 0;
	}
	
	
	public Transaction(string str, Date d1, double d2)
	{
		if (java.lang.Double.isNaN(d2) || java.lang.Double.isInfinite(d2))
		{
			string arg_24_0 = "Amount cannot be NaN or infinite";
			
			throw new ArgumentException(arg_24_0);
		}
		this.who = str;
		this.when = d1;
		if (d2 == (double)0f)
		{
			this.amount = (double)0f;
		}
		else
		{
			this.amount = d2;
		}
	}
	public virtual string who()
	{
		return this.who;
	}
	public virtual Date when()
	{
		return this.when;
	}
	public virtual double amount()
	{
		return this.amount;
	}
	
	
	public override string ToString()
	{
		return java.lang.String.format("%-10s %10s %8.2f", new object[]
		{
			this.who,
			this.when,
			java.lang.Double.valueOf(this.amount)
		});
	}
	
	
	public override bool equals(object obj)
	{
		if (obj == this)
		{
			return true;
		}
		if (obj == null)
		{
			return false;
		}
		if (obj.GetType() != this.GetType())
		{
			return false;
		}
		Transaction transaction = (Transaction)obj;
		return this.amount == transaction.amount && java.lang.String.instancehelper_equals(this.who, transaction.who) && this.when.Equals(transaction.when);
	}
	
	
	public override int hashCode()
	{
		int num = 17;
		num = 31 * num + java.lang.String.instancehelper_hashCode(this.who);
		num = 31 * num + this.when.hashCode();
		return 31 * num + java.lang.Double.valueOf(this.amount).hashCode();
	}
	
	
	/**/public static void main(string[] strarr)
	{
		Transaction[] array = new Transaction[]
		{
			new Transaction("Turing   6/17/1990  644.08"),
			new Transaction("Tarjan   3/26/2002 4121.85"),
			new Transaction("Knuth    6/14/1999  288.34"),
			new Transaction("Dijkstra 8/22/2007 2678.40")
		};
		StdOut.println("Unsorted");
		for (int i = 0; i < array.Length; i++)
		{
			StdOut.println(array[i]);
		}
		StdOut.println();
		StdOut.println("Sort by date");
		Arrays.sort(array, new Transaction.WhenOrder());
		for (int i = 0; i < array.Length; i++)
		{
			StdOut.println(array[i]);
		}
		StdOut.println();
		StdOut.println("Sort by customer");
		Arrays.sort(array, new Transaction.WhoOrder());
		for (int i = 0; i < array.Length; i++)
		{
			StdOut.println(array[i]);
		}
		StdOut.println();
		StdOut.println("Sort by amount");
		Arrays.sort(array, new Transaction.HowMuchOrder());
		for (int i = 0; i < array.Length; i++)
		{
			StdOut.println(array[i]);
		}
		StdOut.println();
	}
/*	[LineNumberTable(23), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic), EditorBrowsable(EditorBrowsableState.Never)]*/
	
	public virtual int compareTo(object obj)
	{
		return this.CompareTo((Transaction)obj);
	}
/*	[LineNumberTable(23), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
	internal static string access_000(Transaction transaction)
	{
		return transaction.who;
	}
/*	[LineNumberTable(23), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
	internal static Date access_100(Transaction transaction)
	{
		return transaction.when;
	}
/*	[LineNumberTable(23), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
	internal static double access_200(Transaction transaction)
	{
		return transaction.amount;
	}
	
	int IComparable.Object;)IcompareTo(object obj)
	{
		return this.CompareTo(obj);
	}
}





public class TransitiveClosure
{
	private DirectedDFS[] tc;
	
	
	public TransitiveClosure(Digraph d)
	{
		this.tc = new DirectedDFS[d.V()];
		for (int i = 0; i < d.V(); i++)
		{
			this.tc[i] = new DirectedDFS(d, i);
		}
	}
	
	
	public virtual bool reachable(int i1, int i2)
	{
		return this.tc[i1].marked(i2);
	}
	
	
	/**/public static void main(string[] strarr)
	{
		
		In i = new In(strarr[0]);
		Digraph digraph = new Digraph(i);
		TransitiveClosure transitiveClosure = new TransitiveClosure(digraph);
		StdOut.print("     ");
		for (int j = 0; j < digraph.V(); j++)
		{
			StdOut.printf("%3d", new object[]
			{
				Integer.valueOf(j)
			});
		}
		StdOut.println();
		StdOut.println("--------------------------------------------");
		for (int j = 0; j < digraph.V(); j++)
		{
			StdOut.printf("%3d: ", new object[]
			{
				Integer.valueOf(j)
			});
			for (int k = 0; k < digraph.V(); k++)
			{
				if (transitiveClosure.reachable(j, k))
				{
					StdOut.printf("  T", new object[0]);
				}
				else
				{
					StdOut.printf("   ", new object[0]);
				}
			}
			StdOut.println();
		}
	}
}








/*[Implements(new string[]
{
	"java.lang.Iterable"
}), Signature("Ljava/lang/Object;Ljava/lang/Iterable<Ljava/lang/String;>;")]*/
public class TrieSET : IEnumerable
{
	/*[EnclosingMethod("TrieSET", null, null), InnerClass(null, Modifiers.Static | Modifiers.Synthetic), Modifiers(Modifiers.Super | Modifiers.Synthetic), SourceFile("TrieSET.java")]*/
	
	[InnerClass(null, Modifiers.Private | Modifiers.Static), Modifiers(Modifiers.Super), SourceFile("TrieSET.java")]
	internal sealed class Node
	{
		private TrieSET.Node[] next;
		private bool isString;
/*		[LineNumberTable(43), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static bool access_000(TrieSET.Node node)
		{
			return node.isString;
		}
/*		[LineNumberTable(43), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static TrieSET.Node[] access_100(TrieSET.Node node)
		{
			return node.next;
		}
/*		[LineNumberTable(43), Modifiers(Modifiers.Synthetic)]*/
		
		internal Node(TrieSET.1) : this()
		{
		}
/*		[LineNumberTable(43), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static bool access_002(TrieSET.Node node, bool result)
		{
			node.isString = result;
			return result;
		}
		
		
		private Node()
		{
			this.next = new TrieSET.Node[256];
		}
	}
	private const int R = 256;
	private TrieSET.Node root;
	private int N;
	
	
	private TrieSET.Node get(TrieSET.Node node, string text, int num)
	{
		if (node == null)
		{
			return null;
		}
		if (num == java.lang.String.instancehelper_length(text))
		{
			return node;
		}
		int num2 = (int)java.lang.String.instancehelper_charAt(text, num);
		return this.get(TrieSET.Node.access_100(node)[num2], text, num + 1);
	}
	
	
	private TrieSET.Node add(TrieSET.Node node, string text, int num)
	{
		if (node == null)
		{
			node = new TrieSET.Node(null);
		}
		if (num == java.lang.String.instancehelper_length(text))
		{
			if (!TrieSET.Node.access_000(node))
			{
				this.N++;
			}
			TrieSET.Node.access_002(node, true);
		}
		else
		{
			int num2 = (int)java.lang.String.instancehelper_charAt(text, num);
			TrieSET.Node.access_100(node)[num2] = this.add(TrieSET.Node.access_100(node)[num2], text, num + 1);
		}
		return node;
	}
	public virtual int Size
	{
		return this.N;
	}
/*	[Signature("(Ljava/lang/String;)Ljava/lang/Iterable<Ljava/lang/String;>;")]*/
	
	public virtual Iterable keysWithPrefix(string str)
	{
		Queue queue = new Queue();
		TrieSET.Node node = this.get(this.root, str, 0);
		this.collect(node, new StringBuilder(str), queue);
		return queue;
	}
/*	[Signature("(LTrieSET$Node;Ljava/lang/StringBuilder;LQueue<Ljava/lang/String;>;)V")]*/
	
	private void collect(TrieSET.Node node, StringBuilder stringBuilder, Queue queue)
	{
		if (node == null)
		{
			return;
		}
		if (TrieSET.Node.access_000(node))
		{
			queue.enqueue(stringBuilder.toString());
		}
		for (int i = 0; i < 256; i = (int)((ushort)(i + 1)))
		{
			stringBuilder.append((char)i);
			this.collect(TrieSET.Node.access_100(node)[i], stringBuilder, queue);
			stringBuilder.deleteCharAt(stringBuilder.Length() - 1);
		}
	}
/*	[Signature("(LTrieSET$Node;Ljava/lang/StringBuilder;Ljava/lang/String;LQueue<Ljava/lang/String;>;)V")]*/
	
	private void collect(TrieSET.Node node, StringBuilder stringBuilder, string text, Queue queue)
	{
		if (node == null)
		{
			return;
		}
		int num = stringBuilder.Length();
		if (num == java.lang.String.instancehelper_length(text) && TrieSET.Node.access_000(node))
		{
			queue.enqueue(stringBuilder.toString());
		}
		if (num == java.lang.String.instancehelper_length(text))
		{
			return;
		}
		int num2 = (int)java.lang.String.instancehelper_charAt(text, num);
		if (num2 == 46)
		{
			for (int i = 0; i < 256; i = (int)((ushort)(i + 1)))
			{
				stringBuilder.append((char)i);
				this.collect(TrieSET.Node.access_100(node)[i], stringBuilder, text, queue);
				stringBuilder.deleteCharAt(stringBuilder.Length() - 1);
			}
		}
		else
		{
			stringBuilder.append((char)num2);
			this.collect(TrieSET.Node.access_100(node)[num2], stringBuilder, text, queue);
			stringBuilder.deleteCharAt(stringBuilder.Length() - 1);
		}
	}
	
	
	private int longestPrefixOf(TrieSET.Node node, string text, int num, int num2)
	{
		if (node == null)
		{
			return num2;
		}
		if (TrieSET.Node.access_000(node))
		{
			num2 = num;
		}
		if (num == java.lang.String.instancehelper_length(text))
		{
			return num2;
		}
		int num3 = (int)java.lang.String.instancehelper_charAt(text, num);
		return this.longestPrefixOf(TrieSET.Node.access_100(node)[num3], text, num + 1, num2);
	}
	
	
	private TrieSET.Node delete(TrieSET.Node node, string text, int num)
	{
		if (node == null)
		{
			return null;
		}
		if (num == java.lang.String.instancehelper_length(text))
		{
			if (TrieSET.Node.access_000(node))
			{
				this.N--;
			}
			TrieSET.Node.access_002(node, false);
		}
		else
		{
			int i = (int)java.lang.String.instancehelper_charAt(text, num);
			TrieSET.Node.access_100(node)[i] = this.delete(TrieSET.Node.access_100(node)[i], text, num + 1);
		}
		if (TrieSET.Node.access_000(node))
		{
			return node;
		}
		for (int i = 0; i < 256; i++)
		{
			if (TrieSET.Node.access_100(node)[i] != null)
			{
				return node;
			}
		}
		return null;
	}
	
	
	public TrieSET()
	{
	}
	
	
	public virtual void add(string str)
	{
		this.root = this.add(this.root, str, 0);
	}
/*	[LineNumberTable(119), Signature("()Ljava/util/Iterator<Ljava/lang/String;>;")]*/
	
	public virtual Iterator iterator()
	{
		return this.keysWithPrefix("").iterator();
	}
	
	
	public virtual string longestPrefixOf(string str)
	{
		int num = this.longestPrefixOf(this.root, str, 0, -1);
		if (num == -1)
		{
			return null;
		}
		return java.lang.String.instancehelper_substring(str, 0, num);
	}
/*	[Signature("(Ljava/lang/String;)Ljava/lang/Iterable<Ljava/lang/String;>;")]*/
	
	public virtual Iterable keysThatMatch(string str)
	{
		Queue queue = new Queue();
		StringBuilder stringBuilder = new StringBuilder();
		this.collect(this.root, stringBuilder, str, queue);
		return queue;
	}
	
	
	public virtual bool contains(string str)
	{
		TrieSET.Node node = this.get(this.root, str, 0);
		return node != null && TrieSET.Node.access_000(node);
	}
	
	
	public virtual bool IsEmpty
	{
		return this.Size == 0;
	}
	
	
	public virtual void delete(string str)
	{
		this.root = this.delete(this.root, str, 0);
	}
	
	
	/**/public static void main(string[] strarr)
	{
		TrieSET trieSET = new TrieSET();
		while (!StdIn.IsEmpty)
		{
			string str = StdIn.readString();
			trieSET.add(str);
		}
		Iterator iterator;
		if (trieSET.Size < 100)
		{
			StdOut.println("keys(\"\"):");
			iterator = trieSET.iterator();
			while (iterator.hasNext())
			{
				string obj = (string)iterator.next();
				StdOut.println(obj);
			}
			StdOut.println();
		}
		StdOut.println("longestPrefixOf(\"shellsort\"):");
		StdOut.println(trieSET.longestPrefixOf("shellsort"));
		StdOut.println();
		StdOut.println("longestPrefixOf(\"xshellsort\"):");
		StdOut.println(trieSET.longestPrefixOf("xshellsort"));
		StdOut.println();
		StdOut.println("keysWithPrefix(\"shor\"):");
		iterator = trieSET.keysWithPrefix("shor").iterator();
		while (iterator.hasNext())
		{
			string obj = (string)iterator.next();
			StdOut.println(obj);
		}
		StdOut.println();
		StdOut.println("keysWithPrefix(\"shortening\"):");
		iterator = trieSET.keysWithPrefix("shortening").iterator();
		while (iterator.hasNext())
		{
			string obj = (string)iterator.next();
			StdOut.println(obj);
		}
		StdOut.println();
		StdOut.println("keysThatMatch(\".he.l.\"):");
		iterator = trieSET.keysThatMatch(".he.l.").iterator();
		while (iterator.hasNext())
		{
			string obj = (string)iterator.next();
			StdOut.println(obj);
		}
	}
	
	IEnumerator IEnumerable.GetEnumerator()
	{
		return new IterableEnumerator(this);
	}
}










//[Signature("<Value:Ljava/lang/Object;>Ljava/lang/Object;")]
public class TST
{
	/*[EnclosingMethod("TST", null, null), InnerClass(null, Modifiers.Static | Modifiers.Synthetic), Modifiers(Modifiers.Super | Modifiers.Synthetic), SourceFile("TST.java")]*/
	
	[InnerClass(null, Modifiers.Private), Modifiers(Modifiers.Super), SourceFile("TST.java")]
	internal sealed class Node
	{
		private char c;
//[Signature("LTST<TValue;>.Node;")]
		private TST.Node left;
//[Signature("LTST<TValue;>.Node;")]
		private TST.Node mid;
//[Signature("LTST<TValue;>.Node;")]
		private TST.Node right;
//[Signature("TValue;")]
		private object val;
//[Modifiers(Modifiers.Final | Modifiers.Synthetic)]
		internal TST tST;
		//[LineNumberTable(33), Modifiers(Modifiers.Static | Modifiers.Synthetic)]
		internal static object access_000(TST.Node node)
		{
			return node.val;
		}
		//[LineNumberTable(33), Modifiers(Modifiers.Static | Modifiers.Synthetic)]
		internal static char access_100(TST.Node node)
		{
			return node.c;
		}
		//[LineNumberTable(33), Modifiers(Modifiers.Static | Modifiers.Synthetic)]
		internal static TST.Node access_200(TST.Node node)
		{
			return node.left;
		}
		//[LineNumberTable(33), Modifiers(Modifiers.Static | Modifiers.Synthetic)]
		internal static TST.Node access_300(TST.Node node)
		{
			return node.right;
		}
		//[LineNumberTable(33), Modifiers(Modifiers.Static | Modifiers.Synthetic)]
		internal static TST.Node access_400(TST.Node node)
		{
			return node.mid;
		}
/*		[LineNumberTable(33), Modifiers(Modifiers.Synthetic)]*/
		
		internal Node(TST tST, TST.1) : this(tST)
		{
		}
		//[LineNumberTable(33), Modifiers(Modifiers.Static | Modifiers.Synthetic)]
		internal static char access_102(TST.Node node, char result)
		{
			node.c = result;
			return result;
		}
		//[LineNumberTable(33), Modifiers(Modifiers.Static | Modifiers.Synthetic)]
		internal static TST.Node access_202(TST.Node node, TST.Node result)
		{
			node.left = result;
			return result;
		}
		//[LineNumberTable(33), Modifiers(Modifiers.Static | Modifiers.Synthetic)]
		internal static TST.Node access_302(TST.Node node, TST.Node result)
		{
			node.right = result;
			return result;
		}
		//[LineNumberTable(33), Modifiers(Modifiers.Static | Modifiers.Synthetic)]
		internal static TST.Node access_402(TST.Node node, TST.Node result)
		{
			node.mid = result;
			return result;
		}
		//[LineNumberTable(33), Modifiers(Modifiers.Static | Modifiers.Synthetic)]
		internal static object access_002(TST.Node node, object result)
		{
			node.val = result;
			return result;
		}
		
		
		private Node(TST tST)
		{
		}
	}
	private int N;
//[Signature("LTST<TValue;>.Node;")]
	private TST.Node root;
	
	
	public TST()
	{
	}
/*	[Signature("(Ljava/lang/String;TValue;)V")]*/
	
	public virtual void put(string str, object obj)
	{
		if (!this.contains(str))
		{
			this.N++;
		}
		this.root = this.put(this.root, str, obj, 0);
	}
	
	
	public virtual string longestPrefixOf(string str)
	{
		if (str == null || java.lang.String.instancehelper_length(str) == 0)
		{
			return null;
		}
		int endIndex = 0;
		TST.Node node = this.root;
		int num = 0;
		while (node != null && num < java.lang.String.instancehelper_length(str))
		{
			int num2 = (int)java.lang.String.instancehelper_charAt(str, num);
			if (num2 < (int)TST.Node.access_100(node))
			{
				node = TST.Node.access_200(node);
			}
			else if (num2 > (int)TST.Node.access_100(node))
			{
				node = TST.Node.access_300(node);
			}
			else
			{
				num++;
				if (TST.Node.access_000(node) != null)
				{
					endIndex = num;
				}
				node = TST.Node.access_400(node);
			}
		}
		return java.lang.String.instancehelper_substring(str, 0, endIndex);
	}
/*	[Signature("(Ljava/lang/String;)TValue;")]*/
	
	public virtual object get(string str)
	{
		if (str == null)
		{
			
			throw new NullPointerException();
		}
		if (java.lang.String.instancehelper_length(str) == 0)
		{
			string arg_20_0 = "key must have length >= 1";
			
			throw new ArgumentException(arg_20_0);
		}
		TST.Node node = this.get(this.root, str, 0);
		if (node == null)
		{
			return null;
		}
		return TST.Node.access_000(node);
	}
/*	[Signature("(LTST<TValue;>.Node;Ljava/lang/String;I)LTST<TValue;>.Node;")]*/
	
	private TST.Node get(TST.Node node, string text, int num)
	{
		if (text == null)
		{
			
			throw new NullPointerException();
		}
		if (java.lang.String.instancehelper_length(text) == 0)
		{
			string arg_20_0 = "key must have length >= 1";
			
			throw new ArgumentException(arg_20_0);
		}
		if (node == null)
		{
			return null;
		}
		int num2 = (int)java.lang.String.instancehelper_charAt(text, num);
		if (num2 < (int)TST.Node.access_100(node))
		{
			return this.get(TST.Node.access_200(node), text, num);
		}
		if (num2 > (int)TST.Node.access_100(node))
		{
			return this.get(TST.Node.access_300(node), text, num);
		}
		if (num < java.lang.String.instancehelper_length(text) - 1)
		{
			return this.get(TST.Node.access_400(node), text, num + 1);
		}
		return node;
	}
	
	
	public virtual bool contains(string str)
	{
		return this.get(str) != null;
	}
/*	[Signature("(LTST<TValue;>.Node;Ljava/lang/String;TValue;I)LTST<TValue;>.Node;")]*/
	
	private TST.Node put(TST.Node node, string text, object obj, int num)
	{
		int num2 = (int)java.lang.String.instancehelper_charAt(text, num);
		if (node == null)
		{
			node = new TST.Node(this, null);
			TST.Node.access_102(node, (char)num2);
		}
		if (num2 < (int)TST.Node.access_100(node))
		{
			TST.Node.access_202(node, this.put(TST.Node.access_200(node), text, obj, num));
		}
		else if (num2 > (int)TST.Node.access_100(node))
		{
			TST.Node.access_302(node, this.put(TST.Node.access_300(node), text, obj, num));
		}
		else if (num < java.lang.String.instancehelper_length(text) - 1)
		{
			TST.Node.access_402(node, this.put(TST.Node.access_400(node), text, obj, num + 1));
		}
		else
		{
			TST.Node.access_002(node, obj);
		}
		return node;
	}
/*	[Signature("(LTST<TValue;>.Node;Ljava/lang/String;LQueue<Ljava/lang/String;>;)V")]*/
	
	private void collect(TST.Node node, string text, Queue queue)
	{
		if (node == null)
		{
			return;
		}
		this.collect(TST.Node.access_200(node), text, queue);
		if (TST.Node.access_000(node) != null)
		{
			queue.enqueue(new StringBuilder().append(text).append(TST.Node.access_100(node)).toString());
		}
		this.collect(TST.Node.access_400(node), new StringBuilder().append(text).append(TST.Node.access_100(node)).toString(), queue);
		this.collect(TST.Node.access_300(node), text, queue);
	}
/*	[Signature("(LTST<TValue;>.Node;Ljava/lang/String;ILjava/lang/String;LQueue<Ljava/lang/String;>;)V")]*/
	
	private void collect(TST.Node node, string text, int num, string text2, Queue queue)
	{
		if (node == null)
		{
			return;
		}
		int num2 = (int)java.lang.String.instancehelper_charAt(text2, num);
		if (num2 == 46 || num2 < (int)TST.Node.access_100(node))
		{
			this.collect(TST.Node.access_200(node), text, num, text2, queue);
		}
		if (num2 == 46 || num2 == (int)TST.Node.access_100(node))
		{
			if (num == java.lang.String.instancehelper_length(text2) - 1 && TST.Node.access_000(node) != null)
			{
				queue.enqueue(new StringBuilder().append(text).append(TST.Node.access_100(node)).toString());
			}
			if (num < java.lang.String.instancehelper_length(text2) - 1)
			{
				this.collect(TST.Node.access_400(node), new StringBuilder().append(text).append(TST.Node.access_100(node)).toString(), num + 1, text2, queue);
			}
		}
		if (num2 == 46 || num2 > (int)TST.Node.access_100(node))
		{
			this.collect(TST.Node.access_300(node), text, num, text2, queue);
		}
	}
/*	[Signature("()Ljava/lang/Iterable<Ljava/lang/String;>;")]*/
	
	public virtual Iterable keys()
	{
		Queue queue = new Queue();
		this.collect(this.root, "", queue);
		return queue;
	}
	public virtual int Size
	{
		return this.N;
	}
/*	[Signature("(Ljava/lang/String;)Ljava/lang/Iterable<Ljava/lang/String;>;")]*/
	
	public virtual Iterable prefixMatch(string str)
	{
		Queue queue = new Queue();
		TST.Node node = this.get(this.root, str, 0);
		if (node == null)
		{
			return queue;
		}
		if (TST.Node.access_000(node) != null)
		{
			queue.enqueue(str);
		}
		this.collect(TST.Node.access_400(node), str, queue);
		return queue;
	}
/*	[Signature("(Ljava/lang/String;)Ljava/lang/Iterable<Ljava/lang/String;>;")]*/
	
	public virtual Iterable wildcardMatch(string str)
	{
		Queue queue = new Queue();
		this.collect(this.root, "", 0, str, queue);
		return queue;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		TST tST = new TST();
		int num = 0;
		while (!StdIn.IsEmpty)
		{
			string str = StdIn.readString();
			tST.put(str, Integer.valueOf(num));
			num++;
		}
		Iterator iterator = tST.keys().iterator();
		while (iterator.hasNext())
		{
			string str = (string)iterator.next();
			StdOut.println(new StringBuilder().append(str).append(" ").append(tST.get(str)).toString());
		}
	}
}




public class Vector
{
	private int N;
	private double[] data;
	
	
	public virtual double dot(Vector v)
	{
		if (this.N != v.N)
		{
			string arg_18_0 = "Dimensions don't agree";
			
			throw new ArgumentException(arg_18_0);
		}
		double num = (double)0f;
		for (int i = 0; i < this.N; i++)
		{
			num += this.data[i] * v.data[i];
		}
		return num;
	}
	
	
	public virtual Vector minus(Vector v)
	{
		if (this.N != v.N)
		{
			string arg_18_0 = "Dimensions don't agree";
			
			throw new ArgumentException(arg_18_0);
		}
		Vector vector = new Vector(this.N);
		for (int i = 0; i < this.N; i++)
		{
			vector.data[i] = this.data[i] - v.data[i];
		}
		return vector;
	}
	
	
	public virtual double magnitude()
	{
		return java.lang.Math.sqrt(this.dot(this));
	}
	
	
	public Vector(int i)
	{
		this.N = i;
		this.data = new double[this.N];
	}
	
	
	public virtual Vector times(double d)
	{
		Vector vector = new Vector(this.N);
		for (int i = 0; i < this.N; i++)
		{
			vector.data[i] = d * this.data[i];
		}
		return vector;
	}
	
	
	public Vector(params double[] darr)
	{
		this.N = darr.Length;
		this.data = new double[this.N];
		for (int i = 0; i < this.N; i++)
		{
			this.data[i] = darr[i];
		}
	}
	
	
	public virtual Vector plus(Vector v)
	{
		if (this.N != v.N)
		{
			string arg_18_0 = "Dimensions don't agree";
			
			throw new ArgumentException(arg_18_0);
		}
		Vector vector = new Vector(this.N);
		for (int i = 0; i < this.N; i++)
		{
			vector.data[i] = this.data[i] + v.data[i];
		}
		return vector;
	}
	
	
	public virtual double distanceTo(Vector v)
	{
		if (this.N != v.N)
		{
			string arg_18_0 = "Dimensions don't agree";
			
			throw new ArgumentException(arg_18_0);
		}
		return this.minus(v).magnitude();
	}
	
	
	public virtual Vector direction()
	{
		if (this.magnitude() == (double)0f)
		{
			string arg_17_0 = "Zero-vector has no direction";
			
			throw new java.lang.ArithmeticException(arg_17_0);
		}
		return this.times((double)1f / this.magnitude());
	}
	public virtual int length()
	{
		return this.N;
	}
	
	public virtual double cartesian(int i)
	{
		return this.data[i];
	}
	
	
	public override string ToString()
	{
		string text = "";
		for (int i = 0; i < this.N; i++)
		{
			text = new StringBuilder().append(text).append(this.data[i]).append(" ").toString();
		}
		return text;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		double[] darr = new double[]
		{
			(double)1f,
			2.0,
			3.0,
			4.0
		};
		double[] darr2 = new double[]
		{
			5.0,
			2.0,
			4.0,
			(double)1f
		};
		Vector vector = new Vector(darr);
		Vector vector2 = new Vector(darr2);
		StdOut.println(new StringBuilder().append("   x       = ").append(vector).toString());
		StdOut.println(new StringBuilder().append("   y       = ").append(vector2).toString());
		Vector vector3 = vector.plus(vector2);
		StdOut.println(new StringBuilder().append("   z       = ").append(vector3).toString());
		vector3 = vector3.times(10.0);
		StdOut.println(new StringBuilder().append(" 10z       = ").append(vector3).toString());
		StdOut.println(new StringBuilder().append("  |x|      = ").append(vector.magnitude()).toString());
		StdOut.println(new StringBuilder().append(" <x, y>    = ").append(vector.dot(vector2)).toString());
		StdOut.println(new StringBuilder().append("dist(x, y) = ").append(vector.distanceTo(vector2)).toString());
		StdOut.println(new StringBuilder().append("dir(x)     = ").append(vector.direction()).toString());
	}
}



public class WhiteFilter
{
	
	
	public WhiteFilter()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		SET sET = new SET();
		
		In @in = new In(strarr[0]);
		while (!@in.IsEmpty)
		{
			string text = @in.readString();
			sET.add(text);
		}
		while (!StdIn.IsEmpty)
		{
			string text = StdIn.readString();
			if (sET.contains(text))
			{
				StdOut.println(text);
			}
		}
	}
}
