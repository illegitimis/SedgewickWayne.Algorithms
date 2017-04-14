public class ClosestPair
{
	private Point2D best1;
	private Point2D best2;
	private double bestDistance;
	
	
	private double closest(Point2D[] array, Point2D[] array2, Point2D[] array3, int num, int num2)
	{
		if (num2 <= num)
		{
			return double.PositiveInfinity;
		}
		int num3 = num + (num2 - num) / 2;
		Point2D point2D = array[num3];
		double a = this.closest(array, array2, array3, num, num3);
		double b = this.closest(array, array2, array3, num3 + 1, num2);
		double num4 = java.lang.Math.min(a, b);
		ClosestPair.merge(array2, array3, num, num3, num2);
		int num5 = 0;
		for (int i = num; i <= num2; i++)
		{
			if (java.lang.Math.abs(array2[i].x() - point2D.x()) < num4)
			{
				int arg_86_1 = num5;
				num5++;
				array3[arg_86_1] = array2[i];
			}
		}
		for (int i = 0; i < num5; i++)
		{
			int num6 = i + 1;
			while (num6 < num5 && array3[num6].y() - array3[i].y() < num4)
			{
				double num7 = array3[i].distanceTo(array3[num6]);
				if (num7 < num4)
				{
					num4 = num7;
					if (num7 < this.bestDistance)
					{
						this.bestDistance = num4;
						this.best1 = array3[i];
						this.best2 = array3[num6];
					}
				}
				num6++;
			}
		}
		return num4;
	}
	
	
	private static void merge(IComparable[] array, IComparable[] array2, int num, int num2, int num3)
	{
		int i;
		for (i = num; i <= num3; i++)
		{
			array2[i] = array[i];
		}
		i = num;
		int num4 = num2 + 1;
		for (int j = num; j <= num3; j++)
		{
			if (i > num2)
			{
				int arg_30_1 = j;
				int arg_2F_1 = num4;
				num4++;
				array[arg_30_1] = array2[arg_2F_1];
			}
			else if (num4 > num3)
			{
				int arg_41_1 = j;
				int arg_40_1 = i;
				i++;
				array[arg_41_1] = array2[arg_40_1];
			}
			else if (ClosestPair.less(array2[num4], array2[i]))
			{
				int arg_5A_1 = j;
				int arg_59_1 = num4;
				num4++;
				array[arg_5A_1] = array2[arg_59_1];
			}
			else
			{
				int arg_66_1 = j;
				int arg_65_1 = i;
				i++;
				array[arg_66_1] = array2[arg_65_1];
			}
		}
	}
	
	
	private static bool less(IComparable o, IComparable comparable)
	{
		return Comparable.__Helper.compareTo(o, comparable) < 0;
	}
	
	
	public ClosestPair(Point2D[] pdarr)
	{
		this.bestDistance = double.PositiveInfinity;
		int num = pdarr.Length;
		if (num <= 1)
		{
			return;
		}
		Point2D[] array = new Point2D[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = pdarr[i];
		}
		Arrays.sort(array, Point2D.__X_ORDER);
		for (int i = 0; i < num - 1; i++)
		{
			if (array[i].equals(array[i + 1]))
			{
				this.bestDistance = (double)0f;
				this.best1 = array[i];
				this.best2 = array[i + 1];
				return;
			}
		}
		Point2D[] array2 = new Point2D[num];
		for (int j = 0; j < num; j++)
		{
			array2[j] = array[j];
		}
		Point2D[] array3 = new Point2D[num];
		this.closest(array, array2, array3, 0, num - 1);
	}
	public virtual double distance()
	{
		return this.bestDistance;
	}
	public virtual Point2D either()
	{
		return this.best1;
	}
	public virtual Point2D other()
	{
		return this.best2;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		int num = StdIn.readInt();
		Point2D[] array = new Point2D[num];
		for (int i = 0; i < num; i++)
		{
			double d = StdIn.readDouble();
			double d2 = StdIn.readDouble();
			array[i] = new Point2D(d, d2);
		}
		ClosestPair closestPair = new ClosestPair(array);
		StdOut.println(new StringBuilder().append(closestPair.distance()).append(" from ").append(closestPair.either()).append(" to ").append(closestPair.other()).toString());
	}
}