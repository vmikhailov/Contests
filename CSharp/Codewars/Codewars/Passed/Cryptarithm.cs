using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Codewars.Passed
{
    public class Cryptarithm
    {
        private readonly string _input;
        private string[] _words;
        private char[][] _reversedWords;
        private IDictionary<char, ISet<int>> _digitsMap;

        public static string Alphametics(string s)
        {
            var solver = new Cryptarithm(s);

            return solver.Solve();
        }

        public Cryptarithm(string input)
        {
            _input = input;
            _words = input.Split(" +=".ToArray(), StringSplitOptions.RemoveEmptyEntries);
            _reversedWords = _words.Select(x => x.Reverse().ToArray()).ToArray();
            _digitsMap = AllowedNumbers(_words);
        }

        private string Solve()
        {
            var map = new Dictionary<char, int>();
            var solutions = new List<IDictionary<char, int>>();

            Solve(0, 0, map, solutions);

            return BuildExpression(solutions.FirstOrDefault());
        }

        private bool Solve(
            int k,
            int overflow,
            Dictionary<char, int> map,
            IList<IDictionary<char, int>> solutions)
        {
            var letters = _reversedWords.Select(x => x.Skip(k).FirstOrDefault())
                                        .Where(x => x != 0)
                                        .ToArray();

            if (!letters.Any())
            {
                if (overflow == 0)
                {
                    solutions.Add(map);

                    return true;
                }

                return false;
            }

            var unknown = letters.Except(map.Keys).Distinct().ToArray();

            var n = (long)Math.Pow(10, unknown.Length);
            var digits = new int[unknown.Length];
            for (var i = 0; i < n; i++)
            {
                if (!FillDigits(unknown, i, digits, map.Values)) continue;

                var nextLevelMap = unknown.Zip(digits).ToDictionary(x => x.First, x => x.Second);
                foreach (var kvp in map) nextLevelMap.Add(kvp.Key, kvp.Value);

                var s = letters[..^1].Select(x => nextLevelMap[x]).Sum() + overflow;
                if (s % 10 == nextLevelMap[letters[^1]])
                {
                    if (Solve(k + 1, s / 10, nextLevelMap, solutions))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool FillDigits(
            char[] letters,
            int flags,
            int[] digits,
            ICollection<int> mapValues)
        {
            for (var i = 0; i < letters.Length; i++)
            {
                var s = _digitsMap[letters[i]];
                var d = flags % 10;
                flags /= 10;

                if (!s.Contains(d)) return false;
                if (mapValues.Contains(d)) return false;
                for (var j = i - 1; j >= 0; j--)
                {
                    if (digits[j] == d) return false;
                }

                digits[i] = d;
            }

            return true;
        }

        private static IDictionary<char, ISet<int>> AllowedNumbers(string[] words)
        {
            var letters = words.SelectMany(x => x).Distinct().ToArray();
            var digitsMap = letters.ToDictionary(x => x, x => (ISet<int>)Enumerable.Range(0, 10).ToHashSet());
            foreach (var w in words)
            {
                digitsMap[w[0]].Remove(0);
            }

            return digitsMap;
        }

        private string BuildExpression(IDictionary<char, int> map)
        {
            if (map == null) return "";
            var numbers = new int[_words.Length];
            for (var i = 0; i < _words.Length; i++)
            {
                var w = _words[i];
                var v = 0;
                foreach (var c in w)
                {
                    if (!map.TryGetValue(c, out var d)) return "";
                    v = v * 10 + d;
                }

                numbers[i] = v;
            }

            var left = string.Join(" + ", numbers[..^1]);

            return $"{left} = {numbers[^1]}";
        }
    }

    public class SingleCharPalindrome
    {    
        public static string solve(string s)
        {
            var cc = s.ToCharArray();

            if (IsPalindrome(cc)) return "OK";
            for (var i = 0; i < cc.Length; i++)
            {
                var sub = cc.Where((x, j) => j != i).ToArray();

                if (IsPalindrome(sub)) return "remove one";
            }

            return "not possible";
        }

        private static bool IsPalindrome(char[] s)
        {
            var i = s.Length - 1;
            var j = 0;
            while (s[i] == s[j] && i > j)
            {
                i--;
                j++;
            }

            return i <= j;
        }
    
    }
}