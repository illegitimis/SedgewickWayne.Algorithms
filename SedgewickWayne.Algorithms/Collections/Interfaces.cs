// Stack, queue and bag APIs

/// <summary>
/// Non-generic, object based pushdown (LIFO) stack
/// </summary>
public interface IStack : IHaveSize, ICheckEmpty, System.Collections.IEnumerable
{
  /// <summary>
  /// Adds an object to the stack.
  /// </summary>
  /// <param name="obj">object to add</param>
  void Push(object obj);

  /// <summary>
  /// Removes and returns the most recently added item
  /// </summary>
  /// <returns>Most recently added item</returns>
  object Pop();

  /// <summary>
  /// Returns the most recently added item without removing it 
  /// </summary>
  /// <returns>Most recently added item</returns>
  object Peek();
}

/// <summary>
/// Generic pushdown (LIFO) stack
/// </summary>
/// <typeparam name="TStack"></typeparam>
public interface IStack<TStack> : IHaveSize, ICheckEmpty, System.Collections.Generic.IEnumerable<TStack>
{
  /// <summary>
  /// Adds an item.
  /// </summary>
  /// <param name="t">item to add</param>
  void Push(TStack t);

  /// <summary>
  /// Removes and returns the most recently added item
  /// </summary>
  /// <returns>Most recently added item</returns>
  TStack Pop();

  /// <summary>
  /// Returns the most recently added item without removing it 
  /// </summary>
  /// <returns>Most recently added item</returns>
  TStack Peek();
}

/// <summary>
/// Non-generic FIFO queue
/// </summary>
public interface IQueue : IHaveSize, ICheckEmpty, System.Collections.IEnumerable
{
  /// <summary>
  /// Adds an item.
  /// </summary>
  /// <param name="obj"></param>
  void Enqueue(object obj);

  /// <summary>
  /// Removes the least recently added item.
  /// </summary>
  /// <returns>Least recently added item</returns>
  object Dequeue();

  /// <summary>
  /// Returns the least recently added item without removing it 
  /// </summary>
  /// <returns>Least recently added item</returns>
  object Peek();
}

/// <summary>
/// Generic FIFO queue
/// </summary>
/// <typeparam name="TQueue"></typeparam>
public interface IQueue<TQueue> : IHaveSize, ICheckEmpty, System.Collections.Generic.IEnumerable<TQueue>
{
  /// <summary>
  /// Adds an item.
  /// </summary>
  /// <param name="t">item to add</param>
  void Enqueue(TQueue t);

  /// <summary>
  /// Removes the least recently added item.
  /// </summary>
  /// <returns>Least recently added item</returns>
  TQueue Dequeue();

  /// <summary>
  /// Returns the least recently added item without removing it 
  /// </summary>
  /// <returns>Least recently added item</returns>
  TQueue Peek();
}

/// <summary>
/// Non-generic bag
/// </summary>
public interface IBag : IHaveSize, ICheckEmpty, System.Collections.IEnumerable
{
  /// <summary>
  /// Adds an object to the bag.
  /// </summary>
  /// <param name="obj">object to add.</param>
  void Add(object obj);
}

/// <summary>
/// Generic bag
/// </summary>
/// <typeparam name="TBag"></typeparam>
public interface IBag<TBag> : IHaveSize, ICheckEmpty, System.Collections.Generic.IEnumerable<TBag>
{
  /// <summary>
  /// add a generic item
  /// </summary>
  /// <param name="x">item to add</param>
  void Add(TBag x); 
}

/// <summary>
/// Abstract out size property
/// </summary>
public interface IHaveSize
{
  /// <summary>
  /// collection size
  /// </summary>
  int Size { get; }
}


/// <summary>
/// Abstract out check for empty
/// </summary>
public interface ICheckEmpty
{
  /// <summary>
  /// is the collection empty?
  /// </summary>
  bool IsEmpty { get; }
}


public interface ICloneable<T> where T : class
{
    T Clone();
}
