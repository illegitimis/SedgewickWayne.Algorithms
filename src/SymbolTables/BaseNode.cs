namespace SedgewickWayne.Algorithms
{

    /// <summary>
    /// inner node class
    /// </summary>
    /// <remarks>better as struct? No can't do because of variable size.</remarks>
    public class BaseNode<TKey, TValue>
    {
        internal TKey key;           // sorted by key
        internal TValue val;         // associated data
        internal int size;          // number of nodes in subtree / subtree count
        internal BaseNode<TKey, TValue> left, right;  // links to left and right subtrees

        public BaseNode(TKey key, TValue val, int size)
        {
            this.key = key;
            this.val = val;
            this.size = size;
        }

        internal void UpdateSizeFromChildren()
        {
            size = 1 + ((left == null) ? 0 : left.size) + ((right == null) ? 0 : right.size);
        }
    }

    public enum NodeColor { RED, BLACK }

    public class RedBlackNode<TKey, TValue>
        : BaseNode<TKey, TValue>
    {
        internal NodeColor color;     // color of parent link
        
        public RedBlackNode(TKey key, TValue val, NodeColor color, int size)
            : base(key, val, size)
        {
           this.color = color;
        }

        public bool IsRed => color == NodeColor.RED;
        public bool IsBlack => color == NodeColor.BLACK;

        public void FlipColor() => color = IsRed ? NodeColor.BLACK : NodeColor.RED;

        public RedBlackNode<TKey, TValue> Left => left as RedBlackNode<TKey, TValue>;
        public RedBlackNode<TKey, TValue> Right => right as RedBlackNode<TKey, TValue>;
    }
}
