
//[Signature("<Key:Ljava/lang/Object;Value:Ljava/lang/Object;>Ljava/lang/Object;")]
public class LinearProbingHashST
{
	private const int INIT_CAPACITY = 4;
	private int N;
	private int M;
//[Signature("[TKey;")]
	private object[] keys;
//[Signature("[TValue;")]
	private object[] vals;
//[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
	internal static bool s_assertionsDisabled;
	
	
	
	
	public LinearProbingHashST(int i)
	{
		this.M = i;
		this.keys = (object[])new object[this.M];
		this.vals = (object[])new object[this.M];
	}
	public virtual int size()
	{
		return this.N;
	}
/*	[Signature("(TKey;)TValue;")]*/
	
	public virtual object get(object obj)
	{
		int num = this.hash(obj);
		while (this.keys[num] != null)
		{
			if (java.lang.Object.instancehelper_equals(this.keys[num], obj))
			{
				return this.vals[num];
			}
			int expr_2D = num + 1;
			int expr_34 = this.M;
			num = ((expr_34 != -1) ? (expr_2D % expr_34) : 0);
		}
		return null;
	}
/*	[Signature("(TKey;TValue;)V")]*/
	
	public virtual void put(object obj1, object obj2)
	{
		if (obj2 == null)
		{
			this.delete(obj1);
		}
		if (this.N >= this.M / 2)
		{
			this.resize(2 * this.M);
		}
		int num = this.hash(obj1);
		while (this.keys[num] != null)
		{
			if (java.lang.Object.instancehelper_equals(this.keys[num], obj1))
			{
				this.vals[num] = obj2;
				return;
			}
			int expr_56 = num + 1;
			int expr_5D = this.M;
			num = ((expr_5D != -1) ? (expr_56 % expr_5D) : 0);
		}
		this.keys[num] = obj1;
		this.vals[num] = obj2;
		this.N++;
	}
/*	[Signature("(TKey;)V")]*/
	
	public virtual void delete(object obj)
	{
		if (!this.contains(obj))
		{
			return;
		}
		int num = this.hash(obj);
		while (!java.lang.Object.instancehelper_equals(obj, this.keys[num]))
		{
			int expr_24 = num + 1;
			int expr_2B = this.M;
			num = ((expr_2B != -1) ? (expr_24 % expr_2B) : 0);
		}
		this.keys[num] = null;
		this.vals[num] = null;
		int expr_4C = num + 1;
		int expr_53 = this.M;
		num = ((expr_53 != -1) ? (expr_4C % expr_53) : 0);
		while (this.keys[num] != null)
		{
			object obj2 = this.keys[num];
			object obj3 = this.vals[num];
			this.keys[num] = null;
			this.vals[num] = null;
			this.N--;
			this.put(obj2, obj3);
			int expr_A4 = num + 1;
			int expr_AB = this.M;
			num = ((expr_AB != -1) ? (expr_A4 % expr_AB) : 0);
		}
		this.N--;
		if (this.N > 0 && this.N <= this.M / 8)
		{
			this.resize(this.M / 2);
		}
		if (!LinearProbingHashST.s_assertionsDisabled && !this.check())
		{
			
			throw new AssertionError();
		}
	}
	
	
	private void resize(int i)
	{
		LinearProbingHashST linearProbingHashST = new LinearProbingHashST(i);
		for (int j = 0; j < this.M; j++)
		{
			if (this.keys[j] != null)
			{
				linearProbingHashST.put(this.keys[j], this.vals[j]);
			}
		}
		this.keys = linearProbingHashST.keys;
		this.vals = linearProbingHashST.vals;
		this.M = linearProbingHashST.M;
	}
/*	[LineNumberTable(54), Signature("(TKey;)I")]*/
	
	private int hash(object this2)
	{
		int expr_0B = java.lang.Object.instancehelper_hashCode(this2) & 2147483647;
		int expr_12 = this.M;
		return (expr_12 != -1) ? (expr_0B % expr_12) : 0;
	}
/*	[LineNumberTable(49), Signature("(TKey;)Z")]*/
	
