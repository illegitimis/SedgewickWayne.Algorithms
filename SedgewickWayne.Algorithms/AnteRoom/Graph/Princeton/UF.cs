
namespace Graph.Princeton
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
  

/******************************************************************************
 *  Compilation:  javac UF.java
 *  Execution:    java UF < input.txt
 *  Data files:   http://algs4.cs.princeton.edu/15uf/tinyUF.txt
 *                http://algs4.cs.princeton.edu/15uf/mediumUF.txt
 *                http://algs4.cs.princeton.edu/15uf/largeUF.txt
 *
 *  Weighted quick-union by rank with path compression by halving.
 *
 *  % java UF < tinyUF.txt
 *  4 3
 *  3 8
 *  6 5
 *  9 4
 *  2 1
 *  5 0
 *  7 2
 *  6 1
 *  2 components
 *
 ******************************************************************************/


/**
 *  The {@code UF} class represents a <em>union–Find data type</em>
 *  (also known as the <em>disjoint-sets data type</em>).
 *  It supports the <em>union</em> and <em>Find</em> operations,
 *  along with a <em>connected</em> operation for determining whether
 *  two sites are in the same component and a <em>Count</em> operation that
 *  returns the total number of components.
 *  <p>
 *  The union–Find data type models connectivity among a set of <em>n</em>
 *  sites, named 0 through <em>n</em>&minus;1.
 *  The <em>is-connected-to</em> relation must be an 
 *  <em>equivalence relation</em>:
 *  <ul>
 *  <li> <em>Reflexive</em>: <em>p</em> is connected to <em>p</em>.
 *  <li> <em>Symmetric</em>: If <em>p</em> is connected to <em>q</em>,
 *       then <em>q</em> is connected to <em>p</em>.
 *  <li> <em>Transitive</em>: If <em>p</em> is connected to <em>q</em>
 *       and <em>q</em> is connected to <em>r</em>, then
 *       <em>p</em> is connected to <em>r</em>.
 *  </ul>
 *  <p>
 *  An equivalence relation partitions the sites into
 *  <em>equivalence classes</em> (or <em>components</em>). In this case,
 *  two sites are in the same component if and only if they are connected.
 *  Both sites and components are identified with integers between 0 and
 *  <em>n</em>&minus;1. 
 *  Initially, there are <em>n</em> components, with each site in its
 *  own component.  The <em>component identifier</em> of a component
 *  (also known as the <em>root</em>, <em>canonical element</em>, <em>leader</em>,
 *  or <em>set representative</em>) is one of the sites in the component:
 *  two sites have the same component identifier if and only if they are
 *  in the same component.
 *  <ul>
 *  <li><em>union</em>(<em>p</em>, <em>q</em>) adds a connection between 
 *      the two sites <em>p</em> and <em>q</em>. If <em>p</em> and <em>q</em> 
 *      are in different components, then it replaces these two components 
 *      with a new component that is the union of the two.
 *  <li><em>Find</em>(<em>p</em>) returns the component
 *      identifier of the component containing <em>p</em>.
 *  <li><em>connected</em>(<em>p</em>, <em>q</em>)
 *      returns true if both <em>p</em> and <em>q</em>
 *      are in the same component, and false otherwise.
 *  <li><em>Count</em>() returns the number of components.
 *  </ul>
 *  <p>
 *  The component identifier of a component can change
 *  only when the component itself changes during a call to
 *  <em>union</em>—it cannot change during a call
 *  to <em>Find</em>, <em>connected</em>, or <em>Count</em>.
 *  <p>
 *  This implementation uses WEIGHTED QUICK UNION BY RANK WITH PATH COMPRESSION BY HALVING.
 *  Initializing a data structure with <em>n</em> sites takes linear time.
 *  Afterwards, the <em>union</em>, <em>Find</em>, and <em>connected</em> 
 *  operations take logarithmic time (in the worst case) and the
 *  <em>Count</em> operation takes constant time.
 *  Moreover, the amortized time per <em>union</em>, <em>Find</em>,
 *  and <em>connected</em> operation has inverse Ackermann complexity.
 *  For alternate implementations of the same API, see
 *  {@link QuickUnionUF}, {@link QuickFindUF}, and {@link WeightedQuickUnionUF}.
 *
 *  <p>
 *  For additional documentation, see <a href="http://algs4.cs.princeton.edu/15uf">Section 1.5</a> of
 *  <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.
 *
 *  @author Robert Sedgewick
 *  @author Kevin Wayne
 */

  public class UF
  {

    private int[] parent;  // parent[i] = parent of i
    private byte[] rank;   // rank[i] = rank of subtree rooted at i (never more than 31)
    
    /**
     * Initializes an empty union–Find data structure with {@code n} sites {@code 0} 
     * through {@code n-1}. Each site is initially in its own component.
     *
     * @param  n the number of sites
     * @throws ArgumentException if {@code n < 0}
     */
    public UF (int n)
    {
      if (n < 0) throw new ArgumentException();
      Count = n;
      parent = new int[n];
      rank = new byte[n];
      for (int i = 0; i < n; i++)
      {
        parent[i] = i;
        rank[i] = 0;
      }
    }

    /**
     * Returns the component identifier for the component containing site {@code p}.
     *
     * @param  p the integer representing one site
     * @return the component identifier for the component containing site {@code p}
     * @throws IndexOutOfBoundsException unless {@code 0 <= p < n}
     */
    public int find (int p)
    {
      validate(p);
      while (p != parent[p])
      {
        parent[p] = parent[parent[p]];    // path compression by halving
        p = parent[p];
      }
      return p;
    }

    /**
     * Returns the number of components.
     *
     * @return the number of components (between {@code 1} and {@code n})
     */
    public int Count { get; private set; }

    /**
     * Returns true if the the two sites are in the same component.
     *
     * @param  p the integer representing one site
     * @param  q the integer representing the other site
     * @return {@code true} if the two sites {@code p} and {@code q} are in the same component;
     *         {@code false} otherwise
     * @throws IndexOutOfBoundsException unless
     *         both {@code 0 <= p < n} and {@code 0 <= q < n}
     */
    public bool connected (int p, int q)
    {
      return find(p) == find(q);
    }

    /**
     * Merges the component containing site {@code p} with the 
     * the component containing site {@code q}.
     *
     * @param  p the integer representing one site
     * @param  q the integer representing the other site
     * @throws IndexOutOfBoundsException unless
     *         both {@code 0 <= p < n} and {@code 0 <= q < n}
     */
    public void union (int p, int q)
    {
      int rootP = find(p);
      int rootQ = find(q);
      if (rootP == rootQ) return;

      // make root of smaller rank point to root of larger rank
      if (rank[rootP] < rank[rootQ]) parent[rootP] = rootQ;
      else if (rank[rootP] > rank[rootQ]) parent[rootQ] = rootP;
      else
      {
        parent[rootQ] = rootP;
        rank[rootP]++;
      }
      Count--;
    }

    // validate that p is a valid index
    private void validate (int p)
    {
      int n = parent.Length;
      if (p < 0 || p >= n)
      {
        throw new ArgumentOutOfRangeException("index " + p + " is not between 0 and " + (n - 1));
      }
    }

  }
}

