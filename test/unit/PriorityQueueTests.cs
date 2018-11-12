

namespace SedgewickWayne.Algorithms.UnitTests
{
    using System;
    using Xunit;
    using System.Collections.Generic;
    using System.Linq;

    
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
        [Fact]
        public void IndexedMaxPQIncreaseKeyTest()
        {
            // arrange 
            var pq = new IndexMaxPQ<string>(array);

            // act + assert initial
            Assert.False(pq.IsEmpty);
            Assert.Equal(10, pq.Size);
            Assert.Equal(9, pq.Index);
            Assert.Equal(9, pq.MaxIndex);
            Assert.Equal("worst", pq.Max);
            Assert.Equal("worst", pq.TopKey);

            // act + assert ex
            try
            {
                pq.increaseKey(9, "exception");
            }
            catch (Exception ex)
            {
                Assert.IsType<ArgumentException>(ex);
                Assert.Equal("Calling increaseKey() with given argument would not strictly increase the key", ex.Message);
            }

            // act + assert increase
            pq.increaseKey(9, "worst even");
            Assert.Equal("worst even", pq.Max);
            Assert.Equal("worst even", pq.TopKey);
        }

        [Fact]
        public void IndexedMinPQDecreaseKeyTest()
        {
            // arrange 
            var pq = new IndexMinPQ<string>(array);

            // act + assert initial
            Assert.False(pq.IsEmpty);
            Assert.Equal(10, pq.Size);
            Assert.Equal(3, pq.Index);
            Assert.Equal(3, pq.MinIndex);
            Assert.Equal("best", pq.Min);
            Assert.Equal("best", pq.TopKey);

            // act + assert ex
            try
            {
                pq.decreaseKey(int.MaxValue-1, null);
            }
            catch (Exception ex)
            {
                Assert.IsType<ArgumentOutOfRangeException>(ex);
            }

            try
            {
                pq.decreaseKey(10, null);
            }
            catch (Exception ex)
            {
                Assert.IsType<ArgumentOutOfRangeException>(ex);
            }
            
            // act + assert decrease
            try
            {
                pq.decreaseKey(5, "zzz");
            }
            catch (Exception ex)
            {
                Assert.IsType<ArgumentException>(ex);
                Assert.Equal("Calling decreaseKey() with given argument would not strictly decrease the key", ex.Message);
            }

            pq.decreaseKey(5, "aaa");
            Assert.Equal("aaa", pq.Min);
            Assert.Equal("aaa", pq.TopKey);
            Assert.Equal(5, pq.Index);
            Assert.Equal(5, pq.MinIndex);
        }

        // insert a bunch of strings
        // delete and print each key
        [Fact]
        public void IndexPQDeleteAtIndexTest()
        {
            var pq = new IndexMaxPQ<String>(array);
            Assert.True(pq.Contains(5));
            pq.Delete(5);
            Assert.False(pq.Contains(5));

            try
            {
                pq.Delete(5);
            }
            catch (Exception ex)
            {
                Assert.IsType<InvalidOperationException>(ex);
                Assert.Equal("index is not in the priority queue", ex.Message);
            }
        }

        // print each key using the iterator
        [Fact]
        public void IndexMaxPQIteratorTest()
        {
            var pq = new IndexMaxPQ<String>(array);
            var actual = Strings(pq).ToList();
            Assert.Equal(indexedMax, actual);            
        }        

