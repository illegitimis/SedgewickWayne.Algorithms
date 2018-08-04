//[Signature("<Key::Ljava/lang/Comparable<TKey;>;Value:Ljava/lang/Object;>Ljava/lang/Object;")]
public class BTree
{
	/*[EnclosingMethod("BTree", null, null), InnerClass(null, Modifiers.Static | Modifiers.Synthetic), Modifiers(Modifiers.Super | Modifiers.Synthetic), SourceFile("BTree.java")]*/
	
	[InnerClass(null, Modifiers.Private | Modifiers.Static), Modifiers(Modifiers.Super), SourceFile("BTree.java")]
	internal sealed class Entry
	{
		private IComparable key;
		private object value;
		private BTree.Node next;
/*		[LineNumberTable(32), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static IComparable access_300(BTree.Entry entry)
		{
			return entry.key;
		}
/*		[LineNumberTable(32), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static object access_400(BTree.Entry entry)
		{
			return entry.value;
		}
/*		[LineNumberTable(32), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static BTree.Node access_500(BTree.Entry entry)
		{
			return entry.next;
		}
		
		
		public Entry(IComparable comparable, object obj, BTree.Node node)
		{
			this.key = comparable;
			this.value = obj;
			this.next = node;
		}
/*		[LineNumberTable(32), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static IComparable access_302(BTree.Entry entry, IComparable result)
		{
			entry.key = result;
			return result;
		}
/*		[LineNumberTable(32), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static BTree.Node access_502(BTree.Entry entry, BTree.Node result)
		{
			entry.next = result;
			return result;
		}
	}
	[InnerClass(null, Modifiers.Private | Modifiers.Static | Modifiers.Final), SourceFile("BTree.java")]
	internal sealed class Node
	{
		private int m;
		private BTree.Entry[] children;
/*		[LineNumberTable(24), Modifiers(Modifiers.Synthetic)]*/
		
		internal Node(int num, BTree.1) : this(num)
		{
		}
/*		[LineNumberTable(24), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static BTree.Entry[] access_100(BTree.Node node)
		{
			return node.children;
		}
/*		[LineNumberTable(24), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static int access_200(BTree.Node node)
		{
			return node.m;
		}
/*		[LineNumberTable(24), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static int access_208(BTree.Node node)
		{
			int num = node.m;
			int arg_13_0 = num;
			node.m = num + 1;
			return arg_13_0;
		}
/*		[LineNumberTable(24), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static int access_202(BTree.Node node, int result)
		{
			node.m = result;
			return result;
		}
		
		
		private Node(int num)
		{
			this.children = new BTree.Entry[4];
			this.m = num;
		}
	}
	private const int M = 4;
	private BTree.Node root;
	private int HT;
	private int N;
/*	[Signature("(LBTree$Node;TKey;I)TValue;")]*/
	
	private object search(BTree.Node node, IComparable comparable, int num)
	{
		BTree.Entry[] array = BTree.Node.access_100(node);
		if (num == 0)
		{
			for (int i = 0; i < BTree.Node.access_200(node); i++)
			{
				if (this.eq(comparable, BTree.Entry.access_300(array[i])))
				{
					return BTree.Entry.access_400(array[i]);
				}
			}
		}
		else
		{
			for (int i = 0; i < BTree.Node.access_200(node); i++)
			{
				if (i + 1 == BTree.Node.access_200(node) || this.less(comparable, BTree.Entry.access_300(array[i + 1])))
				{
					return this.search(BTree.Entry.access_500(array[i]), comparable, num - 1);
				}
			}
		}
		return null;
	}
	
	
	private bool eq(IComparable o, IComparable comparable)
	{
		return Comparable.__Helper.compareTo(o, comparable) == 0;
	}
	
	
	private bool less(IComparable o, IComparable comparable)
	{
		return Comparable.__Helper.compareTo(o, comparable) < 0;
	}
/*	[Signature("(LBTree$Node;TKey;TValue;I)LBTree$Node;")]*/
	
