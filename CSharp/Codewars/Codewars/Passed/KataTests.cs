using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    [TestFixture]
    public class KataTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual("(((", Codewars.Passed.Kata.DuplicateEncode("din"));
            Assert.AreEqual("()()()", Codewars.Passed.Kata.DuplicateEncode("recede"));
            Assert.AreEqual(")())())", Codewars.Passed.Kata.DuplicateEncode("Success"), "should ignore case");
            Assert.AreEqual("))((", Codewars.Passed.Kata.DuplicateEncode("(( @"));
        }
    }
}