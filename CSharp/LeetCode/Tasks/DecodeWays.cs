using FluentAssertions;
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
		DecodeWays.Decode("1").Should().Be(1);
		DecodeWays.Decode("2").Should().Be(2);
	}

	[Test]
	public void Decode_TwoDigits_ReturnsCorrect()
	{
		DecodeWays.Decode("12").Should().Be(12);
		DecodeWays.Decode("26").Should().Be(26);
	}

	[Test]
	public void Decode_InvalidNumber_ReturnsMinusOne()
	{
		DecodeWays.Decode("27").Should().Be(-1);
		DecodeWays.Decode("99").Should().Be(-1);
	}

	[Test]
	public void Decode_WithZero_ReturnsCorrect()
	{
		DecodeWays.Decode("10").Should().Be(10);
		DecodeWays.Decode("20").Should().Be(20);
	}

	[Test]
	public void Decode_MultipleDigits_ReturnsCorrect()
	{
		DecodeWays.Decode("123").Should().Be(123);
	}
}
