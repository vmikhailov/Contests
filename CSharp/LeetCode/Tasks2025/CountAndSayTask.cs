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

    // Optimized version: works with strings directly and avoids StringBuilder indexing
    // Time complexity: O(n * m) where m is the length of the current string
    // Space complexity: O(m) for the result string
    public string CountAndSayOptimized(int n)
    {
        var result = "1";

        for (var i = 2; i <= n; i++)
        {
            result = RleString(result);
        }

        return result;
    }

    private string RleString(string s)
    {
        var r = new StringBuilder(s.Length * 2); // Pre-allocate capacity
        var count = 1;
        var prev = s[0];

        for (var i = 1; i < s.Length; i++)
        {
            var curr = s[i];

            if (curr == prev)
            {
                count++;
            }
            else
            {
                r.Append(count);     // Append int directly
                r.Append(prev);      // Append char directly
                prev = curr;
                count = 1;
            }
        }

        r.Append(count);
        r.Append(prev);

        return r.ToString();
    }

    // Most optimized version: uses ArrayPool to rent char arrays for zero-allocation performance
    // Time complexity: O(n * m) where m is the length of the current string
    // Space complexity: O(m) but with array pooling for better memory reuse
    public string CountAndSayArrayPool(int n)
    {
        var pool = System.Buffers.ArrayPool<char>.Shared;

        // Start with "1"
        var buf = pool.Rent(2);
        buf[0] = '1';
        var len = 1;

        for (var i = 2; i <= n; i++)
        {
            var nextBuf = pool.Rent(len * 4); // Estimate 2x growth with overhead
            var nextLen = RleCharArray(buf, len, nextBuf);

            pool.Return(buf);
            buf = nextBuf;
            len = nextLen;
        }

        var result = new string(buf, 0, len);
        pool.Return(buf);

        return result;
    }

    private int RleCharArray(char[] source, int sourceLength, char[] destination)
    {
        var destIndex = 0;
        var count = 1;
        var prev = source[0];

        for (var i = 1; i < sourceLength; i++)
        {
            var curr = source[i];

            if (curr == prev)
            {
                count++;
            }
            else
            {
                // Write count and character
                destIndex += WriteInteger(count, destination, destIndex);
                destination[destIndex++] = prev;

                prev = curr;
                count = 1;
            }
        }

        // Write final count and character
        destIndex += WriteInteger(count, destination, destIndex);
        destination[destIndex++] = prev;

        return destIndex;
    }

    // Efficiently writes an integer count to char array without string allocation
    private int WriteInteger(int num, char[] buffer, int startIndex)
    {
        // if (num < 10)
        // {
        //     buffer[startIndex] = (char)('0' + num);
        //     return 1;
        // }

        // Handle multi-digit counts (rare but possible for large sequences)
        var digits = 0;
        var temp = num;
        while (temp > 0)
        {
            temp /= 10;
            digits++;
        }

        for (var i = digits - 1; i >= 0; i--)
        {
            buffer[startIndex + i] = (char)('0' + (num % 10));
            num /= 10;
        }

        return digits;
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

        // Tests for optimized version
        [Test]
        public void CountAndSayOptimized_N1_Returns1()
        {
            _task.CountAndSayOptimized(1).Should().Be("1");
        }

        [Test]
        public void CountAndSayOptimized_N5_Returns111221()
        {
            _task.CountAndSayOptimized(5).Should().Be("111221");
        }

        [Test]
        public void CountAndSayOptimized_N10_Returns13211311123113112211()
        {
            _task.CountAndSayOptimized(10).Should().Be("13211311123113112211");
        }

        [Test]
        public void BothVersions_ProduceSameResults()
        {
            // Verify both implementations produce identical results
            for (int i = 1; i <= 15; i++)
            {
                _task.CountAndSay(i).Should().Be(_task.CountAndSayOptimized(i),
                    $"both versions should return the same result for n={i}");
            }
        }

        // Tests for ArrayPool version
        [Test]
        public void CountAndSayArrayPool_N1_Returns1()
        {
            _task.CountAndSayArrayPool(1).Should().Be("1");
        }

        [Test]
        public void CountAndSayArrayPool_N5_Returns111221()
        {
            _task.CountAndSayArrayPool(5).Should().Be("111221");
        }

        [Test]
        public void CountAndSayArrayPool_N10_Returns13211311123113112211()
        {
            _task.CountAndSayArrayPool(10).Should().Be("13211311123113112211");
        }

        [Test]
        public void AllVersions_ProduceSameResults()
        {
            // Verify all three implementations produce identical results
            for (int i = 1; i <= 20; i++)
            {
                var expected = _task.CountAndSay(i);
                _task.CountAndSayOptimized(i).Should().Be(expected,
                    $"optimized version should match for n={i}");
                _task.CountAndSayArrayPool(i).Should().Be(expected,
                    $"ArrayPool version should match for n={i}");
            }
        }

        [Test]
        public void CountAndSayArrayPool_LargeN_Works()
        {
            // Test with larger n to verify it handles longer sequences
            var result = _task.CountAndSayArrayPool(15);
            result.Should().NotBeNullOrEmpty();
            result.Should().Be(_task.CountAndSay(15));
        }
    }
}
