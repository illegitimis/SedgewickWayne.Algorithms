public class FFT
{
	
	
	public static Complex[] fft(Complex[] carr)
	{
		int num = carr.Length;
		if (num == 1)
		{
			return new Complex[]
			{
				carr[0]
			};
		}
		bool expr_14 = num != 0;
		int expr_16 = 2;
		if (expr_16 != -1 && (expr_14 ? 1 : 0) % expr_16 != 0)
		{
			string arg_2C_0 = "N is not a power of 2";
			
			throw new ArgumentException(arg_2C_0);
		}
		Complex[] array = new Complex[num / 2];
		for (int i = 0; i < num / 2; i++)
		{
			array[i] = carr[2 * i];
		}
		Complex[] array2 = FFT.fft(array);
		Complex[] array3 = array;
		for (int j = 0; j < num / 2; j++)
		{
			array3[j] = carr[2 * j + 1];
		}
		Complex[] array4 = FFT.fft(array3);
		Complex[] array5 = new Complex[num];
		for (int k = 0; k < num / 2; k++)
		{
			double a = (double)(-2 * k) * 3.1415926535897931 / (double)num;
			Complex complex = new Complex(java.lang.Math.cos(a), java.lang.Math.sin(a));
			array5[k] = array2[k].plus(complex.times(array4[k]));
			array5[k + num / 2] = array2[k].minus(complex.times(array4[k]));
		}
		return array5;
	}
	
	
	public static Complex[] ifft(Complex[] carr)
	{
		int num = carr.Length;
		Complex[] array = new Complex[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = carr[i].conjugate();
		}
		array = FFT.fft(array);
		for (int i = 0; i < num; i++)
		{
			array[i] = array[i].conjugate();
		}
		for (int i = 0; i < num; i++)
		{
			array[i] = array[i].times((double)1f / (double)num);
		}
		return array;
	}
	
	
	public static Complex[] cconvolve(Complex[] carr1, Complex[] carr2)
	{
		if (carr1.Length != carr2.Length)
		{
			string arg_10_0 = "Dimensions don't agree";
			
			throw new ArgumentException(arg_10_0);
		}
		int num = carr1.Length;
		Complex[] array = FFT.fft(carr1);
		Complex[] array2 = FFT.fft(carr2);
		Complex[] array3 = new Complex[num];
		for (int i = 0; i < num; i++)
		{
			array3[i] = array[i].times(array2[i]);
		}
		return FFT.ifft(array3);
	}
	
	
	public static void show(Complex[] carr, string str)
	{
		StdOut.println(str);
		StdOut.println("-------------------");
		for (int i = 0; i < carr.Length; i++)
		{
			StdOut.println(carr[i]);
		}
		StdOut.println();
	}
	
	
	public static Complex[] convolve(Complex[] carr1, Complex[] carr2)
	{
		Complex complex = new Complex((double)0f, (double)0f);
		Complex[] array = new Complex[2 * carr1.Length];
		for (int i = 0; i < carr1.Length; i++)
		{
			array[i] = carr1[i];
		}
		for (int i = carr1.Length; i < 2 * carr1.Length; i++)
		{
			array[i] = complex;
		}
		Complex[] array2 = new Complex[2 * carr2.Length];
		for (int j = 0; j < carr2.Length; j++)
		{
			array2[j] = carr2[j];
		}
		for (int j = carr2.Length; j < 2 * carr2.Length; j++)
		{
			array2[j] = complex;
		}
		return FFT.cconvolve(array, array2);
	}
	
	
	public FFT()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		int num = Integer.parseInt(strarr[0]);
		Complex[] array = new Complex[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = new Complex((double)i, (double)0f);
			array[i] = new Complex(-2.0 * java.lang.Math.random() + (double)1f, (double)0f);
		}
		FFT.show(array, "x");
		Complex[] carr = FFT.fft(array);
		FFT.show(carr, "y = fft(x)");
		Complex[] carr2 = FFT.ifft(carr);
		FFT.show(carr2, "z = ifft(y)");
		Complex[] carr3 = FFT.cconvolve(array, array);
		FFT.show(carr3, "c = cconvolve(x, x)");
		Complex[] carr4 = FFT.convolve(array, array);
		FFT.show(carr4, "d = convolve(x, x)");
	}
}