using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    [TestFixture]
    public class BlockSeqTest{
        [Test]
        public void ExampleTests()
        {
            Assert.AreEqual(1, BlockSeq.solve(long.MaxValue));
            // Assert.AreEqual(0, BlockSeq.solve(56));
            // Assert.AreEqual(1, BlockSeq.solve(57));
            // Assert.AreEqual(2, BlockSeq.solve(58));
            // Assert.AreEqual(4, BlockSeq.solve(10));
            // Assert.AreEqual(1, BlockSeq.solve(11));
            // Assert.AreEqual(1, BlockSeq.solve(2));
            // Assert.AreEqual(2, BlockSeq.solve(3));
            for (long i = 1; i < 10000000; i++)
            {
                BlockSeq.solve(i);
            }
        
            Assert.AreEqual(3, BlockSeq.solve(101));
            Assert.AreEqual(3, BlockSeq.solve(123456789));
            Assert.AreEqual(4, BlockSeq.solve(999999999999999999));
            Assert.AreEqual(1, BlockSeq.solve(1000000000000000000));
            Assert.AreEqual(7, BlockSeq.solve(999999999999999993));
    
            Assert.AreEqual(4, BlockSeq.solve(999999999999999999));
        
            Assert.AreEqual(1, BlockSeq.solve(100));  
            Assert.AreEqual(4, BlockSeq.solve(14));  
            Assert.AreEqual(2, BlockSeq.solve(30));  

            Assert.AreEqual(1, BlockSeq.solve(100));  
            Assert.AreEqual(2, BlockSeq.solve(2100));
            Assert.AreEqual(2, BlockSeq.solve(3100));
            Assert.AreEqual(1, BlockSeq.solve(55));
            Assert.AreEqual(6, BlockSeq.solve(123456));
            Assert.AreEqual(3, BlockSeq.solve(123456789));  
            Assert.AreEqual(4, BlockSeq.solve(999999999999999999));

        }
    }
}