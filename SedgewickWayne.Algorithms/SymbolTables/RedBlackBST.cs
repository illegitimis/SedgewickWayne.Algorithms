// http://algs4.cs.princeton.edu/33balanced/RedBlackLiteBST.java.html
// http://algs4.cs.princeton.edu/33balanced/RedBlackBST.java.html
// A symbol table implemented using a left-leaning red-black BST. This is the 2-3 version.

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    
    /**
     *  The {@code BST} class represents an ordered symbol table of generic
     *  key-value pairs.
     *  It supports the usual <em>put</em>, <em>get</em>, <em>contains</em>,
     *  <em>delete</em>, <em>size</em>, and <em>is-empty</em> methods.
     *  It also provides ordered methods for finding the <em>minimum</em>,
     *  <em>maximum</em>, <em>floor</em>, and <em>ceiling</em>.
     *  It also provides a <em>keys</em> method for iterating over all of the keys.
     *  A symbol table implements the <em>associative array</em> abstraction:
     *  when associating a value with a key that is already in the symbol table,
     *  the convention is to replace the old value with the new value.
     *  Unlike {@link java.util.Map}, this class uses the convention that
     *  values cannot be {@code null}—setting the
     *  value associated with a key to {@code null} is equivalent to deleting the key
     *  from the symbol table.
     *  <p>
     *  This implementation uses a left-leaning red-black BST. It requires that
     *  the key type implements the {@code Comparable} interface and calls the
     *  {@code compareTo()} and method to compare two keys. It does not call either
     *  {@code equals()} or {@code hashCode()}.
     *  The <em>put</em>, <em>contains</em>, <em>remove</em>, <em>minimum</em>,
     *  <em>maximum</em>, <em>ceiling</em>, and <em>floor</em> operations each take
     *  logarithmic time in the worst case, if the tree becomes unbalanced.
     *  The <em>size</em>, and <em>is-empty</em> operations take constant time.
     *  Construction takes constant time.
     *  <p>
     *  For additional documentation, see <a href="http://algs4.cs.princeton.edu/33balanced">Section 3.3</a> of
     *  <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.
     *  For other implementations of the same API, see {@link ST}, {@link BinarySearchST},
     *  {@link SequentialSearchST}, {@link BST},
     *  {@link SeparateChainingHashST}, {@link LinearProbingHashST}, and {@link AVLTreeST}.
     *
     *  @author Robert Sedgewick
     *  @author Kevin Wayne
     */

    public class RedBlackBST<Key, Value> 
        : IOrderedSymbolTable<Key, Value>
        where Key : IComparable<Key>, IEquatable<Key>
        where Value : IEquatable<Value>
    {

    private const bool RED   = true;
    private const bool BLACK = false;

    private Node root;     // root of the BST

        // BST helper node data type
        private class Node
        {
            private Key key;           // key
            private Value val;         // associated data
            private Node left, right;  // links to left and right subtrees
            private bool color;     // color of parent link
            private int size;          // subtree count

            public Node(Key key, Value val, bool color, int size)
            {
                this.key = key;
                this.val = val;
                this.color = color;
                this.size = size;
            }

/***************************************************************************
*  Node helper methods.
***************************************************************************/

            // is node x red; false if x is null ?
            public bool IsRed { get { return (this == null) ? false : color == RED; } }
            public int Size { get { return (this == null) ? 0 : size; } }

            public bool Is23
            {get {
                    if (x == null) return true;
                    if (isRed(x.right)) return false;
                    if (x != root && isRed(x) && isRed(x.left))
                        return false;
                    return Is23(x.left) && Is23(x.right);
                }
                
            }

            // does every path from the root to a leaf have the given number of black links?
            public bool IsBalanced(int black)
            {
                if (this == null) return black == 0;
                if (!IsRed) black--;
                return IsBalanced(this.left, black) && IsBalanced(this.right, black);
            }

            public int Height
            {
                get
                {
                    return (x == null) ? -1 : 1 + Math.Max(x.left.Height, x.right.Height);                    
                }
                
            }
        }

    /**
     * Initializes an empty symbol table.
     */
    public RedBlackBST() { }

  
   

        /**
         * Returns the number of key-value pairs in this symbol table.
         * @return the number of key-value pairs in this symbol table
         * number of node in subtree rooted at x; 0 if x is null
         */
        public int Size { get { return root.Size; } }

    /**
      * Is this symbol table empty?
      * @return {@code true} if this symbol table is empty and {@code false} otherwise
      */
    public bool IsEmpty { get { return root == null; } }
    

    /***************************************************************************
     *  Standard BST search.
     ***************************************************************************/

    /**
     * Returns the value associated with the given key.
     * @param key the key
     * @return the value associated with the given key if the key is in the symbol table
     *     and {@code null} if the key is not in the symbol table
     * @throws IllegalArgumentException if {@code key} is {@code null}
     */
    public Value Get(Key key)
    {
        if (key == null) throw new IllegalArgumentException("argument to get() is null");
        return get(root, key);
    }

    // value associated with the given key in subtree rooted at x; null if no such key
    private Value get(Node x, Key key)
    {
        while (x != null)
        {
            int cmp = key.compareTo(x.key);
            if (cmp < 0) x = x.left;
            else if (cmp > 0) x = x.right;
            else return x.val;
        }
        return null;
    }

    /**
     * Does this symbol table contain the given key?
     * @param key the key
     * @return {@code true} if this symbol table contains {@code key} and
     *     {@code false} otherwise
     * @throws IllegalArgumentException if {@code key} is {@code null}
     */
    public bool Contains(Key key) { return get(key) != null; } 

    /***************************************************************************
     *  Red-black tree insertion.
     ***************************************************************************/

    /**
     * Inserts the specified key-value pair into the symbol table, overwriting the old 
     * value with the new value if the symbol table already contains the specified key.
     * Deletes the specified key (and its associated value) from this symbol table
     * if the specified value is {@code null}.
     *
     * @param key the key
     * @param val the value
     * @throws IllegalArgumentException if {@code key} is {@code null}
     */
    public void Put(Key key, Value val)
    {
        if (key == null) throw new IllegalArgumentException("first argument to put() is null");
        if (val == null)
        {
            delete(key);
            return;
        }

        root = put(root, key, val);
        root.color = BLACK;
        // assert check();
    }

    // insert the key-value pair in the subtree rooted at h
    private Node put(Node h, Key key, Value val)
    {
        if (h == null) return new Node(key, val, RED, 1);

        int cmp = key.compareTo(h.key);
        if (cmp < 0) h.left = put(h.left, key, val);
        else if (cmp > 0) h.right = put(h.right, key, val);
        else h.val = val;

        // fix-up any right-leaning links
        if (isRed(h.right) && !isRed(h.left)) h = rotateLeft(h);
        if (isRed(h.left) && isRed(h.left.left)) h = rotateRight(h);
        if (isRed(h.left) && isRed(h.right)) flipColors(h);
        h.size = size(h.left) + size(h.right) + 1;

        return h;
    }

    /***************************************************************************
     *  Red-black tree deletion.
     ***************************************************************************/

    /**
     * Removes the smallest key and associated value from the symbol table.
     * @throws NoSuchElementException if the symbol table is empty
     */
    public void deleteMin()
    {
        if (isEmpty()) throw new NoSuchElementException("BST underflow");

        // if both children of root are black, set root to red
        if (!isRed(root.left) && !isRed(root.right))
            root.color = RED;

        root = deleteMin(root);
        if (!isEmpty()) root.color = BLACK;
        // assert check();
    }

    // delete the key-value pair with the minimum key rooted at h
    private Node deleteMin(Node h)
    {
        if (h.left == null)
            return null;

        if (!isRed(h.left) && !isRed(h.left.left))
            h = moveRedLeft(h);

        h.left = deleteMin(h.left);
        return balance(h);
    }


    /**
     * Removes the largest key and associated value from the symbol table.
     * @throws NoSuchElementException if the symbol table is empty
     */
    public void deleteMax()
    {
        if (isEmpty()) throw new NoSuchElementException("BST underflow");

        // if both children of root are black, set root to red
        if (!isRed(root.left) && !isRed(root.right))
            root.color = RED;

        root = deleteMax(root);
        if (!isEmpty()) root.color = BLACK;
        // assert check();
    }

    // delete the key-value pair with the maximum key rooted at h
    private Node deleteMax(Node h)
    {
        if (isRed(h.left))
            h = rotateRight(h);

        if (h.right == null)
            return null;

        if (!isRed(h.right) && !isRed(h.right.left))
            h = moveRedRight(h);

        h.right = deleteMax(h.right);

        return balance(h);
    }

    /**
     * Removes the specified key and its associated value from this symbol table     
     * (if the key is in this symbol table).    
     *
     * @param  key the key
     * @throws IllegalArgumentException if {@code key} is {@code null}
     */
    public void delete(Key key)
    {
        if (key == null) throw new IllegalArgumentException("argument to delete() is null");
        if (!contains(key)) return;

        // if both children of root are black, set root to red
        if (!isRed(root.left) && !isRed(root.right))
            root.color = RED;

        root = delete(root, key);
        if (!isEmpty()) root.color = BLACK;
        // assert check();
    }

    // delete the key-value pair with the given key rooted at h
    private Node delete(Node h, Key key)
    {
        // assert get(h, key) != null;

        if (key.compareTo(h.key) < 0)
        {
            if (!isRed(h.left) && !isRed(h.left.left))
                h = moveRedLeft(h);
            h.left = delete(h.left, key);
        }
        else
        {
            if (isRed(h.left))
                h = rotateRight(h);
            if (key.compareTo(h.key) == 0 && (h.right == null))
                return null;
            if (!isRed(h.right) && !isRed(h.right.left))
                h = moveRedRight(h);
            if (key.compareTo(h.key) == 0)
            {
                Node x = min(h.right);
                h.key = x.key;
                h.val = x.val;
                // h.val = get(h.right, min(h.right).key);
                // h.key = min(h.right).key;
                h.right = deleteMin(h.right);
            }
            else h.right = delete(h.right, key);
        }
        return balance(h);
    }

    /***************************************************************************
     *  Red-black tree helper functions.
     ***************************************************************************/

    // make a left-leaning link lean to the right
    private Node rotateRight(Node h)
    {
        // assert (h != null) && isRed(h.left);
        Node x = h.left;
        h.left = x.right;
        x.right = h;
        x.color = x.right.color;
        x.right.color = RED;
        x.size = h.size;
        h.size = size(h.left) + size(h.right) + 1;
        return x;
    }

    // make a right-leaning link lean to the left
    private Node rotateLeft(Node h)
    {
        // assert (h != null) && isRed(h.right);
        Node x = h.right;
        h.right = x.left;
        x.left = h;
        x.color = x.left.color;
        x.left.color = RED;
        x.size = h.size;
        h.size = size(h.left) + size(h.right) + 1;
        return x;
    }

    // flip the colors of a node and its two children
    private void flipColors(Node h)
    {
        // h must have opposite color of its two children
        // assert (h != null) && (h.left != null) && (h.right != null);
        // assert (!isRed(h) &&  isRed(h.left) &&  isRed(h.right))
        //    || (isRed(h)  && !isRed(h.left) && !isRed(h.right));
        h.color = !h.color;
        h.left.color = !h.left.color;
        h.right.color = !h.right.color;
    }

    // Assuming that h is red and both h.left and h.left.left
    // are black, make h.left or one of its children red.
    private Node moveRedLeft(Node h)
    {
        // assert (h != null);
        // assert isRed(h) && !isRed(h.left) && !isRed(h.left.left);

        flipColors(h);
        if (isRed(h.right.left))
        {
            h.right = rotateRight(h.right);
            h = rotateLeft(h);
            flipColors(h);
        }
        return h;
    }

    // Assuming that h is red and both h.right and h.right.left
    // are black, make h.right or one of its children red.
    private Node moveRedRight(Node h)
    {
        // assert (h != null);
        // assert isRed(h) && !isRed(h.right) && !isRed(h.right.left);
        flipColors(h);
        if (isRed(h.left.left))
        {
            h = rotateRight(h);
            flipColors(h);
        }
        return h;
    }

    // restore red-black tree invariant
    private Node balance(Node h)
    {
        // assert (h != null);

        if (isRed(h.right)) h = rotateLeft(h);
        if (isRed(h.left) && isRed(h.left.left)) h = rotateRight(h);
        if (isRed(h.left) && isRed(h.right)) flipColors(h);

        h.size = size(h.left) + size(h.right) + 1;
        return h;
    }


    /***************************************************************************
     *  Utility functions.
     ***************************************************************************/

    /**
     * Returns the height of the BST (for debugging).
     * @return the height of the BST (a 1-node tree has height 0)
     */
    public int height()
    {
        return height(root);
    }
  

    /***************************************************************************
     *  Ordered symbol table methods.
     ***************************************************************************/

    /**
     * Returns the smallest key in the symbol table.
     * @return the smallest key in the symbol table
     * @throws NoSuchElementException if the symbol table is empty
     */
    public Key min()
    {
        if (isEmpty()) throw new NoSuchElementException("called min() with empty symbol table");
        return min(root).key;
    }

    // the smallest key in subtree rooted at x; null if no such key
    private Node min(Node x)
    {
        // assert x != null;
        if (x.left == null) return x;
        else return min(x.left);
    }

    /**
     * Returns the largest key in the symbol table.
     * @return the largest key in the symbol table
     * @throws NoSuchElementException if the symbol table is empty
     */
    public Key max()
    {
        if (isEmpty()) throw new NoSuchElementException("called max() with empty symbol table");
        return max(root).key;
    }

    // the largest key in the subtree rooted at x; null if no such key
    private Node max(Node x)
    {
        // assert x != null;
        if (x.right == null) return x;
        else return max(x.right);
    }


    /**
     * Returns the largest key in the symbol table less than or equal to {@code key}.
     * @param key the key
     * @return the largest key in the symbol table less than or equal to {@code key}
     * @throws NoSuchElementException if there is no such key
     * @throws IllegalArgumentException if {@code key} is {@code null}
     */
    public Key floor(Key key)
    {
        if (key == null) throw new IllegalArgumentException("argument to floor() is null");
        if (isEmpty()) throw new NoSuchElementException("called floor() with empty symbol table");
        Node x = floor(root, key);
        if (x == null) return null;
        else return x.key;
    }

    // the largest key in the subtree rooted at x less than or equal to the given key
    private Node floor(Node x, Key key)
    {
        if (x == null) return null;
        int cmp = key.compareTo(x.key);
        if (cmp == 0) return x;
        if (cmp < 0) return floor(x.left, key);
        Node t = floor(x.right, key);
        if (t != null) return t;
        else return x;
    }

    /**
     * Returns the smallest key in the symbol table greater than or equal to {@code key}.
     * @param key the key
     * @return the smallest key in the symbol table greater than or equal to {@code key}
     * @throws NoSuchElementException if there is no such key
     * @throws IllegalArgumentException if {@code key} is {@code null}
     */
    public Key ceiling(Key key)
    {
        if (key == null) throw new IllegalArgumentException("argument to ceiling() is null");
        if (isEmpty()) throw new NoSuchElementException("called ceiling() with empty symbol table");
        Node x = ceiling(root, key);
        if (x == null) return null;
        else return x.key;
    }

    // the smallest key in the subtree rooted at x greater than or equal to the given key
    private Node ceiling(Node x, Key key)
    {
        if (x == null) return null;
        int cmp = key.compareTo(x.key);
        if (cmp == 0) return x;
        if (cmp > 0) return ceiling(x.right, key);
        Node t = ceiling(x.left, key);
        if (t != null) return t;
        else return x;
    }

    /**
     * Return the kth smallest key in the symbol table.
     * @param k the order statistic
     * @return the {@code k}th smallest key in the symbol table
     * @throws IllegalArgumentException unless {@code k} is between 0 and
     *     <em>n</em>–1
     */
    public Key select(int k)
    {
        if (k < 0 || k >= size())
        {
            throw new IllegalArgumentException("called select() with invalid argument: " + k);
        }
        Node x = select(root, k);
        return x.key;
    }

    // the key of rank k in the subtree rooted at x
    private Node select(Node x, int k)
    {
        // assert x != null;
        // assert k >= 0 && k < size(x);
        int t = size(x.left);
        if (t > k) return select(x.left, k);
        else if (t < k) return select(x.right, k - t - 1);
        else return x;
    }

    /**
     * Return the number of keys in the symbol table strictly less than {@code key}.
     * @param key the key
     * @return the number of keys in the symbol table strictly less than {@code key}
     * @throws IllegalArgumentException if {@code key} is {@code null}
     */
    public int rank(Key key)
    {
        if (key == null) throw new IllegalArgumentException("argument to rank() is null");
        return rank(key, root);
    }

    // number of keys less than key in the subtree rooted at x
    private int rank(Key key, Node x)
    {
        if (x == null) return 0;
        int cmp = key.compareTo(x.key);
        if (cmp < 0) return rank(key, x.left);
        else if (cmp > 0) return 1 + size(x.left) + rank(key, x.right);
        else return size(x.left);
    }

    /***************************************************************************
     *  Range count and range search.
     ***************************************************************************/

    /**
     * Returns all keys in the symbol table as an {@code Iterable}.
     * To iterate over all of the keys in the symbol table named {@code st},
     * use the foreach notation: {@code for (Key key : st.keys())}.
     * @return all keys in the symbol table as an {@code Iterable}
     */
    public Iterable<Key> keys()
    {
        if (isEmpty()) return new Queue<Key>();
        return keys(min(), max());
    }

    /**
     * Returns all keys in the symbol table in the given range,
     * as an {@code Iterable}.
     *
     * @param  lo minimum endpoint
     * @param  hi maximum endpoint
     * @return all keys in the sybol table between {@code lo} 
     *    (inclusive) and {@code hi} (inclusive) as an {@code Iterable}
     * @throws IllegalArgumentException if either {@code lo} or {@code hi}
     *    is {@code null}
     */
    public Iterable<Key> keys(Key lo, Key hi)
    {
        if (lo == null) throw new IllegalArgumentException("first argument to keys() is null");
        if (hi == null) throw new IllegalArgumentException("second argument to keys() is null");

        Queue<Key> queue = new Queue<Key>();
        // if (isEmpty() || lo.compareTo(hi) > 0) return queue;
        keys(root, queue, lo, hi);
        return queue;
    }

    // add the keys between lo and hi in the subtree rooted at x
    // to the queue
    private void keys(Node x, Queue<Key> queue, Key lo, Key hi)
    {
        if (x == null) return;
        int cmplo = lo.compareTo(x.key);
        int cmphi = hi.compareTo(x.key);
        if (cmplo < 0) keys(x.left, queue, lo, hi);
        if (cmplo <= 0 && cmphi >= 0) queue.enqueue(x.key);
        if (cmphi > 0) keys(x.right, queue, lo, hi);
    }

    /**
     * Returns the number of keys in the symbol table in the given range.
     *
     * @param  lo minimum endpoint
     * @param  hi maximum endpoint
     * @return the number of keys in the sybol table between {@code lo} 
     *    (inclusive) and {@code hi} (inclusive)
     * @throws IllegalArgumentException if either {@code lo} or {@code hi}
     *    is {@code null}
     */
    public int size(Key lo, Key hi)
    {
        if (lo == null) throw new IllegalArgumentException("first argument to size() is null");
        if (hi == null) throw new IllegalArgumentException("second argument to size() is null");

        if (lo.compareTo(hi) > 0) return 0;
        if (contains(hi)) return rank(hi) - rank(lo) + 1;
        else return rank(hi) - rank(lo);
    }


    /***************************************************************************
     *  Check integrity of red-black tree data structure.
     ***************************************************************************/
    private bool check()
    {
        if (!isBST()) StdOut.println("Not in symmetric order");
        if (!isSizeConsistent()) StdOut.println("Subtree counts not consistent");
        if (!isRankConsistent()) StdOut.println("Ranks not consistent");
        if (!Is23) StdOut.println("Not a 2-3 tree");
        if (!IsBalanced) StdOut.println("Not balanced");
        return isBST() && isSizeConsistent() && isRankConsistent() && Is23() && IsBalanced;
    }

    // does this binary tree satisfy symmetric order?
    // Note: this test also ensures that data structure is a binary tree since order is strict
    private bool isBST()
    {
        return isBST(root, null, null);
    }

    // is the tree rooted at x a BST with all keys strictly between min and max
    // (if min or max is null, treat as empty constraint)
    // Credit: Bob Dondero's elegant solution
    private bool isBST(Node x, Key min, Key max)
    {
        if (x == null) return true;
        if (min != null && x.key.compareTo(min) <= 0) return false;
        if (max != null && x.key.compareTo(max) >= 0) return false;
        return isBST(x.left, min, x.key) && isBST(x.right, x.key, max);
    }

    // are the size fields correct?
    private bool isSizeConsistent() { return isSizeConsistent(root); }
    private bool isSizeConsistent(Node x)
    {
        if (x == null) return true;
        if (x.size != size(x.left) + size(x.right) + 1) return false;
        return isSizeConsistent(x.left) && isSizeConsistent(x.right);
    }

    // check that ranks are consistent
    private bool isRankConsistent()
    {
        for (int i = 0; i < size(); i++)
            if (i != rank(select(i))) return false;
        for (Key key : keys())
            if (key.compareTo(select(rank(key))) != 0) return false;
        return true;
    }

    // Does the tree have no red right links, and at most one (left)
    // red links in a row on any path?
    bool Is23 { get { return root.Is23; } }
    

    // do all paths from root to leaf have same number of black edges?
    private bool IsBalanced
    {
            get { 
            int black = 0;     // number of black links on path from root to min
        Node x = root;
        while (x != null)
        {
            if (!isRed(x)) black++;
            x = x.left;
        }
        return isBalanced(root, black);
    }
        }

    


    
}


  //  //[Signature("<Key::Ljava/lang/Comparable<TKey;>;Value:Ljava/lang/Object;>Ljava/lang/Object;")]
  //  public class RedBlackBST
  //  {
  //      //[InnerClass(null, Modifiers.Private), Modifiers(Modifiers.Super), SourceFile("RedBlackBST.java")]
  //      internal sealed class Node
  //      {
  //          //[Signature("TKey;")]
  //          private IComparable key;
  //          //[Signature("TValue;")]
  //          private object val;
  //          //[Signature("LRedBlackBST<TKey;TValue;>.Node;")]
  //          private RedBlackBST.Node left;
  //          //[Signature("LRedBlackBST<TKey;TValue;>.Node;")]
  //          private RedBlackBST.Node right;
  //          private bool color;
  //          private int N;
  //          //[Modifiers(Modifiers.Final | Modifiers.Synthetic)]
  //          internal RedBlackBST redBlackBST;
  //          /*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
  //          internal static bool access_000(RedBlackBST.Node node)
  //          {
  //              return node.color;
  //          }
  //          /*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
  //          internal static int access_100(RedBlackBST.Node node)
  //          {
  //              return node.N;
  //          }
  //          /*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
  //          internal static IComparable access_200(RedBlackBST.Node node)
  //          {
  //              return node.key;
  //          }
  //          /*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
  //          internal static RedBlackBST.Node access_300(RedBlackBST.Node node)
  //          {
  //              return node.left;
  //          }
  //          /*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
  //          internal static RedBlackBST.Node access_400(RedBlackBST.Node node)
  //          {
  //              return node.right;
  //          }
  //          /*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
  //          internal static object access_500(RedBlackBST.Node node)
  //          {
  //              return node.val;
  //          }
  //          /*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
  //          internal static bool access_002(RedBlackBST.Node node, bool result)
  //          {
  //              node.color = result;
  //              return result;
  //          }
  //          /*		[Signature("(TKey;TValue;ZI)V")]*/

  //          public Node(RedBlackBST redBlackBST, IComparable comparable, object obj, bool flag, int n)
  //          {
  //              this.key = comparable;
  //              this.val = obj;
  //              this.color = flag;
  //              this.N = n;
  //          }
  //          /*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
  //          internal static RedBlackBST.Node access_302(RedBlackBST.Node node, RedBlackBST.Node result)
  //          {
  //              node.left = result;
  //              return result;
  //          }
  //          /*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
  //          internal static RedBlackBST.Node access_402(RedBlackBST.Node node, RedBlackBST.Node result)
  //          {
  //              node.right = result;
  //              return result;
  //          }
  //          /*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
  //          internal static object access_502(RedBlackBST.Node node, object result)
  //          {
  //              node.val = result;
  //              return result;
  //          }
  //          /*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
  //          internal static int access_102(RedBlackBST.Node node, int num)
  //          {
  //              node.N = num;
  //              return num;
  //          }
  //          /*		[LineNumberTable(37), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
  //          internal static IComparable access_202(RedBlackBST.Node node, IComparable result)
  //          {
  //              node.key = result;
  //              return result;
  //          }
  //      }
  //      private const bool RED = true;
  //      private const bool BLACK = false;
  //      //[Signature("LRedBlackBST<TKey;TValue;>.Node;")]
  //      private RedBlackBST.Node root;
  //      //[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
  //      internal static bool s_assertionsDisabled;


  //      /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)I")]*/

  //      private int size(RedBlackBST.Node node)
  //      {
  //          if (node == null)
  //          {
  //              return 0;
  //          }
  //          return RedBlackBST.Node.access_100(node);
  //      }
  //      /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;TKey;)TValue;")]*/

  //      private object get(RedBlackBST.Node node, IComparable o)
  //      {
  //          while (node != null)
  //          {
  //              int num = Comparable.__Helper.CompareTo(o, RedBlackBST.Node.access_200(node));
  //              if (num < 0)
  //              {
  //                  node = RedBlackBST.Node.access_300(node);
  //              }
  //              else
  //              {
  //                  if (num <= 0)
  //                  {
  //                      return RedBlackBST.Node.access_500(node);
  //                  }
  //                  node = RedBlackBST.Node.access_400(node);
  //              }
  //          }
  //          return null;
  //      }
  //      /*	[LineNumberTable(85), Signature("(TKey;)TValue;")]*/

  //      public virtual object get(IComparable c)
  //      {
  //          return this.get(this.root, c);
  //      }
  //      /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;TKey;TValue;)LRedBlackBST<TKey;TValue;>.Node;")]*/

  //      private RedBlackBST.Node put(RedBlackBST.Node node, IComparable comparable, object obj)
  //      {
  //          if (node == null)
  //          {
  //              return new RedBlackBST.Node(this, comparable, obj, true, 1);
  //          }
  //          int num = Comparable.__Helper.CompareTo(comparable, RedBlackBST.Node.access_200(node));
  //          if (num < 0)
  //          {
  //              RedBlackBST.Node.access_302(node, this.put(RedBlackBST.Node.access_300(node), comparable, obj));
  //          }
  //          else if (num > 0)
  //          {
  //              RedBlackBST.Node.access_402(node, this.put(RedBlackBST.Node.access_400(node), comparable, obj));
  //          }
  //          else
  //          {
  //              RedBlackBST.Node.access_502(node, obj);
  //          }
  //          if (this.isRed(RedBlackBST.Node.access_400(node)) && !this.isRed(RedBlackBST.Node.access_300(node)))
  //          {
  //              node = this.rotateLeft(node);
  //          }
  //          if (this.isRed(RedBlackBST.Node.access_300(node)) && this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_300(node))))
  //          {
  //              node = this.rotateRight(node);
  //          }
  //          if (this.isRed(RedBlackBST.Node.access_300(node)) && this.isRed(RedBlackBST.Node.access_400(node)))
  //          {
  //              this.flipColors(node);
  //          }
  //          RedBlackBST.Node.access_102(node, this.size(RedBlackBST.Node.access_300(node)) + this.size(RedBlackBST.Node.access_400(node)) + 1);
  //          return node;
  //      }


  //      private bool check()
  //      {
  //          if (!this.isBST())
  //          {
  //              StdOut.println("Not in symmetric order");
  //          }
  //          if (!this.isSizeConsistent())
  //          {
  //              StdOut.println("Subtree counts not consistent");
  //          }
  //          if (!this.isRankConsistent())
  //          {
  //              StdOut.println("Ranks not consistent");
  //          }
  //          if (!this.Is23())
  //          {
  //              StdOut.println("Not a 2-3 tree");
  //          }
  //          if (!this.IsBalanced)
  //          {
  //              StdOut.println("Not balanced");
  //          }
  //          return this.isBST() && this.isSizeConsistent() && this.isRankConsistent() && this.Is23() && this.IsBalanced;
  //      }
  //      /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)Z")]*/

  //      private bool isRed(RedBlackBST.Node node)
  //      {
  //          return node != null && RedBlackBST.Node.access_000(node);
  //      }
  //      /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)LRedBlackBST<TKey;TValue;>.Node;")]*/

  //      private RedBlackBST.Node rotateLeft(RedBlackBST.Node node)
  //      {
  //          if (!RedBlackBST.s_assertionsDisabled && (node == null || !this.isRed(RedBlackBST.Node.access_400(node))))
  //          {

  //              throw new AssertionError();
  //          }
  //          RedBlackBST.Node node2 = RedBlackBST.Node.access_400(node);
  //          RedBlackBST.Node.access_402(node, RedBlackBST.Node.access_300(node2));
  //          RedBlackBST.Node.access_302(node2, node);
  //          RedBlackBST.Node.access_002(node2, RedBlackBST.Node.access_000(RedBlackBST.Node.access_300(node2)));
  //          RedBlackBST.Node.access_002(RedBlackBST.Node.access_300(node2), true);
  //          RedBlackBST.Node.access_102(node2, RedBlackBST.Node.access_100(node));
  //          RedBlackBST.Node.access_102(node, this.size(RedBlackBST.Node.access_300(node)) + this.size(RedBlackBST.Node.access_400(node)) + 1);
  //          return node2;
  //      }
  //      /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)LRedBlackBST<TKey;TValue;>.Node;")]*/

  //      private RedBlackBST.Node rotateRight(RedBlackBST.Node node)
  //      {
  //          if (!RedBlackBST.s_assertionsDisabled && (node == null || !this.isRed(RedBlackBST.Node.access_300(node))))
  //          {

  //              throw new AssertionError();
  //          }
  //          RedBlackBST.Node node2 = RedBlackBST.Node.access_300(node);
  //          RedBlackBST.Node.access_302(node, RedBlackBST.Node.access_400(node2));
  //          RedBlackBST.Node.access_402(node2, node);
  //          RedBlackBST.Node.access_002(node2, RedBlackBST.Node.access_000(RedBlackBST.Node.access_400(node2)));
  //          RedBlackBST.Node.access_002(RedBlackBST.Node.access_400(node2), true);
  //          RedBlackBST.Node.access_102(node2, RedBlackBST.Node.access_100(node));
  //          RedBlackBST.Node.access_102(node, this.size(RedBlackBST.Node.access_300(node)) + this.size(RedBlackBST.Node.access_400(node)) + 1);
  //          return node2;
  //      }
  //      /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)V")]*/

  //      private void flipColors(RedBlackBST.Node node)
  //      {
  //          if (!RedBlackBST.s_assertionsDisabled && (node == null || RedBlackBST.Node.access_300(node) == null || RedBlackBST.Node.access_400(node) == null))
  //          {

  //              throw new AssertionError();
  //          }
  //          if (!RedBlackBST.s_assertionsDisabled && (this.isRed(node) || !this.isRed(RedBlackBST.Node.access_300(node)) || !this.isRed(RedBlackBST.Node.access_400(node))) && (!this.isRed(node) || this.isRed(RedBlackBST.Node.access_300(node)) || this.isRed(RedBlackBST.Node.access_400(node))))
  //          {

  //              throw new AssertionError();
  //          }
  //          RedBlackBST.Node.access_002(node, !RedBlackBST.Node.access_000(node));
  //          RedBlackBST.Node.access_002(RedBlackBST.Node.access_300(node), !RedBlackBST.Node.access_000(RedBlackBST.Node.access_300(node)));
  //          RedBlackBST.Node.access_002(RedBlackBST.Node.access_400(node), !RedBlackBST.Node.access_000(RedBlackBST.Node.access_400(node)));
  //      }
  //      public virtual bool IsEmpty
  //      {
		//return this.root == null;
  //      }
  //      /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)LRedBlackBST<TKey;TValue;>.Node;")]*/

  //      private RedBlackBST.Node deleteMin(RedBlackBST.Node node)
  //      {
  //          if (RedBlackBST.Node.access_300(node) == null)
  //          {
  //              return null;
  //          }
  //          if (!this.isRed(RedBlackBST.Node.access_300(node)) && !this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_300(node))))
  //          {
  //              node = this.moveRedLeft(node);
  //          }
  //          RedBlackBST.Node.access_302(node, this.deleteMin(RedBlackBST.Node.access_300(node)));
  //          return this.balance(node);
  //      }
  //      /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)LRedBlackBST<TKey;TValue;>.Node;")]*/

  //      private RedBlackBST.Node moveRedLeft(RedBlackBST.Node node)
  //      {
  //          if (!RedBlackBST.s_assertionsDisabled && node == null)
  //          {

  //              throw new AssertionError();
  //          }
  //          if (!RedBlackBST.s_assertionsDisabled && (!this.isRed(node) || this.isRed(RedBlackBST.Node.access_300(node)) || this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_300(node)))))
  //          {

  //              throw new AssertionError();
  //          }
  //          this.flipColors(node);
  //          if (this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_400(node))))
  //          {
  //              RedBlackBST.Node.access_402(node, this.rotateRight(RedBlackBST.Node.access_400(node)));
  //              node = this.rotateLeft(node);
  //          }
  //          return node;
  //      }
  //      /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)LRedBlackBST<TKey;TValue;>.Node;")]*/

  //      private RedBlackBST.Node balance(RedBlackBST.Node node)
  //      {
  //          if (!RedBlackBST.s_assertionsDisabled && node == null)
  //          {

  //              throw new AssertionError();
  //          }
  //          if (this.isRed(RedBlackBST.Node.access_400(node)))
  //          {
  //              node = this.rotateLeft(node);
  //          }
  //          if (this.isRed(RedBlackBST.Node.access_300(node)) && this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_300(node))))
  //          {
  //              node = this.rotateRight(node);
  //          }
  //          if (this.isRed(RedBlackBST.Node.access_300(node)) && this.isRed(RedBlackBST.Node.access_400(node)))
  //          {
  //              this.flipColors(node);
  //          }
  //          RedBlackBST.Node.access_102(node, this.size(RedBlackBST.Node.access_300(node)) + this.size(RedBlackBST.Node.access_400(node)) + 1);
  //          return node;
  //      }
  //      /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)LRedBlackBST<TKey;TValue;>.Node;")]*/

  //      private RedBlackBST.Node deleteMax(RedBlackBST.Node node)
  //      {
  //          if (this.isRed(RedBlackBST.Node.access_300(node)))
  //          {
  //              node = this.rotateRight(node);
  //          }
  //          if (RedBlackBST.Node.access_400(node) == null)
  //          {
  //              return null;
  //          }
  //          if (!this.isRed(RedBlackBST.Node.access_400(node)) && !this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_400(node))))
  //          {
  //              node = this.moveRedRight(node);
  //          }
  //          RedBlackBST.Node.access_402(node, this.deleteMax(RedBlackBST.Node.access_400(node)));
  //          return this.balance(node);
  //      }
  //      /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)LRedBlackBST<TKey;TValue;>.Node;")]*/

  //      private RedBlackBST.Node moveRedRight(RedBlackBST.Node node)
  //      {
  //          if (!RedBlackBST.s_assertionsDisabled && node == null)
  //          {

  //              throw new AssertionError();
  //          }
  //          if (!RedBlackBST.s_assertionsDisabled && (!this.isRed(node) || this.isRed(RedBlackBST.Node.access_400(node)) || this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_400(node)))))
  //          {

  //              throw new AssertionError();
  //          }
  //          this.flipColors(node);
  //          if (this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_300(node))))
  //          {
  //              node = this.rotateRight(node);
  //          }
  //          return node;
  //      }
  //      /*	[LineNumberTable(100), Signature("(TKey;)Z")]*/

  //      public virtual bool contains(IComparable c)
  //      {
  //          return this.get(c) != null;
  //      }
  //      /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;TKey;)LRedBlackBST<TKey;TValue;>.Node;")]*/

  //      private RedBlackBST.Node delete(RedBlackBST.Node node, IComparable comparable)
  //      {
  //          if (!RedBlackBST.s_assertionsDisabled && !this.contains(node, comparable))
  //          {

  //              throw new AssertionError();
  //          }
  //          if (Comparable.__Helper.CompareTo(comparable, RedBlackBST.Node.access_200(node)) < 0)
  //          {
  //              if (!this.isRed(RedBlackBST.Node.access_300(node)) && !this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_300(node))))
  //              {
  //                  node = this.moveRedLeft(node);
  //              }
  //              RedBlackBST.Node.access_302(node, this.delete(RedBlackBST.Node.access_300(node), comparable));
  //          }
  //          else
  //          {
  //              if (this.isRed(RedBlackBST.Node.access_300(node)))
  //              {
  //                  node = this.rotateRight(node);
  //              }
  //              if (Comparable.__Helper.CompareTo(comparable, RedBlackBST.Node.access_200(node)) == 0 && RedBlackBST.Node.access_400(node) == null)
  //              {
  //                  return null;
  //              }
  //              if (!this.isRed(RedBlackBST.Node.access_400(node)) && !this.isRed(RedBlackBST.Node.access_300(RedBlackBST.Node.access_400(node))))
  //              {
  //                  node = this.moveRedRight(node);
  //              }
  //              if (Comparable.__Helper.CompareTo(comparable, RedBlackBST.Node.access_200(node)) == 0)
  //              {
  //                  RedBlackBST.Node node2 = this.min(RedBlackBST.Node.access_400(node));
  //                  RedBlackBST.Node.access_202(node, RedBlackBST.Node.access_200(node2));
  //                  RedBlackBST.Node.access_502(node, RedBlackBST.Node.access_500(node2));
  //                  RedBlackBST.Node.access_402(node, this.deleteMin(RedBlackBST.Node.access_400(node)));
  //              }
  //              else
  //              {
  //                  RedBlackBST.Node.access_402(node, this.delete(RedBlackBST.Node.access_400(node), comparable));
  //              }
  //          }
  //          return this.balance(node);
  //      }
  //      /*	[LineNumberTable(105), Signature("(LRedBlackBST<TKey;TValue;>.Node;TKey;)Z")]*/

  //      private bool contains(RedBlackBST.Node node, IComparable comparable)
  //      {
  //          return this.get(node, comparable) != null;
  //      }
  //      /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)LRedBlackBST<TKey;TValue;>.Node;")]*/

  //      private RedBlackBST.Node min(RedBlackBST.Node node)
  //      {
  //          if (!RedBlackBST.s_assertionsDisabled && node == null)
  //          {

  //              throw new AssertionError();
  //          }
  //          if (RedBlackBST.Node.access_300(node) == null)
  //          {
  //              return node;
  //          }
  //          return this.min(RedBlackBST.Node.access_300(node));
  //      }
  //      /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)I")]*/

  //      private int height(RedBlackBST.Node node)
  //      {
  //          if (node == null)
  //          {
  //              return -1;
  //          }
  //          return 1 + java.lang.Math.max(this.height(RedBlackBST.Node.access_300(node)), this.height(RedBlackBST.Node.access_400(node)));
  //      }
  //      /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)LRedBlackBST<TKey;TValue;>.Node;")]*/

  //      private RedBlackBST.Node max(RedBlackBST.Node node)
  //      {
  //          if (!RedBlackBST.s_assertionsDisabled && node == null)
  //          {

  //              throw new AssertionError();
  //          }
  //          if (RedBlackBST.Node.access_400(node) == null)
  //          {
  //              return node;
  //          }
  //          return this.max(RedBlackBST.Node.access_400(node));
  //      }
  //      /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;TKey;)LRedBlackBST<TKey;TValue;>.Node;")]*/

  //      private RedBlackBST.Node floor(RedBlackBST.Node node, IComparable comparable)
  //      {
  //          if (node == null)
  //          {
  //              return null;
  //          }
  //          int num = Comparable.__Helper.CompareTo(comparable, RedBlackBST.Node.access_200(node));
  //          if (num == 0)
  //          {
  //              return node;
  //          }
  //          if (num < 0)
  //          {
  //              return this.floor(RedBlackBST.Node.access_300(node), comparable);
  //          }
  //          RedBlackBST.Node node2 = this.floor(RedBlackBST.Node.access_400(node), comparable);
  //          if (node2 != null)
  //          {
  //              return node2;
  //          }
  //          return node;
  //      }
  //      /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;TKey;)LRedBlackBST<TKey;TValue;>.Node;")]*/

  //      private RedBlackBST.Node ceiling(RedBlackBST.Node node, IComparable comparable)
  //      {
  //          if (node == null)
  //          {
  //              return null;
  //          }
  //          int num = Comparable.__Helper.CompareTo(comparable, RedBlackBST.Node.access_200(node));
  //          if (num == 0)
  //          {
  //              return node;
  //          }
  //          if (num > 0)
  //          {
  //              return this.ceiling(RedBlackBST.Node.access_400(node), comparable);
  //          }
  //          RedBlackBST.Node node2 = this.ceiling(RedBlackBST.Node.access_300(node), comparable);
  //          if (node2 != null)
  //          {
  //              return node2;
  //          }
  //          return node;
  //      }


  //      public virtual int Size
  //      {
		//return this.size(this.root);
  //      }
  //      /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;I)LRedBlackBST<TKey;TValue;>.Node;")]*/

  //      private RedBlackBST.Node select(RedBlackBST.Node node, int num)
  //      {
  //          if (!RedBlackBST.s_assertionsDisabled && node == null)
  //          {

  //              throw new AssertionError();
  //          }
  //          if (!RedBlackBST.s_assertionsDisabled && (num < 0 || num >= this.size(node)))
  //          {

  //              throw new AssertionError();
  //          }
  //          int num2 = this.size(RedBlackBST.Node.access_300(node));
  //          if (num2 > num)
  //          {
  //              return this.select(RedBlackBST.Node.access_300(node), num);
  //          }
  //          if (num2 < num)
  //          {
  //              return this.select(RedBlackBST.Node.access_400(node), num - num2 - 1);
  //          }
  //          return node;
  //      }
  //      /*	[Signature("(TKey;LRedBlackBST<TKey;TValue;>.Node;)I")]*/

  //      private int rank(IComparable comparable, RedBlackBST.Node node)
  //      {
  //          if (node == null)
  //          {
  //              return 0;
  //          }
  //          int num = Comparable.__Helper.CompareTo(comparable, RedBlackBST.Node.access_200(node));
  //          if (num < 0)
  //          {
  //              return this.rank(comparable, RedBlackBST.Node.access_300(node));
  //          }
  //          if (num > 0)
  //          {
  //              return 1 + this.size(RedBlackBST.Node.access_300(node)) + this.rank(comparable, RedBlackBST.Node.access_400(node));
  //          }
  //          return this.size(RedBlackBST.Node.access_300(node));
  //      }
  //      /*	[Signature("()TKey;")]*/

  //      public virtual IComparable Min
  //      {
		//if (this.IsEmpty)

  //      {
  //              return null;
  //          }
		//return RedBlackBST.Node.access_200(this.min(this.root));
  //      }
  //      /*	[Signature("()TKey;")]*/

  //      public virtual IComparable Max
  //      {
		//if (this.IsEmpty)

  //      {
  //              return null;
  //          }
		//return RedBlackBST.Node.access_200(this.max(this.root));
  //      }
  //      /*	[Signature("(TKey;TKey;)Ljava/lang/Iterable<TKey;>;")]*/

  //      public virtual Iterable keys(IComparable c1, IComparable c2)
  //      {
  //          Queue queue = new Queue();
  //          this.keys(this.root, queue, c1, c2);
  //          return queue;
  //      }
  //      /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;LQueue<TKey;>;TKey;TKey;)V")]*/

  //      private void keys(RedBlackBST.Node node, Queue queue, IComparable comparable, IComparable comparable2)
  //      {
  //          if (node == null)
  //          {
  //              return;
  //          }
  //          int num = Comparable.__Helper.CompareTo(comparable, RedBlackBST.Node.access_200(node));
  //          int num2 = Comparable.__Helper.CompareTo(comparable2, RedBlackBST.Node.access_200(node));
  //          if (num < 0)
  //          {
  //              this.keys(RedBlackBST.Node.access_300(node), queue, comparable, comparable2);
  //          }
  //          if (num <= 0 && num2 >= 0)
  //          {
  //              queue.enqueue(RedBlackBST.Node.access_200(node));
  //          }
  //          if (num2 > 0)
  //          {
  //              this.keys(RedBlackBST.Node.access_400(node), queue, comparable, comparable2);
  //          }
  //      }
  //      /*	[LineNumberTable(419), Signature("(TKey;)I")]*/

  //      public virtual int rank(IComparable c)
  //      {
  //          return this.rank(c, this.root);
  //      }


  //      private bool isBST()
  //      {
  //          return this.isBST(this.root, null, null);
  //      }


  //      private bool isSizeConsistent()
  //      {
  //          return this.isSizeConsistent(this.root);
  //      }


  //      private bool isRankConsistent()
  //      {
  //          for (int i = 0; i < this.Size; i++)
  //          {
  //              if (i != this.rank(this.select(i)))
  //              {
  //                  return false;
  //              }
  //          }
  //          Iterator iterator = this.keys().iterator();
  //          while (iterator.hasNext())
  //          {
  //              IComparable comparable = (IComparable)iterator.next();
  //              if (Comparable.__Helper.CompareTo(comparable, this.select(this.rank(comparable))) != 0)
  //              {
  //                  return false;
  //              }
  //          }
  //          return true;
  //      }


  //      private bool Is23()
  //      {
  //          return this.Is23(this.root);
  //      }


  //      private bool IsBalanced
  //      {
  //          int num = 0;
  //          for (RedBlackBST.Node node = this.root; node != null; node = RedBlackBST.Node.access_300(node))
  //          {
  //              if (!this.isRed(node))
  //              {
  //                  num++;
  //              }
  //          }
  //          return this.isBalanced(this.root, num);
  //      }
  //      /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;TKey;TKey;)Z")]*/

  //      private bool isBST(RedBlackBST.Node node, IComparable comparable, IComparable comparable2)
  //      {
  //          return node == null || ((comparable == null || Comparable.__Helper.CompareTo(RedBlackBST.Node.access_200(node), comparable) > 0) && (comparable2 == null || Comparable.__Helper.CompareTo(RedBlackBST.Node.access_200(node), comparable2) < 0) && (this.isBST(RedBlackBST.Node.access_300(node), comparable, RedBlackBST.Node.access_200(node)) && this.isBST(RedBlackBST.Node.access_400(node), RedBlackBST.Node.access_200(node), comparable2)));
  //      }
  //      /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)Z")]*/

  //      private bool isSizeConsistent(RedBlackBST.Node node)
  //      {
  //          return node == null || (RedBlackBST.Node.access_100(node) == this.size(RedBlackBST.Node.access_300(node)) + this.size(RedBlackBST.Node.access_400(node)) + 1 && (this.isSizeConsistent(RedBlackBST.Node.access_300(node)) && this.isSizeConsistent(RedBlackBST.Node.access_400(node))));
  //      }
  //      /*	[Signature("(I)TKey;")]*/

  //      public virtual IComparable select(int i)
  //      {
  //          if (i < 0 || i >= this.Size)
  //          {
  //              return null;
  //          }
  //          RedBlackBST.Node node = this.select(this.root, i);
  //          return RedBlackBST.Node.access_200(node);
  //      }
  //      /*	[LineNumberTable(437), Signature("()Ljava/lang/Iterable<TKey;>;")]*/

  //      public virtual Iterable keys()
  //      {
  //          return this.keys(this.Min, this.Max);
  //      }
  //      /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;)Z")]*/

  //      private bool Is23(RedBlackBST.Node node)
  //      {
  //          return node == null || (!this.isRed(RedBlackBST.Node.access_400(node)) && (node == this.root || !this.isRed(node) || !this.isRed(RedBlackBST.Node.access_300(node))) && (this.Is23(RedBlackBST.Node.access_300(node)) && this.Is23(RedBlackBST.Node.access_400(node))));
  //      }
  //      /*	[Signature("(LRedBlackBST<TKey;TValue;>.Node;I)Z")]*/

  //      private bool isBalanced(RedBlackBST.Node node, int num)
  //      {
  //          if (node == null)
  //          {
  //              return num == 0;
  //          }
  //          if (!this.isRed(node))
  //          {
  //              num += -1;
  //          }
  //          return this.isBalanced(RedBlackBST.Node.access_300(node), num) && this.isBalanced(RedBlackBST.Node.access_400(node), num);
  //      }


  //      public RedBlackBST()
  //      {
  //      }
  //      /*	[Signature("(TKey;TValue;)V")]*/

  //      public virtual void put(IComparable c, object obj)
  //      {
  //          this.root = this.put(this.root, c, obj);
  //          RedBlackBST.Node.access_002(this.root, false);
  //          if (!RedBlackBST.s_assertionsDisabled && !this.check())
  //          {

  //              throw new AssertionError();
  //          }
  //      }


  //      public virtual void deleteMin()
  //      {
  //          if (this.IsEmpty)
  //          {
  //              string arg_12_0 = "BST underflow";

  //              throw new InvalidOperationException(arg_12_0);
  //          }
  //          if (!this.isRed(RedBlackBST.Node.access_300(this.root)) && !this.isRed(RedBlackBST.Node.access_400(this.root)))
  //          {
  //              RedBlackBST.Node.access_002(this.root, true);
  //          }
  //          this.root = this.deleteMin(this.root);
  //          if (!this.IsEmpty)
  //          {
  //              RedBlackBST.Node.access_002(this.root, false);
  //          }
  //          if (!RedBlackBST.s_assertionsDisabled && !this.check())
  //          {

  //              throw new AssertionError();
  //          }
  //      }


  //      public virtual void deleteMax()
  //      {
  //          if (this.IsEmpty)
  //          {
  //              string arg_12_0 = "BST underflow";

  //              throw new InvalidOperationException(arg_12_0);
  //          }
  //          if (!this.isRed(RedBlackBST.Node.access_300(this.root)) && !this.isRed(RedBlackBST.Node.access_400(this.root)))
  //          {
  //              RedBlackBST.Node.access_002(this.root, true);
  //          }
  //          this.root = this.deleteMax(this.root);
  //          if (!this.IsEmpty)
  //          {
  //              RedBlackBST.Node.access_002(this.root, false);
  //          }
  //          if (!RedBlackBST.s_assertionsDisabled && !this.check())
  //          {

  //              throw new AssertionError();
  //          }
  //      }
  //      /*	[Signature("(TKey;)V")]*/

  //      public virtual void delete(IComparable c)
  //      {
  //          if (!this.contains(c))
  //          {
  //              System.err.println(new StringBuilder().append("symbol table does not contain ").append(c).toString());
  //              return;
  //          }
  //          if (!this.isRed(RedBlackBST.Node.access_300(this.root)) && !this.isRed(RedBlackBST.Node.access_400(this.root)))
  //          {
  //              RedBlackBST.Node.access_002(this.root, true);
  //          }
  //          this.root = this.delete(this.root, c);
  //          if (!this.IsEmpty)
  //          {
  //              RedBlackBST.Node.access_002(this.root, false);
  //          }
  //          if (!RedBlackBST.s_assertionsDisabled && !this.check())
  //          {

  //              throw new AssertionError();
  //          }
  //      }


  //      public virtual int height()
  //      {
  //          return this.height(this.root);
  //      }
  //      /*	[Signature("(TKey;)TKey;")]*/

  //      public virtual IComparable floor(IComparable c)
  //      {
  //          RedBlackBST.Node node = this.floor(this.root, c);
  //          if (node == null)
  //          {
  //              return null;
  //          }
  //          return RedBlackBST.Node.access_200(node);
  //      }
  //      /*	[Signature("(TKey;)TKey;")]*/

  //      public virtual IComparable ceiling(IComparable c)
  //      {
  //          RedBlackBST.Node node = this.ceiling(this.root, c);
  //          if (node == null)
  //          {
  //              return null;
  //          }
  //          return RedBlackBST.Node.access_200(node);
  //      }
  //      /*	[Signature("(TKey;TKey;)I")]*/

  //      public virtual int size(IComparable c1, IComparable c2)
  //      {
  //          if (Comparable.__Helper.CompareTo(c1, c2) > 0)
  //          {
  //              return 0;
  //          }
  //          if (this.contains(c2))
  //          {
  //              return this.rank(c2) - this.rank(c1) + 1;
  //          }
  //          return this.rank(c2) - this.rank(c1);
  //      }


  //      /**/
  //      public static void main(string[] strarr)
  //      {
  //          RedBlackBST redBlackBST = new RedBlackBST();
  //          int num = 0;
  //          while (!StdIn.IsEmpty)
  //          {
  //              string text = StdIn.readString();
  //              redBlackBST.put(text, Integer.valueOf(num));
  //              num++;
  //          }
  //          Iterator iterator = redBlackBST.keys().iterator();
  //          while (iterator.hasNext())
  //          {
  //              string text = (string)iterator.next();
  //              StdOut.println(new StringBuilder().append(text).append(" ").append(redBlackBST.get(text)).toString());
  //          }
  //          StdOut.println();
  //      }

  //      static RedBlackBST()
  //      {
  //          RedBlackBST.s_assertionsDisabled = !ClassLiteral<RedBlackBST>.Value.desiredAssertionStatus();
  //      }
  //  }

}
