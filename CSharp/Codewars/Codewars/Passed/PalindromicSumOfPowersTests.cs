using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    [TestFixture]
    public class PalindromicSumOfPowersTests
    {
        [Test]
        public void ExampleTests()
        {
            Assert.AreEqual(3, PalindromicSumOfPowers.values(100));
            Assert.AreEqual(4, PalindromicSumOfPowers.values(200));    
            Assert.AreEqual(4, PalindromicSumOfPowers.values(300));
            Assert.AreEqual(5, PalindromicSumOfPowers.values(400));
            Assert.AreEqual(11, PalindromicSumOfPowers.values(1000));   
            Assert.AreEqual(59, PalindromicSumOfPowers.values(1000000));
            Assert.AreEqual(67, PalindromicSumOfPowers.values(2129364));

        }
    }
}