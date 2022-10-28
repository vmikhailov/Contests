using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    [TestFixture]
    public class DirReductionTests {

        [Test]
        public void Test1() {
            var a = new string[] {"NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST"};
            var b = new string[] {"WEST"};
            Assert.AreEqual(b, DirReduction.dirReduc(a));
        }
        [Test]
        public void Test2() {
            var a = new string[] {"NORTH", "WEST", "SOUTH", "EAST"};
            var b = new string[] {"NORTH", "WEST", "SOUTH", "EAST"};
            Assert.AreEqual(b, DirReduction.dirReduc(a));
        }
    }
}