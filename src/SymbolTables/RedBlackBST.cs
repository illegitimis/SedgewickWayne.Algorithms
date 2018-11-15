// http://algs4.cs.princeton.edu/33balanced/RedBlackLiteBST.java.html
// http://algs4.cs.princeton.edu/33balanced/RedBlackBST.java.html

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    
    /// <summary>
    /// A symbol table implemented using a left-leaning red-black BST. This is the 2-3 version.
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    /// <typeparam name="Value"></typeparam>
    /// <remarks>
    /// The class represents an ordered symbol table of generic key-value pairs.
    /// Construction takes constant time.
    /// Uses the convention that values cannot be null—setting the value associated with a key to null is equivalent to deleting the key from the symbol table.
    /// The put, contains, remove, minimum, maximum, ceiling, and floor operations each take logarithmic time in the worst case, if the tree becomes unbalanced.
    /// The size, and is-empty operations take constant time.
    /// </remarks>
    public class RedBlackBST<Key, Value>
        : TreeSTBase<Key, Value>
        where Key : IComparable<Key>, IEquatable<Key>
        where Value : IEquatable<Value>
    {
        /// <summary>
        /// Initializes an empty symbol table.
        /// </summary>
        public RedBlackBST()
        {
            root = null;
        }

        internal RedBlackNode<Key, Value> Root => root as RedBlackNode<Key, Value>;

        /// <summary>
        /// Standard BST search.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="key"></param>
        /// <returns>TODO: refactor?</returns>
        internal override Value GetKey(BaseNode<Key, Value> x, Key key)
        {
            while (x != null)
            {
                int cmp = key.CompareTo(x.key);
                if (cmp < 0) x = x.left;
                else if (cmp > 0) x = x.right;
                else return x.val;
            }
            return default(Value);
        }

        /// <summary>
        /// insert the key-value pair in the subtree rooted at h.
        /// Red-black tree insertion
        /// </summary>
        /// <param name="h"></param>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        internal override BaseNode<Key, Value> PutKey(BaseNode<Key, Value> h, Key key, Value val)
        {
            if (h == null) return new RedBlackNode<Key, Value>(key, val, NodeColor.RED, 1);

            int cmp = key.CompareTo(h.key);
            if (cmp < 0) h.left = PutKey(h.left, key, val);
            else if (cmp > 0) h.right = PutKey(h.right, key, val);
            else h.val = val;

            if (h is RedBlackNode<Key, Value> hh)
            {
                // fix-up any right-leaning links
                if (IsRed(hh.right) && !IsRed(hh.left)) h = RotateLeft(hh);
                if (IsRed(hh.left) && IsRed(hh.left.left)) h = RotateRight(hh);
                if (IsRed(hh.left) && IsRed(hh.right)) FlipColors(hh);

                hh.UpdateSize();
                return h;
            }
            else throw new TypeLoadException(h.GetType().FullName);

        }

        public override void Put(Key key, Value val)
        {
            base.Put(key, val);

            Root.color = NodeColor.BLACK;
        }

        private bool IsRed(BaseNode<Key, Value> x) => (x != null) && (x is RedBlackNode<Key,Value> y) && y.IsRed;
        private bool IsBlack(BaseNode<Key, Value> x) => (x != null) && (x is RedBlackNode<Key, Value> y) && y.IsBlack;
        
        /// <summary>
        /// make a right-leaning link lean to the left
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        private RedBlackNode<Key, Value> RotateLeft(RedBlackNode<Key, Value> h)
        {
            Contract.Assert((h != null) && IsRed(h.right));

            var x = h.Right;
            h.right = x.left;
            x.left = h;
            x.color = x.Left.color;
            x.Left.color = NodeColor.RED;
            x.SetSize (h.Size);
            h.UpdateSize();
            return x;
        }

        /// <summary>
        /// make a left-leaning link lean to the right
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        private RedBlackNode<Key, Value> RotateRight(RedBlackNode<Key, Value> h)
        {
            Contract.Assert((h != null) && IsRed(h.left));

            var x = h.Left;
            h.left = x.right;
            x.right = h;
            x.color = x.Right.color;
            x.Right.color = NodeColor.RED;
            x.SetSize(h.Size);
            h.UpdateSize();
            return x;
        }

        /// <summary>
        /// flip the colors of a node and its two children
        /// </summary>
        /// <param name="h"></param>
        private void FlipColors(RedBlackNode<Key, Value> h)
        {
            // h must have opposite color of its two children
            Contract.Assert ((h != null) && (h.left != null) && (h.right != null));
            Contract.Assert((IsBlack(h) &&  IsRed(h.left) &&  IsRed(h.right)) || (IsRed(h)  && IsBlack(h.left) && IsBlack(h.right)));

            h.FlipColor();
            h.Left.FlipColor();
            h.Right.FlipColor();
        }


        void SetColor(BaseNode<Key, Value> node, NodeColor color) => (node as RedBlackNode<Key, Value>).color = color;

        #region Red-black tree deletion

        public override void Delete(Key key)
        {
            KeyArgumentNull(key, nameof(Delete));
            if (!Contains(key)) return;

            // if both children of root are black, set root to red
            if (IsBlack(root.left) && IsBlack(root.right)) SetColor(root, NodeColor.RED);

            root = DeleteKey(Root, key);

            if (!IsEmpty) SetColor(root, NodeColor.BLACK);
            // assert check();
        }

        /// <summary>
        /// delete the key-value pair with the given key rooted at h
        /// </summary>
        /// <param name="h"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private RedBlackNode<Key, Value> DeleteKey(RedBlackNode<Key, Value> h, Key key)
        {
            // Contract.Assert(!Get(h, key).Equals(default(Value)));

            if (key.CompareTo(h.key) < 0)
            {
                if (!IsRed(h.left) && !IsRed(h.left.left))
                    h = moveRedLeft(h);
                h.left = DeleteKey(h.Left, key);
            }
            else
            {
                if (IsRed(h.left))
                    h = RotateRight(h);
                if (key.CompareTo(h.key) == 0 && (h.right == null))
                    return null;
                if (!IsRed(h.right) && !IsRed(h.right.left))
                    h = moveRedRight(h);
                if (key.CompareTo(h.key) == 0)
                {
                    var x = MinimumNode(h.Right);
                    h.key = x.key;
                    h.val = x.val;
                    // h.val = get(h.right, min(h.right).key);
                    // h.key = min(h.right).key;
                    h.right = DeleteMin(h.Right);
                }
                else h.right = DeleteKey(h.Right, key);
            }
            return balance(h);
        }

        public override void DeleteMax() => CommonDeleteLimit(DeleteMax);

        private RedBlackNode<Key, Value> DeleteMax(RedBlackNode<Key, Value> h)
        {
            if (IsRed(h.left)) h = RotateRight(h);

            if (h.right == null) return null;

            if (IsBlack(h.right) && IsBlack(h.right.left)) h = moveRedRight(h);

            h.right = DeleteMax(h.Right);

            return balance(h);
        }

        public override void DeleteMin() => CommonDeleteLimit(DeleteMin);

        private RedBlackNode<Key, Value> DeleteMin(RedBlackNode<Key, Value> h)
        {
            if (h.left == null) return null;

            if (IsBlack(h.left) && IsBlack(h.left.left)) h = moveRedLeft(h);

            h.left = DeleteMin(h.Left);
            return balance(h);
        }

        private void CommonDeleteLimit(Func<RedBlackNode<Key, Value>, RedBlackNode<Key, Value>> f)
        {
            SymbolTableUnderflow();

            // if both children of root are black, set root to red
            if (IsBlack(root.left) && IsBlack(root.right))
                SetColor(root, NodeColor.RED);

            root = f(Root);

            if (!IsEmpty)
                SetColor(root, NodeColor.BLACK);
            
            // assert check();
        }

        /// <summary>
        /// restore red-black tree invariant
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        private RedBlackNode<Key, Value> balance(RedBlackNode<Key, Value> h)
        {
            Contract.Assert (h != null);

            if (IsRed(h.right)) h = RotateLeft(h);
            if (IsRed(h.left) && IsRed(h.left.left)) h = RotateRight(h);
            if (IsRed(h.left) && IsRed(h.right)) FlipColors(h);

            h.UpdateSize();
            return h;
        }

        /// <summary>
        /// Assuming that h is red and both h.right and h.right.left are black, make h.right or one of its children red.
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        private RedBlackNode<Key, Value> moveRedRight(RedBlackNode<Key, Value> h)
        {
            Contract.Assert (h != null);
            Contract.Assert (IsRed(h) && !IsRed(h.right) && !IsRed(h.right.left));
            FlipColors(h);
            if (IsRed(h.left.left))
            {
                h = RotateRight(h);
                FlipColors(h);
            }
            return h;
        }

        /// <summary>
        /// Assuming that h is red and both h.left and h.left.left are black, make h.left or one of its children red.
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        private RedBlackNode<Key, Value> moveRedLeft(RedBlackNode<Key, Value> h)
        {
            Contract.Assert(h != null);
            Contract.Assert (IsRed(h) && !IsRed(h.left) && !IsRed(h.left.left));

            FlipColors(h);
            if (IsRed(h.right.left))
            {
                h.right = RotateRight(h.Right);
                h = RotateLeft(h);
                FlipColors(h);
            }
            return h;
        }

        #endregion

        internal override BaseNode<Key, Value> MaximumNode(BaseNode<Key, Value> x) => (x.right == null) ? x : MaximumNode(x.right);

        internal override BaseNode<Key, Value> MinimumNode(BaseNode<Key, Value> x) => (x.left == null) ? x : MinimumNode(x.left);
                
        #region ordered

        /// <summary>
        /// Returns the smallest key in the symbol table greater than or equal to <paramref name="key"/>
        /// </summary>
        /// <param name="key">the key</param>
        /// <returns></returns>
        public override Key Ceiling(Key key) => CommonFloorCeiling(key, ceiling);

        /// <summary>
        /// the smallest key in the subtree rooted at x greater than or equal to the given key
        /// </summary>
        /// <param name="x"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private RedBlackNode<Key, Value> ceiling(RedBlackNode<Key, Value> x, Key key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.key);
            if (cmp == 0) return x;
            if (cmp > 0) return ceiling(x.Right, key);
            var t = ceiling(x.Left, key);
            return t ?? x;
        }

        public override Key Floor(Key key) => CommonFloorCeiling(key, floor);

        private RedBlackNode<Key, Value> floor(RedBlackNode<Key, Value> x, Key key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.key);
            if (cmp == 0) return x;
            if (cmp < 0) return floor(x.Left, key);
            var t = floor(x.Right, key);
            if (t != null) return t;
            else return x;
        }

        private Key CommonFloorCeiling(Key key, Func<RedBlackNode<Key, Value>, Key, RedBlackNode<Key, Value>> f)
        {
            KeyArgumentNull(key, nameof(CommonFloorCeiling));
            SymbolTableUnderflow();
            var x = f(Root, key);
            return (x == null) ? default(Key) : x.key;
        }

        #endregion

        #region enumerable

        public override IEnumerator<Key> GetEnumerator() => Keys().GetEnumerator();

        /// <summary>
        /// Returns all keys in the symbol table
        /// </summary>
        /// <returns></returns>
        IEnumerable<Key> Keys() => IsEmpty ? Enumerable.Empty<Key>() : Keys(Min, Max);

        private IEnumerable<Key> Keys(Key lo, Key hi)
        {
            KeyArgumentNull(lo, nameof(Keys));
            KeyArgumentNull(hi, nameof(Keys));

            var queue = new Queue<Key>();
            keys(Root, queue, lo, hi);
            return queue;
        }

        /// <summary>
        /// add the keys between <paramref name="lo"/> and <paramref name="hi"/>
        /// in the subtree rooted at <paramref name="x"/> to the queue <paramref name="q"/>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="q"></param>
        /// <param name="lo"></param>
        /// <param name="hi"></param>
        private void keys(RedBlackNode<Key, Value> x, Queue<Key> q, Key lo, Key hi)
        {
            if (x == null) return;
            int cmplo = lo.CompareTo(x.key);
            int cmphi = hi.CompareTo(x.key);
            if (cmplo < 0) keys(x.Left, q, lo, hi);
            if (cmplo <= 0 && cmphi >= 0) q.Enqueue(x.key);
            if (cmphi > 0) keys(x.Right, q, lo, hi);
        }

        #endregion

        /// <summary>
        /// TODO
        /// </summary>
        internal override void CheckBstDataStructure()
        {
            
        }

    }
}