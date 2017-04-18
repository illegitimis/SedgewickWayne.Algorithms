public class SymbolDigraph
{
    //[Signature("LST<Ljava/lang/String;Ljava/lang/Integer;>;")]
    private ST st;
    private string[] keys;
    private Digraph G;


    public SymbolDigraph(string str1, string str2)
    {
        this.st = new ST();
        In @in = new In(str1);
        while (@in.hasNextLine())
        {
            string[] array = java.lang.String.instancehelper_split(@in.readLine(), str2);
            for (int i = 0; i < array.Length; i++)
            {
                if (!this.st.contains(array[i]))
                {
                    this.st.put(array[i], Integer.valueOf(this.st.Size));
                }
            }
        }
        this.keys = new string[this.st.Size];
        Iterator iterator = this.st.keys().iterator();
        while (iterator.hasNext())
        {
            string text = (string)iterator.next();
            this.keys[((Integer)this.st.get(text)).intValue()] = text;
        }
        this.G = new Digraph(this.st.Size);
        @in = new In(str1);
        while (@in.hasNextLine())
        {
            string[] array = java.lang.String.instancehelper_split(@in.readLine(), str2);
            int i = ((Integer)this.st.get(array[0])).intValue();
            for (int j = 1; j < array.Length; j++)
            {
                int i2 = ((Integer)this.st.get(array[j])).intValue();
                this.G.addEdge(i, i2);
            }
        }
    }
    public virtual Digraph G()
    {
        return this.G;
    }


    public virtual int index(string str)
    {
        return ((Integer)this.st.get(str)).intValue();
    }

    public virtual string name(int i)
    {
        return this.keys[i];
    }


    public virtual bool contains(string str)
    {
        return this.st.contains(str);
    }


    /**/
    public static void main(string[] strarr)
    {
        string str = strarr[0];
        string str2 = strarr[1];
        SymbolDigraph symbolDigraph = new SymbolDigraph(str, str2);
        Digraph digraph = symbolDigraph.G();
        while (!StdIn.IsEmpty)
        {
            string str3 = StdIn.readLine();
            Iterator iterator = digraph.adj(symbolDigraph.index(str3)).iterator();
            while (iterator.hasNext())
            {
                int i = ((Integer)iterator.next()).intValue();
                StdOut.println(new StringBuilder().append("   ").append(symbolDigraph.name(i)).toString());
            }
        }
    }
}