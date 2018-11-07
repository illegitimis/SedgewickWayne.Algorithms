using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SedgewickWayne.Algorithms.SymbolTables
{
    class TrieST
    {
    }
}


/*
 

//[Signature("<Value:Ljava/lang/Object;>Ljava/lang/Object;")]
public class TrieST
{
	\/*[EnclosingMethod("TrieST", null, null), InnerClass(null, Modifiers.Static | Modifiers.Synthetic), Modifiers(Modifiers.Super | Modifiers.Synthetic), SourceFile("TrieST.java")]*\/

[InnerClass(null, Modifiers.Private | Modifiers.Static), Modifiers(Modifiers.Super), SourceFile("TrieST.java")]
internal sealed class Node
{
    private object val;
    private TrieST.Node[] next;
    
    internal static object access_000(TrieST.Node node)
    {
        return node.val;
    }
    
    internal static TrieST.Node[] access_100(TrieST.Node node)
    {
        return node.next;
    }
    

    internal Node(TrieST.1) : this()
    {
    }
    \/*		[LineNumberTable(55), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*\/
    internal static object access_002(TrieST.Node node, object result)
    {
        node.val = result;
        return result;
    }


    private Node()
    {
        this.next = new TrieST.Node[256];
    }
}
private const int R = 256;
private TrieST.Node root;
private int N;


private TrieST.Node get(TrieST.Node node, string text, int num)
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
    return this.get(TrieST.Node.access_100(node)[num2], text, num + 1);
}
\/*	[Signature("(Ljava/lang/String;)TValue;")]*\/

public virtual object get(string str)
{
    TrieST.Node node = this.get(this.root, str, 0);
    if (node == null)
    {
        return null;
    }
    return TrieST.Node.access_000(node);
}


public virtual void delete(string str)
{
    this.root = this.delete(this.root, str, 0);
}
\/*	[Signature("(LTrieST$Node;Ljava/lang/String;TValue;I)LTrieST$Node;")]*\/

private TrieST.Node put(TrieST.Node node, string text, object obj, int num)
{
    if (node == null)
    {
        node = new TrieST.Node(null);
    }
    if (num == java.lang.String.instancehelper_length(text))
    {
        if (TrieST.Node.access_000(node) == null)
        {
            this.N++;
        }
        TrieST.Node.access_002(node, obj);
        return node;
    }
    int num2 = (int)java.lang.String.instancehelper_charAt(text, num);
    TrieST.Node.access_100(node)[num2] = this.put(TrieST.Node.access_100(node)[num2], text, obj, num + 1);
    return node;
}
public virtual int Size
{
		return this.N;
}
\/*	[Signature("(Ljava/lang/String;)Ljava/lang/Iterable<Ljava/lang/String;>;")]*\/

public virtual Iterable keysWithPrefix(string str)
{
    Queue queue = new Queue();
    TrieST.Node node = this.get(this.root, str, 0);
    this.collect(node, new StringBuilder(str), queue);
    return queue;
}
\/*	[Signature("(LTrieST$Node;Ljava/lang/StringBuilder;LQueue<Ljava/lang/String;>;)V")]*\/

private void collect(TrieST.Node node, StringBuilder stringBuilder, Queue queue)
{
    if (node == null)
    {
        return;
    }
    if (TrieST.Node.access_000(node) != null)
    {
        queue.enqueue(stringBuilder.toString());
    }
    for (int i = 0; i < 256; i = (int)((ushort)(i + 1)))
    {
        stringBuilder.append((char)i);
        this.collect(TrieST.Node.access_100(node)[i], stringBuilder, queue);
        stringBuilder.deleteCharAt(stringBuilder.Length() - 1);
    }
}
\/*	[Signature("(LTrieST$Node;Ljava/lang/StringBuilder;Ljava/lang/String;LQueue<Ljava/lang/String;>;)V")]*\/

private void collect(TrieST.Node node, StringBuilder stringBuilder, string text, Queue queue)
{
    if (node == null)
    {
        return;
    }
    int num = stringBuilder.Length();
    if (num == java.lang.String.instancehelper_length(text) && TrieST.Node.access_000(node) != null)
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
            this.collect(TrieST.Node.access_100(node)[i], stringBuilder, text, queue);
            stringBuilder.deleteCharAt(stringBuilder.Length() - 1);
        }
    }
    else
    {
        stringBuilder.append((char)num2);
        this.collect(TrieST.Node.access_100(node)[num2], stringBuilder, text, queue);
        stringBuilder.deleteCharAt(stringBuilder.Length() - 1);
    }
}


private int longestPrefixOf(TrieST.Node node, string text, int num, int num2)
{
    if (node == null)
    {
        return num2;
    }
    if (TrieST.Node.access_000(node) != null)
    {
        num2 = num;
    }
    if (num == java.lang.String.instancehelper_length(text))
    {
        return num2;
    }
    int num3 = (int)java.lang.String.instancehelper_charAt(text, num);
    return this.longestPrefixOf(TrieST.Node.access_100(node)[num3], text, num + 1, num2);
}


private TrieST.Node delete(TrieST.Node node, string text, int num)
{
    if (node == null)
    {
        return null;
    }
    if (num == java.lang.String.instancehelper_length(text))
    {
        if (TrieST.Node.access_000(node) != null)
        {
            this.N--;
        }
        TrieST.Node.access_002(node, null);
    }
    else
    {
        int i = (int)java.lang.String.instancehelper_charAt(text, num);
        TrieST.Node.access_100(node)[i] = this.delete(TrieST.Node.access_100(node)[i], text, num + 1);
    }
    if (TrieST.Node.access_000(node) != null)
    {
        return node;
    }
    for (int i = 0; i < 256; i++)
    {
        if (TrieST.Node.access_100(node)[i] != null)
        {
            return node;
        }
    }
    return null;
}


public TrieST()
{
}
\/*	[Signature("(Ljava/lang/String;TValue;)V")]*\/

public virtual void put(string str, object obj)
{
    if (obj == null)
    {
        this.delete(str);
    }
    else
    {
        this.root = this.put(this.root, str, obj, 0);
    }
}
\/*	[LineNumberTable(146), Signature("()Ljava/lang/Iterable<Ljava/lang/String;>;")]*\/

public virtual Iterable keys()
{
    return this.keysWithPrefix("");
}


public virtual string longestPrefixOf(string str)
{
    int endIndex = this.longestPrefixOf(this.root, str, 0, 0);
    return java.lang.String.instancehelper_substring(str, 0, endIndex);
}
\/*	[Signature("(Ljava/lang/String;)Ljava/lang/Iterable<Ljava/lang/String;>;")]*\/

public virtual Iterable keysThatMatch(string str)
{
    Queue queue = new Queue();
    this.collect(this.root, new StringBuilder(), str, queue);
    return queue;
}


public virtual bool contains(string str)
{
    return this.get(str) != null;
}


public virtual bool IsEmpty
{
		return this.Size == 0;
}



public static void main(string[] strarr)
{
    TrieST trieST = new TrieST();
    int num = 0;
    while (!StdIn.IsEmpty)
    {
        string text = StdIn.readString();
        trieST.put(text, Integer.valueOf(num));
        num++;
    }
    Iterator iterator;
    if (trieST.Size < 100)
    {
        StdOut.println("keys(\"\"):");
        iterator = trieST.keys().iterator();
        while (iterator.hasNext())
        {
            string text = (string)iterator.next();
            StdOut.println(new StringBuilder().append(text).append(" ").append(trieST.get(text)).toString());
        }
        StdOut.println();
    }
    StdOut.println("longestPrefixOf(\"shellsort\"):");
    StdOut.println(trieST.longestPrefixOf("shellsort"));
    StdOut.println();
    StdOut.println("keysWithPrefix(\"shor\"):");
    iterator = trieST.keysWithPrefix("shor").iterator();
    while (iterator.hasNext())
    {
        string text = (string)iterator.next();
        StdOut.println(text);
    }
    StdOut.println();
    StdOut.println("keysThatMatch(\".he.l.\"):");
    iterator = trieST.keysThatMatch(".he.l.").iterator();
    while (iterator.hasNext())
    {
        string text = (string)iterator.next();
        StdOut.println(text);
    }
}
}

 */