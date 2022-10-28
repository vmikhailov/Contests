using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    public class ProperFractionsSolutionTest
    {
        [Test]
        public void SmallNumbers()
        {
            ProperFractionsSolution.ProperFractions(40);
            ProperFractionsSolution.ProperFractions(60);
            ProperFractionsSolution.ProperFractions(120);
            ProperFractionsSolution.ProperFractions(30030);
            ProperFractionsSolution.ProperFractions(30030*2);
            
            //Assert.AreEqual(0, ProperFractionsSolution.ProperFractions(1));
            //Assert.AreEqual(1, ProperFractionsSolution.ProperFractions(2));
            //Assert.AreEqual(4, ProperFractionsSolution.ProperFractions(5));
            Assert.AreEqual(8, ProperFractionsSolution.ProperFractions(15));
            Assert.AreEqual(20, ProperFractionsSolution.ProperFractions(25));
        }
    
        [Test]
        public void LargeNumbers()
        {
            Assert.AreEqual(6637344, ProperFractionsSolution.ProperFractions(9999999));
            Assert.AreEqual(1805903026, ProperFractionsSolution.ProperFractions(1805903027));
        }
    }
}