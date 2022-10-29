using System.Text;

namespace LeetCode;

public class Anagrams
{
	public IList<IList<string>> GroupAnagrams(string[] strs)
	{
		var r = strs.GroupBy(x => new string(x.OrderBy(y => y).ToArray()))
		            .Select(x => (IList<string>)x.ToList())
		            .ToList();

		return r;
	}
}

public class LetterCombinations
{
	public static IList<string> Solve(string digits)
	{
		var map = new Dictionary<int, char[]>()
		{
			{ '2', "abc".ToCharArray() },
			{ '3', "def".ToCharArray() },
			{ '4', "ghi".ToCharArray() },
			{ '5', "jkl".ToCharArray() },
			{ '6', "mno".ToCharArray() },
			{ '7', "pqrs".ToCharArray() },
			{ '8', "tuv".ToCharArray() },
			{ '9', "wxyz".ToCharArray() }
		};

		var n = 1;
		foreach (var c in digits)
		{
			n *= map[c].Length;
		}

		var r = new List<string>();
		for (var i = 0; i < n; i++)
		{
			var j = i;
			var sb = new StringBuilder(digits.Length);
			foreach (var c in digits)
			{
				var m = map[c];
				sb.Append(m[j % m.Length]);
				j /= m.Length;
			}

			if (sb.Length > 0)
			{
				r.Add(sb.ToString());
			}
		}

		return r;
	}
}