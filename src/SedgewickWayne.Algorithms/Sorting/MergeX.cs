/******************************************************************************
 *  http://algs4.cs.princeton.edu/22mergesort/MergeX.java.html
 *     
 *  OPTIMIZED MERGESORT  
 ******************************************************************************/

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Diagnostics;


  /// <summary>
  /// Sorts a sequence of strings from standard input using an optimized version of mergesort.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public static class MergeX<T> where T : IComparable<T>
    {
        private const int CUTOFF = 7;  // cutoff to insertion sort

        // This class should not be instantiated.
        private static void merge(T[] src, T[] dst, int lo, int mid, int hi)
        {

            // precondition: src[lo .. mid] and src[mid+1 .. hi] are sorted subarrays
            Debug.Assert (SortingHelper<T>.isSorted(src, lo, mid));
            Debug.Assert (SortingHelper<T>.isSorted(src, mid+1, hi));

            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid) dst[k] = src[j++];
                else if (j > hi) dst[k] = src[i++];
                else if (SortingHelper<T>.less(src[j], src[i])) dst[k] = src[j++];   // to ensure stability
                else dst[k] = src[i++];
            }

            // postcondition: dst[lo .. hi] is sorted subarray
            Debug.Assert (SortingHelper<T>.isSorted(dst, lo, hi));
        }

        private static void sort(T[] src, T[] dst, int lo, int hi)
        {
            // if (hi <= lo) return;
            if (hi <= lo + CUTOFF)
            {
                insertionSort(dst, lo, hi);
                return;
            }
            int mid = lo + (hi - lo) / 2;
            sort(dst, src, lo, mid);
            sort(dst, src, mid + 1, hi);

            // if (!less(src[mid+1], src[mid])) {
            //    for (int i = lo; i <= hi; i++) dst[i] = src[i];
            //    return;
            // }

            // using System.arraycopy() is a bit faster than the above loop
            if (! SortingHelper<T>.less(src[mid + 1], src[mid]))
            {
                Array.Copy (src, lo, dst, lo, hi - lo + 1);
                return;
            }

            merge(src, dst, lo, mid, hi);
        }

          /// <summary>
          /// Rearranges the array in ascending order, using the natural order.
          /// </summary>
          /// <param name="a">the array to be sorted</param>
        public static void Sort(T[] a)
        {
            T[] aux = (T[])a.Clone();
            sort(aux, a, 0, a.Length - 1);
            Debug.Assert (SortingHelper<T>.isSorted(a));
        }

        // sort from a[lo] to a[hi] using insertion sort
        private static void insertionSort(T[] a, int lo, int hi)
        {
            for (int i = lo; i <= hi; i++)
                for (int j = i; j > lo && SortingHelper<T>.less(a[j], a[j - 1]); j--)
                    SortingHelper<T>.exch(a, j, j - 1);
        }

    }
}
