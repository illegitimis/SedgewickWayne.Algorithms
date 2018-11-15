# Symbol tables

Name | Princeton java link | .Net implementation
--- | --- | ---
`ISymbolTable` | X | [ISymbolTable](../src/SymbolTables/ISymbolTable.cs)
ArrayST | [ArrayST.java](http://algs4.cs.princeton.edu/31elementary/ArrayST.java.html) | [unordered array](../src/SymbolTables/ArrayST.cs)
SequentialSearchST | [SequentialSearchST.java](https://algs4.cs.princeton.edu/31elementary/SequentialSearchST.java.html) | linked list based [SequentialSearchST.cs](../src/SymbolTables/SequentialSearchST.cs)
`IOrderedSymbolTable` | X | [IOrderedSymbolTable](../src/SymbolTables/IOrderedSymbolTable.cs)
`OrderedSTBase` | X | [OrderedSTBase](../src/SymbolTables/TreeSTBase.cs)
BinarySearchST | [BinarySearchST.java](https://algs4.cs.princeton.edu/31elementary/BinarySearchST.java.html) | [binary search](../src/SymbolTables/BinarySearchST.cs)
`TreeSTBase` | X | [TreeSTBase](../src/SymbolTables/TreeSTBase.cs)
BST | [BST.java](http://algs4.cs.princeton.edu/32bst/BST.java.html )| [Binary Search Tree](../src/SymbolTables/BST.cs)
NonrecursiveBST | [NonrecursiveBST.java](http://algs4.cs.princeton.edu/32bst/NonrecursiveBST.java.html) | [NonrecursiveBST](../src/SymbolTables/NonrecursiveBST.cs) incomplete, `delete` not implemented
RandomizedBST | [RandomizedBST.java](http://algs4.cs.princeton.edu/33balanced/RandomizedBST.java.html) | [RandomizedBST](../src/SymbolTables/RandomizedBST.cs)
[RedBlackBST](http://algs4.cs.princeton.edu/33balanced/RedBlackBST.java.html) | [lecture](https://algs4.cs.princeton.edu/lectures/33BalancedSearchTrees-2x2.pdf), [construction](https://algs4.cs.princeton.edu/lectures/33DemoRedBlackBST.mov) demo, [javadoc](https://algs4.cs.princeton.edu/code/javadoc/edu/princeton/cs/algs4/RedBlackBST.html)| [RedBlackBST.cs](../src/SymbolTables/RedBlackBST.cs)
RedBlackLiteBST | [RedBlackLiteBST.java](http://algs4.cs.princeton.edu/33balanced/RedBlackBST.java.html)| X
[SplayBST.java](http://algs4.cs.princeton.edu/33balanced/SplayBST.java.html) | [self adjusting binary trees](http://www.cs.cmu.edu/%7Esleator/papers/self-adjusting.pdf) original paper, [rotations](http://yaikhom.com/2014/05/12/understanding-splay-tree-rotations.html) | [SplayBST.cs](../src/SymbolTables/SplayBST.cs) scaffolding only 
[AVLTreeST](https://algs4.cs.princeton.edu/code/edu/princeton/cs/algs4/AVLTreeST.java.html) | ordered symbol table of generic key-value pairs, uses internally an [AVL tree](https://algs4.cs.princeton.edu/code/javadoc/edu/princeton/cs/algs4/AVLTreeST.html) | to do
[TrieST](https://algs4.cs.princeton.edu/code/edu/princeton/cs/algs4/TrieST.java.html) | [256-way trie](https://algs4.cs.princeton.edu/code/javadoc/edu/princeton/cs/algs4/TrieST.html) | todo
[TST](https://algs4.cs.princeton.edu/code/edu/princeton/cs/algs4/TST.java.html) | [ternary search trie](https://algs4.cs.princeton.edu/code/javadoc/edu/princeton/cs/algs4/TST.html) | todo
[LinearProbingHashST.java](http://algs4.cs.princeton.edu/34hash/LinearProbingHashST.java.html) | [pic](https://algs4.cs.princeton.edu/34hash/images/linear-probing.png), [demo](https://algs4.cs.princeton.edu/lectures/34DemoLinearProbingHashTable.mov) insert & search | associative array based [LinearProbingHashST.cs](../src/SymbolTables/LinearProbingHashST.cs)
[SeparateChainingHashST](https://algs4.cs.princeton.edu/34hash/SeparateChainingHashST.java.html) | [pic](https://algs4.cs.princeton.edu/34hash/images/separate-chaining.png), [javadoc](https://algs4.cs.princeton.edu/code/javadoc/edu/princeton/cs/algs4/SeparateChainingHashST.html) | [SeparateChainingHashST.cs](../src/SymbolTables/SeparateChainingHashST.cs)

[home](../README.md#pages)