
/**
 * http://algs4.cs.princeton.edu/32bst/BST.java.html
 * 
*  The {@code BST} class represents an ordered symbol table of generic key-value pairs.
*  It supports the usual <em>put</em>, <em>get</em>, <em>contains</em>,
*  <em>delete</em>, <em>size</em>, and <em>is-empty</em> methods.
*  It also provides ordered methods for finding the <em>minimum</em>,
*  <em>maximum</em>, <em>floor</em>, <em>select</em>, <em>ceiling</em>.
*  It also provides a <em>keys</em> method for iterating over all of the keys.
*  A symbol table implements the <em>associative array</em> abstraction:
*  when associating a value with a key that is already in the symbol table,
*  the convention is to replace the old value with the new value.
*  Unlike {@link java.util.Map}, this class uses the convention that
*  values cannot be {@code null}—setting the value associated with a key 
*  to {@code null} is equivalent to deleting the key from the symbol table.
*  
*  This implementation uses an (UNBALANCED) BINARY SEARCH TREE.
*  It requires that the key type implements the {@code Comparable} interface and calls the
*  {@code compareTo()} and method to compare two keys. 
*  It does not call either {@code equals()} or {@code hashCode()}.
*  The <em>put</em>, <em>contains</em>, <em>remove</em>, <em>minimum</em>,
*  <em>maximum</em>, <em>ceiling</em>, <em>floor</em>, <em>select</em>, and
*  <em>rank</em>  operations each take linear time in the worst case, 
*  if the tree becomes unbalanced. 
*  The <em>size</em>, and <em>is-empty</em> operations take constant time.
*  Construction takes constant time.
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


    public class BST<TKey, TValue>
        : IOrderedSymbolTable<TKey, TValue>
      where TKey : IComparable<TKey>, IEquatable<TKey>
      where TValue : IEquatable<TValue>
    {
        /// <summary>
        /// root of BST
        /// </summary>
        private Node root;

        /// <summary>
        /// Initializes empty BST
        /// </summary>
        public BST()
        {
        }

        /// <summary>
        /// Returns true if this symbol table is empty.
        /// </summary>
        public bool IsEmpty => Size == 0;

        /// <summary>
        /// Returns the largest key in the symbol table.
        /// </summary>
        public TKey Max => IsEmpty ? throw new InvalidOperationException("empty symbol table") : Maximum(root).key;

        private Node Maximum(Node x) => (x.right == null) ? x : Maximum(x.right);

        public TKey Min => IsEmpty ? throw new InvalidOperationException("empty symbol table") : Minimum(root).key;

        private Node Minimum(Node x) => (x.left == null) ? x : Minimum(x.left);

        /// <summary>
        /// Returns the number of key-value pairs in this symbol table.
        /// </summary>
        public int Size => NodeSize(root);

        public TKey Ceiling(TKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            if (IsEmpty) throw new InvalidOperationException("empty symbol table");
            Node x = CeilingNode(root, key);
            if (x == null) return default(TKey);
            else return x.key;
        }

        private Node CeilingNode(Node x, TKey key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.key);
            if (cmp == 0) return x;
            if (cmp < 0)
            {
                Node t = CeilingNode(x.left, key);
                if (t != null) return t;
                else return x;
            }
            return CeilingNode(x.right, key);
        }

        /// <summary>
        /// Does this symbol table contain the given key?
        /// </summary>
        /// <param name="key">the key</param>
        /// <returns>True if this symbol table contains the key and false otherwise</returns>
        public bool Contains(TKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            return !Get(key).Equals(default(TValue));
        }

        /// <summary>
        /// Removes the specified key and its associated value from this symbol table if present
        /// </summary>
        /// <param name="key">the key</param>
        public void Delete(TKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            root = DeleteNode(root, key);
            CheckBstDataStructure();
        }

        private Node DeleteNode(Node x, TKey key)
        {
            if (x == null) return null;

            int cmp = key.CompareTo(x.key);
            if (cmp < 0) x.left = DeleteNode(x.left, key);
            else if (cmp > 0) x.right = DeleteNode(x.right, key);
            else
            {
                if (x.right == null) return x.left;
                if (x.left == null) return x.right;
                Node t = x;
                x = Minimum(t.right);
                x.right = DeleteMinimum(t.right);
                x.left = t.left;
            }
            x.size = NodeSize(x.left) + NodeSize(x.right) + 1;
            return x;
        }

        public void DeleteMax()
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
        private Node DeleteMaximum(Node x)
        {
            if (x.right == null) return x.left;
            x.right = DeleteMaximum(x.right);
            x.size = NodeSize(x.left) + NodeSize(x.right) + 1;
            return x;
        }

        public void DeleteMin()
        {
            if (IsEmpty) throw new InvalidOperationException("Symbol table underflow");
            root = DeleteMinimum(root);
            CheckBstDataStructure();
        }

        private Node DeleteMinimum(Node x)
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
        public TKey Floor(TKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            if (IsEmpty) throw new InvalidOperationException("empty symbol table");
            Node x = FloorNode(root, key);
            if (x == null) return default(TKey);
            else return x.key;
        }

        private Node FloorNode(Node x, TKey key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.key);
            if (cmp == 0) return x;
            if (cmp < 0) return FloorNode(x.left, key);
            Node t = FloorNode(x.right, key);
            if (t != null) return t;
            else return x;
        }

        public TValue Get(TKey key) => GetKey(root, key);

        public void Put(TKey key, TValue val)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            if (val == null)
            {
                Delete(key);
                return;
            }
            root = Put(root, key, val);
            CheckBstDataStructure();
        }

        /// <summary>
        /// Returns the number of keys in the symbol table in the given range.
        /// </summary>
        /// <param name="lo">minimum endpoint</param>
        /// <param name="hi">maximum endpoint</param>
        /// <returns>the number of keys in the symbol table between lo (inclusive) and hi (inclusive)</returns>
        public int RangeSize(TKey lo, TKey hi)
        {
            if (lo == null) throw new ArgumentNullException(nameof(lo));
            if (hi == null) throw new ArgumentNullException(nameof(hi));

            if (lo.CompareTo(hi) > 0) return 0;
            if (Contains(hi)) return Rank(hi) - Rank(lo) + 1;
            else return Rank(hi) - Rank(lo);
        }

        /// <summary>
        /// Return the number of keys in the symbol table strictly less than <paramref name="key"/>
        /// </summary>
        /// <param name="key">the key</param>
        /// <returns></returns>
        public int Rank(TKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            return KeyRank(key, root);
        }

        // Number of keys in the subtree less than key.
        private int KeyRank(TKey key, Node x)
        {
            if (x == null) return 0;
            int cmp = key.CompareTo(x.key);
            if (cmp < 0) return KeyRank(key, x.left);
            else if (cmp > 0) return 1 + NodeSize(x.left) + KeyRank(key, x.right);
            else return NodeSize(x.left);
        }

        /// <summary>
        /// Return the key in the symbol table whose rank is <paramref name="k"/>.
        /// This is the (k+1)st smallest key in the symbol table.
        /// </summary>
        /// <param name="k">the order statistic</param>
        /// <returns> the key in the symbol table of rank <paramref name="k"/></returns>
        public TKey Select(int k)
        {
            if (k < 0 || k >= Size)
            {
                throw new ArgumentOutOfRangeException(nameof(k), k, "argument to Select() is out of range");
            }
            Node x = SelectKey(root, k);
            return x.key;
        }

        private Node SelectKey(Node x, int k)
        {
            if (x == null) return null;
            int t = NodeSize(x.left);
            if (t > k) return SelectKey(x.left, k);
            else if (t < k) return SelectKey(x.right, k - t - 1);
            else return x;
        }

        IEnumerator IEnumerable.GetEnumerator() => Keys().GetEnumerator();

        public IEnumerator<TKey> GetEnumerator() => Keys().GetEnumerator();

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

        private void KeysInRangeQueue(Node x, Queue<TKey> queue, TKey lo, TKey hi)
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
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (!queue.IsEmpty)
            {
                Node x = queue.Dequeue();
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

        private int NodeHeight(Node x) => (x == null) ? -1 : 1 + Math.Max(NodeHeight(x.left), NodeHeight(x.right));

        /// <summary>
        /// Number of key-value pairs in BST rooted at x
        /// </summary>
        /// <param name="x">tree node</param>
        /// <returns>Number of nodes in subtree rooted at x</returns>
        private int NodeSize(Node x) => (x == null) ? 0 : x.size;

        private TValue GetKey(Node x, TKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            if (x == null) return default(TValue);
            int cmp = key.CompareTo(x.key);
            if (cmp < 0) return GetKey(x.left, key);
            else if (cmp > 0) return GetKey(x.right, key);
            else return x.val;
        }

        private Node Put(Node x, TKey key, TValue val)
        {
            if (x == null) return new Node(key, val, 1);
            int cmp = key.CompareTo(x.key);
            if (cmp < 0) x.left = Put(x.left, key, val);
            else if (cmp > 0) x.right = Put(x.right, key, val);
            else x.val = val;
            x.size = 1 + NodeSize(x.left) + NodeSize(x.right);
            return x;
        }

        private void CheckBstDataStructure()
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
        private bool IsBinarySearchTree(Node x, TKey min, TKey max)
        {
            if (x == null) return true;
            if (min != null && x.key.CompareTo(min) <= 0) return false;
            if (max != null && x.key.CompareTo(max) >= 0) return false;
            return IsBinarySearchTree(x.left, min, x.key) && IsBinarySearchTree(x.right, x.key, max);
        }

        // are the size fields correct?
        private bool IsSizeConsistent => IsNodeSizeConsistent(root);
        private bool IsNodeSizeConsistent(Node x)
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

        /// <summary>
        /// inner node class
        /// </summary>
        /// <remarks>better as struct?</remarks>
        private class Node
        {
            internal TKey key;           // sorted by key
            internal TValue val;         // associated data
            internal int size;          // number of nodes in subtree
            internal Node left, right;  // left and right subtrees

            public Node(TKey key, TValue val, int size)
            {
                this.key = key;
                this.val = val;
                this.size = size;
            }
        }
    }
}