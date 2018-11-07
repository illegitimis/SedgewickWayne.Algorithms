/******************************************************************************
 *  http://algs4.cs.princeton.edu/12oop/SetofInts.java.html
 *  Data type to store a set of integers.
 ******************************************************************************/

namespace SedgewickWayne.Algorithms
{
    using System;

    /// <summary>
    /// SetofInts class represents a set of integers. 
    /// It supports searching for a given integer is in the set. 
    /// It accomplishes this by keeping the set of integers in a 
    /// sorted array and using binary search to find the given integer.
    /// The <see cref="rank"/> and <see cref="contains"/> operations 
    /// take logarithmic time in the worst case.
    /// </summary>
    public class SetofInts
    {
        private int[] a;
		
        public SetofInts(int[] iarr)
        {
            this.a = new int[iarr.Length];
            for (int i = 0; i < iarr.Length; i++) this.a[i] = iarr[i];
            Array.Sort(a);

            for (int i = 1; i < this.a.Length; i++)
            {
                if (a[i] == a[i - 1])
                {
                    throw new ArgumentException("Argument arrays contains duplicate keys.");
                }
            }
        }


        /// <summary>
        /// Returns either the index of the search key in the sorted array
        /// </summary>
        /// <param name="i">search key</param>
        /// <returns>
        /// the number of keys in this set less than the key 
        /// (if the key is in the set) 
        /// or -1 (if the key is not in the set).
        /// </returns>
        public virtual int Rank(int i)
        {
            int lo = 0;
            int hi = this.a.Length - 1;

            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (i < this.a[mid])
                {
                    hi = mid - 1;
                }
                else if (i > this.a[mid])
                {
                    lo = mid + 1;
                }
                else
                {
                    return mid;
                }
            }
            return -1;
        }

        /// <summary>
        /// Is the key in this set of integers?
        /// </summary>
        /// <param name="i">the search key</param>
        /// <returns>true if the set of integers contains the key; false otherwise</returns>
        public virtual bool Contains(int i)
        {
            return Rank(i) != -1;
        }
    }

}