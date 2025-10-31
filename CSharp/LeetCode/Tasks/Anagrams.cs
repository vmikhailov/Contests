using System.Collections;
using System.Text;

namespace LeetCode;

public class Anagrams
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var r = strs.GroupBy(x => new string(x.OrderBy(y => y).ToArray()))
            .Select(IList<string> (x) => x.ToList())
            .ToList();

        return r;
    }

    public IList<IList<string>> GroupAnagrams2(string[] strs)
    {
        var h = new Dictionary<string, IList<string>>();

        foreach (var s in strs)
        {
            var b = new int[26];

            foreach (var c in s)
            {
                b[c - 'a']++;
            }

            var key = string.Join("", b.Select((x, i) => $"{i+'a'}{x}"));

            if (h.TryGetValue(key, out var list))
            {
                list.Add(s);
                continue;
            }

            h[key] = [s];
        }

        return h.Values.ToList();
    }

    public IList<IList<string>> GroupAnagrams1(string[] strs)
    {
        var h = new Dictionary<string, IList<string>>();

        foreach (var s in strs)
        {
            var a = s.ToCharArray();
            Array.Sort(a);
            var key = new string(a);

            if (h.TryGetValue(key, out var list))
            {
                list.Add(s);
                continue;
            }

            h[key] = [s];
        }

        return h.Values.ToList();
    }


    public static void Test()
    {
        var solution = new Anagrams();
        var input = new string[] { "eat", "tea", "tan", "ate", "nat", "bat", "teea" };
        var output = solution.GroupAnagrams1(input);

        foreach (var group in output)
        {
            Console.WriteLine($"[{string.Join(", ", group)}]");
        }

        var input2 = new string[] { "abbbbbbbbbbb", "aaaaaaaaaaab" };
        var output2 = solution.GroupAnagrams1(input2);

        foreach (var group in output2)
        {
            Console.WriteLine($"[{string.Join(", ", group)}]");
        }
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
