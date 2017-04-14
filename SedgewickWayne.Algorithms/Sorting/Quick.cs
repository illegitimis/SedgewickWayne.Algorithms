/******************************************************************************
 *  http://algs4.cs.princeton.edu/23quicksort/Quick.java.html
 *  Remark: For a type-safe version that uses static generics, see
 *  http://algs4.cs.princeton.edu/23quicksort/QuickPedantic.java  
 *  
 *  QUICKSORT
 *  Sorts a sequence of strings from standard input using quicksort.
 *  provides static methods for sorting an array and selecting the 
 *  ith smallest element in an array using quicksort.
 *   
 ******************************************************************************/

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    public static class Quick<T>
        where T : IComparable<T>
    {
        /**
    * Rearranges the array in ascending order, using the natural order.
    * @param a the array to be sorted
    */
        public static void Sort(T[] a)
        {
            StdRandom.shuffle(a);
            
            sort(a, 0, a.Length - 1);
            Debug.Assert (SortingHelper<T>.isSorted(a));
        }

        // quicksort the subarray from a[lo] to a[hi]
        private static void sort(T[] a, int lo, int hi)
        {
            if (hi <= lo) return;
            int j = partition(a, lo, hi);
            sort(a, lo, j - 1);
            sort(a, j + 1, hi);
            Debug.Assert (SortingHelper<T>.isSorted(a, lo, hi));
        }

        // partition the subarray a[lo..hi] so that a[lo..j-1] <= a[j] <= a[j+1..hi]
        // and return the index j.
        private static int partition(T[] a, int lo, int hi)
        {
            int i = lo;
            int j = hi + 1;
            T v = a[lo];
            while (true)
            {

                // find item on lo to swap
                while (SortingHelper<T>.less(a[++i], v))
                    if (i == hi) break;

                // find item on hi to swap
                while (SortingHelper<T>.less(v, a[--j]))
                    if (j == lo) break;      // redundant since a[lo] acts as sentinel

                // check if pointers cross
                if (i >= j) break;

                SortingHelper<T>.exch(a, i, j);
            }

            // put partitioning item v at a[j]
            SortingHelper<T>.exch(a, lo, j);

            // now, a[lo .. j-1] <= a[j] <= a[j+1 .. hi]
            return j;
        }

        /**
         * Rearranges the array so that {@code a[k]} contains the kth smallest key;
         * {@code a[0]} through {@code a[k-1]} are less than (or equal to) {@code a[k]}; and
         * {@code a[k+1]} through {@code a[n-1]} are greater than (or equal to) {@code a[k]}.
         *
         * @param  a the array
         * @param  k the rank of the key
         * @return the key of rank {@code k}
         */
        public static T Select(T[] a, int k)
        {
            if (k < 0 || k >= a.Length) throw new  IndexOutOfRangeException ("Selected element out of bounds");
            StdRandom.shuffle(a);

            int lo = 0, hi = a.Length - 1;
            while (hi > lo)
            {
                int i = partition(a, lo, hi);
                if (i > k) hi = i - 1;
                else if (i < k) lo = i + 1;
                else return a[i];
            }
            return a[lo];
        }
    }
}

