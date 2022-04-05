# Sorting

> § [2.1](https://algs4.cs.princeton.edu/21elementary/) Elementary Sorts. \
> Algorithms and Data Structures [Cheatsheet](https://algs4.cs.princeton.edu/cheatsheet/) \
> The Analysis of Heapsort [paper](https://algs4.cs.princeton.edu/references/papers/heapsort-sedgewick.pdf)

## implementation

Name | Princeton java link | .Net impl. | Misc
--- | --- | --- | ---
BinaryInsertion | [BinaryInsertion.java] | [BinaryInsertion.cs] | `BinaryInsertion<T> where T : IComparable<T>`
Heap | [Heap.java] | [Heap.cs] | _heapsort_, not the data structure 
Insertion | [Insertion.java] | [Insertion.cs]
InsertionPedantic | [InsertionPedantic.java] | [InsertionT.cs] | `Insertion<T>`
InsertionX | [InsertionX.java] | [InsertionX.cs] | optimized version of insertion sort that uses half exchanges to reduce data movement..
Merge | [Merge.java] | [Merge.cs] | mergesort
MergeBU | [MergeBU.java] | [MergeBU.cs] | BOTTOM-UP MERGESORT
MergeX  | [MergeX.java] | [MergeX.cs] | optimized merge sort `MergeX<T> where T : IComparable<T>`
Quick | [Quick.java] | [Quick.cs]
Quick3Way | [Quick3way.java] | [Quick3Way.cs]
QuickX | [QuickX.java] | [QuickX.cs]
Selection | [Selection.java] | [Selection.cs]
Shell | [Shell.java] | [Shell.cs]

## performance

... | inplace? | stable? | best | average | worst | remarks
--- | --- | --- | --- | --- | --- | --- 
selection | Y | N | n^2/2 | n^2/2 | n^2/2 | _n_ exchanges
insertion | Y | Y | `n` | n^2/4 | n^2/2 | use for small _n_, or partially ordered 
shell | Y | N | nlog3n | ? | cn^3/2 | tight code; subquadratic
merge | N | Y | nlogn/2 | nlgn | nlgn | `n*log(n)` guarantee, _stable_
timsort | N | Y | n | nlgn | nlgn| improves mergesort when preexisting order
quick | Y | N | nlgn | 2nlnn | ½n^2 | `n*log(n)` _probabilistic_ guarantee, **fastest** in practice
3-way quick | Y | N | `n` | 2nlnn | ½n^2 | improves quicksort when duplicate keys
heap | Y | N | 3n | 2nlgn | 2nlgn |  `n*log(n)` guarantee, _in place_, best `n` if keys distinct?
not yet | Y | Y  | `n` | nlgn | nlgn | holy sorting grail

[home](../README.md#pages)

[BinaryInsertion.java]: http://algs4.cs.princeton.edu/21elementary/BinaryInsertion.java.html
[BinaryInsertion.cs]: ../src/Sorting/BinaryInsertion.cs
[Heap.java]: http://algs4.cs.princeton.edu/24pq/Heap.java.html
[Heap.cs]: ../src/Sorting/Heap.cs
[Insertion.java]: http://algs4.cs.princeton.edu/21elementary/Insertion.java
[Insertion.cs]: ../src/Sorting/Insertion.cs
[InsertionPedantic.java]: http://algs4.cs.princeton.edu/21elementary/InsertionPedantic.java.html
[InsertionT.cs]: ../src/Sorting/InsertionT.cs
[InsertionX.java]: http://algs4.cs.princeton.edu/21elementary/InsertionX.java.html
[InsertionX.cs]: ../src/Sorting/InsertionX.cs
[Merge.java]: http://algs4.cs.princeton.edu/22mergesort/Merge.java.html
[Merge.cs]: ../src/Sorting/Merge.cs
[MergeBU.java]: http://algs4.cs.princeton.edu/22mergesort/MergeBU.java.html
[MergeBU.cs]: ../src/Sorting/MergeBU.cs
[MergeX.cs]: ../src/Sorting/MergeX.cs
[MergeX.java]: http://algs4.cs.princeton.edu/22mergesort/MergeX.java.html
[Quick.java]: http://algs4.cs.princeton.edu/23quicksort/Quick.java.html
[Quick.cs]: ../src/Sorting/Quick.cs
[Quick3way.java]: http://algs4.cs.princeton.edu/23quicksort/Quick3way.java.html
[Quick3Way.cs]: ../src/Sorting/Quick3Way.cs
[QuickX.java]: http://algs4.cs.princeton.edu/23quicksort/QuickX.java.html
[QuickX.cs]: ../src/Sorting/QuickX.cs
[Selection.java]: http://algs4.cs.princeton.edu/21elementary/Selection.java.html
[Selection.cs]: ../src/Sorting/Selection.cs
[Shell.java]: http://algs4.cs.princeton.edu/21elementary/Shell.java.html
[Shell.cs]: ../src/Sorting/Shell.cs