using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    [TestFixture]
    public class SmileFacesTest
    {
        [Test]
        public void BasicTest()
        {
            Assert.AreEqual(4, Codewars.Passed.Kata.CountSmileys([":D", ":~)", ";~D", ":)"]));
            Assert.AreEqual(2, Codewars.Passed.Kata.CountSmileys([":)", ":(", ":D", ":O", ":;"]));
            Assert.AreEqual(1, Codewars.Passed.Kata.CountSmileys([";]", ":[", ";*", ":$", ";-D"]));
            Assert.AreEqual(0, Codewars.Passed.Kata.CountSmileys([";", ")", ";*", ":$", "8-D"]));
        }
    }
}