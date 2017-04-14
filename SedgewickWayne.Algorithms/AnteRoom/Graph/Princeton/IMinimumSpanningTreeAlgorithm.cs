
namespace Graph.Princeton
{
  using System.Collections.Generic;

  public interface IMinimumSpanningTreeAlgorithm
  {
    IEnumerable<Edge> Edges { get; }
    double Weight { get; }
  }
}
