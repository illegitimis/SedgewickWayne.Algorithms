/******************************************************************************
 *  Generic Insertion sort from §2.1 Elementary Sorts.
 *  http://algs4.cs.princeton.edu/21elementary/Insertion.java.html
 *  http://algs4.cs.princeton.edu/21elementary/InsertionPedantic.java.html
 *  
 *  Sorts a sequence of strings from standard input using insertion sort.
 *  Copyright © 2000–2017, Robert Sedgewick and Kevin Wayne. 
 *  Last updated: Sat Apr 1 05:15:15 EDT 2017.
 *
 ******************************************************************************/


namespace SedgewickWayne.Algorithms
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;


  /// <summary>
  /// Provides static methods for sorting an array using insertion sort.
  /// This implementation makes ~ 1/2 n^2 compares and exchanges in the worst case, so it is not suitable for sorting large arbitrary arrays.
  /// More precisely, the number of exchanges is exactly equal to the number of inversions. 
  /// So, for example, it sorts a partially-sorted array in linear time.
  /// The sorting algorithm is stable and uses O(1) extra memory.
  /// </summary>
  /// <typeparam name="T">comparable generic type</typeparam>
  public static class Insertion<T>
        where T : IComparable<T>
  {
    /// <summary>
    /// Rearranges the array in ascending order, using the natural order.
    /// </summary>
    /// <param name="a">the array to be sorted</param>
    public static void Sort(T[] a)
    {
      int n = a.Length;
      for (int i = 0; i < n; i++)
      {
        for (int j = i; j > 0 && SortingHelper<T>.less(a[j], a[j - 1]); j--)
        {
          SortingHelper<T>.exch(a, j, j - 1);
        }
        Debug.Assert(SortingHelper<T>.isSorted(a, 0, i));
      }
      Debug.Assert(SortingHelper<T>.isSorted(a));
    }


    /// <summary>
    /// Rearranges the subarray a[lo..hi) in ascending order, using the natural order.
    /// </summary>
    /// <param name="a">the array to be sorted</param>
    /// <param name="lo">left endpoint (inclusive)</param>
    /// <param name="hi">right endpoint (exclusive)</param>
    public static void Sort(T[] a, int lo, int hi)
    {
      for (int i = lo; i < hi; i++)
      {
        for (int j = i; j > lo && SortingHelper<T>.less(a[j], a[j - 1]); j--)
        {
          SortingHelper<T>.exch(a, j, j - 1);
        }
      }
      Debug.Assert(SortingHelper<T>.isSorted(a, lo, hi));
    }

    /// <summary>
    /// Rearranges the array in ascending order, using a comparator.
    /// </summary>
    /// <param name="a">the array</param>
    /// <param name="comparator">the comparator specifying the order</param>
    public static void Sort(T[] a, IComparer<T> comparator)
    {
      int n = a.Length;
      for (int i = 0; i < n; i++)
      {
        for (int j = i; j > 0 && SortingHelper<T>.less(a[j], a[j - 1], comparator); j--)
        {
          SortingHelper<T>.exch(a, j, j - 1);
        }
        Debug.Assert(SortingHelper<T>.isSorted(a, 0, i, comparator));
      }
      Debug.Assert(SortingHelper<T>.isSorted(a, comparator));
    }

    /// <summary>
    /// Rearranges the subarray a[lo..hi) in ascending order, using a comparator.
    /// </summary>
    /// <param name="a">the array</param>
    /// <param name="lo">left endpoint (inclusive)</param>
    /// <param name="hi">right endpoint (exclusive)</param>
    /// <param name="comparator">the comparator specifying the order</param>
    public static void Sort(T[] a, int lo, int hi, IComparer<T> comparator)
    {
      for (int i = lo; i < hi; i++)
      {
        for (int j = i; j > lo && SortingHelper<T>.less(a[j], a[j - 1], comparator); j--)
        {
          SortingHelper<T>.exch(a, j, j - 1);
        }
      }
      Debug.Assert(SortingHelper<T>.isSorted(a, lo, hi, comparator));
    }


    // return a permutation that gives the elements in a[] in ascending order
    // do not change the original array a[]
    /**
     * Returns a permutation that gives the elements in the array in ascending order.
     * @param a the array
     * @return a permutation {@code p[]} such that {@code a[p[0]]}, {@code a[p[1]]},
     *    ..., {@code a[p[n-1]]} are in ascending order
     */
    //public static int[] IndexSort(IComparable<T>[] a)
    public static int[] IndexSort(T[] a)
    {
      int n = a.Length;
      int[] index = new int[n];
      for (int i = 0; i < n; i++)
        index[i] = i;

      for (int i = 0; i < n; i++)
        for (int j = i; j > 0 && SortingHelper<T>.less(a[index[j]], a[index[j - 1]]); j--)
          SortingHelper<int>.exch(index, j, j - 1);

      return index;
    }

  }

}