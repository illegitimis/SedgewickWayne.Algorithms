
namespace SedgewickWayne.Algorithms.UnitTests
{
    using System;
    using Xunit;
    using System.Linq;
    using SedgewickWayne.Algorithms;
    using System.IO;
    using System.Diagnostics;

    
    public class FundamentalsTests
    {
        [Fact]
        [Trait("Type", nameof(SetofInts))]
        public void SETofIntsThrowsExceptionIfInputArrayIsNotASet()
        {
            Assert.Throws<ArgumentException>(() => 
                new SetofInts(Enumerable.Range(20, 50).Concat(Enumerable.Range(30, 80)).ToArray()));
        }

        [Fact]
        [Trait("Type", nameof(SetofInts))]
        public void SETofIntsSetContainsTest()
        {
            var setInts = new SetofInts(Enumerable.Range(20, 50).ToArray());

            Assert.False(setInts.Contains(0));
            Assert.False(setInts.Contains(100));

            Assert.True(setInts.Contains(20));
            Assert.True(setInts.Contains(35));
            Assert.True(setInts.Contains(50));
        }

        [Fact]
        [Trait("Type", nameof(ThreeSumFast))]
        public void ThreeSumFastThrowsExceptionIfInputArrayContainsDuplicates()
        {
            Assert.Throws<ArgumentException>(() =>
                ThreeSumFast.Count(Enumerable.Range(20, 50).Concat(Enumerable.Range(30, 80)).ToArray()));
        }

   

        [Fact]
        [Trait("Type", nameof(Parantheses))]
        public void BalancedParanthesesTest ()
        {
            Assert.True(Parantheses.IsBalanced("[()]{ } {[()()]()}"));
            Assert.False(Parantheses.IsBalanced("[(])"));
        }

        // ( 1 + ( ( 2 + 3 ) * ( 4 * 5 ) ) )
        [Fact]
        [Trait("Type", nameof(Parantheses))]
        public void ArithmeticExpressionEvaluateTest()
        {
            Assert.Equal(101, Parantheses.Evaluate("( 1 + ( ( 2 + 3 ) * ( 4 * 5 ) ) )"), 6);
            Assert.Equal(1.618033988749895, Parantheses.Evaluate("( ( 1 + sqrt ( 5 ) ) / 2.0 )"), 6);
        }
    }
}


