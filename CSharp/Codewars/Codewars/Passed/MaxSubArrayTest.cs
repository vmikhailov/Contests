using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    [TestFixture]
    public class MaxSubArrayTest
    {
        [Test]
        public void Test0()
        {
            Assert.AreEqual(0, MaxSubArray.MaxSequence([]));
        }
        [Test]
        public void Test1()
        {
            Assert.AreEqual(6, MaxSubArray.MaxSequence([-2, 1, -3, 4, -1, 2, 1, -5, 4]));
        }
    }
}