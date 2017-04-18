
namespace SedgewickWayne.Algorithms
{
  using System.Collections.Generic;

  public interface IMinimumSpanningTreeAlgorithm
  {
    IEnumerable<Edge> Edges { get; }
    double Weight { get; }
  }
}
