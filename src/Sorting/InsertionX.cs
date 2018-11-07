/****************************************************************************
  http://algs4.cs.princeton.edu/21elementary/InsertionX.java.html

  SORTING
  Sorts a sequence using an optimized version of insertion sort that 
  uses half exchanges instead of full exchanges to reduce data movement..

 *****************************************************************************/

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Diagnostics;

     
    /// <summary>
    /// Provides static methods for sorting an array using an optimized version of insertion sort (with half exchanges and a sentinel).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class InsertionX<T>
        where T : IComparable<T>
    {    
        /// <summary>
        /// Rearranges the array in ascending order, using the natural order.
        /// </summary>
        /// <param name="a">the array to be sorted</param>
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
