public class FarthestPair
{
	private Point2D best1;
	private Point2D best2;
	private double bestDistance;
	
	
	public FarthestPair(Point2D[] pdarr)
	{
		this.bestDistance = double.NegativeInfinity;
		GrahamScan grahamScan = new GrahamScan(pdarr);
		if (pdarr.Length <= 1)
		{
			return;
		}
		int num = 0;
		Iterator iterator = grahamScan.hull().iterator();
		while (iterator.hasNext())
		{
			Point2D arg_46_0 = (Point2D)iterator.next();
			num++;
		}
		Point2D[] array = new Point2D[num + 1];
		int num2 = 1;
		Iterator iterator2 = grahamScan.hull().iterator();
		while (iterator2.hasNext())
		{
			Point2D point2D = (Point2D)iterator2.next();
			Point2D[] arg_8A_0 = array;
			int arg_8A_1 = num2;
			num2++;
			arg_8A_0[arg_8A_1] = point2D;
		}
		if (num == 1)
		{
			return;
		}
		if (num == 2)
		{
			this.best1 = array[1];
			this.best2 = array[2];
			this.bestDistance = this.best1.distanceTo(this.best2);
			return;
		}
		int num3 = 2;
		while (Point2D.area2(array[num], array[num3 + 1], array[1]) > Point2D.area2(array[num], array[num3], array[1]))
		{
			num3++;
		}
		int num4 = num3;
		for (int i = 1; i <= num3; i++)
		{
			if (array[i].distanceTo(array[num4]) > this.bestDistance)
			{
				this.best1 = array[i];
				this.best2 = array[num4];
				this.bestDistance = array[i].distanceTo(array[num4]);
			}
			while (num4 < num && Point2D.area2(array[i], array[num4 + 1], array[i + 1]) > Point2D.area2(array[i], array[num4], array[i + 1]))
			{
				num4++;
				double num5 = array[i].distanceTo(array[num4]);
				if (num5 > this.bestDistance)
				{
					this.best1 = array[i];
					this.best2 = array[num4];
					this.bestDistance = array[i].distanceTo(array[num4]);
				}
			}
		}
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
			int num2 = StdIn.readInt();
			int num3 = StdIn.readInt();
			array[i] = new Point2D((double)num2, (double)num3);
		}
		FarthestPair farthestPair = new FarthestPair(array);
		StdOut.println(new StringBuilder().append(farthestPair.distance()).append(" from ").append(farthestPair.either()).append(" to ").append(farthestPair.other()).toString());
	}
}