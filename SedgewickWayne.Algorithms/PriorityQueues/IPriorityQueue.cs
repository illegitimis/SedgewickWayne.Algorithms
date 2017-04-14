
// PriorityQueues

namespace SedgewickWayne.Algorithms
{

    public interface IPriorityQueue<TKey>
        : System.Collections.Generic.IEnumerable<TKey>
        , IHaveSize
        , ICheckEmpty
        where TKey : System.IComparable<TKey>
    {
        /// <summary>
        /// largest / lowest key
        /// </summary>
        TKey Top { get; }

        void Insert(TKey x);

        TKey Delete();        
    }

    public interface IMaxPriorityQueue<TKey>
    {
        TKey Max { get; }
        int MaxIndex { get; }
        TKey DeleteMax();
    }

    public interface IMinPriorityQueue<TKey>
    {
        TKey Min { get; }
        int MinIndex { get; }
        TKey DeleteMin();
    }

    public interface IIndexedPriorityQueue<TKey> 
        : System.Collections.Generic.IEnumerable<int>
        , IHaveSize
        , ICheckEmpty
        where TKey : System.IComparable<TKey>
    {
        int Index { get; }
        bool Contains(int i);

        void Insert(int i, TKey key);        

        int DeleteIndex();
        TKey DeleteKey();

        TKey KeyOf(int i);

        void ChangeKey(int i, TKey key);
    }
}
