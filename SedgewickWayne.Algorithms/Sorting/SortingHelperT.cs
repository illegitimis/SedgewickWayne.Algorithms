
namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections.Generic;
    
    public /*static*/ class SortingHelper<T> 
        where T : IComparable<T>
    {

/***************************************************************************
*  Helper sorting functions.
***************************************************************************/
        internal static bool less(IComparable<T> v, IComparable<T> w)
        {
            return v.CompareTo((T)w) < 0;
        }

        /*
        public static bool operator < (IComparable<T> left, IComparable<T> right)
        {
            return left.CompareTo((T)right) < 0;
        }
        public static bool operator > (IComparable<T> left, IComparable<T> right)
        {
            return left.CompareTo((T)right) > 0;
        }
        */

        // is v < w ?
        internal static bool less(T v, T w) { return v.CompareTo(w) < 0; }
        internal static bool eq(T v, T w) { return v.CompareTo(w) == 0; }

        // is v < w ?
        internal static bool less(T v, T w, IComparer<T> comparator) { return comparator.Compare(v, w) < 0; }

        // exchange a[i] and a[j]
        internal static void exch(T[] a, int i, int j)
        {
            T swap = a[i];
            a[i] = a[j];
            a[j] = swap;
        }

        internal static void exch(IComparable<T>[] a, int i, int j)
        {
            IComparable<T> swap = a[i];
            a[i] = a[j];
            a[j] = swap;
        }

        /***************************************************************************
        *  Check if array is sorted - useful for debugging.
        ***************************************************************************/
        internal static bool isSorted(T[] a)
        {
            //return isSorted(a as IComparable<T>[]);
            return isSorted(a, 0, a.Length);
        }

        /*
        internal static bool isSorted(IComparable<T>[] a)
        {
            return isSorted(a, 0, a.Length);
        }
        */

        // is the array a[lo..hi) sorted

        /*
        internal static bool isSorted(IComparable<T>[] a, int lo, int hi)
        {
            for (int i = lo + 1; i < hi; i++)
                if (less(a[i], a[i - 1])) return false;
            return true;
        }
        */

        internal static bool isSorted(T[] a, int lo, int hi)
        {
            //return isSorted(a as IComparable<T>[], lo, hi);
            for (int i = lo + 1; i < hi; i++)
                if (less(a[i], a[i - 1])) return false;
            return true;
        }

        internal static bool isSorted(T[] a, IComparer<T> comparator)
        {
            return isSorted(a, 0, a.Length, comparator);
        }

        // is the array a[lo..hi) sorted
        internal static bool isSorted(T[] a, int lo, int hi, IComparer<T> comparator)
        {
            for (int i = lo + 1; i < hi; i++)
                if (less(a[i], a[i - 1], comparator)) return false;
            return true;
        }


    }
}
