

namespace SedgewickWayne.Algorithms.UnitTests
{
    internal static class PriorityQueueDefines
    {
        public static readonly string[] Array = new string[]
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

        public static readonly string[] TopDown = new string[]
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

        public static readonly string[] BottomUp = new []
        {
            "best",
            "it",
            "it",
            "of",
            "the",
            "the",
            "times",
            "was",
            "was",
            "worst",
        };

        public static readonly string[] IndexedMax = new string[]
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

        public static readonly string[] IndexedMin = new string[] {
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
    }
}
