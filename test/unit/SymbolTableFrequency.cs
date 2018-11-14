/*
 * frequency counter
 * https://algs4.cs.princeton.edu/31elementary/tinyTale.txt it 10
 * https://algs4.cs.princeton.edu/31elementary/tale.txt business 122
 * https://algs4.cs.princeton.edu/31elementary/leipzig1M.txt government 24763
 */

namespace SedgewickWayne.Algorithms.UnitTests
{
    using Xunit;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using static SedgewickWayne.Algorithms.UnitTests.TestHelper;

    
    public class SymbolTableFrequency
    {
        [Fact] public void SequentialSearch() => FrequencyCounter(LINKED_LIST);
        [Fact] public void Array() => FrequencyCounter(UNORDERED_ARRAY);
        [Fact] public void BinarySearch() => FrequencyCounter(BINARY_SEARCH);
        [Fact] public void Bst() => FrequencyCounter(BST);
        [Fact] public void LinearProbing() => FrequencyCounter(LINEAR_PROBING);
        [Fact] public void NonRecursiveBst() => FrequencyCounter(NON_RECURSIVE_BST);
        [Fact] public void RandomizedBst() => FrequencyCounter(RANDOMIZED_BST);
        [Fact] public void RedBlackBst() => FrequencyCounter(RED_BLACK_BST);
        [Fact] public void SeparateChainingHashST() => FrequencyCounter(SEPARATE_CHAINING_HASH);

        /// <summary>
        /// https://algs4.cs.princeton.edu/34hash/tinyST.txt
        /// </summary>
        /// <param name="symbolTableType"></param>
        void FrequencyCounter(string symbolTableType)
        {
            ISymbolTable<string, int> st = Factory<string, int>(symbolTableType);
            var strings = new string[] { "S", "E", "A", "R", "C", "H", "E", "X", "A", "M", "P", "L", "E" };
            FrequencyCounter(st, strings);
            Assert.Equal(2, st.Get("A"));
            Assert.Equal(3, st.Get("E"));
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
