namespace SedgewickWayne.Algorithms
{
    using System;

    /// <summary>
    /// Priority queue implementation with an unsorted array.
    /// Perhaps the simplest priority queue implementation is based on our code for pushdown stacks.
    /// </summary>
    /// <remarks>
    /// Limitations:
    /// - no array resizing.
    /// - does not check for overflow or underflow.
    /// </remarks>
    /// <typeparam name="TKey"></typeparam>
    public class UnorderedArrayMaxPQ<TKey>
        : ArrayPQBase<TKey>
        , IMaxPriorityQueue<TKey>
        where TKey : IComparable<TKey>

    {
        /// <summary>
        /// set inititial size of heap to hold size elements
        /// </summary>
        public UnorderedArrayMaxPQ(int capacity=0) : base(capacity) { }

        public override ArrayPQBase<TKey> Clone()
        {
            var clone = new UnorderedArrayMaxPQ<TKey>(this.pq.Length);
            clone.pq = this.pq;
            clone.n = this.n;
            // foreach (var x in this.pq) clone.Insert(x);
            return clone;
        }

        /// <summary>
        /// The code for insert in the priority queue is the same as for push in the stack.
        /// </summary>
        /// <param name="key"></param>
        public override void Insert(TKey key)
        {
            // double size of array if necessary
            if (n == 0) resize(4);
            else if (n == pq.Length) resize(2 * pq.Length);
            pq[n++] = key;
        }

        /// <summary>
        /// code like the inner loop of selection sort to exchange the 
        /// maximum item with the item at the end and then delete that one, 
        /// as we did with pop() for stacks.
        /// </summary>
        /// <returns></returns>
        public override TKey Delete()
        {
            DeleteStep();

            return pq[--n];
        }

        private void DeleteStep()
        {
            int max = 0;

            for (int i = 1; i < n; i++)
                if (ComparePredicate(max, i))
                    max = i;

            exch(max, n - 1);
        }

        public override TKey Top {
            get {
                DeleteStep();

                return pq[n];
            }
        }

        public TKey Max => Top;

        public override bool ComparePredicate(int i, int j) => pq[i].CompareTo(pq[j]) < 0; 

        private void exch(int i, int j)
        {
            TKey swap = pq[i];
            pq[i] = pq[j];
            pq[j] = swap;
        }

        public TKey DeleteMax() => Delete();
    }

}
