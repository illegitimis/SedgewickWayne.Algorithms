

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Runtime.CompilerServices;


    /// <summary>
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
    }

    public sealed class PathCompressionQUUF : QuickUnionUFBase
    {
        public PathCompressionQUUF(int n) : base(n) { }

        internal override FindImprovementStrategy FindImprovement { get { return FindImprovementStrategy.PathCompression; } }

        internal override UnionImprovementStrategy UnionImprovement { get { return UnionImprovementStrategy.None; } }
    }

    public sealed class HeightWeightedQUUF : QuickUnionUFBase
    {
        public HeightWeightedQUUF(int n) : base(n) { }

        internal override FindImprovementStrategy FindImprovement { get { return FindImprovementStrategy.None; } }

        internal override UnionImprovementStrategy UnionImprovement { get { return UnionImprovementStrategy.WeightingByHeight; } }
    }

    public sealed class SizeWeightedPathHalvingQUUF : QuickUnionUFBase
    {
        public SizeWeightedPathHalvingQUUF(int n) : base(n) { }

        internal override FindImprovementStrategy FindImprovement { get { return FindImprovementStrategy.PathSplittingOrHalving; } }

        internal override UnionImprovementStrategy UnionImprovement { get { return UnionImprovementStrategy.WeightingBySize; } }
    }

    public sealed class QuickUnionUF : QuickUnionUFBase
    {
        public QuickUnionUF(int n) : base(n) { }

        internal override FindImprovementStrategy FindImprovement { get { return FindImprovementStrategy.None; } }

        internal override UnionImprovementStrategy UnionImprovement { get { return UnionImprovementStrategy.None; } }
    }

}
