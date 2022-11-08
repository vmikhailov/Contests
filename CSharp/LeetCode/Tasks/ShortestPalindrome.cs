namespace LeetCode.Tasks;

public class ShortestPalindromeTask
{
	public string ShortestPalindrome(string s)
	{
		if (s.Length == 0) return "";
		var i = 0;
		var m = 1;
		var ss = s.AsSpan();
		while (i < ss.Length)
		{
			if (IsPalindrome(ss[..(i + 1)]))
			{
				m = i + 1;
			}

			i++;
		}

		return new(s[m..].Reverse().Concat(s).ToArray());
	}

	bool IsPalindrome(ReadOnlySpan<char> s)
	{
		var i = 0;
		var j = s.Length - 1;
		while (i < j && s[i] == s[j])
		{
			i++;
			j--;
		}

		return i >= j;
	}
}