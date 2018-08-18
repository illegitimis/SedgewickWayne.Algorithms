
/******************************************************************************
 *  http://algs4.cs.princeton.edu/21elementary/Shell.java.html
 *
 *  SORTING SHELLSORT
 *  Sorts a sequence of strings from standard input using shellsort.
 *
 ******************************************************************************/

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Diagnostics;

    /**
 *  The {@code Shell} class provides static methods for sorting an
 *  array using Shellsort with Knuth's increment sequence (1, 4, 13, 40, ...).
 
 <a href="http://algs4.cs.princeton.edu/21elementary">Section 2.1</a> 
 *  of <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.
 *  
 

 */
    public static class Shell<T> 
        where T : IComparable<T>
    {
        /**
    * Rearranges the array in ascending order, using the natural order.
    * @param a the array to be sorted
    */
        public static void Sort(T[] a)
        {
            int n = a.Length;

            // 3x+1 increment sequence:  1, 4, 13, 40, 121, 364, 1093, ... 
            int h = 1;
            while (h < n / 3) h = 3 * h + 1;

            while (h >= 1)
            {
                // h-sort the array
                for (int i = h; i < n; i++)
                {
                    for (int j = i; j >= h && SortingHelper<T>.less(a[j], a[j - h]); j -= h)
                    {
                        SortingHelper<T>.exch(a, j, j - h);
                    }
                }
                Debug.Assert (isHSorted(a, h));
                h /= 3;
            }
            Debug.Assert (SortingHelper<T>.isSorted(a));
        }

        // is the array h-sorted?
        private static bool isHSorted(T[] a, int h)
        {
            for (int i = h; i < a.Length; i++)
                if (SortingHelper<T>.less(a[i], a[i - h])) return false;
            return true;
        }
    }
}
