# Sorting

Cheatsheet: https://algs4.cs.princeton.edu/cheatsheet/

The Analysis of Heapsort: https://algs4.cs.princeton.edu/references/papers/heapsort-sedgewick.pdf



## implementation

Name | Princeton java link | .Net impl./Misc
--- | --- | --- | ---
BinaryInsertion | [BinaryInsertion.java](http://algs4.cs.princeton.edu/21elementary/BinaryInsertion.java.html) | [BinaryInsertion.cs](../src/Sorting/BinaryInsertion.cs), `BinaryInsertion<T> where T : IComparable<T>`
Heap | [Heap.java](http://algs4.cs.princeton.edu/24pq/Heap.java.html) | [Heap.cs](../src/Sorting/Heap.cs), _heapsort_, not the data structure 
Insertion | [Insertion.java](http://algs4.cs.princeton.edu/21elementary/Insertion.java) | [Insertion.cs](../src/Sorting/Insertion.cs)
InsertionPedantic | [InsertionPedantic.java](http://algs4.cs.princeton.edu/21elementary/InsertionPedantic.java.html) | [InsertionT.cs](../src/Sorting/InsertionT.cs), `Insertion<T>`
InsertionX |  [InsertionX.java](http://algs4.cs.princeton.edu/21elementary/InsertionX.java.html) | [InsertionX.cs](../src/Sorting/InsertionX.cs)
Merge | [Merge.java](http://algs4.cs.princeton.edu/22mergesort/Merge.java.html) | [Merge.cs](../src/Sorting/Merge.cs)
MergeBU | [MergeBU.java](http://algs4.cs.princeton.edu/22mergesort/MergeBU.java.html) | [MergeBU.cs](../src/Sorting/MergeBU.cs)
MergeX  | [MergeX.java](http://algs4.cs.princeton.edu/22mergesort/MergeX.java.html) | [MergeX.cs](../src/Sorting/MergeX.cs), `MergeX<T> where T : IComparable<T>`
Quick | [Quick.java](http://algs4.cs.princeton.edu/23quicksort/Quick.java.html) | [Quick.cs](../src/Sorting/Quick.cs)
Quick3Way | [Quick3way.java](http://algs4.cs.princeton.edu/23quicksort/Quick3way.java.html) | [Quick3Way.cs](../src/Sorting/Quick3Way.cs)
QuickX | [QuickX.java](http://algs4.cs.princeton.edu/23quicksort/QuickX.java.html) | [QuickX.cs](../src/Sorting/QuickX.cs)
Selection | [Selection.java](http://algs4.cs.princeton.edu/21elementary/Selection.java.html) | [Selection.cs](../src/Sorting/Selection.cs)
Shell | [Shell.java](http://algs4.cs.princeton.edu/21elementary/Shell.java.html) | [Shell.cs](../src/Sorting/Shell.cs)

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
