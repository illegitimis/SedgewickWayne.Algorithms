// http://algs4.cs.princeton.edu/32bst/BST.java.html

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /**
 *  The {@code BST} class represents an ordered symbol table of generic key-value pairs.
 *  It supports the usual <em>put</em>, <em>get</em>, <em>contains</em>,
 *  <em>delete</em>, <em>size</em>, and <em>is-empty</em> methods.
 *  It also provides ordered methods for finding the <em>minimum</em>,
 *  <em>maximum</em>, <em>floor</em>, <em>select</em>, <em>ceiling</em>.
 *  It also provides a <em>keys</em> method for iterating over all of the keys.
 *  A symbol table implements the <em>associative array</em> abstraction:
 *  when associating a value with a key that is already in the symbol table,
 *  the convention is to replace the old value with the new value.
 *  Unlike {@link java.util.Map}, this class uses the convention that
 *  values cannot be {@code null}—setting the value associated with a key 
 *  to {@code null} is equivalent to deleting the key from the symbol table.
 *  
 *  This implementation uses an (UNBALANCED) BINARY SEARCH TREE.
 *  It requires that the key type implements the {@code Comparable} interface and calls the
 *  {@code compareTo()} and method to compare two keys. 
 *  It does not call either {@code equals()} or {@code hashCode()}.
 *  The <em>put</em>, <em>contains</em>, <em>remove</em>, <em>minimum</em>,
 *  <em>maximum</em>, <em>ceiling</em>, <em>floor</em>, <em>select</em>, and
 *  <em>rank</em>  operations each take linear time in the worst case, 
 *  if the tree becomes unbalanced. 
 *  The <em>size</em>, and <em>is-empty</em> operations take constant time.
 *  Construction takes constant time.
 *  
 *  For additional documentation, see <a href="http://algs4.cs.princeton.edu/32bst">Section 3.2</a> of
 *  <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.
 *  For other implementations, see {@link ST}, {@link BinarySearchST},
 *  {@link SequentialSearchST}, {@link RedBlackBST},
 *  {@link SeparateChainingHashST}, and {@link LinearProbingHashST},
 *
 *  @author Robert Sedgewick
 *  @author Kevin Wayne
 */

    public class BST<Key, Value>
      : IOrderedSymbolTable<Key, Value>
      where Key : IComparable<Key>, IEquatable<Key>
      where Value : IEquatable<Value>
    {
        public bool IsEmpty
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Key Max
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Key Min
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Size
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Key Ceiling(Key key)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Key key)
        {
            throw new NotImplementedException();
        }

        public void Delete(Key key)
        {
            throw new NotImplementedException();
        }

        public void DeleteMax()
        {
            throw new NotImplementedException();
        }

        public void DeleteMin()
        {
            throw new NotImplementedException();
        }

        public Key Floor(Key key)
        {
            throw new NotImplementedException();
        }

        public Value Get(Key key)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Key> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Put(Key key, Value val)
        {
            throw new NotImplementedException();
        }

        public int RangeSize(Key lo, Key hi)
        {
            throw new NotImplementedException();
        }

        public int Rank(Key key)
        {
            throw new NotImplementedException();
        }

        public Key Select(int k)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}



////[Signature("<Key::Ljava/lang/Comparable<TKey;>;Value:Ljava/lang/Object;>Ljava/lang/Object;")]
//public class BST
//{
//	[InnerClass(null, Modifiers.Private), Modifiers(Modifiers.Super), SourceFile("BST.java")]
//	internal sealed class Node
//	{
////[Signature("TKey;")]
//		private IComparable key;
////[Signature("TValue;")]
//		private object val;
////[Signature("LBST<TKey;TValue;>.Node;")]
//		private BST.Node left;
////[Signature("LBST<TKey;TValue;>.Node;")]
//		private BST.Node right;
//		private int N;
////[Modifiers(Modifiers.Final | Modifiers.Synthetic)]
//		internal BST bST;
///*		[LineNumberTable(31), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
//		internal static int access_000(BST.Node node)
//		{
//			return node.N;
//		}
///*		[LineNumberTable(31), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
//		internal static IComparable access_100(BST.Node node)
//		{
//			return node.key;
//		}
///*		[LineNumberTable(31), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
//		internal static BST.Node access_200(BST.Node node)
//		{
//			return node.left;
//		}
///*		[LineNumberTable(31), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
//		internal static BST.Node access_300(BST.Node node)
//		{
//			return node.right;
//		}
///*		[LineNumberTable(31), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
//		internal static object access_400(BST.Node node)
//		{
//			return node.val;
//		}
///*		[Signature("(TKey;TValue;I)V")]*/

