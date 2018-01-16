
namespace SedgewickWayne.Algorithms.MsTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using SedgewickWayne.Algorithms;


    internal delegate void SortDelegate<T>(T[] a);

    [TestClass]
    public class SortingTests
    {
        static readonly char[] tiny = new char[] { 'S', 'O', 'R', 'T', 'E', 'X', 'A', 'M', 'P', 'L', 'E' };
        static readonly char[] inty = new char[] { 'A', 'E', 'E', 'L', 'M', 'O', 'P', 'R', 'S', 'T', 'X' };

        static readonly string[] words3 = new string[] {
            "bed", "bug", "dad", "yes", "zoo",
            "now", "for", "tip", "ilk", "dim",
            "tag", "jot", "sob", "nob", "sky",
            "hut", "men", "egg", "few", "jay",
            "owl", "joy", "rap", "gig", "wee",
            "was", "wad", "fee", "tap", "tar",
            "dug", "jam", "all", "bad", "yet",
        };

        static readonly string[] dorsw = new string[] {
            "all", "bad", "bed", "bug", "dad",
            "dim", "dug", "egg", "fee", "few",
            "for", "gig", "hut", "ilk", "jam",
            "jay", "jot", "joy", "men", "nob",
            "now", "owl", "rap", "sky", "sob",
            "tag", "tap", "tar", "tip", "wad",
            "was", "wee", "yes", "yet", "zoo",
        };


        /// <summary>
        ///  http://algs4.cs.princeton.edu/21elementary/tiny.txt
        ///  % more tiny.txt
        ///  S O R T E X A M P L E
        ///  A E E L M O P R S T X
        /// </summary>
        [TestMethod]
        public void TinySort()
        {
            var characterArraySorters = new SortDelegate<char>[]
            {
                BinaryInsertion<char>.Sort,
                Heap<char>.Sort,
                Insertion<char>.Sort,
                InsertionX<char>.Sort,
                Merge<char>.Sort,
                MergeBU<char>.Sort,
                MergeX<char>.Sort,
                Quick<char>.Sort,
                Quick3Way<char>.Sort,
                QuickX<char>.Sort,
                Shell<char>.Sort,
            };

            foreach (var sorter in characterArraySorters)
                TinySortStep(sorter);
        }

        void TinySortStep(SortDelegate<char> characterArraySorter)
        {
            var copy = new char[11];
            Array.Copy(tiny, copy, 11);

            characterArraySorter(copy);
            Assert.IsNotNull(copy);
            CollectionAssert.AreEqual(inty, copy, characterArraySorter.Method.DeclaringType.Name);
        }

        /// <summary>
        ///  http://algs4.cs.princeton.edu/21elementary/words3.txt    
        ///  % more words3.txt
        ///  bed bug dad yes zoo ... all bad yet
        ///  all bad bed bug dad ... yes yet zoo    [ one string per line ] 
        /// </summary>
        [TestMethod]
        public void ThreeLetterWordsSort()
        {
            foreach (var sorter in new SortDelegate<string>[]
            {
                BinaryInsertion<string>.Sort,
                Heap<string>.Sort,
                Insertion<string>.Sort,
                InsertionX<string>.Sort,
                Merge<string>.Sort,
                MergeBU<string>.Sort,
                MergeX<string>.Sort,
                Quick<string>.Sort,
                Quick3Way<string>.Sort,
                QuickX<string>.Sort,
                Shell<string>.Sort,
            })
            {
                var copy = new string[35];
                Array.Copy(words3, copy, 35);

                sorter(copy);
                Assert.IsNotNull(copy);
                CollectionAssert.AreEqual(dorsw, copy, sorter.Method.DeclaringType.Name);
            }
        }
    }
}
