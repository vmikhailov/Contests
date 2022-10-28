using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    [TestFixture]
    public class ExpandedForm
    {
        [Test]
        public void BasicTest()
        {
            Assert.That(Kata.ExpandedForm(12), Is.EqualTo("10 + 2"));
            Assert.That(Kata.ExpandedForm(42), Is.EqualTo("40 + 2"));
            Assert.That(Kata.ExpandedForm(70304), Is.EqualTo("70000 + 300 + 4"));
            Assert.That(Kata.ExpandedForm(9876543210123), Is.EqualTo("70000 + 300 + 4"));
        }
    }
}