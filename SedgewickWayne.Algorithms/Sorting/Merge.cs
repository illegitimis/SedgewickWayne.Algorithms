/******************************************************************************
 *  http://algs4.cs.princeton.edu/22mergesort/Merge.java.html
 *   
 *  Sorts a sequence of strings from standard input using mergesort.
 *  
 ******************************************************************************/


namespace SedgewickWayne.Algorithms
{
  using System;
  using System.Diagnostics;

  /// <summary>
  /// provides static methods for sorting an array using mergesort.
  /// For an optimized version, <see cref="MergeX{T}"/>
  /// </summary>
  /// <typeparam name="T">generic comparable array type</typeparam>
  public static class Merge<T> where T : IComparable<T>
  {
    // stably merge a[lo .. mid] with a[mid+1 ..hi] using aux[lo .. hi]
    private static void merge(T[] a, T[] aux, int lo, int mid, int hi)
    {
      // precondition: a[lo .. mid] and a[mid+1 .. hi] are sorted subarrays
      Debug.Assert(SortingHelper<T>.isSorted(a, lo, mid));
      Debug.Assert(SortingHelper<T>.isSorted(a, mid + 1, hi));

      // copy to aux[]
      for (int k = lo; k <= hi; k++)
      {
        aux[k] = a[k];
      }

      // merge back to a[]
      int i = lo, j = mid + 1;
      for (int k = lo; k <= hi; k++)
      {
        if (i > mid) a[k] = aux[j++];
        else if (j > hi) a[k] = aux[i++];
        else if (SortingHelper<T>.less(aux[j], aux[i])) a[k] = aux[j++];
        else a[k] = aux[i++];
      }

      // postcondition: a[lo .. hi] is sorted
      Debug.Assert(SortingHelper<T>.isSorted(a, lo, hi));
    }

    // mergesort a[lo..hi] using auxiliary array aux[lo..hi]
    private static void sort(T[] a, T[] aux, int lo, int hi)
    {
      if (hi <= lo) return;
      int mid = lo + (hi - lo) / 2;
      sort(a, aux, lo, mid);
      sort(a, aux, mid + 1, hi);
      merge(a, aux, lo, mid, hi);
    }

    /**
     * Rearranges the array in ascending order, using the natural order.
     * @param a the array to be sorted
     */
    public static void Sort(T[] a)
    {
      var aux = new T[a.Length];
      sort(a, aux, 0, a.Length - 1);
      Debug.Assert(SortingHelper<T>.isSorted(a));
    }
  }
}
