

namespace SedgewickWayne.Algorithms.MsTest
{
  using System;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using System.Threading;
  using System.Globalization;

  [TestClass]
  public class CollectionsTest
  {
    [TestMethod]
    [TestCategory("Stack")]
    [TestCategory("LinkedList")]
    [TestCategory("NonGeneric")]
    [TestCategory("to be or not to - be - - that - - - is")]
    public void  LinkedStackToBeTxt()
    {
      var stack = new LinkedStack();
      ToBeTxt(stack);
    }

    [TestMethod]
    [TestCategory("Stack")]
    [TestCategory("ResizingArray")]
    [TestCategory("NonGeneric")]
    [TestCategory("to be or not to - be - - that - - - is")]
    public void ResizingArrayStackToBeTxt()
    {
      var stack = new ResizingArrayStack();
      ToBeTxt(stack);
    }

    [TestMethod]
    [TestCategory("Stack")]
    [TestCategory("Generic")]
    [TestCategory("LinkedList")]
    [TestCategory("to be or not to - be - - that - - - is")]
    public void StackToBeTxt()
    {
      var stack = new Stack<string>();
      ToBeTxt(stack);
    }

    [TestMethod]
    [TestCategory("Stack")]
    public void StackToString ()
    {
      //var stack = new Stack();
      //StackIterateToString(stack);
    }

    [TestMethod]
    [TestCategory("Stack")]
    public void LinkedStackToString()
    {
      var stack = new LinkedStack();
      StackIterateToString(stack);
    }

    [TestMethod]
    [TestCategory("Stack")]
    public void ResizingArrayToString()
    {
      var stack = new ResizingArrayStack();
      StackIterateToString(stack);
    }

    void StackIterateToString(IStack stack)
    {
      // Arrange: stack empty to start with
      Assert.IsTrue(stack.IsEmpty);

      // Act
      stack.Push(1);
      stack.Push(2.0d);
      stack.Push("three");
      var s = stack.ToString();
      
      // Assert
      Assert.AreEqual("three 2 1", s);
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
      if (nstack != null) Assert.IsFalse(nstack.IsEmpty);
      else if (gstack != null) Assert.IsFalse(gstack.IsEmpty);

      if (nstack != null)
      {
        while (!nstack.IsEmpty) strings.Add(nstack.Pop() as string);
        Assert.IsTrue(nstack.IsEmpty);
      }
      else if (gstack != null)
      {
        while (!gstack.IsEmpty) strings.Add(gstack.Pop());
        Assert.IsTrue(gstack.IsEmpty);
      }

      //
      CollectionAssert.AreEqual(new[] { "to", "be", "not", "that", "or", "be", "is", "to" }, strings);
    }
  }
}
