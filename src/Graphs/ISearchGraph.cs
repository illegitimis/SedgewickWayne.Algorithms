using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedgewickWayne.Algorithms.Graphs
{
    public interface ISearchGraph
    {
        /// <summary>
        /// is v connected to s?
        /// </summary>
        /// <param name="v">second vertex</param>
        bool Marked(int v);

        /// <summary>
        ///  how many vertices are connected to s?
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// reference vertex (from / either)
        /// </summary>
        int S { get; }
    }
}
