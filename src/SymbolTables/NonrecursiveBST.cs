// http://algs4.cs.princeton.edu/32bst/NonrecursiveBST.java.html


namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>Nonrecursive BST implementation</summary>
    /// <typeparam name="TKey">comparable and equatable key type</typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <remarks>incomplete</remarks>
    public class NonrecursiveBST<TKey, TValue> :
        ISymbolTable<TKey, TValue>
        where TKey : IComparable<TKey>, IEquatable<TKey>
        where TValue : IEquatable<TValue>
    {
        // root of BST
        private Node root;
        private int size;

        public NonrecursiveBST()
        {
            size = 0;
            root = null;
        }

        private class Node
        {
            public TKey key;             // sorted by key
            public TValue val;           // associated value
            public Node left, right;    // left and right subtrees

            public Node(TKey key, TValue val)
            {
                this.key = key;
                this.val = val;
            }
        }


        public bool IsEmpty => root == null;
        
        public int Size => size;

        public bool Contains(TKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            return !Get(key).Equals(default(TValue));
        }

        public void Delete(TKey key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Search BST for given key, nonrecursive version.
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>Gets value for key</returns>
        public TValue Get(TKey key)
        {
            Node x = root;
            while (x != null)
            {
                int cmp = key.CompareTo(x.key);
                if (cmp < 0) x = x.left;
                else if (cmp > 0) x = x.right;
                else return x.val;
            }

            return default(TValue);
        }

        /// <summary>
        /// Insert key-value pair into symbol table (nonrecursive version).
        /// </summary>
        /// <param name="key">key to insert</param>
        /// <param name="val">value for key</param>
        public void Put(TKey key, TValue val)
        {
            int cmp = 0;
            Node z = new Node(key, val);
            if (root == null)
            {
                root = z;
                size = 1;
                return;
            }

            Node parent = null, x = root;
            while (x != null)
            {
                parent = x;
                cmp = key.CompareTo(x.key);
                if (cmp < 0) x = x.left;
                else if (cmp > 0) x = x.right;
                else
                {
                    x.val = val;
                    return;
                }
            }

            cmp = key.CompareTo(parent.key);
            if (cmp < 0) parent.left = z;
            else parent.right = z;
            size++;
        }


        /// <summary>
        /// Inorder traversal.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<TKey> InorderTraversal()
        {
            Stack<Node> stack = new Stack<Node>();
            Queue<TKey> queue = new Queue<TKey>();
            Node x = root;
            while (x != null || !stack.IsEmpty)
            {
                if (x != null)
                {
                    stack.Push(x);
                    x = x.left;
                }
                else
                {
                    x = stack.Pop();
                    queue.Enqueue(x.key);
                    x = x.right;
                }
            }
            return queue;
        }

        public IEnumerator<TKey> GetEnumerator() => InorderTraversal().GetEnumerator();


        IEnumerator IEnumerable.GetEnumerator() => InorderTraversal().GetEnumerator();
    }
}
