namespace SedgewickWayne.Algorithms.UnitTests
{
    using System.Linq;
    using Xunit;
    using static SedgewickWayne.Algorithms.UnitTests.Constants;

    public class SplayTreeSimpleTests
    {
        [Fact]
        public void IntegerKeysAndValues()
        {
            var st = new SplayBST<int, int>();

            st.Put(5, 5);
            Assert.Equal(1, st.Size);

            st.Put(9, 9);
            Assert.Equal(2, st.Size);
            Assert.Equal(new[] { 9, 5 }, st.ToArray());

            st.Put(13, 13);
            Assert.Equal(new[] { 13, 9, 5 }, st.ToArray());
            
            st.Put(11, 11);
            Assert.Equal(new[] { 11, 9, 5, 13 }, st.ToArray());

            st.Put(1, 1);
            Assert.Equal(new[] { 1, 5, 9, 11, 13 }, st.ToArray());
        }

        [Fact]
        public void UniversitiesDns()
        {
            var st = new SplayBST<string, string>();
            st.Put(CsPrincetonEdu, "128.112.136.11");
            st.Put(CsPrincetonEdu, "128.112.136.12");
            st.Put(CsPrincetonEdu, "128.112.136.13");
            st.Put("www.princeton.edu", "128.112.128.15");
            st.Put(YaleEdu, "130.132.143.21");
            st.Put(SimpsonsCom, "209.052.165.60");
            Assert.Equal(4, st.Size);
                        
            st.Delete(YaleEdu);
            Assert.Equal(3, st.Size);

            st.Delete("www.princeton.edu");
            Assert.Equal(2, st.Size);

            st.Delete("non-member");
            Assert.Equal(2, st.Size);

            Assert.Null(st.Get(YaleEdu));
            Assert.NotNull (st.Get(CsPrincetonEdu));
            Assert.NotNull(st.Get(SimpsonsCom));
            
        }
    }
}
