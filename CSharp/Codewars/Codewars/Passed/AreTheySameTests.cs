using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    [TestFixture]
    public class AreTheySameTests
    {
        [Test]
        public void Test1()
        {
            var a = new int[] { 121, 144, 19, 161, 19, 144, 19, 11, -4, 0 };
            var b = new int[] { 11 * 11, 121 * 121, 144 * 144, 19 * 19, 161 * 161, 19 * 19, 144 * 144, 19 * 19, 16, 0};
            var r = AreTheySame.comp(a, b); // True
            Assert.AreEqual(true, r);
        }
    
        [Test]
        public void Test2()
        {
            var a = new int[] { 2, 2, 3 };
            var b = new int[] { 4, 9, 4 };
            var r = AreTheySame.comp(a, b); // True
            Assert.AreEqual(true, r);
        }
    }
}