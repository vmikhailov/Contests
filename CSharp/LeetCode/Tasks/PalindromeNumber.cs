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
			if (a != b) return false;
			x = (int)(x - a * n - b) / 10;
			n /= 100;
		}

		return true;
	}
}