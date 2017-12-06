

namespace SedgewickWayne.Algorithms
{
    /// <summary>
    /// WeightedQuickUnionPathCompressionUF.java.
    /// The amortized cost per operation for this algorithm is known to be bounded by a function known as 
    /// the inverse Ackermann function and is less than 5 for any conceivable value of N that arises in practice. 
    /// 
    ///  This implementation uses weighted quick union by rank with path compression by halving.
    /// 
    /// WEIGHTED QUICK-UNION BY RANK WITH PATH COMPRESSION BY HALVING.
    /// WEIGHTED QUICK UNION (WITH PATH COMPRESSION) ???    
    /// 
    /// makes it possible to solve problems that 
    /// could not otherwise be addressed.
    /// Quick union with path compression. 
    /// 
    /// Just after computing the root of p, set the id of each examined node to point to that root
    /// Improvement is obvious: we always iterate to the root
    /// weighted QU + path compression: N + M lg* N
    /// QU + path compression: N + M log N
    /// M union find ops, N objects, worst case times above
    /// </summary>
    public sealed class UF : QuickUnionUFBase
    {
        public UF(int n) : base(n) { }

        internal override FindImprovementStrategy FindImprovement { get { return FindImprovementStrategy.PathSplittingOrHalving; } }

        internal override UnionImprovementStrategy UnionImprovement { get { return UnionImprovementStrategy.WeightingByRank; } }

        public byte[] Ranks { get { return base.rank; } }
    }

    /// <summary>
    /// QuickUnionPathCompressionUF.java
    /// This implementation uses quick union (no weighting) with full path compression. 
    /// Initializing a data structure with <em>n</em> sites takes linear time. 
    /// Afterwards, <em>union</em>, <em>find</em>, and<em> connected</em> take logarithmic amortized time. 
    /// <em>count</em> takes constant time.
    /// </summary>
    public sealed class PathCompressionQUUF : QuickUnionUFBase
    {
        public PathCompressionQUUF(int n) : base(n) { }

        internal override FindImprovementStrategy FindImprovement { get { return FindImprovementStrategy.PathCompression; } }

        internal override UnionImprovementStrategy UnionImprovement { get { return UnionImprovementStrategy.None; } }
    }

    /// <summary>
    /// WeightedQuickUnionByHeightUF.java 
    /// Weighted quick-union by height. 
    /// Same basic strategy as weighted quick-union but keeps track of tree height and always links the shorter tree to the taller one. 
    /// Prove a logarithmic upper bound on the height of the trees for N sites with your algorithm. 
    /// A union operation between elements in different trees either leaves the height unchanged (if the two tree have different heights) 
    /// or increase the height Noteby one (if the two tree are the same height). 
    /// You can prove by induction that that the size of the tree is at least 2^height. 
    /// Therefore, the height can increase at most lg N times. 
    /// </summary>
    public sealed class HeightWeightedQUUF : QuickUnionUFBase
    {
        public HeightWeightedQUUF(int n) : base(n) { }

        internal override FindImprovementStrategy FindImprovement { get { return FindImprovementStrategy.None; } }

        internal override UnionImprovementStrategy UnionImprovement { get { return UnionImprovementStrategy.WeightingByHeight; } }
    }

    /// <summary>
    /// TODO: WeightedQuickUnionUF - weighted quick union by size (without path compression).
    /// WeightedQuickUnionPathCompressionUF.java 
    /// </summary>
    public sealed class SizeWeightedPathHalvingQUUF : QuickUnionUFBase
    {
        public SizeWeightedPathHalvingQUUF(int n) : base(n) { }

        internal override FindImprovementStrategy FindImprovement { get { return FindImprovementStrategy.PathSplittingOrHalving; } }

        internal override UnionImprovementStrategy UnionImprovement { get { return UnionImprovementStrategy.WeightingBySize; } }

        public int[] Sizes { get { return base.size; } }
    }

    public sealed class QuickUnionUF : QuickUnionUFBase
    {
        public QuickUnionUF(int n) : base(n) { }

        internal override FindImprovementStrategy FindImprovement { get { return FindImprovementStrategy.None; } }

        internal override UnionImprovementStrategy UnionImprovement { get { return UnionImprovementStrategy.None; } }
    }

}
