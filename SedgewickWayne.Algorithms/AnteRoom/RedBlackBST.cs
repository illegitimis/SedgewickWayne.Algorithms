
namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    //[Signature("<Key::Ljava/lang/Comparable<TKey;>;Value:Ljava/lang/Object;>Ljava/lang/Object;")]
    public class RedBlackBST
    {
        //[InnerClass(null, Modifiers.Private), Modifiers(Modifiers.Super), SourceFile("RedBlackBST.java")]
        internal sealed class Node
        {
            //[Signature("TKey;")]
            private IComparable key;
            //[Signature("TValue;")]
            private object val;
            //[Signature("LRedBlackBST<TKey;TValue;>.Node;")]
            private RedBlackBST.Node left;
            //[Signature("LRedBlackBST<TKey;TValue;>.Node;")]
            private RedBlackBST.Node right;
            private bool color;
            private int N;
            //[Modifiers(Modifiers.Final | Modifiers.Synthetic)]
            internal RedBlackBST redBlackBST;
            /*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
            internal static bool access_000(RedBlackBST.Node node)
            {
                return node.color;
            }
            /*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
            internal static int access_100(RedBlackBST.Node node)
            {
                return node.N;
            }
            /*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
            internal static IComparable access_200(RedBlackBST.Node node)
            {
                return node.key;
            }
            /*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
            internal static RedBlackBST.Node access_300(RedBlackBST.Node node)
            {
                return node.left;
            }
            /*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
            internal static RedBlackBST.Node access_400(RedBlackBST.Node node)
            {
                return node.right;
            }
            /*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
            internal static object access_500(RedBlackBST.Node node)
            {
                return node.val;
            }
            /*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
            internal static bool access_002(RedBlackBST.Node node, bool result)
            {
                node.color = result;
                return result;
            }
            /*		[Signature("(TKey;TValue;ZI)V")]*/

            public Node(RedBlackBST redBlackBST, IComparable comparable, object obj, bool flag, int n)
            {
                this.key = comparable;
                this.val = obj;
                this.color = flag;
                this.N = n;
            }
            /*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
            internal static RedBlackBST.Node access_302(RedBlackBST.Node node, RedBlackBST.Node result)
            {
                node.left = result;
                return result;
            }
            /*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
            internal static RedBlackBST.Node access_402(RedBlackBST.Node node, RedBlackBST.Node result)
            {
                node.right = result;
                return result;
            }
            /*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
            internal static object access_502(RedBlackBST.Node node, object result)
            {
                node.val = result;
                return result;
            }
            /*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
            internal static int access_102(RedBlackBST.Node node, int num)
            {
                node.N = num;
                return num;
            }
            /*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
            internal static IComparable access_202(RedBlackBST.Node node, IComparable result)
            {
                node.key = result;
                return result;
            }
        }
        private const bool RED = true;
        private const bool BLACK = false;
        //[Signature("LRedBlackBST<TKey;TValue;>.Node;")]
        private RedBlackBST.Node root;
        //[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
        internal static bool s_assertionsDisabled;


        /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)I")]*/

        private int size(RedBlackBST.Node node)
        {
            if (node == null)
            {
                return 0;
            }
            return RedBlackBST.Node.access_100(node);
        }
        /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;TKey;)TValue;")]*/

        private object get(RedBlackBST.Node node, IComparable o)
        {
            while (node != null)
            {
                int num = Comparable.__Helper.CompareTo(o, RedBlackBST.Node.access_200(node));
                if (num < 0)
                {
                    node = RedBlackBST.Node.access_300(node);
                }
                else
                {
                    if (num <= 0)
                    {
                        return RedBlackBST.Node.access_500(node);
                    }
                    node = RedBlackBST.Node.access_400(node);
                }
            }
            return null;
        }
        /*	[LineNumberTable(85), Signature("(TKey;)TValue;")]*/

        public virtual object get(IComparable c)
        {
            return this.get(this.root, c);
        }
        /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;TKey;TValue;)LRedBlackBST<TKey;TValue;>.Node;")]*/

        private RedBlackBST.Node put(RedBlackBST.Node node, IComparable comparable, object obj)
        {
            if (node == null)
            {
                return new RedBlackBST.Node(this, comparable, obj, true, 1);
            }
            int num = Comparable.__Helper.CompareTo(comparable, RedBlackBST.Node.access_200(node));
            if (num < 0)
            {
                RedBlackBST.Node.access_302(node, this.put(RedBlackBST.Node.access_300(node), comparable, obj));
            }
            else if (num > 0)
            {
                RedBlackBST.Node.access_402(node, this.put(RedBlackBST.Node.access_400(node), comparable, obj));
            }
            else
            {
                RedBlackBST.Node.access_502(node, obj);
            }
            if (this.isRed(RedBlackBST.Node.access_400(node)) && !this.isRed(RedBlackBST.Node.access_300(node)))
            {
                node = this.rotateLeft(node);
            }
            if (this.isRed(RedBlackBST.Node.access_300(node)) && this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_300(node))))
            {
                node = this.rotateRight(node);
            }
            if (this.isRed(RedBlackBST.Node.access_300(node)) && this.isRed(RedBlackBST.Node.access_400(node)))
            {
                this.flipColors(node);
            }
            RedBlackBST.Node.access_102(node, this.size(RedBlackBST.Node.access_300(node)) + this.size(RedBlackBST.Node.access_400(node)) + 1);
            return node;
        }


        private bool check()
        {
            if (!this.isBST())
            {
                StdOut.println("Not in symmetric order");
            }
            if (!this.isSizeConsistent())
            {
                StdOut.println("Subtree counts not consistent");
            }
            if (!this.isRankConsistent())
            {
                StdOut.println("Ranks not consistent");
            }
            if (!this.is23())
            {
                StdOut.println("Not a 2-3 tree");
            }
            if (!this.isBalanced())
            {
                StdOut.println("Not balanced");
            }
            return this.isBST() && this.isSizeConsistent() && this.isRankConsistent() && this.is23() && this.isBalanced();
        }
        /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)Z")]*/

        private bool isRed(RedBlackBST.Node node)
        {
            return node != null && RedBlackBST.Node.access_000(node);
        }
        /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)LRedBlackBST<TKey;TValue;>.Node;")]*/

        private RedBlackBST.Node rotateLeft(RedBlackBST.Node node)
        {
            if (!RedBlackBST.s_assertionsDisabled && (node == null || !this.isRed(RedBlackBST.Node.access_400(node))))
            {

                throw new AssertionError();
            }
            RedBlackBST.Node node2 = RedBlackBST.Node.access_400(node);
            RedBlackBST.Node.access_402(node, RedBlackBST.Node.access_300(node2));
            RedBlackBST.Node.access_302(node2, node);
            RedBlackBST.Node.access_002(node2, RedBlackBST.Node.access_000(RedBlackBST.Node.access_300(node2)));
            RedBlackBST.Node.access_002(RedBlackBST.Node.access_300(node2), true);
            RedBlackBST.Node.access_102(node2, RedBlackBST.Node.access_100(node));
            RedBlackBST.Node.access_102(node, this.size(RedBlackBST.Node.access_300(node)) + this.size(RedBlackBST.Node.access_400(node)) + 1);
            return node2;
        }
        /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)LRedBlackBST<TKey;TValue;>.Node;")]*/

        private RedBlackBST.Node rotateRight(RedBlackBST.Node node)
        {
            if (!RedBlackBST.s_assertionsDisabled && (node == null || !this.isRed(RedBlackBST.Node.access_300(node))))
            {

                throw new AssertionError();
            }
            RedBlackBST.Node node2 = RedBlackBST.Node.access_300(node);
            RedBlackBST.Node.access_302(node, RedBlackBST.Node.access_400(node2));
            RedBlackBST.Node.access_402(node2, node);
            RedBlackBST.Node.access_002(node2, RedBlackBST.Node.access_000(RedBlackBST.Node.access_400(node2)));
            RedBlackBST.Node.access_002(RedBlackBST.Node.access_400(node2), true);
            RedBlackBST.Node.access_102(node2, RedBlackBST.Node.access_100(node));
            RedBlackBST.Node.access_102(node, this.size(RedBlackBST.Node.access_300(node)) + this.size(RedBlackBST.Node.access_400(node)) + 1);
            return node2;
        }
        /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)V")]*/

        private void flipColors(RedBlackBST.Node node)
        {
            if (!RedBlackBST.s_assertionsDisabled && (node == null || RedBlackBST.Node.access_300(node) == null || RedBlackBST.Node.access_400(node) == null))
            {

                throw new AssertionError();
            }
            if (!RedBlackBST.s_assertionsDisabled && (this.isRed(node) || !this.isRed(RedBlackBST.Node.access_300(node)) || !this.isRed(RedBlackBST.Node.access_400(node))) && (!this.isRed(node) || this.isRed(RedBlackBST.Node.access_300(node)) || this.isRed(RedBlackBST.Node.access_400(node))))
            {

                throw new AssertionError();
            }
            RedBlackBST.Node.access_002(node, !RedBlackBST.Node.access_000(node));
            RedBlackBST.Node.access_002(RedBlackBST.Node.access_300(node), !RedBlackBST.Node.access_000(RedBlackBST.Node.access_300(node)));
            RedBlackBST.Node.access_002(RedBlackBST.Node.access_400(node), !RedBlackBST.Node.access_000(RedBlackBST.Node.access_400(node)));
        }
        public virtual bool IsEmpty
        {
		return this.root == null;
        }
        /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)LRedBlackBST<TKey;TValue;>.Node;")]*/

        private RedBlackBST.Node deleteMin(RedBlackBST.Node node)
        {
            if (RedBlackBST.Node.access_300(node) == null)
            {
                return null;
            }
            if (!this.isRed(RedBlackBST.Node.access_300(node)) && !this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_300(node))))
            {
                node = this.moveRedLeft(node);
            }
            RedBlackBST.Node.access_302(node, this.deleteMin(RedBlackBST.Node.access_300(node)));
            return this.balance(node);
        }
        /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)LRedBlackBST<TKey;TValue;>.Node;")]*/

        private RedBlackBST.Node moveRedLeft(RedBlackBST.Node node)
        {
            if (!RedBlackBST.s_assertionsDisabled && node == null)
            {

                throw new AssertionError();
            }
            if (!RedBlackBST.s_assertionsDisabled && (!this.isRed(node) || this.isRed(RedBlackBST.Node.access_300(node)) || this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_300(node)))))
            {

                throw new AssertionError();
            }
            this.flipColors(node);
            if (this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_400(node))))
            {
                RedBlackBST.Node.access_402(node, this.rotateRight(RedBlackBST.Node.access_400(node)));
                node = this.rotateLeft(node);
            }
            return node;
        }
        /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)LRedBlackBST<TKey;TValue;>.Node;")]*/

        private RedBlackBST.Node balance(RedBlackBST.Node node)
        {
            if (!RedBlackBST.s_assertionsDisabled && node == null)
            {

                throw new AssertionError();
            }
            if (this.isRed(RedBlackBST.Node.access_400(node)))
            {
                node = this.rotateLeft(node);
            }
            if (this.isRed(RedBlackBST.Node.access_300(node)) && this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_300(node))))
            {
                node = this.rotateRight(node);
            }
            if (this.isRed(RedBlackBST.Node.access_300(node)) && this.isRed(RedBlackBST.Node.access_400(node)))
            {
                this.flipColors(node);
            }
            RedBlackBST.Node.access_102(node, this.size(RedBlackBST.Node.access_300(node)) + this.size(RedBlackBST.Node.access_400(node)) + 1);
            return node;
        }
        /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)LRedBlackBST<TKey;TValue;>.Node;")]*/

        private RedBlackBST.Node deleteMax(RedBlackBST.Node node)
        {
            if (this.isRed(RedBlackBST.Node.access_300(node)))
            {
                node = this.rotateRight(node);
            }
            if (RedBlackBST.Node.access_400(node) == null)
            {
                return null;
            }
            if (!this.isRed(RedBlackBST.Node.access_400(node)) && !this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_400(node))))
            {
                node = this.moveRedRight(node);
            }
            RedBlackBST.Node.access_402(node, this.deleteMax(RedBlackBST.Node.access_400(node)));
            return this.balance(node);
        }
        /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)LRedBlackBST<TKey;TValue;>.Node;")]*/

        private RedBlackBST.Node moveRedRight(RedBlackBST.Node node)
        {
            if (!RedBlackBST.s_assertionsDisabled && node == null)
            {

                throw new AssertionError();
            }
            if (!RedBlackBST.s_assertionsDisabled && (!this.isRed(node) || this.isRed(RedBlackBST.Node.access_400(node)) || this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_400(node)))))
            {

                throw new AssertionError();
            }
            this.flipColors(node);
            if (this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_300(node))))
            {
                node = this.rotateRight(node);
            }
            return node;
        }
        /*	[LineNumberTable(100), Signature("(TKey;)Z")]*/

        public virtual bool contains(IComparable c)
        {
            return this.get(c) != null;
        }
        /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;TKey;)LRedBlackBST<TKey;TValue;>.Node;")]*/

        private RedBlackBST.Node delete(RedBlackBST.Node node, IComparable comparable)
        {
            if (!RedBlackBST.s_assertionsDisabled && !this.contains(node, comparable))
            {

                throw new AssertionError();
            }
            if (Comparable.__Helper.CompareTo(comparable, RedBlackBST.Node.access_200(node)) < 0)
            {
                if (!this.isRed(RedBlackBST.Node.access_300(node)) && !this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_300(node))))
                {
                    node = this.moveRedLeft(node);
                }
                RedBlackBST.Node.access_302(node, this.delete(RedBlackBST.Node.access_300(node), comparable));
            }
            else
            {
                if (this.isRed(RedBlackBST.Node.access_300(node)))
                {
                    node = this.rotateRight(node);
                }
                if (Comparable.__Helper.CompareTo(comparable, RedBlackBST.Node.access_200(node)) == 0 && RedBlackBST.Node.access_400(node) == null)
                {
                    return null;
                }
                if (!this.isRed(RedBlackBST.Node.access_400(node)) && !this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_400(node))))
                {
                    node = this.moveRedRight(node);
                }
                if (Comparable.__Helper.CompareTo(comparable, RedBlackBST.Node.access_200(node)) == 0)
                {
                    RedBlackBST.Node node2 = this.min(RedBlackBST.Node.access_400(node));
                    RedBlackBST.Node.access_202(node, RedBlackBST.Node.access_200(node2));
                    RedBlackBST.Node.access_502(node, RedBlackBST.Node.access_500(node2));
                    RedBlackBST.Node.access_402(node, this.deleteMin(RedBlackBST.Node.access_400(node)));
                }
                else
                {
                    RedBlackBST.Node.access_402(node, this.delete(RedBlackBST.Node.access_400(node), comparable));
                }
            }
            return this.balance(node);
        }
        /*	[LineNumberTable(105), Signature("(LRedBlackBST<TKey;TValue;>.Node;TKey;)Z")]*/

        private bool contains(RedBlackBST.Node node, IComparable comparable)
        {
            return this.get(node, comparable) != null;
        }
        /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)LRedBlackBST<TKey;TValue;>.Node;")]*/

        private RedBlackBST.Node min(RedBlackBST.Node node)
        {
            if (!RedBlackBST.s_assertionsDisabled && node == null)
            {

                throw new AssertionError();
            }
            if (RedBlackBST.Node.access_300(node) == null)
            {
                return node;
            }
            return this.min(RedBlackBST.Node.access_300(node));
        }
        /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)I")]*/

        private int height(RedBlackBST.Node node)
        {
            if (node == null)
            {
                return -1;
            }
            return 1 + java.lang.Math.max(this.height(RedBlackBST.Node.access_300(node)), this.height(RedBlackBST.Node.access_400(node)));
        }
        /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)LRedBlackBST<TKey;TValue;>.Node;")]*/

        private RedBlackBST.Node max(RedBlackBST.Node node)
        {
            if (!RedBlackBST.s_assertionsDisabled && node == null)
            {

                throw new AssertionError();
            }
            if (RedBlackBST.Node.access_400(node) == null)
            {
                return node;
            }
            return this.max(RedBlackBST.Node.access_400(node));
        }
        /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;TKey;)LRedBlackBST<TKey;TValue;>.Node;")]*/

        private RedBlackBST.Node floor(RedBlackBST.Node node, IComparable comparable)
        {
            if (node == null)
            {
                return null;
            }
            int num = Comparable.__Helper.CompareTo(comparable, RedBlackBST.Node.access_200(node));
            if (num == 0)
            {
                return node;
            }
            if (num < 0)
            {
                return this.floor(RedBlackBST.Node.access_300(node), comparable);
            }
            RedBlackBST.Node node2 = this.floor(RedBlackBST.Node.access_400(node), comparable);
            if (node2 != null)
            {
                return node2;
            }
            return node;
        }
        /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;TKey;)LRedBlackBST<TKey;TValue;>.Node;")]*/

        private RedBlackBST.Node ceiling(RedBlackBST.Node node, IComparable comparable)
        {
            if (node == null)
            {
                return null;
            }
            int num = Comparable.__Helper.CompareTo(comparable, RedBlackBST.Node.access_200(node));
            if (num == 0)
            {
                return node;
            }
            if (num > 0)
            {
                return this.ceiling(RedBlackBST.Node.access_400(node), comparable);
            }
            RedBlackBST.Node node2 = this.ceiling(RedBlackBST.Node.access_300(node), comparable);
            if (node2 != null)
            {
                return node2;
            }
            return node;
        }


        public virtual int Size
        {
		return this.size(this.root);
        }
        /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;I)LRedBlackBST<TKey;TValue;>.Node;")]*/

        private RedBlackBST.Node select(RedBlackBST.Node node, int num)
        {
            if (!RedBlackBST.s_assertionsDisabled && node == null)
            {

                throw new AssertionError();
            }
            if (!RedBlackBST.s_assertionsDisabled && (num < 0 || num >= this.size(node)))
            {

                throw new AssertionError();
            }
            int num2 = this.size(RedBlackBST.Node.access_300(node));
            if (num2 > num)
            {
                return this.select(RedBlackBST.Node.access_300(node), num);
            }
            if (num2 < num)
            {
                return this.select(RedBlackBST.Node.access_400(node), num - num2 - 1);
            }
            return node;
        }
        /*	[Signature("(TKey;LRedBlackBST<TKey;TValue;>.Node;)I")]*/

        private int rank(IComparable comparable, RedBlackBST.Node node)
        {
            if (node == null)
            {
                return 0;
            }
            int num = Comparable.__Helper.CompareTo(comparable, RedBlackBST.Node.access_200(node));
            if (num < 0)
            {
                return this.rank(comparable, RedBlackBST.Node.access_300(node));
            }
            if (num > 0)
            {
                return 1 + this.size(RedBlackBST.Node.access_300(node)) + this.rank(comparable, RedBlackBST.Node.access_400(node));
            }
            return this.size(RedBlackBST.Node.access_300(node));
        }
        /*	[Signature("()TKey;")]*/

        public virtual IComparable Min
        {
		if (this.IsEmpty)

        {
                return null;
            }
		return RedBlackBST.Node.access_200(this.min(this.root));
        }
        /*	[Signature("()TKey;")]*/

        public virtual IComparable Max
        {
		if (this.IsEmpty)

        {
                return null;
            }
		return RedBlackBST.Node.access_200(this.max(this.root));
        }
        /*	[Signature("(TKey;TKey;)Ljava/lang/Iterable<TKey;>;")]*/

        public virtual Iterable keys(IComparable c1, IComparable c2)
        {
            Queue queue = new Queue();
            this.keys(this.root, queue, c1, c2);
            return queue;
        }
        /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;LQueue<TKey;>;TKey;TKey;)V")]*/

        private void keys(RedBlackBST.Node node, Queue queue, IComparable comparable, IComparable comparable2)
        {
            if (node == null)
            {
                return;
            }
            int num = Comparable.__Helper.CompareTo(comparable, RedBlackBST.Node.access_200(node));
            int num2 = Comparable.__Helper.CompareTo(comparable2, RedBlackBST.Node.access_200(node));
            if (num < 0)
            {
                this.keys(RedBlackBST.Node.access_300(node), queue, comparable, comparable2);
            }
            if (num <= 0 && num2 >= 0)
            {
                queue.enqueue(RedBlackBST.Node.access_200(node));
            }
            if (num2 > 0)
            {
                this.keys(RedBlackBST.Node.access_400(node), queue, comparable, comparable2);
            }
        }
        /*	[LineNumberTable(419), Signature("(TKey;)I")]*/

        public virtual int rank(IComparable c)
        {
            return this.rank(c, this.root);
        }


        private bool isBST()
        {
            return this.isBST(this.root, null, null);
        }


        private bool isSizeConsistent()
        {
            return this.isSizeConsistent(this.root);
        }


        private bool isRankConsistent()
        {
            for (int i = 0; i < this.Size; i++)
            {
                if (i != this.rank(this.select(i)))
                {
                    return false;
                }
            }
            Iterator iterator = this.keys().iterator();
            while (iterator.hasNext())
            {
                IComparable comparable = (IComparable)iterator.next();
                if (Comparable.__Helper.CompareTo(comparable, this.select(this.rank(comparable))) != 0)
                {
                    return false;
                }
            }
            return true;
        }


        private bool is23()
        {
            return this.is23(this.root);
        }


        private bool isBalanced()
        {
            int num = 0;
            for (RedBlackBST.Node node = this.root; node != null; node = RedBlackBST.Node.access_300(node))
            {
                if (!this.isRed(node))
                {
                    num++;
                }
            }
            return this.isBalanced(this.root, num);
        }
        /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;TKey;TKey;)Z")]*/

        private bool isBST(RedBlackBST.Node node, IComparable comparable, IComparable comparable2)
        {
            return node == null || ((comparable == null || Comparable.__Helper.CompareTo(RedBlackBST.Node.access_200(node), comparable) > 0) && (comparable2 == null || Comparable.__Helper.CompareTo(RedBlackBST.Node.access_200(node), comparable2) < 0) && (this.isBST(RedBlackBST.Node.access_300(node), comparable, RedBlackBST.Node.access_200(node)) && this.isBST(RedBlackBST.Node.access_400(node), RedBlackBST.Node.access_200(node), comparable2)));
        }
        /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)Z")]*/

        private bool isSizeConsistent(RedBlackBST.Node node)
        {
            return node == null || (RedBlackBST.Node.access_100(node) == this.size(RedBlackBST.Node.access_300(node)) + this.size(RedBlackBST.Node.access_400(node)) + 1 && (this.isSizeConsistent(RedBlackBST.Node.access_300(node)) && this.isSizeConsistent(RedBlackBST.Node.access_400(node))));
        }
        /*	[Signature("(I)TKey;")]*/

        public virtual IComparable select(int i)
        {
            if (i < 0 || i >= this.Size)
            {
                return null;
            }
            RedBlackBST.Node node = this.select(this.root, i);
            return RedBlackBST.Node.access_200(node);
        }
        /*	[LineNumberTable(437), Signature("()Ljava/lang/Iterable<TKey;>;")]*/

        public virtual Iterable keys()
        {
            return this.keys(this.Min, this.Max);
        }
        /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)Z")]*/

        private bool is23(RedBlackBST.Node node)
        {
            return node == null || (!this.isRed(RedBlackBST.Node.access_400(node)) && (node == this.root || !this.isRed(node) || !this.isRed(RedBlackBST.Node.access_300(node))) && (this.is23(RedBlackBST.Node.access_300(node)) && this.is23(RedBlackBST.Node.access_400(node))));
        }
        /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;I)Z")]*/

        private bool isBalanced(RedBlackBST.Node node, int num)
        {
            if (node == null)
            {
                return num == 0;
            }
            if (!this.isRed(node))
            {
                num += -1;
            }
            return this.isBalanced(RedBlackBST.Node.access_300(node), num) && this.isBalanced(RedBlackBST.Node.access_400(node), num);
        }


        public RedBlackBST()
        {
        }
        /*	[Signature("(TKey;TValue;)V")]*/

        public virtual void put(IComparable c, object obj)
        {
            this.root = this.put(this.root, c, obj);
            RedBlackBST.Node.access_002(this.root, false);
            if (!RedBlackBST.s_assertionsDisabled && !this.check())
            {

                throw new AssertionError();
            }
        }


        public virtual void deleteMin()
        {
            if (this.IsEmpty)
            {
                string arg_12_0 = "BST underflow";

                throw new InvalidOperationException(arg_12_0);
            }
            if (!this.isRed(RedBlackBST.Node.access_300(this.root)) && !this.isRed(RedBlackBST.Node.access_400(this.root)))
            {
                RedBlackBST.Node.access_002(this.root, true);
            }
            this.root = this.deleteMin(this.root);
            if (!this.IsEmpty)
            {
                RedBlackBST.Node.access_002(this.root, false);
            }
            if (!RedBlackBST.s_assertionsDisabled && !this.check())
            {

                throw new AssertionError();
            }
        }


        public virtual void deleteMax()
        {
            if (this.IsEmpty)
            {
                string arg_12_0 = "BST underflow";

                throw new InvalidOperationException(arg_12_0);
            }
            if (!this.isRed(RedBlackBST.Node.access_300(this.root)) && !this.isRed(RedBlackBST.Node.access_400(this.root)))
            {
                RedBlackBST.Node.access_002(this.root, true);
            }
            this.root = this.deleteMax(this.root);
            if (!this.IsEmpty)
            {
                RedBlackBST.Node.access_002(this.root, false);
            }
            if (!RedBlackBST.s_assertionsDisabled && !this.check())
            {

                throw new AssertionError();
            }
        }
        /*	[Signature("(TKey;)V")]*/

        public virtual void delete(IComparable c)
        {
            if (!this.contains(c))
            {
                System.err.println(new StringBuilder().append("symbol table does not contain ").append(c).toString());
                return;
            }
            if (!this.isRed(RedBlackBST.Node.access_300(this.root)) && !this.isRed(RedBlackBST.Node.access_400(this.root)))
            {
                RedBlackBST.Node.access_002(this.root, true);
            }
            this.root = this.delete(this.root, c);
            if (!this.IsEmpty)
            {
                RedBlackBST.Node.access_002(this.root, false);
            }
            if (!RedBlackBST.s_assertionsDisabled && !this.check())
            {

                throw new AssertionError();
            }
        }


        public virtual int height()
        {
            return this.height(this.root);
        }
        /*	[Signature("(TKey;)TKey;")]*/

        public virtual IComparable floor(IComparable c)
        {
            RedBlackBST.Node node = this.floor(this.root, c);
            if (node == null)
            {
                return null;
            }
            return RedBlackBST.Node.access_200(node);
        }
        /*	[Signature("(TKey;)TKey;")]*/

        public virtual IComparable ceiling(IComparable c)
        {
            RedBlackBST.Node node = this.ceiling(this.root, c);
            if (node == null)
            {
                return null;
            }
            return RedBlackBST.Node.access_200(node);
        }
        /*	[Signature("(TKey;TKey;)I")]*/

        public virtual int size(IComparable c1, IComparable c2)
        {
            if (Comparable.__Helper.CompareTo(c1, c2) > 0)
            {
                return 0;
            }
            if (this.contains(c2))
            {
                return this.rank(c2) - this.rank(c1) + 1;
            }
            return this.rank(c2) - this.rank(c1);
        }


        /**/
        public static void main(string[] strarr)
        {
            RedBlackBST redBlackBST = new RedBlackBST();
            int num = 0;
            while (!StdIn.IsEmpty)
            {
                string text = StdIn.readString();
                redBlackBST.put(text, Integer.valueOf(num));
                num++;
            }
            Iterator iterator = redBlackBST.keys().iterator();
            while (iterator.hasNext())
            {
                string text = (string)iterator.next();
                StdOut.println(new StringBuilder().append(text).append(" ").append(redBlackBST.get(text)).toString());
            }
            StdOut.println();
        }

        static RedBlackBST()
        {
            RedBlackBST.s_assertionsDisabled = !ClassLiteral<RedBlackBST>.Value.desiredAssertionStatus();
        }
    }
}
