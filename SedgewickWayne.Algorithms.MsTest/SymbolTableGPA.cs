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
 */

namespace SedgewickWayne.Algorithms.MsTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using static SedgewickWayne.Algorithms.MsTest.TestHelper;

    [TestClass]
    public class SymbolTableBasic
    {
        /// <summary>
        /// http://algs4.cs.princeton.edu/31elementary/GPA.java.html
        /// Create a symbol table mapping letter grades to numerical scores
        /// A- B+ B+ B- | GPA = 3.25
        /// </summary>
        [TestMethod] public void linked_list() => GPA(LINKED_LIST);
        [TestMethod] public void unordered_array() => GPA(UNORDERED_ARRAY);
        [TestMethod] public void binary_search() => GPA(BINARY_SEARCH);

        void GPA(string st)
        {
            ISymbolTable<String, Double> grades = GetGrades(st);
            var values = new[] { grades.Get("A-"), grades.Get("A+"), grades.Get("B-"), grades.Get("B+") };
            Assert.AreEqual(3.5, values.Average());
        }

        ISymbolTable<String, Double> GetGrades(string st)
        {
            ISymbolTable<String, Double> grades = Factory<String, Double>(st);

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

    }


}


