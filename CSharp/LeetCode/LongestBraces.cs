namespace LeetCode
{
	public class LongestBraces
	{
		public static int Compute(string s)
		{
			var c = 0;
			var r = new List<(int L, int R)>();
			var p = 0;

			for (var i = 0; i < s.Length; i++)
			{
				if (s[i] == '(')
				{
					if (c <= 0)
					{
						c = 0;
						p = i;
					}

					c++;
				}
				else
				{
					c--;
					if (c == 0)
					{
						r.Add((p, i));
					}
				}
			}

			if (c > 0)
			{
				while (s.Length > p && c-- > 0 && s[p] == '(') p++;
				r.Add((p, s.Length - 1));
			}

			if (r.Count == 0)
			{
				return 0;
			}
			
			var j = 1;
			var dd = new List<int>();
			var d = r[0].R - r[0].L + 1;
			while (j < r.Count)
			{
				if (r[j - 1].R == r[j].L - 1)
				{
					d += r[j].R - r[j].L + 1;
				}
				else
				{
					dd.Add(d);
					d = r[j].R - r[j].L + 1;
				}
				j++;
			}
			dd.Add(d);

			return dd.Max();
		}
	}
}