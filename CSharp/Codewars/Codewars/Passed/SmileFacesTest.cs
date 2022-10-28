using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    [TestFixture]
    public class SmileFacesTest
    {
        [Test]
        public void BasicTest()
        {
            Assert.AreEqual(4, Codewars.Passed.Kata.CountSmileys(new string[] { ":D", ":~)", ";~D", ":)" }));
            Assert.AreEqual(2, Codewars.Passed.Kata.CountSmileys(new string[] { ":)", ":(", ":D", ":O", ":;" }));
            Assert.AreEqual(1, Codewars.Passed.Kata.CountSmileys(new string[] { ";]", ":[", ";*", ":$", ";-D" }));
            Assert.AreEqual(0, Codewars.Passed.Kata.CountSmileys(new string[] { ";", ")", ";*", ":$", "8-D" }));
        }
    }
}