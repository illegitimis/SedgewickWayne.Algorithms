using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SedgewickWayne.Algorithms.AnteRoom
{
    public class SymbolGraph
    {
        //[Signature("LST<Ljava/lang/String;Ljava/lang/Integer;>;")]
        private ST st;
        private string[] keys;
        private Graph G;


        public SymbolGraph(string str1, string str2)
        {
            this.st = new ST();
            In @in = new In(str1);
            while (!@in.IsEmpty)
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
            StdOut.println(new StringBuilder().append("Done reading ").append(str1).toString());
            this.keys = new string[this.st.Size];
            Iterator iterator = this.st.keys().iterator();
            while (iterator.hasNext())
            {
                string text = (string)iterator.next();
                this.keys[((Integer)this.st.get(text)).intValue()] = text;
            }
            this.G = new Graph(this.st.Size);
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
        public virtual Graph G()
        {
            return this.G;
        }


        public virtual bool contains(string str)
        {
            return this.st.contains(str);
        }


        public virtual int index(string str)
        {
            return ((Integer)this.st.get(str)).intValue();
        }

        public virtual string name(int i)
        {
            return this.keys[i];
        }


        /**/
        public static void main(string[] strarr)
        {
            string str = strarr[0];
            string str2 = strarr[1];
            SymbolGraph symbolGraph = new SymbolGraph(str, str2);
            Graph graph = symbolGraph.G();
            while (StdIn.hasNextLine())
            {
                string str3 = StdIn.readLine();
                if (symbolGraph.contains(str3))
                {
                    int i = symbolGraph.index(str3);
                    Iterator iterator = graph.adj(i).iterator();
                    while (iterator.hasNext())
                    {
                        int i2 = ((Integer)iterator.next()).intValue();
                        StdOut.println(new StringBuilder().append("   ").append(symbolGraph.name(i2)).toString());
                    }
                }
                else
                {
                    StdOut.println(new StringBuilder().append("input not contain '").append(str3).append("'").toString());
                }
            }
        }
    }
}
