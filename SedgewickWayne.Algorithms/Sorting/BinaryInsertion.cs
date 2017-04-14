/******************************************************************************
 *  http://algs4.cs.princeton.edu/21elementary/BinaryInsertion.java.html
 *
 *  BINARY INSERTION SORT
 *  Sorts a sequence of strings from standard input using 
 *  binary insertion sort with half exchanges.
 *
 ******************************************************************************/

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Diagnostics;

    /**
 *  The {@code BinaryInsertion} class provides a static method for sorting an
 *  array using an optimized binary insertion sort with half exchanges.
 *  <p>
 *  This implementation makes ~ n lg n compares for any array of length n. 
 *  However, in the worst case, the running time is quadratic because the
 *  number of array accesses can be proportional to n^2 (e.g, if the array
 *  is reverse sorted). As such, it is not suitable for sorting large
 *  arrays (unless the number of inversions is small).
 *  <p>
 *  The sorting algorithm is stable and uses O(1) extra memory.
 *  <p>
 *  For additional documentation, see <a href="http://algs4.cs.princeton.edu/21elementary">Section 2.1</a> 
 *  of <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.
 *
 *  @author Ivan Pesin
 *  @author Robert Sedgewick
 *  @author Kevin Wayne
 */
    public static class BinaryInsertion<T>
        where T : IComparable<T> 
    {
        //public static void Sort(IComparable<T>[] a)
        public static void Sort(T[] a)
        {
            int n = a.Length;
            for (int i = 1; i < n; i++)
            {
                // binary search to determine index j at which to insert a[i]
                var v = a[i];
                int lo = 0, hi = i;
                while (lo < hi)
                {
                    int mid = lo + (hi - lo) / 2;
                    if (SortingHelper<T>.less(v, a[mid])) hi = mid;
                    else lo = mid + 1;
                }

                // insetion sort with "half exchanges"
                // (insert a[i] at index j and shift a[j], ..., a[i-1] to right)
                for (int j = i; j > lo; --j)
                    a[j] = a[j - 1];
                a[lo] = v;
            }

            Debug.Assert (SortingHelper<T>.isSorted(a));
        }
    }
}
