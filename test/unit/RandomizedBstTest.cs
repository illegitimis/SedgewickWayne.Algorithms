namespace SedgewickWayne.Algorithms.UnitTests
{
using System;
using System.Linq;
using Xunit;

    public class RandomizedBstTest
    {
        const string PrincetonUri = "www.cs.princeton.edu";
        const string SimpsonsUri = "www.simpsons.com";

        [Fact]
        public void Dns()
        {
            var st = new RandomizedBST<string, string>();
            // insert some key-value pairs
            st.Put(PrincetonUri, "128.112.136.11");
            // overwrite old value
            st.Put(PrincetonUri, "128.112.136.35");    
            st.Put("www.princeton.edu", "128.112.130.211");
            st.Put("www.math.princeton.edu", "128.112.18.11");
            st.Put("www.yale.edu", "130.132.51.8");
            st.Put("www.amazon.com", "207.171.163.90");
            st.Put(SimpsonsUri, "209.123.16.34");
            st.Put("www.stanford.edu", "171.67.16.120");
            st.Put("www.google.com", "64.233.161.99");
            st.Put("www.ibm.com", "129.42.16.99");
            st.Put("www.apple.com", "17.254.0.91");
            st.Put("www.slashdot.com", "66.35.250.150");
            st.Put("www.whitehouse.gov", "204.153.49.136");
            st.Put("www.espn.com", "199.181.132.250");
            st.Put("www.snopes.com", "66.165.133.65");
            st.Put("www.movies.com", "199.181.132.250");
            st.Put("www.cnn.com", "64.236.16.20");
            st.Put("www.iitb.ac.in", "202.68.145.210");

            Assert.NotNull(st.Get(PrincetonUri));
            Assert.Null(st.Get("www.harvardsucks.com"));
            Assert.NotNull(st.Get(SimpsonsUri));

            Assert.Equal(17, st.Size);
            Assert.Equal("www.yale.edu", st.Max);
            Assert.Equal("www.amazon.com", st.Min);

            Assert.Equal(SimpsonsUri, st.Ceiling(SimpsonsUri));
            Assert.Equal(SimpsonsUri, st.Ceiling("www.simpsonr.com"));
            Assert.Equal("www.slashdot.com", st.Ceiling("www.simpsont.com"));
        }
    }
}
