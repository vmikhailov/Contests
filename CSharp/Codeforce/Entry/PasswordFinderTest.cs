using NUnit.Framework;

namespace Codewars.Entry
{
    [TestFixture]
    public class PasswordFinderTest
    {
        [Test]
        public void Test0()
        {
            Assert.AreEqual(@"caba", PasswordFinder.FindPassword(@"abacaba", "abc", 4));
        }
        
        [Test]
        public void Test1()
        {
            Assert.AreEqual(@"abc", PasswordFinder.FindPassword(@"abacabacaabc", "abc", 4));
        }
       
        
        [Test]
        public void Test2()
        {
            Assert.AreEqual(@"cab", PasswordFinder.FindPassword(@"abacaba", "abc", 3));
        }
        
        [Test]
        public void Test3()
        {
            Assert.AreEqual(@"cabb", PasswordFinder.FindPassword(@"abacabaababcbabcacbabacacbbcbaccbabcacbacbcbbcaccbbcacccabba", "abc", 4));
        }
        
        [Test]
        public void Test4()
        {
            Assert.AreEqual(@"bca", PasswordFinder.FindPassword(@"bcaab", "abc", 3));
        }
    }
}