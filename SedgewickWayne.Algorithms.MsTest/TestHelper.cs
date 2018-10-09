namespace SedgewickWayne.Algorithms.MsTest
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net;

    public static class TestHelper
    {
        internal const string LINKED_LIST = "linked list";
        internal const string UNORDERED_ARRAY = "unordered array";
        internal const string BINARY_SEARCH = "binary search";
        internal const string BST = "binary search tree";

        internal static ISymbolTable<TKey, TValue> Factory<TKey, TValue>(string symbolTableType)
           where TKey : IComparable<TKey>, IEquatable<TKey>
            where TValue : IEquatable<TValue>
        {
            switch (symbolTableType)
            {
                case LINKED_LIST:
                case nameof(SequentialSearchST<TKey, TValue>):
                    return new SequentialSearchST<TKey, TValue>();

                case UNORDERED_ARRAY: return new ArrayST<TKey, TValue>();
                case BINARY_SEARCH: return new BinarySearchST<TKey, TValue>();
                case BST: return new BST<TKey, TValue>();
                default: return null;
            }
        }
    }
}
