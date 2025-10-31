using FluentAssertions;
using NUnit.Framework;

namespace CodeForcesSimple.LeetCode;

public class PalindromeNumber
{
	public static bool IsPalindrome(int x)
	{
		var n = 1L;
		while (x > n * 10) n *= 10;
		while (x > 0)
		{
			var a = x / n;
			var b = x % 10;
			if (a != b)
			{
				return false;
			}

			x = (int)(x - a * n - b) / 10;
			n /= 100;
		}

		return true;
	}
}

[TestFixture]
public class PalindromeNumberTests
{
	[Test]
	public void IsPalindrome_SingleDigit_ReturnsTrue()
	{
		PalindromeNumber.IsPalindrome(7).Should().BeTrue();
		PalindromeNumber.IsPalindrome(0).Should().BeTrue();
	}

	[Test]
	public void IsPalindrome_PalindromeNumber_ReturnsTrue()
	{
		PalindromeNumber.IsPalindrome(121).Should().BeTrue();
		PalindromeNumber.IsPalindrome(12321).Should().BeTrue();
	}

	[Test]
	public void IsPalindrome_NonPalindromeNumber_ReturnsFalse()
	{
		PalindromeNumber.IsPalindrome(123).Should().BeFalse();
		PalindromeNumber.IsPalindrome(10).Should().BeFalse();
	}

	[Test]
	public void IsPalindrome_NegativeNumber_ReturnsFalse()
	{
		PalindromeNumber.IsPalindrome(-121).Should().BeFalse();
	}

	[Test]
	public void IsPalindrome_EvenLengthPalindrome_ReturnsTrue()
	{
		PalindromeNumber.IsPalindrome(1221).Should().BeTrue();
	}
}
