using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SedgewickWayne.Algorithms.AnteRoom
{

    /*[Implements(new string[]
    {
        "java.lang.Iterable"
    }), Signature("Ljava/lang/Object;Ljava/lang/Iterable<Ljava/lang/String;>;")]*/
    public class TrieSET : IEnumerable
    {
        /*[EnclosingMethod("TrieSET", null, null), InnerClass(null, Modifiers.Static | Modifiers.Synthetic), Modifiers(Modifiers.Super | Modifiers.Synthetic), SourceFile("TrieSET.java")]*/

        //[InnerClass(null, Modifiers.Private | Modifiers.Static), Modifiers(Modifiers.Super), SourceFile("TrieSET.java")]
        internal sealed class Node
        {
            private TrieSET.Node[] next;
            private bool isString;
            /*		[LineNumberTable(43), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
            internal static bool access_000(TrieSET.Node node)
            {
                return node.isString;
            }
            /*		[LineNumberTable(43), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
            internal static TrieSET.Node[] access_100(TrieSET.Node node)
            {
                return node.next;
            }
            /*		[LineNumberTable(43), Modifiers(Modifiers.Synthetic)]*/

            internal Node(TrieSET.1) : this()
            {
            }
            /*		[LineNumberTable(43), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
            internal static bool access_002(TrieSET.Node node, bool result)
            {
                node.isString = result;
                return result;
            }


            private Node()
            {
                this.next = new TrieSET.Node[256];
            }
        }
        private const int R = 256;
        private TrieSET.Node root;
        private int N;


        private TrieSET.Node get(TrieSET.Node node, string text, int num)
        {
            if (node == null)
            {
                return null;
            }
            if (num == java.lang.String.instancehelper_length(text))
            {
                return node;
            }
            int num2 = (int)java.lang.String.instancehelper_charAt(text, num);
            return this.get(TrieSET.Node.access_100(node)[num2], text, num + 1);
        }


        private TrieSET.Node add(TrieSET.Node node, string text, int num)
        {
            if (node == null)
            {
                node = new TrieSET.Node(null);
            }
            if (num == java.lang.String.instancehelper_length(text))
            {
                if (!TrieSET.Node.access_000(node))
                {
                    this.N++;
                }
                TrieSET.Node.access_002(node, true);
            }
            else
            {
                int num2 = (int)java.lang.String.instancehelper_charAt(text, num);
                TrieSET.Node.access_100(node)[num2] = this.add(TrieSET.Node.access_100(node)[num2], text, num + 1);
            }
            return node;
        }
        public virtual int Size
        {
		return this.N;
        }
        /*	[Signature("(Ljava/lang/String;)Ljava/lang/Iterable<Ljava/lang/String;>;")]*/

        public virtual Iterable keysWithPrefix(string str)
        {
            Queue queue = new Queue();
            TrieSET.Node node = this.get(this.root, str, 0);
            this.collect(node, new StringBuilder(str), queue);
            return queue;
        }
        /*	[Signature("(LTrieSET$Node;Ljava/lang/StringBuilder;LQueue<Ljava/lang/String;>;)V")]*/

        private void collect(TrieSET.Node node, StringBuilder stringBuilder, Queue queue)
        {
            if (node == null)
            {
                return;
            }
            if (TrieSET.Node.access_000(node))
            {
                queue.enqueue(stringBuilder.toString());
            }
            for (int i = 0; i < 256; i = (int)((ushort)(i + 1)))
            {
                stringBuilder.append((char)i);
                this.collect(TrieSET.Node.access_100(node)[i], stringBuilder, queue);
                stringBuilder.deleteCharAt(stringBuilder.Length() - 1);
            }
        }
        /*	[Signature("(LTrieSET$Node;Ljava/lang/StringBuilder;Ljava/lang/String;LQueue<Ljava/lang/String;>;)V")]*/

        private void collect(TrieSET.Node node, StringBuilder stringBuilder, string text, Queue queue)
        {
            if (node == null)
            {
                return;
            }
            int num = stringBuilder.Length();
            if (num == java.lang.String.instancehelper_length(text) && TrieSET.Node.access_000(node))
            {
                queue.enqueue(stringBuilder.toString());
            }
            if (num == java.lang.String.instancehelper_length(text))
            {
                return;
            }
            int num2 = (int)java.lang.String.instancehelper_charAt(text, num);
            if (num2 == 46)
            {
                for (int i = 0; i < 256; i = (int)((ushort)(i + 1)))
                {
                    stringBuilder.append((char)i);
                    this.collect(TrieSET.Node.access_100(node)[i], stringBuilder, text, queue);
                    stringBuilder.deleteCharAt(stringBuilder.Length() - 1);
                }
            }
            else
            {
                stringBuilder.append((char)num2);
                this.collect(TrieSET.Node.access_100(node)[num2], stringBuilder, text, queue);
                stringBuilder.deleteCharAt(stringBuilder.Length() - 1);
            }
        }


        private int longestPrefixOf(TrieSET.Node node, string text, int num, int num2)
        {
            if (node == null)
            {
                return num2;
            }
            if (TrieSET.Node.access_000(node))
            {
                num2 = num;
            }
            if (num == java.lang.String.instancehelper_length(text))
            {
                return num2;
            }
            int num3 = (int)java.lang.String.instancehelper_charAt(text, num);
            return this.longestPrefixOf(TrieSET.Node.access_100(node)[num3], text, num + 1, num2);
        }


        private TrieSET.Node delete(TrieSET.Node node, string text, int num)
        {
            if (node == null)
            {
                return null;
            }
            if (num == java.lang.String.instancehelper_length(text))
            {
                if (TrieSET.Node.access_000(node))
                {
                    this.N--;
                }
                TrieSET.Node.access_002(node, false);
            }
            else
            {
                int i = (int)java.lang.String.instancehelper_charAt(text, num);
                TrieSET.Node.access_100(node)[i] = this.delete(TrieSET.Node.access_100(node)[i], text, num + 1);
            }
            if (TrieSET.Node.access_000(node))
            {
                return node;
            }
            for (int i = 0; i < 256; i++)
            {
                if (TrieSET.Node.access_100(node)[i] != null)
                {
                    return node;
                }
            }
            return null;
        }


        public TrieSET()
        {
        }


        public virtual void add(string str)
        {
            this.root = this.add(this.root, str, 0);
        }
        /*	[LineNumberTable(119), Signature("()Ljava/util/Iterator<Ljava/lang/String;>;")]*/

        public virtual Iterator iterator()
        {
            return this.keysWithPrefix("").iterator();
        }


        public virtual string longestPrefixOf(string str)
        {
            int num = this.longestPrefixOf(this.root, str, 0, -1);
            if (num == -1)
            {
                return null;
            }
            return java.lang.String.instancehelper_substring(str, 0, num);
        }
        /*	[Signature("(Ljava/lang/String;)Ljava/lang/Iterable<Ljava/lang/String;>;")]*/

        public virtual Iterable keysThatMatch(string str)
        {
            Queue queue = new Queue();
            StringBuilder stringBuilder = new StringBuilder();
            this.collect(this.root, stringBuilder, str, queue);
            return queue;
        }


        public virtual bool contains(string str)
        {
            TrieSET.Node node = this.get(this.root, str, 0);
            return node != null && TrieSET.Node.access_000(node);
        }


        public virtual bool IsEmpty
        {
		return this.Size == 0;
        }


        public virtual void delete(string str)
        {
            this.root = this.delete(this.root, str, 0);
        }


        /**/
        public static void main(string[] strarr)
        {
            TrieSET trieSET = new TrieSET();
            while (!StdIn.IsEmpty)
            {
                string str = StdIn.readString();
                trieSET.add(str);
            }
            Iterator iterator;
            if (trieSET.Size < 100)
            {
                StdOut.println("keys(\"\"):");
                iterator = trieSET.iterator();
                while (iterator.hasNext())
                {
                    string obj = (string)iterator.next();
                    StdOut.println(obj);
                }
                StdOut.println();
            }
            StdOut.println("longestPrefixOf(\"shellsort\"):");
            StdOut.println(trieSET.longestPrefixOf("shellsort"));
            StdOut.println();
            StdOut.println("longestPrefixOf(\"xshellsort\"):");
            StdOut.println(trieSET.longestPrefixOf("xshellsort"));
            StdOut.println();
            StdOut.println("keysWithPrefix(\"shor\"):");
            iterator = trieSET.keysWithPrefix("shor").iterator();
            while (iterator.hasNext())
            {
                string obj = (string)iterator.next();
                StdOut.println(obj);
            }
            StdOut.println();
            StdOut.println("keysWithPrefix(\"shortening\"):");
            iterator = trieSET.keysWithPrefix("shortening").iterator();
            while (iterator.hasNext())
            {
                string obj = (string)iterator.next();
                StdOut.println(obj);
            }
            StdOut.println();
            StdOut.println("keysThatMatch(\".he.l.\"):");
            iterator = trieSET.keysThatMatch(".he.l.").iterator();
            while (iterator.hasNext())
            {
                string obj = (string)iterator.next();
                StdOut.println(obj);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new IterableEnumerator(this);
        }
    }
}
