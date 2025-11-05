using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks2025;

public class CountAndSayTask
{
    /*The count-and-say sequence is a sequence of digit strings defined by the recursive formula:

       countAndSay(1) = "1"
       countAndSay(n) is the run-length encoding of countAndSay(n - 1).
       Run-length encoding (RLE) is a string compression method that works by replacing consecutive identical characters (repeated 2 or more times) with the concatenation of the character and the number marking the count of the characters (length of the run). For example, to compress the string "3322251" we replace "33" with "23", replace "222" with "32", replace "5" with "15" and replace "1" with "11". Thus the compressed string becomes "23321511".

       Given a positive integer n, return the nth element of the count-and-say sequence.
       */

    public string CountAndSay(int n)
    {
        var sb = new StringBuilder("1");

        for (var i = 2; i <= n; i++)
        {
            sb = Rle(sb);
        }

        return sb.ToString();

        StringBuilder Rle(StringBuilder s)
        {
            var r = new StringBuilder();
            var k = 1;
            var p = s[0];

            for (var i = 1; i < s.Length; i++)
            {
                var c = s[i];

                if (c == p)
                {
                    k++;
                }
                else
                {
                    r.Append($"{k}{p}");
                    p = c;
                    k = 1;
                }
            }
            r.Append($"{k}{p}");
            return r;
        }
    }

    [TestFixture]
    public class CountAndSayTaskTests
    {
        private CountAndSayTask _task = null!;

        [SetUp]
        public void SetUp() => _task = new CountAndSayTask();

        [Test]
        public void CountAndSay_N1_Returns1()
        {
            // Base case: countAndSay(1) = "1"
            _task.CountAndSay(1).Should().Be("1");
        }

        [Test]
        public void CountAndSay_N2_Returns11()
        {
            // countAndSay(2) is RLE of "1" = "11" (one 1)
            _task.CountAndSay(2).Should().Be("11");
        }

        [Test]
        public void CountAndSay_N3_Returns21()
        {
            // countAndSay(3) is RLE of "11" = "21" (two 1s)
            _task.CountAndSay(3).Should().Be("21");
        }

        [Test]
        public void CountAndSay_N4_Returns1211()
        {
            // countAndSay(4) is RLE of "21" = "1211" (one 2, one 1)
            _task.CountAndSay(4).Should().Be("1211");
        }

        [Test]
        public void CountAndSay_N5_Returns111221()
        {
            // countAndSay(5) is RLE of "1211" = "111221" (one 1, one 2, two 1s)
            _task.CountAndSay(5).Should().Be("111221");
        }

        [Test]
        public void CountAndSay_N6_Returns312211()
        {
            // countAndSay(6) is RLE of "111221" = "312211" (three 1s, two 2s, one 1)
            _task.CountAndSay(6).Should().Be("312211");
        }

        [Test]
        public void CountAndSay_N7_Returns13112221()
        {
            // countAndSay(7) is RLE of "312211"
            _task.CountAndSay(7).Should().Be("13112221");
        }

        [Test]
        public void CountAndSay_N8_Returns1113213211()
        {
            // countAndSay(8) is RLE of "13112221"
            _task.CountAndSay(8).Should().Be("1113213211");
        }

        [Test]
        public void CountAndSay_N9_Returns31131211131221()
        {
            // countAndSay(9) is RLE of "1113213211"
            _task.CountAndSay(9).Should().Be("31131211131221");
        }

        [Test]
        public void CountAndSay_N10_Returns13211311123113112211()
        {
            // countAndSay(10) is RLE of "31131211131221"
            _task.CountAndSay(10).Should().Be("13211311123113112211");
        }
    }
}
