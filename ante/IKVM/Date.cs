

/*[Implements(new string[]
{
	"java.lang.Comparable"
}), Signature("Ljava/lang/Object;Ljava/lang/Comparable<LDate;>;")]*/
public class Date : IComparable
{
//[Modifiers(Modifiers.Private | Modifiers.Static | Modifiers.Final)]
	private static int[] DAYS;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private int month;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private int day;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
	private int year;
	
	
	
	
	private static bool isValid(int num, int num2, int num3)
	{
		return num >= 1 && num <= 12 && num2 >= 1 && num2 <= Date.DAYS[num] && (num != 2 || num2 != 29 || Date.isLeapYear(num3));
	}
	
	private static bool isLeapYear(int num)
	{
		int expr_06 = 400;
		if (expr_06 == -1 || num % expr_06 == 0)
		{
			return true;
		}
		int expr_17 = 100;
		if (expr_17 == -1 || num % expr_17 == 0)
		{
			return false;
		}
		int expr_27 = 4;
		return expr_27 == -1 || num % expr_27 == 0;
	}
	
	
	public Date(int i1, int i2, int i3)
	{
		if (!Date.isValid(i1, i2, i3))
		{
			string arg_1C_0 = "Invalid date";
			
			throw new ArgumentException(arg_1C_0);
		}
		this.month = i1;
		this.day = i2;
		this.year = i3;
	}
	
	public virtual int compareTo(Date d)
	{
		if (this.year < d.year)
		{
			return -1;
		}
		if (this.year > d.year)
		{
			return 1;
		}
		if (this.month < d.month)
		{
			return -1;
		}
		if (this.month > d.month)
		{
			return 1;
		}
		if (this.day < d.day)
		{
			return -1;
		}
		if (this.day > d.day)
		{
			return 1;
		}
		return 0;
	}
	
	
	public Date Current { get }
	{
		if (Date.isValid(this.month, this.day + 1, this.year))
		{
			return new Date(this.month, this.day + 1, this.year);
		}
		if (Date.isValid(this.month + 1, 1, this.year))
		{
			return new Date(this.month + 1, 1, this.year);
		}
		return new Date(1, 1, this.year + 1);
	}
	
	
	public virtual bool isAfter(Date d)
	{
		return this.compareTo(d) > 0;
	}
	
	
	public Date(string str)
	{
		string[] array = java.lang.String.instancehelper_split(str, "/");
		if (array.Length != 3)
		{
			string arg_23_0 = "Invalid date";
			
			throw new ArgumentException(arg_23_0);
		}
		this.month = Integer.parseInt(array[0]);
		this.day = Integer.parseInt(array[1]);
		this.year = Integer.parseInt(array[2]);
		if (!Date.isValid(this.month, this.day, this.year))
		{
			string arg_76_0 = "Invalid date";
			
			throw new ArgumentException(arg_76_0);
		}
	}
	public virtual int month()
	{
		return this.month;
	}
	public virtual int day()
	{
		return this.day;
	}
	public virtual int year()
	{
		return this.year;
	}
	
	
	public virtual bool isBefore(Date d)
	{
		return this.compareTo(d) < 0;
	}
	
	
	public override string ToString()
	{
		return new StringBuilder().append(this.month).append("/").append(this.day).append("/").append(this.year).toString();
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
		Date date = (Date)obj;
		return this.month == date.month && this.day == date.day && this.year == date.year;
	}
	public override int hashCode()
	{
		int num = 17;
		num = 31 * num + this.month;
		num = 31 * num + this.day;
		return 31 * num + this.year;
	}
	
	
	/**/public static void main(string[] strarr)
	{
		Date date = new Date(2, 25, 2004);
		StdOut.println(date);
		for (int i = 0; i < 10; i++)
		{
			date = date.next();
			StdOut.println(date);
		}
		StdOut.println(date.isAfter(date.next()));
		StdOut.println(date.isAfter(date));
		StdOut.println(date.next().isAfter(date));
		Date date2 = new Date(10, 16, 1971);
		StdOut.println(date2);
		for (int j = 0; j < 10; j++)
		{
			date2 = date2.next();
			StdOut.println(date2);
		}
	}
/*	[LineNumberTable(19), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic), EditorBrowsable(EditorBrowsableState.Never)]*/
	
	public virtual int compareTo(object obj)
	{
		return this.compareTo((Date)obj);
	}
	
	static Date()
	{
		Date.DAYS = new int[]
		{
			0,
			31,
			29,
			31,
			30,
			31,
			30,
			31,
			31,
			30,
			31,
			30,
			31
		};
	}
	
	int IComparable.Object;)IcompareTo(object obj)
	{
		return this.compareTo(obj);
	}
}