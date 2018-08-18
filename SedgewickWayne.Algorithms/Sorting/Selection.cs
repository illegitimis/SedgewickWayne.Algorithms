
/******************************************************************************
 *  http://algs4.cs.princeton.edu/21elementary/Selection.java.html
 *  Data files:   http://algs4.cs.princeton.edu/21elementary/tiny.txt
 *                http://algs4.cs.princeton.edu/21elementary/words3.txt
 *  SORTING   
 *  Sorts a sequence of strings from standard input using selection sort.
 *   
 *  % more tiny.txt
 *  S O R T E X A M P L E
 *
 *  % java Selection < tiny.txt
 *  A E E L M O P R S T X                 [ one string per line ]
 *    
 *  % more words3.txt
 *  bed bug dad yes zoo ... all bad yet
 *  
 *  % java Selection < words3.txt
 *  all bad bed bug dad ... yes yet zoo    [ one string per line ]
 *
 ******************************************************************************/

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    /**
 *  The {@code Selection} class provides static methods 
 *  for sorting an array using selection sort.
 
 <a href="http://algs4.cs.princeton.edu/21elementary">Section 2.1</a> 
 *  of <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.
 *
 

 */
    public static class Selection<T>
        where T : IComparable<T>
    {
        /**
     * Rearranges the array in ascending order, using the natural order.
     * @param a the array to be sorted
     */
        public static void Sort(T[] a)
        {
            int n = a.Length;
            for (int i = 0; i < n; i++)
            {
                int min = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (SortingHelper<T>.less(a[j], a[min])) min = j;
                }
                SortingHelper<T>.exch(a, i, min);

                Debug.Assert(SortingHelper<T>.isSorted(a, 0, i));
            }
            Debug.Assert(SortingHelper<T>.isSorted(a));
        }

        /**
         * Rearranges the array in ascending order, using a comparator.
         * @param a the array
         * @param comparator the comparator specifying the order
         */
        public static void Sort(T[] a, IComparer<T> comparator)
        {
            int n = a.Length;

            for (int i = 0; i < n; i++)
            {
                int min = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (SortingHelper<T>.less(a[j], a[min], comparator)) min = j;
                }
                SortingHelper<T>.exch(a, i, min);

                Debug.Assert(SortingHelper<T>.isSorted(a, 0, i, comparator));
            }

            Debug.Assert(SortingHelper<T>.isSorted(a, comparator));
        }
    }
}
