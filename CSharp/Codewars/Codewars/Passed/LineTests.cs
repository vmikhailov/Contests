using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    [TestFixture]
    public class LineTests
    {
        [Test]
        public void Test1()
        {
            var names = new string[] { "Sheldon", "Leonard", "Penny", "Rajesh", "Howard" };
            var n = 1;
            Assert.AreEqual("Sheldon", Line.WhoIsNext(names, n));
        }

        [Test]
        public void Test2()
        {
            var names = new string[] { "Sheldon", "Leonard", "Penny", "Rajesh", "Howard" };
            var n = 18;
            Assert.AreEqual("Sheldon", Line.WhoIsNext(names, n));
        }
    
        [Test]
        public void Test3()
        {
            var names = new string[] { "Sheldon", "Leonard", "Penny", "Rajesh", "Howard" };
            var n = 159222638;
            Assert.AreEqual("Howard", Line.WhoIsNext(names, n));
        }
    }
}