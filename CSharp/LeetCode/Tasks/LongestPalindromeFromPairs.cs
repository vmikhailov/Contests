using System.Text;

namespace LeetCode.Tasks;

public class LongestPalindromeFromPairs
{
    public int LongestPalindrome(string[] words)
    {
        var mini = words.Where(x => x[0] == x[1])
                                   .GroupBy(x => x)
                                   .ToDictionary(x => x.Key, x => x.Count());

        var wd = words.Where(x => !mini.ContainsKey(x))
                      .GroupBy(x => x)
                      .ToDictionary(x => x.Key, x => x.Count());

        var nn = 0;

        foreach (var a in wd.Keys)
        {
            var b = Reversed(a);
            var c = wd[a];
            if (c > 0 && wd.TryGetValue(b, out var p) && p > 0)
            {
                var n = Math.Min(c, p);
                wd[a] = c - n;
                wd[b] = p - n;
                nn += n;
            }
        }

        var center = mini.Where(x => x.Value % 2 == 1).FirstOrDefault();
        if (center.Key is not null)
        {
            mini[center.Key] = center.Value - 1;
            nn += 2;
        }

        nn += mini.Select(x => x.Value / 2).Sum() * 4;

        return nn;
    }

    private static string Reversed(string s) => new(new[] { s[1], s[0] });
}