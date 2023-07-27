using System.Text;

namespace LeetCode.Tasks;

public class WildCards
{
    private ISet<(int, int)> _cache = new HashSet<(int, int)>();
    public bool IsMatch(string s, string p)
    {
        _cache.Clear();
        var pp = new StringBuilder();
        var pr = (char)0;
        foreach (var c in p)
        {
            if (c == '*' && pr == '*') continue;
            pr = c;
            pp.Append(c);
        }

        return IsMatchImpl(s, pp.ToString(), 0, 0);
    }

    private bool IsMatchImpl(string s, string p, int si, int pi)
    {
        var key = (si, pi);
        if (!_cache.Add(key))
        {
            return false;
        }
        var pl = p.Length;
        var sl = s.Length;
        while (true)
        {
            if (si == sl && pi == pl) return true;
            if (pi == pl) return false;
            if (si == sl) return pi + 1 == pl && p[pi] == '*';

            if (p[pi] == s[si] || p[pi] == '?')
            {
                si++;
                pi++;
                continue;
            }

            if (p[pi] == '*')
            {
                for (var k = si; k <= s.Length; k++)
                {
                    if (IsMatchImpl(s, p, k, pi + 1)) return true;
                }
            }

            return false;
        }
    }
}