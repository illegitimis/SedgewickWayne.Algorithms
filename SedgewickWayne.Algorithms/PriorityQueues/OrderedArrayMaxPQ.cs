

namespace SedgewickWayne.Algorithms
{
    using System;

    
    /// <summary>
    /// Priority queue implementation with an ordered array.
    /// </summary>
    /// <remarks>
    /// Limitations:
    /// - no array resizing.
    /// - does not check for overflow or underflow.
    /// </remarks>
    public class OrderedArrayMaxPQ<TKey> : ArrayMaxPQBase<TKey> where TKey : IComparable<TKey>
    {
        public OrderedArrayMaxPQ(int capacity) : base (capacity)
        { 
        }

        public override ArrayMaxPQBase<TKey> Clone()
        {
            var clone = new OrderedArrayMaxPQ<TKey>(this.pq.Length);
            clone.n = this.n;
            clone.pq = this.pq;
            return clone;
        }

        public override TKey Top => pq[n];

        /// <summary>
        /// the code for remove the maximum in the priority queue is the same as for pop in the stack.
        /// </summary>
        /// <returns></returns>
        public override TKey Delete()
        {
            return pq[--n];
        }

        /// <summary>
        ///  move larger entries one position to the right, 
        ///  thus keeping the entries in the array in order (as in insertion sort). 
        ///  Thus the largest item is always at the end.
        /// </summary>
        /// <param name="key"></param>
        public override void Insert(TKey key)
        {
            int i = n - 1;
            while (i >= 0 && less(key, pq[i]))
            {
                pq[i + 1] = pq[i];
                i--;
            }
            pq[i + 1] = key;
            n++;
        }

        private bool less(TKey v, TKey w)
        {
            return v.CompareTo(w) < 0;
        }
    }

}