//		public Node(BST bST, IComparable comparable, object obj, int n)
//		{
//			this.key = comparable;
//			this.val = obj;
//			this.N = n;
//		}
///*		[LineNumberTable(31), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
//		internal static BST.Node access_202(BST.Node node, BST.Node result)
//		{
//			node.left = result;
//			return result;
//		}
///*		[LineNumberTable(31), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
//		internal static BST.Node access_302(BST.Node node, BST.Node result)
//		{
//			node.right = result;
//			return result;
//		}
///*		[LineNumberTable(31), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
//		internal static object access_402(BST.Node node, object result)
//		{
//			node.val = result;
//			return result;
//		}
///*		[LineNumberTable(31), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
//		internal static int access_002(BST.Node node, int num)
//		{
//			node.N = num;
//			return num;
//		}
//	}
////[Signature("LBST<TKey;TValue;>.Node;")]
//	private BST.Node root;
////[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
//	internal static bool s_assertionsDisabled;




//	public virtual int size()
//	{
//		return this.size(this.root);
//	}
///*	[Signature("(LBST<TKey;TValue;>.Node;)I")]*/

//	private int size(BST.Node node)
//	{
//		if (node == null)
//		{
//			return 0;
//		}
//		return BST.Node.access_000(node);
//	}
///*	[LineNumberTable(71), Signature("(TKey;)TValue;")]*/

//	public virtual object get(IComparable c)
//	{
//		return this.get(this.root, c);
//	}
///*	[Signature("(LBST<TKey;TValue;>.Node;TKey;)TValue;")]*/

//	private object get(BST.Node node, IComparable comparable)
//	{
//		if (node == null)
//		{
//			return null;
//		}
//		int num = Comparable.__Helper.compareTo(comparable, BST.Node.access_100(node));
//		if (num < 0)
//		{
//			return this.get(BST.Node.access_200(node), comparable);
//		}
//		if (num > 0)
//		{
//			return this.get(BST.Node.access_300(node), comparable);
//		}
//		return BST.Node.access_400(node);
//	}
///*	[Signature("(TKey;)V")]*/

//	public virtual void delete(IComparable c)
//	{
//		this.root = this.delete(this.root, c);
//		if (!BST.s_assertionsDisabled && !this.check())
//		{

//			throw new AssertionError();
//		}
//	}
///*	[Signature("(LBST<TKey;TValue;>.Node;TKey;TValue;)LBST<TKey;TValue;>.Node;")]*/

//	private BST.Node put(BST.Node node, IComparable comparable, object obj)
//	{
//		if (node == null)
//		{
//			return new BST.Node(this, comparable, obj, 1);
//		}
//		int num = Comparable.__Helper.compareTo(comparable, BST.Node.access_100(node));
//		if (num < 0)
//		{
//			BST.Node.access_202(node, this.put(BST.Node.access_200(node), comparable, obj));
//		}
//		else if (num > 0)
//		{
//			BST.Node.access_302(node, this.put(BST.Node.access_300(node), comparable, obj));
//		}
//		else
//		{
//			BST.Node.access_402(node, obj);
//		}
//		BST.Node.access_002(node, 1 + this.size(BST.Node.access_200(node)) + this.size(BST.Node.access_300(node)));
//		return node;
//	}


//	private bool check()
//	{
//		if (!this.isBST())
//		{
//			StdOut.println("Not in symmetric order");
//		}
//		if (!this.isSizeConsistent())
//		{
//			StdOut.println("Subtree counts not consistent");
//		}
//		if (!this.isRankConsistent())
//		{
//			StdOut.println("Ranks not consistent");
//		}
//		return this.isBST() && this.isSizeConsistent() && this.isRankConsistent();
//	}


//	public virtual bool isEmpty()
//	{
//		return this.size() == 0;
//	}
///*	[Signature("(LBST<TKey;TValue;>.Node;)LBST<TKey;TValue;>.Node;")]*/

//	private BST.Node deleteMin(BST.Node node)
//	{
//		if (BST.Node.access_200(node) == null)
//		{
//			return BST.Node.access_300(node);
//		}
//		BST.Node.access_202(node, this.deleteMin(BST.Node.access_200(node)));
//		BST.Node.access_002(node, this.size(BST.Node.access_200(node)) + this.size(BST.Node.access_300(node)) + 1);
//		return node;
//	}
///*	[Signature("(LBST<TKey;TValue;>.Node;)LBST<TKey;TValue;>.Node;")]*/

