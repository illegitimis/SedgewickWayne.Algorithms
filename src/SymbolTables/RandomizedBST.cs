// http://algs4.cs.princeton.edu/33balanced/RandomizedBST.java.html
// Symbol table (map) implemented with a randomized BST.

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class RandomizedBST<TKey, TValue>
        : TreeSTBase<TKey, TValue>
        where TKey : IComparable<TKey>, IEquatable<TKey>
        where TValue : IEquatable<TValue>
    {

        internal override BaseNode<TKey, TValue> MaximumNode(BaseNode<TKey, TValue> node)
        {
            BaseNode<TKey, TValue> max = null;
            for (BaseNode<TKey, TValue> x = node; x != null; x = x.right)
                max = x;
            return max;
        }

        internal override BaseNode<TKey, TValue> MinimumNode(BaseNode<TKey, TValue> node)
        {
            BaseNode<TKey, TValue> min = null;
            for (BaseNode<TKey, TValue> x = node; x != null; x = x.left)
                min = x;
            return min;
        }

        #region inequality

        /// <summary />
        /// <param name="key"></param>
        /// <returns>the smallest key >= query key; if no such key return null</returns>
        public override TKey Ceiling(TKey key)
        {
            BaseNode<TKey, TValue> best = Ceiling(root, key, null);
            return (best == null) ? default(TKey) : best.key;
        }

        private BaseNode<TKey, TValue> Ceiling(BaseNode<TKey, TValue> x, TKey key, BaseNode<TKey, TValue> best) =>
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
            BaseNode<TKey, TValue> best = null;
            BaseNode<TKey, TValue> x = root;
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

        public override TKey Floor(TKey key)
        {
            BaseNode<TKey, TValue> best = Floor(root, key, null);
            return (best == null) ? default(TKey) : best.key;
        }

        private BaseNode<TKey, TValue> Floor(BaseNode<TKey, TValue> x, TKey key, BaseNode<TKey, TValue> best) =>        
            (x == null)
              ? best
              : key.Equals(x.key)
                  ? x
                  : (key.CompareTo(x.key) < 0)
                      ? Floor(x.left, key, best)
                      : Floor(x.right, key, x);

        #endregion

        /// <summary>if multiple such values, return first one on path from root</summary>
        /// <param name="x"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        internal override TValue GetKey(BaseNode<TKey, TValue> x, TKey key)
        {
            if (x == null) return default(TValue);
            int cmp = key.CompareTo(x.key);
            if (cmp == 0) return x.val;
            else if (cmp < 0) return GetKey(x.left, key);
            else return GetKey(x.right, key);
        }

        #region delete

        /// <summary>
        /// remove and return value associated with given key; if no such key, exit
        /// </summary>
        /// <param name="key"></param>
        public override void Delete(TKey key)
        {
            if (!Contains(key)) return;
            root = Remove(root, key);
        }

        private BaseNode<TKey, TValue> Remove(BaseNode<TKey, TValue> x, TKey key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.key);
            if (cmp == 0) x = joinLR(x.left, x.right);
            else if (cmp < 0) x.left = Remove(x.left, key);
            else x.right = Remove(x.right, key);
            x.UpdateSize();
            return x;
        }

        /// <summary>
        /// Randomized deletion.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private BaseNode<TKey, TValue> joinLR(BaseNode<TKey, TValue> a, BaseNode<TKey, TValue> b)
        {
            if (a == null) return b;
            if (b == null) return a;

            if (StdRandom.bernoulli((double)a.Size / (a.Size + b.Size)))
            {
                a.right = joinLR(a.right, b);
                a.UpdateSize();
                return a;
            }
            else
            {
                b.left = joinLR(a, b.left);
                b.UpdateSize();
                return b;
            }
        }

        public override void DeleteMax() => Delete(Max);

        public override void DeleteMin() => Delete(Min);

        #endregion

        #region insert
 
        /// <summary>
        /// Randomized insertion.
        /// make new node the root with uniform probability
        /// </summary>
        /// <param name="x"></param>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        internal override BaseNode<TKey, TValue> PutKey(BaseNode<TKey, TValue> x, TKey key, TValue val)
        {
            if (x == null) return new BaseNode<TKey, TValue>(key, val, 1);
            int cmp = key.CompareTo(x.key);
            if (cmp == 0)
            {
                x.val = val;
                return x;
            }

            if (StdRandom.bernoulli(1.0 / (x.Size + 1.0))) return PutRoot(x, key, val);
            if (cmp < 0) x.left = PutKey(x.left, key, val);
            else x.right = PutKey(x.right, key, val);

            x.UpdateSize();
            return x;
        }

        private BaseNode<TKey, TValue> PutRoot(BaseNode<TKey, TValue> x, TKey key, TValue val)
        {
            if (x == null) return new BaseNode<TKey, TValue>(key, val, 1);
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

        private BaseNode<TKey, TValue> RotateRight(BaseNode<TKey, TValue> h)
        {
            var x = h.left;
            h.left = x.right;
            x.right = h;
            h.UpdateSize();
            x.UpdateSize();
            return x;
        }

        private BaseNode<TKey, TValue> RotateLeft(BaseNode<TKey, TValue> h)
        {
            var x = h.right;
            h.right = x.left;
            x.left = h;
            h.UpdateSize();
            x.UpdateSize();
            return x;
        }

        #endregion

        #region enumerable

        public override IEnumerator<TKey> GetEnumerator() => new BstEnumerator(root);

        /// <summary>
        /// Iterate using inorder traversal using a stack.
        /// </summary>
        /// <remarks>Iterating through N elements takes O(N) time.</remarks>
        private class BstEnumerator : IEnumerator<TKey>
        {
            private readonly Stack<BaseNode<TKey, TValue>> stack = new Stack<BaseNode<TKey, TValue>>();

            public BstEnumerator(BaseNode<TKey, TValue> root)
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
                    BaseNode<TKey, TValue> x = stack.Pop();
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
       
    }
}
