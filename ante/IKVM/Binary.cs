using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BinaryDump
{


    public BinaryDump()
    {
    }


    /**/
    public static void main(string[] strarr)
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


    /**/
    public static void main(string[] strarr)
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


    /**/
    public static void main(string[] strarr)
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


    /**//**/
    public static void main(string[] strarr)
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


    /**//**/
    public static void main(string[] strarr)
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