// http://algs4.cs.princeton.edu/33balanced/RandomizedBST.java.html
// Symbol table (map) implemented with a randomized BST.

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class RandomizedBST<TKey, TValue> :
        IOrderedSymbolTable<TKey, TValue>
        where TKey : IComparable<TKey>, IEquatable<TKey>
        where TValue : IEquatable<TValue>
    {

        // root of the BST
        private Node root;   

        public TKey Min
        {
            get
            {
                TKey key = default(TKey);
                for (Node x = root; x != null; x = x.left)
                    key = x.key;
                return key;
            }
        }

        public TKey Max
        {
            get
            {
                TKey key = default(TKey);
                for (Node x = root; x != null; x = x.right)
                    key = x.key;
                return key;
            }
        }

        #region size

        public int Size => NodeSize(root);

        /// <summary>NumberOfNodesInSubtreeRootedAt</summary>
        /// <param name="x">node</param>
        /// <returns></returns>
        private int NodeSize(Node x) => (x == null) ? 0 : x.size;

        private void FixSubtreeCountField(Node x)
        {
            if (x == null) return;
            x.size = 1 + NodeSize(x.left) + NodeSize(x.right);
        }

        public bool IsEmpty => Size == 0;

        #endregion

        #region inequality

        /// <summary />
        /// <param name="key"></param>
        /// <returns>the smallest key >= query key; if no such key return null</returns>
        public TKey Ceiling(TKey key)
        {
            Node best = Ceiling(root, key, null);
            return (best == null) ? default(TKey) : best.key;
        }

        private Node Ceiling(Node x, TKey key, Node best) =>
            (x == null)
                ? best
                : key.Equals(x.key)
                    ? x
                    : (key.CompareTo(x.key) < 0)
                        ? Ceiling(x.left, key, x)
                        : Ceiling(x.right, key, best);

        // iterative ceiling?
        private TKey ceiling2(TKey key)
        {
            Node best = null;
            Node x = root;
            while (x != null)
            {
                int cmp = key.CompareTo(x.key);
                if (cmp < 0)
                {
                    best = x;
                    x = x.left;
                }
                else if (cmp > 0)
                {
                    x = x.right;
                }
                else
                {
                    return x.key;
                }
            }
            if (best == null) return default(TKey);
            return best.key;
        }

        public TKey Floor(TKey key)
        {
            Node best = Floor(root, key, null);
            return (best == null) ? default(TKey) : best.key;
        }

        private Node Floor(Node x, TKey key, Node best) =>        
            (x == null)
              ? best
              : key.Equals(x.key)
                  ? x
                  : (key.CompareTo(x.key) < 0)
                      ? Floor(x.left, key, best)
                      : Floor(x.right, key, x);

        #endregion

        #region get

        public TValue Get(TKey key) => Get(root, key);

        /// <summary>if multiple such values, return first one on path from root</summary>
        /// <param name="x"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private TValue Get(Node x, TKey key)
        {
            if (x == null) return default(TValue);
            int cmp = key.CompareTo(x.key);
            if (cmp == 0) return x.val;
            else if (cmp < 0) return Get(x.left, key);
            else return Get(x.right, key);
        }

        public bool Contains(TKey key) => !Get(key).Equals(default(TValue));

        #endregion

        #region delete

        /// <summary>
        /// remove and return value associated with given key; if no such key, exit
        /// </summary>
        /// <param name="key"></param>
        public void Delete(TKey key)
        {
            if (!Contains(key)) return;
            root = Remove(root, key);
        }

        private Node Remove(Node x, TKey key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.key);
            if (cmp == 0) x = joinLR(x.left, x.right);
            else if (cmp < 0) x.left = Remove(x.left, key);
            else x.right = Remove(x.right, key);
            FixSubtreeCountField(x);
            return x;
        }

        /// <summary>
        /// Randomized deletion.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private Node joinLR(Node a, Node b)
        {
            if (a == null) return b;
            if (b == null) return a;

            int sizea = NodeSize(a);
            int sizeb = NodeSize(b);
            if (StdRandom.bernoulli((double)sizea / (sizea + sizeb)))
            {
                a.right = joinLR(a.right, b);
                FixSubtreeCountField(a);
                return a;
            }
            else
            {
                b.left = joinLR(a, b.left);
                FixSubtreeCountField(b);
                return b;
            }
        }

        public void DeleteMax() => Delete(Max);

        public void DeleteMin() => Delete(Min);

        #endregion

        #region insert

        /// <summary>
        /// Randomized insertion.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        public void Put(TKey key, TValue val)
        {
            root = Put(root, key, val);
        }

        /// <summary>
        /// make new node the root with uniform probability
        /// </summary>
        /// <param name="x"></param>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        private Node Put(Node x, TKey key, TValue val)
        {
            if (x == null) return new Node(key, val);
            int cmp = key.CompareTo(x.key);
            if (cmp == 0)
            {
                x.val = val;
                return x;
            }

            int sizex = NodeSize(x);
            if (StdRandom.bernoulli(1.0 / (sizex + 1.0))) return PutRoot(x, key, val);
            if (cmp < 0) x.left = Put(x.left, key, val);
            else x.right = Put(x.right, key, val);
            
            FixSubtreeCountField(x);
            return x;
        }

        private Node PutRoot(Node x, TKey key, TValue val)
        {
            if (x == null) return new Node(key, val);
            int cmp = key.CompareTo(x.key);
            if (cmp < 0)
            {
                x.left = PutRoot(x.left, key, val);
                x = RotateRight(x);
            }
            else if (cmp > 0)
            {
                x.right = PutRoot(x.right, key, val);
                x = RotateLeft(x);
            }
            else
            {
                x.val = val;
            }
            return x;
        }

        private Node RotateRight(Node h)
        {
            Node x = h.left;
            h.left = x.right;
            x.right = h;
            FixSubtreeCountField(h);
            FixSubtreeCountField(x);
            return x;
        }

        private Node RotateLeft(Node h)
        {
            Node x = h.right;
            h.right = x.left;
            x.left = h;
            FixSubtreeCountField(h);
            FixSubtreeCountField(x);
            return x;
        }

        #endregion

        #region enumerable

        public IEnumerator<TKey> GetEnumerator() => new BstEnumerator(root);

        IEnumerator IEnumerable.GetEnumerator() => new BstEnumerator(root);

        /// <summary>
        /// Iterate using inorder traversal using a stack.
        /// </summary>
        /// <remarks>Iterating through N elements takes O(N) time.</remarks>
        private class BstEnumerator : IEnumerator<TKey>
        {
            private readonly Stack<Node> stack = new Stack<Node>();

            public BstEnumerator(RandomizedBST<TKey, TValue>.Node root)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
            }

            public TKey Current
            {
                get
                {
                    Node x = stack.Pop();
                    TKey key = x.key;
                    x = x.right;
                    while (x != null)
                    {
                        stack.Push(x);
                        x = x.left;
                    }
                    return key;
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                // nothing left to do
            }

            public bool MoveNext() => !stack.IsEmpty;

            public void Reset() => throw new NotSupportedException();
        }

        #endregion

        /// <summary>
        /// Return the key in the symbol table whose rank is <paramref name="k"/>.
        /// </summary>
        /// <param name="k">the order statistic</param>
        /// <returns>the key in the symbol table of rank <paramref name="k"/></returns>
        public TKey Select(int k)
        {
            Node x = Select(root, k);
            return x.key;
        }

        private Node Select(Node x, int k)
        {
            if (x == null) return null;
            int t = NodeSize(x.left);
            if (t > k) return Select(x.left, k);
            else if (t < k) return Select(x.right, k - t - 1);
            else return x;
        }

        public int RangeSize(TKey lo, TKey hi)
        {
            if (lo == null) throw new ArgumentNullException(nameof(lo));
            if (hi == null) throw new ArgumentNullException(nameof(hi));

            if (lo.CompareTo(hi) > 0) return 0;
            if (Contains(hi)) return Rank(hi) - Rank(lo) + 1;
            else return Rank(hi) - Rank(lo);
        }

        public int Rank(TKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            return KeyRank(key, root);
        }

        private int KeyRank(TKey key, Node x)
        {
            if (x == null) return 0;
            int cmp = key.CompareTo(x.key);
            if (cmp < 0) return KeyRank(key, x.left);
            else if (cmp > 0) return 1 + NodeSize(x.left) + KeyRank(key, x.right);
            else return NodeSize(x.left);
        }



        #region BST helper node data type
        private class Node
        {
            internal TKey key;           // key
            internal TValue val;         // associated data
            internal Node left, right;   // left and right subtrees
            internal int size;           // node count of descendents

            public Node(TKey key, TValue val)
            {
                this.key = key;
                this.val = val;
                this.size = 1;
            }
        }
        #endregion
    }
}
