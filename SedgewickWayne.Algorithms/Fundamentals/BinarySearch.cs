// BinarySearch
// http://algs4.cs.princeton.edu/11model/BinarySearch.java.html

namespace SedgewickWayne.Algorithms
{
    using System.Diagnostics;

    /*
     *  The {@code BinarySearch} class provides a static method for binary
     *  searching for an integer in a sorted array of integers.
     *  <p>
     *  The <em>indexOf</em> operations takes logarithmic time in the worst case.
     *  <p>
     *  For additional documentation, see <a href="http://algs4.cs.princeton.edu/11model">Section 1.1</a> of
     *  <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.
     *
     *  @author Robert Sedgewick
     *  @author Kevin Wayne
     */
    public static class BinarySearch
    {

        public static int Rank(int i, int[] iarr)
        {
            Debug.Assert(SortingHelper<int>.isSorted(iarr));
            return indexOf(iarr, i);
        }

        public static int indexOf(int[] a, int key)
        {
            int lo = 0;
            int hi = a.Length - 1;
            while (lo <= hi)
            {
                // Key is in a[lo..hi] or not present.
                int mid = lo + (hi - lo) / 2;
                if (key < a[mid]) hi = mid - 1;
                else if (key > a[mid]) lo = mid + 1;
                else return mid;
            }
            return -1;
        }


    }

}