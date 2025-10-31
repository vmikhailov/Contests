using NUnit.Framework.Legacy;
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
		ClassicAssert.IsTrue(PalindromeNumber.IsPalindrome(7));
		ClassicAssert.IsTrue(PalindromeNumber.IsPalindrome(0));
	}

	[Test]
	public void IsPalindrome_PalindromeNumber_ReturnsTrue()
	{
		ClassicAssert.IsTrue(PalindromeNumber.IsPalindrome(121));
		ClassicAssert.IsTrue(PalindromeNumber.IsPalindrome(12321));
	}

	[Test]
	public void IsPalindrome_NonPalindromeNumber_ReturnsFalse()
	{
		ClassicAssert.IsFalse(PalindromeNumber.IsPalindrome(123));
		ClassicAssert.IsFalse(PalindromeNumber.IsPalindrome(10));
	}

	[Test]
	public void IsPalindrome_NegativeNumber_ReturnsFalse()
	{
		ClassicAssert.IsFalse(PalindromeNumber.IsPalindrome(-121));
	}

	[Test]
	public void IsPalindrome_EvenLengthPalindrome_ReturnsTrue()
	{
		ClassicAssert.IsTrue(PalindromeNumber.IsPalindrome(1221));
	}
}
