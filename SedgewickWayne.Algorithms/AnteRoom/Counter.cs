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