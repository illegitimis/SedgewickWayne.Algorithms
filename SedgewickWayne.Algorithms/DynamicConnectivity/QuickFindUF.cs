

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// eager
    /// Defect: union is too expensive, N array accesses
    /// Trees are flat, too expesnive to keep them flat
    /// http://algs4.cs.princeton.edu/15uf/QuickFindUF.java
    /// There aren't any performance improvements on QF, 
    /// QF alternatives deriving out of 
    /// </summary>
    public sealed class QuickFindUF : UFBase
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public QuickFindUF(int N)
        //: base(N) 
        {
            if (N <= 0) throw new ArgumentException("N > 0");
            this.count = N;
            this.id = new int[N];
            for (int j = 0; j < N; this.id[j] = j++) ;
        }

        /// <summary>
        /// Union. To merge components containing p and q, change all entries whose id equals id[p] to id[q].
        /// Defect: union too expensive, O(N)
        /// quadratic, N objects with N union commands, N^2 array accesses
        /// </summary>
        /// <param name="p">first component</param>
        /// <param name="q">second component</param>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override void Union(int p, int q)
        {
            Validate(p);
            Validate(q);

            // nothing to do if already connected
            // p and q are already in the same component
            if (this.Connected(p, q)) return;

            // needed for correctness
            int pid = this.id[p];

            // to reduce the number of array accesses
            int qid = this.id[q];

            for (int i = 0; i < this.id.Length; i++)
            {
                if (this.id[i] == pid)
                {
                    this.id[i] = qid;
                }
            }

            // decrease component count
            this.count--;
        }

        /// <summary>
        /// Find: constant, array index O(1)
        /// </summary>
        /// <param name="p">component index</param>
        /// <returns>the component identifier for the component containing site p</returns>
        public override int Find(int p)
        {
            Validate(p);
            return id[p];
        }

        /// <summary>
        /// p & q are connected  if they have the same id, id[p] == id[q]
        /// 2 array indices
        /// </summary>
        public override bool Connected(int p, int q)
        {
            Validate(p);
            Validate(q);
            return this.id[p] == this.id[q];
        }
        
    }
}
