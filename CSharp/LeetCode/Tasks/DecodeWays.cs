using NUnit.Framework.Legacy;
using NUnit.Framework;

namespace CodeForcesSimple.LeetCode;

public class DecodeWays
{
	public static int Decode(string s)
	{
		int Decode(string s, int i)
		{
			if (i < 0)
			{
				return 0;
			}
			
			var d = s[i] - '0';

			var f = Decode(s, i - 1);
			if (f >= 0)
			{
				return d + f * 10;
			}

			if (i == 0)
			{
				return -1;
			}
			
			d += (s[i - 1] - '0') * 10;
			if (d > 26)
			{
				return -1;
			}

			f = Decode(s, i - 2);
			if (f >= 0)
			{
				return d + f * 100;
			}

			return -1;
		}

		return Decode(s, s.Length - 1);
	}
}

[TestFixture]
public class DecodeWaysTests
{
	[Test]
	public void Decode_SingleDigit_ReturnsCorrect()
	{
		ClassicAssert.AreEqual(1, DecodeWays.Decode("1"));
		ClassicAssert.AreEqual(2, DecodeWays.Decode("2"));
	}

	[Test]
	public void Decode_TwoDigits_ReturnsCorrect()
	{
		ClassicAssert.AreEqual(12, DecodeWays.Decode("12"));
		ClassicAssert.AreEqual(26, DecodeWays.Decode("26"));
	}

	[Test]
	public void Decode_InvalidNumber_ReturnsMinusOne()
	{
		ClassicAssert.AreEqual(-1, DecodeWays.Decode("27"));
		ClassicAssert.AreEqual(-1, DecodeWays.Decode("99"));
	}

	[Test]
	public void Decode_WithZero_ReturnsCorrect()
	{
		ClassicAssert.AreEqual(10, DecodeWays.Decode("10"));
		ClassicAssert.AreEqual(20, DecodeWays.Decode("20"));
	}

	[Test]
	public void Decode_MultipleDigits_ReturnsCorrect()
	{
		ClassicAssert.AreEqual(123, DecodeWays.Decode("123"));
	}
}
