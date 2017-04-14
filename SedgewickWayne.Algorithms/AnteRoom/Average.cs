public class Average
{
	
	
	private Average()
	{
	}
	
	
	/**/public static void main(string[] strarr)
	{
		int num = 0;
		double num2 = (double)0f;
		double num3;
		while (!StdIn.isEmpty())
		{
			num3 = StdIn.readDouble();
			num2 += num3;
			num++;
		}
		num3 = num2 / (double)num;
		StdOut.println(new StringBuilder().append("Average is ").append(num3).toString());
	}
}