        [Fact]
        public void IndexMinPQIteratorTest()
        {
            var pq = new IndexMinPQ<String>(array);
            var actual = Strings(pq).ToList();
            Assert.Equal(indexedMin, actual);
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
        [Fact]
        public void InsertAllAndDeleteAllMaxPQTest()
        {
            InsertAllAndDeleteAll(new MaxPQ<string>(), topDown);
        }

        [Fact]
        public void InsertAllAndDeleteAllMinPQTest()
        {
            InsertAllAndDeleteAll(new MinPQ<string>(), topDown.Reverse().ToArray());
        }

        [Fact]
        public void ConstructFromArrayMaxPQTest()
        {
            ConstructFromArrayAndIterate(new MaxPQ<string>(array), topDown);
        }

        [Fact]
        public void ConstructFromArrayMinPQTest()
        {
            ConstructFromArrayAndIterate(new MinPQ<string>(array), topDown.Reverse().ToArray());
        }


        void InsertAllAndDeleteAll(ArrayPQBase<string> pq, string[] expected)
        {
            // default ctor, insert a bunch of values, then delete all
            Assert.True(pq.IsEmpty);
            var actual = Strings(pq).ToList();
            Assert.Equal(expected, actual);
        }

        void ConstructFromArrayAndIterate (ArrayPQBase<string> pq, string[] expected)
        {
            Assert.False(pq.IsEmpty);
            Assert.Equal(expected, pq.ToList());
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

        [Fact]
        public void Hamlet_MaxPQ()
        {
            // arrange
            var pq = new MaxPQ<string>();
            // act / assert
            ArrayPQHamlet(pq, hamlet_tops, hamlet_leftovers);
        }


        [Fact]
        public void Hamlet_UnorderedArrayMaxPQ()
        {
            ArrayPQHamlet(new UnorderedArrayMaxPQ<string>(), hamlet_tops, hamlet_leftovers);
        }

        [Fact]
        public void Hamlet_OrderedArrayMaxPQ()
        {
            ArrayPQHamlet(new OrderedArrayMaxPQ<string>(), hamlet_tops, hamlet_leftovers);
        }

        [Fact]
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
            Assert.True(pq.IsEmpty);

            // act
            var tops = Hamlet(pq).ToList();

            // assert
            Assert.False(pq.IsEmpty);
            Assert.Equal(2, pq.Size);

            // , String.Join("|", tops)
            Assert.Equal(expectedTops, tops);

            // , String.Join("|", leftovers)
            var leftovers = pq.ToArray();
            Assert.Equal(expectedLeftovers, leftovers);

            Assert.Equal(expectedLeftovers.Union(expectedTops).OrderBy(x => x), tops.Union(leftovers).OrderBy(x => x));
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

        [Fact]
        public void UnorderedArrayMaxPQ_SimpleTest()
        {
            var pq = new UnorderedArrayMaxPQ<string>(10);
            TestArrayMaxPQ(pq, ProduceArray);
        }

        [Fact]
        public void OrderedArrayMaxPQ_SimpleTest()
        {
            var pq = new OrderedArrayMaxPQ<string>(10);
            TestArrayMaxPQ(pq, ProduceArray);
        }

        [Fact]
        public void UnorderedArrayMaxPQ_Enumerate()
        {
            var pq = new UnorderedArrayMaxPQ<string>(10);
            TestArrayMaxPQ(pq, EnumerateArrayMax, false);
        }

        [Fact]
        public void OrderedArrayMaxPQ_Enumerate()
        {
            var pq = new OrderedArrayMaxPQ<string>(10);
            TestArrayMaxPQ(pq, EnumerateArrayMax, false);
        }

        void TestArrayMaxPQ(ArrayPQBase<string> pq, ArrayMaxPQProducer f, bool IsConsumer = true)
        {
            var maxes = f(pq).ToArray();
            if (IsConsumer) Assert.True(pq.IsEmpty);
            Assert.Equal(new string[] { "this", "test", "is", "a" }, maxes);
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
            Assert.Equal('Q', pq.Delete());
            pq.Insert('X');
            pq.Insert('A');
            pq.Insert('M');
            Assert.Equal('X', pq.Delete());
            pq.Insert('P');
            pq.Insert('L');
            pq.Insert('E');
            Assert.Equal('P', pq.Delete());
            Assert.Equal(6, pq.Size);
            Assert.Equal(new char[] { 'P', 'M', 'L', 'E', 'E', 'A' }, pq.ToArray());
        }

        [Fact]
        void SequenceOfOperations_MaxPQ()
        {
            var pq = new MaxPQ<char>(10);
            SequenceOfOperations(pq);
        }
        [Fact]
        void SequenceOfOperations_OrderedArrayMaxPQ()
        {
            var pq = new OrderedArrayMaxPQ<char>(10);
            SequenceOfOperations(pq);
        }
        [Fact]
        void SequenceOfOperations_UnOrderedArrayMaxPQ()
        {
            var pq = new UnorderedArrayMaxPQ<char>(10);
            SequenceOfOperations(pq);
        }
    }
}
