/**
 *  The {@code EagerPrimMST} class represents a data type for computing a
 *  minimum spanning tree in an edge-weighted graph.
 *  The edge weights can be positive, zero, or negative and need not
 *  be distinct. If the graph is not connected, it computes a minimum
 *  spanning forest, which is the union of minimum spanning trees
 *  in each connected component. The {@code weight()} method returns the 
 *  weight of a minimum spanning tree and the {@code edges()} method
 *  returns its edges.
 
 *  This implementation uses Prim's algorithm with an INDEXED BINARY HEAP.
 *  The constructor takes time proportional to E log V
 *  and extra space (not including the graph) proportional to V,
 *  where V is the number of vertices and E is the number of edges.
 *  Afterwards, the {@code weight()} method takes constant time
 *  and the {@code edges()} method takes time proportional to V.
 
 *  For additional documentation,
 *  see <a href="http://algs4.cs.princeton.edu/43mst">Section 4.3</a> of
 
 *  For alternate implementations, see {@link LazyEagerPrimMST}, {@link KruskalMST}, and {@link BoruvkaMST}.
 *
 

 *  
 * Eager implementation. 
 * To improve the lazy implementation of Prim's algorithm, we might try to DELETE 
 * INELIGIBLE EDGES FROM THE PRIORITY QUEUE, so that the priority queue contains 
 * only the crossing edges. But we can eliminate even more edges. 
 * The key is to note that our only interest is in the MINIMAL EDGE FROM EACH 
 * NON-TREE VERTEX TO A TREE VERTEX. When we add a vertex v to the tree, the only 
 * possible change with respect to each non-tree vertex w is that adding v 
 * brings w closer than before to the tree. 
 * In short, we do not need to keep on the priority queue all of the edges from w 
 * to vertices tree—we just need to keep track of the minimum-weight edge and check 
 * whether the addition of v to the tree necessitates that we update that minimum 
 * (because of an edge v-w that has lower weight), which we can do as we process 
 * each edge in s adjacency list. In other words, we maintain on the priority queue 
 * just one edge for each non-tree vertex: 
 * the shortest edge that connects it to the tree. 
 */

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Linq.Expressions;

    internal static class GenericOperators<T>
    {
        // https://jonskeet.uk/csharp/miscutil/usage/genericoperators.html
        public static T Add(T a, T b)
        {
            //TODO: re-use delegate!
            // declare the parameters
            ParameterExpression paramA = Expression.Parameter(typeof(T), "a"), paramB = Expression.Parameter(typeof(T), "b");
            // add the parameters together
            BinaryExpression body = Expression.Add(paramA, paramB);
            // compile it
            Func<T, T, T> add = Expression.Lambda<Func<T, T, T>>(body, paramA, paramB).Compile();
            // call it
            return add(a, b);
        }
    }
}