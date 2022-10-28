using NUnit.Framework;

namespace Codewars.Entry
{
    [TestFixture]
    public class OptimalWorkerTest
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(12, OptimalWorker.Compute("0 1 1 2 2 3 3 3", "0 10 11 5 6 1 2 1"));
        }
        
        [Test]
        public void Test2()
        {
            Assert.AreEqual(10, OptimalWorker.Compute("0 1 1 2 2 3 3 3 2", "0 10 11 5 6 1 2 1 0"));
        }
        
        [Test]
        public void Test3()
        {
            Assert.AreEqual(12, OptimalWorker.Compute("0 1 1 2 2 3 3", "0 10 11 5 6 1 2"));
            Assert.AreEqual(12, OptimalWorker.Compute("5 5 6 6 7 7 0", "5 6 1 2 10 11 0"));
            Assert.AreEqual(2, OptimalWorker.Compute("0 1 1 3 3 5 5 7 7", "1 1 1 1 1 1 1 1 1"));
            Assert.AreEqual(1, OptimalWorker.Compute("0 1 1 1 1 1 1 1 1 1 1 1 1 1 1", "0 1 2 2 2 3 3 3 1 1 1 1 1 1 1"));
        }
    }
}