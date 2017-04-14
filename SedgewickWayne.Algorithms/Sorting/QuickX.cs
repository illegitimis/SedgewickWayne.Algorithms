/******************************************************************************
 *  http://algs4.cs.princeton.edu/23quicksort/QuickX.java.html
 *  
 *  Uses the Bentley-McIlroy 3-way partitioning scheme, chooses the 
 *  partitioning element using Tukey's ninther, and cuts off to insertion sort.
 *
 *  Reference: Engineering a Sort Function by Jon L. Bentley
 *  and M. Douglas McIlroy. Softwae-Practice and Experience,
 *  Vol. 23 (11), 1249-1265 (November 1993).
 *
 ******************************************************************************/

namespace SedgewickWayne.Algorithms
{
    using System;


    public static class QuickX<T>
        where T : IComparable<T>
    {
        // cutoff to insertion sort, must be >= 1
        private const int INSERTION_SORT_CUTOFF = 8;

        // cutoff to median-of-3 partitioning
        private const int MEDIAN_OF_3_CUTOFF = 40;

        /**
         * Rearranges the array in ascending order, using the natural order.
         * @param a the array to be sorted
         */
        public static void Sort(T[] a)
        {
            sort(a, 0, a.Length - 1);
        }

        private static void sort(T[] a, int lo, int hi)
        {
            int n = hi - lo + 1;

            // cutoff to insertion sort
            if (n <= INSERTION_SORT_CUTOFF)
            {
                insertionSort(a, lo, hi);
                return;
            }

            // use median-of-3 as partitioning element
            else if (n <= MEDIAN_OF_3_CUTOFF)
            {
                int m = median3(a, lo, lo + n / 2, hi);
                SortingHelper<T>.exch(a, m, lo);
            }

            // use Tukey ninther as partitioning element
            else
            {
                int eps = n / 8;
                int mid = lo + n / 2;
                int m1 = median3(a, lo, lo + eps, lo + eps + eps);
                int m2 = median3(a, mid - eps, mid, mid + eps);
                int m3 = median3(a, hi - eps - eps, hi - eps, hi);
                int ninther = median3(a, m1, m2, m3);
                SortingHelper<T>.exch(a, ninther, lo);
            }

            // Bentley-McIlroy 3-way partitioning
            int i = lo, j = hi + 1;
            int p = lo, q = hi + 1;
            T v = a[lo];
            while (true)
            {
                while (SortingHelper<T>.less(a[++i], v))
                    if (i == hi) break;
                while (SortingHelper<T>.less(v, a[--j]))
                    if (j == lo) break;

                // pointers cross
                if (i == j && SortingHelper<T>.eq(a[i], v))
                    SortingHelper<T>.exch(a, ++p, i);
                if (i >= j) break;

                SortingHelper<T>.exch(a, i, j);
                if (SortingHelper<T>.eq(a[i], v)) SortingHelper<T>.exch(a, ++p, i);
                if (SortingHelper<T>.eq(a[j], v)) SortingHelper<T>.exch(a, --q, j);
            }


            i = j + 1;
            for (int k = lo; k <= p; k++)
                SortingHelper<T>.exch(a, k, j--);
            for (int k = hi; k >= q; k--)
                SortingHelper<T>.exch(a, k, i++);

            sort(a, lo, j);
            sort(a, i, hi);
        }


        // sort from a[lo] to a[hi] using insertion sort
        private static void insertionSort(T[] a, int lo, int hi)
        {
            for (int i = lo; i <= hi; i++)
                for (int j = i; j > lo && SortingHelper<T>.less(a[j], a[j - 1]); j--)
                    SortingHelper<T>.exch(a, j, j - 1);
        }


        // return the index of the median element among a[i], a[j], and a[k]
        private static int median3(T[] a, int i, int j, int k)
        {
            return (SortingHelper<T>.less(a[i], a[j]) ?
                   (SortingHelper<T>.less(a[j], a[k]) ? j : SortingHelper<T>.less(a[i], a[k]) ? k : i) :
                   (SortingHelper<T>.less(a[k], a[j]) ? j : SortingHelper<T>.less(a[k], a[i]) ? k : i));
        }

    }
}
