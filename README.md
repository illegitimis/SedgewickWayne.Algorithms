# SedgewickWayne.Algorithms
Porting algorithms by Robert Sedgewick and Kevin Wayne in .NET

**Initial approach was to convert java jars with IKVM, then use ILSpy on the generated code to produce cs files**.
Those files would then have to be stripped off the unnecessary metadata. 
They reside in the `./SedgewickWayne.Algorithms/AnteRoom` folder and are not included in the project.
This approach was dropped because most of the code looked bad, especially inner classes for linked lists, list nodes and enumerators, and even after trimming metadata, severe refactoring was needed.

Replaced tokens: `using IKVM.Attributes;`, `using java.lang;`, `In.__<clinit>();`, `[HideFromJava]`, `using java.util;`, `using ikvm.lang;`, ` Throwable.__<suppressFillInStackTrace>();`, `using java.io;`, ` using ikvm.@internal;`, `: java.lang.Object`, `using IKVM.Runtime;`, `using System.Runtime.CompilerServices;`, `using System;`, `[MethodImpl(MethodImplOptions.NoInlining)]`

Replaced regex: `\[LineNumberTable\([^\)]+\)\]`, `^.*(\[[^\]\(\)]+\([^\]\(\)]+\)[^\]\(\)]*\])$` with ` \/\/\1`, `(\[Implements\(new string\[\]\r\n[^{]+{[^\]]+\])`, `\[LineNumberTable\(new byte\[\]\r\n[^{]+{[^}]+\}\)`, `[LineNumberTable(\d\d), Modifiers(Modifiers.Static | Modifiers.Synthetic)]`


 

**Instead, it seems easier to port java files from the [Princeton repo](http://algs4.cs.princeton.edu) or the [duplicated Brazilian one](https://www.ime.usp.br/~pf/sedgewick-wayne/algs4/)**.

## Pages
Below is the work for which porting was finished and unit tests passing.

+ [Collections](./doc/col.md)
+ [Dynamic Connectivity](./doc/uf.md)

## Algorithms to do list
### Mapped

Name | Category | Princeton java link | Done
--- | --- | --- | ---
BinarySearch                  |  Sorting                      |  | Y
BinarySearchST                |  Searching                    | http://algs4.cs.princeton.edu/31elementary/BinarySearchST.java.html
BlackFilter                   |  Searching                    | http://algs4.cs.princeton.edu/31elementary
BST                           |  Searching                    | http://algs4.cs.princeton.edu/32bst/BST.java.html
DeDup                         |  Searching                    | http://algs4.cs.princeton.edu/31elementary
FileIndex                     |  Searching                    | http://algs4.cs.princeton.edu/31elementary
FordFulkerson                 |                               | https://www.ime.usp.br/~pf/sedgewick-wayne/algs4/FordFulkerson.java
Heap                          |  Sorting                      |  N
IndexMaxPQ                    |  Priority Queues              |  Y
IndexMinPQ                    |  Priority Queues              |  Y
Insertion                     |  Sorting                      |
InsertionX                    |  Sorting                      |
LinearProbingHashST           |  Searching                    | http://algs4.cs.princeton.edu/34hash/LinearProbingHashST.java.html
LookupCSV                     |  Searching                    | http://algs4.cs.princeton.edu/31elementary
LookupIndex                   |  Searching                    | http://algs4.cs.princeton.edu/31elementary
MaxPQ                         |  Priority Queues              | http://algs4.cs.princeton.edu/24pq/MaxPQ.java.html | Y
Merge                         |  Sorting                      |  Y
MergeBU                       |  Sorting                      |  N
MergeX                        |  Sorting                      |  N
MinPQ                         |  Priority Queues              |  http://algs4.cs.princeton.edu/24pq/MinPQ.java.html | Y
Quick                         |  Sorting                      |  N
Quick3Way                     |  Sorting                      |  N
QuickX                        |  Sorting                      |  N
RedBlackBST                   |  Searching                    | http://algs4.cs.princeton.edu/33balanced/RedBlackLiteBST.java.html
Selection                     |  Sorting                      |  Y
SeparateChainingHashST        |  Searching                    | http://algs4.cs.princeton.edu/31elementary
SequentialSearchST            |  Searching                    | http://algs4.cs.princeton.edu/31elementary/SequentialSearchST.java.html 
SET                           |  Searching                    | http://algs4.cs.princeton.edu/31elementary
Shell                         |  Sorting                      |  Y
SparseVector                  |  Searching                    | http://algs4.cs.princeton.edu/31elementary
ST                            |  Searching                    | http://algs4.cs.princeton.edu/35applications/ST.java.html
ThreeSum                      |  Fundamentals                 | http://algs4.cs.princeton.edu/14analysis/ThreeSum.java
ThreeSumFast                  |  Fundamentals                 | http://algs4.cs.princeton.edu/14analysis/ThreeSumFast.java
WhiteFilter                   |  Searching                    | http://algs4.cs.princeton.edu/31elementary

### Unmapped

- AcyclicLP                     
- AcyclicSP                     
- AdjMatrixEdgeWeightedDigraph  
- Alphabet                      
- Arbitrage                     
- AssignmentProblem             
- Average                       
- Bipartite                     
- BipartiteMatching             
- BellmanFordSP                 
- BinaryDump                    
- BoruvkaMST                    
- BoyerMoore                    
- BreadthFirstDirectedPaths     
- BreadthFirstPaths             
- BTree                         
- Cat                           
- CC                            
- ClosestPair                   
- CollisionSystem               
- Complex                       
- Copy                          
- Count                         
- Counter                       
- CPM                           
- Cycle                         
- Date                          
- DepthFirstDirectedPaths       
- DepthFirstOrder               
- DepthFirstPaths               
- DepthFirstSearch              
- Digraph                       
- DigraphGenerator              
- DijkstraAllPairsSP            
- DijkstraSP                    
- DirectedCycle                 
- DirectedDFS                   
- DirectedEdge                  
- DoublingRatio                 
- DoublingTest                  
- Edge                          
- EdgeWeightedDigraph           
- EdgeWeightedDirectedCycle     
- EdgeWeightedGraph             
- FarthestPair                  
- FFT                           
- FlowEdge                      
- FlowNetwork                   
- FloydWarshall                 
- GabowSCC                      
- GaussianElimination           
- Genome                        
- GrahamScan                    
- Graph                         
- GraphGenerator                
- GREP                          
- Huffman                       
- Interval1D                    
- Interval2D                    
- KMP                           
- Knuth                         
- KosarajuSharirSCC             
- KruskalMST                    
- KWIK                          
- LazyPrimMST                   
- LinearRegression              
- LongestCommonSubstring        
- LRS                           
- LSD                           
- LZW                           
- MSD                           
- NFA                           
- PolynomialRegression          
- PrimMST                       
- Queue                         
- Quick3String                  
- RabinKarp                     
- RandomSeq                     
- RunLength                     
- Simplex                       
- Stack                         
- StaticSETOfInts               
- SuffixArray                   
- SuffixArrayX                  
- SymbolDigraph                 
- SymbolGraph                   
- TarjanSCC                     
- Topological                   
- Transaction                   
- TransitiveClosure             
- TrieSET                       
- TrieST                        
- TST                           
- Vector                        
- WhiteList                     