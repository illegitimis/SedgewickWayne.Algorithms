# Shortest Paths

> [4.4](https://algs4.cs.princeton.edu/44sp/) Shortest Paths

## implementation

Name | Princeton java link | .Net impl. | Misc
--- | --- | --- | ---
`IShortestPathAlgorithm<TWeight>` | x | [IShortestPathAlgorithm.cs] | `where TWeight : IComparable<TWeight>`
`BellmanFordSP<TWeight>` | [BellmanFordSP.java] | [BellmanFordSP.cs] | queue-based
`DjikstraSP<TWeight>` | [DjikstraSP.java] | [DjikstraSP.cs] | eager
FloydWarshall | - | -

## Performance characteristics of MST algorithms

algorithm | typical | worst case | restriction | sweet spot
--- | --- | --- | --- | ---
Dijkstra | E log V | E log V | positive weights | worst case guarantee
Bellman-Ford | E + V | E * V | no negative cycles | widely applicable
topological sort | E + V | E + V | edge weighted DAGs | optimal for acyclic

extra space is V for all.

[home](../README.md#pages)

[IShortestPathAlgorithm.cs]: ../src/ShortestPaths/IShortestPathAlgorithm.cs
[BellmanFordSP.cs]: ../src/ShortestPaths/BellmanFordSP.cs
[BellmanFordSP.java]: https://algs4.cs.princeton.edu/44sp/BellmanFordSP.java.html
[DjikstraSP.java]: https://algs4.cs.princeton.edu/44sp/DijkstraSP.java.html
[DjikstraSP.cs]: ../src/ShortestPaths/IShortestPathAlgorithm.cs