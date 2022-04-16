# Minimum Spanning Trees

> Section [4.3](http://algs4.cs.princeton.edu/43mst) documentation \
> Compute a minimum spanning forest  

## implementation

Name | Princeton java link | .Net impl. | Misc
--- | --- | --- | ---
`IMinimumSpanningTreeAlgorithm<TWeight>` | x | [IMinimumSpanningTreeAlgorithm.cs] | `IMinimumSpanningTreeAlgorithm<TWeight> where TWeight : IComparable<TWeight>`
`LazyPrimMST<TWeight>` | [LazyPrimMST.java] | [LazyPrimMST.cs] | lazy version of Prim's algorithm with a BINARY HEAP OF EDGES
`EagerPrimMST<TWeight>` | [PrimMST.java] | [EagerPrimMST.cs] | array of shortest edges from tree vertex to non-tree vertex, distTo weights of shortest such edges
KruskalMST | [KruskalMST.java] | [KruskalMST.cs]
BoruvkaMST | - | -

## Performance characteristics of MST algorithms

> worst-case order of growth for V vertices and E edges

algorithm | space | time
---|---|---
lazy Prim |E | E log E
eager Prim | V | E log V 
Kruskal | E | E log E
Fredman-Tarjan |V | E + V log V
Chazelle | V | very, very nearly, but not quite E
impossible ? | V | E ? 

[home](../README.md#pages)

[IMinimumSpanningTreeAlgorithm.cs]: ../src/MinimumSpanningTrees/IMinimumSpanningTreeAlgorithm.cs
[LazyPrimMST.cs]: ../src/MinimumSpanningTrees/LazyPrimMST.cs
[LazyPrimMST.java]: https://algs4.cs.princeton.edu/43mst/LazyPrimMST.java.html
[PrimMST.java]: https://algs4.cs.princeton.edu/43mst/PrimMST.java.html
[EagerPrimMST.cs]: ../src/MinimumSpanningTrees/EagerPrimMST.cs
[KruskalMST.java]: https://algs4.cs.princeton.edu/43mst/KruskalMST.java.html
[KruskalMST.cs]: ../src/MinimumSpanningTrees/KruskalMST.cs