
    /******************************************************************************
     *  SequentialSearchST.java
     *  Below is the syntax highlighted version of SequentialSearchST.java from §3.1 Elementary Symbol Tables. 
     *  
     *  Symbol table implementation with sequential search in an unordered linked list of key-value pairs.
     *  
     *    Copyright © 2000–2016, Robert Sedgewick and Kevin Wayne. 
     *    Last updated: Wed Nov 2 05:20:57 EDT 2016.
     *
     * Data files:   http://algs4.cs.princeton.edu/31elementary/tinyST.txt  
     *  % more tinyST.txt
     *  S E A R C H E X A M P L E
     *
     *  % java SequentialSearchST < tiny.txt 
     *  L 11
     *  P 10
     *  M 9
     *  X 7
     *  H 5
     *  C 4
     *  R 3
     *  A 8
     *  E 12
     *  S 0
     *
     ******************************************************************************/

namespace SedgewickWayne.Algorithms
{

    using System;
    using System.Collections;
    using System.Collections.Generic;

    /**
     *  The {@code SequentialSearchST} class represents an (unordered)
     *  symbol table of generic key-value pairs.
     *  It supports the usual <em>put</em>, <em>get</em>, <em>contains</em>,
     *  <em>delete</em>, <em>size</em>, and <em>is-empty</em> methods.
     *  It also provides a <em>keys</em> method for iterating over all of the keys.
     *  A symbol table implements the <em>associative array</em> abstraction:
     *  when associating a value with a key that is already in the symbol table,
     *  the convention is to replace the old value with the new value.
     *  The class also uses the convention that values cannot be {@code null}. Setting the
     *  value associated with a key to {@code null} is equivalent to deleting the key
     *  from the symbol table.
     *  <p>
     *  This implementation uses a singly-linked list and sequential search.
     *  It relies on the {@code equals()} method to test whether two keys
     *  are equal. It does not call either the {@code compareTo()} or
     *  {@code hashCode()} method. 
     *  The <em>put</em> and <em>delete</em> operations take linear time; the
     *  <em>get</em> and <em>contains</em> operations takes linear time in the worst case.
     *  The <em>size</em>, and <em>is-empty</em> operations take constant time.
     *  Construction takes constant time.
     *  <p>
     *  For additional documentation, see <a href="http://algs4.cs.princeton.edu/31elementary">Section 3.1</a> of
     *  <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.
     *
     *  @author Robert Sedgewick
     *  @author Kevin Wayne
     */
    public class SequentialSearchST<Key, Value> 
        : ISymbolTable<Key, Value>
        where Key : IComparable<Key>, IEquatable<Key>
    {
        private int n;           // number of key-value pairs
        private Node first;      // the linked list of key-value pairs

        /* Returns the number of key-value pairs in this symbol table. */
        public int Size
        {
            get
            {
                return n;
            }
        }

        /* Returns true if this symbol table is empty. */
        public bool IsEmpty
        {
            get
            {
                return n == 0;
            }
        }

        // a helper linked list data type
        class Node
        {
            internal Key key;
            internal Value val;
            internal Node next;

            public Node(Key key, Value val, Node next)
            {
                this.key = key;
                this.val = val;
                this.next = next;
            }
        }

        /**
         * Initializes an empty symbol table.
         */
        public SequentialSearchST() { }

        /**
         * Returns true if this symbol table contains the specified key.
         *
         * @param  key the key
         * @return {@code true} if this symbol table contains {@code key};
         *         {@code false} otherwise
         * @throws ArgumentNullException if {@code key} is {@code null}
         */
        public bool Contains(Key key)
        {
            if (key == null) throw new ArgumentNullException("argument to contains() is null");
            return Get(key) != null;
        }

        /**
         * Returns all keys in the symbol table as an {@code Iterable}.
         * To iterate over all of the keys in the symbol table named {@code st},
         * use the foreach notation: {@code for (Key key : st.keys())}.
         *
         * @return all keys in the symbol table
         */
        public IEnumerable<Key> Keys()
        {
            Queue<Key> queue = new Queue<Key>();
            for (Node x = first; x != null; x = x.next)
                queue.Enqueue(x.key);
            return queue;
        }


        /**
     * Returns the value associated with the given key in this symbol table.
     *
     * @param  key the key
     * @return the value associated with the given key if the key is in the symbol table
     *     and {@code null} if the key is not in the symbol table
     * @throws ArgumentNullException if {@code key} is {@code null}
     */
        public Value Get(Key key)
        {
            if (key == null) throw new ArgumentNullException("argument to get() is null");
            for (Node x = first; x != null; x = x.next)
            {
                if (key.Equals(x.key))
                    return x.val;
            }
            return default(Value);
        }


        /**
       * Inserts the specified key-value pair into the symbol table, overwriting the old 
       * value with the new value if the symbol table already contains the specified key.
       * Deletes the specified key (and its associated value) from this symbol table
       * if the specified value is {@code null}.
       *
       * @param  key the key
       * @param  val the value
       * @throws ArgumentNullException if {@code key} is {@code null}
       */
        public void Put(Key key, Value val)
        {
            if (key == null) throw new ArgumentNullException("first argument to put() is null");
            if (val == null)
            {
                Delete(key);
                return;
            }

            for (Node x = first; x != null; x = x.next)
            {
                if (key.Equals(x.key))
                {
                    x.val = val;
                    return;
                }
            }
            first = new Node(key, val, first);
            n++;
        }

        /**
       * Removes the specified key and its associated value from this symbol table     
       * (if the key is in this symbol table).    
       *
       * @param  key the key
       * @throws ArgumentNullException if {@code key} is {@code null}
       */
        public void Delete(Key key)
        {
            if (key == null) throw new ArgumentNullException("argument to delete() is null");
            first = Delete(first, key);
        }

        // delete key in linked list beginning at Node x
        // warning: function call stack too large if table is large
        private Node Delete(Node x, Key key)
        {
            if (x == null) return null;
            if (key.Equals(x.key))
            {
                n--;
                return x.next;
            }
            x.next = Delete(x.next, key);
            return x;
        }

        public IEnumerator<Key> GetEnumerator()
        {
            return Keys().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Keys().GetEnumerator();
        }
    }

}
