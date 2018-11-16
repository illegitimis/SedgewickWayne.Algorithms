// https://en.wikipedia.org/wiki/Splay_tree
// http://algs4.cs.princeton.edu/33balanced/SplayBST.java.html
// http://www.cs.cmu.edu/%7Esleator/papers/self-adjusting.pdf
// http://yaikhom.com/2014/05/12/understanding-splay-tree-rotations.html
// http://www.link.cs.cmu.edu/link/ftp-site/splaying/SplayTree.java

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///  Splay tree.
    ///  Supports splay-insert, search, and delete.
    ///  Splays on every operation, regardless of the presence of the associated key prior to that operation.
    ///  It allows searching, insertion, deletion, deletemin, deletemax, splitting, joining, and many other operations, all with amortized logarithmic performance.
    /// </summary>
    /// <typeparam name="TKey">key type</typeparam>
    /// <typeparam name="TValue">store type</typeparam>
    public class SplayBST<TKey, TValue>
       : STBase<TKey, TValue>
       where TKey : IComparable<TKey>, IEquatable<TKey>
       where TValue : IEquatable<TValue>
    {
        // root of the BST
        // inherits outer parameters <TKey, TValue>
        private Node root;

        /// <summary>
        /// simple inner node class with links, key and value only, and no size
        /// </summary>
        private class Node
        {
            internal TKey key;           // sorted by key
            internal TValue val;         // associated data
            internal Node left, right;  // links to left and right subtrees

            public Node(TKey key, TValue val)
            {
                this.key = key;
                this.val = val;
            }
        }

        public SplayBST()
        {
            root = null;
        }

        public override int Size => NodeSize(root);

        private int NodeSize(Node node)
        {
            // stop condition
            if (node == null) return 0;

            return 1 + NodeSize(node.left) + NodeSize(node.right);
        }

        /// <summary>
        /// Splay tree deletion.
        /// </summary>
        /// <remarks>
        /// This splays the key, then does a slightly modified Hibbard deletion on the root.
        /// if it is the node to be deleted; if it is not, the key was not in the tree.
        /// The modification is that rather than swapping the root (call it node A) with its successor,
        /// (call it Node B) is moved to the root position by splaying for the deletion key in A's right subtree.
        /// Finally, A's right child is made the new root's right child.
        /// </remarks>
        /// <param name="key"></param>
        public override void Delete(TKey key)
        {
            // empty tree
            if (root == null) return;

            root = Splay(root, key);

            int cmp = key.CompareTo(root.key);

            if (cmp != 0)
            {
                // it wasn't in the tree to remove
                // ItemNotFoundException
                return;
            }

            // delete the root
            if (root.left == null)
            {
                root = root.right;
            }
            else
            {
                Node x = root.right;
                root = root.left;
                Splay(root, key);
                root.right = x;
            }
        }

        /// <summary>
        /// return value associated with the given key, if no such value, return null
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override TValue Get(TKey key)
        {
            root = Splay(root, key);
            int cmp = key.CompareTo(root.key);
            return (cmp == 0) ? root.val : default(TValue);
        }

        /// <summary>
        /// Splay tree function.
        /// If a node with that key exists, it is splayed to the root of the tree.
        /// If it does not, the last node along the search path for the key is splayed to the root.
        /// </summary>
        /// <param name="h">start node</param>
        /// <param name="key">splay key in the tree rooted at Node h.</param>
        /// <returns></returns>
        private Node Splay(Node h, TKey key)
        {
            if (h == null) return null;

            int cmp1 = key.CompareTo(h.key);

            if (cmp1 < 0)
            {
                // key not in tree, so we're done
                if (h.left == null)
                {
                    return h;
                }
                int cmp2 = key.CompareTo(h.left.key);
                if (cmp2 < 0)
                {
                    h.left.left = Splay(h.left.left, key);
                    h = RotateRight(h);
                }
                else if (cmp2 > 0)
                {
                    h.left.right = Splay(h.left.right, key);
                    if (h.left.right != null)
                        h.left = RotateLeft(h.left);
                }

                if (h.left == null) return h;
                else return RotateRight(h);
            }

            else if (cmp1 > 0)
            {
                // key not in tree, so we're done
                if (h.right == null)
                {
                    return h;
                }

                int cmp2 = key.CompareTo(h.right.key);
                if (cmp2 < 0)
                {
                    h.right.left = Splay(h.right.left, key);
                    if (h.right.left != null)
                        h.right = RotateRight(h.right);
                }
                else if (cmp2 > 0)
                {
                    h.right.right = Splay(h.right.right, key);
                    h = RotateLeft(h);
                }

                if (h.right == null) return h;
                else return RotateLeft(h);
            }

            else return h;
        }

        // print preorder traversal of the tree
        public override IEnumerator<TKey> GetEnumerator()
        {
            var queue = new Queue<TKey>();
            PreOrder(queue, root);
            return queue.GetEnumerator();
        }

        private void PreOrder(Queue<TKey> queue, Node x)
        {
            if (x == null) return;
            queue.Enqueue(x.key);
            PreOrder(queue, x.left);
            PreOrder(queue, x.right);
        }

        /// <summary>
        /// Splay tree insertion.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        public override void Put(TKey key, TValue val)
        {
            // splay key to root
            if (root == null)
            {
                root = new Node(key, val);
                return;
            }

            root = Splay(root, key);

            int cmp = key.CompareTo(root.key);
 
            // It was a duplicate key. Simply replace the value
            if (cmp == 0)
            {
                root.val = val;
                return;
            }

            // Insert new node at root
            var n = new Node(key, val);
            
            if (cmp < 0)
            {
                n.left = root.left;
                n.right = root;
                root.left = null;

            }

            else if (cmp > 0)
            {
                n.right = root.right;
                n.left = root;
                root.right = null;
            }

            root = n;            
        }

        // right rotate
        private Node RotateRight(Node h)
        {
            Node x = h.left;
            h.left = x.right;
            x.right = h;
            return x;
        }

        // left rotate
        private Node RotateLeft(Node h)
        {
            Node x = h.right;
            h.right = x.left;
            x.left = h;
            return x;
        }
    }
}