	public virtual bool contains(object obj)
	{
		return this.get(obj) != null;
	}
	
	
	private bool check()
	{
		if (this.M < 2 * this.N)
		{
			System.err.println(new StringBuilder().append("Hash table size M = ").append(this.M).append("; array size N = ").append(this.N).toString());
			return false;
		}
		for (int i = 0; i < this.M; i++)
		{
			if (this.keys[i] != null)
			{
				if (this.get(this.keys[i]) != this.vals[i])
				{
					System.err.println(new StringBuilder().append("get[").append(this.keys[i]).append("] = ").append(this.get(this.keys[i])).append("; vals[i] = ").append(this.vals[i]).toString());
					return false;
				}
			}
		}
		return true;
	}
	
	
	public LinearProbingHashST() : this(4)
	{
	}
/*	[Signature("()Ljava/lang/Iterable<TKey;>;")]*/
	
	public virtual Iterable keys()
	{
		Queue queue = new Queue();
		for (int i = 0; i < this.M; i++)
		{
			if (this.keys[i] != null)
			{
				queue.enqueue(this.keys[i]);
			}
		}
		return queue;
	}
	
	
	public virtual bool isEmpty()
	{
		return this.size() == 0;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		LinearProbingHashST linearProbingHashST = new LinearProbingHashST();
		int num = 0;
		while (!StdIn.isEmpty())
		{
			string text = StdIn.readString();
			linearProbingHashST.put(text, Integer.valueOf(num));
			num++;
		}
		Iterator iterator = linearProbingHashST.keys().iterator();
		while (iterator.hasNext())
		{
			string text = (string)iterator.next();
			StdOut.println(new StringBuilder().append(text).append(" ").append(linearProbingHashST.get(text)).toString());
		}
	}
	
	static LinearProbingHashST()
	{
		LinearProbingHashST.s_assertionsDisabled = !ClassLiteral<LinearProbingHashST>.Value.desiredAssertionStatus();
	}
}





public class LinearRegression
{
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private int N;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private double alpha;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private double beta;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private double R2;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private double svar;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private double svar0;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private double svar1;
	public virtual double slope()
	{
		return this.beta;
	}
	public virtual double intercept()
	{
		return this.alpha;
	}
	public virtual double R2()
	{
		return this.R2;
	}
	
	
	public LinearRegression(double[] darr1, double[] darr2)
	{
		if (darr1.Length != darr2.Length)
		{
			string arg_18_0 = "array lengths are not equal";
			
			throw new ArgumentException(arg_18_0);
		}
		this.N = darr1.Length;
		double num = (double)0f;
		double num2 = (double)0f;
		double num3 = (double)0f;
		for (int i = 0; i < this.N; i++)
		{
			num += darr1[i];
		}
		for (int i = 0; i < this.N; i++)
		{
			num3 += darr1[i] * darr1[i];
		}
		for (int i = 0; i < this.N; i++)
		{
			num2 += darr2[i];
		}
		double num4 = num / (double)this.N;
		double num5 = num2 / (double)this.N;
		double num6 = (double)0f;
		double num7 = (double)0f;
		double num8 = (double)0f;
		for (int j = 0; j < this.N; j++)
		{
			num6 += (darr1[j] - num4) * (darr1[j] - num4);
			num7 += (darr2[j] - num5) * (darr2[j] - num5);
			num8 += (darr1[j] - num4) * (darr2[j] - num5);
		}
		this.beta = num8 / num6;
		this.alpha = num5 - this.beta * num4;
		double num9 = (double)0f;
		double num10 = (double)0f;
		int k;
		for (k = 0; k < this.N; k++)
		{
			double num11 = this.beta * darr1[k] + this.alpha;
			num9 += (num11 - darr2[k]) * (num11 - darr2[k]);
			num10 += (num11 - num5) * (num11 - num5);
		}
		k = this.N - 2;
		this.R2 = num10 / num7;
		this.svar = num9 / (double)k;
		this.svar1 = this.svar / num6;
		this.svar0 = this.svar / (double)this.N + num4 * num4 * this.svar1;
	}
	
	
	public virtual double interceptStdErr()
	{
		return java.lang.Math.sqrt(this.svar0);
	}
	
	
	public virtual double slopeStdErr()
	{
		return java.lang.Math.sqrt(this.svar1);
	}
	public virtual double predict(double d)
	{
		return this.beta * d + this.alpha;
	}
	
	
	public override string ToString()
	{
		string str = "";
		str = new StringBuilder().append(str).append(java.lang.String.format("%.2f N + %.2f", new object[]
		{
			java.lang.Double.valueOf(this.slope()),
			java.lang.Double.valueOf(this.intercept())
		})).toString();
		return new StringBuilder().append(str).append("  (R^2 = ").append(java.lang.String.format("%.3f", new object[]
		{
			java.lang.Double.valueOf(this.R2())
		})).append(")").toString();
	}
}
