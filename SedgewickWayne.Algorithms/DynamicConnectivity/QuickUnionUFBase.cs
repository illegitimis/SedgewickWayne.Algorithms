

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// [lazy approach] avoid doing work until we have to set of trees(forest).
    /// id array is parent/root of the component tree
    /// Defect: trees can get tall, and find is too expensive
    /// worst: M*N, same as quick find
    /// </summary>
   
    internal enum FindImprovementStrategy { None, PathCompression, PathSplittingOrHalving }

    internal enum UnionImprovementStrategy { None, WeightingBySize, WeightingByHeight, WeightingByRank }

    /// <summary>
    /// This implementation uses quick union.
    /// </summary>
    public abstract class QuickUnionUFBase : UFBase
    {
        #region commonality / variance

        /// <summary>
        /// return the component identifier for the component containing site <see cref="p"/>
        /// </summary>
        /// <remarks>
        /// 1) WeightedQuickUnionByHeightUF FIND is QUFind
        /// 2) WeightedQuickUnionUF FIND is QUFind (Weighted quick-union (without path compression))
        /// id becomes id of parent, loop till the root, moving from child to parent
        /// </remarks>
        /// <param name="p">integer representing one object</param>
        /// <returns>component identifier</returns>
        protected int QUFind(int p)
        {
            Validate(p);
            while (p != id[p]) p = id[p];
            return p;
        }

        /// <summary>
        /// FIND WITH Quick-union with path compression (but no weighting by size or rank).
        /// </summary>
        /// <remarks>
        /// 1) WeightedQuickUnionPathCompressionUF == WSPCQUFind
        /// </remarks>
        /// <param name="p">integer representing one site</param>
        /// <returns></returns>
        protected int PCQUFind(int p)
        {
            int root = p;
            while (root != id[root]) root = id[root];

            while (p != root)
            {
                int newp = id[p];
                id[p] = root;
                p = newp;
            }
            return root;
        }

        // path compression by halving
        // Weighted quick-union with path splitting.
        // WeightedQuickUnionPathHalvingUF
        // UF FIND is PHQUFind
        protected int PHQUFind(int p)
        {
            Validate(p);
            while (p != id[p])
            {
                // Make every other node in path point to its grandparent(thereby halving path length).
                // only one line of code, keeps tree almost flat
                // sole difference from WeightedQuickUnionUF
                // path compression !
                id[p] = id[id[p]];
                p = id[p];
            }
            return p;
        }

        /// <summary>
        /// Merges the component containing site {@code p} with the the component containing site {@code q}
        /// </summary>
        /// <remarks>
        /// 1) QuickUnionPathCompressionUF union is QUUnion
        /// 2) 
        /// </remarks>
        /// <param name="p">integer representing one site</param>
        /// <param name="q">integer representing the other site</param>
        protected void QUUnion(int p, int q)
        {
            int rootP = Find(p);
            int rootQ = Find(q);

            //already connected
            if (rootP == rootQ) return;

            id[rootP] = rootQ;
            count--;
        }

    // size[i] = number of sites in tree rooted at i
    // Note: not necessarily correct if i is not a root node
    // The size of a tree is its number of nodes. The depth of a node in a tree is the number of links on the path from it to the root. The height of a tree is the maximum depth among its nodes. 
    protected int[] size;

        /// <summary>
        /// WeightedQuickUnionPathCompressionUF UNION is WSQUUnion
        /// WeightedQuickUnionUF UNION is WSQUUNION (Weighted quick-union (without path compression))
        /// </summary>    
        /// <remarks>
        /// Depth of any node x is at most lg N. 
        /// lg = base-2 logarithm 
        /// merge smth smaller into smth larger, size at most doubles, depth++
        /// Even if Find the same with QU, becomes lgN from weighting
        /// 
        /// modify QU to avoid tall trees 
        /// always avoid putting the larger tree lower
        /// balance by linking root of smaller tree to root of taller tree
        /// average distance to the root much smaller than not weighted
        /// Find. Identical to quick-union. 
        /// connected: proportional to depths of p and q
        /// weighted QU: N + M log N
        /// worst case for N objects and M unions
        /// WQU by size
        /// </remarks>
        /// <param name="p"></param>
        /// <param name="q"></param>
        protected void WSQUUnion(int p, int q)
        {
            int rootP = Find(p);
            int rootQ = Find(q);
            if (rootP == rootQ) return;

            // make smaller root point to larger one
            if (size[rootP] < size[rootQ])
            {
                id[rootP] = rootQ;
                size[rootQ] += size[rootP];
            }
            else
            {
                id[rootQ] = rootP;
                size[rootP] += size[rootQ];
            }
            count--;
        }


        // height[i] = height of subtree rooted at i
        private int[] height;

        /// <summary>
        /// Weighted quick-union by height (instead of by size).
        /// </summary>        
        protected void WHQUUnion(int p, int q)
        {
            int i = Find(p);
            int j = Find(q);
            if (i == j) return;

            // make shorter root point to taller one
            if (height[i] < height[j]) id[i] = j;
            else if (height[i] > height[j]) id[j] = i;
            else
            {
                id[j] = i;
                height[i]++;
            }
            count--;
        }

        // rank[i] = rank of subtree rooted at i (never more than 31)
        protected byte[] rank;
        protected void WRQUUnion(int p, int q)
        {
            int rootP = Find(p);
            int rootQ = Find(q);
            if (rootP == rootQ) return;

            // make root of smaller rank point to root of larger rank
            if (rank[rootP] < rank[rootQ]) id[rootP] = rootQ;
            else if (rank[rootP] > rank[rootQ]) id[rootQ] = rootP;
            else
            {
                id[rootQ] = rootP;
                rank[rootP]++;
            }
            count--;
        }

        #endregion

        #region abstract

        internal abstract FindImprovementStrategy FindImprovement { get; }
        internal abstract UnionImprovementStrategy UnionImprovement { get; }

        #endregion

       [MethodImpl(MethodImplOptions.NoInlining)]
        public QuickUnionUFBase(int N)
        {
            if (N <= 0) throw new ArgumentException("N > 0");
            this.count = N;
            this.id = new int[N];

            this.rank = new byte[N];
            this.size = new int[N];
            this.height = new int[N];

            for (int j = 0; j < N; j++)
            {
                this.id[j] = j;
                this.rank[j] = 0;
                this.size[j] = 1;
                this.height[j] = 0;
            }
        }

        /// <summary>
        /// check p and q have same root
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override bool Connected(int p, int q)
        {
            return this.Find(p) == this.Find(q);
        }
        
        /// <summary>
        /// set the id of p's root to the id of q's root
        /// (depth of p and q array accesses)
        /// only one value changes
        /// q becomes the root of p
        /// N'- cost of finding roots
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override void Union(int p, int q)
        {
            switch (UnionImprovement)
            {
                default:
                case UnionImprovementStrategy.None: QUUnion(p, q); break;

                case UnionImprovementStrategy.WeightingBySize: WSQUUnion(p, q); break;

                case UnionImprovementStrategy.WeightingByHeight: WHQUUnion(p, q); break;

                case UnionImprovementStrategy.WeightingByRank: WRQUUnion(p, q); break;
            }

        }

        /// <summary>
        /// keep going until it doesn’t change (algorithm ensures no cycles)
        /// chase parent pointers until reach root (depth of i array accesses)
        /// N worst case
        /// </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override int Find(int i)
        {
            switch (FindImprovement)
            {
                default:
                case FindImprovementStrategy.None: return QUFind(i);                    

                case FindImprovementStrategy.PathCompression: return PCQUFind(i);

                case FindImprovementStrategy.PathSplittingOrHalving:return PHQUFind(i);                    
            }
        }

    } 

}
