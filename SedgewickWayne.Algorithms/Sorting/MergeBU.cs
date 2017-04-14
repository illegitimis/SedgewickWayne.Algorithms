/******************************************************************************
 *  http://algs4.cs.princeton.edu/22mergesort/MergeBU.java.html
 *  BOTTOM-UP MERGESORT
 *  Sorts a sequence of strings from standard input using bottom-up mergesort.
 *   
 ******************************************************************************/


namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Diagnostics;


    public static class MergeBU<T> 
        where T : IComparable<T>
    {
        private static void merge(T[] a, T[] aux, int lo, int mid, int hi)
        {

            // copy to aux[]
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = a[k];
            }

            // merge back to a[]
            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid) a[k] = aux[j++];  // this copying is unneccessary
                else if (j > hi) a[k] = aux[i++];
                else if (SortingHelper<T>.less(aux[j], aux[i])) a[k] = aux[j++];
                else a[k] = aux[i++];
            }

        }

        /**
         * Rearranges the array in ascending order, using the natural order.
         * @param a the array to be sorted
         */
        public static void Sort(T[] a)
        {
            int n = a.Length;
            var aux = new T[n];
            for (int len = 1; len < n; len *= 2)
            {
                for (int lo = 0; lo < n - len; lo += len + len)
                {
                    int mid = lo + len - 1;
                    int hi = Math.Min(lo + len + len - 1, n - 1);
                    merge(a, aux, lo, mid, hi);
                }
            }

            Debug.Assert (SortingHelper<T>.isSorted(a));
        }

    }
}
