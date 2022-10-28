using NUnit.Framework;

namespace Codewars.Codewars
{
    [TestFixture]
    public class FactorialDecompositionTests
    {
        [Test]
        public void Can_Be_Solved_With_Basic_Computations()
        {
            Assert.AreEqual(111, FactorialDecomposition.zeroes(111, 4039));
            Assert.AreEqual(617, FactorialDecomposition.zeroes(187, 9891));
            Assert.AreEqual(5, FactorialDecomposition.zeroes(221, 100));
            Assert.AreEqual(124, FactorialDecomposition.zeroes(256, 1000));
            Assert.AreEqual(249998, FactorialDecomposition.zeroes(10, 1000000));
            Assert.AreEqual(124999, FactorialDecomposition.zeroes(256, 1000000));

            Assert.AreEqual(104, FactorialDecomposition.zeroes(68, 1689));
            Assert.AreEqual(2, FactorialDecomposition.zeroes(16, 10));
            Assert.AreEqual(3, FactorialDecomposition.zeroes(16, 16));
            Assert.AreEqual(39, FactorialDecomposition.zeroes(16, 160));
           
        }
    }
}