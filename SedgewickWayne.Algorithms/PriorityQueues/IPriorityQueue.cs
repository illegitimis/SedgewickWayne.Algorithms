
// Priority Queues

using System;
using System.Collections.Generic;

namespace SedgewickWayne.Algorithms
{

    public interface IPriorityQueue<TKey>
        : IEnumerable<TKey>
        , IHaveSize
        , ICheckEmpty
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// largest / lowest key
        /// </summary>
        TKey Top { get; }

        /// <summary>
        /// Remove and return the top key
        /// </summary>
        /// <returns></returns>
        TKey Delete();

        /// <summary>
        /// Insert a key into the queue.
        /// </summary>
        /// <param name="key">what to insert</param>
        void Insert(TKey key);
    }

    public interface IMaxPriorityQueue<TKey> 
        : IPriorityQueue<TKey>
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// 
        /// </summary>
        TKey Max { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        TKey DeleteMax();
    }

    public interface IMinPriorityQueue<TKey> 
        : IPriorityQueue<TKey>
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// 
        /// </summary>
        TKey Min { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        TKey DeleteMin();
    }

    public interface IIndexedPriorityQueue<TKey> : 
        // IList<int>
        // , IPriorityQueue<TKey>
        IEnumerable<int>
        , IHaveSize
        , ICheckEmpty
        where TKey : System.IComparable<TKey>
    {
        /// <summary>
        /// index associated with a minimum/maximum key
        /// </summary>
        int Index { get; }

        // new if hiding intended
        //bool Contains(int i);

        int DeleteIndex();

        TKey DeleteKey();

        TKey KeyOf(int i);

        void ChangeKey(int i, TKey key);

        /// <summary>
        /// Insert a key into the queue at the specified index.
        /// </summary>
        /// <param name="i">where to insert</param>
        /// <param name="key">what to insert</param>
        void Insert(int i, TKey key);
    }

    public interface IIndexedMinPriorityQueue<TKey>
        : IIndexedPriorityQueue<TKey>
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// 
        /// </summary>
        int MinIndex { get; }
    }

    public interface IIndexedMaxPriorityQueue<TKey>
        : IIndexedPriorityQueue<TKey>
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// 
        /// </summary>
        int MaxIndex { get; }
    }

}
