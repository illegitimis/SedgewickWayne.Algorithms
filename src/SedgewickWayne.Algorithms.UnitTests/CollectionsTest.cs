

namespace SedgewickWayne.Algorithms.UnitTests
{
  using System;
  using Xunit;
  using System.Threading;
  using System.Globalization;

  
  public class CollectionsTest
  {
    [Fact]
    [Trait("Type", "Stack")]
    [Trait("SupportingType", "LinkedList")]
    [Trait("Generic", "No")]
    [Trait("TestType", "to be or not to - be - - that - - - is")]
    public void  LinkedStackToBeTxt()
    {
      var stack = new LinkedStack();
      ToBeTxt(stack);
    }

    [Fact]
    [Trait("Type", "Stack")]
    [Trait("SupportingType", "ResizingArray")]
    [Trait("Generic", "No")]
    [Trait("TestType", "to be or not to - be - - that - - - is")]
    public void ResizingArrayStackToBeTxt()
    {
      var stack = new ResizingArrayStack();
      ToBeTxt(stack);
    }

    [Fact]    
    [Trait("Type", "Stack")]
    [Trait("Generic", "Yes")]
    [Trait("SupportingType", "LinkedList")]
    [Trait("TestType", "to be or not to - be - - that - - - is")]
    public void StackToBeTxt()
    {
      var stack = new Stack<string>();
      ToBeTxt(stack);
    }

    [Fact]
    [Trait("Type", "Stack")]
    public void StackToString ()
    {
      //var stack = new Stack();
      //StackIterateToString(stack);
    }

    [Fact]
    [Trait("Type", "Stack")]
    public void LinkedStackToString()
    {
      var stack = new LinkedStack();
      StackIterateToString(stack);
    }

    [Fact]
    [Trait("Type", "Stack")]
    public void ResizingArrayToString()
    {
      var stack = new ResizingArrayStack();
      StackIterateToString(stack);
    }

    void StackIterateToString(IStack stack)
    {
      // Arrange: stack empty to start with
      Assert.True(stack.IsEmpty);

      // Act
      stack.Push(1);
      stack.Push(2.0d);
      stack.Push("three");
      var s = stack.ToString();
      
      // Assert
      Assert.Equal("three 2 1", s);
    }

    


    /// <summary>
    /// % more tobe.txt
    /// to be or not to - be - - that - - - is
    /// </summary>
    void ToBeTxt(object /*IStack*/ oStack)
    {
      var nstack = oStack as IStack;
      var gstack = oStack as IStack<string>;
      var strings = new System.Collections.Generic.List<string>();

      string tobe = "to be or not to - be - - that - - - is";
      var tokens = tobe.Split(new char[] { '\0', ' ' }, StringSplitOptions.RemoveEmptyEntries);
      foreach (var t in tokens)
      {
        switch (t)
        {
          case "-":
            if (nstack != null) strings.Add (nstack.Pop() as string);
            else if (gstack != null) strings.Add(gstack.Pop());
            break;

          default:
            if (nstack != null) nstack.Push(t);
            else if (gstack != null) gstack.Push(t);
            break;
        }
      }

      //
      if (nstack != null) Assert.False(nstack.IsEmpty);
      else if (gstack != null) Assert.False(gstack.IsEmpty);

      if (nstack != null)
      {
        while (!nstack.IsEmpty) strings.Add(nstack.Pop() as string);
        Assert.True(nstack.IsEmpty);
      }
      else if (gstack != null)
      {
        while (!gstack.IsEmpty) strings.Add(gstack.Pop());
        Assert.True(gstack.IsEmpty);
      }

      //
      Assert.Equal(new[] { "to", "be", "not", "that", "or", "be", "is", "to" }, strings);
    }
  }
}
