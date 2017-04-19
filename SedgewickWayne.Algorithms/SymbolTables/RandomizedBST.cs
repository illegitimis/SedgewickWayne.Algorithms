// http://algs4.cs.princeton.edu/33balanced/RandomizedBST.java.html
// Symbol table (map) implemented with a randomized BST.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SedgewickWayne.Algorithms
{
    public class RandomizedBST<TKey, TValue> :
        IOrderedSymbolTable<TKey, TValue>
        where TKey : IComparable<TKey>, IEquatable<TKey>
        where TValue : IEquatable<TValue>
    {

        private Node root;   // root of the BST

        // BST helper node data type
        private class Node
        {
            internal TKey key;           // key
            internal TValue val;         // associated data
            internal Node left, right;   // left and right subtrees
            private int size;           // node count of descendents

            public Node(TKey key, TValue val)
            {
                this.key = key;
                this.val = val;
                this.size = 1;
            }

            public int Size { get { return (this == null) ? 0 : size; } }

            // return value associated with the given key
            // if no such value, return null
            // if multiple such values, return first one on path from root
           internal TValue Get(TKey key)
            {
                if (this == null) return default(TValue);
                int cmp = key.CompareTo(this.key);
                if (cmp == 0) return this.val;
                else if (cmp < 0) return left.Get(key);
                else return right.Get(key);
            }

            /***************************************************************************
            *  Randomized insertion.
            ***************************************************************************/
            // make new node the root with uniform probability
            internal Node put(TKey key, TValue val)
            {
                if (this == null) return new Node(key, val);
                int cmp = key.CompareTo(this.key);
                if (cmp == 0)
                {
                    this.val = val;
                    return this;
                }

                if (StdRandom.bernoulli(1.0 / (Size + 1.0))) return putRoot(key, val);
                if (cmp < 0) left = left.put(key, val);
                else right = right.put(key, val);
                // (x.size)++;
                fix();

                return this;
            }

            Node putRoot(TKey key, TValue val)
            {
                if (this == null) return new Node(key, val);

                int cmp = key.CompareTo(key);
                if (cmp < 0)
                {
                    left = left.putRoot(key, val);
                    return rotR(this);
                }
                else if (cmp > 0)
                {
                    right = right.putRoot(key, val);
                    return rotL(this);
                }
                else
                {
                    this.val = val;
                }

                return this;
            }

            /***************************************************************************
            *  Helper BST functions.
            ***************************************************************************/

            // fix subtree count field
            internal void fix()
            {
                if (this == null) return;
                size = 1 + left.size + right.size;
            }

            // right rotate
            internal Node rotR(Node h)
            {
                Node x = h.left;
                h.left = x.right;
                x.right = h;
                h.fix();
                x.fix();
                return x;
            }

            // left rotate
            internal Node rotL(Node h)
            {
                Node x = h.right;
                h.right = x.left;
                x.left = h;
                h.fix();
                x.fix();
                return x;
            }
            
        }

        public bool IsEmpty { get { return this.root.Size == 0; } }
        public int Size { get { return this.root.Size; } }

        public TKey Max
        {
            get
            {
                TKey key = default(TKey);
                for (Node x = root; x != null; x = x.right) key = x.key;
                return key;
            }
        }

        public TKey Min
        {
            get
            {
                TKey key = default(TKey);
                for (Node x = root; x != null; x = x.left) key = x.key;
                return key;
            }
        }


        #region CEIL

        public TKey Ceiling(TKey key)
        {
            Node best = ceiling(root, key, null);
            if (best == null) return default(TKey);
            return best.key;
        }

        // return the smallest key >= query key; if no such key return null        
        private Node ceiling(Node x, TKey key, Node best)
        {
            if (x == null) return best;
            else if (key.CompareTo(x.key) == 0 || key.Equals(x.key)) return x;
            else if (key.CompareTo(x.key) < 0) return ceiling(x.left, key, x);
            else return ceiling(x.right, key, best);
        }

        // return the smallest key >= query key; if no such key return null
        public TKey ceiling2(TKey key)
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

            return (best == null) ? default(TKey) : best.key;
        }

        #endregion

        public bool Contains(TKey key) { return Get(key) != null; }

        public TValue Get(TKey key) { return root.Get(key); }
        
        #region delete

        public void Delete(TKey key)
        {
            throw new NotImplementedException();
        }

        public void DeleteMax()
        {
            throw new NotImplementedException();
        }

        public void DeleteMin()
        {
            throw new NotImplementedException();
        }

        #endregion

        public TKey Floor(TKey key)
        {
            throw new NotImplementedException();
        }

       

        public IEnumerator<TKey> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Put(TKey key, TValue val) { root = root.put(key, val); }

              


        public int RangeSize(TKey lo, TKey hi)
        {
            throw new NotImplementedException();
        }

        public int Rank(TKey key)
        {
            throw new NotImplementedException();
        }

        public TKey Select(int k)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }


    }
}
