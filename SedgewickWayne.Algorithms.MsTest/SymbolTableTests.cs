/*
 * Data files:   
 * http://algs4.cs.princeton.edu/31elementary/tinyST.txt  
 * http://algs4.cs.princeton.edu/32bst/TestBST.java.html
 * http://algs4.cs.princeton.edu/32bst/PerfectBalance.java.html
 * 
 * 
 *  
 *  % java BinarySearchST < tinyST.txt
 *  A 8
 *  C 4
 *  E 12
 *  H 5
 *  L 11
 *  M 9
 *  P 10
 *  R 3
 *  S 0
 *  X 7
 *  
 *  % java SequentialSearchST < tiny.txt 
 *  L 11
 *  P 10
 *  M 9
 *  X 7
 *  H 5
 *  C 4
 *  R 3
 *  A 8
 *  E 12
 *  S 0
 *  
 * frequency counter
 * https://algs4.cs.princeton.edu/31elementary/tinyTale.txt it 10
 * https://algs4.cs.princeton.edu/31elementary/tale.txt business 122
 * https://algs4.cs.princeton.edu/31elementary/leipzig1M.txt government 24763
 */

namespace SedgewickWayne.Algorithms.MsTest
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SymbolTableTests
    {
        /// <summary>
        /// http://algs4.cs.princeton.edu/31elementary/GPA.java.html
        /// Create a symbol table mapping letter grades to numerical scores
        /// A- B+ B+ B- | GPA = 3.25
        /// </summary>
        [TestMethod]
        public void GPA()
        {
            ISymbolTable<String, Double> grades = GetGrades();

            Assert.AreEqual(3.5, new[] { grades.Get("A-"), grades.Get("A+"), grades.Get("B-"), grades.Get("B+") });
        }

        [TestMethod]
        public void FrequencyCounter_ST()
        {
            var st = new SequentialSearchST<string, int>();
            var strings = new string[] { "S", "E", "A", "R", "C", "H", "E", "X", "A", "M", "P", "L", "E" };
            FrequencyCounter(st, strings);
        }

        ISymbolTable<String, Double> GetGrades()
        {
            ISymbolTable<String, Double> grades = new SequentialSearchST<String, Double>();
            grades.Put("A", 4.00);
            grades.Put("B", 3.00);
            grades.Put("C", 2.00);
            grades.Put("D", 1.00);
            grades.Put("F", 0.00);
            grades.Put("A+", 4.33);
            grades.Put("B+", 3.33);
            grades.Put("C+", 2.33);
            grades.Put("A-", 3.67);
            grades.Put("B-", 2.67);

            return grades;
        }


        /// <summary>
        /// http://algs4.cs.princeton.edu/31elementary/TestBinarySearchST.java.html
        /// </summary>
        [TestMethod]
        public void TestBinarySearchST()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// http://algs4.cs.princeton.edu/31elementary/PhoneNumber.java.html
        /// </summary>
        [TestMethod]
        public void PhoneNumberTest ()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// http://algs4.cs.princeton.edu/31elementary/Student.java.html
        /// </summary>
        [TestMethod]
        public void StudentComparatorTest()
        {
            throw new NotImplementedException();
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


