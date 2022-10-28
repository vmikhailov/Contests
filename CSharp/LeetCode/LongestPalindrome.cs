namespace LeetCode;

public class LongestPalindrome
{
	public string GetLongestPalindrome(string s)
	{
		var max = "";
		if (s.Length == 1 || s.Length == 2 && s[0] == s[1]) return s; 
		
		for (var i = 0; i < s.Length - 1; i++)
		{
			string p;
			if (TryPalindrome(s, i, i, out p) && p.Length > max.Length) max = p;
			if (TryPalindrome(s, i, i + 1, out p) && p.Length > max.Length) max = p;
		}

		return max;
	}

	public bool TryPalindrome(string s, int i, int j, out string p)
	{
		while (i >= 0 && j < s.Length && s[i] == s[j])
		{
			i--;
			j++;
		}

		p = s[(i+1)..j];
		return j - i > 1;
	}

	public string GetLongestCommon(string str1, string str2)
	{
		return GetLongestCommon(str1.ToCharArray(), str2.ToCharArray());
	}

	public string GetLongestCommon(char[] str1, char[] str2)
	{
		var n1 = str1.Length;
		var n2 = str2.Length;

		var m = new int[n1 + 1, n2 + 1];

		for (var i = 0; i <= n1; i++) m[i, 0] = 0;
		for (var i = 0; i <= n2; i++) m[0, i] = 0;
		

		var max = 0;
		var max_i = 0;
		var max_j = 0;
		var prev = new List<int>();

		for (var i = 1; i <= n1; i++)
		{
			for (var j = 1; j <= n2; j++)
			{
				if (str1[i - 1] == str2[j - 1])
				{
					m[i, j] = m[i - 1, j - 1] + 1;
					if (m[i, j] > max)
					{
						max_i = i;
						max_j = j;
						max = m[i, j];
					}
				}
			}
		}
		
		Print(m);
		
		var result = str1[(max_i - max)..max_i];
		return new(result);
	}

	private void Print(int[,] m)
	{
		for (var i = 0; i < m.GetLength(0); i++)
		{
			for (var j = 0; j < m.GetLength(1); j++)
			{
				Console.Write($"{m[i,j]} ");
			}	
			Console.WriteLine();
		}
	}
}