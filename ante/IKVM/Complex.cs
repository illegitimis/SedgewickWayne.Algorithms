public class Complex
{
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private double re;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private double im;
	
	
	public Complex(double d1, double d2)
	{
		this.re = d1;
		this.im = d2;
	}
	
	
	public virtual Complex reciprocal()
	{
		double num = this.re * this.re + this.im * this.im;
		return new Complex(this.re / num, -this.im / num);
	}
	
	
	public virtual Complex times(Complex c)
	{
		double d = this.re * c.re - this.im * c.im;
		double d2 = this.re * c.im + this.im * c.re;
		return new Complex(d, d2);
	}
	
	
	public virtual Complex sin()
	{
		return new Complex(java.lang.Math.sin(this.re) * java.lang.Math.cosh(this.im), java.lang.Math.cos(this.re) * java.lang.Math.sinh(this.im));
	}
	
	
	public virtual Complex cos()
	{
		return new Complex(java.lang.Math.cos(this.re) * java.lang.Math.cosh(this.im), -java.lang.Math.sin(this.re) * java.lang.Math.sinh(this.im));
	}
	
	
	public virtual Complex divides(Complex c)
	{
		return this.times(c.reciprocal());
	}
	public virtual double re()
	{
		return this.re;
	}
	public virtual double im()
	{
		return this.im;
	}
	
	
	public virtual Complex plus(Complex c)
	{
		double d = this.re + c.re;
		double d2 = this.im + c.im;
		return new Complex(d, d2);
	}
	
	
	public virtual Complex minus(Complex c)
	{
		double d = this.re - c.re;
		double d2 = this.im - c.im;
		return new Complex(d, d2);
	}
	
	
	public virtual Complex conjugate()
	{
		return new Complex(this.re, -this.im);
	}
	
	
	public virtual double abs()
	{
		return java.lang.Math.hypot(this.re, this.im);
	}
	
	
	public virtual Complex tan()
	{
		return this.sin().divides(this.cos());
	}
	
	
	public override string ToString()
	{
		if (this.im == (double)0f)
		{
			return new StringBuilder().append(this.re).append("").toString();
		}
		if (this.re == (double)0f)
		{
			return new StringBuilder().append(this.im).append("i").toString();
		}
		if (this.im < (double)0f)
		{
			return new StringBuilder().append(this.re).append(" - ").append(-this.im).append("i").toString();
		}
		return new StringBuilder().append(this.re).append(" + ").append(this.im).append("i").toString();
	}
	
	
	public virtual double phase()
	{
		return java.lang.Math.atan2(this.im, this.re);
	}
	
	
	public virtual Complex times(double d)
	{
		return new Complex(d * this.re, d * this.im);
	}
	
	
	public virtual Complex exp()
	{
		return new Complex(java.lang.Math.exp(this.re) * java.lang.Math.cos(this.im), java.lang.Math.exp(this.re) * java.lang.Math.sin(this.im));
	}
	
	
	public static Complex plus(Complex c1, Complex c2)
	{
		double d = c1.re + c2.re;
		double d2 = c1.im + c2.im;
		return new Complex(d, d2);
	}
	
	
	/**/public static void main(string[] strarr)
	{
		Complex complex = new Complex(5.0, 6.0);
		Complex complex2 = new Complex(-3.0, 4.0);
		StdOut.println(new StringBuilder().append("a            = ").append(complex).toString());
		StdOut.println(new StringBuilder().append("b            = ").append(complex2).toString());
		StdOut.println(new StringBuilder().append("Re(a)        = ").append(complex.re()).toString());
		StdOut.println(new StringBuilder().append("Im(a)        = ").append(complex.im()).toString());
		StdOut.println(new StringBuilder().append("b + a        = ").append(complex2.plus(complex)).toString());
		StdOut.println(new StringBuilder().append("a - b        = ").append(complex.minus(complex2)).toString());
		StdOut.println(new StringBuilder().append("a * b        = ").append(complex.times(complex2)).toString());
		StdOut.println(new StringBuilder().append("b * a        = ").append(complex2.times(complex)).toString());
		StdOut.println(new StringBuilder().append("a / b        = ").append(complex.divides(complex2)).toString());
		StdOut.println(new StringBuilder().append("(a / b) * b  = ").append(complex.divides(complex2).times(complex2)).toString());
		StdOut.println(new StringBuilder().append("conj(a)      = ").append(complex.conjugate()).toString());
		StdOut.println(new StringBuilder().append("|a|          = ").append(complex.abs()).toString());
		StdOut.println(new StringBuilder().append("tan(a)       = ").append(complex.tan()).toString());
	}
}