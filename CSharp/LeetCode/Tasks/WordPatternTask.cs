using System.Text;

namespace LeetCode.Tasks;

public class WordPatternTask
{
	public bool WordPattern(string pattern, string s)
	{
		var ss = s.Split(" ");
		var r = new StringBuilder();
		if (ss.Length != pattern.Length) return false;

		var d = new Dictionary<char, string>();
		var f = new Dictionary<string, char>();

		for (var i = 0; i < ss.Length; i++)
		{
			var a = pattern[i];
			var b = ss[i];

			var x1 = d.TryGetValue(a, out var c);
			var x2 = f.TryGetValue(b, out var e);

			if (x1 || x2)
			{
				if (x1 != x2 && (c != b || e != a)) return false;
			}

			d[a] = b;
			f[b] = a;
			r.Append(a);
		}

		return r.ToString() == pattern;
	}
}