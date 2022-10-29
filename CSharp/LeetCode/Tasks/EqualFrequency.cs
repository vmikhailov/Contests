namespace LeetCode;

public class EqualFrequency
{
	public bool Solve(string word)
	{
		var chars = new int[26];

		foreach (var c in word) chars[c - 'a']++;

		var g = chars.Where(x => x != 0)
		             .GroupBy(x => x)
		             .Select(x => (x.Key, Count: x.Count()))
		             .ToList();

		switch (g.Count())
		{
			case 1:
				return g[0].Count == 1 || g[0].Key == 1;

			case 2:
				if (g.Any(x => x.Key == 1 && x.Count == 1)) return true;
				if (Math.Abs(g[0].Key - g[1].Key) > 1) return false;
				return g[0].Key + 1 == g[1].Key && g[1].Count == 1 ||
				       g[1].Key + 1 == g[0].Key && g[0].Count == 1;

			default:
				return false;
		}
	}
}