	private BTree.Node insert(BTree.Node node, IComparable comparable, object obj, int num)
	{
		BTree.Entry entry = new BTree.Entry(comparable, obj, null);
		int i;
		if (num == 0)
		{
			for (i = 0; i < BTree.Node.access_200(node); i++)
			{
				if (this.less(comparable, BTree.Entry.access_300(BTree.Node.access_100(node)[i])))
				{
					break;
				}
			}
		}
		else
		{
			i = 0;
			while (i < BTree.Node.access_200(node))
			{
				if (i + 1 == BTree.Node.access_200(node) || this.less(comparable, BTree.Entry.access_300(BTree.Node.access_100(node)[i + 1])))
				{
					BTree.Entry[] arg_79_0 = BTree.Node.access_100(node);
					int arg_79_1 = i;
					i++;
					BTree.Node node2 = this.insert(BTree.Entry.access_500(arg_79_0[arg_79_1]), comparable, obj, num - 1);
					if (node2 == null)
					{
						return null;
					}
					BTree.Entry.access_302(entry, BTree.Entry.access_300(BTree.Node.access_100(node2)[0]));
					BTree.Entry.access_502(entry, node2);
					break;
				}
				else
				{
					i++;
				}
			}
		}
		for (int j = BTree.Node.access_200(node); j > i; j += -1)
		{
			BTree.Node.access_100(node)[j] = BTree.Node.access_100(node)[j - 1];
		}
		BTree.Node.access_100(node)[i] = entry;
		BTree.Node.access_208(node);
		if (BTree.Node.access_200(node) < 4)
		{
			return null;
		}
		return this.split(node);
	}
	
	
	private BTree.Node split(BTree.Node node)
	{
		BTree.Node node2 = new BTree.Node(2, null);
		BTree.Node.access_202(node, 2);
		for (int i = 0; i < 2; i++)
		{
			BTree.Node.access_100(node2)[i] = BTree.Node.access_100(node)[2 + i];
		}
		return node2;
	}
	
	
	private string toString(BTree.Node node, int num, string str)
	{
		string text = "";
		BTree.Entry[] array = BTree.Node.access_100(node);
		if (num == 0)
		{
			for (int i = 0; i < BTree.Node.access_200(node); i++)
			{
				text = new StringBuilder().append(text).append(str).append(BTree.Entry.access_300(array[i])).append(" ").append(BTree.Entry.access_400(array[i])).append("\n").toString();
			}
		}
		else
		{
			for (int i = 0; i < BTree.Node.access_200(node); i++)
			{
				if (i > 0)
				{
					text = new StringBuilder().append(text).append(str).append("(").append(BTree.Entry.access_300(array[i])).append(")\n").toString();
				}
				text = new StringBuilder().append(text).append(this.toString(BTree.Entry.access_500(array[i]), num - 1, new StringBuilder().append(str).append("     ").toString())).toString();
			}
		}
		return text;
	}
	
	
	public BTree()
	{
		this.root = new BTree.Node(0, null);
	}
/*	[Signature("(TKey;TValue;)V")]*/
	
	public virtual void put(IComparable c, object obj)
	{
		BTree.Node node = this.insert(this.root, c, obj, this.HT);
		this.N++;
		if (node == null)
		{
			return;
		}
		BTree.Node node2 = new BTree.Node(2, null);
		BTree.Node.access_100(node2)[0] = new BTree.Entry(BTree.Entry.access_300(BTree.Node.access_100(this.root)[0]), null, this.root);
		BTree.Node.access_100(node2)[1] = new BTree.Entry(BTree.Entry.access_300(BTree.Node.access_100(node)[0]), null, node);
		this.root = node2;
		this.HT++;
	}
/*	[LineNumberTable(54), Signature("(TKey;)TValue;")]*/
	
	public virtual object get(IComparable c)
	{
		return this.search(this.root, c, this.HT);
	}
	public virtual int size()
	{
		return this.N;
	}
	public virtual int height()
	{
		return this.HT;
	}
	
	
	public override string ToString()
	{
		return new StringBuilder().append(this.toString(this.root, this.HT, "")).append("\n").toString();
	}
	
	
	/**/public static void main(string[] strarr)
	{
		BTree bTree = new BTree();
		bTree.put("www.cs.princeton.edu", "128.112.136.11");
		bTree.put("www.princeton.edu", "128.112.128.15");
		bTree.put("www.yale.edu", "130.132.143.21");
		bTree.put("www.simpsons.com", "209.052.165.60");
		bTree.put("www.apple.com", "17.112.152.32");
		bTree.put("www.amazon.com", "207.171.182.16");
		bTree.put("www.ebay.com", "66.135.192.87");
		bTree.put("www.cnn.com", "64.236.16.20");
		bTree.put("www.google.com", "216.239.41.99");
		bTree.put("www.nytimes.com", "199.239.136.200");
		bTree.put("www.microsoft.com", "207.126.99.140");
		bTree.put("www.dell.com", "143.166.224.230");
		bTree.put("www.slashdot.org", "66.35.250.151");
		bTree.put("www.espn.com", "199.181.135.201");
		bTree.put("www.weather.com", "63.111.66.11");
		bTree.put("www.yahoo.com", "216.109.118.65");
		StdOut.println(new StringBuilder().append("cs.princeton.edu:  ").append((string)bTree.get("www.cs.princeton.edu")).toString());
		StdOut.println(new StringBuilder().append("hardvardsucks.com: ").append((string)bTree.get("www.harvardsucks.com")).toString());
		StdOut.println(new StringBuilder().append("simpsons.com:      ").append((string)bTree.get("www.simpsons.com")).toString());
		StdOut.println(new StringBuilder().append("apple.com:         ").append((string)bTree.get("www.apple.com")).toString());
		StdOut.println(new StringBuilder().append("ebay.com:          ").append((string)bTree.get("www.ebay.com")).toString());
		StdOut.println(new StringBuilder().append("dell.com:          ").append((string)bTree.get("www.dell.com")).toString());
		StdOut.println();
		StdOut.println(new StringBuilder().append("size:    ").append(bTree.size()).toString());
		StdOut.println(new StringBuilder().append("height:  ").append(bTree.height()).toString());
		StdOut.println(bTree);
		StdOut.println();
	}
}