# Collections

Namespace: `SedgewickWayne.Algorithms`.

## Generic

Based solely on **linked lists**.

Class | Princeton java link | .Net implementation
--- | --- | ---
`Bag` | [Bag.java] | [Bag.cs]
`Queue` | [Queue.java] | [Queue.cs]
`Stack` | [Stack.java] | [Stack.cs]

Below the class diagram for the generic queue.

![IQueue<T>](IQueue{T}.png)

## Non Generic

Based on linked lists and resizing arrays.

Class | Princeton java link | .Net implementation
--- | --- | ---
`ResizingArrayBag` | [ResizingArrayBag.java] | [ResizingArrayBag.cs]
`ResizingArrayQueue` | [ResizingArrayQueue.java] | [ResizingArrayQueue.cs]
`ResizingArrayStack` | [ResizingArrayStack.java] | [ResizingArrayStack.cs]
`LinkedBag` | [LinkedBag.java] | [LinkedBag.cs]
`LinkedQueue` | [LinkedQueue.java]| [LinkedQueue.cs]
`LinkedStack` | [LinkedStack.java] | [LinkedStack.cs]

Bare-bone implementations with a _fixed array_ like [1] & [2] were discarded.

Below the class diagram for the object based queue.

![IQueue](IQueue.png)

[home](../README.md#pages)

[1]: https://algs4.cs.princeton.edu/13stacks/FixedCapacityStackOfStrings.java.html
[2]: https://algs4.cs.princeton.edu/13stacks/FixedCapacityStack.java.html
[Bag.java]: https://algs4.cs.princeton.edu/13stacks/Bag.java.html
[Bag.cs]: ../src/Collections/Generic/Bag.cs
[Queue.java]: https://algs4.cs.princeton.edu/13stacks/Queue.java.html
[Queue.cs]: ../src/Collections/Generic/Queue.cs
[Stack.java]: https://algs4.cs.princeton.edu/13stacks/Stack.java.html
[Stack.cs]: ../src/Collections/Generic/Stack.cs
[ResizingArrayBag.java]: https://algs4.cs.princeton.edu/13stacks/ResizingArrayBag.java.html
[ResizingArrayBag.cs]: ../src/Collections/NonGeneric/ResizingArrayBag.cs
[ResizingArrayQueue.java]: https://algs4.cs.princeton.edu/13stacks/ResizingArrayQueue.java.html
[ResizingArrayQueue.cs]: ../src/Collections/NonGeneric/ResizingArrayQueue.cs
[ResizingArrayStack.java]: https://algs4.cs.princeton.edu/13stacks/ResizingArrayStack.java.html
[ResizingArrayStack.cs]: ../src/Collections/NonGeneric/ResizingArrayStack.cs
[LinkedBag.java]: https://algs4.cs.princeton.edu/13stacks/LinkedBag.java.html
[LinkedBag.cs]: ../src/Collections/NonGeneric/LinkedBag.cs
[LinkedQueue.java]: https://algs4.cs.princeton.edu/13stacks/LinkedQueue.java.html
[LinkedQueue.cs]: ../src/Collections/NonGeneric/LinkedQueue.cs
[LinkedStack.java]: https://algs4.cs.princeton.edu/13stacks/LinkedStack.java.html
[LinkedStack.cs]: ../src/Collections/NonGeneric/LinkedStack.cs