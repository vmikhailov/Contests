using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    [TestFixture]
    public class FractsTests {

        [Test]
        public void Test1() {
  
            var lst = new long[,] { {1, 20}, {1, 30}, {1, 40} };
            Assert.AreEqual("(6,120)(4,120)(3,120)", Fracts.convertFrac(lst));
  
        }
    
        [Test]
        public void Test2() {
  
            var lst = new long[,] { {1, 2}, {1, 3}, {1, 4} };
            Assert.AreEqual("(6,12)(4,12)(3,12)", Fracts.convertFrac(lst));
  
        }
    }
}