//	private BST.Node deleteMax(BST.Node node)
//	{
//		if (BST.Node.access_300(node) == null)
//		{
//			return BST.Node.access_200(node);
//		}
//		BST.Node.access_302(node, this.deleteMax(BST.Node.access_300(node)));
//		BST.Node.access_002(node, this.size(BST.Node.access_200(node)) + this.size(BST.Node.access_300(node)) + 1);
//		return node;
//	}
///*	[Signature("(LBST<TKey;TValue;>.Node;TKey;)LBST<TKey;TValue;>.Node;")]*/

//	private BST.Node delete(BST.Node node, IComparable comparable)
//	{
//		if (node == null)
//		{
//			return null;
//		}
//		int num = Comparable.__Helper.compareTo(comparable, BST.Node.access_100(node));
//		if (num < 0)
//		{
//			BST.Node.access_202(node, this.delete(BST.Node.access_200(node), comparable));
//		}
//		else if (num > 0)
//		{
//			BST.Node.access_302(node, this.delete(BST.Node.access_300(node), comparable));
//		}
//		else
//		{
//			if (BST.Node.access_300(node) == null)
//			{
//				return BST.Node.access_200(node);
//			}
//			if (BST.Node.access_200(node) == null)
//			{
//				return BST.Node.access_300(node);
//			}
//			BST.Node node2 = node;
//			node = this.min(BST.Node.access_300(node2));
//			BST.Node.access_302(node, this.deleteMin(BST.Node.access_300(node2)));
//			BST.Node.access_202(node, BST.Node.access_200(node2));
//		}
//		BST.Node.access_002(node, this.size(BST.Node.access_200(node)) + this.size(BST.Node.access_300(node)) + 1);
//		return node;
//	}
///*	[Signature("(LBST<TKey;TValue;>.Node;)LBST<TKey;TValue;>.Node;")]*/

//	private BST.Node min(BST.Node node)
//	{
//		if (BST.Node.access_200(node) == null)
//		{
//			return node;
//		}
//		return this.min(BST.Node.access_200(node));
//	}
///*	[Signature("(LBST<TKey;TValue;>.Node;)LBST<TKey;TValue;>.Node;")]*/

//	private BST.Node max(BST.Node node)
//	{
//		if (BST.Node.access_300(node) == null)
//		{
//			return node;
//		}
//		return this.max(BST.Node.access_300(node));
//	}
///*	[Signature("(LBST<TKey;TValue;>.Node;TKey;)LBST<TKey;TValue;>.Node;")]*/

//	private BST.Node floor(BST.Node node, IComparable comparable)
//	{
//		if (node == null)
//		{
//			return null;
//		}
//		int num = Comparable.__Helper.compareTo(comparable, BST.Node.access_100(node));
//		if (num == 0)
//		{
//			return node;
//		}
//		if (num < 0)
//		{
//			return this.floor(BST.Node.access_200(node), comparable);
//		}
//		BST.Node node2 = this.floor(BST.Node.access_300(node), comparable);
//		if (node2 != null)
//		{
//			return node2;
//		}
//		return node;
//	}
///*	[Signature("(LBST<TKey;TValue;>.Node;TKey;)LBST<TKey;TValue;>.Node;")]*/

//	private BST.Node ceiling(BST.Node node, IComparable comparable)
//	{
//		if (node == null)
//		{
//			return null;
//		}
//		int num = Comparable.__Helper.compareTo(comparable, BST.Node.access_100(node));
//		if (num == 0)
//		{
//			return node;
//		}
//		if (num >= 0)
//		{
//			return this.ceiling(BST.Node.access_300(node), comparable);
//		}
//		BST.Node node2 = this.ceiling(BST.Node.access_200(node), comparable);
//		if (node2 != null)
//		{
//			return node2;
//		}
//		return node;
//	}
///*	[Signature("(LBST<TKey;TValue;>.Node;I)LBST<TKey;TValue;>.Node;")]*/

//	private BST.Node select(BST.Node node, int num)
//	{
//		if (node == null)
//		{
//			return null;
//		}
//		int num2 = this.size(BST.Node.access_200(node));
//		if (num2 > num)
//		{
//			return this.select(BST.Node.access_200(node), num);
//		}
//		if (num2 < num)
//		{
//			return this.select(BST.Node.access_300(node), num - num2 - 1);
//		}
//		return node;
//	}
///*	[Signature("(TKey;LBST<TKey;TValue;>.Node;)I")]*/

