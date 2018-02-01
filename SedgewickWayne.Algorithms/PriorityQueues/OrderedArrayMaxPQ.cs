

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
    public class OrderedArrayMaxPQ<TKey>
        : ArrayPQBase<TKey>
        , IMaxPriorityQueue<TKey>
        where TKey : IComparable<TKey>
    {
        public OrderedArrayMaxPQ(int capacity = 0) : base(capacity)
        {
        }

        public override ArrayPQBase<TKey> Clone()
        {
            var clone = new OrderedArrayMaxPQ<TKey>(this.pq.Length);
            clone.n = this.n;
            clone.pq = this.pq;
            return clone;
        }

        public override TKey Top => pq[n];

        public TKey Max => throw new NotImplementedException();

        /// <summary>
        /// the code for remove the maximum in the priority queue is the same as for pop in the stack.
        /// </summary>
        /// <returns></returns>
        public override TKey Delete()
        {
            // half capacity if less than quarter
            if ((n > 0) && (n == pq.Length / 4)) resize(pq.Length / 2);

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
            // double size of array if necessary
            if (n == 0) resize(4);
            else if (n == pq.Length) resize(2 * pq.Length);

            int i = n - 1;
            while (i >= 0 && predicate(key, pq[i]))
            {
                pq[i + 1] = pq[i];
                i--;
            }
            pq[i + 1] = key;


            n++;
        }

        bool predicate(TKey v, TKey w) => v.CompareTo(w) < 0;

        public override bool ComparePredicate(int i, int j) => pq[i].CompareTo(pq[j]) < 0;

        public TKey DeleteMax() => Delete();
    }

}
