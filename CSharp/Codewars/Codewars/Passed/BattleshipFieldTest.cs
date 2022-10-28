using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    [TestFixture]
    public class BattleshipFieldTest
    {
        [Test]
        public void TestCase1()
        {
            var field = new int[10, 10]
            {
                { 1, 0, 0, 0, 0, 1, 1, 0, 0, 0 },
                { 1, 0, 1, 0, 0, 0, 0, 0, 1, 0 },
                { 1, 0, 1, 0, 1, 1, 1, 0, 1, 0 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };
            Assert.IsTrue(BattleshipField.ValidateBattlefield(field));
        }
        
        [Test]
        public void TestCase2()
        {
            var field = new int[10, 10]
            {
                { 1, 0, 0, 0, 0, 1, 1, 0, 0, 0 },
                { 1, 0, 1, 0, 0, 0, 0, 0, 1, 0 },
                { 1, 0, 1, 0, 1, 1, 1, 0, 1, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };
            Assert.IsFalse(BattleshipField.ValidateBattlefield(field));
        }
        
        [Test]
        public void TestCase3()
        {
            var field = new int[10, 10]
            {
                { 1, 0, 0, 0, 0, 1, 1, 0, 0, 0 },
                { 1, 0, 1, 0, 0, 0, 0, 0, 1, 0 },
                { 1, 0, 1, 0, 1, 1, 1, 0, 1, 0 },
                { 1, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };
            Assert.IsFalse(BattleshipField.ValidateBattlefield(field));
        }
    }
}