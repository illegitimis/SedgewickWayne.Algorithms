

namespace SedgewickWayne.Algorithms.MsTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class PriorityQueueTests
    {
        #region defines

        static readonly string[] array = new string[]
        {
            "it",
            "was",
            "the",
            "best",
            "of",
            "times",
            "it",
            "was",
            "the",
            "worst"
        };

        static readonly string[] topDown = new string[]
        {
            "worst",
            "was",
            "was",
            "times",
            "the",
            "the",
            "of",
            "it",
            "it",
            "best"
        };

        static readonly string[] indexedMax = new string[]
        {
            "9", "worst",
            "1", "was",
            "7", "was",
            "5", "times",
            "8", "the",
            "2", "the",
            "4", "of",
            "6", "it",
            "0", "it",
            "3", "best"
        };

        static readonly string[] indexedMin = new string[] {
            "3" , "best" ,
            "0" , "it" ,
            "6" , "it" ,
            "4" , "of" ,
            "8" , "the" ,
            "2" , "the" ,
            "5" , "times" ,
            "7" , "was" ,
            "1" , "was" ,
            "9" , "worst"
        };

       

        #endregion
        
        // increase or decrease the key
        [TestMethod]
        public void IndexedMaxPQIncreaseKeyTest()
        {
            // arrange 
            var pq = new IndexMaxPQ<string>(array);

            // act + assert initial
            Assert.IsFalse(pq.IsEmpty);
            Assert.AreEqual(10, pq.Size);
            Assert.AreEqual(9, pq.Index);
            Assert.AreEqual(9, pq.MaxIndex);
            Assert.AreEqual("worst", pq.Max);
            Assert.AreEqual("worst", pq.TopKey);

            // act + assert ex
            try
            {
                pq.increaseKey(9, "exception");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
                Assert.AreEqual("Calling increaseKey() with given argument would not strictly increase the key", ex.Message);
            }

            // act + assert increase
            pq.increaseKey(9, "worst even");
            Assert.AreEqual("worst even", pq.Max);
            Assert.AreEqual("worst even", pq.TopKey);
        }

        [TestMethod]
        public void IndexedMinPQDecreaseKeyTest()
        {
            // arrange 
            var pq = new IndexMinPQ<string>(array);

            // act + assert initial
            Assert.IsFalse(pq.IsEmpty);
            Assert.AreEqual(10, pq.Size);
            Assert.AreEqual(3, pq.Index);
            Assert.AreEqual(3, pq.MinIndex);
            Assert.AreEqual("best", pq.Min);
            Assert.AreEqual("best", pq.TopKey);

            // act + assert ex
            try
            {
                pq.decreaseKey(int.MaxValue-1, null);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentOutOfRangeException));             
            }

            try
            {
                pq.decreaseKey(10, null);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentOutOfRangeException));
            }
            
            // act + assert decrease
            try
            {
                pq.decreaseKey(5, "zzz");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
                Assert.AreEqual("Calling decreaseKey() with given argument would not strictly decrease the key", ex.Message);
            }

            pq.decreaseKey(5, "aaa");
            Assert.AreEqual("aaa", pq.Min);
            Assert.AreEqual("aaa", pq.TopKey);
            Assert.AreEqual(5, pq.Index);
            Assert.AreEqual(5, pq.MinIndex);
        }

        // insert a bunch of strings
        // delete and print each key
        [TestMethod]
        public void IndexPQDeleteAtIndexTest()
        {
            var pq = new IndexMaxPQ<String>(array);
            Assert.IsTrue(pq.Contains(5));
            pq.Delete(5);
            Assert.IsFalse(pq.Contains(5));

            try
            {
                pq.Delete(5);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("index is not in the priority queue", ex.Message);
            }
        }

        // print each key using the iterator
        [TestMethod]
        public void IndexMaxPQIteratorTest()
        {
            var pq = new IndexMaxPQ<String>(array);
            var actual = Strings(pq).ToList();
            CollectionAssert.AreEqual(indexedMax, actual, String.Join("|",actual));            
        }        

        [TestMethod]
        public void IndexMinPQIteratorTest()
        {
            var pq = new IndexMinPQ<String>(array);
            var actual = Strings(pq).ToList();
            CollectionAssert.AreEqual(indexedMin, actual, String.Join("|", actual));
        }

        IEnumerable<Tuple<int,string>> Tuples (IndexPQBase<string> pq)
        {
            foreach (int i in pq)
            {
                yield return new Tuple<int, string>(i, pq.KeyOf(i));                
            }
        }
        IEnumerable<string> Strings(IndexPQBase<string> pq)
        {
            foreach (int i in pq)
            {
                yield return i.ToString();
                yield return pq.KeyOf(i);
            }
        }


        /*
        * Unit tests the {@code IndexMinPQ} data type.
        * Unit tests the {@code IndexMaxPQ} data type.
        * insert a bunch of strings
        * delete and print each key
        * print each key using the iterator
        */
        [TestMethod]
        public void InsertAllAndDeleteAllMaxPQTest()
        {
            InsertAllAndDeleteAll(new MaxPQ<string>(), topDown);
        }

        [TestMethod]
        public void InsertAllAndDeleteAllMinPQTest()
        {
            InsertAllAndDeleteAll(new MinPQ<string>(), topDown.Reverse().ToArray());
        }

        [TestMethod]
        public void ConstructFromArrayMaxPQTest()
        {
            ConstructFromArrayAndIterate(new MaxPQ<string>(array), topDown);
        }

        [TestMethod]
        public void ConstructFromArrayMinPQTest()
        {
            ConstructFromArrayAndIterate(new MinPQ<string>(array), topDown.Reverse().ToArray());
        }


        void InsertAllAndDeleteAll(ArrayPQBase<string> pq, string[] expected)
        {
            // default ctor, insert a bunch of values, then delete all
            Assert.IsTrue(pq.IsEmpty);
            var actual = Strings(pq).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        void ConstructFromArrayAndIterate (ArrayPQBase<string> pq, string[] expected)
        {
            Assert.IsFalse(pq.IsEmpty);
            CollectionAssert.AreEqual(expected, pq.ToList());
        }


        IEnumerable<string> Strings(ArrayPQBase<string> pq)
        {
            foreach (var s in array) pq.Insert(s);

            while (!pq.IsEmpty) yield return pq.Delete();
        }

        #region hamlet

        const string hamlet = "to be or not to - be - - that - - - is";
        static readonly string[] hamlet_tops = new[] { "to", "to", "or", "that", "not", "be" };
        static readonly string[] hamlet_leftovers = new[] { "is", "be" };

        [TestMethod]
        public void Hamlet_MaxPQ()
        {
            // arrange
            var pq = new MaxPQ<string>();
            // act / assert
            ArrayPQHamlet(pq, hamlet_tops, hamlet_leftovers);
        }


        [TestMethod]
        public void Hamlet_UnorderedArrayMaxPQ()
        {
            ArrayPQHamlet(new UnorderedArrayMaxPQ<string>(), hamlet_tops, hamlet_leftovers);
        }

        [TestMethod]
        public void Hamlet_OrderedArrayMaxPQ()
        {
            ArrayPQHamlet(new OrderedArrayMaxPQ<string>(), hamlet_tops, hamlet_leftovers);
        }

        [TestMethod]
        public void Hamlet_MinPQ()
        {
            // arrange
            var pq = new MinPQ<string>();
            // act
            ArrayPQHamlet(pq, new[] { "be", "be", "not", "or", "that", "to" }, new[] { "is", "to" });
        }


        void ArrayPQHamlet(ArrayPQBase<string> pq, string[] expectedTops, string[] expectedLeftovers)
        {
            // arrange
            // var pq = new MinPQ<string>();
            Assert.IsTrue(pq.IsEmpty);

            // act
            var tops = Hamlet(pq).ToList();

            // assert
            Assert.IsFalse(pq.IsEmpty);
            Assert.AreEqual(2, pq.Size);

            CollectionAssert.AreEqual(expectedTops, tops, String.Join("|", tops));

            var leftovers = pq.ToArray();
            CollectionAssert.AreEqual(expectedLeftovers, leftovers, String.Join("|", leftovers));

            CollectionAssert.AreEquivalent(
                expectedLeftovers.Union(expectedTops).ToArray(), 
                tops.Union(leftovers).ToArray(), 
                "union");            
        }

        #endregion

        IEnumerable<string> Hamlet(IPriorityQueue<string> pq)
        {
            foreach (var s in hamlet.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
            {
                // act
                switch (s)
                {
                    case "-": yield return pq.Delete(); break;
                    default: pq.Insert(s); break;
                }
            }
        }

        [TestMethod]
        public void UnorderedArrayMaxPQ_SimpleTest()
        {
            var pq = new UnorderedArrayMaxPQ<string>(10);
            TestArrayMaxPQ(pq, ProduceArray);
        }

        [TestMethod]
        public void OrderedArrayMaxPQ_SimpleTest()
        {
            var pq = new OrderedArrayMaxPQ<string>(10);
            TestArrayMaxPQ(pq, ProduceArray);
        }

        [TestMethod]
        public void UnorderedArrayMaxPQ_Enumerate()
        {
            var pq = new UnorderedArrayMaxPQ<string>(10);
            TestArrayMaxPQ(pq, EnumerateArrayMax, false);
        }

        [TestMethod]
        public void OrderedArrayMaxPQ_Enumerate()
        {
            var pq = new OrderedArrayMaxPQ<string>(10);
            TestArrayMaxPQ(pq, EnumerateArrayMax, false);
        }

        void TestArrayMaxPQ(ArrayPQBase<string> pq, ArrayMaxPQProducer f, bool IsConsumer = true)
        {
            var maxes = f(pq).ToArray();
            if (IsConsumer) Assert.IsTrue(pq.IsEmpty);
            CollectionAssert.AreEqual(new string[] { "this", "test", "is", "a" }, maxes);
        }

        delegate IEnumerable<string> ArrayMaxPQProducer(ArrayPQBase<string> pq);

        IEnumerable<string> EnumerateArrayMax(ArrayPQBase<string> pq)
        {
            pq.Insert("this");
            pq.Insert("is");
            pq.Insert("a");
            pq.Insert("test");
            foreach(string s in pq) yield return s;
        }

        IEnumerable<string> ProduceArray(ArrayPQBase<string> pq)
        {
            pq.Insert("this");
            pq.Insert("is");
            pq.Insert("a");
            pq.Insert("test");
            while (!pq.IsEmpty) yield return pq.Delete();
        }

        // https://algs4.cs.princeton.edu/24pq/images/pq-array.png
        void SequenceOfOperations(IMaxPriorityQueue<char> pq)
        {
            pq.Insert('P');
            pq.Insert('Q');
            pq.Insert('E');
            Assert.AreEqual(pq.Delete(), 'Q');
            pq.Insert('X');
            pq.Insert('A');
            pq.Insert('M');
            Assert.AreEqual(pq.Delete(), 'X');
            pq.Insert('P');
            pq.Insert('L');
            pq.Insert('E');
            Assert.AreEqual(pq.Delete(), 'P');
            Assert.AreEqual(pq.Size, 6);
            CollectionAssert.AreEqual(new char[] { 'P', 'M', 'L', 'E', 'E', 'A' }, pq.ToArray());
        }

        [TestMethod]
        void SequenceOfOperations_MaxPQ()
        {
            var pq = new MaxPQ<char>(10);
            SequenceOfOperations(pq);
        }
        [TestMethod]
        void SequenceOfOperations_OrderedArrayMaxPQ()
        {
            var pq = new OrderedArrayMaxPQ<char>(10);
            SequenceOfOperations(pq);
        }
        [TestMethod]
        void SequenceOfOperations_UnOrderedArrayMaxPQ()
        {
            var pq = new UnorderedArrayMaxPQ<char>(10);
            SequenceOfOperations(pq);
        }
    }
}
