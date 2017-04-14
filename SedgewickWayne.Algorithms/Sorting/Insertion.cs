/******************************************************************************
 *  Non-Generic Insertion sort from §2.1 Elementary Sorts.
 *  http://algs4.cs.princeton.edu/21elementary/Insertion.java
  ******************************************************************************/

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections;
    using System.Diagnostics;

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
