using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    [TestFixture]
    public class CodeWarsTests
    {
        [Test]
        public static void SimpleTest()
        {
            Assert.AreEqual("12345", CodeWars.crack("827ccb0eea8a706c4c34a16891f84e7b"));
        }
        [Test]
        public static void HarderTest()
        {
            Assert.AreEqual("00078", CodeWars.crack("86aa400b65433b608a9db30070ec60cd"));
        }
    }
}