

namespace SedgewickWayne.Algorithms
{
    using System;
       
    
    /// <summary>
    /// There's no linear time algo for dynamic connectivity [Fredman-Saks].
    /// </summary>
    public abstract class UFBase : IUnionFind
    {
        /// <summary>
        /// array value at index is parent of component with index
        /// </summary>
        protected int[] id;
        public virtual int[] Ids { get { return this.id; } }

        /// <summary>
        /// number of components
        /// </summary>
        protected int count;
        public virtual int Count { get { return this.count; } }


        /// <summary>
        /// initialize union-find data structure with N objects(0 to N – 1)
        /// each entry equal to its index / each equal to itself. O(N)
        /// </summary>
        /// <param name="N"></param>
        
        //public UFBase(int N)
        //{
        //    if (N <= 0) throw new ArgumentException("N > 0");
        //    this.count = N;
        //    this.id = new int[N];
        //    for (int j = 0; j < N; this.id[j] = j++) ;
        //}
        
        /// <summary>
        /// are p and q in the same component?
        /// Reflexive/symmetric/transitive EQUIVALENCE relation
        /// </summary>
        /// <param name="p">first component index</param>
        /// <param name="q">second component index</param>
        /// <returns>Returns true if objects with indices are in the same connected component</returns>
        public abstract bool Connected(int p, int q);

        /// <summary>
        /// add connection between p and q
        /// Merges the component containing site <see cref="p"/> with the the component containing site <see cref="q"/>
        /// </summary>
        /// <param name="p">integer representing one site</param>
        /// <param name="q">integer representing the other site</param>
        public abstract void Union(int p, int q);

        /// <summary>
        /// component identifier for p(0 to N – 1)
        /// </summary>
        /// <param name="i">integer representing one object</param>
        /// <returns></returns>
        public abstract int Find(int i);
        
        /// <summary>
        /// validate that <see cref="p"/> is a valid index
        /// </summary>
        /// <param name="p">integer representing one site</param>
        protected void Validate(int p)
        {
            if (p < 0 || p >= id.Length)
            {
                //throw new IndexOutOfBoundsException("index " + p + " is not between 0 and " + (n - 1));
                throw new IndexOutOfRangeException("index " + p + " is not between 0 and " + (count - 1));
            }
        }
        
   
    }
    
}



