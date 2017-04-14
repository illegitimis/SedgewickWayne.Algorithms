using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SedgewickWayne.Algorithms.AnteRoom
{

    public class NFA
    {
        private Digraph G;
        private string regexp;
        private int M;
        //[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
        internal static bool s_assertionsDisabled;




        public NFA(string str)
        {
            this.regexp = str;
            this.M = java.lang.String.instancehelper_length(str);
            Stack stack = new Stack();
            this.G = new Digraph(this.M + 1);
            for (int i = 0; i < this.M; i++)
            {
                int num = i;
                if (java.lang.String.instancehelper_charAt(str, i) == '(' || java.lang.String.instancehelper_charAt(str, i) == '|')
                {
                    stack.push(Integer.valueOf(i));
                }
                else if (java.lang.String.instancehelper_charAt(str, i) == ')')
                {
                    int num2 = ((Integer)stack.pop()).intValue();
                    if (java.lang.String.instancehelper_charAt(str, num2) == '|')
                    {
                        num = ((Integer)stack.pop()).intValue();
                        this.G.addEdge(num, num2 + 1);
                        this.G.addEdge(num2, i);
                    }
                    else if (java.lang.String.instancehelper_charAt(str, num2) == '(')
                    {
                        num = num2;
                    }
                    else if (!NFA.s_assertionsDisabled)
                    {

                        throw new AssertionError();
                    }
                }
                if (i < this.M - 1 && java.lang.String.instancehelper_charAt(str, i + 1) == '*')
                {
                    this.G.addEdge(num, i + 1);
                    this.G.addEdge(i + 1, num);
                }
                if (java.lang.String.instancehelper_charAt(str, i) == '(' || java.lang.String.instancehelper_charAt(str, i) == '*' || java.lang.String.instancehelper_charAt(str, i) == ')')
                {
                    this.G.addEdge(i, i + 1);
                }
            }
        }


        public virtual bool recognizes(string str)
        {
            DirectedDFS directedDFS = new DirectedDFS(this.G, 0);
            Bag bag = new Bag();
            for (int i = 0; i < this.G.V(); i++)
            {
                if (directedDFS.marked(i))
                {
                    bag.add(Integer.valueOf(i));
                }
            }
            for (int i = 0; i < java.lang.String.instancehelper_length(str); i++)
            {
                Bag bag2 = new Bag();
                Iterator iterator = bag.iterator();
                while (iterator.hasNext())
                {
                    int num = ((Integer)iterator.next()).intValue();
                    if (num != this.M)
                    {
                        if (java.lang.String.instancehelper_charAt(this.regexp, num) == java.lang.String.instancehelper_charAt(str, i) || java.lang.String.instancehelper_charAt(this.regexp, num) == '.')
                        {
                            bag2.add(Integer.valueOf(num + 1));
                        }
                    }
                }
                directedDFS = new DirectedDFS(this.G, bag2);
                bag = new Bag();
                for (int j = 0; j < this.G.V(); j++)
                {
                    if (directedDFS.marked(j))
                    {
                        bag.add(Integer.valueOf(j));
                    }
                }
                if (bag.Size == 0)
                {
                    return false;
                }
            }
            Iterator iterator2 = bag.iterator();
            while (iterator2.hasNext())
            {
                int num2 = ((Integer)iterator2.next()).intValue();
                if (num2 == this.M)
                {
                    return true;
                }
            }
            return false;
        }


        /**/
        public static void main(string[] strarr)
        {
            string str = new StringBuilder().append("(").append(strarr[0]).append(")").toString();
            string text = strarr[1];
            if (java.lang.String.instancehelper_indexOf(text, 124) >= 0)
            {
                string arg_40_0 = "| character in text is not supported";

                throw new ArgumentException(arg_40_0);
            }
            NFA nFA = new NFA(str);
            StdOut.println(nFA.recognizes(text));
        }

        static NFA()
        {
            NFA.s_assertionsDisabled = !ClassLiteral<NFA>.Value.desiredAssertionStatus();
        }
    }
}