//	private int rank(IComparable comparable, BST.Node node)
//	{
//		if (node == null)
//		{
//			return 0;
//		}
//		int num = Comparable.__Helper.compareTo(comparable, BST.Node.access_100(node));
//		if (num < 0)
//		{
//			return this.rank(comparable, BST.Node.access_200(node));
//		}
//		if (num > 0)
//		{
//			return 1 + this.size(BST.Node.access_200(node)) + this.rank(comparable, BST.Node.access_300(node));
//		}
//		return this.size(BST.Node.access_200(node));
//	}
///*	[Signature("()TKey;")]*/

//	public virtual IComparable min()
//	{
//		if (this.isEmpty())
//		{
//			return null;
//		}
//		return BST.Node.access_100(this.min(this.root));
//	}
///*	[Signature("()TKey;")]*/

//	public virtual IComparable max()
//	{
//		if (this.isEmpty())
//		{
//			return null;
//		}
//		return BST.Node.access_100(this.max(this.root));
//	}
///*	[Signature("(TKey;TKey;)Ljava/lang/Iterable<TKey;>;")]*/

//	public virtual Iterable keys(IComparable c1, IComparable c2)
//	{
//		Queue queue = new Queue();
//		this.keys(this.root, queue, c1, c2);
//		return queue;
//	}
///*	[Signature("(LBST<TKey;TValue;>.Node;LQueue<TKey;>;TKey;TKey;)V")]*/

//	private void keys(BST.Node node, Queue queue, IComparable comparable, IComparable comparable2)
//	{
//		if (node == null)
//		{
//			return;
//		}
//		int num = Comparable.__Helper.compareTo(comparable, BST.Node.access_100(node));
//		int num2 = Comparable.__Helper.compareTo(comparable2, BST.Node.access_100(node));
//		if (num < 0)
//		{
//			this.keys(BST.Node.access_200(node), queue, comparable, comparable2);
//		}
//		if (num <= 0 && num2 >= 0)
//		{
//			queue.enqueue(BST.Node.access_100(node));
//		}
//		if (num2 > 0)
//		{
//			this.keys(BST.Node.access_300(node), queue, comparable, comparable2);
//		}
//	}
///*	[LineNumberTable(66), Signature("(TKey;)Z")]*/

//	public virtual bool contains(IComparable c)
//	{
//		return this.get(c) != null;
//	}
///*	[LineNumberTable(231), Signature("(TKey;)I")]*/

//	public virtual int rank(IComparable c)
//	{
//		return this.rank(c, this.root);
//	}
///*	[Signature("(LBST<TKey;TValue;>.Node;)I")]*/

//	private int height(BST.Node node)
//	{
//		if (node == null)
//		{
//			return -1;
//		}
//		return 1 + java.lang.Math.max(this.height(BST.Node.access_200(node)), this.height(BST.Node.access_300(node)));
//	}


//	private bool isBST()
//	{
//		return this.isBST(this.root, null, null);
//	}


//	private bool isSizeConsistent()
//	{
//		return this.isSizeConsistent(this.root);
//	}


//	private bool isRankConsistent()
//	{
//		for (int i = 0; i < this.size(); i++)
//		{
//			if (i != this.rank(this.select(i)))
//			{
//				return false;
//			}
//		}
//		Iterator iterator = this.keys().iterator();
//		while (iterator.hasNext())
//		{
//			IComparable comparable = (IComparable)iterator.next();
//			if (Comparable.__Helper.compareTo(comparable, this.select(this.rank(comparable))) != 0)
//			{
//				return false;
//			}
//		}
//		return true;
//	}
///*	[Signature("(LBST<TKey;TValue;>.Node;TKey;TKey;)Z")]*/

//	private bool isBST(BST.Node node, IComparable comparable, IComparable comparable2)
//	{
//		return node == null || ((comparable == null || Comparable.__Helper.compareTo(BST.Node.access_100(node), comparable) > 0) && (comparable2 == null || Comparable.__Helper.compareTo(BST.Node.access_100(node), comparable2) < 0) && (this.isBST(BST.Node.access_200(node), comparable, BST.Node.access_100(node)) && this.isBST(BST.Node.access_300(node), BST.Node.access_100(node), comparable2)));
//	}
///*	[Signature("(LBST<TKey;TValue;>.Node;)Z")]*/

