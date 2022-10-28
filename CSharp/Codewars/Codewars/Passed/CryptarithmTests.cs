using System.Linq;
using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    [TestFixture]
    public class CryptarithmTests
    {
        [Test, Description("5 Example Tests"), TestCaseSource("Examples")]
        public static void ExampleTest(string s)
        {
            var z = s.Split(" -> ").Select(e => e.Substring(1, e.Length - 2)).ToArray();
            Assert.That(Cryptarithm.Alphametics(z[0]), Is.EqualTo(z[1]));
        }

        private static string[] Examples =
        {
            //"\"ELEVEN + NINE + FIVE + FIVE = THIRTY\" -> \"797275 + 5057 + 4027 + 4027 = 810386\"",
            "\"SEND + MORE = MONEY\" -> \"9567 + 1085 = 10652\"",
            "\"ZEROES + ONES = BINARY\" -> \"698392 + 3192 = 701584\"",
            "\"COUPLE + COUPLE = QUARTET\" -> \"653924 + 653924 = 1307848\"",
            "\"DO + YOU + FEEL = LUCKY\" -> \"57 + 870 + 9441 = 10368\"",
            "\"ELEVEN + NINE + FIVE + FIVE = THIRTY\" -> \"797275 + 5057 + 4027 + 4027 = 810386\"",
            "\"ZJ + AOJ + RRB = ZRU\" -> \"73 + 523 + 114 = 710\""
        };
    }
}