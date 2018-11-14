namespace SedgewickWayne.Algorithms.UnitTests
{
    using System;

    public static class TestHelper
    {
        internal const string LINKED_LIST = "linked list";
        internal const string UNORDERED_ARRAY = "unordered array";
        internal const string BINARY_SEARCH = "binary search";
        internal const string BST = "binary search tree";
        internal const string LINEAR_PROBING = "linear probing";
        internal const string NON_RECURSIVE_BST = "non recursive bst";
        internal const string RANDOMIZED_BST = "randomized bst";
        internal const string RED_BLACK_BST = "red black bst";

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

                case LINEAR_PROBING: return new LinearProbingHashST<TKey, TValue>();

                case NON_RECURSIVE_BST: return new NonrecursiveBST<TKey, TValue>();

                case RANDOMIZED_BST:
                case nameof(RandomizedBST<TKey, TValue>): return new RandomizedBST<TKey, TValue>();

                case RED_BLACK_BST:
                case nameof(RedBlackBST<TKey, TValue>): return new RedBlackBST<TKey, TValue>();

                default: return null;
            }
        }
    }
}
