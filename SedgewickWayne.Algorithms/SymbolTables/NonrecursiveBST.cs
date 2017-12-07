// http://algs4.cs.princeton.edu/32bst/NonrecursiveBST.java.html


namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class NonrecursiveBST<Key, Value> :
        ISymbolTable<Key, Value>
        where Key : IComparable<Key>, IEquatable<Key>        
    {
        // root of BST
        private Node root;

        private class Node
        {
            public Key key;             // sorted by key
            public Value val;           // associated value
            public Node left, right;    // left and right subtrees

            public Node(Key key, Value val)
            {
                this.key = key;
                this.val = val;
            }
        }


        public bool IsEmpty
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Size
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool Contains(Key key)
        {
            throw new NotImplementedException();
        }

        public void Delete(Key key)
        {
            throw new NotImplementedException();
        }

        public Value Get(Key key)
        {
            Node x = root;
            while (x != null)
            {
                int cmp = key.CompareTo(x.key);
                if (cmp < 0) x = x.left;
                else if (cmp > 0) x = x.right;
                else return x.val;
            }

            //return null;
            return default(Value);
        }

        public void Put(Key key, Value val)
        {
            int cmp = 0;
            Node z = new Node(key, val);
            if (root == null)
            {
                root = z;
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
        }

        /***************************************************************************
        *  Inorder traversal.
        ***************************************************************************/
        public IEnumerable<Key> InorderTraversal ()
        {
            Stack<Node> stack = new Stack<Node>();
            Queue<Key> queue = new Queue<Key>();
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

        public IEnumerator<Key> GetEnumerator()
        {
            return InorderTraversal().GetEnumerator();
        }

        

        IEnumerator IEnumerable.GetEnumerator()
        {
            return InorderTraversal().GetEnumerator();
        }

        

    }
}
