namespace SedgewickWayne.Algorithms.DynamicConnectivity
{
    /// <summary>
    /// This implementation uses weighted quick union by rank with path compression by halving.
    /// WeightedQuickUnionPathHalvingUF
    /// WEIGHTED QUICK-UNION BY RANK WITH PATH COMPRESSION BY HALVING.
    /// 
    /// Just after computing the root of p, set the id of each examined node to point to that root
    /// Improvement is obvious: we always iterate to the root
    /// weighted QU + path compression: N + M lg* N
    /// QU + path compression: N + M log N
    /// M union find ops, N objects, worst case times above
    /// </summary>
    /// <see href="https://algs4.cs.princeton.edu/15uf/UF.java.html"/>
    public sealed class UF : QuickUnionUF
    {
        public UF(int N) : base(N)
        {
            this.rank = new byte[N];
            for (int j = 0; j < N; j++) this.rank[j] = 0;
        }

        // rank[i] = rank of subtree rooted at i (never more than 31)
        readonly byte[] rank;

        /// <summary>
        /// Seems to be the same thing as weighting by height in <see cref="WeightedQuickUnionByHeightUF"/>?
        /// </summary>
        public byte[] Ranks { get { return rank; } }

        public override void Union(int p, int q)
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

        /// <summary>
        /// path compression by halving
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public override int Find(int p)
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

    }

}
