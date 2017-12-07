// BinarySearch
// http://algs4.cs.princeton.edu/11model/BinarySearch.java.html

namespace SedgewickWayne.Algorithms
{
  using System.Diagnostics;


  /// <summary>
  /// Provides a static method for binary searching for an integer in a sorted array of integers.
  /// </summary>
  public static class BinarySearch
  {

    /// <summary>
    /// Searches <paramref name="i"/> within <paramref name="iarr"/> integer array.
    /// </summary>
    /// <param name="i">value</param>
    /// <param name="iarr">array</param>
    /// <returns>array index if element found, otherwise -1.</returns>
    public static int Rank(int i, int[] iarr)
    {
      Debug.Assert(SortingHelper<int>.isSorted(iarr));
      return IndexOf(iarr, i);
    }

    /// <summary>
    /// operations takes logarithmic time in the worst case.
    /// </summary>
    /// <param name="a">sorted array where a value is sought</param>
    /// <param name="key">value sought</param>
    /// <returns></returns>
    public static int IndexOf(int[] a, int key)
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