
/**
 * http://algs4.cs.princeton.edu/32bst/BST.java.html
 * 
*  The {@code BST} class 
*  It supports the usual put, get, contains,
*  delete, size, and is-empty methods.
*  It also provides ordered methods for finding the minimum,
*  maximum, floor, select, ceiling.
*  It also provides a keys method for iterating over all of the keys.

*  
*  
*  It requires that the key type implements the {@code Comparable} interface and calls the
*  {@code compareTo()} and method to compare two keys. 
*  It does not call either {@code equals()} or {@code hashCode()}.
*  The put, contains, remove, minimum,
*  maximum, ceiling, floor, select, and
*  rank  operations each take linear time in the worst case, 
*  if the tree becomes unbalanced. 
*  The size, and is-empty operations take constant time.
*  
*  
<a href="http://algs4.cs.princeton.edu/32bst">Section 3.2</a> of

*  For other implementations, see {@link ST}, {@link BinarySearchST},
*  {@link SequentialSearchST}, {@link RedBlackBST},
*  {@link SeparateChainingHashST}, and {@link LinearProbingHashST}

*/

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections;
    using System.Collections.Generic;


    /// <summary>
    /// Represents an ordered symbol table of generic key-value pairs.
    /// This implementation uses an (UNBALANCED) BINARY SEARCH TREE.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <remarks>
    /// Construction takes constant time.
    /// </remarks>
    public class BST<TKey, TValue>
        : TreeSTBase<TKey, TValue>
        where TKey : IComparable<TKey>, IEquatable<TKey>
        where TValue : IEquatable<TValue>
    {
        /// <summary>
        /// Initializes empty BST
        /// </summary>
        public BST()
        {
        }

        internal override BaseNode<TKey, TValue> MinimumNode(BaseNode<TKey, TValue> x) => (x.left == null) ? x : MinimumNode(x.left);

        internal override BaseNode<TKey, TValue> MaximumNode(BaseNode<TKey, TValue> x) => (x.right == null) ? x : MaximumNode(x.right);

        public override TKey Ceiling(TKey key)
        {
            KeyArgumentNull(key, nameof(Ceiling));
            SymbolTableUnderflow();
            var x = CeilingNode(root, key);
            if (x == null) return default(TKey);
            else return x.key;
        }

        private BaseNode<TKey, TValue> CeilingNode(BaseNode<TKey, TValue> x, TKey key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.key);
            if (cmp == 0) return x;
            if (cmp < 0)
            {
                var t = CeilingNode(x.left, key);
                if (t != null) return t;
                else return x;
            }
            return CeilingNode(x.right, key);
        }

        /// <summary>
        /// Removes the specified key and its associated value from this symbol table if present
        /// </summary>
        /// <param name="key">the key</param>
        public override void Delete(TKey key)
        {
            KeyArgumentNull(key, nameof(Delete));
            root = DeleteNode(root, key);
            CheckBstDataStructure();
        }

        private BaseNode<TKey, TValue> DeleteNode(BaseNode<TKey, TValue> x, TKey key)
        {
            if (x == null) return null;

            int cmp = key.CompareTo(x.key);
            if (cmp < 0) x.left = DeleteNode(x.left, key);
            else if (cmp > 0) x.right = DeleteNode(x.right, key);
            else
            {
                if (x.right == null) return x.left;
                if (x.left == null) return x.right;
                BaseNode<TKey, TValue> t = x;
                x = MinimumNode(t.right);
                x.right = DeleteMinimum(t.right);
                x.left = t.left;
            }
            x.size = NodeSize(x.left) + NodeSize(x.right) + 1;
            return x;
        }

        public override void DeleteMax()
        {
            if (IsEmpty) throw new InvalidOperationException("Symbol table underflow");
            root = DeleteMaximum(root);
            CheckBstDataStructure();
        }

        /// <summary>
        /// Removes the largest key and associated value from the symbol table.
        /// </summary>
        /// <param name="x">element to start recursion from</param>
        /// <returns>root?</returns>
        private BaseNode<TKey, TValue> DeleteMaximum(BaseNode<TKey, TValue> x)
        {
            if (x.right == null) return x.left;
            x.right = DeleteMaximum(x.right);
            x.size = NodeSize(x.left) + NodeSize(x.right) + 1;
            return x;
        }

        public override void DeleteMin()
        {
            SymbolTableUnderflow();
            root = DeleteMinimum(root);
            CheckBstDataStructure();
        }

        private BaseNode<TKey, TValue> DeleteMinimum(BaseNode<TKey, TValue> x)
        {
            if (x.left == null) return x.right;
            x.left = DeleteMinimum(x.left);
            x.size = NodeSize(x.left) + NodeSize(x.right) + 1;
            return x;
        }

        /// <summary>
        /// Returns the largest key in the symbol table less than or equal to <paramref name="key"/>
        /// </summary>
        /// <param name="key">the key</param>
        /// <returns>the largest key in the symbol table less than or equal to <paramref name="key"/></returns>
        /// <example>
        /// <code>
        /// public Key floor2(Key key) => floor2(root, key, null);
        /// 
        ///         private Key floor2(Node x, Key key, Key best) {
        ///             if (x == null) return best;
        ///             int cmp = key.compareTo(x.key);
        ///             if (cmp < 0) return floor2(x.left, key, best);
        ///             else if (cmp > 0) return floor2(x.right, key, x.key);
        ///             else return x.key;
        ///             }
        /// </code>
        /// </example>
        public override TKey Floor(TKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            if (IsEmpty) throw new InvalidOperationException("empty symbol table");
            BaseNode<TKey, TValue> x = FloorNode(root, key);
            if (x == null) return default(TKey);
            else return x.key;
        }

        private BaseNode<TKey, TValue> FloorNode(BaseNode<TKey, TValue> x, TKey key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.key);
            if (cmp == 0) return x;
            if (cmp < 0) return FloorNode(x.left, key);
            BaseNode<TKey, TValue> t = FloorNode(x.right, key);
            if (t != null) return t;
            else return x;
        }
        
        public override IEnumerator<TKey> GetEnumerator() => Keys().GetEnumerator();

        /// <summary>
        /// Returns all keys in the symbol table in the given range
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TKey> Keys()
        {
            if (IsEmpty) return new Queue<TKey>();
            return KeysInRange(Min, Max);
        }

        /// <summary>
        /// Returns all keys in the symbol table in the given range
        /// </summary>
        /// <param name="lo">minimum endpoint</param>
        /// <param name="hi">maximum endpoint</param>
        /// <returns>all keys in the symbol table between lo (inclusive) and hi (inclusive)</returns>
        private Queue<TKey> KeysInRange(TKey lo, TKey hi)
        {
            if (lo == null) throw new ArgumentNullException(nameof(lo));
            if (hi == null) throw new ArgumentNullException(nameof(hi));

            Queue<TKey> queue = new Queue<TKey>();
            KeysInRangeQueue(root, queue, lo, hi);
            return queue;
        }

        private void KeysInRangeQueue(BaseNode<TKey, TValue> x, Queue<TKey> queue, TKey lo, TKey hi)
        {
            if (x == null) return;
            int cmplo = lo.CompareTo(x.key);
            int cmphi = hi.CompareTo(x.key);
            if (cmplo < 0) KeysInRangeQueue(x.left, queue, lo, hi);
            if (cmplo <= 0 && cmphi >= 0) queue.Enqueue(x.key);
            if (cmphi > 0) KeysInRangeQueue(x.right, queue, lo, hi);
        }

