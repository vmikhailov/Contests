using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    [TestFixture]
    public class InfiniteDigitalStringTests
    {
        [TestCase("01")]
        [TestCase("0910")]
        [TestCase("0991")]
        [TestCase("09910")]
        [TestCase("09991")]
        [TestCase("667")]
        [TestCase("123")]
        [TestCase("456")]
        [TestCase("454")]
        [TestCase("455")]
        [TestCase("123456789")]
        [TestCase("1234567891")]
        [TestCase("53635")]
        [TestCase("00101")]
        [TestCase("00")]
        [TestCase("000000")]
        [TestCase("09")]
        [TestCase("100")]
        [TestCase("10000")]
        [TestCase("10001")]
        [TestCase("8899")]
        [TestCase("949225100")]
        [TestCase("58257860625")]
        [TestCase("3999589058124")]
        [TestCase("555899959741198")]
        public void PatternTests(string str)
        {
            InfiniteDigitalString2.findPosition(str);
        }

        [TestCase(10, "01")]
        [TestCase(190, "00")]
        [TestCase(170, "091")]
        [TestCase(2927, "0910")]
        [TestCase(2617, "0991")]
        [TestCase(2617, "09910")]
        [TestCase(35286, "09991")]
        [TestCase(3, "456", "...3456...")]
        [TestCase(79, "454", "...444546...")]
        [TestCase(98, "455", "...545556...")]
        [TestCase(8, "910", "...7891011...")]
        [TestCase(188, "9100", "...9899100...")]
        [TestCase(187, "99100", "...9899100...")]
        [TestCase(190, "00101", "...9899100...")]
        [TestCase(190, "001", "...9899100...")]
        [TestCase(190, "00", "...9899100...")]
        [TestCase(0, "123456789")]
        [TestCase(0, "1234567891")]
        [TestCase(1000000071, "123456798")]
        [TestCase(9, "10")]
        [TestCase(13034, "53635")]
        [TestCase(1091, "040")]
        [TestCase(11, "11")]
        [TestCase(168, "99")]
        [TestCase(15050, "0404")]
        [TestCase(382689688L, "949225100")]
        [TestCase(24674951477L, "58257860625")]
        [TestCase(6957586376885L, "3999589058124")]
        [TestCase(1686722738828503L, "555899959741198")]
        [TestCase(3950281, "986768")]
        public void FixedTests(long expected, string str, string comment = null)
        {
            Assert.AreEqual(expected, InfiniteDigitalString2.findPosition(str));
        }
    }
}