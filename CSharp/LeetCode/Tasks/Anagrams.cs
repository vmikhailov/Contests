using NUnit.Framework.Legacy;
using System.Collections;
using System.Text;
using NUnit.Framework;

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
}

[TestFixture]
public class AnagramsTests
{
    private Anagrams _task = null!;

    [SetUp]
    public void SetUp() => _task = new Anagrams();

    private static void AssertAnagramGroups(IList<IList<string>> expected, IList<IList<string>> actual)
    {
        ClassicAssert.AreEqual(expected.Count, actual.Count);
        var sortedExpected = expected.Select(g => g.OrderBy(s => s).ToList()).OrderBy(g => g[0]).ToList();
        var sortedActual = actual.Select(g => g.OrderBy(s => s).ToList()).OrderBy(g => g[0]).ToList();

        for (int i = 0; i < sortedExpected.Count; i++)
        {
            CollectionClassicAssert.AreEqual(sortedExpected[i], sortedActual[i]);
        }
    }

    [Test]
    public void GroupAnagrams_BasicCase_ReturnsCorrectGroups()
    {
        var input = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
        var result = _task.GroupAnagrams1(input);
        ClassicAssert.AreEqual(3, result.Count);
    }

    [Test]
    public void GroupAnagrams_EmptyString_ReturnsOneGroup()
    {
        var input = new string[] { "" };
        var result = _task.GroupAnagrams1(input);
        ClassicAssert.AreEqual(1, result.Count);
        CollectionClassicAssert.AreEqual(new[] { "" }, result[0]);
    }

    [Test]
    public void GroupAnagrams_SingleCharacter_ReturnsOneGroup()
    {
        var input = new string[] { "a" };
        var result = _task.GroupAnagrams1(input);
        ClassicAssert.AreEqual(1, result.Count);
        CollectionClassicAssert.AreEqual(new[] { "a" }, result[0]);
    }

    [Test]
    public void GroupAnagrams_DifferentLengths_GroupsSeparately()
    {
        var input = new string[] { "abbbbbbbbbbb", "aaaaaaaaaaab" };
        var result = _task.GroupAnagrams1(input);
        ClassicAssert.AreEqual(2, result.Count);
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

[TestFixture]
public class LetterCombinationsTests
{
    [Test]
    public void Solve_TwoDigits_ReturnsCorrectCombinations()
    {
        var result = LetterCombinations.Solve("23");
        ClassicAssert.AreEqual(9, result.Count);
        CollectionClassicAssert.Contains(result, "ad");
        CollectionClassicAssert.Contains(result, "ae");
        CollectionClassicAssert.Contains(result, "af");
    }

    [Test]
    public void Solve_EmptyString_ReturnsEmpty()
    {
        var result = LetterCombinations.Solve("");
        ClassicAssert.AreEqual(0, result.Count);
    }

    [Test]
    public void Solve_SingleDigit_ReturnsCorrectLetters()
    {
        var result = LetterCombinations.Solve("2");
        ClassicAssert.AreEqual(3, result.Count);
        CollectionClassicAssert.AreEquivalent(new[] { "a", "b", "c" }, result);
    }
}

