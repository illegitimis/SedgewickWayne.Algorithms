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
        STBase<TKey, TValue>
        where TKey : IComparable<TKey>, IEquatable<TKey>
        where TValue : IEquatable<TValue>
    {
        // root of BST
        private BaseNode<TKey, TValue> root;
                
        public NonrecursiveBST()
        {
            root = null;
        }
                
        public override int Size => root.Size;

        public override void Delete(TKey key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Search BST for given key, nonrecursive version.
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>Gets value for key</returns>
        public override TValue Get(TKey key)
        {
            BaseNode<TKey, TValue> x = root;
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
        public override void Put(TKey key, TValue val)
        {
            int cmp = 0;
            var z = new BaseNode<TKey, TValue>(key, val, 1);
            if (root == null)
            {
                root = z;
                return;
            }

            BaseNode<TKey, TValue> parent = null, x = root;
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

            parent.UpdateSize();
        }


        /// <summary>
        /// Inorder traversal.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<TKey> InorderTraversal()
        {
            var stack = new Stack<BaseNode<TKey, TValue>>();
            var queue = new Queue<TKey>();
            BaseNode<TKey, TValue> x = root;
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

        public override IEnumerator<TKey> GetEnumerator() => InorderTraversal().GetEnumerator();
    }
}
