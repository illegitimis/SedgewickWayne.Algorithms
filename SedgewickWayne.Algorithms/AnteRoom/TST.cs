using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SedgewickWayne.Algorithms.AnteRoom
{

    //[Signature("<Value:Ljava/lang/Object;>Ljava/lang/Object;")]
    public class TST
    {
        /*[EnclosingMethod("TST", null, null), InnerClass(null, Modifiers.Static | Modifiers.Synthetic), Modifiers(Modifiers.Super | Modifiers.Synthetic), SourceFile("TST.java")]*/

        [InnerClass(null, Modifiers.Private), Modifiers(Modifiers.Super), SourceFile("TST.java")]
        internal sealed class Node
        {
            private char c;
            //[Signature("LTST<TValue;>.Node;")]
            private TST.Node left;
            //[Signature("LTST<TValue;>.Node;")]
            private TST.Node mid;
            //[Signature("LTST<TValue;>.Node;")]
            private TST.Node right;
            //[Signature("TValue;")]
            private object val;
            //[Modifiers(Modifiers.Final | Modifiers.Synthetic)]
            internal TST tST;
            //[LineNumberTable(33), Modifiers(Modifiers.Static | Modifiers.Synthetic)]
            internal static object access_000(TST.Node node)
            {
                return node.val;
            }
            //[LineNumberTable(33), Modifiers(Modifiers.Static | Modifiers.Synthetic)]
            internal static char access_100(TST.Node node)
            {
                return node.c;
            }
            //[LineNumberTable(33), Modifiers(Modifiers.Static | Modifiers.Synthetic)]
            internal static TST.Node access_200(TST.Node node)
            {
                return node.left;
            }
            //[LineNumberTable(33), Modifiers(Modifiers.Static | Modifiers.Synthetic)]
            internal static TST.Node access_300(TST.Node node)
            {
                return node.right;
            }
            //[LineNumberTable(33), Modifiers(Modifiers.Static | Modifiers.Synthetic)]
            internal static TST.Node access_400(TST.Node node)
            {
                return node.mid;
            }
            /*		[LineNumberTable(33), Modifiers(Modifiers.Synthetic)]*/

            internal Node(TST tST, TST.1) : this(tST)
            {
            }
            //[LineNumberTable(33), Modifiers(Modifiers.Static | Modifiers.Synthetic)]
            internal static char access_102(TST.Node node, char result)
            {
                node.c = result;
                return result;
            }
            //[LineNumberTable(33), Modifiers(Modifiers.Static | Modifiers.Synthetic)]
            internal static TST.Node access_202(TST.Node node, TST.Node result)
            {
                node.left = result;
                return result;
            }
            //[LineNumberTable(33), Modifiers(Modifiers.Static | Modifiers.Synthetic)]
            internal static TST.Node access_302(TST.Node node, TST.Node result)
            {
                node.right = result;
                return result;
            }
            //[LineNumberTable(33), Modifiers(Modifiers.Static | Modifiers.Synthetic)]
            internal static TST.Node access_402(TST.Node node, TST.Node result)
            {
                node.mid = result;
                return result;
            }
            //[LineNumberTable(33), Modifiers(Modifiers.Static | Modifiers.Synthetic)]
            internal static object access_002(TST.Node node, object result)
            {
                node.val = result;
                return result;
            }


            private Node(TST tST)
            {
            }
        }
        private int N;
        //[Signature("LTST<TValue;>.Node;")]
        private TST.Node root;


        public TST()
        {
        }
        /*	[Signature("(Ljava/lang/String;TValue;)V")]*/

        public virtual void put(string str, object obj)
        {
            if (!this.contains(str))
            {
                this.N++;
            }
            this.root = this.put(this.root, str, obj, 0);
        }


        public virtual string longestPrefixOf(string str)
        {
            if (str == null || java.lang.String.instancehelper_length(str) == 0)
            {
                return null;
            }
            int endIndex = 0;
            TST.Node node = this.root;
            int num = 0;
            while (node != null && num < java.lang.String.instancehelper_length(str))
            {
                int num2 = (int)java.lang.String.instancehelper_charAt(str, num);
                if (num2 < (int)TST.Node.access_100(node))
                {
                    node = TST.Node.access_200(node);
                }
                else if (num2 > (int)TST.Node.access_100(node))
                {
                    node = TST.Node.access_300(node);
                }
                else
                {
                    num++;
                    if (TST.Node.access_000(node) != null)
                    {
                        endIndex = num;
                    }
                    node = TST.Node.access_400(node);
                }
            }
            return java.lang.String.instancehelper_substring(str, 0, endIndex);
        }
        /*	[Signature("(Ljava/lang/String;)TValue;")]*/

        public virtual object get(string str)
        {
            if (str == null)
            {

                throw new NullPointerException();
            }
            if (java.lang.String.instancehelper_length(str) == 0)
            {
                string arg_20_0 = "key must have length >= 1";

                throw new ArgumentException(arg_20_0);
            }
            TST.Node node = this.get(this.root, str, 0);
            if (node == null)
            {
                return null;
            }
            return TST.Node.access_000(node);
        }
        /*	[Signature("(LTST<TValue;>.Node;Ljava/lang/String;I)LTST<TValue;>.Node;")]*/

        private TST.Node get(TST.Node node, string text, int num)
        {
            if (text == null)
            {

                throw new NullPointerException();
            }
            if (java.lang.String.instancehelper_length(text) == 0)
            {
                string arg_20_0 = "key must have length >= 1";

                throw new ArgumentException(arg_20_0);
            }
            if (node == null)
            {
                return null;
            }
            int num2 = (int)java.lang.String.instancehelper_charAt(text, num);
            if (num2 < (int)TST.Node.access_100(node))
            {
                return this.get(TST.Node.access_200(node), text, num);
            }
            if (num2 > (int)TST.Node.access_100(node))
            {
                return this.get(TST.Node.access_300(node), text, num);
            }
            if (num < java.lang.String.instancehelper_length(text) - 1)
            {
                return this.get(TST.Node.access_400(node), text, num + 1);
            }
            return node;
        }


        public virtual bool contains(string str)
        {
            return this.get(str) != null;
        }
        /*	[Signature("(LTST<TValue;>.Node;Ljava/lang/String;TValue;I)LTST<TValue;>.Node;")]*/

        private TST.Node put(TST.Node node, string text, object obj, int num)
        {
            int num2 = (int)java.lang.String.instancehelper_charAt(text, num);
            if (node == null)
            {
                node = new TST.Node(this, null);
                TST.Node.access_102(node, (char)num2);
            }
            if (num2 < (int)TST.Node.access_100(node))
            {
                TST.Node.access_202(node, this.put(TST.Node.access_200(node), text, obj, num));
            }
            else if (num2 > (int)TST.Node.access_100(node))
            {
                TST.Node.access_302(node, this.put(TST.Node.access_300(node), text, obj, num));
            }
            else if (num < java.lang.String.instancehelper_length(text) - 1)
            {
                TST.Node.access_402(node, this.put(TST.Node.access_400(node), text, obj, num + 1));
            }
            else
            {
                TST.Node.access_002(node, obj);
            }
            return node;
        }
        /*	[Signature("(LTST<TValue;>.Node;Ljava/lang/String;LQueue<Ljava/lang/String;>;)V")]*/

        private void collect(TST.Node node, string text, Queue queue)
        {
            if (node == null)
            {
                return;
            }
            this.collect(TST.Node.access_200(node), text, queue);
            if (TST.Node.access_000(node) != null)
            {
                queue.enqueue(new StringBuilder().append(text).append(TST.Node.access_100(node)).toString());
            }
            this.collect(TST.Node.access_400(node), new StringBuilder().append(text).append(TST.Node.access_100(node)).toString(), queue);
            this.collect(TST.Node.access_300(node), text, queue);
        }
        /*	[Signature("(LTST<TValue;>.Node;Ljava/lang/String;ILjava/lang/String;LQueue<Ljava/lang/String;>;)V")]*/

        private void collect(TST.Node node, string text, int num, string text2, Queue queue)
        {
            if (node == null)
            {
                return;
            }
            int num2 = (int)java.lang.String.instancehelper_charAt(text2, num);
            if (num2 == 46 || num2 < (int)TST.Node.access_100(node))
            {
                this.collect(TST.Node.access_200(node), text, num, text2, queue);
            }
            if (num2 == 46 || num2 == (int)TST.Node.access_100(node))
            {
                if (num == java.lang.String.instancehelper_length(text2) - 1 && TST.Node.access_000(node) != null)
                {
                    queue.enqueue(new StringBuilder().append(text).append(TST.Node.access_100(node)).toString());
                }
                if (num < java.lang.String.instancehelper_length(text2) - 1)
                {
                    this.collect(TST.Node.access_400(node), new StringBuilder().append(text).append(TST.Node.access_100(node)).toString(), num + 1, text2, queue);
                }
            }
            if (num2 == 46 || num2 > (int)TST.Node.access_100(node))
            {
                this.collect(TST.Node.access_300(node), text, num, text2, queue);
            }
        }
        /*	[Signature("()Ljava/lang/Iterable<Ljava/lang/String;>;")]*/

        public virtual Iterable keys()
        {
            Queue queue = new Queue();
            this.collect(this.root, "", queue);
            return queue;
        }
        public virtual int Size
        {
		return this.N;
        }
        /*	[Signature("(Ljava/lang/String;)Ljava/lang/Iterable<Ljava/lang/String;>;")]*/

        public virtual Iterable prefixMatch(string str)
        {
            Queue queue = new Queue();
            TST.Node node = this.get(this.root, str, 0);
            if (node == null)
            {
                return queue;
            }
            if (TST.Node.access_000(node) != null)
            {
                queue.enqueue(str);
            }
            this.collect(TST.Node.access_400(node), str, queue);
            return queue;
        }
        /*	[Signature("(Ljava/lang/String;)Ljava/lang/Iterable<Ljava/lang/String;>;")]*/

        public virtual Iterable wildcardMatch(string str)
        {
            Queue queue = new Queue();
            this.collect(this.root, "", 0, str, queue);
            return queue;
        }


        /**/
        public static void main(string[] strarr)
        {
            TST tST = new TST();
            int num = 0;
            while (!StdIn.IsEmpty)
            {
                string str = StdIn.readString();
                tST.put(str, Integer.valueOf(num));
                num++;
            }
            Iterator iterator = tST.keys().iterator();
            while (iterator.hasNext())
            {
                string str = (string)iterator.next();
                StdOut.println(new StringBuilder().append(str).append(" ").append(tST.get(str)).toString());
            }
        }
    }
}
