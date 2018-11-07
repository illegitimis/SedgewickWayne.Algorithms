/******************************************************************************
 *  Non-Generic Insertion sort from §2.1 Elementary Sorts.
 *  http://algs4.cs.princeton.edu/21elementary/Insertion.java
  ******************************************************************************/

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections;
    using System.Diagnostics;

  /// <summary>
  /// provides static methods for sorting an array using insertion sort.
  /// </summary>
    public class Insertion
    {
        #region less

        private static bool less(IComparable o, IComparable comparable)
        {
            //return Comparable.__Helper.CompareTo(o, comparable) < 0;
            return o.CompareTo(comparable) < 0;
        }

        private static bool less(IComparer comparator, object obj, object obj2)
        {
            return comparator.Compare(obj, obj2) < 0;
        }

        #endregion

        #region exchange 
        private static void exch(object[] array, int num, int num2)
        {
            object obj = array[num];
            array[num] = array[num2];
            array[num2] = obj;
        }

        private static void exch(int[] array, int num, int num2)
        {
            int num3 = array[num];
            array[num] = array[num2];
            array[num2] = num3;
        }

        #endregion

        #region Is Sorted ?

        private static bool isSorted(IComparable[] array, int num, int num2)
        {
            for (int i = num + 1; i <= num2; i++)
            {
                if (Insertion.less(array[i], array[i - 1]))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool isSorted(IComparable[] array)
        {
            return Insertion.isSorted(array, 0, array.Length - 1);
        }

        private static bool isSorted(object[] array, IComparer comparator, int num, int num2)
        {
            for (int i = num + 1; i <= num2; i++)
            {
                if (Insertion.less(comparator, array[i], array[i - 1]))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool isSorted(object[] array, IComparer comparator)
        {
            return Insertion.isSorted(array, comparator, 0, array.Length - 1);
        }

    #endregion

    /// <summary>
    /// Rearranges the array in ascending order, using the natural order.
    /// </summary>
    /// <param name="carr">the array to be sorted</param>
    public static void Sort(IComparable[] carr)
        {
            int num = carr.Length;
            for (int i = 0; i < num; i++)
            {
                int num2 = i;
                while (num2 > 0 && Insertion.less(carr[num2], carr[num2 - 1]))
                {
                    Insertion.exch(carr, num2, num2 - 1);
                    num2 += -1;
                }

                Debug.Assert(Insertion.isSorted(carr, 0, i));
            }

            Debug.Assert(Insertion.isSorted(carr));
        }

    /// <summary>
    /// Rearranges the array in ascending order, using a comparator.
    /// </summary>
    /// <param name="objarr">the array</param>
    /// <param name="c">comparator the comparator specifying the order, Java type is <see cref="Comparator"/></param>
    public static void Sort(object[] objarr, IComparer c)
        {
            int num = objarr.Length;
            for (int i = 0; i < num; i++)
            {
                int num2 = i;
                while (num2 > 0 && Insertion.less(c, objarr[num2], objarr[num2 - 1]))
                {
                    Insertion.exch(objarr, num2, num2 - 1);
                    num2 += -1;
                }

                Debug.Assert(Insertion.isSorted(objarr, c, 0, i));
            }

            Debug.Assert(Insertion.isSorted(objarr, c));
    }

    /// <summary>
    /// Returns a permutation that gives the elements in a[] in ascending order. 
    /// Does not change the original array, <paramref name="carr"/>
    /// </summary>
    /// <param name="carr">the array</param>
    /// <returns>a permutation p[]} such that a[p[0]], a[p[1]], ...,  a[p[n - 1]] are in ascending order</returns>
    public static int[] IndexSort(IComparable[] carr)
        {
            int num = carr.Length;
            int[] array = new int[num];
            for (int i = 0; i < num; i++)
            {
                array[i] = i;
            }
            for (int i = 0; i < num; i++)
            {
                int num2 = i;
                while (num2 > 0 && Insertion.less(carr[array[num2]], carr[array[num2 - 1]]))
                {
                    Insertion.exch(array, num2, num2 - 1);
                    num2 += -1;
                }
            }
            return array;
        }


    }
}
