
/******************************************************************************
 *  http://algs4.cs.princeton.edu/24pq/Heap.java.html
 *  HEAPSORTING
 *  Sorts a sequence of strings from standard input using heapsort.
 *
 ******************************************************************************/

namespace SedgewickWayne.Algorithms
{
  using System;
  public static class Heap<T>
      where T : IComparable<T>
  {

    /// <summary>
    /// Rearranges the array in ascending order, using the natural order.
    /// </summary>
    /// <param name="pq">the array to be sorted</param>
    public static void Sort(T[] pq)
    {
      int n = pq.Length;
      for (int k = n / 2; k >= 1; k--)
        sink(pq, k, n);
      while (n > 1)
      {
        exch(pq, 1, n--);
        sink(pq, 1, n);
      }
    }

    /***************************************************************************
     * Helper functions to restore the heap invariant.
     ***************************************************************************/

    private static void sink(T[] pq, int k, int n)
    {
      while (2 * k <= n)
      {
        int j = 2 * k;
        if (j < n && less(pq, j, j + 1)) j++;
        if (!less(pq, k, j)) break;
        exch(pq, k, j);
        k = j;
      }
    }

    /***************************************************************************
     * Helper functions for comparisons and swaps.
     * Indices are "off-by-one" to support 1-based indexing.
     ***************************************************************************/
    private static bool less(T[] pq, int i, int j)
    {
      return pq[i - 1].CompareTo(pq[j - 1]) < 0;
    }

    private static void exch(T[] pq, int i, int j)
    {
      T swap = pq[i - 1];
      pq[i - 1] = pq[j - 1];
      pq[j - 1] = swap;
    }


  }
}
