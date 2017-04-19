





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
