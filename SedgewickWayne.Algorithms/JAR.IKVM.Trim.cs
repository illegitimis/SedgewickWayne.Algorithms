using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.ComponentModel;


public class BinaryDump
{
	
	
	public BinaryDump()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		int num = 16;
		if (strarr.Length == 1)
		{
			num = Integer.parseInt(strarr[0]);
		}
		int num2 = 0;
		while (!BinaryStdIn.IsEmpty)
		{
			if (num == 0)
			{
				BinaryStdIn.readBoolean();
			}
			else
			{
				if (num2 != 0)
				{
					bool expr_28 = num2 != 0;
					int expr_2A = num;
					if (expr_2A == -1 || (expr_28 ? 1 : 0) % expr_2A == 0)
					{
						StdOut.println();
					}
				}
				if (BinaryStdIn.readBoolean())
				{
					StdOut.print(1);
				}
				else
				{
					StdOut.print(0);
				}
			}
			num2++;
		}
		if (num != 0)
		{
			StdOut.println();
		}
		StdOut.println(new StringBuilder().append(num2).append(" bits").toString());
	}
}

public sealed class BinaryIn
{
	private const int EOF = -1;
	private BufferedInputStream @in;
	private int buffer;
	private int N;
	
	
	private void fillBuffer()
	{
		try
		{
			this.buffer = this.@in.read();
			this.N = 8;
		}
		catch (IOException arg_1C_0)
		{
			goto IL_20;
		}
		return;
		IL_20:
		System.err.println("EOF");
		this.buffer = -1;
		this.N = -1;
	}
	public virtual bool IsEmpty
	{
		return this.buffer == -1;
	}
	
	
	public virtual char readChar()
	{
		if (this.IsEmpty)
		{
			string arg_12_0 = "Reading from empty input stream";
			
			throw new RuntimeException(arg_12_0);
		}
		int num;
		if (this.N == 8)
		{
			num = this.buffer;
			this.fillBuffer();
			return (char)(num & 255);
		}
		num = this.buffer;
		num <<= 8 - this.N;
		int n = this.N;
		this.fillBuffer();
		if (this.IsEmpty)
		{
			string arg_6B_0 = "Reading from empty input stream";
			
			throw new RuntimeException(arg_6B_0);
		}
		this.N = n;
		num |= (int)((uint)this.buffer >> this.N);
		return (char)(num & 255);
	}
	
	
	public virtual bool readBoolean()
	{
		if (this.IsEmpty)
		{
			string arg_12_0 = "Reading from empty input stream";
			
			throw new RuntimeException(arg_12_0);
		}
		this.N--;
		int result = ((this.buffer >> this.N & 1) == 1) ? 1 : 0;
		if (this.N == 0)
		{
			this.fillBuffer();
		}
		return result != 0;
	}
	
	
	public virtual int readInt()
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			int num2 = (int)this.readChar();
			num <<= 8;
			num |= num2;
		}
		return num;
	}
	
	
	public virtual long readLong()
	{
		long num = 0L;
		for (int i = 0; i < 8; i++)
		{
			int num2 = (int)this.readChar();
			num <<= 8;
			num |= (long)num2;
		}
		return num;
	}
	
	
	public BinaryIn(string str)
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
				this.@in = new BufferedInputStream(inputStream);
				this.fillBuffer();
				goto IL_74;
			}
			FileInputStream fileInputStream = new FileInputStream(file);
			this.@in = new BufferedInputStream(fileInputStream);
			this.fillBuffer();
		}
		catch (IOException arg_71_0)
		{
			goto IL_76;
		}
		return;
		IL_74:
		return;
		IL_76:
		System.err.println(new StringBuilder().append("Could not open ").append(str).toString());
	}
	
	
	public BinaryIn()
	{
		BufferedInputStream.__<clinit>();
		this.@in = new BufferedInputStream(System.@in);
		this.fillBuffer();
	}
	
	
	public BinaryIn(InputStream @is)
	{
		this.@in = new BufferedInputStream(@is);
		this.fillBuffer();
	}
	
	
	public BinaryIn(Socket s)
	{
		try
		{
			InputStream inputStream = s.getInputStream();
			this.@in = new BufferedInputStream(inputStream);
			this.fillBuffer();
		}
		catch (IOException arg_25_0)
		{
			goto IL_29;
		}
		return;
		IL_29:
		System.err.println(new StringBuilder().append("Could not open ").append(s).toString());
	}
	
	
	public BinaryIn(URL url)
	{
		try
		{
			URLConnection uRLConnection = url.openConnection();
			InputStream inputStream = uRLConnection.getInputStream();
			this.@in = new BufferedInputStream(inputStream);
			this.fillBuffer();
		}
		catch (IOException arg_2C_0)
		{
			goto IL_30;
		}
		return;
		IL_30:
		System.err.println(new StringBuilder().append("Could not open ").append(url).toString());
	}
	public virtual bool exists()
	{
		return this.@in != null;
	}
	
	
	public virtual char readChar(int i)
	{
		if (i < 1 || i > 16)
		{
			string arg_28_0 = new StringBuilder().append("Illegal value of r = ").append(i).toString();
			
			throw new RuntimeException(arg_28_0);
		}
		if (i == 8)
		{
			return this.readChar();
		}
		int num = 0;
		for (int j = 0; j < i; j++)
		{
			num = (int)((ushort)(num << 1));
			int num2 = this.readBoolean() ? 1 : 0;
			if (num2 != 0)
			{
				num = (int)((ushort)(num | 1));
			}
		}
		return (char)num;
	}
	
	
	public virtual string readString()
	{
		if (this.IsEmpty)
		{
			string arg_12_0 = "Reading from empty input stream";
			
			throw new RuntimeException(arg_12_0);
		}
		StringBuilder stringBuilder = new StringBuilder();
		while (!this.IsEmpty)
		{
			int c = (int)this.readChar();
			stringBuilder.append((char)c);
		}
		return stringBuilder.toString();
	}
	
	
	public virtual short readShort()
	{
		int num = 0;
		for (int i = 0; i < 2; i++)
		{
			int num2 = (int)this.readChar();
			num = (int)((short)(num << 8));
			num = (int)((short)(num | num2));
		}
		return (short)num;
	}
	
	
	public virtual int readInt(int i)
	{
		if (i < 1 || i > 32)
		{
			string arg_28_0 = new StringBuilder().append("Illegal value of r = ").append(i).toString();
			
			throw new RuntimeException(arg_28_0);
		}
		if (i == 32)
		{
			return this.readInt();
		}
		int num = 0;
		for (int j = 0; j < i; j++)
		{
			num <<= 1;
			int num2 = this.readBoolean() ? 1 : 0;
			if (num2 != 0)
			{
				num |= 1;
			}
		}
		return num;
	}
	
	
	public virtual double readDouble()
	{
		DoubleConverter doubleConverter;
		return DoubleConverter.ToDouble(this.readLong(), ref doubleConverter);
	}
	
	
	public virtual float readFloat()
	{
		FloatConverter floatConverter;
		return FloatConverter.ToFloat(this.readInt(), ref floatConverter);
	}
	
	
	public virtual byte readByte()
	{
		int num = (int)this.readChar();
		return (byte)((sbyte)(num & 255));
	}
	
	
	/**/public static void main(string[] strarr)
	{
		BinaryIn binaryIn = new BinaryIn(strarr[0]);
		BinaryOut.__<clinit>();
		BinaryOut binaryOut = new BinaryOut(strarr[1]);
		while (!binaryIn.IsEmpty)
		{
			int ch = (int)binaryIn.readChar();
			binaryOut.write((char)ch);
		}
		binaryOut.flush();
	}
}

public sealed class BinaryOut
{
	private BufferedOutputStream @out;
	private int buffer;
	private int N;
//[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
	internal static bool s_assertionsDisabled;
	
	
	
	
	public BinaryOut(string str)
	{
		IOException ex;
		try
		{
			FileOutputStream fileOutputStream = new FileOutputStream(str);
			this.@out = new BufferedOutputStream(fileOutputStream);
		}
		catch (IOException arg_20_0)
		{
			ex = ByteCodeHelper.MapException<IOException>(arg_20_0, ByteCodeHelper.MapFlags.NoRemapping);
			goto IL_2A;
		}
		return;
		IL_2A:
		IOException this2 = ex;
		Throwable.instancehelper_printStackTrace(this2);
	}
	
	
	public virtual void write(char ch)
	{
		if (ch < '\0' || ch >= 'Ā')
		{
			string arg_2D_0 = new StringBuilder().append("Illegal 8-bit char = ").append(ch).toString();
			
			throw new RuntimeException(arg_2D_0);
		}
		this.writeByte((int)ch);
	}
	
	
	public virtual void flush()
	{
		this.clearBuffer();
		IOException ex;
		try
		{
			this.@out.flush();
		}
		catch (IOException arg_16_0)
		{
			ex = ByteCodeHelper.MapException<IOException>(arg_16_0, ByteCodeHelper.MapFlags.NoRemapping);
			goto IL_20;
		}
		return;
		IL_20:
		IOException this2 = ex;
		Throwable.instancehelper_printStackTrace(this2);
	}
	
	
	private void clearBuffer()
	{
		if (this.N == 0)
		{
			return;
		}
		if (this.N > 0)
		{
			this.buffer <<= 8 - this.N;
		}
		IOException ex;
		try
		{
			this.@out.write(this.buffer);
		}
		catch (IOException arg_40_0)
		{
			ex = ByteCodeHelper.MapException<IOException>(arg_40_0, ByteCodeHelper.MapFlags.NoRemapping);
			goto IL_4A;
		}
		goto IL_56;
		IL_4A:
		IOException this2 = ex;
		Throwable.instancehelper_printStackTrace(this2);
		IL_56:
		this.N = 0;
		this.buffer = 0;
	}
	
	
	private void writeBit(bool flag)
	{
		this.buffer <<= 1;
		if (flag)
		{
			this.buffer |= 1;
		}
		this.N++;
		if (this.N == 8)
		{
			this.clearBuffer();
		}
	}
	
	
	private void writeByte(int num)
	{
		if (!BinaryOut.s_assertionsDisabled && (num < 0 || num >= 256))
		{
			
			throw new AssertionError();
		}
		if (this.N == 0)
		{
			IOException ex;
			try
			{
				this.@out.write(num);
			}
			catch (IOException arg_37_0)
			{
				ex = ByteCodeHelper.MapException<IOException>(arg_37_0, ByteCodeHelper.MapFlags.NoRemapping);
				goto IL_41;
			}
			return;
			IL_41:
			IOException this2 = ex;
			Throwable.instancehelper_printStackTrace(this2);
			return;
		}
		for (int i = 0; i < 8; i++)
		{
			int num2 = (((uint)num >> 8 - i - 1 & 1u) == 1u) ? 1 : 0;
			this.writeBit(num2 != 0);
		}
	}
	
	
	public virtual void write(int i)
	{
		this.writeByte((int)((uint)i >> 24 & 255u));
		this.writeByte((int)((uint)i >> 16 & 255u));
		this.writeByte((int)((uint)i >> 8 & 255u));
		this.writeByte((int)((uint)i >> 0 & 255u));
	}
	
	
	public virtual void write(long l)
	{
		this.writeByte((int)((ulong)l >> 56 & (ulong)255));
		this.writeByte((int)((ulong)l >> 48 & (ulong)255));
		this.writeByte((int)((ulong)l >> 40 & (ulong)255));
		this.writeByte((int)((ulong)l >> 32 & (ulong)255));
		this.writeByte((int)((ulong)l >> 24 & (ulong)255));
		this.writeByte((int)((ulong)l >> 16 & (ulong)255));
		this.writeByte((int)((ulong)l >> 8 & (ulong)255));
		this.writeByte((int)((ulong)l >> 0 & (ulong)255));
	}
	
	
	public virtual void write(char ch, int i)
	{
		if (i == 8)
		{
			this.write(ch);
			return;
		}
		if (i < 1 || i > 16)
		{
			string arg_38_0 = new StringBuilder().append("Illegal value for r = ").append(i).toString();
			
			throw new RuntimeException(arg_38_0);
		}
		if (ch < '\0' || (int)ch >= 1 << i)
		{
			string arg_7A_0 = new StringBuilder().append("Illegal ").append(i).append("-bit char = ").append(ch).toString();
			
			throw new RuntimeException(arg_7A_0);
		}
		for (int j = 0; j < i; j++)
		{
			int num = ((ch >> (i - j - 1 & 31) & '\u0001') == '\u0001') ? 1 : 0;
			this.writeBit(num != 0);
		}
	}
	
	
	public BinaryOut(OutputStream os)
	{
		this.@out = new BufferedOutputStream(os);
	}
	
	
	public BinaryOut()
	{
		this.@out = new BufferedOutputStream(System.@out);
	}
	
	
	public BinaryOut(Socket s)
	{
		IOException ex;
		try
		{
			OutputStream outputStream = s.getOutputStream();
			this.@out = new BufferedOutputStream(outputStream);
		}
		catch (IOException arg_20_0)
		{
			ex = ByteCodeHelper.MapException<IOException>(arg_20_0, ByteCodeHelper.MapFlags.NoRemapping);
			goto IL_2A;
		}
		return;
		IL_2A:
		IOException this2 = ex;
		Throwable.instancehelper_printStackTrace(this2);
	}
	
	
	public virtual void close()
	{
		this.flush();
		IOException ex;
		try
		{
			this.@out.close();
		}
		catch (IOException arg_16_0)
		{
			ex = ByteCodeHelper.MapException<IOException>(arg_16_0, ByteCodeHelper.MapFlags.NoRemapping);
			goto IL_20;
		}
		return;
		IL_20:
		IOException this2 = ex;
		Throwable.instancehelper_printStackTrace(this2);
	}
	
	
	public virtual void write(bool b)
	{
		this.writeBit(b);
	}
	
	
	public virtual void write(byte b)
	{
		int num = (int)((sbyte)b);
		this.writeByte(num & 255);
	}
	
	
	public virtual void write(int i1, int i2)
	{
		if (i2 == 32)
		{
			this.write(i1);
			return;
		}
		if (i2 < 1 || i2 > 32)
		{
			string arg_37_0 = new StringBuilder().append("Illegal value for r = ").append(i2).toString();
			
			throw new RuntimeException(arg_37_0);
		}
		if (i1 < 0 || i1 >= 1 << i2)
		{
			string arg_79_0 = new StringBuilder().append("Illegal ").append(i2).append("-bit char = ").append(i1).toString();
			
			throw new RuntimeException(arg_79_0);
		}
		for (int j = 0; j < i2; j++)
		{
			int num = (((uint)i1 >> i2 - j - 1 & 1u) == 1u) ? 1 : 0;
			this.writeBit(num != 0);
		}
	}
	
	
	public virtual void write(double d)
	{
		DoubleConverter doubleConverter;
		this.write(DoubleConverter.ToLong(d, ref doubleConverter));
	}
	
	
	public virtual void write(float f)
	{
		FloatConverter floatConverter;
		this.write(FloatConverter.ToInt(f, ref floatConverter));
	}
	
	
	public virtual void write(short s)
	{
		this.writeByte((int)((uint)s >> 8 & 255u));
		this.writeByte((int)((uint)s >> 0 & 255u));
	}
	
	
	public virtual void write(string str)
	{
		for (int i = 0; i < java.lang.String.instancehelper_length(str); i++)
		{
			this.write(java.lang.String.instancehelper_charAt(str, i));
		}
	}
	
	
	public virtual void write(string str, int i)
	{
		for (int j = 0; j < java.lang.String.instancehelper_length(str); j++)
		{
			this.write(java.lang.String.instancehelper_charAt(str, j), i);
		}
	}
	
	
	/**/public static void main(string[] strarr)
	{
		string str = strarr[0];
		BinaryOut binaryOut = new BinaryOut(str);
		BinaryIn binaryIn = new BinaryIn();
		while (!binaryIn.IsEmpty)
		{
			int ch = (int)binaryIn.readChar();
			binaryOut.write((char)ch);
		}
		binaryOut.flush();
	}
	
	static BinaryOut()
	{
		BinaryOut.s_assertionsDisabled = !ClassLiteral<BinaryOut>.Value.desiredAssertionStatus();
	}
}

public sealed class BinaryStdIn
{
	private static BufferedInputStream @in;
	private const int EOF = -1;
	private static int buffer;
	private static int N;
	
	
	public static bool IsEmpty
	{
		return BinaryStdIn.buffer == -1;
	}
	
	
	public static bool readBoolean()
	{
		if (BinaryStdIn.IsEmpty)
		{
			string arg_11_0 = "Reading from empty input stream";
			
			throw new RuntimeException(arg_11_0);
		}
		BinaryStdIn.N--;
		int result = ((BinaryStdIn.buffer >> BinaryStdIn.N & 1) == 1) ? 1 : 0;
		if (BinaryStdIn.N == 0)
		{
			BinaryStdIn.fillBuffer();
		}
		return result != 0;
	}
	
	
	public static string readString()
	{
		if (BinaryStdIn.IsEmpty)
		{
			string arg_11_0 = "Reading from empty input stream";
			
			throw new RuntimeException(arg_11_0);
		}
		StringBuilder stringBuilder = new StringBuilder();
		while (!BinaryStdIn.IsEmpty)
		{
			int c = (int)BinaryStdIn.readChar();
			stringBuilder.append((char)c);
		}
		return stringBuilder.toString();
	}
	
	
	public static int readInt()
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			int num2 = (int)BinaryStdIn.readChar();
			num <<= 8;
			num |= num2;
		}
		return num;
	}
	
	
	public static char readChar(int i)
	{
		if (i < 1 || i > 16)
		{
			string arg_28_0 = new StringBuilder().append("Illegal value of r = ").append(i).toString();
			
			throw new RuntimeException(arg_28_0);
		}
		if (i == 8)
		{
			return BinaryStdIn.readChar();
		}
		int num = 0;
		for (int j = 0; j < i; j++)
		{
			num = (int)((ushort)(num << 1));
			int num2 = BinaryStdIn.readBoolean() ? 1 : 0;
			if (num2 != 0)
			{
				num = (int)((ushort)(num | 1));
			}
		}
		return (char)num;
	}
	
	
	public static char readChar()
	{
		if (BinaryStdIn.IsEmpty)
		{
			string arg_11_0 = "Reading from empty input stream";
			
			throw new RuntimeException(arg_11_0);
		}
		int num;
		if (BinaryStdIn.N == 8)
		{
			num = BinaryStdIn.buffer;
			BinaryStdIn.fillBuffer();
			return (char)(num & 255);
		}
		num = BinaryStdIn.buffer;
		num <<= 8 - BinaryStdIn.N;
		int n = BinaryStdIn.N;
		BinaryStdIn.fillBuffer();
		if (BinaryStdIn.IsEmpty)
		{
			string arg_62_0 = "Reading from empty input stream";
			
			throw new RuntimeException(arg_62_0);
		}
		BinaryStdIn.N = n;
		num |= (int)((uint)BinaryStdIn.buffer >> BinaryStdIn.N);
		return (char)(num & 255);
	}
	
	
	public static int readInt(int i)
	{
		if (i < 1 || i > 32)
		{
			string arg_28_0 = new StringBuilder().append("Illegal value of r = ").append(i).toString();
			
			throw new RuntimeException(arg_28_0);
		}
		if (i == 32)
		{
			return BinaryStdIn.readInt();
		}
		int num = 0;
		for (int j = 0; j < i; j++)
		{
			num <<= 1;
			int num2 = BinaryStdIn.readBoolean() ? 1 : 0;
			if (num2 != 0)
			{
				num |= 1;
			}
		}
		return num;
	}
	
	
	private static void fillBuffer()
	{
		try
		{
			BinaryStdIn.buffer = BinaryStdIn.@in.read();
			BinaryStdIn.N = 8;
		}
		catch (IOException arg_19_0)
		{
			goto IL_1D;
		}
		return;
		IL_1D:
		System.@out.println("EOF");
		BinaryStdIn.buffer = -1;
		BinaryStdIn.N = -1;
	}
	
	
	public static long readLong()
	{
		long num = 0L;
		for (int i = 0; i < 8; i++)
		{
			int num2 = (int)BinaryStdIn.readChar();
			num <<= 8;
			num |= (long)num2;
		}
		return num;
	}
	
	
	private BinaryStdIn()
	{
	}
	
	
	public static void close()
	{
		IOException ex;
		try
		{
			BinaryStdIn.@in.close();
		}
		catch (IOException arg_0F_0)
		{
			ex = ByteCodeHelper.MapException<IOException>(arg_0F_0, ByteCodeHelper.MapFlags.NoRemapping);
			goto IL_19;
		}
		return;
		IL_19:
		IOException @this = ex;
		Throwable.instancehelper_printStackTrace(@this);
		string arg_2F_0 = "Could not close BinaryStdIn";
		
		throw new RuntimeException(arg_2F_0);
	}
	
	
	public static short readShort()
	{
		int num = 0;
		for (int i = 0; i < 2; i++)
		{
			int num2 = (int)BinaryStdIn.readChar();
			num = (int)((short)(num << 8));
			num = (int)((short)(num | num2));
		}
		return (short)num;
	}
	
	
	public static double readDouble()
	{
		DoubleConverter doubleConverter;
		return DoubleConverter.ToDouble(BinaryStdIn.readLong(), ref doubleConverter);
	}
	
	
	public static float readFloat()
	{
		FloatConverter floatConverter;
		return FloatConverter.ToFloat(BinaryStdIn.readInt(), ref floatConverter);
	}
	
	
	public static byte readByte()
	{
		int num = (int)BinaryStdIn.readChar();
		return (byte)((sbyte)(num & 255));
	}
	
	
	/**//**/public static void main(string[] strarr)
	{
		while (!BinaryStdIn.IsEmpty)
		{
			int ch = (int)BinaryStdIn.readChar();
			BinaryStdOut.write((char)ch);
		}
		BinaryStdOut.flush();
	}
	
	static BinaryStdIn()
	{
		BufferedInputStream.__<clinit>();
		BinaryStdIn.@in = new BufferedInputStream(System.@in);
		BinaryStdIn.fillBuffer();
	}
}

public sealed class BinaryStdOut
{
	private static BufferedOutputStream @out;
	private static int buffer;
	private static int N;
//[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
	internal static bool s_assertionsDisabled;
	
	
	
	
	public static void write(int i)
	{
		BinaryStdOut.writeByte((int)((uint)i >> 24 & 255u));
		BinaryStdOut.writeByte((int)((uint)i >> 16 & 255u));
		BinaryStdOut.writeByte((int)((uint)i >> 8 & 255u));
		BinaryStdOut.writeByte((int)((uint)i >> 0 & 255u));
	}
	
	
	public static void write(int i1, int i2)
	{
		if (i2 == 32)
		{
			BinaryStdOut.write(i1);
			return;
		}
		if (i2 < 1 || i2 > 32)
		{
			string arg_36_0 = new StringBuilder().append("Illegal value for r = ").append(i2).toString();
			
			throw new RuntimeException(arg_36_0);
		}
		if (i1 < 0 || i1 >= 1 << i2)
		{
			string arg_78_0 = new StringBuilder().append("Illegal ").append(i2).append("-bit char = ").append(i1).toString();
			
			throw new RuntimeException(arg_78_0);
		}
		for (int j = 0; j < i2; j++)
		{
			int num = (((uint)i1 >> i2 - j - 1 & 1u) == 1u) ? 1 : 0;
			BinaryStdOut.writeBit(num != 0);
		}
	}
	
	
	public static void close()
	{
		BinaryStdOut.flush();
		IOException ex;
		try
		{
			BinaryStdOut.@out.close();
		}
		catch (IOException arg_14_0)
		{
			ex = ByteCodeHelper.MapException<IOException>(arg_14_0, ByteCodeHelper.MapFlags.NoRemapping);
			goto IL_1E;
		}
		return;
		IL_1E:
		IOException @this = ex;
		Throwable.instancehelper_printStackTrace(@this);
	}
	
	
	public static void write(char ch, int i)
	{
		if (i == 8)
		{
			BinaryStdOut.write(ch);
			return;
		}
		if (i < 1 || i > 16)
		{
			string arg_37_0 = new StringBuilder().append("Illegal value for r = ").append(i).toString();
			
			throw new RuntimeException(arg_37_0);
		}
		if (ch < '\0' || (int)ch >= 1 << i)
		{
			string arg_79_0 = new StringBuilder().append("Illegal ").append(i).append("-bit char = ").append(ch).toString();
			
			throw new RuntimeException(arg_79_0);
		}
		for (int j = 0; j < i; j++)
		{
			int num = ((ch >> (i - j - 1 & 31) & '\u0001') == '\u0001') ? 1 : 0;
			BinaryStdOut.writeBit(num != 0);
		}
	}
	
	
	public static void write(bool b)
	{
		BinaryStdOut.writeBit(b);
	}
	
	
	public static void write(string str)
	{
		for (int i = 0; i < java.lang.String.instancehelper_length(str); i++)
		{
			BinaryStdOut.write(java.lang.String.instancehelper_charAt(str, i));
		}
	}
	
	
	public static void write(char ch)
	{
		if (ch < '\0' || ch >= 'Ā')
		{
			string arg_2D_0 = new StringBuilder().append("Illegal 8-bit char = ").append(ch).toString();
			
			throw new RuntimeException(arg_2D_0);
		}
		BinaryStdOut.writeByte((int)ch);
	}
	
	
	public static void flush()
	{
		BinaryStdOut.clearBuffer();
		IOException ex;
		try
		{
			BinaryStdOut.@out.flush();
		}
		catch (IOException arg_14_0)
		{
			ex = ByteCodeHelper.MapException<IOException>(arg_14_0, ByteCodeHelper.MapFlags.NoRemapping);
			goto IL_1E;
		}
		return;
		IL_1E:
		IOException @this = ex;
		Throwable.instancehelper_printStackTrace(@this);
	}
	
	
	private static void clearBuffer()
	{
		if (BinaryStdOut.N == 0)
		{
			return;
		}
		if (BinaryStdOut.N > 0)
		{
			BinaryStdOut.buffer <<= 8 - BinaryStdOut.N;
		}
		IOException ex;
		try
		{
			BinaryStdOut.@out.write(BinaryStdOut.buffer);
		}
		catch (IOException arg_39_0)
		{
			ex = ByteCodeHelper.MapException<IOException>(arg_39_0, ByteCodeHelper.MapFlags.NoRemapping);
			goto IL_43;
		}
		goto IL_4F;
		IL_43:
		IOException @this = ex;
		Throwable.instancehelper_printStackTrace(@this);
		IL_4F:
		BinaryStdOut.N = 0;
		BinaryStdOut.buffer = 0;
	}
	
	
	private static void writeBit(bool flag)
	{
		BinaryStdOut.buffer <<= 1;
		if (flag)
		{
			BinaryStdOut.buffer |= 1;
		}
		BinaryStdOut.N++;
		if (BinaryStdOut.N == 8)
		{
			BinaryStdOut.clearBuffer();
		}
	}
	
	
	private static void writeByte(int num)
	{
		if (!BinaryStdOut.s_assertionsDisabled && (num < 0 || num >= 256))
		{
			
			throw new AssertionError();
		}
		if (BinaryStdOut.N == 0)
		{
			IOException ex;
			try
			{
				BinaryStdOut.@out.write(num);
			}
			catch (IOException arg_35_0)
			{
				ex = ByteCodeHelper.MapException<IOException>(arg_35_0, ByteCodeHelper.MapFlags.NoRemapping);
				goto IL_3F;
			}
			return;
			IL_3F:
			IOException @this = ex;
			Throwable.instancehelper_printStackTrace(@this);
			return;
		}
		for (int i = 0; i < 8; i++)
		{
			int num2 = (((uint)num >> 8 - i - 1 & 1u) == 1u) ? 1 : 0;
			BinaryStdOut.writeBit(num2 != 0);
		}
	}
	
	
	public static void write(long l)
	{
		BinaryStdOut.writeByte((int)((ulong)l >> 56 & (ulong)255));
		BinaryStdOut.writeByte((int)((ulong)l >> 48 & (ulong)255));
		BinaryStdOut.writeByte((int)((ulong)l >> 40 & (ulong)255));
		BinaryStdOut.writeByte((int)((ulong)l >> 32 & (ulong)255));
		BinaryStdOut.writeByte((int)((ulong)l >> 24 & (ulong)255));
		BinaryStdOut.writeByte((int)((ulong)l >> 16 & (ulong)255));
		BinaryStdOut.writeByte((int)((ulong)l >> 8 & (ulong)255));
		BinaryStdOut.writeByte((int)((ulong)l >> 0 & (ulong)255));
	}
	
	
	private BinaryStdOut()
	{
	}
	
	
	public static void write(byte b)
	{
		int num = (int)((sbyte)b);
		BinaryStdOut.writeByte(num & 255);
	}
	
	
	public static void write(double d)
	{
		DoubleConverter doubleConverter;
		BinaryStdOut.write(DoubleConverter.ToLong(d, ref doubleConverter));
	}
	
	
	public static void write(float f)
	{
		FloatConverter floatConverter;
		BinaryStdOut.write(FloatConverter.ToInt(f, ref floatConverter));
	}
	
	
	public static void write(short s)
	{
		BinaryStdOut.writeByte((int)((uint)s >> 8 & 255u));
		BinaryStdOut.writeByte((int)((uint)s >> 0 & 255u));
	}
	
	
	public static void write(string str, int i)
	{
		for (int j = 0; j < java.lang.String.instancehelper_length(str); j++)
		{
			BinaryStdOut.write(java.lang.String.instancehelper_charAt(str, j), i);
		}
	}
	
	
	/**//**/public static void main(string[] strarr)
	{
		int num = Integer.parseInt(strarr[0]);
		for (int i = 0; i < num; i++)
		{
			BinaryStdOut.write(i);
		}
		BinaryStdOut.flush();
	}
	
	static BinaryStdOut()
	{
		BinaryStdOut.s_assertionsDisabled = !ClassLiteral<BinaryStdOut>.Value.desiredAssertionStatus();
		BinaryStdOut.@out = new BufferedOutputStream(System.@out);
	}
}

public class Cat
{
	
	
	private Cat()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		Out.__<clinit>();
		Out @out = new Out(strarr[strarr.Length - 1]);
		for (int i = 0; i < strarr.Length - 1; i++)
		{
			
			In @in = new In(strarr[i]);
			string obj = @in.readAll();
			@out.println(obj);
			@in.close();
		}
		@out.close();
	}
}

public class Copy
{
	
	
	public Copy()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		while (!BinaryStdIn.IsEmpty)
		{
			int ch = (int)BinaryStdIn.readChar();
			BinaryStdOut.write((char)ch);
		}
		BinaryStdOut.flush();
	}
}

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


using java.awt.@event;
using java.awt.geom;
using java.awt.image;
using javax.imageio;
using javax.swing;


/*[Implements(new string[]
{
	"java.awt.event.ActionListener",
	"java.awt.event.MouseListener",
	"java.awt.event.MouseMotionListener",
	"java.awt.event.KeyListener"
})]*/
public sealed class Draw, ActionListener, EventListener, MouseListener, MouseMotionListener, KeyListener
{
	internal static Color __BLACK;
	internal static Color __BLUE;
	internal static Color __CYAN;
	internal static Color __DARK_GRAY;
	internal static Color __GRAY;
	internal static Color __GREEN;
	internal static Color __LIGHT_GRAY;
	internal static Color __MAGENTA;
	internal static Color __ORANGE;
	internal static Color __PINK;
	internal static Color __RED;
	internal static Color __WHITE;
	internal static Color __YELLOW;
	internal static Color __BOOK_BLUE;
	internal static Color __BOOK_RED;
//[Modifiers(Modifiers.Private | Modifiers.Static | Modifiers.Final)]
	private static Color DEFAULT_PEN_COLOR;
//[Modifiers(Modifiers.Private | Modifiers.Static | Modifiers.Final)]
	private static Color DEFAULT_CLEAR_COLOR;
	private const double BORDER = 0.05;
	private const double DEFAULT_XMIN = 0.0;
	private const double DEFAULT_XMAX = 1.0;
	private const double DEFAULT_YMIN = 0.0;
	private const double DEFAULT_YMAX = 1.0;
	private const int DEFAULT_SIZE = 512;
	private const double DEFAULT_PEN_RADIUS = 0.002;
//[Modifiers(Modifiers.Private | Modifiers.Static | Modifiers.Final)]
	private static Font DEFAULT_FONT;
	private Color penColor;
	private int width;
	private int height;
	private double penRadius;
	private bool defer;
	private double xmin;
	private double ymin;
	private double xmax;
	private double ymax;
	private string name;
	private object mouseLock;
	private object keyLock;
	private Font font;
	private BufferedImage offscreenImage;
	private BufferedImage onscreenImage;
	private Graphics2D offscreen;
	private Graphics2D onscreen;
	private JFrame frame;
	private bool mousePressed;
	private double mouseX;
	private double mouseY;
//[Signature("Ljava/util/LinkedList<Ljava/lang/Character;>;")]
	private LinkedList keysTyped;
//[Signature("Ljava/util/TreeSet<Ljava/lang/Integer;>;")]
	private TreeSet keysDown;
//[Signature("Ljava/util/ArrayList<LDrawListener;>;")]
	private ArrayList listeners;
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color BLACK
	{
		
		get
		{
			return Draw.__BLACK;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color BLUE
	{
		
		get
		{
			return Draw.__BLUE;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color CYAN
	{
		
		get
		{
			return Draw.__CYAN;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color DARK_GRAY
	{
		
		get
		{
			return Draw.__DARK_GRAY;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color GRAY
	{
		
		get
		{
			return Draw.__GRAY;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color GREEN
	{
		
		get
		{
			return Draw.__GREEN;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color LIGHT_GRAY
	{
		
		get
		{
			return Draw.__LIGHT_GRAY;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color MAGENTA
	{
		
		get
		{
			return Draw.__MAGENTA;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color ORANGE
	{
		
		get
		{
			return Draw.__ORANGE;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color PINK
	{
		
		get
		{
			return Draw.__PINK;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color RED
	{
		
		get
		{
			return Draw.__RED;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color WHITE
	{
		
		get
		{
			return Draw.__WHITE;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color YELLOW
	{
		
		get
		{
			return Draw.__YELLOW;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color BOOK_BLUE
	{
		
		get
		{
			return Draw.__BOOK_BLUE;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color BOOK_RED
	{
		
		get
		{
			return Draw.__BOOK_RED;
		}
	}
	
	
	
	
	private void init()
	{
		if (this.frame != null)
		{
			this.frame.setVisible(false);
		}
		this.frame = new JFrame();
		BufferedImage.__<clinit>();
		this.offscreenImage = new BufferedImage(this.width, this.height, 2);
		BufferedImage.__<clinit>();
		this.onscreenImage = new BufferedImage(this.width, this.height, 2);
		this.offscreen = this.offscreenImage.createGraphics();
		this.onscreen = this.onscreenImage.createGraphics();
		this.setXscale();
		this.setYscale();
		this.offscreen.setColor(Draw.DEFAULT_CLEAR_COLOR);
		this.offscreen.fillRect(0, 0, this.width, this.height);
		this.setPenColor();
		this.setPenRadius();
		this.setFont();
		this.clear();
		RenderingHints.__<clinit>();
		RenderingHints renderingHints = new RenderingHints(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
		renderingHints.put(RenderingHints.KEY_RENDERING, RenderingHints.VALUE_RENDER_QUALITY);
		this.offscreen.addRenderingHints(renderingHints);
		ImageIcon.__<clinit>();
		ImageIcon image = new ImageIcon(this.onscreenImage);
		JLabel jLabel = new JLabel(image);
		jLabel.addMouseListener(this);
		jLabel.addMouseMotionListener(this);
		this.frame.setContentPane(jLabel);
		this.frame.addKeyListener(this);
		this.frame.setResizable(false);
		this.frame.setDefaultCloseOperation(2);
		this.frame.setTitle(this.name);
		this.frame.setJMenuBar(this.createMenuBar());
		this.frame.pack();
		this.frame.requestFocusInWindow();
		this.frame.setVisible(true);
	}
	
	
	public virtual void setXscale()
	{
		this.setXscale((double)0f, (double)1f);
	}
	
	
	public virtual void setYscale()
	{
		this.setYscale((double)0f, (double)1f);
	}
	
	
	public virtual void setPenColor()
	{
		this.setPenColor(Draw.DEFAULT_PEN_COLOR);
	}
	
	
	public virtual void setPenRadius()
	{
		this.setPenRadius(0.002);
	}
	
	
	public virtual void setFont()
	{
		this.setFont(Draw.DEFAULT_FONT);
	}
	
	
	public virtual void clear()
	{
		this.clear(Draw.DEFAULT_CLEAR_COLOR);
	}
	
	
	private JMenuBar createMenuBar()
	{
		JMenuBar jMenuBar = new JMenuBar();
		JMenu jMenu = new JMenu("File");
		jMenuBar.add(jMenu);
		JMenuItem jMenuItem = new JMenuItem(" Save...   ");
		jMenuItem.addActionListener(this);
		jMenuItem.setAccelerator(KeyStroke.getKeyStroke(83, Toolkit.getDefaultToolkit().getMenuShortcutKeyMask()));
		jMenu.add(jMenuItem);
		return jMenuBar;
	}
	public virtual void setXscale(double d1, double d2)
	{
		double num = d2 - d1;
		this.xmin = d1 - 0.05 * num;
		this.xmax = d2 + 0.05 * num;
	}
	public virtual void setYscale(double d1, double d2)
	{
		double num = d2 - d1;
		this.ymin = d1 - 0.05 * num;
		this.ymax = d2 + 0.05 * num;
	}
	
	
	public virtual void clear(Color c)
	{
		this.offscreen.setColor(c);
		this.offscreen.fillRect(0, 0, this.width, this.height);
		this.offscreen.setColor(this.penColor);
		this.draw();
	}
	
	
	private void draw()
	{
		if (this.defer)
		{
			return;
		}
		this.onscreen.drawImage(this.offscreenImage, 0, 0, null);
		this.frame.repaint();
	}
	
	
	public virtual void setPenRadius(double d)
	{
		if (d < (double)0f)
		{
			string arg_13_0 = "pen radius must be positive";
			
			throw new RuntimeException(arg_13_0);
		}
		this.penRadius = d * 512.0;
		BasicStroke stroke = new BasicStroke((float)this.penRadius, 1, 1);
		this.offscreen.setStroke(stroke);
	}
	
	
	public virtual void setPenColor(Color c)
	{
		this.penColor = c;
		this.offscreen.setColor(this.penColor);
	}
	public virtual void setFont(Font f)
	{
		this.font = f;
	}
	private double scaleX(double num)
	{
		return (double)this.width * (num - this.xmin) / (this.xmax - this.xmin);
	}
	private double scaleY(double num)
	{
		return (double)this.height * (this.ymax - num) / (this.ymax - this.ymin);
	}
	
	
	private void pixel(double num, double num2)
	{
		this.offscreen.fillRect((int)java.lang.Math.round(this.scaleX(num)), (int)java.lang.Math.round(this.scaleY(num2)), 1, 1);
	}
	
	
	private double factorX(double num)
	{
		return num * (double)this.width / java.lang.Math.abs(this.xmax - this.xmin);
	}
	
	
	private double factorY(double num)
	{
		return num * (double)this.height / java.lang.Math.abs(this.ymax - this.ymin);
	}
	
	
	private Image getImage(string text)
	{
		ImageIcon imageIcon = new ImageIcon(text);
		if (imageIcon != null)
		{
			if (imageIcon.getImageLoadStatus() == 8)
			{
				goto IL_39;
			}
		}
		try
		{
			URL uRL = new URL(text);
			imageIcon = new ImageIcon(uRL);
		}
		catch (System.Exception arg_26_0)
		{
			if (ByteCodeHelper.MapException<java.lang.Exception>(arg_26_0, ByteCodeHelper.MapFlags.Unused) == null)
			{
				throw;
			}
		}
		IL_39:
		if (imageIcon == null || imageIcon.getImageLoadStatus() != 8)
		{
			URL uRL = ClassLiteral<Draw>.Value.getResource(text);
			if (uRL == null)
			{
				string arg_7D_0 = new StringBuilder().append("image ").append(text).append(" not found").toString();
				
				throw new RuntimeException(arg_7D_0);
			}
			imageIcon = new ImageIcon(uRL);
		}
		return imageIcon.getImage();
	}
	
	
	public virtual void text(double d1, double d2, string str)
	{
		this.offscreen.setFont(this.font);
		FontMetrics fontMetrics = this.offscreen.getFontMetrics();
		double num = this.scaleX(d1);
		double num2 = this.scaleY(d2);
		int num3 = fontMetrics.stringWidth(str);
		int descent = fontMetrics.getDescent();
		this.offscreen.drawString(str, (float)(num - (double)num3 / 2.0), (float)(num2 + (double)descent));
		this.draw();
	}
	
	
	public virtual void show()
	{
		this.defer = false;
		this.draw();
	}
	
	
	public virtual void save(string str)
	{
		File output = new File(str);
		string text = java.lang.String.instancehelper_substring(str, java.lang.String.instancehelper_lastIndexOf(str, 46) + 1);
		if (java.lang.String.instancehelper_equals(java.lang.String.instancehelper_toLowerCase(text), "png"))
		{
			IOException ex;
			try
			{
				ImageIO.write(this.offscreenImage, text, output);
			}
			catch (IOException arg_3D_0)
			{
				ex = ByteCodeHelper.MapException<IOException>(arg_3D_0, ByteCodeHelper.MapFlags.NoRemapping);
				goto IL_47;
			}
			return;
			IL_47:
			IOException this2 = ex;
			Throwable.instancehelper_printStackTrace(this2);
		}
		else if (java.lang.String.instancehelper_equals(java.lang.String.instancehelper_toLowerCase(text), "jpg"))
		{
			WritableRaster raster = this.offscreenImage.getRaster();
			WritableRaster raster2 = raster.createWritableChild(0, 0, this.width, this.height, 0, 0, new int[]
			{
				0,
				1,
				2
			});
			DirectColorModel directColorModel = (DirectColorModel)this.offscreenImage.getColorModel();
			DirectColorModel.__<clinit>();
			DirectColorModel cm = new DirectColorModel(directColorModel.getPixelSize(), directColorModel.getRedMask(), directColorModel.getGreenMask(), directColorModel.getBlueMask());
			BufferedImage im = new BufferedImage(cm, raster2, false, null);
			IOException ex2;
			try
			{
				ImageIO.write(im, text, output);
			}
			catch (IOException arg_FE_0)
			{
				ex2 = ByteCodeHelper.MapException<IOException>(arg_FE_0, ByteCodeHelper.MapFlags.NoRemapping);
				goto IL_109;
			}
			goto IL_118;
			IL_109:
			IOException this3 = ex2;
			Throwable.instancehelper_printStackTrace(this3);
			IL_118:;
		}
		else
		{
			System.@out.println(new StringBuilder().append("Invalid image file type: ").append(text).toString());
		}
	}
	private double userX(double num)
	{
		return this.xmin + num * (this.xmax - this.xmin) / (double)this.width;
	}
	private double userY(double num)
	{
		return this.ymax - num * (this.ymax - this.ymin) / (double)this.height;
	}
	
	
	public Draw(string str)
	{
		this.width = 512;
		this.height = 512;
		this.defer = false;
		this.name = "Draw";
		this.mouseLock = new java.lang.Object();
		this.keyLock = new java.lang.Object();
		this.frame = new JFrame();
		this.mousePressed = false;
		this.mouseX = (double)0f;
		this.mouseY = (double)0f;
		this.keysTyped = new LinkedList();
		this.keysDown = new TreeSet();
		this.listeners = new ArrayList();
		this.name = str;
		this.init();
	}
	
	
	public virtual void square(double d1, double d2, double d3)
	{
		if (d3 < (double)0f)
		{
			string arg_13_0 = "square side length can't be negative";
			
			throw new RuntimeException(arg_13_0);
		}
		double num = this.scaleX(d1);
		double num2 = this.scaleY(d2);
		double num3 = this.factorX(2.0 * d3);
		double num4 = this.factorY(2.0 * d3);
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			this.pixel(d1, d2);
		}
		else
		{
			this.offscreen.draw(new Rectangle2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
		}
		this.draw();
	}
	
	
	public virtual void filledSquare(double d1, double d2, double d3)
	{
		if (d3 < (double)0f)
		{
			string arg_13_0 = "square side length can't be negative";
			
			throw new RuntimeException(arg_13_0);
		}
		double num = this.scaleX(d1);
		double num2 = this.scaleY(d2);
		double num3 = this.factorX(2.0 * d3);
		double num4 = this.factorY(2.0 * d3);
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			this.pixel(d1, d2);
		}
		else
		{
			this.offscreen.fill(new Rectangle2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
		}
		this.draw();
	}
	
	
	public virtual void circle(double d1, double d2, double d3)
	{
		if (d3 < (double)0f)
		{
			string arg_13_0 = "circle radius can't be negative";
			
			throw new RuntimeException(arg_13_0);
		}
		double num = this.scaleX(d1);
		double num2 = this.scaleY(d2);
		double num3 = this.factorX(2.0 * d3);
		double num4 = this.factorY(2.0 * d3);
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			this.pixel(d1, d2);
		}
		else
		{
			this.offscreen.draw(new Ellipse2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
		}
		this.draw();
	}
	
	
	public virtual void arc(double d1, double d2, double d3, double d4, double d5)
	{
		if (d3 < (double)0f)
		{
			string arg_13_0 = "arc radius can't be negative";
			
			throw new RuntimeException(arg_13_0);
		}
		while (d5 < d4)
		{
			d5 += 360.0;
		}
		double num = this.scaleX(d1);
		double num2 = this.scaleY(d2);
		double num3 = this.factorX(2.0 * d3);
		double num4 = this.factorY(2.0 * d3);
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			this.pixel(d1, d2);
		}
		else
		{
			this.offscreen.draw(new Arc2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4, d4, d5 - d4, 0));
		}
		this.draw();
	}
	
	
	public virtual void setCanvasSize(int i1, int i2)
	{
		if (i1 < 1 || i2 < 1)
		{
			string arg_12_0 = "width and height must be positive";
			
			throw new RuntimeException(arg_12_0);
		}
		this.width = i1;
		this.height = i2;
		this.init();
	}
	
	
	public virtual void filledPolygon(double[] darr1, double[] darr2)
	{
		int num = darr1.Length;
		GeneralPath generalPath = new GeneralPath();
		generalPath.moveTo((float)this.scaleX(darr1[0]), (float)this.scaleY(darr2[0]));
		for (int i = 0; i < num; i++)
		{
			generalPath.lineTo((float)this.scaleX(darr1[i]), (float)this.scaleY(darr2[i]));
		}
		generalPath.closePath();
		this.offscreen.fill(generalPath);
		this.draw();
	}
	
	
	public Draw()
	{
		this.width = 512;
		this.height = 512;
		this.defer = false;
		this.name = "Draw";
		this.mouseLock = new java.lang.Object();
		this.keyLock = new java.lang.Object();
		this.frame = new JFrame();
		this.mousePressed = false;
		this.mouseX = (double)0f;
		this.mouseY = (double)0f;
		this.keysTyped = new LinkedList();
		this.keysDown = new TreeSet();
		this.listeners = new ArrayList();
		this.init();
	}
	
	
	public virtual void setLocationOnScreen(int i1, int i2)
	{
		this.frame.setLocation(i1, i2);
	}
	public virtual double getPenRadius()
	{
		return this.penRadius;
	}
	public virtual Color getPenColor()
	{
		return this.penColor;
	}
	
	
	public virtual void setPenColor(int i1, int i2, int i3)
	{
		if (i1 < 0 || i1 >= 256)
		{
			string arg_16_0 = "amount of red must be between 0 and 255";
			
			throw new ArgumentException(arg_16_0);
		}
		if (i2 < 0 || i2 >= 256)
		{
			string arg_32_0 = "amount of red must be between 0 and 255";
			
			throw new ArgumentException(arg_32_0);
		}
		if (i3 < 0 || i3 >= 256)
		{
			string arg_4E_0 = "amount of red must be between 0 and 255";
			
			throw new ArgumentException(arg_4E_0);
		}
		this.setPenColor(new Color(i1, i2, i3));
	}
	
	
	public virtual void xorOn()
	{
		this.offscreen.setXORMode(Draw.DEFAULT_CLEAR_COLOR);
	}
	
	
	public virtual void xorOff()
	{
		this.offscreen.setPaintMode();
	}
	public virtual Font getFont()
	{
		return this.font;
	}
	
	
	public virtual void line(double d1, double d2, double d3, double d4)
	{
		this.offscreen.draw(new Line2D.Double(this.scaleX(d1), this.scaleY(d2), this.scaleX(d3), this.scaleY(d4)));
		this.draw();
	}
	
	
	public virtual void point(double d1, double d2)
	{
		double num = this.scaleX(d1);
		double num2 = this.scaleY(d2);
		double num3 = this.penRadius;
		if (num3 <= (double)1f)
		{
			this.pixel(d1, d2);
		}
		else
		{
			this.offscreen.fill(new Ellipse2D.Double(num - num3 / 2.0, num2 - num3 / 2.0, num3, num3));
		}
		this.draw();
	}
	
	
	public virtual void filledCircle(double d1, double d2, double d3)
	{
		if (d3 < (double)0f)
		{
			string arg_13_0 = "circle radius can't be negative";
			
			throw new RuntimeException(arg_13_0);
		}
		double num = this.scaleX(d1);
		double num2 = this.scaleY(d2);
		double num3 = this.factorX(2.0 * d3);
		double num4 = this.factorY(2.0 * d3);
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			this.pixel(d1, d2);
		}
		else
		{
			this.offscreen.fill(new Ellipse2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
		}
		this.draw();
	}
	
	
	public virtual void ellipse(double d1, double d2, double d3, double d4)
	{
		if (d3 < (double)0f)
		{
			string arg_13_0 = "ellipse semimajor axis can't be negative";
			
			throw new RuntimeException(arg_13_0);
		}
		if (d4 < (double)0f)
		{
			string arg_2D_0 = "ellipse semiminor axis can't be negative";
			
			throw new RuntimeException(arg_2D_0);
		}
		double num = this.scaleX(d1);
		double num2 = this.scaleY(d2);
		double num3 = this.factorX(2.0 * d3);
		double num4 = this.factorY(2.0 * d4);
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			this.pixel(d1, d2);
		}
		else
		{
			this.offscreen.draw(new Ellipse2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
		}
		this.draw();
	}
	
	
	public virtual void filledEllipse(double d1, double d2, double d3, double d4)
	{
		if (d3 < (double)0f)
		{
			string arg_13_0 = "ellipse semimajor axis can't be negative";
			
			throw new RuntimeException(arg_13_0);
		}
		if (d4 < (double)0f)
		{
			string arg_2D_0 = "ellipse semiminor axis can't be negative";
			
			throw new RuntimeException(arg_2D_0);
		}
		double num = this.scaleX(d1);
		double num2 = this.scaleY(d2);
		double num3 = this.factorX(2.0 * d3);
		double num4 = this.factorY(2.0 * d4);
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			this.pixel(d1, d2);
		}
		else
		{
			this.offscreen.fill(new Ellipse2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
		}
		this.draw();
	}
	
	
	public virtual void rectangle(double d1, double d2, double d3, double d4)
	{
		if (d3 < (double)0f)
		{
			string arg_13_0 = "half width can't be negative";
			
			throw new RuntimeException(arg_13_0);
		}
		if (d4 < (double)0f)
		{
			string arg_2D_0 = "half height can't be negative";
			
			throw new RuntimeException(arg_2D_0);
		}
		double num = this.scaleX(d1);
		double num2 = this.scaleY(d2);
		double num3 = this.factorX(2.0 * d3);
		double num4 = this.factorY(2.0 * d4);
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			this.pixel(d1, d2);
		}
		else
		{
			this.offscreen.draw(new Rectangle2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
		}
		this.draw();
	}
	
	
	public virtual void filledRectangle(double d1, double d2, double d3, double d4)
	{
		if (d3 < (double)0f)
		{
			string arg_13_0 = "half width can't be negative";
			
			throw new RuntimeException(arg_13_0);
		}
		if (d4 < (double)0f)
		{
			string arg_2D_0 = "half height can't be negative";
			
			throw new RuntimeException(arg_2D_0);
		}
		double num = this.scaleX(d1);
		double num2 = this.scaleY(d2);
		double num3 = this.factorX(2.0 * d3);
		double num4 = this.factorY(2.0 * d4);
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			this.pixel(d1, d2);
		}
		else
		{
			this.offscreen.fill(new Rectangle2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
		}
		this.draw();
	}
	
	
	public virtual void polygon(double[] darr1, double[] darr2)
	{
		int num = darr1.Length;
		GeneralPath generalPath = new GeneralPath();
		generalPath.moveTo((float)this.scaleX(darr1[0]), (float)this.scaleY(darr2[0]));
		for (int i = 0; i < num; i++)
		{
			generalPath.lineTo((float)this.scaleX(darr1[i]), (float)this.scaleY(darr2[i]));
		}
		generalPath.closePath();
		this.offscreen.draw(generalPath);
		this.draw();
	}
	
	
	public virtual void picture(double d1, double d2, string str)
	{
		Image image = this.getImage(str);
		double num = this.scaleX(d1);
		double num2 = this.scaleY(d2);
		int num3 = image.getWidth(null);
		int num4 = image.getHeight(null);
		if (num3 < 0 || num4 < 0)
		{
			string arg_5F_0 = new StringBuilder().append("image ").append(str).append(" is corrupt").toString();
			
			throw new RuntimeException(arg_5F_0);
		}
		this.offscreen.drawImage(image, (int)java.lang.Math.round(num - (double)num3 / 2.0), (int)java.lang.Math.round(num2 - (double)num4 / 2.0), null);
		this.draw();
	}
	
	
	public virtual void picture(double d1, double d2, string str, double d3)
	{
		Image image = this.getImage(str);
		double num = this.scaleX(d1);
		double num2 = this.scaleY(d2);
		int num3 = image.getWidth(null);
		int num4 = image.getHeight(null);
		if (num3 < 0 || num4 < 0)
		{
			string arg_5F_0 = new StringBuilder().append("image ").append(str).append(" is corrupt").toString();
			
			throw new RuntimeException(arg_5F_0);
		}
		this.offscreen.rotate(java.lang.Math.toRadians(-d3), num, num2);
		this.offscreen.drawImage(image, (int)java.lang.Math.round(num - (double)num3 / 2.0), (int)java.lang.Math.round(num2 - (double)num4 / 2.0), null);
		this.offscreen.rotate(java.lang.Math.toRadians(d3), num, num2);
		this.draw();
	}
	
	
	public virtual void picture(double d1, double d2, string str, double d3, double d4)
	{
		Image image = this.getImage(str);
		double num = this.scaleX(d1);
		double num2 = this.scaleY(d2);
		double num3 = this.factorX(d3);
		double num4 = this.factorY(d4);
		if (num3 < (double)0f || num4 < (double)0f)
		{
			string arg_6D_0 = new StringBuilder().append("image ").append(str).append(" is corrupt").toString();
			
			throw new RuntimeException(arg_6D_0);
		}
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			this.pixel(d1, d2);
		}
		else
		{
			this.offscreen.drawImage(image, (int)java.lang.Math.round(num - num3 / 2.0), (int)java.lang.Math.round(num2 - num4 / 2.0), (int)java.lang.Math.round(num3), (int)java.lang.Math.round(num4), null);
		}
		this.draw();
	}
	
	
	public virtual void picture(double d1, double d2, string str, double d3, double d4, double d5)
	{
		Image image = this.getImage(str);
		double num = this.scaleX(d1);
		double num2 = this.scaleY(d2);
		double num3 = this.factorX(d3);
		double num4 = this.factorY(d4);
		if (num3 < (double)0f || num4 < (double)0f)
		{
			string arg_6D_0 = new StringBuilder().append("image ").append(str).append(" is corrupt").toString();
			
			throw new RuntimeException(arg_6D_0);
		}
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			this.pixel(d1, d2);
		}
		this.offscreen.rotate(java.lang.Math.toRadians(-d5), num, num2);
		this.offscreen.drawImage(image, (int)java.lang.Math.round(num - num3 / 2.0), (int)java.lang.Math.round(num2 - num4 / 2.0), (int)java.lang.Math.round(num3), (int)java.lang.Math.round(num4), null);
		this.offscreen.rotate(java.lang.Math.toRadians(d5), num, num2);
		this.draw();
	}
	
	
	public virtual void text(double d1, double d2, string str, double d3)
	{
		double d4 = this.scaleX(d1);
		double d5 = this.scaleY(d2);
		this.offscreen.rotate(java.lang.Math.toRadians(-d3), d4, d5);
		this.text(d1, d2, str);
		this.offscreen.rotate(java.lang.Math.toRadians(d3), d4, d5);
	}
	
	
	public virtual void textLeft(double d1, double d2, string str)
	{
		this.offscreen.setFont(this.font);
		FontMetrics fontMetrics = this.offscreen.getFontMetrics();
		double num = this.scaleX(d1);
		double num2 = this.scaleY(d2);
		int descent = fontMetrics.getDescent();
		this.offscreen.drawString(str, (float)num, (float)(num2 + (double)descent));
		this.show();
	}
	
	
	public virtual void show(int i)
	{
		this.defer = false;
		this.draw();
		try
		{
			Thread.sleep((long)i);
		}
		catch (InterruptedException arg_18_0)
		{
			goto IL_1C;
		}
		goto IL_31;
		IL_1C:
		System.@out.println("Error sleeping");
		IL_31:
		this.defer = true;
	}
	
	
	public virtual void actionPerformed(ActionEvent ae)
	{
		FileDialog.__<clinit>();
		FileDialog fileDialog = new FileDialog(this.frame, "Use a .png or .jpg extension", 1);
		fileDialog.setVisible(true);
		string file = fileDialog.getFile();
		if (file != null)
		{
			this.save(new StringBuilder().append(fileDialog.getDirectory()).append(File.separator).append(fileDialog.getFile()).toString());
		}
	}
	
	
	public virtual void addListener(DrawListener dl)
	{
		this.show();
		this.listeners.add(dl);
		this.frame.addKeyListener(this);
		this.frame.addMouseListener(this);
		this.frame.addMouseMotionListener(this);
		this.frame.setFocusable(true);
	}
	
	public virtual bool mousePressed()
	{
		int result;
		lock (this.mouseLock)
		{
			result = (this.mousePressed ? 1 : 0);
		}
		return result != 0;
	}
	
	public virtual double mouseX()
	{
		double result;
		lock (this.mouseLock)
		{
			result = this.mouseX;
		}
		return result;
	}
	
	public virtual double mouseY()
	{
		double result;
		lock (this.mouseLock)
		{
			result = this.mouseY;
		}
		return result;
	}
	public virtual void mouseClicked(MouseEvent me)
	{
	}
	public virtual void mouseEntered(MouseEvent me)
	{
	}
	public virtual void mouseExited(MouseEvent me)
	{
	}
	
	
	public virtual void mousePressed(MouseEvent me)
	{
		lock (this.mouseLock)
		{
			this.mouseX = this.userX((double)me.getX());
			this.mouseY = this.userY((double)me.getY());
			this.mousePressed = true;
		}
		if (me.getButton() == 1)
		{
			Iterator iterator = this.listeners.iterator();
			while (iterator.hasNext())
			{
				DrawListener drawListener = (DrawListener)iterator.next();
				drawListener.mousePressed(this.userX((double)me.getX()), this.userY((double)me.getY()));
			}
		}
	}
	
	
	public virtual void mouseReleased(MouseEvent me)
	{
		lock (this.mouseLock)
		{
			this.mousePressed = false;
		}
		if (me.getButton() == 1)
		{
			Iterator iterator = this.listeners.iterator();
			while (iterator.hasNext())
			{
				DrawListener drawListener = (DrawListener)iterator.next();
				drawListener.mouseReleased(this.userX((double)me.getX()), this.userY((double)me.getY()));
			}
		}
	}
	
	
	public virtual void mouseDragged(MouseEvent me)
	{
		lock (this.mouseLock)
		{
			this.mouseX = this.userX((double)me.getX());
			this.mouseY = this.userY((double)me.getY());
		}
		Iterator iterator = this.listeners.iterator();
		while (iterator.hasNext())
		{
			DrawListener drawListener = (DrawListener)iterator.next();
			drawListener.mouseDragged(this.userX((double)me.getX()), this.userY((double)me.getY()));
		}
	}
	
	
	public virtual void mouseMoved(MouseEvent me)
	{
		lock (this.mouseLock)
		{
			this.mouseX = this.userX((double)me.getX());
			this.mouseY = this.userY((double)me.getY());
		}
	}
	
	
	public virtual bool hasNextKeyTyped()
	{
		int result;
		lock (this.keyLock)
		{
			result = (this.keysTyped.IsEmpty ? 0 : 1);
		}
		return result != 0;
	}
	
	
	public virtual char nextKeyTyped()
	{
		int result;
		lock (this.keyLock)
		{
			result = (int)((Character)this.keysTyped.removeLast()).charValue();
		}
		return (char)result;
	}
	
	
	public virtual bool isKeyPressed(int i)
	{
		int result;
		lock (this.keyLock)
		{
			result = (this.keysDown.contains(Integer.valueOf(i)) ? 1 : 0);
		}
		return result != 0;
	}
	
	
	public virtual void keyTyped(KeyEvent ke)
	{
		lock (this.keyLock)
		{
			this.keysTyped.addFirst(Character.valueOf(ke.getKeyChar()));
		}
		Iterator iterator = this.listeners.iterator();
		while (iterator.hasNext())
		{
			DrawListener drawListener = (DrawListener)iterator.next();
			drawListener.keyTyped(ke.getKeyChar());
		}
	}
	
	
	public virtual void keyPressed(KeyEvent ke)
	{
		lock (this.keyLock)
		{
			this.keysDown.add(Integer.valueOf(ke.getKeyCode()));
		}
	}
	
	
	public virtual void keyReleased(KeyEvent ke)
	{
		lock (this.keyLock)
		{
			this.keysDown.remove(Integer.valueOf(ke.getKeyCode()));
		}
	}
	
	
	/**/public static void main(string[] strarr)
	{
		Draw draw = new Draw("Test client 1");
		draw.square(0.2, 0.8, 0.1);
		draw.filledSquare(0.8, 0.8, 0.2);
		draw.circle(0.8, 0.2, 0.2);
		draw.setPenColor(Draw.__MAGENTA);
		draw.setPenRadius(0.02);
		draw.arc(0.8, 0.2, 0.1, 200.0, 45.0);
		Draw draw2 = new Draw("Test client 2");
		draw2.setCanvasSize(900, 200);
		draw2.setPenRadius();
		draw2.setPenColor(Draw.__BLUE);
		double[] darr = new double[]
		{
			0.1,
			0.2,
			0.3,
			0.2
		};
		double[] darr2 = new double[]
		{
			0.2,
			0.3,
			0.2,
			0.1
		};
		draw2.filledPolygon(darr, darr2);
		draw2.setPenColor(Draw.__BLACK);
		draw2.text(0.2, 0.5, "bdfdfdfdlack text");
		draw2.setPenColor(Draw.__WHITE);
		draw2.text(0.8, 0.8, "white text");
	}
	
	static Draw()
	{
		Draw.__BLACK = Color.BLACK;
		Draw.__BLUE = Color.BLUE;
		Draw.__CYAN = Color.CYAN;
		Draw.__DARK_GRAY = Color.DARK_GRAY;
		Draw.__GRAY = Color.GRAY;
		Draw.__GREEN = Color.GREEN;
		Draw.__LIGHT_GRAY = Color.LIGHT_GRAY;
		Draw.__MAGENTA = Color.MAGENTA;
		Draw.__ORANGE = Color.ORANGE;
		Draw.__PINK = Color.PINK;
		Draw.__RED = Color.RED;
		Draw.__WHITE = Color.WHITE;
		Draw.__YELLOW = Color.YELLOW;
		Draw.__BOOK_BLUE = new Color(9, 90, 166);
		Draw.__BOOK_RED = new Color(173, 32, 24);
		Draw.DEFAULT_PEN_COLOR = Draw.__BLACK;
		Draw.DEFAULT_CLEAR_COLOR = Draw.__WHITE;
		Draw.DEFAULT_FONT = new Font("SansSerif", 0, 16);
	}
}


public interface DrawListener
{
	void mousePressed(double d1, double d2);
	void mouseReleased(double d1, double d2);
	void mouseDragged(double d1, double d2);
	void keyTyped(char ch);
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





public class Interval1D
{
	/*[EnclosingMethod("Interval1D", null, null), InnerClass(null, Modifiers.Static | Modifiers.Synthetic), Modifiers(Modifiers.Super | Modifiers.Synthetic), SourceFile("Interval1D.java")]*/
	
	/*[Implements(new string[]
	{
		"java.util.Comparator"
	}), InnerClass(null, Modifiers.Private | Modifiers.Static), Modifiers(Modifiers.Super), Signature("Ljava/lang/Object;Ljava/util/Comparator<LInterval1D;>;"), SourceFile("Interval1D.java")]*/
	internal sealed class LeftComparator, Comparator
	{
/*		[LineNumberTable(122), Modifiers(Modifiers.Synthetic)]*/
		
		internal LeftComparator(Interval1D.1) : this()
		{
		}
		
		
		private LeftComparator()
		{
		}
		
		
		public virtual int compare(Interval1D interval1D, Interval1D interval1D2)
		{
			if (Interval1D.access_300(interval1D) < Interval1D.access_300(interval1D2))
			{
				return -1;
			}
			if (Interval1D.access_300(interval1D) > Interval1D.access_300(interval1D2))
			{
				return 1;
			}
			if (Interval1D.access_400(interval1D) < Interval1D.access_400(interval1D2))
			{
				return -1;
			}
			if (Interval1D.access_400(interval1D) > Interval1D.access_400(interval1D2))
			{
				return 1;
			}
			return 0;
		}
/*		[LineNumberTable(122), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public virtual int compare(object obj, object obj2)
		{
			return this.compare((Interval1D)obj, (Interval1D)obj2);
		}
		
		bool Comparator.Object;)Zequals(object obj)
		{
			return java.lang.Object.instancehelper_equals(this, obj);
		}
	}
	/*[Implements(new string[]
	{
		"java.util.Comparator"
	}), InnerClass(null, Modifiers.Private | Modifiers.Static), Modifiers(Modifiers.Super), Signature("Ljava/lang/Object;Ljava/util/Comparator<LInterval1D;>;"), SourceFile("Interval1D.java")]*/
	internal sealed class LengthComparator, Comparator
	{
/*		[LineNumberTable(144), Modifiers(Modifiers.Synthetic)]*/
		
		internal LengthComparator(Interval1D.1) : this()
		{
		}
		
		
		private LengthComparator()
		{
		}
		
		
		public virtual int compare(Interval1D interval1D, Interval1D interval1D2)
		{
			double num = interval1D.Length();
			double num2 = interval1D2.Length();
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
/*		[LineNumberTable(144), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public virtual int compare(object obj, object obj2)
		{
			return this.compare((Interval1D)obj, (Interval1D)obj2);
		}
		
		bool Comparator.Object;)Zequals(object obj)
		{
			return java.lang.Object.instancehelper_equals(this, obj);
		}
	}
	/*[Implements(new string[]
	{
		"java.util.Comparator"
	}), InnerClass(null, Modifiers.Private | Modifiers.Static), Modifiers(Modifiers.Super), Signature("Ljava/lang/Object;Ljava/util/Comparator<LInterval1D;>;"), SourceFile("Interval1D.java")]*/
	internal sealed class RightComparator, Comparator
	{
/*		[LineNumberTable(133), Modifiers(Modifiers.Synthetic)]*/
		
		internal RightComparator(Interval1D.1) : this()
		{
		}
		
		
		private RightComparator()
		{
		}
		
		
		public virtual int compare(Interval1D interval1D, Interval1D interval1D2)
		{
			if (Interval1D.access_400(interval1D) < Interval1D.access_400(interval1D2))
			{
				return -1;
			}
			if (Interval1D.access_400(interval1D) > Interval1D.access_400(interval1D2))
			{
				return 1;
			}
			if (Interval1D.access_300(interval1D) < Interval1D.access_300(interval1D2))
			{
				return -1;
			}
			if (Interval1D.access_300(interval1D) > Interval1D.access_300(interval1D2))
			{
				return 1;
			}
			return 0;
		}
/*		[LineNumberTable(133), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public virtual int compare(object obj, object obj2)
		{
			return this.compare((Interval1D)obj, (Interval1D)obj2);
		}
		
		bool Comparator.Object;)Zequals(object obj)
		{
			return java.lang.Object.instancehelper_equals(this, obj);
		}
	}
//[Signature("Ljava/util/Comparator<LInterval1D;>;")]
	internal static Comparator __LEFT_ENDPOINT_ORDER;
//[Signature("Ljava/util/Comparator<LInterval1D;>;")]
	internal static Comparator __RIGHT_ENDPOINT_ORDER;
//[Signature("Ljava/util/Comparator<LInterval1D;>;")]
	internal static Comparator __LENGTH_ORDER;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private double left;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private double right;
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Comparator LEFT_ENDPOINT_ORDER
	{
		
		get
		{
			return Interval1D.__LEFT_ENDPOINT_ORDER;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Comparator RIGHT_ENDPOINT_ORDER
	{
		
		get
		{
			return Interval1D.__RIGHT_ENDPOINT_ORDER;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Comparator LENGTH_ORDER
	{
		
		get
		{
			return Interval1D.__LENGTH_ORDER;
		}
	}
	
	
	
	
	public Interval1D(double d1, double d2)
	{
		if (java.lang.Double.isInfinite(d1) || java.lang.Double.isInfinite(d2))
		{
			string arg_24_0 = "Endpoints must be finite";
			
			throw new ArgumentException(arg_24_0);
		}
		if (java.lang.Double.isNaN(d1) || java.lang.Double.isNaN(d2))
		{
			string arg_46_0 = "Endpoints cannot be NaN";
			
			throw new ArgumentException(arg_46_0);
		}
		if (d1 <= d2)
		{
			this.left = d1;
			this.right = d2;
			return;
		}
		string arg_70_0 = "Illegal interval";
		
		throw new ArgumentException(arg_70_0);
	}
	public virtual double left()
	{
		return this.left;
	}
	public virtual double right()
	{
		return this.right;
	}
	
	public virtual bool intersects(Interval1D id)
	{
		return this.right >= id.left && id.right >= this.left;
	}
	public virtual bool contains(double d)
	{
		return this.left <= d && d <= this.right;
	}
	public virtual double length()
	{
		return this.right - this.left;
	}
	
	
	public override string ToString()
	{
		return new StringBuilder().append("[").append(this.left).append(", ").append(this.right).append("]").toString();
	}
	
	
	/**/public static void main(string[] strarr)
	{
		Interval1D[] array = new Interval1D[]
		{
			new Interval1D(15.0, 33.0),
			new Interval1D(45.0, 60.0),
			new Interval1D(20.0, 70.0),
			new Interval1D(46.0, 55.0)
		};
		StdOut.println("Unsorted");
		for (int i = 0; i < array.Length; i++)
		{
			StdOut.println(array[i]);
		}
		StdOut.println();
		StdOut.println("Sort by left endpoint");
		Arrays.sort(array, Interval1D.__LEFT_ENDPOINT_ORDER);
		for (int i = 0; i < array.Length; i++)
		{
			StdOut.println(array[i]);
		}
		StdOut.println();
		StdOut.println("Sort by right endpoint");
		Arrays.sort(array, Interval1D.__RIGHT_ENDPOINT_ORDER);
		for (int i = 0; i < array.Length; i++)
		{
			StdOut.println(array[i]);
		}
		StdOut.println();
		StdOut.println("Sort by length");
		Arrays.sort(array, Interval1D.__LENGTH_ORDER);
		for (int i = 0; i < array.Length; i++)
		{
			StdOut.println(array[i]);
		}
		StdOut.println();
	}
/*	[LineNumberTable(24), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
	internal static double access_300(Interval1D interval1D)
	{
		return interval1D.left;
	}
/*	[LineNumberTable(24), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
	internal static double access_400(Interval1D interval1D)
	{
		return interval1D.right;
	}
	
	static Interval1D()
	{
		Interval1D.__LEFT_ENDPOINT_ORDER = new Interval1D.LeftComparator(null);
		Interval1D.__RIGHT_ENDPOINT_ORDER = new Interval1D.RightComparator(null);
		Interval1D.__LENGTH_ORDER = new Interval1D.LengthComparator(null);
	}
}





public class Interval2D
{
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private Interval1D x;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private Interval1D y;
	
	
	public Interval2D(Interval1D id1, Interval1D id2)
	{
		this.x = id1;
		this.y = id2;
	}
	
	
	public virtual void draw()
	{
		double d = (this.x.left() + this.x.right()) / 2.0;
		double d2 = (this.y.left() + this.y.right()) / 2.0;
		StdDraw.rectangle(d, d2, this.x.Length() / 2.0, this.y.Length() / 2.0);
	}
	
	
	public virtual bool contains(Point2D pd)
	{
		return this.x.contains(pd.x()) && this.y.contains(pd.y());
	}
	
	
	public virtual double area()
	{
		return this.x.Length() * this.y.Length();
	}
	
	
	public virtual bool intersects(Interval2D id)
	{
		return this.x.intersects(id.x) && this.y.intersects(id.y);
	}
	
	
	public override string ToString()
	{
		return new StringBuilder().append(this.x).append(" x ").append(this.y).toString();
	}
	
	
	/**/public static void main(string[] strarr)
	{
		double d = java.lang.Double.parseDouble(strarr[0]);
		double d2 = java.lang.Double.parseDouble(strarr[1]);
		double d3 = java.lang.Double.parseDouble(strarr[2]);
		double d4 = java.lang.Double.parseDouble(strarr[3]);
		int num = Integer.parseInt(strarr[4]);
		Interval1D id = new Interval1D(d, d2);
		Interval1D id2 = new Interval1D(d3, d4);
		Interval2D interval2D = new Interval2D(id, id2);
		interval2D.draw();
		Counter counter = new Counter("hits");
		for (int i = 0; i < num; i++)
		{
			double d5 = StdRandom.uniform((double)0f, (double)1f);
			double d6 = StdRandom.uniform((double)0f, (double)1f);
			Point2D point2D = new Point2D(d5, d6);
			if (interval2D.contains(point2D))
			{
				counter.increment();
			}
			else
			{
				point2D.draw();
			}
		}
		StdOut.println(counter);
		StdOut.printf("box area = %.2f\n", new object[]
		{
			java.lang.Double.valueOf(interval2D.area())
		});
	}
}






public class KMP
{
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private int R;
	private int[][] dfa;
	private char[] pattern;
	private string pat;
	
	
	public KMP(string str)
	{
		this.R = 256;
		this.pat = str;
		int num = java.lang.String.instancehelper_length(str);
		int arg_35_0 = this.R;
		int arg_30_0 = num;
		int[] array = new int[2];
		int num2 = arg_30_0;
		array[1] = num2;
		num2 = arg_35_0;
		array[0] = num2;
		this.dfa = (int[][])ByteCodeHelper.multianewarray(typeof(int[][]).TypeHandle, array);
		this.dfa[(int)java.lang.String.instancehelper_charAt(str, 0)][0] = 1;
		int num3 = 0;
		for (int i = 1; i < num; i++)
		{
			for (int j = 0; j < this.R; j++)
			{
				this.dfa[j][i] = this.dfa[j][num3];
			}
			this.dfa[(int)java.lang.String.instancehelper_charAt(str, i)][i] = i + 1;
			num3 = this.dfa[(int)java.lang.String.instancehelper_charAt(str, i)][num3];
		}
	}
	
	
	public virtual int search(string str)
	{
		int num = java.lang.String.instancehelper_length(this.pat);
		int num2 = java.lang.String.instancehelper_length(str);
		int num3 = 0;
		int num4 = 0;
		while (num3 < num2 && num4 < num)
		{
			num4 = this.dfa[(int)java.lang.String.instancehelper_charAt(str, num3)][num4];
			num3++;
		}
		if (num4 == num)
		{
			return num3 - num;
		}
		return num2;
	}
	
	
	public KMP(char[] charr, int i)
	{
		this.R = i;
		this.pattern = new char[charr.Length];
		int j;
		for (j = 0; j < charr.Length; j++)
		{
			this.pattern[j] = charr[j];
		}
		j = charr.Length;
		int arg_41_0 = j;
		int[] array = new int[2];
		int num = arg_41_0;
		array[1] = num;
		array[0] = i;
		this.dfa = (int[][])ByteCodeHelper.multianewarray(typeof(int[][]).TypeHandle, array);
		this.dfa[(int)charr[0]][0] = 1;
		int num2 = 0;
		for (int k = 1; k < j; k++)
		{
			for (int l = 0; l < i; l++)
			{
				this.dfa[l][k] = this.dfa[l][num2];
			}
			this.dfa[(int)charr[k]][k] = k + 1;
			num2 = this.dfa[(int)charr[k]][num2];
		}
	}
	
	public virtual int search(char[] charr)
	{
		int num = this.pattern.Length;
		int num2 = charr.Length;
		int num3 = 0;
		int num4 = 0;
		while (num3 < num2 && num4 < num)
		{
			num4 = this.dfa[(int)charr[num3]][num4];
			num3++;
		}
		if (num4 == num)
		{
			return num3 - num;
		}
		return num2;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		string text = strarr[0];
		string text2 = strarr[1];
		char[] charr = java.lang.String.instancehelper_toCharArray(text);
		char[] charr2 = java.lang.String.instancehelper_toCharArray(text2);
		KMP kMP = new KMP(text);
		int num = kMP.search(text2);
		KMP kMP2 = new KMP(charr, 256);
		int num2 = kMP2.search(charr2);
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






public class Knuth
{
	
	
	public static void shuffle(object[] objarr)
	{
		int num = objarr.Length;
		for (int i = 0; i < num; i++)
		{
			int num2 = i + ByteCodeHelper.d2i(java.lang.Math.random() * (double)(num - i));
			object obj = objarr[num2];
			objarr[num2] = objarr[i];
			objarr[i] = obj;
		}
	}
	
	
	private Knuth()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		string[] array = StdIn.readAllStrings();
		Knuth.shuffle(array);
		for (int i = 0; i < array.Length; i++)
		{
			StdOut.println(array[i]);
		}
	}
}


public class MSD
{
	private const int R = 256;
	private const int CUTOFF = 15;
//[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
	internal static bool s_assertionsDisabled;
	
	
	
	
	private static void sort(string[] array, int num, int num2, int num3, string[] array2)
	{
		if (num2 <= num + 15)
		{
			MSD.insertion(array, num, num2, num3);
			return;
		}
		int[] array3 = new int[258];
		for (int i = num; i <= num2; i++)
		{
			int num4 = MSD.charAt(array[i], num3);
			int[] arg_33_0 = array3;
			int num5 = num4 + 2;
			int[] array4 = arg_33_0;
			array4[num5]++;
		}
		for (int i = 0; i < 257; i++)
		{
			int[] arg_54_0 = array3;
			int num5 = i + 1;
			int[] array4 = arg_54_0;
			array4[num5] += array3[i];
		}
		for (int i = num; i <= num2; i++)
		{
			int num4 = MSD.charAt(array[i], num3);
			int[] arg_7F_0 = array3;
			int num5 = num4 + 1;
			int[] array4 = arg_7F_0;
			int[] arg_8B_0 = array4;
			int arg_89_0 = num5;
			num5 = array4[num5];
			int num6 = arg_89_0;
			array4 = arg_8B_0;
			int arg_99_1 = num5;
			array4[num6] = num5 + 1;
			array2[arg_99_1] = array[i];
		}
		for (int i = num; i <= num2; i++)
		{
			array[i] = array2[i - num];
		}
		for (int i = 0; i < 256; i++)
		{
			MSD.sort(array, num + array3[i], num + array3[i + 1] - 1, num3 + 1, array2);
		}
	}
	
	
	private static void insertion(string[] array, int num, int num2, int num3)
	{
		for (int i = num; i <= num2; i++)
		{
			int num4 = i;
			while (num4 > num && MSD.less(array[num4], array[num4 - 1], num3))
			{
				MSD.exch(array, num4, num4 - 1);
				num4 += -1;
			}
		}
	}
	
	
	private static int charAt(string @this, int num)
	{
		if (!MSD.s_assertionsDisabled && (num < 0 || num > java.lang.String.instancehelper_length(@this)))
		{
			
			throw new AssertionError();
		}
		if (num == java.lang.String.instancehelper_length(@this))
		{
			return -1;
		}
		return (int)java.lang.String.instancehelper_charAt(@this, num);
	}
	
	
	private static bool less(string @this, string this2, int num)
	{
		if (!MSD.s_assertionsDisabled && !java.lang.String.instancehelper_equals(java.lang.String.instancehelper_substring(@this, 0, num), java.lang.String.instancehelper_substring(this2, 0, num)))
		{
			
			throw new AssertionError();
		}
		for (int i = num; i < java.lang.Math.min(java.lang.String.instancehelper_length(@this), java.lang.String.instancehelper_length(this2)); i++)
		{
			if (java.lang.String.instancehelper_charAt(@this, i) < java.lang.String.instancehelper_charAt(this2, i))
			{
				return true;
			}
			if (java.lang.String.instancehelper_charAt(@this, i) > java.lang.String.instancehelper_charAt(this2, i))
			{
				return false;
			}
		}
		return java.lang.String.instancehelper_length(@this) < java.lang.String.instancehelper_length(this2);
	}
	
	private static void exch(string[] array, int num, int num2)
	{
		string text = array[num];
		array[num] = array[num2];
		array[num2] = text;
	}
	
	
	public static void sort(string[] strarr)
	{
		int num = strarr.Length;
		string[] array = new string[num];
		MSD.sort(strarr, 0, num - 1, 0, array);
	}
	
	
	public MSD()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		string[] array = StdIn.readAllStrings();
		int num = array.Length;
		MSD.sort(array);
		for (int i = 0; i < num; i++)
		{
			StdOut.println(array[i]);
		}
	}
	
	static MSD()
	{
		MSD.s_assertionsDisabled = !ClassLiteral<MSD>.Value.desiredAssertionStatus();
	}
}

public class NFA
{
	private Digraph G;
	private string regexp;
	private int M;
//[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
	internal static bool s_assertionsDisabled;
	
	
	
	
	public NFA(string str)
	{
		this.regexp = str;
		this.M = java.lang.String.instancehelper_length(str);
		Stack stack = new Stack();
		this.G = new Digraph(this.M + 1);
		for (int i = 0; i < this.M; i++)
		{
			int num = i;
			if (java.lang.String.instancehelper_charAt(str, i) == '(' || java.lang.String.instancehelper_charAt(str, i) == '|')
			{
				stack.push(Integer.valueOf(i));
			}
			else if (java.lang.String.instancehelper_charAt(str, i) == ')')
			{
				int num2 = ((Integer)stack.pop()).intValue();
				if (java.lang.String.instancehelper_charAt(str, num2) == '|')
				{
					num = ((Integer)stack.pop()).intValue();
					this.G.addEdge(num, num2 + 1);
					this.G.addEdge(num2, i);
				}
				else if (java.lang.String.instancehelper_charAt(str, num2) == '(')
				{
					num = num2;
				}
				else if (!NFA.s_assertionsDisabled)
				{
					
					throw new AssertionError();
				}
			}
			if (i < this.M - 1 && java.lang.String.instancehelper_charAt(str, i + 1) == '*')
			{
				this.G.addEdge(num, i + 1);
				this.G.addEdge(i + 1, num);
			}
			if (java.lang.String.instancehelper_charAt(str, i) == '(' || java.lang.String.instancehelper_charAt(str, i) == '*' || java.lang.String.instancehelper_charAt(str, i) == ')')
			{
				this.G.addEdge(i, i + 1);
			}
		}
	}
	
	
	public virtual bool recognizes(string str)
	{
		DirectedDFS directedDFS = new DirectedDFS(this.G, 0);
		Bag bag = new Bag();
		for (int i = 0; i < this.G.V(); i++)
		{
			if (directedDFS.marked(i))
			{
				bag.add(Integer.valueOf(i));
			}
		}
		for (int i = 0; i < java.lang.String.instancehelper_length(str); i++)
		{
			Bag bag2 = new Bag();
			Iterator iterator = bag.iterator();
			while (iterator.hasNext())
			{
				int num = ((Integer)iterator.next()).intValue();
				if (num != this.M)
				{
					if (java.lang.String.instancehelper_charAt(this.regexp, num) == java.lang.String.instancehelper_charAt(str, i) || java.lang.String.instancehelper_charAt(this.regexp, num) == '.')
					{
						bag2.add(Integer.valueOf(num + 1));
					}
				}
			}
			directedDFS = new DirectedDFS(this.G, bag2);
			bag = new Bag();
			for (int j = 0; j < this.G.V(); j++)
			{
				if (directedDFS.marked(j))
				{
					bag.add(Integer.valueOf(j));
				}
			}
			if (bag.Size == 0)
			{
				return false;
			}
		}
		Iterator iterator2 = bag.iterator();
		while (iterator2.hasNext())
		{
			int num2 = ((Integer)iterator2.next()).intValue();
			if (num2 == this.M)
			{
				return true;
			}
		}
		return false;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		string str = new StringBuilder().append("(").append(strarr[0]).append(")").toString();
		string text = strarr[1];
		if (java.lang.String.instancehelper_indexOf(text, 124) >= 0)
		{
			string arg_40_0 = "| character in text is not supported";
			
			throw new ArgumentException(arg_40_0);
		}
		NFA nFA = new NFA(str);
		StdOut.println(nFA.recognizes(text));
	}
	
	static NFA()
	{
		NFA.s_assertionsDisabled = !ClassLiteral<NFA>.Value.desiredAssertionStatus();
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






public class Particle
{
	private const double INFINITY = double.PositiveInfinity;
	private double rx;
	private double ry;
	private double vx;
	private double vy;
	private double radius;
	private double mass;
	private Color color;
	private int count;
	
	
	public virtual double timeToHit(Particle p)
	{
		if (this == p)
		{
			return double.PositiveInfinity;
		}
		double num = p.rx - this.rx;
		double num2 = p.ry - this.ry;
		double num3 = p.vx - this.vx;
		double num4 = p.vy - this.vy;
		double num5 = num * num3 + num2 * num4;
		if (num5 > (double)0f)
		{
			return double.PositiveInfinity;
		}
		double num6 = num3 * num3 + num4 * num4;
		double num7 = num * num + num2 * num2;
		double num8 = this.radius + p.radius;
		double num9 = num5 * num5 - num6 * (num7 - num8 * num8);
		if (num9 < (double)0f)
		{
			return double.PositiveInfinity;
		}
		return -(num5 + java.lang.Math.sqrt(num9)) / num6;
	}
	public virtual double timeToHitVerticalWall()
	{
		if (this.vx > (double)0f)
		{
			return ((double)1f - this.rx - this.radius) / this.vx;
		}
		if (this.vx < (double)0f)
		{
			return (this.radius - this.rx) / this.vx;
		}
		return double.PositiveInfinity;
	}
	public virtual double timeToHitHorizontalWall()
	{
		if (this.vy > (double)0f)
		{
			return ((double)1f - this.ry - this.radius) / this.vy;
		}
		if (this.vy < (double)0f)
		{
			return (this.radius - this.ry) / this.vy;
		}
		return double.PositiveInfinity;
	}
	
	
	public virtual void draw()
	{
		StdDraw.setPenColor(this.color);
		StdDraw.filledCircle(this.rx, this.ry, this.radius);
	}
	
	public virtual void move(double d)
	{
		this.rx += this.vx * d;
		this.ry += this.vy * d;
	}
	
	public virtual void bounceOff(Particle p)
	{
		double num = p.rx - this.rx;
		double num2 = p.ry - this.ry;
		double num3 = p.vx - this.vx;
		double num4 = p.vy - this.vy;
		double num5 = num * num3 + num2 * num4;
		double num6 = this.radius + p.radius;
		double num7 = 2.0 * this.mass * p.mass * num5 / ((this.mass + p.mass) * num6);
		double num8 = num7 * num / num6;
		double num9 = num7 * num2 / num6;
		this.vx += num8 / this.mass;
		this.vy += num9 / this.mass;
		p.vx -= num8 / p.mass;
		p.vy -= num9 / p.mass;
		this.count++;
		p.count++;
	}
	
	public virtual void bounceOffVerticalWall()
	{
		this.vx = -this.vx;
		this.count++;
	}
	
	public virtual void bounceOffHorizontalWall()
	{
		this.vy = -this.vy;
		this.count++;
	}
	
	
	public Particle()
	{
		this.rx = java.lang.Math.random();
		this.ry = java.lang.Math.random();
		this.vx = 0.01 * (java.lang.Math.random() - 0.5);
		this.vy = 0.01 * (java.lang.Math.random() - 0.5);
		this.radius = 0.01;
		this.mass = 0.5;
		this.color = Color.BLACK;
	}
	
	
	public Particle(double d1, double d2, double d3, double d4, double d5, double d6, Color c)
	{
		this.vx = d3;
		this.vy = d4;
		this.rx = d1;
		this.ry = d2;
		this.radius = d5;
		this.mass = d6;
		this.color = c;
	}
	public virtual int count()
	{
		return this.count;
	}
	public virtual double kineticEnergy()
	{
		return 0.5 * this.mass * (this.vx * this.vx + this.vy * this.vy);
	}
}




using java.awt.@event;
using java.awt.image;




using javax.imageio;
using javax.swing;


/*[Implements(new string[]
{
	"java.awt.event.ActionListener"
})]*/
public sealed class Picture, ActionListener, EventListener
{
	private BufferedImage image;
	private JFrame frame;
	private string filename;
	private bool isOriginUpperLeft;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private int width;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private int height;
	
	
	public Picture(int i1, int i2)
	{
		this.isOriginUpperLeft = true;
		if (i1 < 0)
		{
			string arg_1D_0 = "width must be nonnegative";
			
			throw new ArgumentException(arg_1D_0);
		}
		if (i2 < 0)
		{
			string arg_31_0 = "height must be nonnegative";
			
			throw new ArgumentException(arg_31_0);
		}
		this.width = i1;
		this.height = i2;
		this.image = new BufferedImage(i1, i2, 1);
		this.filename = new StringBuilder().append(i1).append("-by-").append(i2).toString();
	}
	
	
	public virtual void set(int i1, int i2, Color c)
	{
		if (i1 < 0 || i1 >= this.width())
		{
			string arg_33_0 = new StringBuilder().append("x must be between 0 and ").append(this.width() - 1).toString();
			
			throw new IndexOutOfRangeException(arg_33_0);
		}
		if (i2 < 0 || i2 >= this.height())
		{
			string arg_6C_0 = new StringBuilder().append("y must be between 0 and ").append(this.height() - 1).toString();
			
			throw new IndexOutOfRangeException(arg_6C_0);
		}
		if (c == null)
		{
			string arg_7F_0 = "can't set Color to null";
			
			throw new NullPointerException(arg_7F_0);
		}
		if (this.isOriginUpperLeft)
		{
			this.image.setRGB(i1, i2, c.getRGB());
		}
		else
		{
			this.image.setRGB(i1, this.height - i2 - 1, c.getRGB());
		}
	}
	
	
	public virtual void show()
	{
		if (this.frame == null)
		{
			this.frame = new JFrame();
			JMenuBar jMenuBar = new JMenuBar();
			JMenu jMenu = new JMenu("File");
			jMenuBar.add(jMenu);
			JMenuItem jMenuItem = new JMenuItem(" Save...   ");
			jMenuItem.addActionListener(this);
			jMenuItem.setAccelerator(KeyStroke.getKeyStroke(83, Toolkit.getDefaultToolkit().getMenuShortcutKeyMask()));
			jMenu.add(jMenuItem);
			this.frame.setJMenuBar(jMenuBar);
			this.frame.setContentPane(this.getJLabel());
			this.frame.setDefaultCloseOperation(2);
			this.frame.setTitle(this.filename);
			this.frame.setResizable(false);
			this.frame.pack();
			this.frame.setVisible(true);
		}
		this.frame.repaint();
	}
	public virtual int width()
	{
		return this.width;
	}
	public virtual int height()
	{
		return this.height;
	}
	
	
	public virtual Color get(int i1, int i2)
	{
		if (i1 < 0 || i1 >= this.width())
		{
			string arg_33_0 = new StringBuilder().append("x must be between 0 and ").append(this.width() - 1).toString();
			
			throw new IndexOutOfRangeException(arg_33_0);
		}
		if (i2 < 0 || i2 >= this.height())
		{
			string arg_6C_0 = new StringBuilder().append("y must be between 0 and ").append(this.height() - 1).toString();
			
			throw new IndexOutOfRangeException(arg_6C_0);
		}
		if (this.isOriginUpperLeft)
		{
			Color.__<clinit>();
			return new Color(this.image.getRGB(i1, i2));
		}
		Color.__<clinit>();
		return new Color(this.image.getRGB(i1, this.height - i2 - 1));
	}
	
	
	public virtual JLabel getJLabel()
	{
		if (this.image == null)
		{
			return null;
		}
		ImageIcon.__<clinit>();
		ImageIcon imageIcon = new ImageIcon(this.image);
		return new JLabel(imageIcon);
	}
	
	
	public virtual void save(File f)
	{
		this.filename = f.getName();
		if (this.frame != null)
		{
			this.frame.setTitle(this.filename);
		}
		string text = java.lang.String.instancehelper_substring(this.filename, java.lang.String.instancehelper_lastIndexOf(this.filename, 46) + 1);
		text = java.lang.String.instancehelper_toLowerCase(text);
		if (!java.lang.String.instancehelper_equals(text, "jpg"))
		{
			if (!java.lang.String.instancehelper_equals(text, "png"))
			{
				System.@out.println("Error: filename must end in .jpg or .png");
				return;
			}
		}
		IOException ex;
		try
		{
			ImageIO.write(this.image, text, f);
		}
		catch (IOException arg_74_0)
		{
			ex = ByteCodeHelper.MapException<IOException>(arg_74_0, ByteCodeHelper.MapFlags.NoRemapping);
			goto IL_7E;
		}
		return;
		IL_7E:
		IOException this2 = ex;
		Throwable.instancehelper_printStackTrace(this2);
	}
	
	
	public virtual void save(string str)
	{
		this.save(new File(str));
	}
	
	
	public Picture(string str)
	{
		this.isOriginUpperLeft = true;
		this.filename = str;
		try
		{
			File file = new File(str);
			if (file.isFile())
			{
				this.image = ImageIO.read(file);
			}
			else
			{
				URL uRL = java.lang.Object.instancehelper_getClass(this).getResource(str);
				if (uRL == null)
				{
					uRL = new URL(str);
				}
				this.image = ImageIO.read(uRL);
			}
			this.width = this.image.getWidth(null);
			this.height = this.image.getHeight(null);
		}
		catch (IOException arg_7E_0)
		{
			goto IL_82;
		}
		return;
		IL_82:
		string arg_A7_0 = new StringBuilder().append("Could not open file: ").append(str).toString();
		
		throw new RuntimeException(arg_A7_0);
	}
	
	
	public Picture(Picture p)
	{
		this.isOriginUpperLeft = true;
		this.width = p.width();
		this.height = p.height();
		BufferedImage.__<clinit>();
		this.image = new BufferedImage(this.width, this.height, 1);
		this.filename = p.filename;
		for (int i = 0; i < this.width(); i++)
		{
			for (int j = 0; j < this.height(); j++)
			{
				this.image.setRGB(i, j, p.get(i, j).getRGB());
			}
		}
	}
	
	
	public Picture(File f)
	{
		this.isOriginUpperLeft = true;
		IOException ex;
		try
		{
			this.image = ImageIO.read(f);
		}
		catch (IOException arg_20_0)
		{
			ex = ByteCodeHelper.MapException<IOException>(arg_20_0, ByteCodeHelper.MapFlags.NoRemapping);
			goto IL_2A;
		}
		if (this.image == null)
		{
			string arg_82_0 = new StringBuilder().append("Invalid image file: ").append(f).toString();
			
			throw new RuntimeException(arg_82_0);
		}
		this.width = this.image.getWidth(null);
		this.height = this.image.getHeight(null);
		this.filename = f.getName();
		return;
		IL_2A:
		IOException this2 = ex;
		Throwable.instancehelper_printStackTrace(this2);
		string arg_55_0 = new StringBuilder().append("Could not open file: ").append(f).toString();
		
		throw new RuntimeException(arg_55_0);
	}
	public virtual void setOriginUpperLeft()
	{
		this.isOriginUpperLeft = true;
	}
	public virtual void setOriginLowerLeft()
	{
		this.isOriginUpperLeft = false;
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
		Picture picture = (Picture)obj;
		if (this.width() != picture.width())
		{
			return false;
		}
		if (this.height() != picture.height())
		{
			return false;
		}
		for (int i = 0; i < this.width(); i++)
		{
			for (int j = 0; j < this.height(); j++)
			{
				if (!this.get(i, j).Equals(picture.get(i, j)))
				{
					return false;
				}
			}
		}
		return true;
	}
	
	
	public virtual void actionPerformed(ActionEvent ae)
	{
		FileDialog.__<clinit>();
		FileDialog fileDialog = new FileDialog(this.frame, "Use a .png or .jpg extension", 1);
		fileDialog.setVisible(true);
		if (fileDialog.getFile() != null)
		{
			this.save(new StringBuilder().append(fileDialog.getDirectory()).append(File.separator).append(fileDialog.getFile()).toString());
		}
	}
	
	
	/**/public static void main(string[] strarr)
	{
		Picture picture = new Picture(strarr[0]);
		System.@out.printf("%d-by-%d\n", new object[]
		{
			Integer.valueOf(picture.width()),
			Integer.valueOf(picture.height())
		});
		picture.show();
	}
}






public class PictureDump
{
	
	
	public PictureDump()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		int num = Integer.parseInt(strarr[0]);
		int num2 = Integer.parseInt(strarr[1]);
		Picture picture = new Picture(num, num2);
		int num3 = 0;
		for (int i = 0; i < num2; i++)
		{
			for (int j = 0; j < num; j++)
			{
				picture.set(j, i, Color.RED);
				if (!BinaryStdIn.IsEmpty)
				{
					num3++;
					int num4 = BinaryStdIn.readBoolean() ? 1 : 0;
					if (num4 != 0)
					{
						picture.set(j, i, Color.BLACK);
					}
					else
					{
						picture.set(j, i, Color.WHITE);
					}
				}
			}
		}
		picture.show();
		StdOut.println(new StringBuilder().append(num3).append(" bits").toString());
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






public class PolynomialRegression
{
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private int N;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private int degree;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private object beta;
	private double SSE;
	private double SST;
	
	public virtual double beta(int i)
	{
		this.beta;
		i;
		0;
		throw new NoClassDefFoundError("Jama.Matrix");
	}
	public virtual double R2()
	{
		if (this.SST == (double)0f)
		{
			return (double)1f;
		}
		return (double)1f - this.SSE / this.SST;
	}
	
	
	public PolynomialRegression(double[] darr1, double[] darr2, int i)
	{
		this.degree = i;
		this.N = darr1.Length;
		int arg_2C_0 = this.N;
		int arg_27_0 = i + 1;
		int[] array = new int[2];
		int num = arg_27_0;
		array[1] = num;
		num = arg_2C_0;
		array[0] = num;
		double[][] array2 = (double[][])ByteCodeHelper.multianewarray(typeof(double[][]).TypeHandle, array);
		for (int j = 0; j < this.N; j++)
		{
			for (int k = 0; k <= i; k++)
			{
				array2[j][k] = java.lang.Math.pow(darr1[j], (double)k);
			}
		}
		throw new NoClassDefFoundError("Jama.Matrix");
	}
	public virtual int degree()
	{
		return this.degree;
	}
	
	
	public virtual double predict(double d)
	{
		double num = (double)0f;
		for (int i = this.degree; i >= 0; i += -1)
		{
			num = this.beta(i) + d * num;
		}
		return num;
	}
	
	
	public override string ToString()
	{
		string str = "";
		int i = this.degree;
		while (i >= 0 && java.lang.Math.abs(this.beta(i)) < 1E-05)
		{
			i += -1;
		}
		for (i = i; i >= 0; i += -1)
		{
			if (i == 0)
			{
				str = new StringBuilder().append(str).append(java.lang.String.format("%.2f ", new object[]
				{
					java.lang.Double.valueOf(this.beta(i))
				})).toString();
			}
			else if (i == 1)
			{
				str = new StringBuilder().append(str).append(java.lang.String.format("%.2f N + ", new object[]
				{
					java.lang.Double.valueOf(this.beta(i))
				})).toString();
			}
			else
			{
				str = new StringBuilder().append(str).append(java.lang.String.format("%.2f N^%d + ", new object[]
				{
					java.lang.Double.valueOf(this.beta(i)),
					Integer.valueOf(i)
				})).toString();
			}
		}
		return new StringBuilder().append(str).append("  (R^2 = ").append(java.lang.String.format("%.3f", new object[]
		{
			java.lang.Double.valueOf(this.R2())
		})).append(")").toString();
	}
	
	
	/**/public static void main(string[] strarr)
	{
		double[] darr = new double[]
		{
			10.0,
			20.0,
			40.0,
			80.0,
			160.0,
			200.0
		};
		double[] darr2 = new double[]
		{
			100.0,
			350.0,
			1500.0,
			6700.0,
			20160.0,
			40000.0
		};
		PolynomialRegression obj = new PolynomialRegression(darr, darr2, 3);
		StdOut.println(obj);
	}
}







public class PrimMST
{
	private Edge[] edgeTo;
	private double[] distTo;
	private bool[] marked;
//[Signature("LIndexMinPQ<Ljava/lang/Double;>;")]
	private IndexMinPQ pq;
//[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
	internal static bool s_assertionsDisabled;
	
	
	
	
	private void prim(EdgeWeightedGraph edgeWeightedGraph, int num)
	{
		this.distTo[num] = (double)0f;
		this.pq.insert(num, java.lang.Double.valueOf(this.distTo[num]));
		while (!this.pq.IsEmpty)
		{
			int num2 = this.pq.delMin();
			this.scan(edgeWeightedGraph, num2);
		}
	}
	
	
	private bool check(EdgeWeightedGraph edgeWeightedGraph)
	{
		double num = (double)0f;
		Iterator iterator = this.edges().iterator();
		while (iterator.hasNext())
		{
			Edge edge = (Edge)iterator.next();
			num += edge.weight();
		}
		double num2 = 1E-12;
		if (java.lang.Math.abs(num - this.weight()) > num2)
		{
			System.err.printf("Weight of edges does not equal weight(): %f vs. %f\n", new object[]
			{
				java.lang.Double.valueOf(num),
				java.lang.Double.valueOf(this.weight())
			});
			return false;
		}
		UF uF = new UF(edgeWeightedGraph.V());
		Iterator iterator2 = this.edges().iterator();
		while (iterator2.hasNext())
		{
			Edge edge2 = (Edge)iterator2.next();
			int num3 = edge2.either();
			int i = edge2.other(num3);
			if (uF.connected(num3, i))
			{
				System.err.println("Not a forest");
				return false;
			}
			uF.union(num3, i);
		}
		iterator2 = edgeWeightedGraph.edges().iterator();
		while (iterator2.hasNext())
		{
			Edge edge2 = (Edge)iterator2.next();
			int num3 = edge2.either();
			int i = edge2.other(num3);
			if (!uF.connected(num3, i))
			{
				System.err.println("Not a spanning forest");
				return false;
			}
		}
		iterator2 = this.edges().iterator();
		while (iterator2.hasNext())
		{
			Edge edge2 = (Edge)iterator2.next();
			uF = new UF(edgeWeightedGraph.V());
			Iterator iterator3 = this.edges().iterator();
			while (iterator3.hasNext())
			{
				Edge edge3 = (Edge)iterator3.next();
				int num4 = edge3.either();
				int i2 = edge3.other(num4);
				if (edge3 != edge2)
				{
					uF.union(num4, i2);
				}
			}
			iterator3 = edgeWeightedGraph.edges().iterator();
			while (iterator3.hasNext())
			{
				Edge edge3 = (Edge)iterator3.next();
				int num4 = edge3.either();
				int i2 = edge3.other(num4);
				if (!uF.connected(num4, i2) && edge3.weight() < edge2.weight())
				{
					System.err.println(new StringBuilder().append("Edge ").append(edge3).append(" violates cut optimality conditions").toString());
					return false;
				}
			}
		}
		return true;
	}
	
	
	private void scan(EdgeWeightedGraph edgeWeightedGraph, int num)
	{
		this.marked[num] = true;
		Iterator iterator = edgeWeightedGraph.adj(num).iterator();
		while (iterator.hasNext())
		{
			Edge edge = (Edge)iterator.next();
			int num2 = edge.other(num);
			if (!this.marked[num2])
			{
				if (edge.weight() < this.distTo[num2])
				{
					this.distTo[num2] = edge.weight();
					this.edgeTo[num2] = edge;
					if (this.pq.contains(num2))
					{
						this.pq.decreaseKey(num2, java.lang.Double.valueOf(this.distTo[num2]));
					}
					else
					{
						this.pq.insert(num2, java.lang.Double.valueOf(this.distTo[num2]));
					}
				}
			}
		}
	}
/*	[Signature("()Ljava/lang/Iterable<LEdge;>;")]*/
	
	public virtual Iterable edges()
	{
		Queue queue = new Queue();
		for (int i = 0; i < this.edgeTo.Length; i++)
		{
			Edge edge = this.edgeTo[i];
			if (edge != null)
			{
				queue.enqueue(edge);
			}
		}
		return queue;
	}
	
	
	public virtual double weight()
	{
		double num = (double)0f;
		Iterator iterator = this.edges().iterator();
		while (iterator.hasNext())
		{
			Edge edge = (Edge)iterator.next();
			num += edge.weight();
		}
		return num;
	}
	
	
	public PrimMST(EdgeWeightedGraph ewg)
	{
		this.edgeTo = new Edge[ewg.V()];
		this.distTo = new double[ewg.V()];
		this.marked = new bool[ewg.V()];
		this.pq = new IndexMinPQ(ewg.V());
		for (int i = 0; i < ewg.V(); i++)
		{
			this.distTo[i] = double.PositiveInfinity;
		}
		for (int i = 0; i < ewg.V(); i++)
		{
			if (!this.marked[i])
			{
				this.prim(ewg, i);
			}
		}
		if (!PrimMST.s_assertionsDisabled && !this.check(ewg))
		{
			
			throw new AssertionError();
		}
	}
	
	
	/**/public static void main(string[] strarr)
	{
		
		In i = new In(strarr[0]);
		EdgeWeightedGraph ewg = new EdgeWeightedGraph(i);
		PrimMST primMST = new PrimMST(ewg);
		Iterator iterator = primMST.edges().iterator();
		while (iterator.hasNext())
		{
			Edge obj = (Edge)iterator.next();
			StdOut.println(obj);
		}
		StdOut.printf("%.5f\n", new object[]
		{
			java.lang.Double.valueOf(primMST.weight())
		});
	}
	
	static PrimMST()
	{
		PrimMST.s_assertionsDisabled = !ClassLiteral<PrimMST>.Value.desiredAssertionStatus();
	}
}













public class Quick3string
{
	private const int CUTOFF = 15;
//[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
	internal static bool s_assertionsDisabled;
	
	
	
	
	private static void sort(string[] array, int num, int num2, int num3)
	{
		if (num2 <= num + 15)
		{
			Quick3string.insertion(array, num, num2, num3);
			return;
		}
		int num4 = num;
		int num5 = num2;
		int num6 = Quick3string.charAt(array[num], num3);
		int i = num + 1;
		while (i <= num5)
		{
			int num7 = Quick3string.charAt(array[i], num3);
			if (num7 < num6)
			{
				int arg_47_1 = num4;
				num4++;
				int arg_47_2 = i;
				i++;
				Quick3string.exch(array, arg_47_1, arg_47_2);
			}
			else if (num7 > num6)
			{
				int arg_5A_1 = i;
				int arg_5A_2 = num5;
				num5 += -1;
				Quick3string.exch(array, arg_5A_1, arg_5A_2);
			}
			else
			{
				i++;
			}
		}
		Quick3string.sort(array, num, num4 - 1, num3);
		if (num6 >= 0)
		{
			Quick3string.sort(array, num4, num5, num3 + 1);
		}
		Quick3string.sort(array, num5 + 1, num2, num3);
	}
	
	
	private static bool isSorted(string[] array)
	{
		for (int i = 1; i < array.Length; i++)
		{
			if (java.lang.String.instancehelper_compareTo(array[i], array[i - 1]) < 0)
			{
				return false;
			}
		}
		return true;
	}
	
	
	private static void insertion(string[] array, int num, int num2, int num3)
	{
		for (int i = num; i <= num2; i++)
		{
			int num4 = i;
			while (num4 > num && Quick3string.less(array[num4], array[num4 - 1], num3))
			{
				Quick3string.exch(array, num4, num4 - 1);
				num4 += -1;
			}
		}
	}
	
	
	private static int charAt(string @this, int num)
	{
		if (!Quick3string.s_assertionsDisabled && (num < 0 || num > java.lang.String.instancehelper_length(@this)))
		{
			
			throw new AssertionError();
		}
		if (num == java.lang.String.instancehelper_length(@this))
		{
			return -1;
		}
		return (int)java.lang.String.instancehelper_charAt(@this, num);
	}
	
	private static void exch(string[] array, int num, int num2)
	{
		string text = array[num];
		array[num] = array[num2];
		array[num2] = text;
	}
	
	
	private static bool less(string @this, string this2, int num)
	{
		if (!Quick3string.s_assertionsDisabled && !java.lang.String.instancehelper_equals(java.lang.String.instancehelper_substring(@this, 0, num), java.lang.String.instancehelper_substring(this2, 0, num)))
		{
			
			throw new AssertionError();
		}
		for (int i = num; i < java.lang.Math.min(java.lang.String.instancehelper_length(@this), java.lang.String.instancehelper_length(this2)); i++)
		{
			if (java.lang.String.instancehelper_charAt(@this, i) < java.lang.String.instancehelper_charAt(this2, i))
			{
				return true;
			}
			if (java.lang.String.instancehelper_charAt(@this, i) > java.lang.String.instancehelper_charAt(this2, i))
			{
				return false;
			}
		}
		return java.lang.String.instancehelper_length(@this) < java.lang.String.instancehelper_length(this2);
	}
	
	
	public static void sort(string[] strarr)
	{
		StdRandom.shuffle(strarr);
		Quick3string.sort(strarr, 0, strarr.Length - 1, 0);
		if (!Quick3string.s_assertionsDisabled && !Quick3string.isSorted(strarr))
		{
			
			throw new AssertionError();
		}
	}
	
	
	public Quick3string()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		string[] array = StdIn.readAllStrings();
		int num = array.Length;
		Quick3string.sort(array);
		for (int i = 0; i < num; i++)
		{
			StdOut.println(array[i]);
		}
	}
	
	static Quick3string()
	{
		Quick3string.s_assertionsDisabled = !ClassLiteral<Quick3string>.Value.desiredAssertionStatus();
	}
}






public class QuickFindUF
{
	private int[] id;
	private int count;
	
	public virtual bool connected(int i1, int i2)
	{
		return this.id[i1] == this.id[i2];
	}
	
	
	public QuickFindUF(int i)
	{
		this.count = i;
		this.id = new int[i];
		for (int j = 0; j < i; j++)
		{
			this.id[j] = j;
		}
	}
	
	
	public virtual void union(int i1, int i2)
	{
		if (this.connected(i1, i2))
		{
			return;
		}
		int num = this.id[i1];
		for (int j = 0; j < this.id.Length; j++)
		{
			if (this.id[j] == num)
			{
				this.id[j] = this.id[i2];
			}
		}
		this.count--;
	}
	public virtual int count()
	{
		return this.count;
	}
	
	public virtual int find(int i)
	{
		return this.id[i];
	}
	
	
	/**/public static void main(string[] strarr)
	{
		int i = StdIn.readInt();
		QuickFindUF quickFindUF = new QuickFindUF(i);
		while (!StdIn.IsEmpty)
		{
			int num = StdIn.readInt();
			int num2 = StdIn.readInt();
			if (!quickFindUF.connected(num, num2))
			{
				quickFindUF.union(num, num2);
				StdOut.println(new StringBuilder().append(num).append(" ").append(num2).toString());
			}
		}
		StdOut.println(new StringBuilder().append(quickFindUF.count()).append(" components").toString());
	}
}





public class RabinKarp
{
	private string pat;
	private long patHash;
	private int M;
	private long Q;
	private int R;
	private long RM;
	
	
	private static long longRandomPrime()
	{
		BigInteger bigInteger = BigInteger.probablePrime(31, new java.util.Random());
		return bigInteger.longValue();
	}
	
	
	private long hash(string this2, int num)
	{
		long num2 = 0L;
		for (int i = 0; i < num; i++)
		{
			long expr_1A = (long)this.R * num2 + (long)java.lang.String.instancehelper_charAt(this2, i);
			long expr_21 = this.Q;
			num2 = ((expr_21 != -1L) ? (expr_1A % expr_21) : 0L);
		}
		return num2;
	}
	
	
	private bool check(string this2, int num)
	{
		for (int i = 0; i < this.M; i++)
		{
			if (java.lang.String.instancehelper_charAt(this.pat, i) != java.lang.String.instancehelper_charAt(this2, num + i))
			{
				return false;
			}
		}
		return true;
	}
	
	
	public RabinKarp(string str)
	{
		this.pat = str;
		this.R = 256;
		this.M = java.lang.String.instancehelper_length(str);
		this.Q = RabinKarp.longRandomPrime();
		this.RM = 1L;
		for (int i = 1; i <= this.M - 1; i++)
		{
			long expr_54 = (long)this.R * this.RM;
			long expr_5B = this.Q;
			this.RM = ((expr_5B != -1L) ? (expr_54 % expr_5B) : 0L);
		}
		this.patHash = this.hash(str, this.M);
	}
	
	
	public virtual int search(string str)
	{
		int num = java.lang.String.instancehelper_length(str);
		if (num < this.M)
		{
			return num;
		}
		long num2 = this.hash(str, this.M);
		if (this.patHash == num2 && this.check(str, 0))
		{
			return 0;
		}
		for (int i = this.M; i < num; i++)
		{
			long arg_73_0 = num2 + this.Q;
			long expr_60 = this.RM * (long)java.lang.String.instancehelper_charAt(str, i - this.M);
			long expr_67 = this.Q;
			long expr_73 = arg_73_0 - ((expr_67 != -1L) ? (expr_60 % expr_67) : 0L);
			long expr_7A = this.Q;
			num2 = ((expr_7A != -1L) ? (expr_73 % expr_7A) : 0L);
			long expr_98 = num2 * (long)this.R + (long)java.lang.String.instancehelper_charAt(str, i);
			long expr_9F = this.Q;
			num2 = ((expr_9F != -1L) ? (expr_98 % expr_9F) : 0L);
			int num3 = i - this.M + 1;
			if (this.patHash == num2 && this.check(str, num3))
			{
				return num3;
			}
		}
		return num;
	}
	
	
	public RabinKarp(int i, char[] charr)
	{
		string arg_10_0 = "Operation not supported yet";
		
		throw new NotSupportedException(arg_10_0);
	}
	private bool check(int num)
	{
		return true;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		string text = strarr[0];
		string text2 = strarr[1];
		java.lang.String.instancehelper_toCharArray(text);
		java.lang.String.instancehelper_toCharArray(text2);
		RabinKarp rabinKarp = new RabinKarp(text);
		int num = rabinKarp.search(text2);
		StdOut.println(new StringBuilder().append("text:    ").append(text2).toString());
		StdOut.print("pattern: ");
		for (int i = 0; i < num; i++)
		{
			StdOut.print(" ");
		}
		StdOut.println(text);
	}
}





public class RandomSeq
{
	
	
	private RandomSeq()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		int num = Integer.parseInt(strarr[0]);
		if (strarr.Length == 1)
		{
			for (int i = 0; i < num; i++)
			{
				double d = StdRandom.uniform();
				StdOut.println(d);
			}
		}
		else
		{
			if (strarr.Length != 3)
			{
				string arg_87_0 = "Invalid number of arguments";
				
				throw new ArgumentException(arg_87_0);
			}
			double d2 = java.lang.Double.parseDouble(strarr[1]);
			double d3 = java.lang.Double.parseDouble(strarr[2]);
			for (int j = 0; j < num; j++)
			{
				double d4 = StdRandom.uniform(d2, d3);
				StdOut.printf("%.2f\n", new object[]
				{
					java.lang.Double.valueOf(d4)
				});
			}
		}
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







//[Signature("<Key:Ljava/lang/Object;Value:Ljava/lang/Object;>Ljava/lang/Object;")]
public class SeparateChainingHashST
{
	private const int INIT_CAPACITY = 4;
	private int N;
	private int M;
//[Signature("[LSequentialSearchST<TKey;TValue;>;")]
	private SequentialSearchST[] st;
	
	
	public SeparateChainingHashST(int i)
	{
		this.M = i;
		this.st = (SequentialSearchST[])new SequentialSearchST[i];
		for (int j = 0; j < i; j++)
		{
			this.st[j] = new SequentialSearchST();
		}
	}
/*	[Signature("(TKey;TValue;)V")]*/
	
	public virtual void put(object obj1, object obj2)
	{
		if (obj2 == null)
		{
			this.delete(obj1);
			return;
		}
		if (this.N >= 10 * this.M)
		{
			this.resize(2 * this.M);
		}
		int num = this.hash(obj1);
		if (!this.st[num].contains(obj1))
		{
			this.N++;
		}
		this.st[num].put(obj1, obj2);
	}
	public virtual int Size
	{
		return this.N;
	}
/*	[Signature("(TKey;)TValue;")]*/
	
	public virtual object get(object obj)
	{
		int num = this.hash(obj);
		return this.st[num].get(obj);
	}
/*	[LineNumberTable(56), Signature("(TKey;)I")]*/
	
	private int hash(object this2)
	{
		int expr_0B = java.lang.Object.instancehelper_hashCode(this2) & 2147483647;
		int expr_12 = this.M;
		return (expr_12 != -1) ? (expr_0B % expr_12) : 0;
	}
/*	[Signature("(TKey;)V")]*/
	
	public virtual void delete(object obj)
	{
		int num = this.hash(obj);
		if (this.st[num].contains(obj))
		{
			this.N--;
		}
		this.st[num].delete(obj);
		if (this.M > 4 && this.N <= 2 * this.M)
		{
			this.resize(this.M / 2);
		}
	}
	
	
	private void resize(int i)
	{
		SeparateChainingHashST separateChainingHashST = new SeparateChainingHashST(i);
		for (int j = 0; j < this.M; j++)
		{
			Iterator iterator = this.st[j].keys().iterator();
			while (iterator.hasNext())
			{
				object obj = iterator.next();
				separateChainingHashST.put(obj, this.st[j].get(obj));
			}
		}
		this.M = separateChainingHashST.M;
		this.N = separateChainingHashST.N;
		this.st = separateChainingHashST.st;
	}
	
	
	public SeparateChainingHashST() : this(4)
	{
	}
/*	[Signature("()Ljava/lang/Iterable<TKey;>;")]*/
	
	public virtual Iterable keys()
	{
		Queue queue = new Queue();
		for (int i = 0; i < this.M; i++)
		{
			Iterator iterator = this.st[i].keys().iterator();
			while (iterator.hasNext())
			{
				object obj = iterator.next();
				queue.enqueue(obj);
			}
		}
		return queue;
	}
	
	
	public virtual bool IsEmpty
	{
		return this.Size == 0;
	}
/*	[LineNumberTable(71), Signature("(TKey;)Z")]*/
	
	public virtual bool contains(object obj)
	{
		return this.get(obj) != null;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		SeparateChainingHashST separateChainingHashST = new SeparateChainingHashST();
		int num = 0;
		while (!StdIn.IsEmpty)
		{
			string text = StdIn.readString();
			separateChainingHashST.put(text, Integer.valueOf(num));
			num++;
		}
		Iterator iterator = separateChainingHashST.keys().iterator();
		while (iterator.hasNext())
		{
			string text = (string)iterator.next();
			StdOut.println(new StringBuilder().append(text).append(" ").append(separateChainingHashST.get(text)).toString());
		}
	}
}






//[Signature("<Key:Ljava/lang/Object;Value:Ljava/lang/Object;>Ljava/lang/Object;")]
public class SequentialSearchST
{
	[InnerClass(null, Modifiers.Private), Modifiers(Modifiers.Super), SourceFile("SequentialSearchST.java")]
	internal sealed class Node
	{
//[Signature("TKey;")]
		private object key;
//[Signature("TValue;")]
		private object val;
//[Signature("LSequentialSearchST<TKey;TValue;>.Node;")]
		private SequentialSearchST.Node next;
//[Modifiers(Modifiers.Final | Modifiers.Synthetic)]
		internal SequentialSearchST sequentialSearchST;
/*		[LineNumberTable(60), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static object access_100(SequentialSearchST.Node node)
		{
			return node.key;
		}
/*		[LineNumberTable(60), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static object access_200(SequentialSearchST.Node node)
		{
			return node.val;
		}
/*		[LineNumberTable(60), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static SequentialSearchST.Node access_000(SequentialSearchST.Node node)
		{
			return node.next;
		}
/*		[LineNumberTable(60), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static object access_202(SequentialSearchST.Node node, object result)
		{
			node.val = result;
			return result;
		}
/*		[Signature("(TKey;TValue;LSequentialSearchST<TKey;TValue;>.Node;)V")]*/
		
		public Node(SequentialSearchST sequentialSearchST, object obj, object obj2, SequentialSearchST.Node node)
		{
			this.key = obj;
			this.val = obj2;
			this.next = node;
		}
/*		[LineNumberTable(60), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static SequentialSearchST.Node access_002(SequentialSearchST.Node node, SequentialSearchST.Node result)
		{
			node.next = result;
			return result;
		}
	}
	private int N;
//[Signature("LSequentialSearchST<TKey;TValue;>.Node;")]
	private SequentialSearchST.Node first;
	
	
	public SequentialSearchST()
	{
	}
/*	[Signature("()Ljava/lang/Iterable<TKey;>;")]*/
	
	public virtual Iterable keys()
	{
		Queue queue = new Queue();
		for (SequentialSearchST.Node node = this.first; node != null; node = SequentialSearchST.Node.access_000(node))
		{
			queue.enqueue(SequentialSearchST.Node.access_100(node));
		}
		return queue;
	}
/*	[Signature("(TKey;)TValue;")]*/
	
	public virtual object get(object obj)
	{
		for (SequentialSearchST.Node node = this.first; node != null; node = SequentialSearchST.Node.access_000(node))
		{
			if (java.lang.Object.instancehelper_equals(obj, SequentialSearchST.Node.access_100(node)))
			{
				return SequentialSearchST.Node.access_200(node);
			}
		}
		return null;
	}
/*	[LineNumberTable(101), Signature("(TKey;)Z")]*/
	
	public virtual bool contains(object obj)
	{
		return this.get(obj) != null;
	}
/*	[Signature("(TKey;TValue;)V")]*/
	
	public virtual void put(object obj1, object obj2)
	{
		if (obj2 == null)
		{
			this.delete(obj1);
			return;
		}
		for (SequentialSearchST.Node node = this.first; node != null; node = SequentialSearchST.Node.access_000(node))
		{
			if (java.lang.Object.instancehelper_equals(obj1, SequentialSearchST.Node.access_100(node)))
			{
				SequentialSearchST.Node.access_202(node, obj2);
				return;
			}
		}
		this.first = new SequentialSearchST.Node(this, obj1, obj2, this.first);
		this.N++;
	}
/*	[Signature("(TKey;)V")]*/
	
	public virtual void delete(object obj)
	{
		this.first = this.delete(this.first, obj);
	}
	public virtual int Size
	{
		return this.N;
	}
/*	[Signature("(LSequentialSearchST<TKey;TValue;>.Node;TKey;)LSequentialSearchST<TKey;TValue;>.Node;")]*/
	
	private SequentialSearchST.Node delete(SequentialSearchST.Node node, object obj)
	{
		if (node == null)
		{
			return null;
		}
		if (java.lang.Object.instancehelper_equals(obj, SequentialSearchST.Node.access_100(node)))
		{
			this.N--;
			return SequentialSearchST.Node.access_000(node);
		}
		SequentialSearchST.Node.access_002(node, this.delete(SequentialSearchST.Node.access_000(node), obj));
		return node;
	}
	
	
	public virtual bool IsEmpty
	{
		return this.Size == 0;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		SequentialSearchST sequentialSearchST = new SequentialSearchST();
		int num = 0;
		while (!StdIn.IsEmpty)
		{
			string text = StdIn.readString();
			sequentialSearchST.put(text, Integer.valueOf(num));
			num++;
		}
		Iterator iterator = sequentialSearchST.keys().iterator();
		while (iterator.hasNext())
		{
			string text = (string)iterator.next();
			StdOut.println(new StringBuilder().append(text).append(" ").append(sequentialSearchST.get(text)).toString());
		}
	}
}









/*[Implements(new string[]
{
	"java.lang.Iterable"
}), Signature("<Key::Ljava/lang/Comparable<TKey;>;>Ljava/lang/Object;Ljava/lang/Iterable<TKey;>;")]*/
public class SET : IEnumerable
{
//[Signature("Ljava/util/TreeSet<TKey;>;")]
	private TreeSet set;
	
	
	public SET()
	{
		this.set = new TreeSet();
	}
/*	[Signature("(TKey;)V")]*/
	
	public virtual void add(IComparable c)
	{
		if (c == null)
		{
			string arg_0D_0 = "called add() with a null key";
			
			throw new NullPointerException(arg_0D_0);
		}
		this.set.add(c);
	}
/*	[Signature("(TKey;)Z")]*/
	
	public virtual bool contains(IComparable c)
	{
		if (c == null)
		{
			string arg_0D_0 = "called contains() with a null key";
			
			throw new NullPointerException(arg_0D_0);
		}
		return this.set.contains(c);
	}
/*	[LineNumberTable(111), Signature("()Ljava/util/Iterator<TKey;>;")]*/
	
	public virtual Iterator iterator()
	{
		return this.set.iterator();
	}
	
	
	public virtual int Size
	{
		return this.set.Size;
	}
	
	
	public virtual bool IsEmpty
	{
		return this.Size == 0;
	}
/*	[Signature("(TKey;)TKey;")]*/
	
	public virtual IComparable ceiling(IComparable c)
	{
		if (c == null)
		{
			string arg_0D_0 = "called ceiling() with a null key";
			
			throw new NullPointerException(arg_0D_0);
		}
		IComparable comparable = (IComparable)this.set.ceiling(c);
		if (comparable == null)
		{
			string arg_47_0 = new StringBuilder().append("all keys are less than ").append(c).toString();
			
			throw new InvalidOperationException(arg_47_0);
		}
		return comparable;
	}
/*	[Signature("(TKey;)TKey;")]*/
	
	public virtual IComparable floor(IComparable c)
	{
		if (c == null)
		{
			string arg_0D_0 = "called floor() with a null key";
			
			throw new NullPointerException(arg_0D_0);
		}
		IComparable comparable = (IComparable)this.set.floor(c);
		if (comparable == null)
		{
			string arg_47_0 = new StringBuilder().append("all keys are greater than ").append(c).toString();
			
			throw new InvalidOperationException(arg_47_0);
		}
		return comparable;
	}
/*	[Signature("(TKey;)V")]*/
	
	public virtual void delete(IComparable c)
	{
		if (c == null)
		{
			string arg_0D_0 = "called delete() with a null key";
			
			throw new NullPointerException(arg_0D_0);
		}
		this.set.remove(c);
	}
/*	[Signature("()TKey;")]*/
	
	public virtual IComparable Max
	{
		if (this.IsEmpty)
		{
			string arg_12_0 = "called Max with empty set";
			
			throw new InvalidOperationException(arg_12_0);
		}
		return (IComparable)this.set.last();
	}
/*	[Signature("()TKey;")]*/
	
	public virtual IComparable Min
	{
		if (this.IsEmpty)
		{
			string arg_12_0 = "called Min with empty set";
			
			throw new InvalidOperationException(arg_12_0);
		}
		return (IComparable)this.set.first();
	}
/*	[Signature("(LSET<TKey;>;)LSET<TKey;>;")]*/
	
	public virtual SET union(SET set)
	{
		if (set == null)
		{
			string arg_0D_0 = "called union() with a null argument";
			
			throw new NullPointerException(arg_0D_0);
		}
		SET sET = new SET();
		Iterator iterator = this.iterator();
		while (iterator.hasNext())
		{
			IComparable c = (IComparable)iterator.next();
			sET.add(c);
		}
		iterator = set.iterator();
		while (iterator.hasNext())
		{
			IComparable c = (IComparable)iterator.next();
			sET.add(c);
		}
		return sET;
	}
/*	[Signature("(LSET<TKey;>;)LSET<TKey;>;")]*/
	
	public virtual SET intersects(SET set)
	{
		if (set == null)
		{
			string arg_0D_0 = "called intersects() with a null argument";
			
			throw new NullPointerException(arg_0D_0);
		}
		SET sET = new SET();
		if (this.Size < set.Size)
		{
			Iterator iterator = this.iterator();
			while (iterator.hasNext())
			{
				IComparable c = (IComparable)iterator.next();
				if (set.contains(c))
				{
					sET.add(c);
				}
			}
		}
		else
		{
			Iterator iterator = set.iterator();
			while (iterator.hasNext())
			{
				IComparable c = (IComparable)iterator.next();
				if (this.contains(c))
				{
					sET.add(c);
				}
			}
		}
		return sET;
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
		SET sET = (SET)obj;
		if (this.Size != sET.Size)
		{
			return false;
		}
		try
		{
			Iterator iterator = this.iterator();
			while (iterator.hasNext())
			{
				IComparable c = (IComparable)iterator.next();
				if (!sET.contains(c))
				{
					return false;
				}
			}
		}
		catch (System.Exception arg_5F_0)
		{
			if (ByteCodeHelper.MapException<ClassCastException>(arg_5F_0, ByteCodeHelper.MapFlags.Unused) == null)
			{
				throw;
			}
			return false;
		}
		return true;
	}
	
	
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		Iterator iterator = this.iterator();
		while (iterator.hasNext())
		{
			IComparable obj = (IComparable)iterator.next();
			stringBuilder.append(new StringBuilder().append(obj).append(" ").toString());
		}
		return stringBuilder.toString();
	}
	
	
	/**/public static void main(string[] strarr)
	{
		SET sET = new SET();
		sET.add("www.cs.princeton.edu");
		sET.add("www.cs.princeton.edu");
		sET.add("www.princeton.edu");
		sET.add("www.math.princeton.edu");
		sET.add("www.yale.edu");
		sET.add("www.amazon.com");
		sET.add("www.simpsons.com");
		sET.add("www.stanford.edu");
		sET.add("www.google.com");
		sET.add("www.ibm.com");
		sET.add("www.apple.com");
		sET.add("www.slashdot.com");
		sET.add("www.whitehouse.gov");
		sET.add("www.espn.com");
		sET.add("www.snopes.com");
		sET.add("www.movies.com");
		sET.add("www.cnn.com");
		sET.add("www.iitb.ac.in");
		StdOut.println(sET.contains("www.cs.princeton.edu"));
		StdOut.println(!sET.contains("www.harvardsucks.com"));
		StdOut.println(sET.contains("www.simpsons.com"));
		StdOut.println();
		StdOut.println(new StringBuilder().append("ceiling(www.simpsonr.com) = ").append((string)sET.ceiling("www.simpsonr.com")).toString());
		StdOut.println(new StringBuilder().append("ceiling(www.simpsons.com) = ").append((string)sET.ceiling("www.simpsons.com")).toString());
		StdOut.println(new StringBuilder().append("ceiling(www.simpsont.com) = ").append((string)sET.ceiling("www.simpsont.com")).toString());
		StdOut.println(new StringBuilder().append("floor(www.simpsonr.com)   = ").append((string)sET.floor("www.simpsonr.com")).toString());
		StdOut.println(new StringBuilder().append("floor(www.simpsons.com)   = ").append((string)sET.floor("www.simpsons.com")).toString());
		StdOut.println(new StringBuilder().append("floor(www.simpsont.com)   = ").append((string)sET.floor("www.simpsont.com")).toString());
		StdOut.println();
		Iterator iterator = sET.iterator();
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








/*[Implements(new string[]
{
	"java.lang.Iterable"
}), Signature("<Key::Ljava/lang/Comparable<TKey;>;Value:Ljava/lang/Object;>Ljava/lang/Object;Ljava/lang/Iterable<TKey;>;")]*/
public class ST : IEnumerable
{
//[Signature("Ljava/util/TreeMap<TKey;TValue;>;")]
	private TreeMap st;
	
	
	public ST()
	{
		this.st = new TreeMap();
	}
/*	[Signature("(TKey;)Z")]*/
	
	public virtual bool contains(IComparable c)
	{
		if (c == null)
		{
			string arg_0D_0 = "called contains() with null key";
			
			throw new NullPointerException(arg_0D_0);
		}
		return this.st.containsKey(c);
	}
/*	[Signature("(TKey;TValue;)V")]*/
	
	public virtual void put(IComparable c, object obj)
	{
		if (c == null)
		{
			string arg_0D_0 = "called put() with null key";
			
			throw new NullPointerException(arg_0D_0);
		}
		if (obj == null)
		{
			this.st.remove(c);
		}
		else
		{
			this.st.put(c, obj);
		}
	}
/*	[Signature("(TKey;)TValue;")]*/
	
	public virtual object get(IComparable c)
	{
		if (c == null)
		{
			string arg_0D_0 = "called get() with null key";
			
			throw new NullPointerException(arg_0D_0);
		}
		return this.st.get(c);
	}
/*	[LineNumberTable(130), Signature("()Ljava/lang/Iterable<TKey;>;")]*/
	
	public virtual Iterable keys()
	{
		return this.st.keySet();
	}
/*	[Signature("(TKey;)V")]*/
	
	public virtual void delete(IComparable c)
	{
		if (c == null)
		{
			string arg_0D_0 = "called delete() with null key";
			
			throw new NullPointerException(arg_0D_0);
		}
		this.st.remove(c);
	}
	
	
	public virtual int Size
	{
		return this.st.Size;
	}
	
	
	public virtual bool IsEmpty
	{
		return this.Size == 0;
	}
	[LineNumberTable(143), Signature("()Ljava/util/Iterator<TKey;>;"), Obsolete]
	
	public virtual Iterator iterator()
	{
		return this.st.keySet().iterator();
	}
/*	[Signature("()TKey;")]*/
	
	public virtual IComparable Min
	{
		if (this.IsEmpty)
		{
			string arg_12_0 = "called Min with empty symbol table";
			
			throw new InvalidOperationException(arg_12_0);
		}
		return (IComparable)this.st.firstKey();
	}
/*	[Signature("()TKey;")]*/
	
	public virtual IComparable Max
	{
		if (this.IsEmpty)
		{
			string arg_12_0 = "called Max with empty symbol table";
			
			throw new InvalidOperationException(arg_12_0);
		}
		return (IComparable)this.st.lastKey();
	}
/*	[Signature("(TKey;)TKey;")]*/
	
	public virtual IComparable ceiling(IComparable c)
	{
		if (c == null)
		{
			string arg_0D_0 = "called ceiling() with null key";
			
			throw new NullPointerException(arg_0D_0);
		}
		IComparable comparable = (IComparable)this.st.ceilingKey(c);
		if (comparable == null)
		{
			string arg_47_0 = new StringBuilder().append("all keys are less than ").append(c).toString();
			
			throw new InvalidOperationException(arg_47_0);
		}
		return comparable;
	}
/*	[Signature("(TKey;)TKey;")]*/
	
	public virtual IComparable floor(IComparable c)
	{
		if (c == null)
		{
			string arg_0D_0 = "called floor() with null key";
			
			throw new NullPointerException(arg_0D_0);
		}
		IComparable comparable = (IComparable)this.st.floorKey(c);
		if (comparable == null)
		{
			string arg_47_0 = new StringBuilder().append("all keys are greater than ").append(c).toString();
			
			throw new InvalidOperationException(arg_47_0);
		}
		return comparable;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		ST sT = new ST();
		int num = 0;
		while (!StdIn.IsEmpty)
		{
			string text = StdIn.readString();
			sT.put(text, Integer.valueOf(num));
			num++;
		}
		Iterator iterator = sT.keys().iterator();
		while (iterator.hasNext())
		{
			string text = (string)iterator.next();
			StdOut.println(new StringBuilder().append(text).append(" ").append(sT.get(text)).toString());
		}
	}
	
	IEnumerator IEnumerable.GetEnumerator()
	{
		return new IterableEnumerator(this);
	}
}








/*[Implements(new string[]
{
	"java.lang.Iterable"
}), Signature("<Item:Ljava/lang/Object;>Ljava/lang/Object;Ljava/lang/Iterable<TItem;>;")]*/
public class Stack : IEnumerable
{
	/*[EnclosingMethod("Stack", null, null), InnerClass(null, Modifiers.Static | Modifiers.Synthetic), Modifiers(Modifiers.Super | Modifiers.Synthetic), SourceFile("Stack.java")]*/
	
	/*[Implements(new string[]
	{
		"java.util.Iterator"
	}), InnerClass(null, Modifiers.Private), Modifiers(Modifiers.Super), Signature("<Item:Ljava/lang/Object;>Ljava/lang/Object;Ljava/util/Iterator<TItem;>;"), SourceFile("Stack.java")]*/
	internal sealed class ListIterator : IEnumerator
	{
//[Signature("LStack$Node<TItem;>;")]
		private Stack.Node current;
//[Modifiers(Modifiers.Final | Modifiers.Synthetic)]
		internal Stack stack;
/*		[Signature("(LStack$Node<TItem;>;)V")]*/
		
		public ListIterator(Stack stack, Stack.Node node)
		{
			this.current = node;
		}
		public bool MoveNext()
		{
			return this.current != null;
		}
		
		
		public void Reset()
		{
			
			throw new NotSupportedException();
		}
/*		[Signature("()TItem;")]*/
		
		public object Current { get }
		{
			if (!MoveNext())
			{
				
				throw new InvalidOperationException();
			}
			object result = Stack.Node.access_100(this.current);
			this.current = Stack.Node.access_200(this.current);
			return result;
		}
	}
	[InnerClass(null, Modifiers.Private | Modifiers.Static), Modifiers(Modifiers.Super), Signature("<Item:Ljava/lang/Object;>Ljava/lang/Object;"), SourceFile("Stack.java")]
	internal sealed class Node
	{
//[Signature("TItem;")]
		private object item;
//[Signature("LStack$Node<TItem;>;")]
		private Stack.Node next;
/*		[LineNumberTable(47), Modifiers(Modifiers.Synthetic)]*/
		
		internal Node(Stack.1) : this()
		{
		}
/*		[LineNumberTable(47), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static object access_102(Stack.Node node, object result)
		{
			node.item = result;
			return result;
		}
/*		[LineNumberTable(47), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static Stack.Node access_202(Stack.Node node, Stack.Node result)
		{
			node.next = result;
			return result;
		}
/*		[LineNumberTable(47), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static object access_100(Stack.Node node)
		{
			return node.item;
		}
/*		[LineNumberTable(47), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static Stack.Node access_200(Stack.Node node)
		{
			return node.next;
		}
		
		
		private Node()
		{
		}
	}
	private int N;
//[Signature("LStack$Node<TItem;>;")]
	private Stack.Node first;
	
	
	public Stack()
	{
		this.first = null;
		this.N = 0;
	}
/*	[Signature("(TItem;)V")]*/
	
	public virtual void push(object obj)
	{
		Stack.Node node = this.first;
		this.first = new Stack.Node(null);
		Stack.Node.access_102(this.first, obj);
		Stack.Node.access_202(this.first, node);
		this.N++;
	}
/*	[LineNumberTable(129), Signature("()Ljava/util/Iterator<TItem;>;")]*/
	
	public virtual Iterator iterator()
	{
		return new Stack.ListIterator(this, this.first);
	}
/*	[Signature("()TItem;")]*/
	
	public virtual object peek()
	{
		if (this.IsEmpty)
		{
			string arg_12_0 = "Stack underflow";
			
			throw new InvalidOperationException(arg_12_0);
		}
		return Stack.Node.access_100(this.first);
	}
/*	[Signature("()TItem;")]*/
	
	public virtual object pop()
	{
		if (this.IsEmpty)
		{
			string arg_12_0 = "Stack underflow";
			
			throw new InvalidOperationException(arg_12_0);
		}
		object result = Stack.Node.access_100(this.first);
		this.first = Stack.Node.access_200(this.first);
		this.N--;
		return result;
	}
	public virtual int Size
	{
		return this.N;
	}
	public virtual bool IsEmpty
	{
		return this.first == null;
	}
	
	
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		Iterator iterator = this.iterator();
		while (iterator.hasNext())
		{
			object obj = iterator.next();
			stringBuilder.append(new StringBuilder().append(obj).append(" ").toString());
		}
		return stringBuilder.toString();
	}
	
	
	/**/public static void main(string[] strarr)
	{
		Stack stack = new Stack();
		while (!StdIn.IsEmpty)
		{
			string text = StdIn.readString();
			if (!java.lang.String.instancehelper_equals(text, "-"))
			{
				stack.push(text);
			}
			else if (!stack.IsEmpty)
			{
				StdOut.print(new StringBuilder().append((string)stack.pop()).append(" ").toString());
			}
		}
		StdOut.println(new StringBuilder().append("(").append(stack.Size).append(" left on stack)").toString());
	}
	
	IEnumerator IEnumerable.GetEnumerator()
	{
		return new IterableEnumerator(this);
	}
}






public class StaticSETofInts
{
	private int[] a;
	
	public virtual int rank(int i)
	{
		int j = 0;
		int num = this.a.Length - 1;
		while (j <= num)
		{
			int num2 = j + (num - j) / 2;
			if (i < this.a[num2])
			{
				num = num2 - 1;
			}
			else
			{
				if (i <= this.a[num2])
				{
					return num2;
				}
				j = num2 + 1;
			}
		}
		return -1;
	}
	
	
	public StaticSETofInts(int[] iarr)
	{
		this.a = new int[iarr.Length];
		for (int i = 0; i < iarr.Length; i++)
		{
			this.a[i] = iarr[i];
		}
		Arrays.sort(this.a);
		for (int i = 1; i < this.a.Length; i++)
		{
			if (this.a[i] == this.a[i - 1])
			{
				string arg_62_0 = "Argument arrays contains duplicate keys.";
				
				throw new ArgumentException(arg_62_0);
			}
		}
	}
	
	
	public virtual bool contains(int i)
	{
		return this.rank(i) != -1;
	}
}






public class StdArrayIO
{
	
	
	public static double[] readDouble1D()
	{
		int num = StdIn.readInt();
		double[] array = new double[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = StdIn.readDouble();
		}
		return array;
	}
	
	
	public static void print(double[] darr)
	{
		int num = darr.Length;
		StdOut.println(num);
		for (int i = 0; i < num; i++)
		{
			StdOut.printf("%9.5f ", new object[]
			{
				java.lang.Double.valueOf(darr[i])
			});
		}
		StdOut.println();
	}
	
	
	public static double[][] readDouble2D()
	{
		int num = StdIn.readInt();
		int num2 = StdIn.readInt();
		int arg_1A_0 = num;
		int arg_15_0 = num2;
		int[] array = new int[2];
		int num3 = arg_15_0;
		array[1] = num3;
		num3 = arg_1A_0;
		array[0] = num3;
		double[][] array2 = (double[][])ByteCodeHelper.multianewarray(typeof(double[][]).TypeHandle, array);
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				array2[i][j] = StdIn.readDouble();
			}
		}
		return array2;
	}
	
	
	public static void print(double[][] darr)
	{
		int num = darr.Length;
		int num2 = darr[0].Length;
		StdOut.println(new StringBuilder().append(num).append(" ").append(num2).toString());
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				StdOut.printf("%9.5f ", new object[]
				{
					java.lang.Double.valueOf(darr[i][j])
				});
			}
			StdOut.println();
		}
	}
	
	
	public static bool[][] readBoolean2D()
	{
		int num = StdIn.readInt();
		int num2 = StdIn.readInt();
		int arg_1A_0 = num;
		int arg_15_0 = num2;
		int[] array = new int[2];
		int num3 = arg_15_0;
		array[1] = num3;
		num3 = arg_1A_0;
		array[0] = num3;
		bool[][] array2 = (bool[][])ByteCodeHelper.multianewarray(typeof(bool[][]).TypeHandle, array);
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				array2[i][j] = StdIn.readBoolean();
			}
		}
		return array2;
	}
	
	
	public static void print(bool[][] barr)
	{
		int num = barr.Length;
		int num2 = barr[0].Length;
		StdOut.println(new StringBuilder().append(num).append(" ").append(num2).toString());
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				if (barr[i][j])
				{
					StdOut.print("1 ");
				}
				else
				{
					StdOut.print("0 ");
				}
			}
			StdOut.println();
		}
	}
	
	
	private StdArrayIO()
	{
	}
	
	
	public static int[] readInt1D()
	{
		int num = StdIn.readInt();
		int[] array = new int[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = StdIn.readInt();
		}
		return array;
	}
	
	
	public static void print(int[] iarr)
	{
		int num = iarr.Length;
		StdOut.println(num);
		for (int i = 0; i < num; i++)
		{
			StdOut.printf("%9d ", new object[]
			{
				Integer.valueOf(iarr[i])
			});
		}
		StdOut.println();
	}
	
	
	public static int[][] readInt2D()
	{
		int num = StdIn.readInt();
		int num2 = StdIn.readInt();
		int arg_1A_0 = num;
		int arg_15_0 = num2;
		int[] array = new int[2];
		int num3 = arg_15_0;
		array[1] = num3;
		num3 = arg_1A_0;
		array[0] = num3;
		int[][] array2 = (int[][])ByteCodeHelper.multianewarray(typeof(int[][]).TypeHandle, array);
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				array2[i][j] = StdIn.readInt();
			}
		}
		return array2;
	}
	
	
	public static void print(int[][] iarr)
	{
		int num = iarr.Length;
		int num2 = iarr[0].Length;
		StdOut.println(new StringBuilder().append(num).append(" ").append(num2).toString());
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				StdOut.printf("%9d ", new object[]
				{
					Integer.valueOf(iarr[i][j])
				});
			}
			StdOut.println();
		}
	}
	
	
	public static bool[] readBoolean1D()
	{
		int num = StdIn.readInt();
		bool[] array = new bool[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = StdIn.readBoolean();
		}
		return array;
	}
	
	
	public static void print(bool[] barr)
	{
		int num = barr.Length;
		StdOut.println(num);
		for (int i = 0; i < num; i++)
		{
			if (barr[i])
			{
				StdOut.print("1 ");
			}
			else
			{
				StdOut.print("0 ");
			}
		}
		StdOut.println();
	}
	
	
	/**/public static void main(string[] strarr)
	{
		double[] darr = StdArrayIO.readDouble1D();
		StdArrayIO.print(darr);
		StdOut.println();
		double[][] darr2 = StdArrayIO.readDouble2D();
		StdArrayIO.print(darr2);
		StdOut.println();
		bool[][] barr = StdArrayIO.readBoolean2D();
		StdArrayIO.print(barr);
		StdOut.println();
	}
}




using java.applet;



using javax.sound.sampled;


public sealed class StdAudio
{
	public const int SAMPLE_RATE = 44100;
	private const int BYTES_PER_SAMPLE = 2;
	private const int BITS_PER_SAMPLE = 16;
	private const double MAX_16_BIT = 32767.0;
	private const int SAMPLE_BUFFER_SIZE = 4096;
	private static SourceDataLine line;
	private static byte[] buffer;
	private static int bufferSize;
	
	
	
	
	public static void play(double d)
	{
		if (d < -1.0)
		{
			d = -1.0;
		}
		if (d > (double)1f)
		{
			d = (double)1f;
		}
		int num = (int)((short)ByteCodeHelper.d2i(32767.0 * d));
		StdAudio.buffer[StdAudio.bufferSize++] = (byte)((sbyte)num);
		StdAudio.buffer[StdAudio.bufferSize++] = (byte)((sbyte)(num >> 8));
		if (StdAudio.bufferSize >= StdAudio.buffer.Length)
		{
			StdAudio.line.write(StdAudio.buffer, 0, StdAudio.buffer.Length);
			StdAudio.bufferSize = 0;
		}
	}
	
	
	private static byte[] readByte(string text)
	{
		byte[] array;
		java.lang.Exception ex;
		try
		{
			File file = new File(text);
			if (file.exists())
			{
				AudioInputStream audioInputStream = AudioSystem.getAudioInputStream(file);
				array = new byte[audioInputStream.available()];
				audioInputStream.read(array);
			}
			else
			{
				URL resource = ClassLiteral<StdAudio>.Value.getResource(text);
				AudioInputStream audioInputStream = AudioSystem.getAudioInputStream(resource);
				array = new byte[audioInputStream.available()];
				audioInputStream.read(array);
			}
		}
		catch (System.Exception arg_5C_0)
		{
			java.lang.Exception expr_61 = ByteCodeHelper.MapException<java.lang.Exception>(arg_5C_0, ByteCodeHelper.MapFlags.None);
			if (expr_61 == null)
			{
				throw;
			}
			ex = expr_61;
			goto IL_6C;
		}
		return array;
		IL_6C:
		java.lang.Exception @this = ex;
		System.@out.println(Throwable.instancehelper_getMessage(@this));
		string arg_A4_0 = new StringBuilder().append("Could not read ").append(text).toString();
		
		throw new RuntimeException(arg_A4_0);
	}
	
	
	private static double[] note(double num, double num2, double num3)
	{
		int num4 = ByteCodeHelper.d2i(44100.0 * num2);
		double[] array = new double[num4 + 1];
		for (int i = 0; i <= num4; i++)
		{
			array[i] = num3 * java.lang.Math.sin(6.2831853071795862 * (double)i * num / 44100.0);
		}
		return array;
	}
	
	
	public static void play(double[] darr)
	{
		for (int i = 0; i < darr.Length; i++)
		{
			StdAudio.play(darr[i]);
		}
	}
	
	
	public static void close()
	{
		StdAudio.line.drain();
		StdAudio.line.stop();
	}
	
	
	private static void init()
	{
		java.lang.Exception ex;
		try
		{
			AudioFormat audioFormat = new AudioFormat(44100f, 16, 1, true, false);
			DataLine.Info info = new DataLine.Info(ClassLiteral<SourceDataLine>.Value, audioFormat);
			StdAudio.line = (SourceDataLine)AudioSystem.getLine(info);
			StdAudio.line.open(audioFormat, 8192);
			StdAudio.buffer = new byte[2730];
		}
		catch (System.Exception arg_50_0)
		{
			java.lang.Exception expr_55 = ByteCodeHelper.MapException<java.lang.Exception>(arg_50_0, ByteCodeHelper.MapFlags.None);
			if (expr_55 == null)
			{
				throw;
			}
			ex = expr_55;
			goto IL_5F;
		}
		goto IL_7B;
		IL_5F:
		java.lang.Exception @this = ex;
		System.@out.println(Throwable.instancehelper_getMessage(@this));
		System.exit(1);
		IL_7B:
		StdAudio.line.start();
	}
	
	
	private StdAudio()
	{
	}
	
	
	public static double[] read(string str)
	{
		byte[] array = StdAudio.readByte(str);
		int num = array.Length;
		double[] array2 = new double[num / 2];
		for (int i = 0; i < num / 2; i++)
		{
			array2[i] = (double)((short)(((int)array[2 * i + 1] << 8) + (int)array[2 * i])) / 32767.0;
		}
		return array2;
	}
	
	
	public static void play(string str)
	{
		URL uRL = null;
		MalformedURLException ex;
		try
		{
			File file = new File(str);
			if (file.canRead())
			{
				uRL = file.toURI().toURL();
			}
		}
		catch (MalformedURLException arg_22_0)
		{
			ex = ByteCodeHelper.MapException<MalformedURLException>(arg_22_0, ByteCodeHelper.MapFlags.NoRemapping);
			goto IL_2C;
		}
		goto IL_38;
		IL_2C:
		MalformedURLException @this = ex;
		Throwable.instancehelper_printStackTrace(@this);
		IL_38:
		if (uRL == null)
		{
			string arg_64_0 = new StringBuilder().append("audio ").append(str).append(" not found").toString();
			
			throw new RuntimeException(arg_64_0);
		}
		AudioClip audioClip = Applet.newAudioClip(uRL);
		audioClip.play();
	}
	
	
	public static void loop(string str)
	{
		URL uRL = null;
		MalformedURLException ex;
		try
		{
			File file = new File(str);
			if (file.canRead())
			{
				uRL = file.toURI().toURL();
			}
		}
		catch (MalformedURLException arg_22_0)
		{
			ex = ByteCodeHelper.MapException<MalformedURLException>(arg_22_0, ByteCodeHelper.MapFlags.NoRemapping);
			goto IL_2C;
		}
		goto IL_38;
		IL_2C:
		MalformedURLException @this = ex;
		Throwable.instancehelper_printStackTrace(@this);
		IL_38:
		if (uRL == null)
		{
			string arg_64_0 = new StringBuilder().append("audio ").append(str).append(" not found").toString();
			
			throw new RuntimeException(arg_64_0);
		}
		AudioClip audioClip = Applet.newAudioClip(uRL);
		audioClip.loop();
	}
	
	
	public static void save(string str, double[] darr)
	{
		AudioFormat format = new AudioFormat(44100f, 16, 1, true, false);
		byte[] array = new byte[2 * darr.Length];
		for (int i = 0; i < darr.Length; i++)
		{
			int num = (int)((short)ByteCodeHelper.d2i(darr[i] * 32767.0));
			array[2 * i + 0] = (byte)((sbyte)num);
			array[2 * i + 1] = (byte)((sbyte)(num >> 8));
		}
		java.lang.Exception ex;
		try
		{
			ByteArrayInputStream stream = new ByteArrayInputStream(array);
			AudioInputStream stream2 = new AudioInputStream(stream, format, (long)darr.Length);
			if (java.lang.String.instancehelper_endsWith(str, ".wav") || java.lang.String.instancehelper_endsWith(str, ".WAV"))
			{
				AudioSystem.write(stream2, AudioFileFormat.Type.WAVE, new File(str));
			}
			else
			{
				if (!java.lang.String.instancehelper_endsWith(str, ".au") && !java.lang.String.instancehelper_endsWith(str, ".AU"))
				{
					string arg_E1_0 = new StringBuilder().append("File format not supported: ").append(str).toString();
					
					throw new RuntimeException(arg_E1_0);
				}
				AudioSystem.write(stream2, AudioFileFormat.Type.AU, new File(str));
			}
		}
		catch (System.Exception arg_EA_0)
		{
			java.lang.Exception expr_EF = ByteCodeHelper.MapException<java.lang.Exception>(arg_EA_0, ByteCodeHelper.MapFlags.None);
			if (expr_EF == null)
			{
				throw;
			}
			ex = expr_EF;
			goto IL_FA;
		}
		return;
		IL_FA:
		java.lang.Exception x = ex;
		System.@out.println(x);
		System.exit(1);
	}
	
	
	/**/public static void main(string[] strarr)
	{
		double num = 440.0;
		for (int i = 0; i <= 44100; i++)
		{
			StdAudio.play(0.5 * java.lang.Math.sin(6.2831853071795862 * num * (double)i / 44100.0));
		}
		int[] array = new int[]
		{
			0,
			2,
			4,
			5,
			7,
			9,
			11,
			12
		};
		for (int j = 0; j < array.Length; j++)
		{
			double num2 = 440.0 * java.lang.Math.pow(2.0, (double)array[j] / 12.0);
			StdAudio.play(StdAudio.note(num2, (double)1f, 0.5));
		}
		StdAudio.close();
		System.exit(0);
	}
	
	static StdAudio()
	{
		StdAudio.bufferSize = 0;
		StdAudio.init();
	}
}





using java.awt.@event;
using java.awt.geom;
using java.awt.image;




using javax.imageio;
using javax.swing;


/*[Implements(new string[]
{
	"java.awt.event.ActionListener",
	"java.awt.event.MouseListener",
	"java.awt.event.MouseMotionListener",
	"java.awt.event.KeyListener"
})]*/
public sealed class StdDraw, ActionListener, EventListener, MouseListener, MouseMotionListener, KeyListener
{
	internal static Color __BLACK;
	internal static Color __BLUE;
	internal static Color __CYAN;
	internal static Color __DARK_GRAY;
	internal static Color __GRAY;
	internal static Color __GREEN;
	internal static Color __LIGHT_GRAY;
	internal static Color __MAGENTA;
	internal static Color __ORANGE;
	internal static Color __PINK;
	internal static Color __RED;
	internal static Color __WHITE;
	internal static Color __YELLOW;
	internal static Color __BOOK_BLUE;
	internal static Color __BOOK_LIGHT_BLUE;
	internal static Color __BOOK_RED;
//[Modifiers(Modifiers.Private | Modifiers.Static | Modifiers.Final)]
	private static Color DEFAULT_PEN_COLOR;
//[Modifiers(Modifiers.Private | Modifiers.Static | Modifiers.Final)]
	private static Color DEFAULT_CLEAR_COLOR;
	private static Color penColor;
	private const int DEFAULT_SIZE = 512;
	private static int width;
	private static int height;
	private const double DEFAULT_PEN_RADIUS = 0.002;
	private static double penRadius;
	private static bool defer;
	private const double BORDER = 0.05;
	private const double DEFAULT_XMIN = 0.0;
	private const double DEFAULT_XMAX = 1.0;
	private const double DEFAULT_YMIN = 0.0;
	private const double DEFAULT_YMAX = 1.0;
	private static double xmin;
	private static double ymin;
	private static double xmax;
	private static double ymax;
	private static object mouseLock;
	private static object keyLock;
//[Modifiers(Modifiers.Private | Modifiers.Static | Modifiers.Final)]
	private static Font DEFAULT_FONT;
	private static Font font;
	private static BufferedImage offscreenImage;
	private static BufferedImage onscreenImage;
	private static Graphics2D offscreen;
	private static Graphics2D onscreen;
	private static StdDraw std;
	private static JFrame frame;
	private static bool mousePressed;
	private static double mouseX;
	private static double mouseY;
//[Signature("Ljava/util/LinkedList<Ljava/lang/Character;>;")]
	private static LinkedList keysTyped;
//[Signature("Ljava/util/TreeSet<Ljava/lang/Integer;>;")]
	private static TreeSet keysDown;
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color BLACK
	{
		
		get
		{
			return StdDraw.__BLACK;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color BLUE
	{
		
		get
		{
			return StdDraw.__BLUE;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color CYAN
	{
		
		get
		{
			return StdDraw.__CYAN;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color DARK_GRAY
	{
		
		get
		{
			return StdDraw.__DARK_GRAY;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color GRAY
	{
		
		get
		{
			return StdDraw.__GRAY;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color GREEN
	{
		
		get
		{
			return StdDraw.__GREEN;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color LIGHT_GRAY
	{
		
		get
		{
			return StdDraw.__LIGHT_GRAY;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color MAGENTA
	{
		
		get
		{
			return StdDraw.__MAGENTA;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color ORANGE
	{
		
		get
		{
			return StdDraw.__ORANGE;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color PINK
	{
		
		get
		{
			return StdDraw.__PINK;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color RED
	{
		
		get
		{
			return StdDraw.__RED;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color WHITE
	{
		
		get
		{
			return StdDraw.__WHITE;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color YELLOW
	{
		
		get
		{
			return StdDraw.__YELLOW;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color BOOK_BLUE
	{
		
		get
		{
			return StdDraw.__BOOK_BLUE;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color BOOK_LIGHT_BLUE
	{
		
		get
		{
			return StdDraw.__BOOK_LIGHT_BLUE;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color BOOK_RED
	{
		
		get
		{
			return StdDraw.__BOOK_RED;
		}
	}
	
	
	
	
	public static void clear()
	{
		StdDraw.clear(StdDraw.DEFAULT_CLEAR_COLOR);
	}
	
	
	public static void show(int i)
	{
		StdDraw.defer = false;
		StdDraw.draw();
		try
		{
			Thread.sleep((long)i);
		}
		catch (InterruptedException arg_16_0)
		{
			goto IL_1A;
		}
		goto IL_2F;
		IL_1A:
		System.@out.println("Error sleeping");
		IL_2F:
		StdDraw.defer = true;
	}
	
	public static void setXscale(double d1, double d2)
	{
		double num = d2 - d1;
		lock (StdDraw.mouseLock)
		{
			StdDraw.xmin = d1 - 0.05 * num;
			StdDraw.xmax = d2 + 0.05 * num;
		}
	}
	
	public static void setYscale(double d1, double d2)
	{
		double num = d2 - d1;
		lock (StdDraw.mouseLock)
		{
			StdDraw.ymin = d1 - 0.05 * num;
			StdDraw.ymax = d2 + 0.05 * num;
		}
	}
	
	
	public static void rectangle(double d1, double d2, double d3, double d4)
	{
		if (d3 < (double)0f)
		{
			string arg_13_0 = "half width must be nonnegative";
			
			throw new ArgumentException(arg_13_0);
		}
		if (d4 < (double)0f)
		{
			string arg_2C_0 = "half height must be nonnegative";
			
			throw new ArgumentException(arg_2C_0);
		}
		double num = StdDraw.scaleX(d1);
		double num2 = StdDraw.scaleY(d2);
		double num3 = StdDraw.factorX(2.0 * d3);
		double num4 = StdDraw.factorY(2.0 * d4);
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			StdDraw.pixel(d1, d2);
		}
		else
		{
			StdDraw.offscreen.draw(new Rectangle2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
		}
		StdDraw.draw();
	}
	
	
	public static void setPenColor(Color c)
	{
		StdDraw.penColor = c;
		StdDraw.offscreen.setColor(StdDraw.penColor);
	}
	
	
	public static void filledCircle(double d1, double d2, double d3)
	{
		if (d3 < (double)0f)
		{
			string arg_13_0 = "circle radius must be nonnegative";
			
			throw new ArgumentException(arg_13_0);
		}
		double num = StdDraw.scaleX(d1);
		double num2 = StdDraw.scaleY(d2);
		double num3 = StdDraw.factorX(2.0 * d3);
		double num4 = StdDraw.factorY(2.0 * d3);
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			StdDraw.pixel(d1, d2);
		}
		else
		{
			StdDraw.offscreen.fill(new Ellipse2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
		}
		StdDraw.draw();
	}
	
	
	public static void point(double d1, double d2)
	{
		double num = StdDraw.scaleX(d1);
		double num2 = StdDraw.scaleY(d2);
		double num3 = StdDraw.penRadius;
		float num4 = (float)(num3 * 512.0);
		if (num4 <= 1f)
		{
			StdDraw.pixel(d1, d2);
		}
		else
		{
			StdDraw.offscreen.fill(new Ellipse2D.Double(num - (double)(num4 / 2f), num2 - (double)(num4 / 2f), (double)num4, (double)num4));
		}
		StdDraw.draw();
	}
	
	
	public static void line(double d1, double d2, double d3, double d4)
	{
		StdDraw.offscreen.draw(new Line2D.Double(StdDraw.scaleX(d1), StdDraw.scaleY(d2), StdDraw.scaleX(d3), StdDraw.scaleY(d4)));
		StdDraw.draw();
	}
	
	
	public static void setCanvasSize(int i1, int i2)
	{
		if (i1 < 1 || i2 < 1)
		{
			string arg_12_0 = "width and height must be positive";
			
			throw new ArgumentException(arg_12_0);
		}
		StdDraw.width = i1;
		StdDraw.height = i2;
		StdDraw.init();
	}
	
	
	public static void setPenRadius(double d)
	{
		if (d < (double)0f)
		{
			string arg_13_0 = "pen radius must be nonnegative";
			
			throw new ArgumentException(arg_13_0);
		}
		StdDraw.penRadius = d;
		float num = (float)(d * 512.0);
		BasicStroke stroke = new BasicStroke(num, 1, 1);
		StdDraw.offscreen.setStroke(stroke);
	}
	
	
	public static void setPenRadius()
	{
		StdDraw.setPenRadius(0.002);
	}
	
	
	private static void init()
	{
		if (StdDraw.frame != null)
		{
			StdDraw.frame.setVisible(false);
		}
		StdDraw.frame = new JFrame();
		BufferedImage.__<clinit>();
		StdDraw.offscreenImage = new BufferedImage(StdDraw.width, StdDraw.height, 2);
		BufferedImage.__<clinit>();
		StdDraw.onscreenImage = new BufferedImage(StdDraw.width, StdDraw.height, 2);
		StdDraw.offscreen = StdDraw.offscreenImage.createGraphics();
		StdDraw.onscreen = StdDraw.onscreenImage.createGraphics();
		StdDraw.setXscale();
		StdDraw.setYscale();
		StdDraw.offscreen.setColor(StdDraw.DEFAULT_CLEAR_COLOR);
		StdDraw.offscreen.fillRect(0, 0, StdDraw.width, StdDraw.height);
		StdDraw.setPenColor();
		StdDraw.setPenRadius();
		StdDraw.setFont();
		StdDraw.clear();
		RenderingHints.__<clinit>();
		RenderingHints renderingHints = new RenderingHints(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
		renderingHints.put(RenderingHints.KEY_RENDERING, RenderingHints.VALUE_RENDER_QUALITY);
		StdDraw.offscreen.addRenderingHints(renderingHints);
		ImageIcon.__<clinit>();
		ImageIcon image = new ImageIcon(StdDraw.onscreenImage);
		JLabel jLabel = new JLabel(image);
		jLabel.addMouseListener(StdDraw.std);
		jLabel.addMouseMotionListener(StdDraw.std);
		StdDraw.frame.setContentPane(jLabel);
		StdDraw.frame.addKeyListener(StdDraw.std);
		StdDraw.frame.setResizable(false);
		StdDraw.frame.setDefaultCloseOperation(3);
		StdDraw.frame.setTitle("Standard Draw");
		StdDraw.frame.setJMenuBar(StdDraw.createMenuBar());
		StdDraw.frame.pack();
		StdDraw.frame.requestFocusInWindow();
		StdDraw.frame.setVisible(true);
	}
	
	
	public static void setXscale()
	{
		StdDraw.setXscale((double)0f, (double)1f);
	}
	
	
	public static void setYscale()
	{
		StdDraw.setYscale((double)0f, (double)1f);
	}
	
	
	public static void setPenColor()
	{
		StdDraw.setPenColor(StdDraw.DEFAULT_PEN_COLOR);
	}
	
	
	public static void setFont()
	{
		StdDraw.setFont(StdDraw.DEFAULT_FONT);
	}
	
	
	private static JMenuBar createMenuBar()
	{
		JMenuBar jMenuBar = new JMenuBar();
		JMenu jMenu = new JMenu("File");
		jMenuBar.add(jMenu);
		JMenuItem jMenuItem = new JMenuItem(" Save...   ");
		jMenuItem.addActionListener(StdDraw.std);
		jMenuItem.setAccelerator(KeyStroke.getKeyStroke(83, Toolkit.getDefaultToolkit().getMenuShortcutKeyMask()));
		jMenu.add(jMenuItem);
		return jMenuBar;
	}
	
	
	public static void clear(Color c)
	{
		StdDraw.offscreen.setColor(c);
		StdDraw.offscreen.fillRect(0, 0, StdDraw.width, StdDraw.height);
		StdDraw.offscreen.setColor(StdDraw.penColor);
		StdDraw.draw();
	}
	
	
	private static void draw()
	{
		if (StdDraw.defer)
		{
			return;
		}
		StdDraw.onscreen.drawImage(StdDraw.offscreenImage, 0, 0, null);
		StdDraw.frame.repaint();
	}
	public static void setFont(Font f)
	{
		StdDraw.font = f;
	}
	private static double scaleX(double num)
	{
		return (double)StdDraw.width * (num - StdDraw.xmin) / (StdDraw.xmax - StdDraw.xmin);
	}
	private static double scaleY(double num)
	{
		return (double)StdDraw.height * (StdDraw.ymax - num) / (StdDraw.ymax - StdDraw.ymin);
	}
	
	
	private static void pixel(double num, double num2)
	{
		StdDraw.offscreen.fillRect((int)java.lang.Math.round(StdDraw.scaleX(num)), (int)java.lang.Math.round(StdDraw.scaleY(num2)), 1, 1);
	}
	
	
	private static double factorX(double num)
	{
		return num * (double)StdDraw.width / java.lang.Math.abs(StdDraw.xmax - StdDraw.xmin);
	}
	
	
	private static double factorY(double num)
	{
		return num * (double)StdDraw.height / java.lang.Math.abs(StdDraw.ymax - StdDraw.ymin);
	}
	
	
	private static Image getImage(string text)
	{
		ImageIcon imageIcon = new ImageIcon(text);
		if (imageIcon != null)
		{
			if (imageIcon.getImageLoadStatus() == 8)
			{
				goto IL_39;
			}
		}
		try
		{
			URL uRL = new URL(text);
			imageIcon = new ImageIcon(uRL);
		}
		catch (System.Exception arg_26_0)
		{
			if (ByteCodeHelper.MapException<java.lang.Exception>(arg_26_0, ByteCodeHelper.MapFlags.Unused) == null)
			{
				throw;
			}
		}
		IL_39:
		if (imageIcon == null || imageIcon.getImageLoadStatus() != 8)
		{
			URL uRL = ClassLiteral<StdDraw>.Value.getResource(text);
			if (uRL == null)
			{
				string arg_7D_0 = new StringBuilder().append("image ").append(text).append(" not found").toString();
				
				throw new ArgumentException(arg_7D_0);
			}
			imageIcon = new ImageIcon(uRL);
		}
		return imageIcon.getImage();
	}
	
	
	public static void text(double d1, double d2, string str)
	{
		StdDraw.offscreen.setFont(StdDraw.font);
		FontMetrics fontMetrics = StdDraw.offscreen.getFontMetrics();
		double num = StdDraw.scaleX(d1);
		double num2 = StdDraw.scaleY(d2);
		int num3 = fontMetrics.stringWidth(str);
		int descent = fontMetrics.getDescent();
		StdDraw.offscreen.drawString(str, (float)(num - (double)num3 / 2.0), (float)(num2 + (double)descent));
		StdDraw.draw();
	}
	
	
	public static void save(string str)
	{
		File output = new File(str);
		string text = java.lang.String.instancehelper_substring(str, java.lang.String.instancehelper_lastIndexOf(str, 46) + 1);
		if (java.lang.String.instancehelper_equals(java.lang.String.instancehelper_toLowerCase(text), "png"))
		{
			IOException ex;
			try
			{
				ImageIO.write(StdDraw.onscreenImage, text, output);
			}
			catch (IOException arg_3C_0)
			{
				ex = ByteCodeHelper.MapException<IOException>(arg_3C_0, ByteCodeHelper.MapFlags.NoRemapping);
				goto IL_46;
			}
			return;
			IL_46:
			IOException @this = ex;
			Throwable.instancehelper_printStackTrace(@this);
		}
		else if (java.lang.String.instancehelper_equals(java.lang.String.instancehelper_toLowerCase(text), "jpg"))
		{
			WritableRaster raster = StdDraw.onscreenImage.getRaster();
			WritableRaster raster2 = raster.createWritableChild(0, 0, StdDraw.width, StdDraw.height, 0, 0, new int[]
			{
				0,
				1,
				2
			});
			DirectColorModel directColorModel = (DirectColorModel)StdDraw.onscreenImage.getColorModel();
			DirectColorModel.__<clinit>();
			DirectColorModel cm = new DirectColorModel(directColorModel.getPixelSize(), directColorModel.getRedMask(), directColorModel.getGreenMask(), directColorModel.getBlueMask());
			BufferedImage im = new BufferedImage(cm, raster2, false, null);
			IOException ex2;
			try
			{
				ImageIO.write(im, text, output);
			}
			catch (IOException arg_F9_0)
			{
				ex2 = ByteCodeHelper.MapException<IOException>(arg_F9_0, ByteCodeHelper.MapFlags.NoRemapping);
				goto IL_104;
			}
			goto IL_113;
			IL_104:
			IOException this2 = ex2;
			Throwable.instancehelper_printStackTrace(this2);
			IL_113:;
		}
		else
		{
			System.@out.println(new StringBuilder().append("Invalid image file type: ").append(text).toString());
		}
	}
	private static double userX(double num)
	{
		return StdDraw.xmin + num * (StdDraw.xmax - StdDraw.xmin) / (double)StdDraw.width;
	}
	private static double userY(double num)
	{
		return StdDraw.ymax - num * (StdDraw.ymax - StdDraw.ymin) / (double)StdDraw.height;
	}
	
	
	public static void square(double d1, double d2, double d3)
	{
		if (d3 < (double)0f)
		{
			string arg_13_0 = "square side length must be nonnegative";
			
			throw new ArgumentException(arg_13_0);
		}
		double num = StdDraw.scaleX(d1);
		double num2 = StdDraw.scaleY(d2);
		double num3 = StdDraw.factorX(2.0 * d3);
		double num4 = StdDraw.factorY(2.0 * d3);
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			StdDraw.pixel(d1, d2);
		}
		else
		{
			StdDraw.offscreen.draw(new Rectangle2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
		}
		StdDraw.draw();
	}
	
	
	public static void filledSquare(double d1, double d2, double d3)
	{
		if (d3 < (double)0f)
		{
			string arg_13_0 = "square side length must be nonnegative";
			
			throw new ArgumentException(arg_13_0);
		}
		double num = StdDraw.scaleX(d1);
		double num2 = StdDraw.scaleY(d2);
		double num3 = StdDraw.factorX(2.0 * d3);
		double num4 = StdDraw.factorY(2.0 * d3);
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			StdDraw.pixel(d1, d2);
		}
		else
		{
			StdDraw.offscreen.fill(new Rectangle2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
		}
		StdDraw.draw();
	}
	
	
	public static void circle(double d1, double d2, double d3)
	{
		if (d3 < (double)0f)
		{
			string arg_13_0 = "circle radius must be nonnegative";
			
			throw new ArgumentException(arg_13_0);
		}
		double num = StdDraw.scaleX(d1);
		double num2 = StdDraw.scaleY(d2);
		double num3 = StdDraw.factorX(2.0 * d3);
		double num4 = StdDraw.factorY(2.0 * d3);
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			StdDraw.pixel(d1, d2);
		}
		else
		{
			StdDraw.offscreen.draw(new Ellipse2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
		}
		StdDraw.draw();
	}
	
	
	public static void arc(double d1, double d2, double d3, double d4, double d5)
	{
		if (d3 < (double)0f)
		{
			string arg_13_0 = "arc radius must be nonnegative";
			
			throw new ArgumentException(arg_13_0);
		}
		while (d5 < d4)
		{
			d5 += 360.0;
		}
		double num = StdDraw.scaleX(d1);
		double num2 = StdDraw.scaleY(d2);
		double num3 = StdDraw.factorX(2.0 * d3);
		double num4 = StdDraw.factorY(2.0 * d3);
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			StdDraw.pixel(d1, d2);
		}
		else
		{
			StdDraw.offscreen.draw(new Arc2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4, d4, d5 - d4, 0));
		}
		StdDraw.draw();
	}
	
	
	public static void filledPolygon(double[] darr1, double[] darr2)
	{
		int num = darr1.Length;
		GeneralPath generalPath = new GeneralPath();
		generalPath.moveTo((float)StdDraw.scaleX(darr1[0]), (float)StdDraw.scaleY(darr2[0]));
		for (int i = 0; i < num; i++)
		{
			generalPath.lineTo((float)StdDraw.scaleX(darr1[i]), (float)StdDraw.scaleY(darr2[i]));
		}
		generalPath.closePath();
		StdDraw.offscreen.fill(generalPath);
		StdDraw.draw();
	}
	
	
	private StdDraw()
	{
	}
	
	
	public static void setCanvasSize()
	{
		StdDraw.setCanvasSize(512, 512);
	}
	
	public static void setScale(double d1, double d2)
	{
		double num = d2 - d1;
		lock (StdDraw.mouseLock)
		{
			StdDraw.xmin = d1 - 0.05 * num;
			StdDraw.xmax = d2 + 0.05 * num;
			StdDraw.ymin = d1 - 0.05 * num;
			StdDraw.ymax = d2 + 0.05 * num;
		}
	}
	public static double getPenRadius()
	{
		return StdDraw.penRadius;
	}
	public static Color getPenColor()
	{
		return StdDraw.penColor;
	}
	
	
	public static void setPenColor(int i1, int i2, int i3)
	{
		if (i1 < 0 || i1 >= 256)
		{
			string arg_16_0 = "amount of red must be between 0 and 255";
			
			throw new ArgumentException(arg_16_0);
		}
		if (i2 < 0 || i2 >= 256)
		{
			string arg_32_0 = "amount of red must be between 0 and 255";
			
			throw new ArgumentException(arg_32_0);
		}
		if (i3 < 0 || i3 >= 256)
		{
			string arg_4E_0 = "amount of red must be between 0 and 255";
			
			throw new ArgumentException(arg_4E_0);
		}
		StdDraw.setPenColor(new Color(i1, i2, i3));
	}
	public static Font getFont()
	{
		return StdDraw.font;
	}
	
	
	public static void ellipse(double d1, double d2, double d3, double d4)
	{
		if (d3 < (double)0f)
		{
			string arg_13_0 = "ellipse semimajor axis must be nonnegative";
			
			throw new ArgumentException(arg_13_0);
		}
		if (d4 < (double)0f)
		{
			string arg_2C_0 = "ellipse semiminor axis must be nonnegative";
			
			throw new ArgumentException(arg_2C_0);
		}
		double num = StdDraw.scaleX(d1);
		double num2 = StdDraw.scaleY(d2);
		double num3 = StdDraw.factorX(2.0 * d3);
		double num4 = StdDraw.factorY(2.0 * d4);
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			StdDraw.pixel(d1, d2);
		}
		else
		{
			StdDraw.offscreen.draw(new Ellipse2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
		}
		StdDraw.draw();
	}
	
	
	public static void filledEllipse(double d1, double d2, double d3, double d4)
	{
		if (d3 < (double)0f)
		{
			string arg_13_0 = "ellipse semimajor axis must be nonnegative";
			
			throw new ArgumentException(arg_13_0);
		}
		if (d4 < (double)0f)
		{
			string arg_2C_0 = "ellipse semiminor axis must be nonnegative";
			
			throw new ArgumentException(arg_2C_0);
		}
		double num = StdDraw.scaleX(d1);
		double num2 = StdDraw.scaleY(d2);
		double num3 = StdDraw.factorX(2.0 * d3);
		double num4 = StdDraw.factorY(2.0 * d4);
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			StdDraw.pixel(d1, d2);
		}
		else
		{
			StdDraw.offscreen.fill(new Ellipse2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
		}
		StdDraw.draw();
	}
	
	
	public static void filledRectangle(double d1, double d2, double d3, double d4)
	{
		if (d3 < (double)0f)
		{
			string arg_13_0 = "half width must be nonnegative";
			
			throw new ArgumentException(arg_13_0);
		}
		if (d4 < (double)0f)
		{
			string arg_2C_0 = "half height must be nonnegative";
			
			throw new ArgumentException(arg_2C_0);
		}
		double num = StdDraw.scaleX(d1);
		double num2 = StdDraw.scaleY(d2);
		double num3 = StdDraw.factorX(2.0 * d3);
		double num4 = StdDraw.factorY(2.0 * d4);
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			StdDraw.pixel(d1, d2);
		}
		else
		{
			StdDraw.offscreen.fill(new Rectangle2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
		}
		StdDraw.draw();
	}
	
	
	public static void polygon(double[] darr1, double[] darr2)
	{
		int num = darr1.Length;
		GeneralPath generalPath = new GeneralPath();
		generalPath.moveTo((float)StdDraw.scaleX(darr1[0]), (float)StdDraw.scaleY(darr2[0]));
		for (int i = 0; i < num; i++)
		{
			generalPath.lineTo((float)StdDraw.scaleX(darr1[i]), (float)StdDraw.scaleY(darr2[i]));
		}
		generalPath.closePath();
		StdDraw.offscreen.draw(generalPath);
		StdDraw.draw();
	}
	
	
	public static void picture(double d1, double d2, string str)
	{
		Image image = StdDraw.getImage(str);
		double num = StdDraw.scaleX(d1);
		double num2 = StdDraw.scaleY(d2);
		int num3 = image.getWidth(null);
		int num4 = image.getHeight(null);
		if (num3 < 0 || num4 < 0)
		{
			string arg_5C_0 = new StringBuilder().append("image ").append(str).append(" is corrupt").toString();
			
			throw new ArgumentException(arg_5C_0);
		}
		StdDraw.offscreen.drawImage(image, (int)java.lang.Math.round(num - (double)num3 / 2.0), (int)java.lang.Math.round(num2 - (double)num4 / 2.0), null);
		StdDraw.draw();
	}
	
	
	public static void picture(double d1, double d2, string str, double d3)
	{
		Image image = StdDraw.getImage(str);
		double num = StdDraw.scaleX(d1);
		double num2 = StdDraw.scaleY(d2);
		int num3 = image.getWidth(null);
		int num4 = image.getHeight(null);
		if (num3 < 0 || num4 < 0)
		{
			string arg_5C_0 = new StringBuilder().append("image ").append(str).append(" is corrupt").toString();
			
			throw new ArgumentException(arg_5C_0);
		}
		StdDraw.offscreen.rotate(java.lang.Math.toRadians(-d3), num, num2);
		StdDraw.offscreen.drawImage(image, (int)java.lang.Math.round(num - (double)num3 / 2.0), (int)java.lang.Math.round(num2 - (double)num4 / 2.0), null);
		StdDraw.offscreen.rotate(java.lang.Math.toRadians(d3), num, num2);
		StdDraw.draw();
	}
	
	
	public static void picture(double d1, double d2, string str, double d3, double d4)
	{
		Image image = StdDraw.getImage(str);
		double num = StdDraw.scaleX(d1);
		double num2 = StdDraw.scaleY(d2);
		if (d3 < (double)0f)
		{
			string arg_42_0 = new StringBuilder().append("width is negative: ").append(d3).toString();
			
			throw new ArgumentException(arg_42_0);
		}
		if (d4 < (double)0f)
		{
			string arg_73_0 = new StringBuilder().append("height is negative: ").append(d4).toString();
			
			throw new ArgumentException(arg_73_0);
		}
		double num3 = StdDraw.factorX(d3);
		double num4 = StdDraw.factorY(d4);
		if (num3 < (double)0f || num4 < (double)0f)
		{
			string arg_C7_0 = new StringBuilder().append("image ").append(str).append(" is corrupt").toString();
			
			throw new ArgumentException(arg_C7_0);
		}
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			StdDraw.pixel(d1, d2);
		}
		else
		{
			StdDraw.offscreen.drawImage(image, (int)java.lang.Math.round(num - num3 / 2.0), (int)java.lang.Math.round(num2 - num4 / 2.0), (int)java.lang.Math.round(num3), (int)java.lang.Math.round(num4), null);
		}
		StdDraw.draw();
	}
	
	
	public static void picture(double d1, double d2, string str, double d3, double d4, double d5)
	{
		Image image = StdDraw.getImage(str);
		double num = StdDraw.scaleX(d1);
		double num2 = StdDraw.scaleY(d2);
		double num3 = StdDraw.factorX(d3);
		double num4 = StdDraw.factorY(d4);
		if (num3 < (double)0f || num4 < (double)0f)
		{
			string arg_67_0 = new StringBuilder().append("image ").append(str).append(" is corrupt").toString();
			
			throw new ArgumentException(arg_67_0);
		}
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			StdDraw.pixel(d1, d2);
		}
		StdDraw.offscreen.rotate(java.lang.Math.toRadians(-d5), num, num2);
		StdDraw.offscreen.drawImage(image, (int)java.lang.Math.round(num - num3 / 2.0), (int)java.lang.Math.round(num2 - num4 / 2.0), (int)java.lang.Math.round(num3), (int)java.lang.Math.round(num4), null);
		StdDraw.offscreen.rotate(java.lang.Math.toRadians(d5), num, num2);
		StdDraw.draw();
	}
	
	
	public static void text(double d1, double d2, string str, double d3)
	{
		double d4 = StdDraw.scaleX(d1);
		double d5 = StdDraw.scaleY(d2);
		StdDraw.offscreen.rotate(java.lang.Math.toRadians(-d3), d4, d5);
		StdDraw.text(d1, d2, str);
		StdDraw.offscreen.rotate(java.lang.Math.toRadians(d3), d4, d5);
	}
	
	
	public static void textLeft(double d1, double d2, string str)
	{
		StdDraw.offscreen.setFont(StdDraw.font);
		FontMetrics fontMetrics = StdDraw.offscreen.getFontMetrics();
		double num = StdDraw.scaleX(d1);
		double num2 = StdDraw.scaleY(d2);
		int descent = fontMetrics.getDescent();
		StdDraw.offscreen.drawString(str, (float)num, (float)(num2 + (double)descent));
		StdDraw.draw();
	}
	
	
	public static void textRight(double d1, double d2, string str)
	{
		StdDraw.offscreen.setFont(StdDraw.font);
		FontMetrics fontMetrics = StdDraw.offscreen.getFontMetrics();
		double num = StdDraw.scaleX(d1);
		double num2 = StdDraw.scaleY(d2);
		int num3 = fontMetrics.stringWidth(str);
		int descent = fontMetrics.getDescent();
		StdDraw.offscreen.drawString(str, (float)(num - (double)num3), (float)(num2 + (double)descent));
		StdDraw.draw();
	}
	
	
	public static void show()
	{
		StdDraw.defer = false;
		StdDraw.draw();
	}
	
	
	public virtual void actionPerformed(ActionEvent ae)
	{
		FileDialog.__<clinit>();
		FileDialog fileDialog = new FileDialog(StdDraw.frame, "Use a .png or .jpg extension", 1);
		fileDialog.setVisible(true);
		string file = fileDialog.getFile();
		if (file != null)
		{
			StdDraw.save(new StringBuilder().append(fileDialog.getDirectory()).append(File.separator).append(fileDialog.getFile()).toString());
		}
	}
	
	public static bool mousePressed()
	{
		int result;
		lock (StdDraw.mouseLock)
		{
			result = (StdDraw.mousePressed ? 1 : 0);
		}
		return result != 0;
	}
	
	public static double mouseX()
	{
		double result;
		lock (StdDraw.mouseLock)
		{
			result = StdDraw.mouseX;
		}
		return result;
	}
	
	public static double mouseY()
	{
		double result;
		lock (StdDraw.mouseLock)
		{
			result = StdDraw.mouseY;
		}
		return result;
	}
	public virtual void mouseClicked(MouseEvent me)
	{
	}
	public virtual void mouseEntered(MouseEvent me)
	{
	}
	public virtual void mouseExited(MouseEvent me)
	{
	}
	
	
	public virtual void mousePressed(MouseEvent me)
	{
		lock (StdDraw.mouseLock)
		{
			StdDraw.mouseX = StdDraw.userX((double)me.getX());
			StdDraw.mouseY = StdDraw.userY((double)me.getY());
			StdDraw.mousePressed = true;
		}
	}
	
	public virtual void mouseReleased(MouseEvent me)
	{
		lock (StdDraw.mouseLock)
		{
			StdDraw.mousePressed = false;
		}
	}
	
	
	public virtual void mouseDragged(MouseEvent me)
	{
		lock (StdDraw.mouseLock)
		{
			StdDraw.mouseX = StdDraw.userX((double)me.getX());
			StdDraw.mouseY = StdDraw.userY((double)me.getY());
		}
	}
	
	
	public virtual void mouseMoved(MouseEvent me)
	{
		lock (StdDraw.mouseLock)
		{
			StdDraw.mouseX = StdDraw.userX((double)me.getX());
			StdDraw.mouseY = StdDraw.userY((double)me.getY());
		}
	}
	
	
	public static bool hasNextKeyTyped()
	{
		int result;
		lock (StdDraw.keyLock)
		{
			result = (StdDraw.keysTyped.IsEmpty ? 0 : 1);
		}
		return result != 0;
	}
	
	
	public static char nextKeyTyped()
	{
		int result;
		lock (StdDraw.keyLock)
		{
			result = (int)((Character)StdDraw.keysTyped.removeLast()).charValue();
		}
		return (char)result;
	}
	
	
	public static bool isKeyPressed(int i)
	{
		int result;
		lock (StdDraw.keyLock)
		{
			result = (StdDraw.keysDown.contains(Integer.valueOf(i)) ? 1 : 0);
		}
		return result != 0;
	}
	
	
	public virtual void keyTyped(KeyEvent ke)
	{
		lock (StdDraw.keyLock)
		{
			StdDraw.keysTyped.addFirst(Character.valueOf(ke.getKeyChar()));
		}
	}
	
	
	public virtual void keyPressed(KeyEvent ke)
	{
		lock (StdDraw.keyLock)
		{
			StdDraw.keysDown.add(Integer.valueOf(ke.getKeyCode()));
		}
	}
	
	
	public virtual void keyReleased(KeyEvent ke)
	{
		lock (StdDraw.keyLock)
		{
			StdDraw.keysDown.remove(Integer.valueOf(ke.getKeyCode()));
		}
	}
	
	
	/**/public static void main(string[] strarr)
	{
		StdDraw.square(0.2, 0.8, 0.1);
		StdDraw.filledSquare(0.8, 0.8, 0.2);
		StdDraw.circle(0.8, 0.2, 0.2);
		StdDraw.setPenColor(StdDraw.__BOOK_RED);
		StdDraw.setPenRadius(0.02);
		StdDraw.arc(0.8, 0.2, 0.1, 200.0, 45.0);
		StdDraw.setPenRadius();
		StdDraw.setPenColor(StdDraw.__BOOK_BLUE);
		double[] darr = new double[]
		{
			0.1,
			0.2,
			0.3,
			0.2
		};
		double[] darr2 = new double[]
		{
			0.2,
			0.3,
			0.2,
			0.1
		};
		StdDraw.filledPolygon(darr, darr2);
		StdDraw.setPenColor(StdDraw.__BLACK);
		StdDraw.text(0.2, 0.5, "black text");
		StdDraw.setPenColor(StdDraw.__WHITE);
		StdDraw.text(0.8, 0.8, "white text");
	}
	
	static StdDraw()
	{
		StdDraw.__BLACK = Color.BLACK;
		StdDraw.__BLUE = Color.BLUE;
		StdDraw.__CYAN = Color.CYAN;
		StdDraw.__DARK_GRAY = Color.DARK_GRAY;
		StdDraw.__GRAY = Color.GRAY;
		StdDraw.__GREEN = Color.GREEN;
		StdDraw.__LIGHT_GRAY = Color.LIGHT_GRAY;
		StdDraw.__MAGENTA = Color.MAGENTA;
		StdDraw.__ORANGE = Color.ORANGE;
		StdDraw.__PINK = Color.PINK;
		StdDraw.__RED = Color.RED;
		StdDraw.__WHITE = Color.WHITE;
		StdDraw.__YELLOW = Color.YELLOW;
		StdDraw.__BOOK_BLUE = new Color(9, 90, 166);
		StdDraw.__BOOK_LIGHT_BLUE = new Color(103, 198, 243);
		StdDraw.__BOOK_RED = new Color(150, 35, 31);
		StdDraw.DEFAULT_PEN_COLOR = StdDraw.__BLACK;
		StdDraw.DEFAULT_CLEAR_COLOR = StdDraw.__WHITE;
		StdDraw.width = 512;
		StdDraw.height = 512;
		StdDraw.defer = false;
		StdDraw.mouseLock = new java.lang.Object();
		StdDraw.keyLock = new java.lang.Object();
		StdDraw.DEFAULT_FONT = new Font("SansSerif", 0, 16);
		StdDraw.std = new StdDraw();
		StdDraw.mousePressed = false;
		StdDraw.mouseX = (double)0f;
		StdDraw.mouseY = (double)0f;
		StdDraw.keysTyped = new LinkedList();
		StdDraw.keysDown = new TreeSet();
		StdDraw.init();
	}
}





using java.awt.@event;
using java.awt.geom;
using java.awt.image;



using java.text;

using javax.swing;
using javax.swing.@event;


/*[Implements(new string[]
{
	"java.awt.event.MouseListener",
	"java.awt.event.MouseMotionListener",
	"java.awt.event.MouseWheelListener",
	"java.awt.event.KeyListener",
	"java.awt.event.ActionListener",
	"javax.swing.event.ChangeListener",
	"java.awt.event.ComponentListener",
	"java.awt.event.WindowFocusListener"
})]*/
public sealed class StdDraw3D, MouseListener, EventListener, MouseMotionListener, MouseWheelListener, KeyListener, ActionListener, ChangeListener, ComponentListener, WindowFocusListener
{
	[InnerClass(null, Modifiers.Public | Modifiers.Static), SourceFile("StdDraw3D.java")]
	public class Camera : StdDraw3D.Transformable
	{
		private object tg;
		private StdDraw3D.Shape pair;
		
		
		private Camera(object obj)
		{
			ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D.Camera).TypeHandle, "javax.media.j3d.TransformGroup");
			object obj2 = null;
			base..ctor(obj, obj2);
			this.tg = obj;
		}
		
		
		public virtual void rotateFPS(double d1, double d2, double d3)
		{
			double d4 = java.lang.Math.toRadians(d1);
			double num = java.lang.Math.toRadians(d2);
			double d5 = java.lang.Math.toRadians(d3);
			StdDraw3D.Vector3D sddvd = StdDraw3D.Transformable.access_2300(this, new StdDraw3D.Vector3D(-num, d4, d5));
			StdDraw3D.Vector3D vector3D = base.getDirection().plus(sddvd);
			double num2 = vector3D.angle(StdDraw3D.access_1500());
			if (num2 > 90.0)
			{
				num2 = 180.0 - num2;
			}
			if (num2 < 5.0)
			{
				return;
			}
			base.setDirection(base.getDirection().plus(sddvd));
		}
		
		
		public virtual void match(StdDraw3D.Shape sdds)
		{
			StdDraw3D.Transformable.access_1900(this, sdds);
		}
		public virtual void pair(StdDraw3D.Shape sdds)
		{
			this.pair = sdds;
		}
		public virtual void unpair()
		{
			this.pair = null;
		}
		
		
		public override void moveRelative(StdDraw3D.Vector3D sddvd)
		{
			StdDraw3D.access_2000();
			throw new NoClassDefFoundError("javax.media.j3d.View");
		}
		
		
		public virtual void rotateFPS(StdDraw3D.Vector3D sddvd)
		{
			this.rotateFPS(sddvd.__x, sddvd.__y, sddvd.__z);
		}
/*		[LineNumberTable(3969), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override StdDraw3D.Vector3D getDirection()
		{
			return base.getDirection();
		}
/*		[LineNumberTable(3969), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void setDirection(StdDraw3D.Vector3D sddvd1, StdDraw3D.Vector3D sddvd2)
		{
			base.setDirection(sddvd1, sddvd2);
		}
/*		[LineNumberTable(3969), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void setDirection(StdDraw3D.Vector3D sddvd)
		{
			base.setDirection(sddvd);
		}
/*		[LineNumberTable(3969), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void lookAt(StdDraw3D.Vector3D sddvd1, StdDraw3D.Vector3D sddvd2)
		{
			base.lookAt(sddvd1, sddvd2);
		}
/*		[LineNumberTable(3969), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void lookAt(StdDraw3D.Vector3D sddvd)
		{
			base.lookAt(sddvd);
		}
/*		[LineNumberTable(3969), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override StdDraw3D.Vector3D getOrientation()
		{
			return base.getOrientation();
		}
/*		[LineNumberTable(3969), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void setOrientation(StdDraw3D.Vector3D sddvd)
		{
			base.setOrientation(sddvd);
		}
/*		[LineNumberTable(3969), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void setOrientation(double d1, double d2, double d3)
		{
			base.setOrientation(d1, d2, d3);
		}
/*		[LineNumberTable(3969), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void rotateRelative(StdDraw3D.Vector3D sddvd)
		{
			base.rotateRelative(sddvd);
		}
/*		[LineNumberTable(3969), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void rotateRelative(double d1, double d2, double d3)
		{
			base.rotateRelative(d1, d2, d3);
		}
/*		[LineNumberTable(3969), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void rotate(StdDraw3D.Vector3D sddvd)
		{
			base.rotate(sddvd);
		}
/*		[LineNumberTable(3969), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void rotate(double d1, double d2, double d3)
		{
			base.rotate(d1, d2, d3);
		}
/*		[LineNumberTable(3969), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override StdDraw3D.Vector3D getPosition()
		{
			return base.getPosition();
		}
/*		[LineNumberTable(3969), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void setPosition(StdDraw3D.Vector3D sddvd)
		{
			base.setPosition(sddvd);
		}
/*		[LineNumberTable(3969), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void setPosition(double d1, double d2, double d3)
		{
			base.setPosition(d1, d2, d3);
		}
/*		[LineNumberTable(3969), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void moveRelative(double d1, double d2, double d3)
		{
			base.moveRelative(d1, d2, d3);
		}
/*		[LineNumberTable(3969), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void move(StdDraw3D.Vector3D sddvd)
		{
			base.move(sddvd);
		}
/*		[LineNumberTable(3969), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void move(double d1, double d2, double d3)
		{
			base.move(d1, d2, d3);
		}
/*		[LineNumberTable(3969), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void rotateAxis(StdDraw3D.Vector3D sddvd, double d)
		{
			base.rotateAxis(sddvd, d);
		}
/*		[LineNumberTable(3969), Modifiers(Modifiers.Synthetic)]*/
		
		internal Camera(object obj, object obj2)
		{
			ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D.Camera).TypeHandle, "javax.media.j3d.TransformGroup");
			ByteCodeHelper.DynamicCast(obj2, typeof(StdDraw3D.Camera).TypeHandle, "StdDraw3D$1");
			this..ctor(obj);
		}
/*		[LineNumberTable(3969), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static StdDraw3D.Shape access_200(StdDraw3D.Camera camera)
		{
			return camera.pair;
		}
	}
	[InnerClass(null, Modifiers.Public | Modifiers.Static), SourceFile("StdDraw3D.java")]
	public class Light : StdDraw3D.Transformable
	{
		internal object light;
		internal object bg;
/*		[LineNumberTable(4119), Modifiers(Modifiers.Synthetic)]*/
		
		internal Light(object obj, object obj2, object obj3, object obj4)
		{
			ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D.Light).TypeHandle, "javax.media.j3d.BranchGroup");
			ByteCodeHelper.DynamicCast(obj2, typeof(StdDraw3D.Light).TypeHandle, "javax.media.j3d.TransformGroup");
			ByteCodeHelper.DynamicCast(obj3, typeof(StdDraw3D.Light).TypeHandle, "javax.media.j3d.Light");
			ByteCodeHelper.DynamicCast(obj4, typeof(StdDraw3D.Light).TypeHandle, "StdDraw3D$1");
			this..ctor(obj, obj2, obj3);
		}
/*		[LineNumberTable(4119), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void setDirection(StdDraw3D.Vector3D sddvd)
		{
			base.setDirection(sddvd);
		}
/*		[LineNumberTable(4119), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void setPosition(double d1, double d2, double d3)
		{
			base.setPosition(d1, d2, d3);
		}
		
		
		public virtual void scalePower(double d)
		{
			if (ByteCodeHelper.DynamicInstanceOf(this.light, typeof(StdDraw3D.Light).TypeHandle, "javax.media.j3d.PointLight"))
			{
				double arg_34_0 = (double)1f / (0.999 * d + 0.001);
				ByteCodeHelper.DynamicCast(this.light, typeof(StdDraw3D.Light).TypeHandle, "javax.media.j3d.PointLight");
				throw new NoClassDefFoundError("javax.vecmath.Point3f");
			}
			System.err.println("Can only scale power for point lights!");
		}
		
		
		private Light(object obj, object obj2, object obj3)
		{
			ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D.Light).TypeHandle, "javax.media.j3d.BranchGroup");
			ByteCodeHelper.DynamicCast(obj2, typeof(StdDraw3D.Light).TypeHandle, "javax.media.j3d.TransformGroup");
			ByteCodeHelper.DynamicCast(obj3, typeof(StdDraw3D.Light).TypeHandle, "javax.media.j3d.Light");
			object obj4 = null;
			base..ctor(obj2, obj4);
			this.light = obj3;
			this.bg = obj;
		}
		
		public virtual void hide()
		{
			this.light;
			0;
			throw new NoClassDefFoundError("javax.media.j3d.Light");
		}
		
		public virtual void unhide()
		{
			this.light;
			1;
			throw new NoClassDefFoundError("javax.media.j3d.Light");
		}
		
		
		public virtual void match(StdDraw3D.Shape sdds)
		{
			StdDraw3D.Transformable.access_1900(this, sdds);
		}
		
		
		public virtual void match(StdDraw3D.Camera sddc)
		{
			StdDraw3D.Transformable.access_1900(this, sddc);
		}
		
		public virtual void setColor(Color c)
		{
			this.light;
			throw new NoClassDefFoundError("javax.vecmath.Color3f");
		}
/*		[LineNumberTable(4119), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override StdDraw3D.Vector3D getDirection()
		{
			return base.getDirection();
		}
/*		[LineNumberTable(4119), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void setDirection(StdDraw3D.Vector3D sddvd1, StdDraw3D.Vector3D sddvd2)
		{
			base.setDirection(sddvd1, sddvd2);
		}
/*		[LineNumberTable(4119), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void lookAt(StdDraw3D.Vector3D sddvd1, StdDraw3D.Vector3D sddvd2)
		{
			base.lookAt(sddvd1, sddvd2);
		}
/*		[LineNumberTable(4119), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void lookAt(StdDraw3D.Vector3D sddvd)
		{
			base.lookAt(sddvd);
		}
/*		[LineNumberTable(4119), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override StdDraw3D.Vector3D getOrientation()
		{
			return base.getOrientation();
		}
/*		[LineNumberTable(4119), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void setOrientation(StdDraw3D.Vector3D sddvd)
		{
			base.setOrientation(sddvd);
		}
/*		[LineNumberTable(4119), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void setOrientation(double d1, double d2, double d3)
		{
			base.setOrientation(d1, d2, d3);
		}
/*		[LineNumberTable(4119), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void rotateRelative(StdDraw3D.Vector3D sddvd)
		{
			base.rotateRelative(sddvd);
		}
/*		[LineNumberTable(4119), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void rotateRelative(double d1, double d2, double d3)
		{
			base.rotateRelative(d1, d2, d3);
		}
/*		[LineNumberTable(4119), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void rotate(StdDraw3D.Vector3D sddvd)
		{
			base.rotate(sddvd);
		}
/*		[LineNumberTable(4119), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void rotate(double d1, double d2, double d3)
		{
			base.rotate(d1, d2, d3);
		}
/*		[LineNumberTable(4119), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override StdDraw3D.Vector3D getPosition()
		{
			return base.getPosition();
		}
/*		[LineNumberTable(4119), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void setPosition(StdDraw3D.Vector3D sddvd)
		{
			base.setPosition(sddvd);
		}
/*		[LineNumberTable(4119), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void moveRelative(StdDraw3D.Vector3D sddvd)
		{
			base.moveRelative(sddvd);
		}
/*		[LineNumberTable(4119), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void moveRelative(double d1, double d2, double d3)
		{
			base.moveRelative(d1, d2, d3);
		}
/*		[LineNumberTable(4119), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void move(StdDraw3D.Vector3D sddvd)
		{
			base.move(sddvd);
		}
/*		[LineNumberTable(4119), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void move(double d1, double d2, double d3)
		{
			base.move(d1, d2, d3);
		}
/*		[LineNumberTable(4119), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void rotateAxis(StdDraw3D.Vector3D sddvd, double d)
		{
			base.rotateAxis(sddvd, d);
		}
	}
	[InnerClass(null, Modifiers.Public | Modifiers.Static), SourceFile("StdDraw3D.java")]
	public class Shape : StdDraw3D.Transformable
	{
		private object bg;
		private object tg;
/*		[LineNumberTable(4025), Modifiers(Modifiers.Synthetic)]*/
		
		internal Shape(object obj, object obj2, object obj3)
		{
			ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D.Shape).TypeHandle, "javax.media.j3d.BranchGroup");
			ByteCodeHelper.DynamicCast(obj2, typeof(StdDraw3D.Shape).TypeHandle, "javax.media.j3d.TransformGroup");
			ByteCodeHelper.DynamicCast(obj3, typeof(StdDraw3D.Shape).TypeHandle, "StdDraw3D$1");
			this..ctor(obj, obj2);
		}
/*		[LineNumberTable(4025), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void rotateAxis(StdDraw3D.Vector3D sddvd, double d)
		{
			base.rotateAxis(sddvd, d);
		}
/*		[LineNumberTable(4025), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static object access_900(StdDraw3D.Shape shape)
		{
			return shape.bg;
		}
/*		[LineNumberTable(4025), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static object access_1000(StdDraw3D.Shape shape)
		{
			return shape.tg;
		}
		
		
		public virtual void scale(double d)
		{
			object obj = StdDraw3D.Transformable.access_2400(this);
			obj;
			obj;
			throw new NoClassDefFoundError("javax.media.j3d.Transform3D");
		}
/*		[LineNumberTable(4025), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void move(double d1, double d2, double d3)
		{
			base.move(d1, d2, d3);
		}
/*		[LineNumberTable(4025), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void rotate(double d1, double d2, double d3)
		{
			base.rotate(d1, d2, d3);
		}
		
		
		private Shape(object obj, object obj2)
		{
			ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D.Shape).TypeHandle, "javax.media.j3d.BranchGroup");
			ByteCodeHelper.DynamicCast(obj2, typeof(StdDraw3D.Shape).TypeHandle, "javax.media.j3d.TransformGroup");
			object obj3 = null;
			base..ctor(obj2, obj3);
			this.bg = obj;
			this.tg = obj2;
			obj2;
			17;
			throw new NoClassDefFoundError("javax.media.j3d.TransformGroup");
		}
		
		
		public virtual void hide()
		{
			StdDraw3D.access_2600();
			this.bg;
			throw new NoClassDefFoundError("javax.media.j3d.BranchGroup");
		}
		
		private void setColor(object obj, Color color)
		{
			ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D.Shape).TypeHandle, "javax.media.j3d.Group");
			int num = 0;
			num;
			obj;
			throw new NoClassDefFoundError("javax.media.j3d.Group");
		}
		
		
		public virtual void setColor(Color c)
		{
			this.setColor(this.tg, c);
		}
		
		private void setColor(object obj, Color color)
		{
			ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D.Shape).TypeHandle, "javax.media.j3d.Appearance");
			obj;
			throw new NoClassDefFoundError("javax.media.j3d.Appearance");
		}
		
		
		public virtual void unhide()
		{
			this.hide();
			StdDraw3D.access_2600();
			this.bg;
			throw new NoClassDefFoundError("javax.media.j3d.BranchGroup");
		}
		
		
		public virtual void match(StdDraw3D.Shape sdds)
		{
			StdDraw3D.Transformable.access_1900(this, sdds);
		}
		
		
		public virtual void match(StdDraw3D.Camera sddc)
		{
			StdDraw3D.Transformable.access_1900(this, sddc);
		}
		
		
		public virtual void setColor(Color c, int i)
		{
			Color.__<clinit>();
			this.setColor(new Color(c.getRed(), c.getGreen(), c.getBlue(), i));
		}
/*		[LineNumberTable(4025), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override StdDraw3D.Vector3D getDirection()
		{
			return base.getDirection();
		}
/*		[LineNumberTable(4025), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void setDirection(StdDraw3D.Vector3D sddvd1, StdDraw3D.Vector3D sddvd2)
		{
			base.setDirection(sddvd1, sddvd2);
		}
/*		[LineNumberTable(4025), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void setDirection(StdDraw3D.Vector3D sddvd)
		{
			base.setDirection(sddvd);
		}
/*		[LineNumberTable(4025), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void lookAt(StdDraw3D.Vector3D sddvd1, StdDraw3D.Vector3D sddvd2)
		{
			base.lookAt(sddvd1, sddvd2);
		}
/*		[LineNumberTable(4025), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void lookAt(StdDraw3D.Vector3D sddvd)
		{
			base.lookAt(sddvd);
		}
/*		[LineNumberTable(4025), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override StdDraw3D.Vector3D getOrientation()
		{
			return base.getOrientation();
		}
/*		[LineNumberTable(4025), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void setOrientation(StdDraw3D.Vector3D sddvd)
		{
			base.setOrientation(sddvd);
		}
/*		[LineNumberTable(4025), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void setOrientation(double d1, double d2, double d3)
		{
			base.setOrientation(d1, d2, d3);
		}
/*		[LineNumberTable(4025), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void rotateRelative(StdDraw3D.Vector3D sddvd)
		{
			base.rotateRelative(sddvd);
		}
/*		[LineNumberTable(4025), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void rotateRelative(double d1, double d2, double d3)
		{
			base.rotateRelative(d1, d2, d3);
		}
/*		[LineNumberTable(4025), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void rotate(StdDraw3D.Vector3D sddvd)
		{
			base.rotate(sddvd);
		}
/*		[LineNumberTable(4025), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override StdDraw3D.Vector3D getPosition()
		{
			return base.getPosition();
		}
/*		[LineNumberTable(4025), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void setPosition(StdDraw3D.Vector3D sddvd)
		{
			base.setPosition(sddvd);
		}
/*		[LineNumberTable(4025), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void setPosition(double d1, double d2, double d3)
		{
			base.setPosition(d1, d2, d3);
		}
/*		[LineNumberTable(4025), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void moveRelative(StdDraw3D.Vector3D sddvd)
		{
			base.moveRelative(sddvd);
		}
/*		[LineNumberTable(4025), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void moveRelative(double d1, double d2, double d3)
		{
			base.moveRelative(d1, d2, d3);
		}
/*		[LineNumberTable(4025), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public override void move(StdDraw3D.Vector3D sddvd)
		{
			base.move(sddvd);
		}
	}
	[InnerClass(null, Modifiers.Private | Modifiers.Static), SourceFile("StdDraw3D.java")]
	internal class Transformable
	{
		private object tg;
		
		private void setTransform(object obj)
		{
			ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D.Transformable).TypeHandle, "javax.media.j3d.Transform3D");
			this.tg;
			obj;
			throw new NoClassDefFoundError("javax.media.j3d.TransformGroup");
		}
		
		private object getTransform()
		{
			throw new NoClassDefFoundError("javax.media.j3d.Transform3D");
		}
		
		
		private StdDraw3D.Vector3D relToAbs(StdDraw3D.Vector3D vector3D)
		{
			this.getTransform();
			throw new NoClassDefFoundError("javax.vecmath.Matrix3d");
		}
		
		
		private void match(StdDraw3D.Transformable transformable)
		{
			this.setOrientation(transformable.getOrientation());
			this.setPosition(transformable.getPosition());
		}
		
		
		private Transformable(object obj)
		{
			ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D.Transformable).TypeHandle, "javax.media.j3d.TransformGroup");
			base..ctor();
			this.tg = obj;
		}
		
		
		private void rotateQuat(object obj)
		{
			ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D.Transformable).TypeHandle, "javax.vecmath.Quat4d");
			this.getTransform();
			throw new NoClassDefFoundError("javax.media.j3d.Transform3D");
		}
		
		
		private void setQuaternion(object obj)
		{
			ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D.Transformable).TypeHandle, "javax.vecmath.Quat4d");
			object transform = this.getTransform();
			transform;
			obj;
			throw new NoClassDefFoundError("javax.media.j3d.Transform3D");
		}
		
		
		private StdDraw3D.Vector3D absToRel(StdDraw3D.Vector3D vector3D)
		{
			this.getTransform();
			throw new NoClassDefFoundError("javax.vecmath.Matrix3d");
		}
		
		
		public virtual void move(StdDraw3D.Vector3D vector3D)
		{
			this.getTransform();
			throw new NoClassDefFoundError("javax.vecmath.Vector3f");
		}
		
		
		public virtual void moveRelative(StdDraw3D.Vector3D vector3D)
		{
			this.move(this.relToAbs(vector3D.times((double)1f, (double)1f, -1.0)));
		}
		
		
		public virtual void setPosition(StdDraw3D.Vector3D vector3D)
		{
			object transform = this.getTransform();
			transform;
			StdDraw3D.access_1100(vector3D);
			throw new NoClassDefFoundError("javax.media.j3d.Transform3D");
		}
		
		
		public virtual void rotate(StdDraw3D.Vector3D vector3D)
		{
			this.getTransform();
			throw new NoClassDefFoundError("javax.media.j3d.Transform3D");
		}
		
		
		public virtual void rotateRelative(StdDraw3D.Vector3D vector3D)
		{
			this.getTransform();
			throw new NoClassDefFoundError("javax.media.j3d.Transform3D");
		}
		
		
		public virtual void setOrientation(StdDraw3D.Vector3D vector3D)
		{
			if (java.lang.Math.abs(vector3D.__y) == 90.0)
			{
				System.err.println("Gimbal lock when the y-angle is vertical!");
			}
			this.getTransform();
			vector3D.times(0.017453292519943295);
			throw new NoClassDefFoundError("javax.media.j3d.Transform3D");
		}
		
		
		public virtual void lookAt(StdDraw3D.Vector3D vector3D, StdDraw3D.Vector3D vector3D2)
		{
			this.getTransform();
			throw new NoClassDefFoundError("javax.media.j3d.Transform3D");
		}
		
		
		public virtual void setDirection(StdDraw3D.Vector3D sddvd, StdDraw3D.Vector3D vector3D)
		{
			StdDraw3D.Vector3D vector3D2 = this.getPosition().plus(sddvd);
			this.lookAt(vector3D2, vector3D);
		}
		
		
		public virtual StdDraw3D.Vector3D getPosition()
		{
			this.getTransform();
			throw new NoClassDefFoundError("javax.vecmath.Vector3d");
		}
		
		
		public virtual StdDraw3D.Vector3D getOrientation()
		{
			this.getTransform();
			throw new NoClassDefFoundError("javax.vecmath.Matrix3d");
		}
		
		private void rotateQuat(double num, double num2, double num3, double num4)
		{
			this;
			throw new NoClassDefFoundError("javax.vecmath.Quat4d");
		}
		
		private void setQuaternion(double num, double num2, double num3, double num4)
		{
			this;
			throw new NoClassDefFoundError("javax.vecmath.Quat4d");
		}
		
		
		private object getQuaternion()
		{
			this.getTransform();
			throw new NoClassDefFoundError("javax.vecmath.Matrix3d");
		}
		
		
		private void orientAxis(StdDraw3D.Vector3D vector3D, double num)
		{
			this.getTransform();
			throw new NoClassDefFoundError("javax.vecmath.AxisAngle4d");
		}
		
		
		public virtual void rotateAxis(StdDraw3D.Vector3D vector3D, double num)
		{
			if (num == (double)0f)
			{
				return;
			}
			this.getTransform();
			this.absToRel(vector3D);
			throw new NoClassDefFoundError("javax.vecmath.AxisAngle4d");
		}
		
		
		public virtual void move(double num, double num2, double num3)
		{
			this.move(new StdDraw3D.Vector3D(num, num2, num3));
		}
		
		
		public virtual void moveRelative(double num, double num2, double num3)
		{
			this.moveRelative(new StdDraw3D.Vector3D(num, num2, num3));
		}
		
		
		public virtual void setPosition(double num, double num2, double num3)
		{
			this.setPosition(new StdDraw3D.Vector3D(num, num2, num3));
		}
		
		
		public virtual void rotate(double num, double num2, double num3)
		{
			this.rotate(new StdDraw3D.Vector3D(num, num2, num3));
		}
		
		
		public virtual void rotateRelative(double num, double num2, double num3)
		{
			this.rotateRelative(new StdDraw3D.Vector3D(num, num2, num3));
		}
		
		
		public virtual void setOrientation(double num, double num2, double num3)
		{
			this.setOrientation(new StdDraw3D.Vector3D(num, num2, num3));
		}
		
		
		public virtual void lookAt(StdDraw3D.Vector3D vector3D)
		{
			this.lookAt(vector3D, StdDraw3D.access_1500());
		}
		
		
		public virtual void setDirection(StdDraw3D.Vector3D vector3D)
		{
			this.setDirection(vector3D, StdDraw3D.access_1500());
		}
		
		
		public virtual StdDraw3D.Vector3D getDirection()
		{
			return this.relToAbs(StdDraw3D.access_1600().times(-1.0)).direction();
		}
/*		[LineNumberTable(3608), Modifiers(Modifiers.Synthetic)]*/
		
		internal Transformable(object obj, object obj2)
		{
			ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D.Transformable).TypeHandle, "javax.media.j3d.TransformGroup");
			ByteCodeHelper.DynamicCast(obj2, typeof(StdDraw3D.Transformable).TypeHandle, "StdDraw3D$1");
			this..ctor(obj);
		}
/*		[LineNumberTable(3608), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		
		internal static void access_1900(StdDraw3D.Transformable transformable, StdDraw3D.Transformable transformable2)
		{
			transformable.match(transformable2);
		}
/*		[LineNumberTable(3608), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		
		internal static StdDraw3D.Vector3D access_2300(StdDraw3D.Transformable transformable, StdDraw3D.Vector3D vector3D)
		{
			return transformable.relToAbs(vector3D);
		}
/*		[LineNumberTable(3608), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		
		internal static object access_2400(StdDraw3D.Transformable transformable)
		{
			return transformable.getTransform();
		}
/*		[LineNumberTable(3608), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		
		internal static void access_2500(StdDraw3D.Transformable transformable, object obj)
		{
			ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D.Transformable).TypeHandle, "javax.media.j3d.Transform3D");
			transformable.setTransform(obj);
		}
	}
	[InnerClass(null, Modifiers.Public | Modifiers.Static), SourceFile("StdDraw3D.java")]
	public class Vector3D
	{
		internal double __x;
		internal double __y;
		internal double __z;
//[Modifiers(Modifiers.Public | Modifiers.Final)]
		public double x
		{
			
			get
			{
				return this.__x;
			}
			
			private set
			{
				this.__x = value;
			}
		}
//[Modifiers(Modifiers.Public | Modifiers.Final)]
		public double y
		{
			
			get
			{
				return this.__y;
			}
			
			private set
			{
				this.__y = value;
			}
		}
//[Modifiers(Modifiers.Public | Modifiers.Final)]
		public double z
		{
			
			get
			{
				return this.__z;
			}
			
			private set
			{
				this.__z = value;
			}
		}
/*		[LineNumberTable(4176), Modifiers(Modifiers.Synthetic)]*/
		
		internal Vector3D(object obj, object obj2)
		{
			ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D.Vector3D).TypeHandle, "javax.vecmath.Vector3f");
			ByteCodeHelper.DynamicCast(obj2, typeof(StdDraw3D.Vector3D).TypeHandle, "StdDraw3D$1");
			this..ctor(obj);
		}
		
		
		public Vector3D(double d1, double d2, double d3)
		{
			this.__x = d1;
			this.__y = d2;
			this.__z = d3;
		}
		
		
		public virtual StdDraw3D.Vector3D times(double d1, double d2, double d3)
		{
			double d4 = this.__x * d1;
			double d5 = this.__y * d2;
			double d6 = this.__z * d3;
			return new StdDraw3D.Vector3D(d4, d5, d6);
		}
/*		[LineNumberTable(4176), Modifiers(Modifiers.Synthetic)]*/
		
		internal Vector3D(object obj, object obj2)
		{
			ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D.Vector3D).TypeHandle, "javax.vecmath.Vector3d");
			ByteCodeHelper.DynamicCast(obj2, typeof(StdDraw3D.Vector3D).TypeHandle, "StdDraw3D$1");
			this..ctor(obj);
		}
		
		
		public virtual StdDraw3D.Vector3D times(double d)
		{
			return this.times(d, d, d);
		}
		
		
		public virtual StdDraw3D.Vector3D plus(StdDraw3D.Vector3D sddvd)
		{
			double d = this.__x + sddvd.__x;
			double d2 = this.__y + sddvd.__y;
			double d3 = this.__z + sddvd.__z;
			return new StdDraw3D.Vector3D(d, d2, d3);
		}
		
		
		public virtual StdDraw3D.Vector3D direction()
		{
			if (this.mag() == (double)0f)
			{
				string arg_17_0 = "Zero-vector has no direction";
				
				throw new RuntimeException(arg_17_0);
			}
			return this.times((double)1f / this.mag());
		}
		
		
		public virtual double angle(StdDraw3D.Vector3D sddvd)
		{
			return java.lang.Math.toDegrees(java.lang.Math.acos(this.dot(sddvd) / (this.mag() * sddvd.mag())));
		}
/*		[LineNumberTable(4176), Modifiers(Modifiers.Synthetic)]*/
		
		internal Vector3D(object obj, object obj2)
		{
			ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D.Vector3D).TypeHandle, "javax.vecmath.Point3d");
			ByteCodeHelper.DynamicCast(obj2, typeof(StdDraw3D.Vector3D).TypeHandle, "StdDraw3D$1");
			this..ctor(obj);
		}
		
		
		public virtual double mag()
		{
			return java.lang.Math.sqrt(this.dot(this));
		}
		
		
		public virtual StdDraw3D.Vector3D cross(StdDraw3D.Vector3D sddvd)
		{
			return new StdDraw3D.Vector3D(this.__y * sddvd.__z - this.__z * sddvd.__y, this.__z * sddvd.__x - this.__x * sddvd.__z, this.__x * sddvd.__y - this.__y * sddvd.__x);
		}
		
		
		private Vector3D(object obj)
		{
			ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D.Vector3D).TypeHandle, "javax.vecmath.Vector3d");
			base..ctor();
			this;
			obj;
			throw new NoClassDefFoundError("javax.vecmath.Vector3d");
		}
		
		
		private Vector3D(object obj)
		{
			ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D.Vector3D).TypeHandle, "javax.vecmath.Vector3f");
			base..ctor();
			this;
			obj;
			throw new NoClassDefFoundError("javax.vecmath.Vector3f");
		}
		
		
		private Vector3D(object obj)
		{
			ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D.Vector3D).TypeHandle, "javax.vecmath.Point3d");
			base..ctor();
			this;
			obj;
			throw new NoClassDefFoundError("javax.vecmath.Point3d");
		}
		
		public virtual double dot(StdDraw3D.Vector3D sddvd)
		{
			return this.__x * sddvd.__x + this.__y * sddvd.__y + this.__z * sddvd.__z;
		}
		
		
		public virtual StdDraw3D.Vector3D minus(StdDraw3D.Vector3D sddvd)
		{
			double d = this.__x - sddvd.__x;
			double d2 = this.__y - sddvd.__y;
			double d3 = this.__z - sddvd.__z;
			return new StdDraw3D.Vector3D(d, d2, d3);
		}
		
		
		public virtual StdDraw3D.Vector3D proj(StdDraw3D.Vector3D sddvd)
		{
			StdDraw3D.Vector3D vector3D = sddvd.direction();
			return vector3D.times(this.dot(vector3D));
		}
		
		
		public Vector3D()
		{
			this.__x = (double)0f;
			this.__y = (double)0f;
			this.__z = (double)0f;
		}
		
		
		public Vector3D(double[] darr)
		{
			if (darr.Length != 3)
			{
				string arg_17_0 = "Incorrect number of dimensions!";
				
				throw new RuntimeException(arg_17_0);
			}
			this.__x = darr[0];
			this.__y = darr[1];
			this.__z = darr[2];
		}
		
		
		private Vector3D(object obj)
		{
			ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D.Vector3D).TypeHandle, "javax.vecmath.Point3f");
			base..ctor();
			this;
			obj;
			throw new NoClassDefFoundError("javax.vecmath.Point3f");
		}
		
		
		public virtual double distanceTo(StdDraw3D.Vector3D sddvd)
		{
			return this.minus(sddvd).mag();
		}
		
		
		public virtual StdDraw3D.Vector3D plus(double d1, double d2, double d3)
		{
			double d4 = this.__x + d1;
			double d5 = this.__y + d2;
			double d6 = this.__z + d3;
			return new StdDraw3D.Vector3D(d4, d5, d6);
		}
		
		
		public virtual StdDraw3D.Vector3D minus(double d1, double d2, double d3)
		{
			double d4 = this.__x - d1;
			double d5 = this.__y - d2;
			double d6 = this.__z - d3;
			return new StdDraw3D.Vector3D(d4, d5, d6);
		}
		
		
		public virtual StdDraw3D.Vector3D reflect(StdDraw3D.Vector3D sddvd)
		{
			return this.proj(sddvd).times(2.0).minus(this);
		}
		
		
		public override string ToString()
		{
			DecimalFormat decimalFormat = new DecimalFormat("0.000000");
			return new StringBuilder().append("( ").append(decimalFormat.format(this.__x)).append(", ").append(decimalFormat.format(this.__y)).append(", ").append(decimalFormat.format(this.__z)).append(" )").toString();
		}
		
		
		public virtual void draw()
		{
			StdDraw3D.sphere(this.__x, this.__y, this.__z, 0.01);
		}
	}
	internal static Color __BLACK;
	internal static Color __BLUE;
	internal static Color __CYAN;
	internal static Color __DARK_GRAY;
	internal static Color __GRAY;
	internal static Color __GREEN;
	internal static Color __LIGHT_GRAY;
	internal static Color __MAGENTA;
	internal static Color __ORANGE;
	internal static Color __PINK;
	internal static Color __RED;
	internal static Color __WHITE;
	internal static Color __YELLOW;
	public const int ORBIT_MODE = 0;
	public const int FPS_MODE = 1;
	public const int AIRPLANE_MODE = 2;
	public const int LOOK_MODE = 3;
	public const int FIXED_MODE = 4;
	public const int IMMERSIVE_MODE = 5;
	private static JFrame frame;
	private static Panel canvasPanel;
	private static JMenuBar menuBar;
	private static JMenu fileMenu;
	private static JMenu cameraMenu;
	private static JMenu graphicsMenu;
	private static JMenuItem loadButton;
	private static JMenuItem saveButton;
	private static JMenuItem save3DButton;
	private static JMenuItem quitButton;
	private static JSpinner fovSpinner;
	private static JRadioButtonMenuItem orbitModeButton;
	private static JRadioButtonMenuItem fpsModeButton;
	private static JRadioButtonMenuItem airplaneModeButton;
	private static JRadioButtonMenuItem lookModeButton;
	private static JRadioButtonMenuItem fixedModeButton;
	private static JRadioButtonMenuItem perspectiveButton;
	private static JRadioButtonMenuItem parallelButton;
	private static JCheckBoxMenuItem antiAliasingButton;
	private static JSpinner numDivSpinner;
	private static JCheckBox infoCheckBox;
	private static object universe;
	private static object rootGroup;
	private static object lightGroup;
	private static object soundGroup;
	private static object fogGroup;
	private static object appearanceGroup;
	private static object onscreenGroup;
	private static object offscreenGroup;
	private static object orbit;
	private static object background;
	private static object bgGroup;
	private static object view;
	private static object canvas;
	private static StdDraw3D.Camera camera;
	private static BufferedImage offscreenImage;
	private static BufferedImage onscreenImage;
	private static BufferedImage infoImage;
	private static int width;
	private static int height;
	private static double aspectRatio;
	private static int cameraMode;
	private static object orbitCenter;
	private static double min;
	private static double max;
	private static double zoom;
	private static Color bgColor;
	private static Color penColor;
	private static float penRadius;
	private static Font font;
	private static bool clear3D;
	private static bool clearOverlay;
	private static bool infoDisplay;
	private static int numDivisions;
	private static bool mouse1;
	private static bool mouse2;
	private static bool mouse3;
	private static double mouseX;
	private static double mouseY;
//[Signature("Ljava/util/TreeSet<Ljava/lang/Integer;>;")]
	private static TreeSet keysDown;
//[Signature("Ljava/util/LinkedList<Ljava/lang/Character;>;")]
	private static LinkedList keysTyped;
	private static object mouseLock;
	private static object keyLock;
	private static bool initialized;
	private static bool fullscreen;
	private static bool immersive;
	private static bool showedOnce;
	private static bool renderedOnce;
	private const int DEFAULT_SIZE = 600;
	private const double DEFAULT_MIN = 0.0;
	private const double DEFAULT_MAX = 1.0;
	private const int DEFAULT_CAMERA_MODE = 0;
	private const double DEFAULT_FOV = 0.9;
	private const int DEFAULT_NUM_DIVISIONS = 100;
	private const double DEFAULT_FRONT_CLIP = 0.01;
	private const double DEFAULT_BACK_CLIP = 10.0;
//[Modifiers(Modifiers.Private | Modifiers.Static | Modifiers.Final)]
	private static Font DEFAULT_FONT;
	private const double DEFAULT_PEN_RADIUS = 0.002;
//[Modifiers(Modifiers.Private | Modifiers.Static | Modifiers.Final)]
	private static Color DEFAULT_PEN_COLOR;
//[Modifiers(Modifiers.Private | Modifiers.Static | Modifiers.Final)]
	private static Color DEFAULT_BGCOLOR;
	private const double TEXT3D_SHRINK_FACTOR = 0.005;
	private const double TEXT3D_DEPTH = 1.5;
	private const int PRIMFLAGS = 3;
//[Modifiers(Modifiers.Private | Modifiers.Static | Modifiers.Final)]
	private static object INFINITE_BOUNDS;
//[Modifiers(Modifiers.Private | Modifiers.Static | Modifiers.Final)]
	private static StdDraw3D.Vector3D xAxis;
//[Modifiers(Modifiers.Private | Modifiers.Static | Modifiers.Final)]
	private static StdDraw3D.Vector3D yAxis;
//[Modifiers(Modifiers.Private | Modifiers.Static | Modifiers.Final)]
	private static StdDraw3D.Vector3D zAxis;
	private static StdDraw3D std;
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color BLACK
	{
		
		get
		{
			return StdDraw3D.__BLACK;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color BLUE
	{
		
		get
		{
			return StdDraw3D.__BLUE;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color CYAN
	{
		
		get
		{
			return StdDraw3D.__CYAN;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color DARK_GRAY
	{
		
		get
		{
			return StdDraw3D.__DARK_GRAY;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color GRAY
	{
		
		get
		{
			return StdDraw3D.__GRAY;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color GREEN
	{
		
		get
		{
			return StdDraw3D.__GREEN;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color LIGHT_GRAY
	{
		
		get
		{
			return StdDraw3D.__LIGHT_GRAY;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color MAGENTA
	{
		
		get
		{
			return StdDraw3D.__MAGENTA;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color ORANGE
	{
		
		get
		{
			return StdDraw3D.__ORANGE;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color PINK
	{
		
		get
		{
			return StdDraw3D.__PINK;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color RED
	{
		
		get
		{
			return StdDraw3D.__RED;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color WHITE
	{
		
		get
		{
			return StdDraw3D.__WHITE;
		}
	}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Color YELLOW
	{
		
		get
		{
			return StdDraw3D.__YELLOW;
		}
	}
	
	
/*	[LineNumberTable(56), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
	
	internal static object access_1100(StdDraw3D.Vector3D vector3D)
	{
		return StdDraw3D.createVector3f(vector3D);
	}
//[Modifiers(Modifiers.Static | Modifiers.Synthetic)]
	internal static StdDraw3D.Vector3D access_1400()
	{
		return StdDraw3D.xAxis;
	}
//[Modifiers(Modifiers.Static | Modifiers.Synthetic)]
	internal static StdDraw3D.Vector3D access_1500()
	{
		return StdDraw3D.yAxis;
	}
//[Modifiers(Modifiers.Static | Modifiers.Synthetic)]
	internal static StdDraw3D.Vector3D access_1600()
	{
		return StdDraw3D.zAxis;
	}
/*	[LineNumberTable(56), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
	
	internal static object access_1700(StdDraw3D.Vector3D vector3D)
	{
		return StdDraw3D.createVector3d(vector3D);
	}
//[Modifiers(Modifiers.Static | Modifiers.Synthetic)]
	internal static object access_2000()
	{
		return StdDraw3D.view;
	}
//[Modifiers(Modifiers.Static | Modifiers.Synthetic)]
	internal static double access_2100()
	{
		return StdDraw3D.zoom;
	}
/*	[LineNumberTable(56), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
	
	internal static void access_2200(double num)
	{
		StdDraw3D.setScreenScale(num);
	}
	
	private static void setScreenScale(double num)
	{
		num;
		StdDraw3D.view;
		throw new NoClassDefFoundError("javax.media.j3d.View");
	}
	
	private static object createVector3d(StdDraw3D.Vector3D vector3D)
	{
		throw new NoClassDefFoundError("javax.vecmath.Vector3d");
	}
	
	
	private static object createVector3f(StdDraw3D.Vector3D vector3D)
	{
		return StdDraw3D.createVector3f(vector3D.__x, vector3D.__y, vector3D.__z);
	}
	
	
	private static BufferedImage createBufferedImage()
	{
		BufferedImage.__<clinit>();
		return new BufferedImage(StdDraw3D.width, StdDraw3D.height, 2);
	}
	
	
	private static void initializeCanvas()
	{
		Panel panel = new Panel();
		GridBagLayout layout = new GridBagLayout();
		GridBagConstraints gridBagConstraints = new GridBagConstraints();
		panel.setLayout(layout);
		gridBagConstraints.gridx = 0;
		gridBagConstraints.gridy = 0;
		gridBagConstraints.gridwidth = 5;
		gridBagConstraints.gridheight = 5;
		throw new NoClassDefFoundError("com.sun.j3d.utils.universe.SimpleUniverse");
	}
	
	
	private static JMenuBar createMenuBar()
	{
		StdDraw3D.menuBar = new JMenuBar();
		StdDraw3D.fileMenu = new JMenu("File");
		StdDraw3D.menuBar.add(StdDraw3D.fileMenu);
		StdDraw3D.loadButton = new JMenuItem(" Load 3D Model..  ");
		StdDraw3D.loadButton.addActionListener(StdDraw3D.std);
		StdDraw3D.loadButton.setAccelerator(KeyStroke.getKeyStroke(76, Toolkit.getDefaultToolkit().getMenuShortcutKeyMask()));
		StdDraw3D.fileMenu.add(StdDraw3D.loadButton);
		StdDraw3D.saveButton = new JMenuItem(" Save Image...  ");
		StdDraw3D.saveButton.addActionListener(StdDraw3D.std);
		StdDraw3D.saveButton.setAccelerator(KeyStroke.getKeyStroke(83, Toolkit.getDefaultToolkit().getMenuShortcutKeyMask()));
		StdDraw3D.fileMenu.add(StdDraw3D.saveButton);
		StdDraw3D.save3DButton = new JMenuItem(" Export 3D Scene...  ");
		StdDraw3D.save3DButton.addActionListener(StdDraw3D.std);
		StdDraw3D.save3DButton.setAccelerator(KeyStroke.getKeyStroke(69, Toolkit.getDefaultToolkit().getMenuShortcutKeyMask()));
		StdDraw3D.fileMenu.addSeparator();
		StdDraw3D.quitButton = new JMenuItem(" Quit...   ");
		StdDraw3D.quitButton.addActionListener(StdDraw3D.std);
		StdDraw3D.quitButton.setAccelerator(KeyStroke.getKeyStroke(81, Toolkit.getDefaultToolkit().getMenuShortcutKeyMask()));
		StdDraw3D.fileMenu.add(StdDraw3D.quitButton);
		StdDraw3D.cameraMenu = new JMenu("Camera");
		StdDraw3D.menuBar.add(StdDraw3D.cameraMenu);
		JLabel jLabel = new JLabel("Camera Mode");
		jLabel.setAlignmentX(0.5f);
		jLabel.setForeground(StdDraw3D.__GRAY);
		StdDraw3D.cameraMenu.add(jLabel);
		StdDraw3D.cameraMenu.addSeparator();
		ButtonGroup buttonGroup = new ButtonGroup();
		StdDraw3D.orbitModeButton = new JRadioButtonMenuItem("Orbit Mode");
		StdDraw3D.orbitModeButton.setSelected(true);
		buttonGroup.add(StdDraw3D.orbitModeButton);
		StdDraw3D.cameraMenu.add(StdDraw3D.orbitModeButton);
		StdDraw3D.orbitModeButton.addActionListener(StdDraw3D.std);
		StdDraw3D.orbitModeButton.setAccelerator(KeyStroke.getKeyStroke(49, Toolkit.getDefaultToolkit().getMenuShortcutKeyMask()));
		StdDraw3D.fpsModeButton = new JRadioButtonMenuItem("First-Person Mode");
		buttonGroup.add(StdDraw3D.fpsModeButton);
		StdDraw3D.cameraMenu.add(StdDraw3D.fpsModeButton);
		StdDraw3D.fpsModeButton.addActionListener(StdDraw3D.std);
		StdDraw3D.fpsModeButton.setAccelerator(KeyStroke.getKeyStroke(50, Toolkit.getDefaultToolkit().getMenuShortcutKeyMask()));
		StdDraw3D.airplaneModeButton = new JRadioButtonMenuItem("Airplane Mode");
		buttonGroup.add(StdDraw3D.airplaneModeButton);
		StdDraw3D.cameraMenu.add(StdDraw3D.airplaneModeButton);
		StdDraw3D.airplaneModeButton.addActionListener(StdDraw3D.std);
		StdDraw3D.airplaneModeButton.setAccelerator(KeyStroke.getKeyStroke(51, Toolkit.getDefaultToolkit().getMenuShortcutKeyMask()));
		StdDraw3D.lookModeButton = new JRadioButtonMenuItem("Look Mode");
		buttonGroup.add(StdDraw3D.lookModeButton);
		StdDraw3D.cameraMenu.add(StdDraw3D.lookModeButton);
		StdDraw3D.lookModeButton.addActionListener(StdDraw3D.std);
		StdDraw3D.lookModeButton.setAccelerator(KeyStroke.getKeyStroke(52, Toolkit.getDefaultToolkit().getMenuShortcutKeyMask()));
		StdDraw3D.fixedModeButton = new JRadioButtonMenuItem("Fixed Mode");
		buttonGroup.add(StdDraw3D.fixedModeButton);
		StdDraw3D.cameraMenu.add(StdDraw3D.fixedModeButton);
		StdDraw3D.fixedModeButton.addActionListener(StdDraw3D.std);
		StdDraw3D.fixedModeButton.setAccelerator(KeyStroke.getKeyStroke(53, Toolkit.getDefaultToolkit().getMenuShortcutKeyMask()));
		StdDraw3D.cameraMenu.addSeparator();
		JLabel jLabel2 = new JLabel("Projection Mode");
		jLabel2.setAlignmentX(0.5f);
		jLabel2.setForeground(StdDraw3D.__GRAY);
		StdDraw3D.cameraMenu.add(jLabel2);
		StdDraw3D.cameraMenu.addSeparator();
		SpinnerNumberModel model = new SpinnerNumberModel(0.9, 0.5, 3.0, 0.05);
		StdDraw3D.fovSpinner = new JSpinner(model);
		JPanel jPanel = new JPanel();
		jPanel.setLayout(new BoxLayout(jPanel, 0));
		JLabel comp = new JLabel("Field of View:");
		jPanel.add(Box.createRigidArea(new Dimension(30, 5)));
		jPanel.add(comp);
		jPanel.add(Box.createRigidArea(new Dimension(10, 5)));
		jPanel.add(StdDraw3D.fovSpinner);
		ButtonGroup buttonGroup2 = new ButtonGroup();
		StdDraw3D.perspectiveButton = new JRadioButtonMenuItem("Perspective Projection");
		StdDraw3D.parallelButton = new JRadioButtonMenuItem("Parallel Projection");
		StdDraw3D.fovSpinner.addChangeListener(StdDraw3D.std);
		StdDraw3D.perspectiveButton.addActionListener(StdDraw3D.std);
		StdDraw3D.parallelButton.addActionListener(StdDraw3D.std);
		StdDraw3D.cameraMenu.add(StdDraw3D.parallelButton);
		StdDraw3D.cameraMenu.add(StdDraw3D.perspectiveButton);
		StdDraw3D.cameraMenu.add(jPanel);
		buttonGroup2.add(StdDraw3D.parallelButton);
		buttonGroup2.add(StdDraw3D.perspectiveButton);
		StdDraw3D.perspectiveButton.setSelected(true);
		StdDraw3D.graphicsMenu = new JMenu("Graphics");
		JLabel jLabel3 = new JLabel("Polygon Count");
		jLabel3.setAlignmentX(0.5f);
		jLabel3.setForeground(StdDraw3D.__GRAY);
		StdDraw3D.graphicsMenu.add(jLabel3);
		StdDraw3D.graphicsMenu.addSeparator();
		SpinnerNumberModel model2 = new SpinnerNumberModel(100, 4, 4000, 5);
		StdDraw3D.numDivSpinner = new JSpinner(model2);
		JPanel jPanel2 = new JPanel();
		jPanel2.setLayout(new BoxLayout(jPanel2, 0));
		JLabel comp2 = new JLabel("Triangles:");
		jPanel2.add(Box.createRigidArea(new Dimension(5, 5)));
		jPanel2.add(comp2);
		jPanel2.add(Box.createRigidArea(new Dimension(15, 5)));
		jPanel2.add(StdDraw3D.numDivSpinner);
		StdDraw3D.graphicsMenu.add(jPanel2);
		StdDraw3D.numDivSpinner.addChangeListener(StdDraw3D.std);
		StdDraw3D.graphicsMenu.addSeparator();
		JLabel jLabel4 = new JLabel("Advanced Rendering");
		jLabel4.setAlignmentX(0.5f);
		jLabel4.setForeground(StdDraw3D.__GRAY);
		StdDraw3D.graphicsMenu.add(jLabel4);
		StdDraw3D.graphicsMenu.addSeparator();
		StdDraw3D.antiAliasingButton = new JCheckBoxMenuItem("Enable Anti-Aliasing");
		StdDraw3D.antiAliasingButton.setSelected(false);
		StdDraw3D.antiAliasingButton.addActionListener(StdDraw3D.std);
		StdDraw3D.graphicsMenu.add(StdDraw3D.antiAliasingButton);
		StdDraw3D.infoCheckBox = new JCheckBox("Show Info Display");
		StdDraw3D.infoCheckBox.setFocusable(false);
		StdDraw3D.infoCheckBox.addActionListener(StdDraw3D.std);
		StdDraw3D.menuBar.add(Box.createRigidArea(new Dimension(50, 5)));
		StdDraw3D.menuBar.add(StdDraw3D.infoCheckBox);
		return StdDraw3D.menuBar;
	}
	
	private static object createBranchGroup()
	{
		throw new NoClassDefFoundError("javax.media.j3d.BranchGroup");
	}
	
	
	public static void setDefaultLight()
	{
		StdDraw3D.clearLight();
		StdDraw3D.directionalLight(-4.0, 7.0, 12.0, StdDraw3D.__LIGHT_GRAY);
		StdDraw3D.directionalLight(4.0, -7.0, -12.0, StdDraw3D.__WHITE);
		StdDraw3D.ambientLight(new Color(0.1f, 0.1f, 0.1f));
	}
	
	public static void setAntiAliasing(bool b)
	{
		StdDraw3D.view;
		b;
		throw new NoClassDefFoundError("javax.media.j3d.View");
	}
	
	private static void setOrbitCenter(object obj)
	{
		ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D).TypeHandle, "javax.vecmath.Point3d");
		StdDraw3D.orbitCenter = obj;
		StdDraw3D.orbit;
		StdDraw3D.orbitCenter;
		throw new NoClassDefFoundError("com.sun.j3d.utils.behaviors.vp.OrbitBehavior");
	}
	
	
	public static void setPerspectiveProjection()
	{
		StdDraw3D.setPerspectiveProjection(0.9);
	}
	
	
	public static void setCameraMode()
	{
		StdDraw3D.setCameraMode(0);
	}
	public static void setPenColor()
	{
		StdDraw3D.penColor = StdDraw3D.DEFAULT_PEN_COLOR;
	}
	
	
	public static void setPenRadius()
	{
		StdDraw3D.setPenRadius(0.002);
	}
	public static void setFont()
	{
		StdDraw3D.font = StdDraw3D.DEFAULT_FONT;
	}
	
	
	public static void setScale()
	{
		StdDraw3D.setScale((double)0f, (double)1f);
	}
	
	
	public static void setInfoDisplay(bool b)
	{
		StdDraw3D.infoDisplay = b;
		StdDraw3D.infoCheckBox.setSelected(b);
		StdDraw3D.camera.move((double)0f, (double)0f, (double)0f);
		StdDraw3D.infoDisplay();
	}
	
	
	public static void setBackground(Color c)
	{
		if (!c.Equals(StdDraw3D.bgColor))
		{
			StdDraw3D.bgColor = c;
			StdDraw3D.rootGroup;
			StdDraw3D.bgGroup;
			throw new NoClassDefFoundError("javax.media.j3d.BranchGroup");
		}
	}
	
	public static void setPerspectiveProjection(double d)
	{
		StdDraw3D.view;
		1;
		throw new NoClassDefFoundError("javax.media.j3d.View");
	}
	
	
	private static void saveAction()
	{
		FileDialog.__<clinit>();
		FileDialog fileDialog = new FileDialog(StdDraw3D.frame, "Use a .png or .jpg extension.", 1);
		fileDialog.setVisible(true);
		string file = fileDialog.getFile();
		if (file != null)
		{
			StdDraw3D.save(new StringBuilder().append(fileDialog.getDirectory()).append(File.separator).append(fileDialog.getFile()).toString());
		}
		StdDraw3D.keysDown.remove(Integer.valueOf(157));
		StdDraw3D.keysDown.remove(Integer.valueOf(17));
		StdDraw3D.keysDown.remove(Integer.valueOf(83));
	}
	
	
	private static void loadAction()
	{
		FileDialog.__<clinit>();
		FileDialog fileDialog = new FileDialog(StdDraw3D.frame, "Pick a .obj or .ply file to load.", 0);
		fileDialog.setVisible(true);
		string str = new StringBuilder().append(fileDialog.getDirectory()).append(fileDialog.getFile()).toString();
		StdDraw3D.model(str);
		StdDraw3D.keysDown.remove(Integer.valueOf(157));
		StdDraw3D.keysDown.remove(Integer.valueOf(17));
		StdDraw3D.keysDown.remove(Integer.valueOf(76));
	}
	
	
	private static void save3DAction()
	{
		FileDialog.__<clinit>();
		FileDialog fileDialog = new FileDialog(StdDraw3D.frame, "Save as a 3D file for loading later.", 1);
		fileDialog.setVisible(true);
		string file = fileDialog.getFile();
		if (file != null)
		{
			StdDraw3D.saveScene3D(new StringBuilder().append(fileDialog.getDirectory()).append(File.separator).append(fileDialog.getFile()).toString());
		}
		StdDraw3D.keysDown.remove(Integer.valueOf(157));
		StdDraw3D.keysDown.remove(Integer.valueOf(17));
		StdDraw3D.keysDown.remove(Integer.valueOf(69));
	}
	
	
	private static void quitAction()
	{
		WindowEvent.__<clinit>();
		WindowEvent theEvent = new WindowEvent(StdDraw3D.frame, 201);
		Toolkit.getDefaultToolkit().getSystemEventQueue().postEvent(theEvent);
		StdDraw3D.keysDown.remove(Integer.valueOf(157));
		StdDraw3D.keysDown.remove(Integer.valueOf(17));
		StdDraw3D.keysDown.remove(Integer.valueOf(81));
	}
	
	public static void setCameraMode(int i)
	{
		StdDraw3D.cameraMode = i;
		if (StdDraw3D.cameraMode == 0)
		{
			StdDraw3D.orbit;
			1;
			throw new NoClassDefFoundError("com.sun.j3d.utils.behaviors.vp.OrbitBehavior");
		}
		StdDraw3D.orbit;
		0;
		throw new NoClassDefFoundError("com.sun.j3d.utils.behaviors.vp.OrbitBehavior");
	}
	
	public static void setParallelProjection()
	{
		StdDraw3D.view;
		throw new NoClassDefFoundError("javax.media.j3d.View");
	}
	
	private static object createBlankAppearance()
	{
		throw new NoClassDefFoundError("javax.media.j3d.Appearance");
	}
	
	
	private static object createTexture(string str)
	{
		try
		{
			throw new NoClassDefFoundError("com.sun.j3d.utils.image.TextureLoader");
		}
		catch (System.Exception arg_0C_0)
		{
			if (ByteCodeHelper.MapException<java.lang.Exception>(arg_0C_0, ByteCodeHelper.MapFlags.Unused) == null)
			{
				throw;
			}
		}
		string arg_44_0 = new StringBuilder().append("Could not read from the file '").append(str).append("'").toString();
		
		throw new RuntimeException(arg_44_0);
	}
	
	private static object createVector3f(double num, double num2, double num3)
	{
		throw new NoClassDefFoundError("javax.vecmath.Vector3f");
	}
	
	private static object createPoint3f(double num, double num2, double num3)
	{
		throw new NoClassDefFoundError("javax.vecmath.Point3f");
	}
	
	
	private static void setCanvasSize(int num, int num2, bool flag)
	{
		StdDraw3D.fullscreen = flag;
		if (num < 1 || num2 < 1)
		{
			string arg_1A_0 = "Dimensions must be positive integers!";
			
			throw new RuntimeException(arg_1A_0);
		}
		StdDraw3D.width = num;
		StdDraw3D.height = num2;
		StdDraw3D.aspectRatio = (double)StdDraw3D.width / (double)StdDraw3D.height;
		StdDraw3D.initialize();
	}
	
	
	private static void initialize()
	{
		StdDraw3D.numDivisions = 100;
		StdDraw3D.onscreenImage = StdDraw3D.createBufferedImage();
		StdDraw3D.offscreenImage = StdDraw3D.createBufferedImage();
		StdDraw3D.infoImage = StdDraw3D.createBufferedImage();
		StdDraw3D.initializeCanvas();
		if (StdDraw3D.frame != null)
		{
			StdDraw3D.frame.setVisible(false);
		}
		StdDraw3D.frame = new JFrame();
		StdDraw3D.frame.setVisible(false);
		StdDraw3D.frame.setResizable(StdDraw3D.fullscreen);
		StdDraw3D.frame.setDefaultCloseOperation(3);
		StdDraw3D.frame.setTitle("Standard Draw 3D");
		StdDraw3D.frame.add(StdDraw3D.canvasPanel);
		StdDraw3D.frame.setJMenuBar(StdDraw3D.createMenuBar());
		StdDraw3D.frame.addComponentListener(StdDraw3D.std);
		StdDraw3D.frame.addWindowFocusListener(StdDraw3D.std);
		StdDraw3D.frame.pack();
		StdDraw3D.rootGroup = StdDraw3D.createBranchGroup();
		StdDraw3D.lightGroup = StdDraw3D.createBranchGroup();
		StdDraw3D.bgGroup = StdDraw3D.createBranchGroup();
		StdDraw3D.soundGroup = StdDraw3D.createBranchGroup();
		StdDraw3D.fogGroup = StdDraw3D.createBranchGroup();
		StdDraw3D.appearanceGroup = StdDraw3D.createBranchGroup();
		StdDraw3D.onscreenGroup = StdDraw3D.createBranchGroup();
		StdDraw3D.offscreenGroup = StdDraw3D.createBranchGroup();
		StdDraw3D.rootGroup;
		StdDraw3D.onscreenGroup;
		throw new NoClassDefFoundError("javax.media.j3d.BranchGroup");
	}
	
	
	public static void setScale(double d1, double d2)
	{
		StdDraw3D.min = d1;
		StdDraw3D.max = d2;
		StdDraw3D.zoom = (StdDraw3D.max - StdDraw3D.min) / 2.0;
		double num = StdDraw3D.min + StdDraw3D.zoom;
		StdDraw3D.camera.setPosition(num, num, StdDraw3D.zoom * (2.0 + java.lang.Math.sqrt(2.0)));
		double num2 = 0.5 * StdDraw3D.zoom;
		StdDraw3D.orbit;
		num2;
		throw new NoClassDefFoundError("com.sun.j3d.utils.behaviors.vp.OrbitBehavior");
	}
	public static void setPenColor(Color c)
	{
		StdDraw3D.penColor = c;
	}
	public static void setPenRadius(double d)
	{
		StdDraw3D.penRadius = (float)d * 500f;
	}
	
	
	private static void infoDisplay()
	{
		if (!StdDraw3D.infoDisplay)
		{
			StdDraw3D.infoImage = StdDraw3D.createBufferedImage();
			return;
		}
		BufferedImage bufferedImage = StdDraw3D.createBufferedImage();
		Graphics2D graphics2D = (Graphics2D)bufferedImage.getGraphics();
		graphics2D.setFont(new Font("Courier", 0, 11));
		graphics2D.setStroke(new BasicStroke(1f, 1, 1));
		double num = (StdDraw3D.min + StdDraw3D.max) / 2.0;
		double arg_65_0 = StdDraw3D.zoom;
		double num2 = StdDraw3D.zoom * 0.10000000149011612;
		DecimalFormat decimalFormat = new DecimalFormat(" 0.000;-0.000");
		StdDraw3D.Vector3D position = StdDraw3D.camera.getPosition();
		string str = new StringBuilder().append("(").append(decimalFormat.format(position.__x)).append(",").append(decimalFormat.format(position.__y)).append(",").append(decimalFormat.format(position.__z)).append(")").toString();
		graphics2D.setColor(StdDraw3D.__BLACK);
		graphics2D.drawString(new StringBuilder().append("Position: ").append(str).toString(), 21, 26);
		graphics2D.setColor(StdDraw3D.__LIGHT_GRAY);
		graphics2D.drawString(new StringBuilder().append("Position: ").append(str).toString(), 20, 25);
		StdDraw3D.Vector3D orientation = StdDraw3D.camera.getOrientation();
		string str2 = new StringBuilder().append("(").append(decimalFormat.format(orientation.__x)).append(",").append(decimalFormat.format(orientation.__y)).append(",").append(decimalFormat.format(orientation.__z)).append(")").toString();
		graphics2D.setColor(StdDraw3D.__BLACK);
		graphics2D.drawString(new StringBuilder().append("Rotation: ").append(str2).toString(), 21, 41);
		graphics2D.setColor(StdDraw3D.__LIGHT_GRAY);
		graphics2D.drawString(new StringBuilder().append("Rotation: ").append(str2).toString(), 20, 40);
		string str3;
		if (StdDraw3D.cameraMode == 0)
		{
			str3 = "Camera: ORBIT_MODE";
		}
		else if (StdDraw3D.cameraMode == 1)
		{
			str3 = "Camera: FPS_MODE";
		}
		else if (StdDraw3D.cameraMode == 2)
		{
			str3 = "Camera: AIRPLANE_MODE";
		}
		else if (StdDraw3D.cameraMode == 3)
		{
			str3 = "Camera: LOOK_MODE";
		}
		else
		{
			if (StdDraw3D.cameraMode != 4)
			{
				string arg_293_0 = "Unknown camera mode!";
				
				throw new RuntimeException(arg_293_0);
			}
			str3 = "Camera: FIXED_MODE";
		}
		graphics2D.setColor(StdDraw3D.__BLACK);
		graphics2D.drawString(str3, 21, 56);
		graphics2D.setColor(StdDraw3D.__LIGHT_GRAY);
		graphics2D.drawString(str3, 20, 55);
		double num3 = num2 / 4.0;
		graphics2D.draw(new Line2D.Double((double)StdDraw3D.scaleX(num3 + num), (double)StdDraw3D.scaleY((double)0f + num), (double)StdDraw3D.scaleX(-num3 + num), (double)StdDraw3D.scaleY((double)0f + num)));
		graphics2D.draw(new Line2D.Double((double)StdDraw3D.scaleX((double)0f + num), (double)StdDraw3D.scaleY(num3 + num), (double)StdDraw3D.scaleX((double)0f + num), (double)StdDraw3D.scaleY(-num3 + num)));
		StdDraw3D.infoImage = bufferedImage;
	}
	
	public static bool mouse1Pressed()
	{
		int result;
		lock (StdDraw3D.mouseLock)
		{
			result = (StdDraw3D.mouse1 ? 1 : 0);
		}
		return result != 0;
	}
	
	public static bool mouse2Pressed()
	{
		int result;
		lock (StdDraw3D.mouseLock)
		{
			result = (StdDraw3D.mouse2 ? 1 : 0);
		}
		return result != 0;
	}
	
	public static bool mouse3Pressed()
	{
		int result;
		lock (StdDraw3D.mouseLock)
		{
			result = (StdDraw3D.mouse3 ? 1 : 0);
		}
		return result != 0;
	}
	private static double unscaleX(double num)
	{
		double num2 = (double)1f;
		if (StdDraw3D.width > StdDraw3D.height)
		{
			num2 = (double)1f / StdDraw3D.aspectRatio;
		}
		return (num * (2.0 * StdDraw3D.zoom) / (double)StdDraw3D.width + StdDraw3D.min) / num2;
	}
	private static double unscaleY(double num)
	{
		double num2 = (double)1f;
		if (StdDraw3D.height > StdDraw3D.width)
		{
			num2 = StdDraw3D.aspectRatio;
		}
		return (StdDraw3D.max - num * (2.0 * StdDraw3D.zoom) / (double)StdDraw3D.height) / num2;
	}
	
	
	private static void mouseMotionEvents(MouseEvent mouseEvent, double num, double num2, bool flag)
	{
		if (StdDraw3D.cameraMode == 4)
		{
			return;
		}
		if (StdDraw3D.cameraMode == 1)
		{
			if (flag || StdDraw3D.immersive)
			{
				StdDraw3D.camera.rotateFPS((StdDraw3D.mouseY - num2) / 4.0, (StdDraw3D.mouseX - num) / 4.0, (double)0f);
			}
			return;
		}
		if (StdDraw3D.cameraMode == 2)
		{
			if (flag || StdDraw3D.immersive)
			{
				StdDraw3D.camera.rotateRelative((StdDraw3D.mouseY - num2) / 4.0, (StdDraw3D.mouseX - num) / 4.0, (double)0f);
			}
			return;
		}
		if (StdDraw3D.cameraMode == 3)
		{
			if (flag || StdDraw3D.immersive)
			{
				StdDraw3D.camera.rotateFPS((StdDraw3D.mouseY - num2) / 4.0, (StdDraw3D.mouseX - num) / 4.0, (double)0f);
			}
			return;
		}
		if (StdDraw3D.cameraMode == 0 && flag && StdDraw3D.isKeyPressed(18))
		{
			StdDraw3D.view;
			throw new NoClassDefFoundError("javax.media.j3d.View");
		}
	}
	
	
	public static bool isKeyPressed(int i)
	{
		int result;
		lock (StdDraw3D.keyLock)
		{
			result = (StdDraw3D.keysDown.contains(Integer.valueOf(i)) ? 1 : 0);
		}
		return result != 0;
	}
	public static int getCameraMode()
	{
		return StdDraw3D.cameraMode;
	}
	
	
	public static void saveScene3D(string str)
	{
		new File(str);
		IOException ex;
		object obj;
		try
		{
			try
			{
				throw new NoClassDefFoundError("com.sun.j3d.utils.scenegraph.io.SceneGraphFileWriter");
			}
			catch (IOException arg_13_0)
			{
				ex = ByteCodeHelper.MapException<IOException>(arg_13_0, ByteCodeHelper.MapFlags.NoRemapping);
			}
		}
		catch (System.Exception arg_1C_0)
		{
			System.Exception expr_21 = ByteCodeHelper.MapException<System.Exception>(arg_1C_0, ByteCodeHelper.MapFlags.None);
			if (!ByteCodeHelper.DynamicInstanceOf(expr_21, typeof(StdDraw3D).TypeHandle, "com.sun.j3d.utils.scenegraph.io.UnsupportedUniverseException"))
			{
				throw;
			}
			obj = expr_21;
			goto IL_3B;
		}
		IOException @this = ex;
		Throwable.instancehelper_printStackTrace(@this);
		return;
		IL_3B:
		object obj2 = obj;
		obj2;
		throw new NoClassDefFoundError("com.sun.j3d.utils.scenegraph.io.UnsupportedUniverseException");
	}
	
	
	public static StdDraw3D.Shape model(string str)
	{
		return StdDraw3D.model(str, false);
	}
	
	
	public static void save(string str)
	{
		StdDraw3D.getCameraMode();
		StdDraw3D.setCameraMode(4);
		StdDraw3D.canvas;
		throw new NoClassDefFoundError("javax.media.j3d.Canvas3D");
	}
	
	private static object createBackground()
	{
		throw new NoClassDefFoundError("javax.media.j3d.Background");
	}
	
	private static void playAmbientSound(string text, double num, bool flag)
	{
		throw new NoClassDefFoundError("javax.media.j3d.MediaContainer");
	}
	
	public static void clearLight()
	{
		StdDraw3D.lightGroup;
		throw new NoClassDefFoundError("javax.media.j3d.BranchGroup");
	}
	
	public static StdDraw3D.Light directionalLight(double d1, double d2, double d3, Color c)
	{
		throw new NoClassDefFoundError("javax.media.j3d.DirectionalLight");
	}
	
	public static StdDraw3D.Light ambientLight(Color c)
	{
		throw new NoClassDefFoundError("javax.vecmath.Color3f");
	}
	
	private static object createTransformGroup()
	{
		throw new NoClassDefFoundError("javax.media.j3d.TransformGroup");
	}
	
	public static StdDraw3D.Light pointLight(double d1, double d2, double d3, Color c, double d4)
	{
		throw new NoClassDefFoundError("javax.media.j3d.PointLight");
	}
	
	
	public static void clear3D()
	{
		StdDraw3D.clear3D = true;
		StdDraw3D.offscreenGroup = StdDraw3D.createBranchGroup();
	}
	
	
	public static void clearOverlay()
	{
		StdDraw3D.clearOverlay = true;
		StdDraw3D.offscreenImage = StdDraw3D.createBufferedImage();
	}
	
	
	public static void clear()
	{
		StdDraw3D.clear3D();
		StdDraw3D.clearOverlay();
	}
	
	
	private static void moveEvents(int num)
	{
		StdDraw3D.infoDisplay();
		if (StdDraw3D.isKeyPressed(17))
		{
			return;
		}
		if (StdDraw3D.cameraMode == 1)
		{
			double num2 = 0.00015 * (double)num * StdDraw3D.zoom;
			if (StdDraw3D.isKeyPressed(87) || StdDraw3D.isKeyPressed(38))
			{
				StdDraw3D.camera.moveRelative((double)0f, (double)0f, num2 * 3.0);
			}
			if (StdDraw3D.isKeyPressed(83) || StdDraw3D.isKeyPressed(40))
			{
				StdDraw3D.camera.moveRelative((double)0f, (double)0f, -num2 * 3.0);
			}
			if (StdDraw3D.isKeyPressed(65) || StdDraw3D.isKeyPressed(37))
			{
				StdDraw3D.camera.moveRelative(-num2, (double)0f, (double)0f);
			}
			if (StdDraw3D.isKeyPressed(68) || StdDraw3D.isKeyPressed(39))
			{
				StdDraw3D.camera.moveRelative(num2, (double)0f, (double)0f);
			}
			if (StdDraw3D.isKeyPressed(81) || StdDraw3D.isKeyPressed(33))
			{
				StdDraw3D.camera.moveRelative((double)0f, num2, (double)0f);
			}
			if (StdDraw3D.isKeyPressed(69) || StdDraw3D.isKeyPressed(34))
			{
				StdDraw3D.camera.moveRelative((double)0f, -num2, (double)0f);
			}
		}
		if (StdDraw3D.cameraMode == 2)
		{
			double num2 = 0.00015 * (double)num * StdDraw3D.zoom;
			if (StdDraw3D.isKeyPressed(87) || StdDraw3D.isKeyPressed(38))
			{
				StdDraw3D.camera.moveRelative((double)0f, (double)0f, num2 * 3.0);
			}
			if (StdDraw3D.isKeyPressed(83) || StdDraw3D.isKeyPressed(40))
			{
				StdDraw3D.camera.moveRelative((double)0f, (double)0f, -num2 * 3.0);
			}
			if (StdDraw3D.isKeyPressed(65) || StdDraw3D.isKeyPressed(37))
			{
				StdDraw3D.camera.moveRelative(-num2, (double)0f, (double)0f);
			}
			if (StdDraw3D.isKeyPressed(68) || StdDraw3D.isKeyPressed(39))
			{
				StdDraw3D.camera.moveRelative(num2, (double)0f, (double)0f);
			}
			if (StdDraw3D.isKeyPressed(81) || StdDraw3D.isKeyPressed(33))
			{
				StdDraw3D.camera.rotateRelative((double)0f, (double)0f, num2 * 250.0 / StdDraw3D.zoom);
			}
			if (StdDraw3D.isKeyPressed(69) || StdDraw3D.isKeyPressed(34))
			{
				StdDraw3D.camera.rotateRelative((double)0f, (double)0f, -num2 * 250.0 / StdDraw3D.zoom);
			}
		}
	}
	
	
	public static void show(int i)
	{
		StdDraw3D.renderOverlay();
		StdDraw3D.render3D();
		StdDraw3D.pause(i);
	}
	
	
	private static void renderOverlay()
	{
		if (StdDraw3D.clearOverlay)
		{
			StdDraw3D.clearOverlay = false;
			StdDraw3D.onscreenImage = StdDraw3D.offscreenImage;
		}
		else
		{
			Graphics2D graphics2D = (Graphics2D)StdDraw3D.onscreenImage.getGraphics();
			graphics2D.drawRenderedImage(StdDraw3D.offscreenImage, new AffineTransform());
		}
		StdDraw3D.offscreenImage = StdDraw3D.createBufferedImage();
	}
	
	private static void render3D()
	{
		StdDraw3D.rootGroup;
		StdDraw3D.offscreenGroup;
		throw new NoClassDefFoundError("javax.media.j3d.BranchGroup");
	}
	
	
	public static void pause(int i)
	{
		int j = i;
		int num = 15;
		while (j > num)
		{
			StdDraw3D.moveEvents(num);
			Toolkit.getDefaultToolkit().sync();
			try
			{
				Thread.currentThread();
				Thread.sleep((long)num);
			}
			catch (InterruptedException arg_2A_0)
			{
				goto IL_2E;
			}
			IL_43:
			j -= num;
			continue;
			goto IL_43;
			IL_2E:
			System.@out.println("Error sleeping");
			goto IL_43;
		}
		StdDraw3D.moveEvents(j);
		if (j == 0)
		{
			return;
		}
		try
		{
			Thread.currentThread();
			Thread.sleep((long)j);
		}
		catch (InterruptedException arg_64_0)
		{
			goto IL_68;
		}
		return;
		IL_68:
		System.@out.println("Error sleeping");
	}
	
	
	public static void showOverlay(int i)
	{
		StdDraw3D.renderOverlay();
		StdDraw3D.pause(i);
	}
	
	
	public static void show3D(int i)
	{
		StdDraw3D.render3D();
		StdDraw3D.pause(i);
	}
	
	
	public static StdDraw3D.Shape sphere(double d1, double d2, double d3, double d4, double d5, double d6, double d7, string str)
	{
		StdDraw3D.createVector3f((double)0f, (double)0f, d4);
		throw new NoClassDefFoundError("com.sun.j3d.utils.geometry.Sphere");
	}
	
	
	private static object createAppearance(string text, bool flag)
	{
		StdDraw3D.createBlankAppearance();
		throw new NoClassDefFoundError("javax.media.j3d.PolygonAttributes");
	}
	
	private static StdDraw3D.Shape primitive(object obj, double num, double num2, double num3, object obj2, object obj3)
	{
		ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D).TypeHandle, "com.sun.j3d.utils.geometry.Primitive");
		ByteCodeHelper.DynamicCast(obj2, typeof(StdDraw3D).TypeHandle, "javax.vecmath.Vector3d");
		ByteCodeHelper.DynamicCast(obj3, typeof(StdDraw3D).TypeHandle, "javax.vecmath.Vector3d");
		obj;
		64;
		throw new NoClassDefFoundError("com.sun.j3d.utils.geometry.Primitive");
	}
	
	
	public static StdDraw3D.Shape wireSphere(double d1, double d2, double d3, double d4, double d5, double d6, double d7)
	{
		StdDraw3D.createVector3f((double)0f, (double)0f, d4);
		throw new NoClassDefFoundError("com.sun.j3d.utils.geometry.Sphere");
	}
	
	public static StdDraw3D.Shape ellipsoid(double d1, double d2, double d3, double d4, double d5, double d6, double d7, double d8, double d9, string str)
	{
		throw new NoClassDefFoundError("com.sun.j3d.utils.geometry.Sphere");
	}
	
	public static StdDraw3D.Shape wireEllipsoid(double d1, double d2, double d3, double d4, double d5, double d6, double d7, double d8, double d9)
	{
		throw new NoClassDefFoundError("com.sun.j3d.utils.geometry.Sphere");
	}
	
	
	public static StdDraw3D.Shape cube(double d1, double d2, double d3, double d4, double d5, double d6, double d7, string str)
	{
		return StdDraw3D.box(d1, d2, d3, d4, d4, d4, d5, d6, d7, str);
	}
	
	
	public static StdDraw3D.Shape box(double d1, double d2, double d3, double d4, double d5, double d6, double d7, double d8, double d9, string str)
	{
		StdDraw3D.createAppearance(str, true);
		StdDraw3D.createVector3f(d4, d5, d6);
		throw new NoClassDefFoundError("com.sun.j3d.utils.geometry.Box");
	}
	
	
	public static StdDraw3D.Shape wireBox(double d1, double d2, double d3, double d4, double d5, double d6, double d7, double d8, double d9)
	{
		StdDraw3D.createAppearance(null, false);
		StdDraw3D.createVector3f(d4, d5, d6);
		throw new NoClassDefFoundError("com.sun.j3d.utils.geometry.Box");
	}
	
	
	public static StdDraw3D.Shape lines(double[] darr1, double[] darr2, double[] darr3)
	{
		StdDraw3D.constructPoint3f(darr1, darr2, darr3);
		throw new NoClassDefFoundError("javax.media.j3d.LineStripArray");
	}
	
	
	public static StdDraw3D.Shape cylinder(double d1, double d2, double d3, double d4, double d5, double d6, double d7, double d8, string str)
	{
		StdDraw3D.createAppearance(str, true);
		StdDraw3D.createVector3f(d4, d5, (double)0f);
		throw new NoClassDefFoundError("com.sun.j3d.utils.geometry.Cylinder");
	}
	
	
	public static StdDraw3D.Shape wireCylinder(double d1, double d2, double d3, double d4, double d5, double d6, double d7, double d8)
	{
		StdDraw3D.createAppearance(null, false);
		StdDraw3D.createVector3f(d4, d5, (double)0f);
		throw new NoClassDefFoundError("com.sun.j3d.utils.geometry.Cylinder");
	}
	
	
	public static StdDraw3D.Shape cone(double d1, double d2, double d3, double d4, double d5, double d6, double d7, double d8, string str)
	{
		StdDraw3D.createAppearance(str, true);
		StdDraw3D.createVector3f(d4, d5, (double)0f);
		throw new NoClassDefFoundError("com.sun.j3d.utils.geometry.Cone");
	}
	
	
	public static StdDraw3D.Shape wireCone(double d1, double d2, double d3, double d4, double d5, double d6, double d7, double d8)
	{
		StdDraw3D.createAppearance(null, false);
		StdDraw3D.createVector3f(d4, d5, (double)0f);
		throw new NoClassDefFoundError("com.sun.j3d.utils.geometry.Cone");
	}
	
	
	public static StdDraw3D.Shape points(double[] darr1, double[] darr2, double[] darr3)
	{
		StdDraw3D.constructPoint3f(darr1, darr2, darr3);
		throw new NoClassDefFoundError("javax.media.j3d.PointArray");
	}
	
	private static object constructPoint3f(double[] array, double[] array2, double[] array3)
	{
		int num = array.Length;
		num;
		throw new NoClassDefFoundError("javax.vecmath.Point3f");
	}
	
	private static object createShape3D(object obj)
	{
		ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D).TypeHandle, "javax.media.j3d.Geometry");
		throw new NoClassDefFoundError("javax.media.j3d.Shape3D");
	}
	
	
	private static StdDraw3D.Shape shape(object obj)
	{
		ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D).TypeHandle, "javax.media.j3d.Shape3D");
		bool arg_17_0 = true;
		object arg_16_0 = null;
		bool flag = false;
		object obj2 = arg_16_0;
		bool flag2 = arg_17_0;
		return StdDraw3D.shape(obj, flag2, obj2, flag);
	}
	
	
	private static StdDraw3D.Shape customShape(object obj)
	{
		ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D).TypeHandle, "javax.media.j3d.Shape3D");
		bool arg_17_0 = true;
		object arg_16_0 = null;
		bool flag = true;
		object obj2 = arg_16_0;
		bool flag2 = arg_17_0;
		return StdDraw3D.shape(obj, flag2, obj2, flag);
	}
	
	
	public static StdDraw3D.Shape cylinder(double d1, double d2, double d3, double d4, double d5)
	{
		return StdDraw3D.cylinder(d1, d2, d3, d4, d5, (double)0f, (double)0f, (double)0f, null);
	}
	
	
	public static StdDraw3D.Shape combine(params StdDraw3D.Shape[] sddsarr)
	{
		StdDraw3D.createBranchGroup();
		throw new NoClassDefFoundError("javax.media.j3d.TransformGroup");
	}
	
	
	public static StdDraw3D.Shape tube(double d1, double d2, double d3, double d4, double d5, double d6, double d7)
	{
		StdDraw3D.Vector3D vector3D = new StdDraw3D.Vector3D(d1 + d4, d2 + d5, d3 + d6).times(0.5);
		StdDraw3D.Vector3D vector3D2 = new StdDraw3D.Vector3D(d4 - d1, d5 - d2, d6 - d3);
		StdDraw3D.Shape shape = StdDraw3D.cylinder(vector3D.__x, vector3D.__y, vector3D.__z, d7, vector3D2.mag());
		StdDraw3D.Vector3D sddvd = new StdDraw3D.Vector3D((double)0f, (double)1f, (double)0f);
		StdDraw3D.Vector3D sddvd2 = vector3D2.cross(sddvd);
		double num = vector3D2.angle(sddvd);
		shape.rotateAxis(sddvd2, -num);
		return StdDraw3D.combine(new StdDraw3D.Shape[]
		{
			shape
		});
	}
	
	
	public static StdDraw3D.Shape sphere(double d1, double d2, double d3, double d4)
	{
		return StdDraw3D.sphere(d1, d2, d3, d4, (double)0f, (double)0f, (double)0f, null);
	}
	
	
	private static StdDraw3D.Shape polygon(double[] array, double[] array2, double[] array3, bool flag)
	{
		StdDraw3D.constructPoint3f(array, array2, array3);
		throw new NoClassDefFoundError("javax.media.j3d.TriangleFanArray");
	}
	
	
	private static StdDraw3D.Shape wireShape(object obj)
	{
		ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D).TypeHandle, "javax.media.j3d.Shape3D");
		bool arg_17_0 = false;
		object arg_16_0 = null;
		bool flag = false;
		object obj2 = arg_16_0;
		bool flag2 = arg_17_0;
		return StdDraw3D.shape(obj, flag2, obj2, flag);
	}
	
	private static StdDraw3D.Shape triangles(double[][] array, bool flag)
	{
		int num = array.Length;
		num * 3;
		throw new NoClassDefFoundError("javax.vecmath.Point3f");
	}
	
	private static StdDraw3D.Shape triangles(double[][] array, Color[] array2, bool flag)
	{
		int num = array.Length;
		num * 3;
		throw new NoClassDefFoundError("javax.vecmath.Point3f");
	}
	
	
	public static StdDraw3D.Shape text3D(double d1, double d2, double d3, string str, double d4, double d5, double d6)
	{
		new Line2D.Double((double)0f, (double)0f, 1.5, (double)0f);
		throw new NoClassDefFoundError("javax.media.j3d.FontExtrusion");
	}
	
	
	private static StdDraw3D.Shape shape(object obj, bool flag, object obj2, bool flag2)
	{
		ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D).TypeHandle, "javax.media.j3d.Shape3D");
		ByteCodeHelper.DynamicCast(obj2, typeof(StdDraw3D).TypeHandle, "javax.media.j3d.Transform3D");
		object obj3;
		if (flag2)
		{
			obj3 = StdDraw3D.createCustomAppearance(flag);
		}
		else
		{
			obj3 = StdDraw3D.createAppearance(null, flag);
		}
		obj;
		obj3;
		throw new NoClassDefFoundError("javax.media.j3d.Shape3D");
	}
	
	
	private static Scanner createScanner(string text)
	{
		string charsetName = "ISO-8859-1";
		Locale locale = new Locale("en", "US");
		Scanner result;
		try
		{
			File file = new File(text);
			Scanner scanner;
			if (!file.exists())
			{
				URL uRL = new URL(text);
				URLConnection uRLConnection = uRL.openConnection();
				InputStream inputStream = uRLConnection.getInputStream();
				Scanner.__<clinit>();
				scanner = new Scanner(new BufferedInputStream(inputStream), charsetName);
				scanner.useLocale(locale);
				result = scanner;
				return result;
			}
			scanner = new Scanner(file, charsetName);
			scanner.useLocale(locale);
			result = scanner;
		}
		catch (IOException arg_78_0)
		{
			goto IL_81;
		}
		return result;
		IL_81:
		System.err.println(new StringBuilder().append("Could not open ").append(text).append(".").toString());
		return null;
	}
	
	
	public static StdDraw3D.Shape triangles(double[][] darr)
	{
		return StdDraw3D.triangles(darr, true);
	}
	
	
	public static StdDraw3D.Shape model(string str, bool b)
	{
		return StdDraw3D.model(str, false, b);
	}
	
	
	private static StdDraw3D.Shape model(string text, bool flag, bool flag2)
	{
		if (text == null)
		{
			return null;
		}
		string @this = java.lang.String.instancehelper_substring(text, java.lang.String.instancehelper_lastIndexOf(text, 46) + 1);
		java.lang.String.instancehelper_toLowerCase(@this);
		if (java.lang.String.instancehelper_equals(@this, "ply"))
		{
			return StdDraw3D.drawPLY(text, flag);
		}
		if (java.lang.String.instancehelper_equals(@this, "obj"))
		{
			return StdDraw3D.drawOBJ(text, flag, flag2);
		}
		string arg_5A_0 = "Format not supported!";
		
		throw new RuntimeException(arg_5A_0);
	}
	
	
	private static StdDraw3D.Shape drawPLY(string text, bool flag)
	{
		Scanner scanner = StdDraw3D.createScanner(text);
		int num = -1;
		int num2 = -1;
		int num3 = -1;
		while (true)
		{
			string @this = scanner.next();
			if (java.lang.String.instancehelper_equals(@this, "vertex"))
			{
				num = scanner.nextInt();
			}
			else if (java.lang.String.instancehelper_equals(@this, "face"))
			{
				num2 = scanner.nextInt();
			}
			else if (java.lang.String.instancehelper_equals(@this, "property"))
			{
				num3++;
				scanner.next();
				scanner.next();
			}
			else if (java.lang.String.instancehelper_equals(@this, "end_header"))
			{
				break;
			}
		}
		System.@out.println(new StringBuilder().append(num).append(" ").append(num2).append(" ").append(num3).toString());
		if (num == -1 || num2 == -1 || num3 == -1)
		{
			string arg_CA_0 = "Cannot read format of .ply file!";
			
			throw new RuntimeException(arg_CA_0);
		}
		int arg_E2_0 = num3;
		int arg_DA_0 = num;
		int[] array = new int[2];
		int num4 = arg_DA_0;
		array[1] = num4;
		num4 = arg_E2_0;
		array[0] = num4;
		double[][] array2 = (double[][])ByteCodeHelper.multianewarray(typeof(double[][]).TypeHandle, array);
		for (int i = 0; i < num; i++)
		{
			bool expr_108 = i != 0;
			int expr_10F = 10000;
			if (expr_10F == -1 || (expr_108 ? 1 : 0) % expr_10F == 0)
			{
				System.@out.println(new StringBuilder().append("vertex ").append(i).toString());
			}
			for (int j = 0; j < num3; j++)
			{
				array2[j][i] = scanner.nextDouble();
			}
		}
		int arg_17D_0 = num2;
		int arg_175_0 = 9;
		array = new int[2];
		num4 = arg_175_0;
		array[1] = num4;
		num4 = arg_17D_0;
		array[0] = num4;
		double[][] array3 = (double[][])ByteCodeHelper.multianewarray(typeof(double[][]).TypeHandle, array);
		for (int j = 0; j < num2; j++)
		{
			int num5 = scanner.nextInt();
			if (num5 != 3)
			{
				string arg_1BA_0 = "Only triangular faces supported!";
				
				throw new RuntimeException(arg_1BA_0);
			}
			bool expr_1C0 = j != 0;
			int expr_1C7 = 10000;
			if (expr_1C7 == -1 || (expr_1C0 ? 1 : 0) % expr_1C7 == 0)
			{
				System.@out.println(new StringBuilder().append("face ").append(j).toString());
			}
			int num6 = scanner.nextInt();
			array3[j][0] = array2[0][num6];
			array3[j][1] = array2[1][num6];
			array3[j][2] = array2[2][num6];
			num6 = scanner.nextInt();
			array3[j][3] = array2[0][num6];
			array3[j][4] = array2[1][num6];
			array3[j][5] = array2[2][num6];
			num6 = scanner.nextInt();
			array3[j][6] = array2[0][num6];
			array3[j][7] = array2[1][num6];
			array3[j][8] = array2[2][num6];
		}
		return StdDraw3D.triangles(array3);
	}
	
	private static StdDraw3D.Shape drawOBJ(string text, bool flag, bool flag2)
	{
		if (flag2)
		{
		}
		throw new NoClassDefFoundError("com.sun.j3d.loaders.objectfile.ObjectFile");
	}
	
	
	private static object createCustomAppearance(bool flag)
	{
		StdDraw3D.createBlankAppearance();
		throw new NoClassDefFoundError("javax.media.j3d.PolygonAttributes");
	}
	
	
	private static Graphics2D getGraphics2D(BufferedImage bufferedImage)
	{
		Graphics2D graphics2D = (Graphics2D)bufferedImage.getGraphics();
		graphics2D.setColor(StdDraw3D.penColor);
		graphics2D.setFont(StdDraw3D.font);
		BasicStroke stroke = new BasicStroke(StdDraw3D.penRadius, 1, 1);
		graphics2D.setStroke(stroke);
		graphics2D.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
		return graphics2D;
	}
	private static float scaleX(double num)
	{
		double num2 = (double)1f;
		if (StdDraw3D.width > StdDraw3D.height)
		{
			num2 = (double)1f / StdDraw3D.aspectRatio;
		}
		return (float)((double)StdDraw3D.width * (num * num2 - StdDraw3D.min) / (2.0 * StdDraw3D.zoom));
	}
	private static float scaleY(double num)
	{
		double num2 = (double)1f;
		if (StdDraw3D.height > StdDraw3D.width)
		{
			num2 = StdDraw3D.aspectRatio;
		}
		return (float)((double)StdDraw3D.height * (StdDraw3D.max - num * num2) / (2.0 * StdDraw3D.zoom));
	}
	
	
	public static void overlayPixel(double d1, double d2)
	{
		StdDraw3D.getGraphics2D(StdDraw3D.offscreenImage).fillRect(java.lang.Math.round(StdDraw3D.scaleX(d1)), java.lang.Math.round(StdDraw3D.scaleY(d2)), 1, 1);
	}
	private static double factorX(double num)
	{
		double num2 = (double)StdDraw3D.width;
		if (StdDraw3D.width > StdDraw3D.height)
		{
			num2 = (double)StdDraw3D.height;
		}
		return num2 * (num / (2.0 * StdDraw3D.zoom));
	}
	private static double factorY(double num)
	{
		double num2 = (double)StdDraw3D.height;
		if (StdDraw3D.height > StdDraw3D.width)
		{
			num2 = (double)StdDraw3D.width;
		}
		return num2 * (num / (2.0 * StdDraw3D.zoom));
	}
	
	
	private static Image getImage(string text)
	{
		ImageIcon imageIcon = new ImageIcon(text);
		if (imageIcon != null)
		{
			if (imageIcon.getImageLoadStatus() == 8)
			{
				goto IL_39;
			}
		}
		try
		{
			URL uRL = new URL(text);
			imageIcon = new ImageIcon(uRL);
		}
		catch (System.Exception arg_26_0)
		{
			if (ByteCodeHelper.MapException<java.lang.Exception>(arg_26_0, ByteCodeHelper.MapFlags.Unused) == null)
			{
				throw;
			}
		}
		IL_39:
		if (imageIcon == null || imageIcon.getImageLoadStatus() != 8)
		{
			URL uRL = ClassLiteral<StdDraw3D>.Value.getResource(text);
			if (uRL == null)
			{
				string arg_7D_0 = new StringBuilder().append("image ").append(text).append(" not found").toString();
				
				throw new RuntimeException(arg_7D_0);
			}
			imageIcon = new ImageIcon(uRL);
		}
		return imageIcon.getImage();
	}
	
	
	public static void setCameraPosition(StdDraw3D.Vector3D sddvd)
	{
		StdDraw3D.camera.setPosition(sddvd);
	}
	
	
	public static void setCameraOrientation(StdDraw3D.Vector3D sddvd)
	{
		StdDraw3D.camera.setOrientation(sddvd);
	}
	
	
	public static void setCameraDirection(StdDraw3D.Vector3D sddvd)
	{
		StdDraw3D.camera.setDirection(sddvd);
	}
	
	
	public static void overlaySquare(double d1, double d2, double d3)
	{
		if (d3 < (double)0f)
		{
			string arg_13_0 = "square side length can't be negative";
			
			throw new RuntimeException(arg_13_0);
		}
		double num = (double)StdDraw3D.scaleX(d1);
		double num2 = (double)StdDraw3D.scaleY(d2);
		double num3 = StdDraw3D.factorX(2.0 * d3);
		double num4 = StdDraw3D.factorY(2.0 * d3);
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			StdDraw3D.overlayPixel(d1, d2);
		}
		else
		{
			StdDraw3D.getGraphics2D(StdDraw3D.offscreenImage).draw(new Rectangle2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
		}
	}
	
	
	public static void setPenColor(Color c, int i)
	{
		Color.__<clinit>();
		StdDraw3D.setPenColor(new Color(c.getRed(), c.getGreen(), c.getBlue(), i));
	}
	
	
	public static void overlayCircle(double d1, double d2, double d3)
	{
		if (d3 < (double)0f)
		{
			string arg_13_0 = "circle radius can't be negative";
			
			throw new RuntimeException(arg_13_0);
		}
		double num = (double)StdDraw3D.scaleX(d1);
		double num2 = (double)StdDraw3D.scaleY(d2);
		double num3 = StdDraw3D.factorX(2.0 * d3);
		double num4 = StdDraw3D.factorY(2.0 * d3);
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			StdDraw3D.overlayPixel(d1, d2);
		}
		else
		{
			StdDraw3D.getGraphics2D(StdDraw3D.offscreenImage).draw(new Ellipse2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
		}
	}
	
	
	public static void overlayText(double d1, double d2, string str)
	{
		Graphics2D graphics2D = StdDraw3D.getGraphics2D(StdDraw3D.offscreenImage);
		FontMetrics fontMetrics = graphics2D.getFontMetrics();
		double num = (double)StdDraw3D.scaleX(d1);
		double num2 = (double)StdDraw3D.scaleY(d2);
		int num3 = fontMetrics.stringWidth(str);
		int descent = fontMetrics.getDescent();
		graphics2D.drawString(str, (float)(num - (double)num3 / 2.0), (float)(num2 + (double)descent));
	}
	public static void setFont(Font f)
	{
		StdDraw3D.font = f;
	}
	
	
	public static StdDraw3D.Shape text3D(double d1, double d2, double d3, string str)
	{
		return StdDraw3D.text3D(d1, d2, d3, str, (double)0f, (double)0f, (double)0f);
	}
	
	
	private StdDraw3D()
	{
	}
	
	
	public static void setCanvasSize(int i1, int i2)
	{
		StdDraw3D.setCanvasSize(i1, i2, false);
	}
	
	
	public virtual void stateChanged(ChangeEvent ce)
	{
		object source = ce.getSource();
		if (source == StdDraw3D.numDivSpinner)
		{
			StdDraw3D.numDivisions = ((Integer)StdDraw3D.numDivSpinner.getValue()).intValue();
		}
		if (source == StdDraw3D.fovSpinner)
		{
			StdDraw3D.setPerspectiveProjection(((java.lang.Double)StdDraw3D.fovSpinner.getValue()).doubleValue());
			StdDraw3D.perspectiveButton.setSelected(true);
		}
	}
	[Obsolete]
	
	public virtual void actionPerformed(ActionEvent ae)
	{
		object source = ae.getSource();
		if (source == StdDraw3D.saveButton)
		{
			StdDraw3D.saveAction();
		}
		else if (source == StdDraw3D.loadButton)
		{
			StdDraw3D.loadAction();
		}
		else if (source == StdDraw3D.save3DButton)
		{
			StdDraw3D.save3DAction();
		}
		else if (source == StdDraw3D.quitButton)
		{
			StdDraw3D.quitAction();
		}
		else if (source == StdDraw3D.orbitModeButton)
		{
			StdDraw3D.setCameraMode(0);
		}
		else if (source == StdDraw3D.fpsModeButton)
		{
			StdDraw3D.setCameraMode(1);
		}
		else if (source == StdDraw3D.airplaneModeButton)
		{
			StdDraw3D.setCameraMode(2);
		}
		else if (source == StdDraw3D.lookModeButton)
		{
			StdDraw3D.setCameraMode(3);
		}
		else if (source == StdDraw3D.fixedModeButton)
		{
			StdDraw3D.setCameraMode(4);
		}
		else if (source == StdDraw3D.perspectiveButton)
		{
			StdDraw3D.setPerspectiveProjection(((java.lang.Double)StdDraw3D.fovSpinner.getValue()).doubleValue());
		}
		else if (source == StdDraw3D.parallelButton)
		{
			StdDraw3D.setParallelProjection();
		}
		else if (source == StdDraw3D.antiAliasingButton)
		{
			StdDraw3D.setAntiAliasing(StdDraw3D.antiAliasingButton.isSelected());
		}
		else if (source == StdDraw3D.infoCheckBox)
		{
			StdDraw3D.setInfoDisplay(StdDraw3D.infoCheckBox.isSelected());
		}
	}
//[LineNumberTable(644), Obsolete]
	
	public virtual void componentHidden(ComponentEvent ce)
	{
		StdDraw3D.keysDown = new TreeSet();
	}
//[LineNumberTable(650), Obsolete]
	
	public virtual void componentMoved(ComponentEvent ce)
	{
		StdDraw3D.keysDown = new TreeSet();
	}
//[LineNumberTable(656), Obsolete]
	
	public virtual void componentShown(ComponentEvent ce)
	{
		StdDraw3D.keysDown = new TreeSet();
	}
//[LineNumberTable(662), Obsolete]
	
	public virtual void componentResized(ComponentEvent ce)
	{
		StdDraw3D.keysDown = new TreeSet();
	}
//[LineNumberTable(668), Obsolete]
	
	public virtual void windowGainedFocus(WindowEvent we)
	{
		StdDraw3D.keysDown = new TreeSet();
	}
//[LineNumberTable(674), Obsolete]
	
	public virtual void windowLostFocus(WindowEvent we)
	{
		StdDraw3D.keysDown = new TreeSet();
	}
	
	
	private static object createPoint3f(StdDraw3D.Vector3D vector3D)
	{
		return StdDraw3D.createPoint3f(vector3D.__x, vector3D.__y, vector3D.__z);
	}
	
	
	public static void setPenColor(int i1, int i2, int i3)
	{
		StdDraw3D.penColor = new Color(i1, i2, i3);
	}
	public static Color getPenColor()
	{
		return StdDraw3D.penColor;
	}
	public static float getPenRadius()
	{
		return StdDraw3D.penRadius / 500f;
	}
	public static Font getFont()
	{
		return StdDraw3D.font;
	}
	
	
	public static void fullscreen()
	{
		StdDraw3D.frame.setResizable(true);
		StdDraw3D.frame.setExtendedState(6);
		int num = StdDraw3D.frame.getSize().width;
		int num2 = StdDraw3D.frame.getSize().height;
		int num3 = StdDraw3D.frame.getInsets().top + StdDraw3D.frame.getInsets().bottom;
		int num4 = StdDraw3D.frame.getInsets().left + StdDraw3D.frame.getInsets().right;
		StdDraw3D.setCanvasSize(num - num4, num2 - num3 - StdDraw3D.menuBar.getHeight(), true);
		StdDraw3D.frame.setExtendedState(6);
	}
	
	
	public static bool getAntiAliasing()
	{
		return StdDraw3D.antiAliasingButton.isSelected();
	}
	public static void setNumDivisions(int i)
	{
		StdDraw3D.numDivisions = i;
	}
	public static int getNumDivisions()
	{
		return StdDraw3D.numDivisions;
	}
	
	public static void setOrbitCenter(double d1, double d2, double d3)
	{
		throw new NoClassDefFoundError("javax.vecmath.Point3d");
	}
	
	public static void setOrbitCenter(StdDraw3D.Vector3D sddvd)
	{
		throw new NoClassDefFoundError("javax.vecmath.Point3d");
	}
	
	
	public static StdDraw3D.Vector3D getOrbitCenter()
	{
		object arg_08_0 = StdDraw3D.orbitCenter;
		object obj = null;
		return new StdDraw3D.Vector3D(arg_08_0, obj);
	}
	
	
	public static bool mousePressed()
	{
		int result;
		lock (StdDraw3D.mouseLock)
		{
			result = ((!StdDraw3D.mouse1Pressed() && !StdDraw3D.mouse2Pressed() && !StdDraw3D.mouse3Pressed()) ? 0 : 1);
		}
		return result != 0;
	}
	
	
	public static double mouseX()
	{
		double result;
		lock (StdDraw3D.mouseLock)
		{
			result = StdDraw3D.unscaleX(StdDraw3D.mouseX);
		}
		return result;
	}
	
	
	public static double mouseY()
	{
		double result;
		lock (StdDraw3D.mouseLock)
		{
			result = StdDraw3D.unscaleY(StdDraw3D.mouseY);
		}
		return result;
	}
	[Obsolete]
	public virtual void mouseClicked(MouseEvent me)
	{
	}
	[Obsolete]
	public virtual void mouseEntered(MouseEvent me)
	{
	}
	[Obsolete]
	public virtual void mouseExited(MouseEvent me)
	{
	}
	[Obsolete]
	
	public virtual void mousePressed(MouseEvent me)
	{
		lock (StdDraw3D.mouseLock)
		{
			StdDraw3D.mouseX = (double)me.getX();
			StdDraw3D.mouseY = (double)me.getY();
			if (me.getButton() == 1)
			{
				StdDraw3D.mouse1 = true;
			}
			if (me.getButton() == 2)
			{
				StdDraw3D.mouse2 = true;
			}
			if (me.getButton() == 3)
			{
				StdDraw3D.mouse3 = true;
			}
		}
	}
	[Obsolete]
	
	public virtual void mouseReleased(MouseEvent me)
	{
		lock (StdDraw3D.mouseLock)
		{
			if (me.getButton() == 1)
			{
				StdDraw3D.mouse1 = false;
			}
			if (me.getButton() == 2)
			{
				StdDraw3D.mouse2 = false;
			}
			if (me.getButton() == 3)
			{
				StdDraw3D.mouse3 = false;
			}
		}
	}
	[Obsolete]
	
	public virtual void mouseDragged(MouseEvent me)
	{
		lock (StdDraw3D.mouseLock)
		{
			StdDraw3D.mouseMotionEvents(me, (double)me.getX(), (double)me.getY(), true);
			StdDraw3D.mouseX = (double)me.getX();
			StdDraw3D.mouseY = (double)me.getY();
		}
	}
	[Obsolete]
	
	public virtual void mouseMoved(MouseEvent me)
	{
		lock (StdDraw3D.mouseLock)
		{
			StdDraw3D.mouseMotionEvents(me, (double)me.getX(), (double)me.getY(), false);
		}
	}
	[Obsolete]
	
	public virtual void mouseWheelMoved(MouseWheelEvent mwe)
	{
		double arg_07_0 = (double)mwe.getWheelRotation();
		if (StdDraw3D.cameraMode == 0)
		{
			StdDraw3D.view;
			throw new NoClassDefFoundError("javax.media.j3d.View");
		}
	}
	
	
	public static bool hasNextKeyTyped()
	{
		int result;
		lock (StdDraw3D.keyLock)
		{
			result = (StdDraw3D.keysTyped.IsEmpty ? 0 : 1);
		}
		return result != 0;
	}
	
	
	public static char nextKeyTyped()
	{
		int result;
		lock (StdDraw3D.keyLock)
		{
			result = (int)((Character)StdDraw3D.keysTyped.removeLast()).charValue();
		}
		return (char)result;
	}
	[Obsolete]
	
	public virtual void keyTyped(KeyEvent ke)
	{
		lock (StdDraw3D.keyLock)
		{
			int keyChar = (int)ke.getKeyChar();
			StdDraw3D.keysTyped.addFirst(Character.valueOf((char)keyChar));
			if (keyChar == 96)
			{
				int expr_2E = StdDraw3D.getCameraMode() + 1;
				int expr_30 = 5;
				StdDraw3D.setCameraMode((expr_30 != -1) ? (expr_2E % expr_30) : 0);
			}
		}
	}
	[Obsolete]
	
	public virtual void keyPressed(KeyEvent ke)
	{
		lock (StdDraw3D.keyLock)
		{
			StdDraw3D.keysDown.add(Integer.valueOf(ke.getKeyCode()));
		}
	}
	[Obsolete]
	
	public virtual void keyReleased(KeyEvent ke)
	{
		lock (StdDraw3D.keyLock)
		{
			StdDraw3D.keysDown.remove(Integer.valueOf(ke.getKeyCode()));
		}
	}
	
	public static void setBackground(string str)
	{
		StdDraw3D.rootGroup;
		StdDraw3D.bgGroup;
		throw new NoClassDefFoundError("javax.media.j3d.BranchGroup");
	}
	
	public static void setBackgroundSphere(string str)
	{
		throw new NoClassDefFoundError("com.sun.j3d.utils.geometry.Sphere");
	}
	
	public static void clearSound()
	{
		StdDraw3D.soundGroup;
		throw new NoClassDefFoundError("javax.media.j3d.BranchGroup");
	}
	
	
	public static void playAmbientSound(string str)
	{
		StdDraw3D.playAmbientSound(str, (double)1f, false);
	}
	
	
	public static void playAmbientSound(string str, bool b)
	{
		StdDraw3D.playAmbientSound(str, (double)1f, b);
	}
	
	public static void clearFog()
	{
		StdDraw3D.fogGroup;
		throw new NoClassDefFoundError("javax.media.j3d.BranchGroup");
	}
	
	public static void addFog(Color c, double d1, double d2)
	{
		throw new NoClassDefFoundError("javax.media.j3d.LinearFog");
	}
	
	
	public static StdDraw3D.Light directionalLight(StdDraw3D.Vector3D sddvd, Color c)
	{
		return StdDraw3D.directionalLight(sddvd.__x, sddvd.__y, sddvd.__z, c);
	}
	
	
	public static StdDraw3D.Light pointLight(StdDraw3D.Vector3D sddvd, Color c)
	{
		return StdDraw3D.pointLight(sddvd.__x, sddvd.__y, sddvd.__z, c, (double)1f);
	}
	
	
	public static StdDraw3D.Light pointLight(double d1, double d2, double d3, Color c)
	{
		return StdDraw3D.pointLight(d1, d2, d3, c, (double)1f);
	}
	
	
	public static StdDraw3D.Light pointLight(StdDraw3D.Vector3D sddvd, Color c, double d)
	{
		return StdDraw3D.pointLight(sddvd.__x, sddvd.__y, sddvd.__z, c, d);
	}
	
	
	public static Color randomColor()
	{
		Color.__<clinit>();
		return new Color(new java.util.Random().nextInt());
	}
	
	
	public static Color randomRainbowColor()
	{
		return Color.getHSBColor((float)java.lang.Math.random(), 1f, 1f);
	}
	
	
	public static StdDraw3D.Vector3D randomDirection()
	{
		double a = java.lang.Math.random() * 3.1415926535897931 * 2.0;
		double a2 = java.lang.Math.random() * 3.1415926535897931;
		return new StdDraw3D.Vector3D(java.lang.Math.cos(a) * java.lang.Math.sin(a2), java.lang.Math.sin(a) * java.lang.Math.sin(a2), java.lang.Math.cos(a2));
	}
	
	
	public static void clear(Color c)
	{
		StdDraw3D.setBackground(c);
		StdDraw3D.clear();
	}
	
	
	public static void finished()
	{
		StdDraw3D.show(1000000000);
	}
	
	
	public static void show()
	{
		StdDraw3D.show(0);
	}
	
	
	public static void showOverlay()
	{
		StdDraw3D.showOverlay(0);
	}
	
	
	public static void show3D()
	{
		StdDraw3D.show3D(0);
	}
	
	
	public static StdDraw3D.Shape sphere(double d1, double d2, double d3, double d4, double d5, double d6, double d7)
	{
		return StdDraw3D.sphere(d1, d2, d3, d4, d5, d6, d7, null);
	}
	
	
	public static StdDraw3D.Shape sphere(double d1, double d2, double d3, double d4, string str)
	{
		return StdDraw3D.sphere(d1, d2, d3, d4, (double)0f, (double)0f, (double)0f, str);
	}
	
	
	public static StdDraw3D.Shape wireSphere(double d1, double d2, double d3, double d4)
	{
		return StdDraw3D.wireSphere(d1, d2, d3, d4, (double)0f, (double)0f, (double)0f);
	}
	
	
	public static StdDraw3D.Shape ellipsoid(double d1, double d2, double d3, double d4, double d5, double d6)
	{
		return StdDraw3D.ellipsoid(d1, d2, d3, d4, d5, d6, (double)0f, (double)0f, (double)0f, null);
	}
	
	
	public static StdDraw3D.Shape ellipsoid(double d1, double d2, double d3, double d4, double d5, double d6, double d7, double d8, double d9)
	{
		return StdDraw3D.ellipsoid(d1, d2, d3, d4, d5, d6, d7, d8, d9, null);
	}
	
	
	public static StdDraw3D.Shape ellipsoid(double d1, double d2, double d3, double d4, double d5, double d6, string str)
	{
		return StdDraw3D.ellipsoid(d1, d2, d3, d4, d5, d6, (double)0f, (double)0f, (double)0f, str);
	}
	
	
	public static StdDraw3D.Shape wireEllipsoid(double d1, double d2, double d3, double d4, double d5, double d6)
	{
		return StdDraw3D.wireEllipsoid(d1, d2, d3, d4, d5, d6, (double)0f, (double)0f, (double)0f);
	}
	
	
	public static StdDraw3D.Shape cube(double d1, double d2, double d3, double d4)
	{
		return StdDraw3D.cube(d1, d2, d3, d4, (double)0f, (double)0f, (double)0f, null);
	}
	
	
	public static StdDraw3D.Shape cube(double d1, double d2, double d3, double d4, double d5, double d6, double d7)
	{
		return StdDraw3D.cube(d1, d2, d3, d4, d5, d6, d7, null);
	}
	
	
	public static StdDraw3D.Shape cube(double d1, double d2, double d3, double d4, string str)
	{
		return StdDraw3D.cube(d1, d2, d3, d4, (double)0f, (double)0f, (double)0f, str);
	}
	
	
	public static StdDraw3D.Shape wireCube(double d1, double d2, double d3, double d4, double d5, double d6, double d7)
	{
		return StdDraw3D.wireBox(d1, d2, d3, d4, d4, d4, (double)0f, (double)0f, (double)0f);
	}
	
	
	public static StdDraw3D.Shape wireCube(double d1, double d2, double d3, double d4)
	{
		double[] darr = new double[]
		{
			d1 + d4,
			d1 + d4,
			d1 - d4,
			d1 - d4,
			d1 + d4,
			d1 + d4,
			d1 + d4,
			d1 - d4,
			d1 - d4,
			d1 + d4,
			d1 + d4,
			d1 + d4,
			d1 - d4,
			d1 - d4,
			d1 - d4,
			d1 - d4
		};
		double[] darr2 = new double[]
		{
			d2 + d4,
			d2 - d4,
			d2 - d4,
			d2 + d4,
			d2 + d4,
			d2 + d4,
			d2 - d4,
			d2 - d4,
			d2 + d4,
			d2 + d4,
			d2 - d4,
			d2 - d4,
			d2 - d4,
			d2 - d4,
			d2 + d4,
			d2 + d4
		};
		double[] darr3 = new double[]
		{
			d3 + d4,
			d3 + d4,
			d3 + d4,
			d3 + d4,
			d3 + d4,
			d3 - d4,
			d3 - d4,
			d3 - d4,
			d3 - d4,
			d3 - d4,
			d3 - d4,
			d3 + d4,
			d3 + d4,
			d3 - d4,
			d3 - d4,
			d3 + d4
		};
		return StdDraw3D.lines(darr, darr2, darr3);
	}
	
	
	public static StdDraw3D.Shape box(double d1, double d2, double d3, double d4, double d5, double d6)
	{
		return StdDraw3D.box(d1, d2, d3, d4, d5, d6, (double)0f, (double)0f, (double)0f, null);
	}
	
	
	public static StdDraw3D.Shape box(double d1, double d2, double d3, double d4, double d5, double d6, double d7, double d8, double d9)
	{
		return StdDraw3D.box(d1, d2, d3, d4, d5, d6, d7, d8, d9, null);
	}
	
	
	public static StdDraw3D.Shape box(double d1, double d2, double d3, double d4, double d5, double d6, string str)
	{
		return StdDraw3D.box(d1, d2, d3, d4, d5, d6, (double)0f, (double)0f, (double)0f, str);
	}
	
	
	public static StdDraw3D.Shape wireBox(double d1, double d2, double d3, double d4, double d5, double d6)
	{
		return StdDraw3D.wireBox(d1, d2, d3, d4, d5, d6, (double)0f, (double)0f, (double)0f);
	}
	
	
	public static StdDraw3D.Shape cylinder(double d1, double d2, double d3, double d4, double d5, double d6, double d7, double d8)
	{
		return StdDraw3D.cylinder(d1, d2, d3, d4, d5, d6, d7, d8, null);
	}
	
	
	public static StdDraw3D.Shape cylinder(double d1, double d2, double d3, double d4, double d5, string str)
	{
		return StdDraw3D.cylinder(d1, d2, d3, d4, d5, (double)0f, (double)0f, (double)0f, str);
	}
	
	
	public static StdDraw3D.Shape wireCylinder(double d1, double d2, double d3, double d4, double d5)
	{
		return StdDraw3D.wireCylinder(d1, d2, d3, d4, d5, (double)0f, (double)0f, (double)0f);
	}
	
	
	public static StdDraw3D.Shape cone(double d1, double d2, double d3, double d4, double d5)
	{
		return StdDraw3D.cone(d1, d2, d3, d4, d5, (double)0f, (double)0f, (double)0f, null);
	}
	
	
	public static StdDraw3D.Shape cone(double d1, double d2, double d3, double d4, double d5, double d6, double d7, double d8)
	{
		return StdDraw3D.cone(d1, d2, d3, d4, d5, d6, d7, d8, null);
	}
	
	
	public static StdDraw3D.Shape cone(double d1, double d2, double d3, double d4, double d5, string str)
	{
		return StdDraw3D.cone(d1, d2, d3, d4, d5, (double)0f, (double)0f, (double)0f, str);
	}
	
	
	public static StdDraw3D.Shape wireCone(double d1, double d2, double d3, double d4, double d5)
	{
		return StdDraw3D.wireCone(d1, d2, d3, d4, d5, (double)0f, (double)0f, (double)0f);
	}
	
	
	public static StdDraw3D.Shape point(double d1, double d2, double d3)
	{
		return StdDraw3D.points(new double[]
		{
			d1
		}, new double[]
		{
			d2
		}, new double[]
		{
			d3
		});
	}
	
	
	public static StdDraw3D.Shape points(double[] darr1, double[] darr2, double[] darr3, Color[] carr)
	{
		StdDraw3D.constructPoint3f(darr1, darr2, darr3);
		throw new NoClassDefFoundError("javax.media.j3d.PointArray");
	}
	
	
	public static StdDraw3D.Shape line(double d1, double d2, double d3, double d4, double d5, double d6)
	{
		return StdDraw3D.lines(new double[]
		{
			d1,
			d4
		}, new double[]
		{
			d2,
			d5
		}, new double[]
		{
			d3,
			d6
		});
	}
	
	
	public static StdDraw3D.Shape lines(double[] darr1, double[] darr2, double[] darr3, Color[] carr)
	{
		StdDraw3D.constructPoint3f(darr1, darr2, darr3);
		throw new NoClassDefFoundError("javax.media.j3d.LineStripArray");
	}
	
	
	public static StdDraw3D.Shape tubes(double[] darr1, double[] darr2, double[] darr3, double d)
	{
		StdDraw3D.Shape[] array = new StdDraw3D.Shape[(darr1.Length - 1) * 2];
		for (int i = 0; i < darr1.Length - 1; i++)
		{
			array[i] = StdDraw3D.tube(darr1[i], darr2[i], darr3[i], darr1[i + 1], darr2[i + 1], darr3[i + 1], d);
			array[i + darr1.Length - 1] = StdDraw3D.sphere(darr1[i + 1], darr2[i + 1], darr3[i + 1], d);
		}
		return StdDraw3D.combine(array);
	}
	
	
	public static StdDraw3D.Shape tubes(double[] darr1, double[] darr2, double[] darr3, double d, Color[] carr)
	{
		StdDraw3D.Shape[] array = new StdDraw3D.Shape[(darr1.Length - 1) * 2];
		for (int i = 0; i < darr1.Length - 1; i++)
		{
			StdDraw3D.setPenColor(carr[i]);
			array[i] = StdDraw3D.tube(darr1[i], darr2[i], darr3[i], darr1[i + 1], darr2[i + 1], darr3[i + 1], d);
			array[i + darr1.Length - 1] = StdDraw3D.sphere(darr1[i + 1], darr2[i + 1], darr3[i + 1], d);
		}
		return StdDraw3D.combine(array);
	}
	
	
	public static StdDraw3D.Shape polygon(double[] darr1, double[] darr2, double[] darr3)
	{
		return StdDraw3D.polygon(darr1, darr2, darr3, true);
	}
	
	
	public static StdDraw3D.Shape wirePolygon(double[] darr1, double[] darr2, double[] darr3)
	{
		return StdDraw3D.polygon(darr1, darr2, darr3, false);
	}
	
	
	public static StdDraw3D.Shape wireTriangles(double[][] darr)
	{
		return StdDraw3D.triangles(darr, false);
	}
	
	
	public static StdDraw3D.Shape triangles(double[][] darr, Color[] carr)
	{
		return StdDraw3D.triangles(darr, carr, true);
	}
	
	
	public static StdDraw3D.Shape wireTriangles(double[][] darr, Color[] carr)
	{
		return StdDraw3D.triangles(darr, carr, false);
	}
	
	private static StdDraw3D.Shape drawLWS(string text)
	{
		throw new NoClassDefFoundError("com.sun.j3d.loaders.lw3d.Lw3dLoader");
	}
	
	
	public static StdDraw3D.Shape coloredModel(string str)
	{
		return StdDraw3D.model(str, true, true);
	}
	
	
	public static StdDraw3D.Shape coloredModel(string str, bool b)
	{
		return StdDraw3D.model(str, true, b);
	}
	
	
	private static StdDraw3D.Shape customWireShape(object obj)
	{
		ByteCodeHelper.DynamicCast(obj, typeof(StdDraw3D).TypeHandle, "javax.media.j3d.Shape3D");
		bool arg_17_0 = false;
		object arg_16_0 = null;
		bool flag = true;
		object obj2 = arg_16_0;
		bool flag2 = arg_17_0;
		return StdDraw3D.shape(obj, flag2, obj2, flag);
	}
	
	
	public static void overlayPoint(double d1, double d2)
	{
		float num = StdDraw3D.penRadius;
		if (num <= 1f)
		{
			StdDraw3D.overlayPixel(d1, d2);
		}
		else
		{
			StdDraw3D.getGraphics2D(StdDraw3D.offscreenImage).fill(new Ellipse2D.Double((double)(StdDraw3D.scaleX(d1) - num / 2f), (double)(StdDraw3D.scaleY(d2) - num / 2f), (double)num, (double)num));
		}
	}
	
	
	public static void overlayLine(double d1, double d2, double d3, double d4)
	{
		StdDraw3D.getGraphics2D(StdDraw3D.offscreenImage).draw(new Line2D.Double((double)StdDraw3D.scaleX(d1), (double)StdDraw3D.scaleY(d2), (double)StdDraw3D.scaleX(d3), (double)StdDraw3D.scaleY(d4)));
	}
	
	
	public static void overlayFilledCircle(double d1, double d2, double d3)
	{
		if (d3 < (double)0f)
		{
			string arg_13_0 = "circle radius can't be negative";
			
			throw new RuntimeException(arg_13_0);
		}
		double num = (double)StdDraw3D.scaleX(d1);
		double num2 = (double)StdDraw3D.scaleY(d2);
		double num3 = StdDraw3D.factorX(2.0 * d3);
		double num4 = StdDraw3D.factorY(2.0 * d3);
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			StdDraw3D.overlayPixel(d1, d2);
		}
		else
		{
			StdDraw3D.getGraphics2D(StdDraw3D.offscreenImage).fill(new Ellipse2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
		}
	}
	
	
	public static void overlayEllipse(double d1, double d2, double d3, double d4)
	{
		if (d3 < (double)0f)
		{
			string arg_13_0 = "ellipse semimajor axis can't be negative";
			
			throw new RuntimeException(arg_13_0);
		}
		if (d4 < (double)0f)
		{
			string arg_2C_0 = "ellipse semiminor axis can't be negative";
			
			throw new RuntimeException(arg_2C_0);
		}
		double num = (double)StdDraw3D.scaleX(d1);
		double num2 = (double)StdDraw3D.scaleY(d2);
		double num3 = StdDraw3D.factorX(2.0 * d3);
		double num4 = StdDraw3D.factorY(2.0 * d4);
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			StdDraw3D.overlayPixel(d1, d2);
		}
		else
		{
			StdDraw3D.getGraphics2D(StdDraw3D.offscreenImage).draw(new Ellipse2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
		}
	}
	
	
	public static void overlayFilledEllipse(double d1, double d2, double d3, double d4)
	{
		if (d3 < (double)0f)
		{
			string arg_13_0 = "ellipse semimajor axis can't be negative";
			
			throw new RuntimeException(arg_13_0);
		}
		if (d4 < (double)0f)
		{
			string arg_2C_0 = "ellipse semiminor axis can't be negative";
			
			throw new RuntimeException(arg_2C_0);
		}
		double num = (double)StdDraw3D.scaleX(d1);
		double num2 = (double)StdDraw3D.scaleY(d2);
		double num3 = StdDraw3D.factorX(2.0 * d3);
		double num4 = StdDraw3D.factorY(2.0 * d4);
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			StdDraw3D.overlayPixel(d1, d2);
		}
		else
		{
			StdDraw3D.getGraphics2D(StdDraw3D.offscreenImage).fill(new Ellipse2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
		}
	}
	
	
	public static void overlayArc(double d1, double d2, double d3, double d4, double d5)
	{
		if (d3 < (double)0f)
		{
			string arg_13_0 = "arc radius can't be negative";
			
			throw new RuntimeException(arg_13_0);
		}
		while (d5 < d4)
		{
			d5 += 360.0;
		}
		double num = (double)StdDraw3D.scaleX(d1);
		double num2 = (double)StdDraw3D.scaleY(d2);
		double num3 = StdDraw3D.factorX(2.0 * d3);
		double num4 = StdDraw3D.factorY(2.0 * d3);
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			StdDraw3D.overlayPixel(d1, d2);
		}
		else
		{
			StdDraw3D.getGraphics2D(StdDraw3D.offscreenImage).draw(new Arc2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4, d4, d5 - d4, 0));
		}
	}
	
	
	public static void overlayFilledSquare(double d1, double d2, double d3)
	{
		if (d3 < (double)0f)
		{
			string arg_13_0 = "square side length can't be negative";
			
			throw new RuntimeException(arg_13_0);
		}
		double num = (double)StdDraw3D.scaleX(d1);
		double num2 = (double)StdDraw3D.scaleY(d2);
		double num3 = StdDraw3D.factorX(2.0 * d3);
		double num4 = StdDraw3D.factorY(2.0 * d3);
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			StdDraw3D.overlayPixel(d1, d2);
		}
		else
		{
			StdDraw3D.getGraphics2D(StdDraw3D.offscreenImage).fill(new Rectangle2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
		}
	}
	
	
	public static void overlayRectangle(double d1, double d2, double d3, double d4)
	{
		if (d3 < (double)0f)
		{
			string arg_13_0 = "half width can't be negative";
			
			throw new RuntimeException(arg_13_0);
		}
		if (d4 < (double)0f)
		{
			string arg_2C_0 = "half height can't be negative";
			
			throw new RuntimeException(arg_2C_0);
		}
		double num = (double)StdDraw3D.scaleX(d1);
		double num2 = (double)StdDraw3D.scaleY(d2);
		double num3 = StdDraw3D.factorX(2.0 * d3);
		double num4 = StdDraw3D.factorY(2.0 * d4);
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			StdDraw3D.overlayPixel(d1, d2);
		}
		else
		{
			StdDraw3D.getGraphics2D(StdDraw3D.offscreenImage).draw(new Rectangle2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
		}
	}
	
	
	public static void overlayFilledRectangle(double d1, double d2, double d3, double d4)
	{
		if (d3 < (double)0f)
		{
			string arg_13_0 = "half width can't be negative";
			
			throw new RuntimeException(arg_13_0);
		}
		if (d4 < (double)0f)
		{
			string arg_2C_0 = "half height can't be negative";
			
			throw new RuntimeException(arg_2C_0);
		}
		double num = (double)StdDraw3D.scaleX(d1);
		double num2 = (double)StdDraw3D.scaleY(d2);
		double num3 = StdDraw3D.factorX(2.0 * d3);
		double num4 = StdDraw3D.factorY(2.0 * d4);
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			StdDraw3D.overlayPixel(d1, d2);
		}
		else
		{
			StdDraw3D.getGraphics2D(StdDraw3D.offscreenImage).fill(new Rectangle2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
		}
	}
	
	
	public static void overlayPolygon(double[] darr1, double[] darr2)
	{
		int num = darr1.Length;
		GeneralPath generalPath = new GeneralPath();
		generalPath.moveTo(StdDraw3D.scaleX(darr1[0]), StdDraw3D.scaleY(darr2[0]));
		for (int i = 0; i < num; i++)
		{
			generalPath.lineTo(StdDraw3D.scaleX(darr1[i]), StdDraw3D.scaleY(darr2[i]));
		}
		generalPath.closePath();
		StdDraw3D.getGraphics2D(StdDraw3D.offscreenImage).draw(generalPath);
	}
	
	
	public static void overlayFilledPolygon(double[] darr1, double[] darr2)
	{
		int num = darr1.Length;
		GeneralPath generalPath = new GeneralPath();
		generalPath.moveTo(StdDraw3D.scaleX(darr1[0]), StdDraw3D.scaleY(darr2[0]));
		for (int i = 0; i < num; i++)
		{
			generalPath.lineTo(StdDraw3D.scaleX(darr1[i]), StdDraw3D.scaleY(darr2[i]));
		}
		generalPath.closePath();
		StdDraw3D.getGraphics2D(StdDraw3D.offscreenImage).fill(generalPath);
	}
	
	
	public static void overlayText(double d1, double d2, string str, double d3)
	{
		Graphics2D graphics2D = StdDraw3D.getGraphics2D(StdDraw3D.offscreenImage);
		FontMetrics fontMetrics = graphics2D.getFontMetrics();
		double num = (double)StdDraw3D.scaleX(d1);
		double num2 = (double)StdDraw3D.scaleY(d2);
		int num3 = fontMetrics.stringWidth(str);
		int descent = fontMetrics.getDescent();
		graphics2D.rotate(java.lang.Math.toRadians(-d3), num, num2);
		graphics2D.drawString(str, (float)(num - (double)num3 / 2.0), (float)(num2 + (double)descent));
		graphics2D.rotate(java.lang.Math.toRadians(d3), num, num2);
	}
	
	
	public static void overlayTextLeft(double d1, double d2, string str)
	{
		Graphics2D graphics2D = StdDraw3D.getGraphics2D(StdDraw3D.offscreenImage);
		FontMetrics fontMetrics = graphics2D.getFontMetrics();
		double num = (double)StdDraw3D.scaleX(d1);
		double num2 = (double)StdDraw3D.scaleY(d2);
		fontMetrics.stringWidth(str);
		int descent = fontMetrics.getDescent();
		graphics2D.drawString(str, (float)num, (float)(num2 + (double)descent));
	}
	
	
	public static void overlayTextRight(double d1, double d2, string str)
	{
		Graphics2D graphics2D = StdDraw3D.getGraphics2D(StdDraw3D.offscreenImage);
		FontMetrics fontMetrics = graphics2D.getFontMetrics();
		double num = (double)StdDraw3D.scaleX(d1);
		double num2 = (double)StdDraw3D.scaleY(d2);
		int num3 = fontMetrics.stringWidth(str);
		int descent = fontMetrics.getDescent();
		graphics2D.drawString(str, (float)(num - (double)num3), (float)(num2 + (double)descent));
	}
	
	
	public static void overlayPicture(double d1, double d2, string str)
	{
		Image image = StdDraw3D.getImage(str);
		double num = (double)StdDraw3D.scaleX(d1);
		double num2 = (double)StdDraw3D.scaleY(d2);
		int num3 = image.getWidth(null);
		int num4 = image.getHeight(null);
		if (num3 < 0 || num4 < 0)
		{
			string arg_5C_0 = new StringBuilder().append("image ").append(str).append(" is corrupt").toString();
			
			throw new RuntimeException(arg_5C_0);
		}
		StdDraw3D.getGraphics2D(StdDraw3D.offscreenImage).drawImage(image, (int)java.lang.Math.round(num - (double)num3 / 2.0), (int)java.lang.Math.round(num2 - (double)num4 / 2.0), null);
	}
	
	
	public static void overlayPicture(double d1, double d2, string str, double d3)
	{
		Image image = StdDraw3D.getImage(str);
		double num = (double)StdDraw3D.scaleX(d1);
		double num2 = (double)StdDraw3D.scaleY(d2);
		int num3 = image.getWidth(null);
		int num4 = image.getHeight(null);
		if (num3 < 0 || num4 < 0)
		{
			string arg_5C_0 = new StringBuilder().append("image ").append(str).append(" is corrupt").toString();
			
			throw new RuntimeException(arg_5C_0);
		}
		Graphics2D graphics2D = StdDraw3D.getGraphics2D(StdDraw3D.offscreenImage);
		graphics2D.rotate(java.lang.Math.toRadians(-d3), num, num2);
		graphics2D.drawImage(image, (int)java.lang.Math.round(num - (double)num3 / 2.0), (int)java.lang.Math.round(num2 - (double)num4 / 2.0), null);
		graphics2D.rotate(java.lang.Math.toRadians(d3), num, num2);
	}
	
	
	public static void overlayPicture(double d1, double d2, string str, double d3, double d4)
	{
		Image image = StdDraw3D.getImage(str);
		double num = (double)StdDraw3D.scaleX(d1);
		double num2 = (double)StdDraw3D.scaleY(d2);
		if (d3 < (double)0f)
		{
			string arg_42_0 = new StringBuilder().append("width is negative: ").append(d3).toString();
			
			throw new RuntimeException(arg_42_0);
		}
		if (d4 < (double)0f)
		{
			string arg_73_0 = new StringBuilder().append("height is negative: ").append(d4).toString();
			
			throw new RuntimeException(arg_73_0);
		}
		double num3 = StdDraw3D.factorX(d3);
		double num4 = StdDraw3D.factorY(d4);
		if (num3 < (double)0f || num4 < (double)0f)
		{
			string arg_C7_0 = new StringBuilder().append("image ").append(str).append(" is corrupt").toString();
			
			throw new RuntimeException(arg_C7_0);
		}
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			StdDraw3D.overlayPixel(d1, d2);
		}
		else
		{
			StdDraw3D.getGraphics2D(StdDraw3D.offscreenImage).drawImage(image, (int)java.lang.Math.round(num - num3 / 2.0), (int)java.lang.Math.round(num2 - num4 / 2.0), (int)java.lang.Math.round(num3), (int)java.lang.Math.round(num4), null);
		}
	}
	
	
	public static void overlayPicture(double d1, double d2, string str, double d3, double d4, double d5)
	{
		Image image = StdDraw3D.getImage(str);
		double num = (double)StdDraw3D.scaleX(d1);
		double num2 = (double)StdDraw3D.scaleY(d2);
		double num3 = StdDraw3D.factorX(d3);
		double num4 = StdDraw3D.factorY(d4);
		if (num3 < (double)0f || num4 < (double)0f)
		{
			string arg_67_0 = new StringBuilder().append("image ").append(str).append(" is corrupt").toString();
			
			throw new RuntimeException(arg_67_0);
		}
		if (num3 <= (double)1f && num4 <= (double)1f)
		{
			StdDraw3D.overlayPixel(d1, d2);
		}
		Graphics2D graphics2D = StdDraw3D.getGraphics2D(StdDraw3D.offscreenImage);
		graphics2D.rotate(java.lang.Math.toRadians(-d5), num, num2);
		graphics2D.drawImage(image, (int)java.lang.Math.round(num - num3 / 2.0), (int)java.lang.Math.round(num2 - num4 / 2.0), (int)java.lang.Math.round(num3), (int)java.lang.Math.round(num4), null);
		graphics2D.rotate(java.lang.Math.toRadians(d5), num, num2);
	}
	
	
	public static void loadScene3D(string str)
	{
		new File(str);
		IOException ex;
		try
		{
			throw new NoClassDefFoundError("com.sun.j3d.utils.scenegraph.io.SceneGraphFileReader");
		}
		catch (IOException arg_13_0)
		{
			ex = ByteCodeHelper.MapException<IOException>(arg_13_0, ByteCodeHelper.MapFlags.NoRemapping);
		}
		IOException @this = ex;
		Throwable.instancehelper_printStackTrace(@this);
	}
	
	
	public static StdDraw3D.Shape copy(StdDraw3D.Shape sdds)
	{
		object obj = StdDraw3D.Shape.access_1000(sdds);
		StdDraw3D.Shape.access_900(sdds);
		obj;
		throw new NoClassDefFoundError("javax.media.j3d.TransformGroup");
	}
	
	
	public static StdDraw3D.Vector3D getCameraPosition()
	{
		return StdDraw3D.camera.getPosition();
	}
	
	
	public static StdDraw3D.Vector3D getCameraOrientation()
	{
		return StdDraw3D.camera.getOrientation();
	}
	
	
	public static StdDraw3D.Vector3D getCameraDirection()
	{
		return StdDraw3D.camera.getDirection();
	}
	
	
	public static void setCameraPosition(double d1, double d2, double d3)
	{
		StdDraw3D.setCameraPosition(new StdDraw3D.Vector3D(d1, d2, d3));
	}
	
	
	public static void setCameraOrientation(double d1, double d2, double d3)
	{
		StdDraw3D.setCameraOrientation(new StdDraw3D.Vector3D(d1, d2, d3));
	}
	
	
	public static void setCameraDirection(double d1, double d2, double d3)
	{
		StdDraw3D.setCameraDirection(new StdDraw3D.Vector3D(d1, d2, d3));
	}
	
	
	public static void setCamera(double d1, double d2, double d3, double d4, double d5, double d6)
	{
		StdDraw3D.camera.setPosition(d1, d2, d3);
		StdDraw3D.camera.setOrientation(d4, d5, d6);
	}
	
	
	public static void setCamera(StdDraw3D.Vector3D sddvd1, StdDraw3D.Vector3D sddvd2)
	{
		StdDraw3D.camera.setPosition(sddvd1);
		StdDraw3D.camera.setOrientation(sddvd2);
	}
	public static StdDraw3D.Camera camera()
	{
		return StdDraw3D.camera;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		StdDraw3D.setScale(-1.0, (double)1f);
		StdDraw3D.setInfoDisplay(false);
		StdDraw3D.setPenColor(StdDraw3D.__WHITE);
		StdDraw3D.overlaySquare((double)0f, (double)0f, 0.98);
		StdDraw3D.setPenRadius(0.06);
		StdDraw3D.setPenColor(StdDraw3D.__RED, 220);
		StdDraw3D.overlayCircle((double)0f, (double)0f, 0.8);
		StdDraw3D.setPenColor(StdDraw3D.__RED, 220);
		StdDraw3D.overlayCircle((double)0f, (double)0f, 0.6);
		StdDraw3D.setPenColor(StdDraw3D.__WHITE);
		StdDraw3D.overlayText((double)0f, 0.91, "Standard Draw 3D - Test Program");
		StdDraw3D.overlayText((double)0f, -0.95, "You should see rotating text. Drag the mouse to orbit.");
		StdDraw3D.setPenColor(StdDraw3D.__YELLOW);
		StdDraw3D.setFont(new Font("Arial", 1, 16));
		StdDraw3D.Shape shape = StdDraw3D.text3D((double)0f, (double)0f, (double)0f, "StdDraw3D");
		shape.scale(3.5);
		shape.move(-0.7, -0.1, (double)0f);
		shape = StdDraw3D.combine(new StdDraw3D.Shape[]
		{
			shape
		});
		while (true)
		{
			shape.rotate((double)0f, 1.2, (double)0f);
			StdDraw3D.show(20);
		}
	}
//[Modifiers(Modifiers.Static | Modifiers.Synthetic)]
	internal static StdDraw3D.Camera access_100()
	{
		return StdDraw3D.camera;
	}
//[Modifiers(Modifiers.Static | Modifiers.Synthetic)]
	internal static BufferedImage access_300()
	{
		return StdDraw3D.onscreenImage;
	}
//[Modifiers(Modifiers.Static | Modifiers.Synthetic)]
	internal static bool access_400()
	{
		return StdDraw3D.infoDisplay;
	}
//[Modifiers(Modifiers.Static | Modifiers.Synthetic)]
	internal static BufferedImage access_500()
	{
		return StdDraw3D.infoImage;
	}
//[Modifiers(Modifiers.Static | Modifiers.Synthetic)]
	internal static object access_2600()
	{
		return StdDraw3D.offscreenGroup;
	}
//[Modifiers(Modifiers.Static | Modifiers.Synthetic)]
	internal static object access_2700()
	{
		return StdDraw3D.onscreenGroup;
	}
	
	static StdDraw3D()
	{
		StdDraw3D.__BLACK = Color.BLACK;
		StdDraw3D.__BLUE = Color.BLUE;
		StdDraw3D.__CYAN = Color.CYAN;
		StdDraw3D.__DARK_GRAY = Color.DARK_GRAY;
		StdDraw3D.__GRAY = Color.GRAY;
		StdDraw3D.__GREEN = Color.GREEN;
		StdDraw3D.__LIGHT_GRAY = Color.LIGHT_GRAY;
		StdDraw3D.__MAGENTA = Color.MAGENTA;
		StdDraw3D.__ORANGE = Color.ORANGE;
		StdDraw3D.__PINK = Color.PINK;
		StdDraw3D.__RED = Color.RED;
		StdDraw3D.__WHITE = Color.WHITE;
		StdDraw3D.__YELLOW = Color.YELLOW;
		StdDraw3D.keysDown = new TreeSet();
		StdDraw3D.keysTyped = new LinkedList();
		StdDraw3D.mouseLock = new java.lang.Object();
		StdDraw3D.keyLock = new java.lang.Object();
		StdDraw3D.initialized = false;
		StdDraw3D.fullscreen = false;
		StdDraw3D.immersive = false;
		StdDraw3D.showedOnce = true;
		StdDraw3D.renderedOnce = false;
		StdDraw3D.DEFAULT_FONT = new Font("Arial", 0, 16);
		StdDraw3D.DEFAULT_PEN_COLOR = StdDraw3D.__WHITE;
		StdDraw3D.DEFAULT_BGCOLOR = StdDraw3D.__BLACK;
		throw new NoClassDefFoundError("javax.media.j3d.BoundingSphere");
	}
}







using java.util.regex;


public sealed class StdIn
{
	private static Scanner scanner;
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
	
	
	
	
	public static int readInt()
	{
		return StdIn.scanner.nextInt();
	}
	
	
	public static string readString()
	{
		return StdIn.scanner.next();
	}
	
	
	public static double readDouble()
	{
		return StdIn.scanner.nextDouble();
	}
	
	
	public static bool IsEmpty
	{
		return !StdIn.scanner.hasNext();
	}
	
	
	public static string readAll()
	{
		if (!StdIn.scanner.hasNextLine())
		{
			return "";
		}
		string result = StdIn.scanner.useDelimiter(StdIn.EVERYTHING_PATTERN).next();
		StdIn.scanner.useDelimiter(StdIn.WHITESPACE_PATTERN);
		return result;
	}
	
	
	public static string readLine()
	{
		string result;
		try
		{
			result = StdIn.scanner.nextLine();
		}
		catch (System.Exception arg_10_0)
		{
			if (ByteCodeHelper.MapException<java.lang.Exception>(arg_10_0, ByteCodeHelper.MapFlags.Unused) == null)
			{
				throw;
			}
			goto IL_1D;
		}
		return result;
		IL_1D:
		result = null;
		return result;
	}
	
	
	public static bool hasNextLine()
	{
		return StdIn.scanner.hasNextLine();
	}
	
	
	public static string[] readAllStrings()
	{
		Pattern arg_1A_0 = StdIn.WHITESPACE_PATTERN;
		object _<ref> = StdIn.readAll();
		CharSequence input;
		input.__<ref> = _<ref>;
		string[] array = arg_1A_0.split(input);
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
	
	
	public static bool readBoolean()
	{
		string @this = StdIn.readString();
		if (java.lang.String.instancehelper_equalsIgnoreCase(@this, "true"))
		{
			return true;
		}
		if (java.lang.String.instancehelper_equalsIgnoreCase(@this, "false"))
		{
			return false;
		}
		if (java.lang.String.instancehelper_equals(@this, "1"))
		{
			return true;
		}
		if (java.lang.String.instancehelper_equals(@this, "0"))
		{
			return false;
		}
		
		throw new InputMismatchException();
	}
	
	
	private static void setScanner(Scanner scanner)
	{
		StdIn.scanner = scanner;
		StdIn.scanner.useLocale(StdIn.usLocale);
	}
	
	
	public static int[] readAllInts()
	{
		string[] array = StdIn.readAllStrings();
		int[] array2 = new int[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = Integer.parseInt(array[i]);
		}
		return array2;
	}
	
	
	public static double[] readAllDoubles()
	{
		string[] array = StdIn.readAllStrings();
		double[] array2 = new double[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = java.lang.Double.parseDouble(array[i]);
		}
		return array2;
	}
	
	
	private static void resync()
	{
		Scanner.__<clinit>();
		BufferedInputStream.__<clinit>();
		StdIn.setScanner(new Scanner(new BufferedInputStream(System.@in), "UTF-8"));
	}
	
	
	private StdIn()
	{
	}
	
	
	public static bool hasNextChar()
	{
		StdIn.scanner.useDelimiter(StdIn.EMPTY_PATTERN);
		int result = StdIn.scanner.hasNext() ? 1 : 0;
		StdIn.scanner.useDelimiter(StdIn.WHITESPACE_PATTERN);
		return result != 0;
	}
	
	
	public static char readChar()
	{
		StdIn.scanner.useDelimiter(StdIn.EMPTY_PATTERN);
		string @this = StdIn.scanner.next();
		if (!StdIn.s_assertionsDisabled && java.lang.String.instancehelper_length(@this) != 1)
		{
			object arg_35_0 = "Internal (Std)In.readChar() error! Please contact the authors.";
			
			throw new AssertionError(arg_35_0);
		}
		StdIn.scanner.useDelimiter(StdIn.WHITESPACE_PATTERN);
		return java.lang.String.instancehelper_charAt(@this, 0);
	}
	
	
	public static float readFloat()
	{
		return StdIn.scanner.nextFloat();
	}
	
	
	public static long readLong()
	{
		return StdIn.scanner.nextLong();
	}
	
	
	public static short readShort()
	{
		return StdIn.scanner.nextShort();
	}
	
	
	public static byte readByte()
	{
		return (byte)((sbyte)StdIn.scanner.nextByte());
	}
//[LineNumberTable(253), Obsolete]
	
	public static int[] readInts()
	{
		return StdIn.readAllInts();
	}
//[LineNumberTable(261), Obsolete]
	
	public static double[] readDoubles()
	{
		return StdIn.readAllDoubles();
	}
//[LineNumberTable(269), Obsolete]
	
	public static string[] readStrings()
	{
		return StdIn.readAllStrings();
	}
	
	
	/**/public static void main(string[] strarr)
	{
		System.@out.println("Type a string: ");
		string str = StdIn.readString();
		System.@out.println(new StringBuilder().append("Your string was: ").append(str).toString());
		System.@out.println();
		System.@out.println("Type an int: ");
		int i = StdIn.readInt();
		System.@out.println(new StringBuilder().append("Your int was: ").append(i).toString());
		System.@out.println();
		System.@out.println("Type a bool: ");
		int b = StdIn.readBoolean() ? 1 : 0;
		System.@out.println(new StringBuilder().append("Your bool was: ").append(b != 0).toString());
		System.@out.println();
		System.@out.println("Type a double: ");
		double d = StdIn.readDouble();
		System.@out.println(new StringBuilder().append("Your double was: ").append(d).toString());
		System.@out.println();
	}
	
	static StdIn()
	{
		StdIn.s_assertionsDisabled = !ClassLiteral<StdIn>.Value.desiredAssertionStatus();
		StdIn.usLocale = new Locale("en", "US");
		StdIn.WHITESPACE_PATTERN = Pattern.compile("\\p{javaWhitespace}+");
		StdIn.EMPTY_PATTERN = Pattern.compile("");
		StdIn.EVERYTHING_PATTERN = Pattern.compile("\\A");
		StdIn.resync();
	}
}






using java.lang.reflect;



public class StdInTest
{
	private sealed class __<CallerID> : CallerID
	{
		internal __<CallerID>()
		{
		}
	}
	public static bool testStdIn;
	public static Method resyncMethod;
	public static int testCount = 0;
	private static CallerID __<callerID>;
	
	
	public static object escape(object obj)
	{
		if (obj is Character)
		{
			int num = (int)((Character)obj).charValue();
			int num2 = java.lang.String.instancehelper_indexOf("\b\t\n\f\r\"'\\", num);
			if (num2 >= 0)
			{
				return new StringBuilder().append("\\").append(java.lang.String.instancehelper_charAt("btnfr\"'\\", num2)).toString();
			}
			if (num < 32)
			{
				return new StringBuilder().append("\\").append(Integer.toOctalString(num)).toString();
			}
			if (num > 126)
			{
				return new StringBuilder().append("\\u").append(java.lang.String.format("%04X", new object[]
				{
					Integer.valueOf(num)
				})).toString();
			}
			return obj;
		}
		else
		{
			if (obj is string)
			{
				StringBuilder stringBuilder = new StringBuilder();
				char[] array = java.lang.String.instancehelper_toCharArray((string)obj);
				int i = array.Length;
				for (int j = 0; j < i; j++)
				{
					int c = (int)array[j];
					stringBuilder.append(StdInTest.escape(Character.valueOf((char)c)));
				}
				return new StringBuilder().append("\"").append(stringBuilder.toString()).append("\"").toString();
			}
			if (java.lang.Object.instancehelper_getClass(obj).isArray())
			{
				StringBuilder stringBuilder = new StringBuilder("[");
				int num2 = java.lang.reflect.Array.getLength(obj);
				for (int i = 0; i < num2; i++)
				{
					stringBuilder.append(" ").append(StdInTest.escape(java.lang.reflect.Array.get(obj, i)));
				}
				return stringBuilder.append("]").toString();
			}
			return obj;
		}
	}
	
	
	public static void test(string str, object[][] objarr, bool b)
	{
		In @in = null;
		if (b)
		{
			UnsupportedEncodingException ex;
			try
			{
				System.setIn(new ByteArrayInputStream(java.lang.String.instancehelper_getBytes(str, "UTF-8")));
			}
			catch (UnsupportedEncodingException arg_24_0)
			{
				ex = ByteCodeHelper.MapException<UnsupportedEncodingException>(arg_24_0, ByteCodeHelper.MapFlags.NoRemapping);
				goto IL_2E;
			}
			IllegalAccessException ex2;
			InvocationTargetException ex3;
			try
			{
				try
				{
					StdInTest.resyncMethod.invoke(null, new object[0], StdInTest.__<GetCallerID>());
				}
				catch (IllegalAccessException arg_61_0)
				{
					ex2 = ByteCodeHelper.MapException<IllegalAccessException>(arg_61_0, ByteCodeHelper.MapFlags.NoRemapping);
					goto IL_76;
				}
			}
			catch (InvocationTargetException arg_6B_0)
			{
				ex3 = ByteCodeHelper.MapException<InvocationTargetException>(arg_6B_0, ByteCodeHelper.MapFlags.NoRemapping);
				goto IL_7A;
			}
			goto IL_B9;
			IL_76:
			IllegalAccessException @this = ex2;
			string arg_8E_0 = Throwable.instancehelper_toString(@this);
			
			throw new RuntimeException(arg_8E_0);
			IL_7A:
			InvocationTargetException this2 = ex3;
			string arg_A2_0 = Throwable.instancehelper_toString(this2);
			
			throw new RuntimeException(arg_A2_0);
			IL_2E:
			UnsupportedEncodingException this3 = ex;
			string arg_3F_0 = Throwable.instancehelper_toString(this3);
			
			throw new RuntimeException(arg_3F_0);
		}
		
		@in = new In(new Scanner(str));
		IL_B9:
		int num = 0;
		int num2 = objarr.Length;
		int i = 0;
		while (i < num2)
		{
			object[] array = objarr[i];
			string text = (string)array[0];
			object obj = array[1];
			string text2 = "Failed input %s\nStep %d (%s)\n";
			object obj2;
			NoSuchMethodException ex4;
			IllegalAccessException ex5;
			InvocationTargetException ex6;
			try
			{
				try
				{
					try
					{
						Method method;
						if (b)
						{
							method = ClassLiteral<StdIn>.Value.getMethod(text, new Class[0], StdInTest.__<GetCallerID>());
						}
						else
						{
							method = java.lang.Object.instancehelper_getClass(@in).getMethod(text, new Class[0], StdInTest.__<GetCallerID>());
						}
						obj2 = method.invoke(@in, new object[0], StdInTest.__<GetCallerID>());
					}
					catch (NoSuchMethodException arg_141_0)
					{
						ex4 = ByteCodeHelper.MapException<NoSuchMethodException>(arg_141_0, ByteCodeHelper.MapFlags.NoRemapping);
						goto IL_160;
					}
				}
				catch (IllegalAccessException arg_14B_0)
				{
					ex5 = ByteCodeHelper.MapException<IllegalAccessException>(arg_14B_0, ByteCodeHelper.MapFlags.NoRemapping);
					goto IL_164;
				}
			}
			catch (InvocationTargetException arg_155_0)
			{
				ex6 = ByteCodeHelper.MapException<InvocationTargetException>(arg_155_0, ByteCodeHelper.MapFlags.NoRemapping);
				goto IL_168;
			}
			if (java.lang.Object.instancehelper_getClass(obj).isArray())
			{
				if (java.lang.Object.instancehelper_getClass(obj2).isArray())
				{
					object obj3 = obj2;
					object obj4 = obj;
					int length = java.lang.reflect.Array.getLength(obj3);
					int length2 = java.lang.reflect.Array.getLength(obj4);
					if (length2 != length)
					{
						StdOut.printf(new StringBuilder().append(text2).append("Expected %d, got %d items:\n%s\n").toString(), new object[]
						{
							StdInTest.escape(str),
							Integer.valueOf(num),
							text,
							Integer.valueOf(length2),
							Integer.valueOf(length),
							StdInTest.escape(obj3)
						});
					}
					else
					{
						for (int j = 0; j < length; j++)
						{
							if (!java.lang.Object.instancehelper_equals(java.lang.reflect.Array.get(obj3, j), java.lang.reflect.Array.get(obj4, j)))
							{
								StdOut.printf(new StringBuilder().append(text2).append("\nExpected [%d]=%s, got %s\n").toString(), new object[]
								{
									StdInTest.escape(str),
									Integer.valueOf(num),
									text,
									Integer.valueOf(j),
									StdInTest.escape(java.lang.reflect.Array.get(obj4, j)),
									StdInTest.escape(java.lang.reflect.Array.get(obj3, j))
								});
							}
						}
					}
					goto IL_47A;
				}
				StdOut.printf(new StringBuilder().append(text2).append("Expected array, got %s\n").toString(), new object[]
				{
					str,
					Integer.valueOf(num),
					text,
					obj2
				});
			}
			else
			{
				if (!java.lang.Object.instancehelper_equals(obj2, obj))
				{
					StdOut.printf(new StringBuilder().append(text2).append("Expected %s, got %s\n").toString(), new object[]
					{
						StdInTest.escape(str),
						Integer.valueOf(num),
						text,
						StdInTest.escape(obj),
						StdInTest.escape(obj2)
					});
					goto IL_47A;
				}
				goto IL_47A;
			}
			IL_480:
			i++;
			continue;
			IL_47A:
			num++;
			goto IL_480;
			IL_160:
			NoSuchMethodException this4 = ex4;
			StringWriter stringWriter = new StringWriter();
			Throwable.instancehelper_printStackTrace(this4, new PrintWriter(stringWriter));
			string arg_1CB_0 = new StringBuilder().append(java.lang.String.format(text2, new object[]
			{
				str,
				Integer.valueOf(num),
				text
			})).append(stringWriter.toString()).toString();
			
			throw new RuntimeException(arg_1CB_0);
			IL_164:
			IllegalAccessException this5 = ex5;
			stringWriter = new StringWriter();
			Throwable.instancehelper_printStackTrace(this5, new PrintWriter(stringWriter));
			string arg_228_0 = new StringBuilder().append(java.lang.String.format(text2, new object[]
			{
				str,
				Integer.valueOf(num),
				text
			})).append(stringWriter.toString()).toString();
			
			throw new RuntimeException(arg_228_0);
			IL_168:
			InvocationTargetException ex7 = ex6;
			stringWriter = new StringWriter();
			Throwable.instancehelper_printStackTrace(ex7, new PrintWriter(stringWriter));
			Throwable.instancehelper_printStackTrace(ex7.getCause(), new PrintWriter(stringWriter));
			string arg_298_0 = new StringBuilder().append(java.lang.String.format(text2, new object[]
			{
				str,
				Integer.valueOf(num),
				text
			})).append(stringWriter.toString()).toString();
			
			throw new RuntimeException(arg_298_0);
		}
	}
	
	
	public static bool canResync()
	{
		try
		{
			StdInTest.resyncMethod = ClassLiteral<StdIn>.Value.getMethod("resync", new Class[0], StdInTest.__<GetCallerID>());
		}
		catch (NoSuchMethodException arg_23_0)
		{
			return false;
		}
		return true;
	}
	
	
	public static void test(string str, object[][] objarr)
	{
		StdInTest.test(str, objarr, false);
		if (StdInTest.testStdIn)
		{
			StdInTest.test(str, objarr, true);
		}
		StdInTest.testCount++;
	}
	
	
	public StdInTest()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		StdInTest.testStdIn = StdInTest.canResync();
		if (StdInTest.testStdIn)
		{
			StdOut.println("Note: any errors appear duplicated since tests run 2x.");
		}
		else
		{
			StdOut.println("Note: StdIn.resync is private, only In will be tested.");
		}
		StdInTest.test("this is a test", new object[][]
		{
			new object[]
			{
				"isEmpty",
				java.lang.Boolean.valueOf(false)
			},
			new object[]
			{
				"hasNextChar",
				java.lang.Boolean.valueOf(true)
			},
			new object[]
			{
				"hasNextLine",
				java.lang.Boolean.valueOf(true)
			},
			new object[]
			{
				"readAllStrings",
				new string[]
				{
					"this",
					"is",
					"a",
					"test"
				}
			},
			new object[]
			{
				"isEmpty",
				java.lang.Boolean.valueOf(true)
			},
			new object[]
			{
				"hasNextChar",
				java.lang.Boolean.valueOf(false)
			},
			new object[]
			{
				"hasNextLine",
				java.lang.Boolean.valueOf(false)
			}
		});
		StdInTest.test("\n\n\n", new object[][]
		{
			new object[]
			{
				"isEmpty",
				java.lang.Boolean.valueOf(true)
			},
			new object[]
			{
				"hasNextChar",
				java.lang.Boolean.valueOf(true)
			},
			new object[]
			{
				"hasNextLine",
				java.lang.Boolean.valueOf(true)
			},
			new object[]
			{
				"readAll",
				"\n\n\n"
			}
		});
		StdInTest.test("", new object[][]
		{
			new object[]
			{
				"isEmpty",
				java.lang.Boolean.valueOf(true)
			},
			new object[]
			{
				"hasNextChar",
				java.lang.Boolean.valueOf(false)
			},
			new object[]
			{
				"hasNextLine",
				java.lang.Boolean.valueOf(false)
			}
		});
		StdInTest.test("\t\t  \t\t", new object[][]
		{
			new object[]
			{
				"isEmpty",
				java.lang.Boolean.valueOf(true)
			},
			new object[]
			{
				"hasNextChar",
				java.lang.Boolean.valueOf(true)
			},
			new object[]
			{
				"hasNextLine",
				java.lang.Boolean.valueOf(true)
			},
			new object[]
			{
				"readAll",
				"\t\t  \t\t"
			}
		});
		StdInTest.test("readLine consumes newline\nyeah!", new object[][]
		{
			new object[]
			{
				"readLine",
				"readLine consumes newline"
			},
			new object[]
			{
				"readChar",
				Character.valueOf('y')
			}
		});
		StdInTest.test("readString doesn't consume spaces", new object[][]
		{
			new object[]
			{
				"readString",
				"readString"
			},
			new object[]
			{
				"readChar",
				Character.valueOf(' ')
			}
		});
		StdInTest.test("\n\nblank lines test", new object[][]
		{
			new object[]
			{
				"readLine",
				""
			},
			new object[]
			{
				"readLine",
				""
			},
			new object[]
			{
				"hasNextLine",
				java.lang.Boolean.valueOf(true)
			},
			new object[]
			{
				"readLine",
				"blank lines test"
			},
			new object[]
			{
				"hasNextLine",
				java.lang.Boolean.valueOf(false)
			}
		});
		StdInTest.test("   \n  \t \n  correct  \n\t\n\t .trim replacement \n\t", new object[][]
		{
			new object[]
			{
				"readAllStrings",
				new string[]
				{
					"correct",
					".trim",
					"replacement"
				}
			},
			new object[]
			{
				"hasNextChar",
				java.lang.Boolean.valueOf(false)
			}
		});
		StringBuilder stringBuilder = new StringBuilder();
		int arg_3E4_0 = 2000;
		int arg_3DF_0 = 2;
		int[] array = new int[2];
		int num = arg_3DF_0;
		array[1] = num;
		num = arg_3E4_0;
		array[0] = num;
		object[][] array2 = (object[][])ByteCodeHelper.multianewarray(typeof(object[][]).TypeHandle, array);
		for (int i = 0; i < 1000; i++)
		{
			stringBuilder.append((char)i);
			stringBuilder.append((char)(i + 8000));
			array2[2 * i][0] = "readChar";
			array2[2 * i + 1][0] = "readChar";
			array2[2 * i][1] = Character.valueOf((char)i);
			array2[2 * i + 1][1] = Character.valueOf((char)(i + 8000));
		}
		StdInTest.test(stringBuilder.toString(), array2);
		StdInTest.test(" this \n and \that \n ", new object[][]
		{
			new object[]
			{
				"readString",
				"this"
			},
			new object[]
			{
				"readString",
				"and"
			},
			new object[]
			{
				"readChar",
				Character.valueOf(' ')
			},
			new object[]
			{
				"readString",
				"hat"
			},
			new object[]
			{
				"readChar",
				Character.valueOf(' ')
			},
			new object[]
			{
				"isEmpty",
				java.lang.Boolean.valueOf(true)
			},
			new object[]
			{
				"hasNextLine",
				java.lang.Boolean.valueOf(true)
			},
			new object[]
			{
				"readLine",
				""
			},
			new object[]
			{
				"readLine",
				" "
			}
		});
		StdInTest.test(" 1 2 3 \n\t 4 5 ", new object[][]
		{
			new object[]
			{
				"readAllInts",
				new int[]
				{
					1,
					2,
					3,
					4,
					5
				}
			}
		});
		StdInTest.test(" 0 1 False true falsE True ", new object[][]
		{
			new object[]
			{
				"readBoolean",
				java.lang.Boolean.valueOf(false)
			},
			new object[]
			{
				"readBoolean",
				java.lang.Boolean.valueOf(true)
			},
			new object[]
			{
				"readBoolean",
				java.lang.Boolean.valueOf(false)
			},
			new object[]
			{
				"readBoolean",
				java.lang.Boolean.valueOf(true)
			},
			new object[]
			{
				"readBoolean",
				java.lang.Boolean.valueOf(false)
			},
			new object[]
			{
				"readBoolean",
				java.lang.Boolean.valueOf(true)
			}
		});
		StdInTest.test(" \u00a0\u1680\u2000\u2001\u2002\u2003\u2004\u2005\u2006\u2007\u2008\u2009\u200a\u205f\u3000", new object[][]
		{
			new object[]
			{
				"readString",
				"\u00a0"
			},
			new object[]
			{
				"readString",
				"\u2007"
			},
			new object[]
			{
				"hasNextChar",
				java.lang.Boolean.valueOf(true)
			},
			new object[]
			{
				"isEmpty",
				java.lang.Boolean.valueOf(true)
			},
			new object[]
			{
				"readChar",
				Character.valueOf('\u2008')
			}
		});
		StdInTest.test("a\u2028b\u2029c\u001fd\ve\u0085f", new object[][]
		{
			new object[]
			{
				"readAllStrings",
				new string[]
				{
					"a",
					"b",
					"c",
					"d",
					"e\u0085f"
				}
			}
		});
		StdInTest.test("a\u2028b\u2029c\u001fd\ve\u0085f", new object[][]
		{
			new object[]
			{
				"readLine",
				"a"
			},
			new object[]
			{
				"readLine",
				"b"
			},
			new object[]
			{
				"readLine",
				"c\u001fd\ve"
			},
			new object[]
			{
				"readLine",
				"f"
			}
		});
		StdInTest.test("\u2028\u2029", new object[][]
		{
			new object[]
			{
				"readLine",
				""
			},
			new object[]
			{
				"hasNextLine",
				java.lang.Boolean.valueOf(true)
			},
			new object[]
			{
				"hasNextChar",
				java.lang.Boolean.valueOf(true)
			},
			new object[]
			{
				"readLine",
				""
			},
			new object[]
			{
				"hasNextLine",
				java.lang.Boolean.valueOf(false)
			},
			new object[]
			{
				"hasNextChar",
				java.lang.Boolean.valueOf(false)
			}
		});
		StdInTest.test("\n\n", new object[][]
		{
			new object[]
			{
				"readLine",
				""
			},
			new object[]
			{
				"hasNextLine",
				java.lang.Boolean.valueOf(true)
			},
			new object[]
			{
				"hasNextChar",
				java.lang.Boolean.valueOf(true)
			},
			new object[]
			{
				"readLine",
				""
			},
			new object[]
			{
				"hasNextLine",
				java.lang.Boolean.valueOf(false)
			},
			new object[]
			{
				"hasNextChar",
				java.lang.Boolean.valueOf(false)
			}
		});
		StdInTest.test("\r\n\r\n", new object[][]
		{
			new object[]
			{
				"readLine",
				""
			},
			new object[]
			{
				"hasNextLine",
				java.lang.Boolean.valueOf(true)
			},
			new object[]
			{
				"hasNextChar",
				java.lang.Boolean.valueOf(true)
			},
			new object[]
			{
				"readLine",
				""
			},
			new object[]
			{
				"hasNextLine",
				java.lang.Boolean.valueOf(false)
			},
			new object[]
			{
				"hasNextChar",
				java.lang.Boolean.valueOf(false)
			}
		});
		StdInTest.test("\n\r", new object[][]
		{
			new object[]
			{
				"readLine",
				""
			},
			new object[]
			{
				"hasNextLine",
				java.lang.Boolean.valueOf(true)
			},
			new object[]
			{
				"hasNextChar",
				java.lang.Boolean.valueOf(true)
			},
			new object[]
			{
				"readLine",
				""
			},
			new object[]
			{
				"hasNextLine",
				java.lang.Boolean.valueOf(false)
			},
			new object[]
			{
				"hasNextChar",
				java.lang.Boolean.valueOf(false)
			}
		});
		StdInTest.test("\r\n", new object[][]
		{
			new object[]
			{
				"readLine",
				""
			},
			new object[]
			{
				"hasNextChar",
				java.lang.Boolean.valueOf(false)
			},
			new object[]
			{
				"hasNextLine",
				java.lang.Boolean.valueOf(false)
			}
		});
		StdInTest.test("3E4 \t -0.5 \n \t +4", new object[][]
		{
			new object[]
			{
				"readAllDoubles",
				new double[]
				{
					30000.0,
					-0.5,
					4.0
				}
			}
		});
		StdInTest.test(" whitespace ", new object[][]
		{
			new object[]
			{
				"readString",
				"whitespace"
			},
			new object[]
			{
				"readChar",
				Character.valueOf(' ')
			},
			new object[]
			{
				"hasNextLine",
				java.lang.Boolean.valueOf(false)
			}
		});
		StdInTest.test(" whitespace \n", new object[][]
		{
			new object[]
			{
				"readString",
				"whitespace"
			},
			new object[]
			{
				"readChar",
				Character.valueOf(' ')
			},
			new object[]
			{
				"readLine",
				""
			},
			new object[]
			{
				"hasNextLine",
				java.lang.Boolean.valueOf(false)
			}
		});
		StdInTest.test(" whitespace \n ", new object[][]
		{
			new object[]
			{
				"readString",
				"whitespace"
			},
			new object[]
			{
				"readChar",
				Character.valueOf(' ')
			},
			new object[]
			{
				"readLine",
				""
			},
			new object[]
			{
				"hasNextLine",
				java.lang.Boolean.valueOf(true)
			},
			new object[]
			{
				"readLine",
				" "
			},
			new object[]
			{
				"hasNextLine",
				java.lang.Boolean.valueOf(false)
			}
		});
		StdInTest.test(" 34 -12983   3.25\n\t foo!", new object[][]
		{
			new object[]
			{
				"readByte",
				java.lang.Byte.valueOf(34)
			},
			new object[]
			{
				"readShort",
				Short.valueOf(-12983)
			},
			new object[]
			{
				"readDouble",
				java.lang.Double.valueOf(3.25)
			},
			new object[]
			{
				"readAll",
				"\n\t foo!"
			}
		});
		StdInTest.test("30000000000  3.5 3e4, foo   \t\t ya", new object[][]
		{
			new object[]
			{
				"readLong",
				Long.valueOf(30000000000L)
			},
			new object[]
			{
				"readFloat",
				Float.valueOf(3.5f)
			},
			new object[]
			{
				"readAllStrings",
				new string[]
				{
					"3e4,",
					"foo",
					"ya"
				}
			}
		});
		StdInTest.test(" \u0001 foo \u0001 foo \u0001 foo", new object[][]
		{
			new object[]
			{
				"readAllStrings",
				new string[]
				{
					"\u0001",
					"foo",
					"\u0001",
					"foo",
					"\u0001",
					"foo"
				}
			}
		});
		StdInTest.test(" \u2005 foo \u2005 foo \u2005 foo", new object[][]
		{
			new object[]
			{
				"readAllStrings",
				new string[]
				{
					"foo",
					"foo",
					"foo"
				}
			}
		});
		StdInTest.test(" \u0001 foo \u0001 foo \u0001 foo", new object[][]
		{
			new object[]
			{
				"readString",
				"\u0001"
			},
			new object[]
			{
				"readString",
				"foo"
			},
			new object[]
			{
				"readString",
				"\u0001"
			},
			new object[]
			{
				"readString",
				"foo"
			},
			new object[]
			{
				"readString",
				"\u0001"
			},
			new object[]
			{
				"readString",
				"foo"
			}
		});
		StdInTest.test(" \u2005 foo \u2005 foo \u2005 foo", new object[][]
		{
			new object[]
			{
				"readString",
				"foo"
			},
			new object[]
			{
				"readString",
				"foo"
			},
			new object[]
			{
				"readString",
				"foo"
			}
		});
		StdOut.printf("Ran %d tests.\n", new object[]
		{
			Integer.valueOf(StdInTest.testCount)
		});
	}
	private static CallerID __<GetCallerID>()
	{
		if (StdInTest.__<callerID> == null)
		{
			StdInTest.__<callerID> = new StdInTest.__<CallerID>();
		}
		return StdInTest.__<callerID>;
	}
}








public sealed class StdOut
{
	private const string charsetName = "UTF-8";
//[Modifiers(Modifiers.Private | Modifiers.Static | Modifiers.Final)]
	private static Locale US_LOCALE;
	private static PrintWriter @out;
	
	
	
	
	public static void printf(string str, params object[] objarr)
	{
		StdOut.@out.printf(StdOut.US_LOCALE, str, objarr);
		StdOut.@out.flush();
	}
	
	
	public static void print(object obj)
	{
		StdOut.@out.print(obj);
		StdOut.@out.flush();
	}
	
	
	public static void println()
	{
		StdOut.@out.println();
	}
	
	
	public static void println(object obj)
	{
		StdOut.@out.println(obj);
	}
	
	
	public static void print(int i)
	{
		StdOut.@out.print(i);
		StdOut.@out.flush();
	}
	
	
	public static void println(int i)
	{
		StdOut.@out.println(i);
	}
	
	
	public static void println(bool b)
	{
		StdOut.@out.println(b);
	}
	
	
	public static void println(double d)
	{
		StdOut.@out.println(d);
	}
	
	
	private StdOut()
	{
	}
	
	
	public static void close()
	{
		StdOut.@out.close();
	}
	
	
	public static void println(char ch)
	{
		StdOut.@out.println(ch);
	}
	
	
	public static void println(float f)
	{
		StdOut.@out.println(f);
	}
	
	
	public static void println(long l)
	{
		StdOut.@out.println(l);
	}
	
	
	public static void println(short s)
	{
		StdOut.@out.println((int)s);
	}
	
	
	public static void println(byte b)
	{
		int x = (int)((sbyte)b);
		StdOut.@out.println(x);
	}
	
	
	public static void print()
	{
		StdOut.@out.flush();
	}
	
	
	public static void print(bool b)
	{
		StdOut.@out.print(b);
		StdOut.@out.flush();
	}
	
	
	public static void print(char ch)
	{
		StdOut.@out.print(ch);
		StdOut.@out.flush();
	}
	
	
	public static void print(double d)
	{
		StdOut.@out.print(d);
		StdOut.@out.flush();
	}
	
	
	public static void print(float f)
	{
		StdOut.@out.print(f);
		StdOut.@out.flush();
	}
	
	
	public static void print(long l)
	{
		StdOut.@out.print(l);
		StdOut.@out.flush();
	}
	
	
	public static void print(short s)
	{
		StdOut.@out.print((int)s);
		StdOut.@out.flush();
	}
	
	
	public static void print(byte b)
	{
		int i = (int)((sbyte)b);
		StdOut.@out.print(i);
		StdOut.@out.flush();
	}
	
	
	public static void printf(Locale l, string str, params object[] objarr)
	{
		StdOut.@out.printf(l, str, objarr);
		StdOut.@out.flush();
	}
	
	
	/**/public static void main(string[] strarr)
	{
		StdOut.println("Test");
		StdOut.println(17);
		StdOut.println(true);
		StdOut.printf("%.6f\n", new object[]
		{
			java.lang.Double.valueOf(0.14285714285714285)
		});
	}
	
	static StdOut()
	{
		StdOut.US_LOCALE = new Locale("en", "US");
		UnsupportedEncodingException ex;
		try
		{
			StdOut.@out = new PrintWriter(new OutputStreamWriter(System.@out, "UTF-8"), true);
		}
		catch (UnsupportedEncodingException arg_33_0)
		{
			ex = ByteCodeHelper.MapException<UnsupportedEncodingException>(arg_33_0, ByteCodeHelper.MapFlags.NoRemapping);
			goto IL_3D;
		}
		return;
		IL_3D:
		UnsupportedEncodingException x = ex;
		System.@out.println(x);
	}
}













public sealed class StdStats
{
	
	public static double sum(double[] darr)
	{
		double num = (double)0f;
		for (int i = 0; i < darr.Length; i++)
		{
			num += darr[i];
		}
		return num;
	}
	
	
	public static double sum(double[] darr, int i1, int i2)
	{
		if (i1 < 0 || i2 >= darr.Length || i1 > i2)
		{
			string arg_17_0 = "Subarray indices out of bounds";
			
			throw new RuntimeException(arg_17_0);
		}
		double num = (double)0f;
		for (int j = i1; j <= i2; j++)
		{
			num += darr[j];
		}
		return num;
	}
	
	
	public static double mean(double[] darr)
	{
		if (darr.Length == 0)
		{
			return double.NaN;
		}
		double num = StdStats.sum(darr);
		return num / (double)darr.Length;
	}
	
	
	public static double mean(double[] darr, int i1, int i2)
	{
		int num = i2 - i1 + 1;
		if (i1 < 0 || i2 >= darr.Length || i1 > i2)
		{
			string arg_1D_0 = "Subarray indices out of bounds";
			
			throw new RuntimeException(arg_1D_0);
		}
		if (num == 0)
		{
			return double.NaN;
		}
		double num2 = StdStats.sum(darr, i1, i2);
		return num2 / (double)num;
	}
	
	public static double mean(int[] iarr)
	{
		if (iarr.Length == 0)
		{
			return double.NaN;
		}
		double num = (double)0f;
		for (int i = 0; i < iarr.Length; i++)
		{
			num += (double)iarr[i];
		}
		return num / (double)iarr.Length;
	}
	
	
	public static double var(double[] darr)
	{
		if (darr.Length == 0)
		{
			return double.NaN;
		}
		double num = StdStats.mean(darr);
		double num2 = (double)0f;
		for (int i = 0; i < darr.Length; i++)
		{
			num2 += (darr[i] - num) * (darr[i] - num);
		}
		return num2 / (double)(darr.Length - 1);
	}
	
	
	public static double var(double[] darr, int i1, int i2)
	{
		int num = i2 - i1 + 1;
		if (i1 < 0 || i2 >= darr.Length || i1 > i2)
		{
			string arg_1D_0 = "Subarray indices out of bounds";
			
			throw new RuntimeException(arg_1D_0);
		}
		if (num == 0)
		{
			return double.NaN;
		}
		double num2 = StdStats.mean(darr, i1, i2);
		double num3 = (double)0f;
		for (int j = i1; j <= i2; j++)
		{
			num3 += (darr[j] - num2) * (darr[j] - num2);
		}
		return num3 / (double)(num - 1);
	}
	
	
	public static double var(int[] iarr)
	{
		if (iarr.Length == 0)
		{
			return double.NaN;
		}
		double num = StdStats.mean(iarr);
		double num2 = (double)0f;
		for (int i = 0; i < iarr.Length; i++)
		{
			num2 += ((double)iarr[i] - num) * ((double)iarr[i] - num);
		}
		return num2 / (double)(iarr.Length - 1);
	}
	
	
	public static double varp(double[] darr)
	{
		if (darr.Length == 0)
		{
			return double.NaN;
		}
		double num = StdStats.mean(darr);
		double num2 = (double)0f;
		for (int i = 0; i < darr.Length; i++)
		{
			num2 += (darr[i] - num) * (darr[i] - num);
		}
		return num2 / (double)darr.Length;
	}
	
	
	public static double varp(double[] darr, int i1, int i2)
	{
		int num = i2 - i1 + 1;
		if (i1 < 0 || i2 >= darr.Length || i1 > i2)
		{
			string arg_1D_0 = "Subarray indices out of bounds";
			
			throw new RuntimeException(arg_1D_0);
		}
		if (num == 0)
		{
			return double.NaN;
		}
		double num2 = StdStats.mean(darr, i1, i2);
		double num3 = (double)0f;
		for (int j = i1; j <= i2; j++)
		{
			num3 += (darr[j] - num2) * (darr[j] - num2);
		}
		return num3 / (double)num;
	}
	
	public static double min(double[] darr)
	{
		double num = double.PositiveInfinity;
		for (int i = 0; i < darr.Length; i++)
		{
			if (darr[i] < num)
			{
				num = darr[i];
			}
		}
		return num;
	}
	
	public static double max(double[] darr)
	{
		double num = double.NegativeInfinity;
		for (int i = 0; i < darr.Length; i++)
		{
			if (darr[i] > num)
			{
				num = darr[i];
			}
		}
		return num;
	}
	
	
	public static double stddev(double[] darr)
	{
		return java.lang.Math.sqrt(StdStats.var(darr));
	}
	
	
	private StdStats()
	{
	}
	
	
	public static double max(double[] darr, int i1, int i2)
	{
		if (i1 < 0 || i2 >= darr.Length || i1 > i2)
		{
			string arg_17_0 = "Subarray indices out of bounds";
			
			throw new RuntimeException(arg_17_0);
		}
		double num = double.NegativeInfinity;
		for (int j = i1; j <= i2; j++)
		{
			if (darr[j] > num)
			{
				num = darr[j];
			}
		}
		return num;
	}
	
	public static int max(int[] iarr)
	{
		int num = -2147483648;
		for (int i = 0; i < iarr.Length; i++)
		{
			if (iarr[i] > num)
			{
				num = iarr[i];
			}
		}
		return num;
	}
	
	
	public static double min(double[] darr, int i1, int i2)
	{
		if (i1 < 0 || i2 >= darr.Length || i1 > i2)
		{
			string arg_17_0 = "Subarray indices out of bounds";
			
			throw new RuntimeException(arg_17_0);
		}
		double num = double.PositiveInfinity;
		for (int j = i1; j <= i2; j++)
		{
			if (darr[j] < num)
			{
				num = darr[j];
			}
		}
		return num;
	}
	
	public static int min(int[] iarr)
	{
		int num = 2147483647;
		for (int i = 0; i < iarr.Length; i++)
		{
			if (iarr[i] < num)
			{
				num = iarr[i];
			}
		}
		return num;
	}
	
	
	public static double stddev(double[] darr, int i1, int i2)
	{
		return java.lang.Math.sqrt(StdStats.var(darr, i1, i2));
	}
	
	
	public static double stddev(int[] iarr)
	{
		return java.lang.Math.sqrt(StdStats.var(iarr));
	}
	
	
	public static double stddevp(double[] darr)
	{
		return java.lang.Math.sqrt(StdStats.varp(darr));
	}
	
	
	public static double stddevp(double[] darr, int i1, int i2)
	{
		return java.lang.Math.sqrt(StdStats.varp(darr, i1, i2));
	}
	
	public static int sum(int[] iarr)
	{
		int num = 0;
		for (int i = 0; i < iarr.Length; i++)
		{
			num += iarr[i];
		}
		return num;
	}
	
	
	public static void plotPoints(double[] darr)
	{
		int num = darr.Length;
		StdDraw.setXscale((double)0f, (double)(num - 1));
		StdDraw.setPenRadius((double)1f / (3.0 * (double)num));
		for (int i = 0; i < num; i++)
		{
			StdDraw.point((double)i, darr[i]);
		}
	}
	
	
	public static void plotLines(double[] darr)
	{
		int num = darr.Length;
		StdDraw.setXscale((double)0f, (double)(num - 1));
		StdDraw.setPenRadius();
		for (int i = 1; i < num; i++)
		{
			StdDraw.line((double)(i - 1), darr[i - 1], (double)i, darr[i]);
		}
	}
	
	
	public static void plotBars(double[] darr)
	{
		int num = darr.Length;
		StdDraw.setXscale((double)0f, (double)(num - 1));
		for (int i = 0; i < num; i++)
		{
			StdDraw.filledRectangle((double)i, darr[i] / 2.0, 0.25, darr[i] / 2.0);
		}
	}
	
	
	/**/public static void main(string[] strarr)
	{
		double[] darr = StdArrayIO.readDouble1D();
		StdOut.printf("       min %7.3f\n", new object[]
		{
			java.lang.Double.valueOf(StdStats.min(darr))
		});
		StdOut.printf("      mean %7.3f\n", new object[]
		{
			java.lang.Double.valueOf(StdStats.mean(darr))
		});
		StdOut.printf("       max %7.3f\n", new object[]
		{
			java.lang.Double.valueOf(StdStats.max(darr))
		});
		StdOut.printf("   std dev %7.3f\n", new object[]
		{
			java.lang.Double.valueOf(StdStats.stddev(darr))
		});
	}
}





public class Stopwatch
{
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private long start;
	
	
	public Stopwatch()
	{
		this.start = System.currentTimeMillis();
	}
	
	
	public virtual double elapsedTime()
	{
		long num = System.currentTimeMillis();
		return (double)(num - this.start) / 1000.0;
	}
}



using java.lang.management;


public class StopwatchCPU
{
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private ThreadMXBean threadTimer;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private long start;
	private const double NANOSECONDS_PER_SECOND = 1000000000.0;
	
	
	public StopwatchCPU()
	{
		this.threadTimer = ManagementFactory.getThreadMXBean();
		this.start = this.threadTimer.getCurrentThreadCpuTime();
	}
	
	
	public virtual double elapsedTime()
	{
		long currentThreadCpuTime = this.threadTimer.getCurrentThreadCpuTime();
		return (double)(currentThreadCpuTime - this.start) / 1000000000.0;
	}
}







public class SuffixArray
{
	/*[EnclosingMethod("SuffixArray", null, null), InnerClass(null, Modifiers.Static | Modifiers.Synthetic), Modifiers(Modifiers.Super | Modifiers.Synthetic), SourceFile("SuffixArray.java")]*/
	
	/*[Implements(new string[]
	{
		"java.lang.Comparable"
	}), InnerClass(null, Modifiers.Private | Modifiers.Static), Modifiers(Modifiers.Super), Signature("Ljava/lang/Object;Ljava/lang/Comparable<LSuffixArray$Suffix;>;"), SourceFile("SuffixArray.java")]*/
	internal sealed class Suffix, Comparable
	{
//[Modifiers(Modifiers.Private | Modifiers.Final)]
		private string text;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
		private int index;
/*		[LineNumberTable(70), Modifiers(Modifiers.Synthetic)]*/
		
		internal Suffix(string text, int num, SuffixArray.1) : this(text, num)
		{
		}
/*		[LineNumberTable(70), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static int access_100(SuffixArray.Suffix suffix)
		{
			return suffix.index;
		}
/*		[LineNumberTable(70), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		
		internal static int access_200(SuffixArray.Suffix suffix)
		{
			return suffix.Length();
		}
/*		[LineNumberTable(70), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		
		internal static char access_300(SuffixArray.Suffix suffix, int num)
		{
			return suffix.charAt(num);
		}
		
		
		public override string ToString()
		{
			return java.lang.String.instancehelper_substring(this.text, this.index);
		}
		
		
		private char charAt(int num)
		{
			return java.lang.String.instancehelper_charAt(this.text, this.index + num);
		}
		
		
		private int length()
		{
			return java.lang.String.instancehelper_length(this.text) - this.index;
		}
		
		
		private Suffix(string text, int num)
		{
			this.text = text;
			this.index = num;
		}
		
		
		public virtual int compareTo(SuffixArray.Suffix suffix)
		{
			if (this == suffix)
			{
				return 0;
			}
			int num = java.lang.Math.min(this.Length(), suffix.Length());
			for (int i = 0; i < num; i++)
			{
				if (this.charAt(i) < suffix.charAt(i))
				{
					return -1;
				}
				if (this.charAt(i) > suffix.charAt(i))
				{
					return 1;
				}
			}
			return this.Length() - suffix.Length();
		}
/*		[LineNumberTable(70), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/
		
		public virtual int compareTo(object obj)
		{
			return this.CompareTo((SuffixArray.Suffix)obj);
		}
		
		int IComparable.Object;)IcompareTo(object obj)
		{
			return this.CompareTo(obj);
		}
	}
	private SuffixArray.Suffix[] suffixes;
//[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
	internal static bool s_assertionsDisabled;
	
	
	
	
	public SuffixArray(string str)
	{
		int num = java.lang.String.instancehelper_length(str);
		this.suffixes = new SuffixArray.Suffix[num];
		for (int i = 0; i < num; i++)
		{
			this.suffixes[i] = new SuffixArray.Suffix(str, i, null);
		}
		Arrays.sort(this.suffixes);
	}
	
	
	public virtual int rank(string str)
	{
		int i = 0;
		int num = this.suffixes.Length - 1;
		while (i <= num)
		{
			int num2 = i + (num - i) / 2;
			int num3 = SuffixArray.compare(str, this.suffixes[num2]);
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
	
	
	public virtual int index(int i)
	{
		if (i < 0 || i >= this.suffixes.Length)
		{
			
			throw new IndexOutOfRangeException();
		}
		return SuffixArray.Suffix.access_100(this.suffixes[i]);
	}
	
	
	public virtual int lcp(int i)
	{
		if (i < 1 || i >= this.suffixes.Length)
		{
			
			throw new IndexOutOfRangeException();
		}
		return SuffixArray.lcp(this.suffixes[i], this.suffixes[i - 1]);
	}
	
	public virtual int length()
	{
		return this.suffixes.Length;
	}
	
	
	private static int lcp(SuffixArray.Suffix suffix, SuffixArray.Suffix suffix2)
	{
		int num = java.lang.Math.min(SuffixArray.Suffix.access_200(suffix), SuffixArray.Suffix.access_200(suffix2));
		for (int i = 0; i < num; i++)
		{
			if (SuffixArray.Suffix.access_300(suffix, i) != SuffixArray.Suffix.access_300(suffix2, i))
			{
				return i;
			}
		}
		return num;
	}
	
	
	private static int compare(string @this, SuffixArray.Suffix suffix)
	{
		int num = java.lang.Math.min(java.lang.String.instancehelper_length(@this), SuffixArray.Suffix.access_200(suffix));
		for (int i = 0; i < num; i++)
		{
			if (java.lang.String.instancehelper_charAt(@this, i) < SuffixArray.Suffix.access_300(suffix, i))
			{
				return -1;
			}
			if (java.lang.String.instancehelper_charAt(@this, i) > SuffixArray.Suffix.access_300(suffix, i))
			{
				return 1;
			}
		}
		return java.lang.String.instancehelper_length(@this) - SuffixArray.Suffix.access_200(suffix);
	}
	
	
	public virtual string select(int i)
	{
		if (i < 0 || i >= this.suffixes.Length)
		{
			
			throw new IndexOutOfRangeException();
		}
		return this.suffixes[i].toString();
	}
	
	
	/**/public static void main(string[] strarr)
	{
		string text = java.lang.String.instancehelper_trim(java.lang.String.instancehelper_replaceAll(StdIn.readAll(), "\\s+", " "));
		SuffixArray suffixArray = new SuffixArray(text);
		StdOut.println("  i ind lcp rnk select");
		StdOut.println("---------------------------");
		for (int i = 0; i < java.lang.String.instancehelper_length(text); i++)
		{
			int num = suffixArray.index(i);
			string text2 = new StringBuilder().append("\"").append(java.lang.String.instancehelper_substring(text, num, java.lang.Math.min(num + 50, java.lang.String.instancehelper_length(text)))).append("\"").toString();
			if (!SuffixArray.s_assertionsDisabled && !java.lang.String.instancehelper_equals(java.lang.String.instancehelper_substring(text, num), suffixArray.select(i)))
			{
				
				throw new AssertionError();
			}
			int i2 = suffixArray.rank(java.lang.String.instancehelper_substring(text, num));
			if (i == 0)
			{
				StdOut.printf("%3d %3d %3s %3d %s\n", new object[]
				{
					Integer.valueOf(i),
					Integer.valueOf(num),
					"-",
					Integer.valueOf(i2),
					text2
				});
			}
			else
			{
				int i3 = suffixArray.lcp(i);
				StdOut.printf("%3d %3d %3d %3d %s\n", new object[]
				{
					Integer.valueOf(i),
					Integer.valueOf(num),
					Integer.valueOf(i3),
					Integer.valueOf(i2),
					text2
				});
			}
		}
	}
	
	static SuffixArray()
	{
		SuffixArray.s_assertionsDisabled = !ClassLiteral<SuffixArray>.Value.desiredAssertionStatus();
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
public class TrieST
{
	/*[EnclosingMethod("TrieST", null, null), InnerClass(null, Modifiers.Static | Modifiers.Synthetic), Modifiers(Modifiers.Super | Modifiers.Synthetic), SourceFile("TrieST.java")]*/
	
	[InnerClass(null, Modifiers.Private | Modifiers.Static), Modifiers(Modifiers.Super), SourceFile("TrieST.java")]
	internal sealed class Node
	{
		private object val;
		private TrieST.Node[] next;
/*		[LineNumberTable(55), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static object access_000(TrieST.Node node)
		{
			return node.val;
		}
/*		[LineNumberTable(55), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static TrieST.Node[] access_100(TrieST.Node node)
		{
			return node.next;
		}
/*		[LineNumberTable(55), Modifiers(Modifiers.Synthetic)]*/
		
		internal Node(TrieST.1) : this()
		{
		}
/*		[LineNumberTable(55), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static object access_002(TrieST.Node node, object result)
		{
			node.val = result;
			return result;
		}
		
		
		private Node()
		{
			this.next = new TrieST.Node[256];
		}
	}
	private const int R = 256;
	private TrieST.Node root;
	private int N;
	
	
	private TrieST.Node get(TrieST.Node node, string text, int num)
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
		return this.get(TrieST.Node.access_100(node)[num2], text, num + 1);
	}
/*	[Signature("(Ljava/lang/String;)TValue;")]*/
	
	public virtual object get(string str)
	{
		TrieST.Node node = this.get(this.root, str, 0);
		if (node == null)
		{
			return null;
		}
		return TrieST.Node.access_000(node);
	}
	
	
	public virtual void delete(string str)
	{
		this.root = this.delete(this.root, str, 0);
	}
/*	[Signature("(LTrieST$Node;Ljava/lang/String;TValue;I)LTrieST$Node;")]*/
	
	private TrieST.Node put(TrieST.Node node, string text, object obj, int num)
	{
		if (node == null)
		{
			node = new TrieST.Node(null);
		}
		if (num == java.lang.String.instancehelper_length(text))
		{
			if (TrieST.Node.access_000(node) == null)
			{
				this.N++;
			}
			TrieST.Node.access_002(node, obj);
			return node;
		}
		int num2 = (int)java.lang.String.instancehelper_charAt(text, num);
		TrieST.Node.access_100(node)[num2] = this.put(TrieST.Node.access_100(node)[num2], text, obj, num + 1);
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
		TrieST.Node node = this.get(this.root, str, 0);
		this.collect(node, new StringBuilder(str), queue);
		return queue;
	}
/*	[Signature("(LTrieST$Node;Ljava/lang/StringBuilder;LQueue<Ljava/lang/String;>;)V")]*/
	
	private void collect(TrieST.Node node, StringBuilder stringBuilder, Queue queue)
	{
		if (node == null)
		{
			return;
		}
		if (TrieST.Node.access_000(node) != null)
		{
			queue.enqueue(stringBuilder.toString());
		}
		for (int i = 0; i < 256; i = (int)((ushort)(i + 1)))
		{
			stringBuilder.append((char)i);
			this.collect(TrieST.Node.access_100(node)[i], stringBuilder, queue);
			stringBuilder.deleteCharAt(stringBuilder.Length() - 1);
		}
	}
/*	[Signature("(LTrieST$Node;Ljava/lang/StringBuilder;Ljava/lang/String;LQueue<Ljava/lang/String;>;)V")]*/
	
	private void collect(TrieST.Node node, StringBuilder stringBuilder, string text, Queue queue)
	{
		if (node == null)
		{
			return;
		}
		int num = stringBuilder.Length();
		if (num == java.lang.String.instancehelper_length(text) && TrieST.Node.access_000(node) != null)
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
				this.collect(TrieST.Node.access_100(node)[i], stringBuilder, text, queue);
				stringBuilder.deleteCharAt(stringBuilder.Length() - 1);
			}
		}
		else
		{
			stringBuilder.append((char)num2);
			this.collect(TrieST.Node.access_100(node)[num2], stringBuilder, text, queue);
			stringBuilder.deleteCharAt(stringBuilder.Length() - 1);
		}
	}
	
	
	private int longestPrefixOf(TrieST.Node node, string text, int num, int num2)
	{
		if (node == null)
		{
			return num2;
		}
		if (TrieST.Node.access_000(node) != null)
		{
			num2 = num;
		}
		if (num == java.lang.String.instancehelper_length(text))
		{
			return num2;
		}
		int num3 = (int)java.lang.String.instancehelper_charAt(text, num);
		return this.longestPrefixOf(TrieST.Node.access_100(node)[num3], text, num + 1, num2);
	}
	
	
	private TrieST.Node delete(TrieST.Node node, string text, int num)
	{
		if (node == null)
		{
			return null;
		}
		if (num == java.lang.String.instancehelper_length(text))
		{
			if (TrieST.Node.access_000(node) != null)
			{
				this.N--;
			}
			TrieST.Node.access_002(node, null);
		}
		else
		{
			int i = (int)java.lang.String.instancehelper_charAt(text, num);
			TrieST.Node.access_100(node)[i] = this.delete(TrieST.Node.access_100(node)[i], text, num + 1);
		}
		if (TrieST.Node.access_000(node) != null)
		{
			return node;
		}
		for (int i = 0; i < 256; i++)
		{
			if (TrieST.Node.access_100(node)[i] != null)
			{
				return node;
			}
		}
		return null;
	}
	
	
	public TrieST()
	{
	}
/*	[Signature("(Ljava/lang/String;TValue;)V")]*/
	
	public virtual void put(string str, object obj)
	{
		if (obj == null)
		{
			this.delete(str);
		}
		else
		{
			this.root = this.put(this.root, str, obj, 0);
		}
	}
/*	[LineNumberTable(146), Signature("()Ljava/lang/Iterable<Ljava/lang/String;>;")]*/
	
	public virtual Iterable keys()
	{
		return this.keysWithPrefix("");
	}
	
	
	public virtual string longestPrefixOf(string str)
	{
		int endIndex = this.longestPrefixOf(this.root, str, 0, 0);
		return java.lang.String.instancehelper_substring(str, 0, endIndex);
	}
/*	[Signature("(Ljava/lang/String;)Ljava/lang/Iterable<Ljava/lang/String;>;")]*/
	
	public virtual Iterable keysThatMatch(string str)
	{
		Queue queue = new Queue();
		this.collect(this.root, new StringBuilder(), str, queue);
		return queue;
	}
	
	
	public virtual bool contains(string str)
	{
		return this.get(str) != null;
	}
	
	
	public virtual bool IsEmpty
	{
		return this.Size == 0;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		TrieST trieST = new TrieST();
		int num = 0;
		while (!StdIn.IsEmpty)
		{
			string text = StdIn.readString();
			trieST.put(text, Integer.valueOf(num));
			num++;
		}
		Iterator iterator;
		if (trieST.Size < 100)
		{
			StdOut.println("keys(\"\"):");
			iterator = trieST.keys().iterator();
			while (iterator.hasNext())
			{
				string text = (string)iterator.next();
				StdOut.println(new StringBuilder().append(text).append(" ").append(trieST.get(text)).toString());
			}
			StdOut.println();
		}
		StdOut.println("longestPrefixOf(\"shellsort\"):");
		StdOut.println(trieST.longestPrefixOf("shellsort"));
		StdOut.println();
		StdOut.println("keysWithPrefix(\"shor\"):");
		iterator = trieST.keysWithPrefix("shor").iterator();
		while (iterator.hasNext())
		{
			string text = (string)iterator.next();
			StdOut.println(text);
		}
		StdOut.println();
		StdOut.println("keysThatMatch(\".he.l.\"):");
		iterator = trieST.keysThatMatch(".he.l.").iterator();
		while (iterator.hasNext())
		{
			string text = (string)iterator.next();
			StdOut.println(text);
		}
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





public class UF
{
	private int[] id;
	private byte[] rank;
	private int count;
	
	
	public UF(int i)
	{
		if (i < 0)
		{
			
			throw new ArgumentException();
		}
		this.count = i;
		this.id = new int[i];
		this.rank = new byte[i];
		for (int j = 0; j < i; j++)
		{
			this.id[j] = j;
			this.rank[j] = 0;
		}
	}
	
	
	public virtual int find(int i)
	{
		if (i < 0 || i >= this.id.Length)
		{
			
			throw new IndexOutOfRangeException();
		}
		while (i != this.id[i])
		{
			this.id[i] = this.id[this.id[i]];
			i = this.id[i];
		}
		return i;
	}
	
	
	public virtual bool connected(int i1, int i2)
	{
		return this.find(i1) == this.find(i2);
	}
	
	
	public virtual void union(int i1, int i2)
	{
		int num = this.find(i1);
		int num2 = this.find(i2);
		if (num == num2)
		{
			return;
		}
		if (this.rank[num] < this.rank[num2])
		{
			this.id[num] = num2;
		}
		else if (this.rank[num] > this.rank[num2])
		{
			this.id[num2] = num;
		}
		else
		{
			this.id[num2] = num;
			byte[] arg_60_0 = this.rank;
			int num3 = num;
			byte[] array = arg_60_0;
			array[num3] = (byte)((sbyte)(array[num3] + 1));
		}
		this.count--;
	}
	public virtual int count()
	{
		return this.count;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		int i = StdIn.readInt();
		UF uF = new UF(i);
		while (!StdIn.IsEmpty)
		{
			int num = StdIn.readInt();
			int num2 = StdIn.readInt();
			if (!uF.connected(num, num2))
			{
				uF.union(num, num2);
				StdOut.println(new StringBuilder().append(num).append(" ").append(num2).toString());
			}
		}
		StdOut.println(new StringBuilder().append(uF.count()).append(" components").toString());
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





public class WeightedQuickUnionUF
{
	private int[] id;
	private int[] sz;
	private int count;
	
	public virtual int find(int i)
	{
		while (i != this.id[i])
		{
			i = this.id[i];
		}
		return i;
	}
	
	
	public WeightedQuickUnionUF(int i)
	{
		this.count = i;
		this.id = new int[i];
		this.sz = new int[i];
		for (int j = 0; j < i; j++)
		{
			this.id[j] = j;
			this.sz[j] = 1;
		}
	}
	
	
	public virtual bool connected(int i1, int i2)
	{
		return this.find(i1) == this.find(i2);
	}
	
	
	public virtual void union(int i1, int i2)
	{
		int num = this.find(i1);
		int num2 = this.find(i2);
		if (num == num2)
		{
			return;
		}
		if (this.sz[num] < this.sz[num2])
		{
			this.id[num] = num2;
			int[] arg_38_0 = this.sz;
			int num3 = num2;
			int[] array = arg_38_0;
			array[num3] += this.sz[num];
		}
		else
		{
			this.id[num2] = num;
			int[] arg_5B_0 = this.sz;
			int num3 = num;
			int[] array = arg_5B_0;
			array[num3] += this.sz[num2];
		}
		this.count--;
	}
	public virtual int count()
	{
		return this.count;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		int i = StdIn.readInt();
		WeightedQuickUnionUF weightedQuickUnionUF = new WeightedQuickUnionUF(i);
		while (!StdIn.IsEmpty)
		{
			int num = StdIn.readInt();
			int num2 = StdIn.readInt();
			if (!weightedQuickUnionUF.connected(num, num2))
			{
				weightedQuickUnionUF.union(num, num2);
				StdOut.println(new StringBuilder().append(num).append(" ").append(num2).toString());
			}
		}
		StdOut.println(new StringBuilder().append(weightedQuickUnionUF.count()).append(" components").toString());
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
