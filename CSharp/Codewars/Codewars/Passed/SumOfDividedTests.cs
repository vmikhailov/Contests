using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    [TestFixture]
    public class SumOfDividedTests {

        [Test]
        public void Test1() {
            var lst = new int[] {12, 15};
            Assert.AreEqual("(2 12)(3 27)(5 15)", SumOfDivided.sumOfDivided(lst));
        }
    }
}