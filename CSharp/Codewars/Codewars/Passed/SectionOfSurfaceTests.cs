using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    [TestFixture]
    public static class SectionOfSurfaceTests 
    {
        private static void testing(long n, int expected)
        {
            var actual = SectionOfSurface.C(n);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public static void test1()
        {
            testing(1, 1);
            testing(4, 4);
            testing(4096576, 160);
            testing(2019, 0);
            testing(5317636, 16);
            testing(2961841, 4);
            testing(13396105, 0);  	    
        }
    }
}