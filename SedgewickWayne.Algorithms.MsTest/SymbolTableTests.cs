/*
 * Data files:   
 * http://algs4.cs.princeton.edu/31elementary/tinyST.txt  
 * http://algs4.cs.princeton.edu/32bst/TestBST.java.html
 * http://algs4.cs.princeton.edu/32bst/PerfectBalance.java.html
 * 
 * 
 *  % more tinyST.txt
 *  S E A R C H E X A M P L E
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
 */

namespace SedgewickWayne.Algorithms.MsTest
{
    using System;
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
            /*
             ST<String, Double> grades = new ST<String, Double>();
        grades.put("A",  4.00);
        grades.put("B",  3.00);
        grades.put("C",  2.00);
        grades.put("D",  1.00);
        grades.put("F",  0.00);
        grades.put("A+", 4.33);
        grades.put("B+", 3.33);
        grades.put("C+", 2.33);
        grades.put("A-", 3.67);
        grades.put("B-", 2.67);
             */
        }


        /// <summary>
        /// http://algs4.cs.princeton.edu/31elementary/TestBinarySearchST.java.html
        /// </summary>
        [TestMethod]
        public void TestBinarySearchST()
        {

        }

        /// <summary>
        /// http://algs4.cs.princeton.edu/31elementary/PhoneNumber.java.html
        /// </summary>
        [TestMethod]
        public void PhoneNumberTest ()
        {

        }

        /// <summary>
        /// http://algs4.cs.princeton.edu/31elementary/Student.java.html
        /// </summary>
        [TestMethod]
        public void StudentComparatorTest()
        {

        }
    }

}
