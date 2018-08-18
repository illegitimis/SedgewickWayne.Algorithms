/*
 * frequency counter
 * https://algs4.cs.princeton.edu/31elementary/tinyTale.txt it 10
 * https://algs4.cs.princeton.edu/31elementary/tale.txt business 122
 * https://algs4.cs.princeton.edu/31elementary/leipzig1M.txt government 24763
 */

namespace SedgewickWayne.Algorithms.MsTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using static SedgewickWayne.Algorithms.MsTest.TestHelper;

    [TestClass]
    public class SymbolTableFrequency
    {
        [TestMethod] public void SequentialSearch() => FrequencyCounter(LINKED_LIST);
        [TestMethod] public void Array() => FrequencyCounter(UNORDERED_ARRAY);
        [TestMethod] public void BinarySearch() => FrequencyCounter(BINARY_SEARCH);


        void FrequencyCounter(string symbolTableType)
        {
            ISymbolTable<string, int> st = Factory<string, int>(symbolTableType);
            var strings = new string[] { "S", "E", "A", "R", "C", "H", "E", "X", "A", "M", "P", "L", "E" };
            FrequencyCounter(st, strings);
            Assert.AreEqual(2, st.Get("A"));
            Assert.AreEqual(3, st.Get("E"));
        }



        // a symbol-table client that finds the number of occurrences of each string 
        // (having at least as many characters as a given threshold length) 
        // in a sequence of strings from standard input, 
        // then iterates through the keys to find the one that occurs the most frequently
        static void FrequencyCounter(ISymbolTable<string, int> st, IEnumerable<string> strings)
        {
            foreach (string s in strings)
            {
                if (st.Contains(s))
                {
                    st.Put(s, 1 + st.Get(s));
                }
                else
                {
                    st.Put(s, 1);
                }
            }
        }
    }
}
