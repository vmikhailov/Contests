using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    [TestFixture]
    public class DecomposeTests {

        [Test]
        public void Test1() {
            var d = new Decompose();
            var a1 = d.decompose(10000);
            var a2 = d.decompose(10000441);
            Assert.AreEqual("1 2 4 10", d.decompose(3*25));
            Assert.AreEqual("1 3 5 8 49", d.decompose(50));
            Assert.AreEqual("1 2 4 10", d.decompose(11));
        }
    }
}