namespace SedgewickWayne.Algorithms
{
    using System;

    /// <summary>
    /// Base class for symbol tables based on tree structures
    /// </summary>
    /// <typeparam name="TKey">key type</typeparam>
    /// <typeparam name="TValue">value type</typeparam>
    public abstract class TreeSTBase<TKey, TValue>
        : OrderedSTBase<TKey, TValue>
        where TKey : IComparable<TKey>, IEquatable<TKey>
        where TValue : IEquatable<TValue>
    {
        /// <summary>
        /// root of BST
        /// </summary>
        protected BaseNode<TKey, TValue> root;

        #region overrides

        /// <summary>
        /// Returns the number of key-value pairs in this symbol table.
        /// </summary>
        public override int Size => NodeSize(root);

        /// <summary>
        /// Returns the largest key in the symbol table.
        /// </summary>
        public override TKey Max
        {
            get
            {
                SymbolTableUnderflow();
                return MaximumKey(root);
            }
        }

        public override TKey Min
        {
            get
            {
                SymbolTableUnderflow();
                return MinimumKey(root);
            }
        }

        /// <summary>
        /// Return the number of keys in the symbol table strictly less than <paramref name="key"/>
        /// </summary>
        /// <param name="key">the key</param>
        /// <returns></returns>
        public override int Rank(TKey key)
        {
            KeyArgumentNull(key, nameof(Rank));
            return NodeRank(key, root);
        }

        /// <summary>Gets the value associated with the given key in this symbol table.</summary>
        /// <param name="key">search key</param>
        /// <returns>sought value</returns>
        public override TValue Get(TKey key)
        {
            KeyArgumentNull(key, nameof(Get));
            return GetKey(root, key);
        }

        /// <summary>
        /// A symbol table implements the associative array abstraction.
        /// When associating a value with a key that is already in the symbol table, the convention is to replace the old value with the new value.
        /// Setting the value associated with a key to null is equivalent to deleting the key from the symbol table.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        public override void Put(TKey key, TValue val)
        {
            KeyArgumentNull(key, nameof(Put));
            if (val.Equals(default(TValue)))
            {
                Delete(key);
                return;
            }
            root = PutKey(root, key, val);
        }

        /// <summary>
        /// Return the key in the symbol table whose rank is <paramref name="k"/>.
        /// This is the (k+1)st smallest key in the symbol table. 
        /// </summary>
        /// <param name="k">the order statistic</param>
        /// <returns>the key in the symbol table of rank <paramref name="k"/></returns>
        public override TKey Select(int k)
        {
            SelectOutOfRange(k);
            var x = SelectKey(root, k);
            return x.key;
        }

        #endregion

        #region protected

        /// <summary>
        /// Number of key-value pairs in BST rooted at x
        /// </summary>
        /// <param name="x">tree node</param>
        /// <returns>Number of nodes in subtree rooted at x</returns>
        protected int NodeSize(BaseNode<TKey, TValue> x) => (x == null) ? 0 : x.size;

        /// <summary>
        /// Number of keys in the subtree less than key.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        protected int NodeRank(TKey key, BaseNode<TKey, TValue> x)
        {
            if (x == null) return 0;
            int cmp = key.CompareTo(x.key);
            if (cmp < 0) return NodeRank(key, x.left);
            else if (cmp > 0) return 1 + NodeSize(x.left) + NodeRank(key, x.right);
            else return NodeSize(x.left);
        }

        protected BaseNode<TKey, TValue> SelectKey(BaseNode<TKey, TValue> x, int k)
        {
            if (x == null) return null;
            int t = NodeSize(x.left);
            if (t > k) return SelectKey(x.left, k);
            else if (t < k) return SelectKey(x.right, k - t - 1);
            else return x;
        }

        #endregion

        #region abstract

        internal abstract TValue GetKey(BaseNode<TKey, TValue> root, TKey key);
        internal abstract BaseNode<TKey, TValue> PutKey(BaseNode<TKey, TValue> x, TKey key, TValue val);
        internal abstract BaseNode<TKey, TValue> MaximumNode(BaseNode<TKey, TValue> node);
        internal abstract BaseNode<TKey, TValue> MinimumNode(BaseNode<TKey, TValue> node);
        #endregion
        internal virtual void CheckBstDataStructure()
        {
        }

        // internal abstract TKey MaximumKey(BaseNode<TKey, TValue> node);
        internal virtual TKey MaximumKey(BaseNode<TKey, TValue> node) => MaximumNode(node).key;

        // internal abstract TKey MinimumKey(BaseNode<TKey, TValue> node);
        internal virtual TKey MinimumKey(BaseNode<TKey, TValue> node) => MinimumNode(node).key;

    }
}
