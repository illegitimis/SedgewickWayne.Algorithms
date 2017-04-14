// Stack, queue and bag APIs
public interface IStack : IHaveSize, ICheckEmpty, System.Collections.IEnumerable
{
  void push(object obj);
  object pop();
  object peek();
}

public interface IStack<TStack> : IHaveSize, ICheckEmpty, System.Collections.Generic.IEnumerable<TStack>
{
  void push(TStack obj);
  TStack pop();
  TStack peek();
}

public interface IQueue : IHaveSize, ICheckEmpty, System.Collections.IEnumerable
{
  void Enqueue(object obj);
  object Dequeue();
  object Peek();
}

public interface IQueue<TQueue> : IHaveSize, ICheckEmpty, System.Collections.Generic.IEnumerable<TQueue>
{
  void Enqueue(TQueue obj);
  TQueue Dequeue();
  TQueue Peek();
}

public interface IBag : IHaveSize, ICheckEmpty, System.Collections.IEnumerable
{
  void Add(object obj);
}
public interface IBag<TBag> : IHaveSize, ICheckEmpty, System.Collections.Generic.IEnumerable<TBag>
{
  void Add(TBag x); 
}

public interface IHaveSize
{
  //int Size;
  int Size { get; }
}

public interface ICheckEmpty
{
  //bool IsEmpty;
  bool IsEmpty { get; }
}

