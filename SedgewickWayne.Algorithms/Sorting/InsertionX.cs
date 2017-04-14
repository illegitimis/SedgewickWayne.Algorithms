/******************************************************************************
 *  algs4.cs.princeton.edu/21elementary/InsertionX.java.html
 *  Data files:   http://algs4.cs.princeton.edu/21elementary/tiny.txt
 *                http://algs4.cs.princeton.edu/21elementary/words3.txt
 *  SORTING
 *  Sorts a sequence of strings from standard input using an optimized
 *  version of insertion sort that uses half exchanges instead of 
 *  full exchanges to reduce data movement..
 *
 *  % more tiny.txt
 *  S O R T E X A M P L E
 *
 *  % java InsertionX < tiny.txt
 *  A E E L M O P R S T X                 [ one string per line ]
 *
 *  % more words3.txt
 *  bed bug dad yes zoo ... all bad yet
 *
 *  % java InsertionX < words3.txt
 *  all bad bed bug dad ... yes yet zoo   [ one string per line ]
 *
 ******************************************************************************/

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Diagnostics;

    /**
     *  The {@code InsertionX} class provides static methods for sorting an array 
     *  using an optimized version of insertion sort (with half exchanges and a sentinel).
     *  <p>
     *  For additional documentation, see <a href="http://algs4.cs.princeton.edu/21elementary">Section 2.1</a> 
     *  of <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.
     *
     *  @author Robert Sedgewick
     *  @author Kevin Wayne
     */
    public static class InsertionX<T>
        where T : IComparable<T>
    {
        /**
    * Rearranges the array in ascending order, using the natural order.
    * @param a the array to be sorted
    */
        //public static void Sort(IComparable<T>[] a)
        public static void Sort(T[] a)
        {
            int n = a.Length;

            // put smallest element in position to serve as sentinel
            int exchanges = 0;
            for (int i = n - 1; i > 0; i--)
            {
                if (SortingHelper<T>.less(a[i], a[i - 1]))
                {
                    SortingHelper<T>.exch(a, i, i - 1);
                    exchanges++;
                }
            }
            if (exchanges == 0) return;


            // insertion sort with half-exchanges
            for (int i = 2; i < n; i++)
            {
                var v = a[i];
                int j = i;
                while (SortingHelper<T>.less(v, a[j - 1]))
                {
                    a[j] = a[j - 1];
                    j--;
                }
                a[j] = v;
            }

            Debug.Assert (SortingHelper<T>.isSorted(a));
        }
    }
}