#pragma warning disable S1144 // Unused private types or members should be removed
        private IEnumerable<TKey> LevelOrder()
        {
            Queue<TKey> keys = new Queue<TKey>();
            var queue = new Queue<BaseNode<TKey, TValue>>();
            queue.Enqueue(root);
            while (!queue.IsEmpty)
            {
                BaseNode<TKey, TValue> x = queue.Dequeue();
                if (x == null) continue;
                keys.Enqueue(x.key);
                queue.Enqueue(x.left);
                queue.Enqueue(x.right);
            }
            return keys;
        }
#pragma warning restore S1144 // Unused private types or members should be removed

        /// <summary>
        /// the height of the BST (a 1-node tree has height 0)
        /// </summary>
        public int Height => NodeHeight(root);

        private int NodeHeight(BaseNode<TKey, TValue> x) => (x == null) ? -1 : 1 + Math.Max(NodeHeight(x.left), NodeHeight(x.right));

        internal override TValue GetKey(BaseNode<TKey, TValue> x, TKey key)
        {
            if (x == null) return default(TValue);
            int cmp = key.CompareTo(x.key);
            if (cmp < 0) return GetKey(x.left, key);
            else if (cmp > 0) return GetKey(x.right, key);
            else return x.val;
        }

        internal override BaseNode<TKey, TValue> PutKey(BaseNode<TKey, TValue> x, TKey key, TValue val)
        {
            if (x == null) return new BaseNode<TKey, TValue>(key, val, 1);
            int cmp = key.CompareTo(x.key);
            if (cmp < 0) x.left = PutKey(x.left, key, val);
            else if (cmp > 0) x.right = PutKey(x.right, key, val);
            else x.val = val;
            x.size = 1 + NodeSize(x.left) + NodeSize(x.right);
            return x;
        }

        public override void Put(TKey key, TValue val)
        {
            base.Put(key, val);

            CheckBstDataStructure();
        }

        internal override void CheckBstDataStructure()
        {
#pragma warning disable S112 // General exceptions should never be thrown
            if (!IsBST) throw new Exception("Not in symmetric order");
            if (!IsSizeConsistent) throw new Exception("Subtree counts not consistent");
            if (!IsRankConsistent) throw new Exception("Ranks not consistent");
#pragma warning restore S112 // General exceptions should never be thrown
        }

        // does this binary tree satisfy symmetric order?
        // Note: this test also ensures that data structure is a binary tree since order is strict
        private bool IsBST => IsBinarySearchTree(root, default(TKey), default(TKey));


        // is the tree rooted at x a BST with all keys strictly between min and max
        // (if min or max is null, treat as empty constraint)
        // Credit: Bob Dondero's elegant solution
        private bool IsBinarySearchTree(BaseNode<TKey, TValue> x, TKey min, TKey max)
        {
            if (x == null) return true;
            if (min != null && x.key.CompareTo(min) <= 0) return false;
            if (max != null && x.key.CompareTo(max) >= 0) return false;
            return IsBinarySearchTree(x.left, min, x.key) && IsBinarySearchTree(x.right, x.key, max);
        }

        // are the size fields correct?
        private bool IsSizeConsistent => IsNodeSizeConsistent(root);
        private bool IsNodeSizeConsistent(BaseNode<TKey, TValue> x)
        {
            if (x == null) return true;
            if (x.size != NodeSize(x.left) + NodeSize(x.right) + 1) return false;
            return IsNodeSizeConsistent(x.left) && IsNodeSizeConsistent(x.right);
        }

        private bool IsRankConsistent => CheckRanks();
        
        // check that ranks are consistent
        private bool CheckRanks()
        {
            for (int i = 0; i < Size; i++)
                if (i != Rank(Select(i))) return false;
            foreach (TKey key in Keys())
                if (key.CompareTo(Select(Rank(key))) != 0) return false;
            return true;
        }
    }
}