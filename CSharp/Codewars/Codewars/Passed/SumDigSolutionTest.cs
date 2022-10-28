using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    [TestFixture]
    public class SumDigSolutionTest
    {
        [Test]
        public void ExampleTests()
        {
            Assert.AreEqual(1999, SumDigSolution.solve(2090));
            Assert.AreEqual(1, SumDigSolution.solve(1));
            Assert.AreEqual(2, SumDigSolution.solve(2));     
            Assert.AreEqual(18, SumDigSolution.solve(18));
            Assert.AreEqual(48, SumDigSolution.solve(48));
            Assert.AreEqual(99, SumDigSolution.solve(100));
            Assert.AreEqual(9, SumDigSolution.solve(10));     
            Assert.AreEqual(99, SumDigSolution.solve(110));
            Assert.AreEqual(1999, SumDigSolution.solve(2090));
            Assert.AreEqual(999999999989, SumDigSolution.solve(999999999992));
   
        }
    }
}