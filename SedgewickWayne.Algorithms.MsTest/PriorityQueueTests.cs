

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

        string hamlet = "to be or not to - be - - that - - - is";

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
            // default ctor then insert
            PQBase<string> pq = new MaxPQ<string>();
            Assert.IsTrue(pq.IsEmpty);
            var actual = InsertAllAndDeleteAll(pq).ToList();
            CollectionAssert.AreEqual(topDown, actual);

            // InsertAllConstructorAndIterate
            pq = new MaxPQ<string>(array);
            Assert.IsFalse(pq.IsEmpty);
            CollectionAssert.AreEqual(topDown, pq.ToList());
        }

        [TestMethod]
        public void InsertAllAndDeleteAllMinPQTest()
        {
            var expected = topDown.Reverse().ToArray();

            // default ctor then insert
            PQBase<string> pq = new MinPQ<string>();
            Assert.IsTrue(pq.IsEmpty);
            var actual = InsertAllAndDeleteAll(pq).ToList();
            CollectionAssert.AreEqual(expected, actual);

            // InsertAllConstructorAndIterate
            pq = new MinPQ<string>(array);
            Assert.IsFalse(pq.IsEmpty);
            CollectionAssert.AreEqual(expected, pq.ToList());
        }

        IEnumerable<string> InsertAllAndDeleteAll(PQBase<string> pq)
        {
            foreach (var s in array)
                pq.Insert(s);

            while (!pq.IsEmpty)
                yield return pq.Delete();
        }

        /**
         * insert and delete
         * Unit tests the {@code MaxPQ} data type.         
         * Unit tests the {@code MinPQ} data type.         
         */
        [TestMethod]
        public void MaxPQHamlet()
        {
            // arrange
            var pq = new MaxPQ<string>();
            // act
            var tops = ActHamlet(pq).ToList();
            // assert
            Assert.IsFalse(pq.IsEmpty);
            Assert.AreEqual(2, pq.Size);
            CollectionAssert.AreEqual(new[] { "to", "to", "or", "that", "not", "be" }, tops, String.Join("|", tops));
            CollectionAssert.AreEqual(new[] { "is", "be" }, pq.ToArray());
        }

        [TestMethod]
        public void MinPQHamlet()
        {
            // arrange
            var pq = new MinPQ<string>();
            // act
            var tops = ActHamlet(pq).ToList();
            // assert
            Assert.IsFalse(pq.IsEmpty);
            Assert.AreEqual(2, pq.Size);
            CollectionAssert.AreEqual(new[] { "be", "be", "not", "or", "that", "to" }, tops, String.Join("|", tops));
            CollectionAssert.AreEqual(new[] { "is", "to" }, pq.ToArray());
        }
        private IEnumerable<string> ActHamlet(IPriorityQueue<string> pq)
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
    }
}