//	private bool isSizeConsistent(BST.Node node)
//	{
//		return node == null || (BST.Node.access_000(node) == this.size(BST.Node.access_200(node)) + this.size(BST.Node.access_300(node)) + 1 && (this.isSizeConsistent(BST.Node.access_200(node)) && this.isSizeConsistent(BST.Node.access_300(node))));
//	}
///*	[Signature("(I)TKey;")]*/

//	public virtual IComparable select(int i)
//	{
//		if (i < 0 || i >= this.size())
//		{
//			return null;
//		}
//		BST.Node node = this.select(this.root, i);
//		return BST.Node.access_100(node);
//	}
///*	[LineNumberTable(247), Signature("()Ljava/lang/Iterable<TKey;>;")]*/

//	public virtual Iterable keys()
//	{
//		return this.keys(this.min(), this.max());
//	}


//	public BST()
//	{
//	}
///*	[Signature("(TKey;TValue;)V")]*/

//	public virtual void put(IComparable c, object obj)
//	{
//		if (obj == null)
//		{
//			this.delete(c);
//			return;
//		}
//		this.root = this.put(this.root, c, obj);
//		if (!BST.s_assertionsDisabled && !this.check())
//		{

//			throw new AssertionError();
//		}
//	}
///*	[Signature("()Ljava/lang/Iterable<TKey;>;")]*/

//	public virtual Iterable levelOrder()
//	{
//		Queue queue = new Queue();
//		Queue queue2 = new Queue();
//		queue2.enqueue(this.root);
//		while (!queue2.isEmpty())
//		{
//			BST.Node node = (BST.Node)queue2.dequeue();
//			if (node != null)
//			{
//				queue.enqueue(BST.Node.access_100(node));
//				queue2.enqueue(BST.Node.access_200(node));
//				queue2.enqueue(BST.Node.access_300(node));
//			}
//		}
//		return queue;
//	}


//	public virtual void deleteMin()
//	{
//		if (this.isEmpty())
//		{
//			string arg_12_0 = "Symbol table underflow";

//			throw new InvalidOperationException(arg_12_0);
//		}
//		this.root = this.deleteMin(this.root);
//		if (!BST.s_assertionsDisabled && !this.check())
//		{

//			throw new AssertionError();
//		}
//	}


//	public virtual void deleteMax()
//	{
//		if (this.isEmpty())
//		{
//			string arg_12_0 = "Symbol table underflow";

//			throw new InvalidOperationException(arg_12_0);
//		}
//		this.root = this.deleteMax(this.root);
//		if (!BST.s_assertionsDisabled && !this.check())
//		{

//			throw new AssertionError();
//		}
//	}
///*	[Signature("(TKey;)TKey;")]*/

//	public virtual IComparable floor(IComparable c)
//	{
//		BST.Node node = this.floor(this.root, c);
//		if (node == null)
//		{
//			return null;
//		}
//		return BST.Node.access_100(node);
//	}
///*	[Signature("(TKey;)TKey;")]*/

//	public virtual IComparable ceiling(IComparable c)
//	{
//		BST.Node node = this.ceiling(this.root, c);
//		if (node == null)
//		{
//			return null;
//		}
//		return BST.Node.access_100(node);
//	}
///*	[Signature("(TKey;TKey;)I")]*/

//	public virtual int size(IComparable c1, IComparable c2)
//	{
//		if (Comparable.__Helper.compareTo(c1, c2) > 0)
//		{
//			return 0;
//		}
//		if (this.contains(c2))
//		{
//			return this.rank(c2) - this.rank(c1) + 1;
//		}
//		return this.rank(c2) - this.rank(c1);
//	}


//	public virtual int height()
//	{
//		return this.height(this.root);
//	}


//	/**/public static void main(string[] strarr)
//	{
//		BST bST = new BST();
//		int num = 0;
//		while (!StdIn.isEmpty())
//		{
//			string text = StdIn.readString();
//			bST.put(text, Integer.valueOf(num));
//			num++;
//		}
//		Iterator iterator = bST.levelOrder().iterator();
//		while (iterator.hasNext())
//		{
//			string text = (string)iterator.next();
//			StdOut.println(new StringBuilder().append(text).append(" ").append(bST.get(text)).toString());
//		}
//		StdOut.println();
//		iterator = bST.keys().iterator();
//		while (iterator.hasNext())
//		{
//			string text = (string)iterator.next();
//			StdOut.println(new StringBuilder().append(text).append(" ").append(bST.get(text)).toString());
//		}
//	}

//	static BST()
//	{
//		BST.s_assertionsDisabled = !ClassLiteral<BST>.Value.desiredAssertionStatus();
//	}
//}