using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Codewars.Passed
{
    public class KataRange
    {
        public static int[] MysteryRange(string s, int n)
        {
            var l = s.Length;

            var min = 1;
            var max = 3;

            var m1 = 1;
            var m2 = 200;
            for (var i = m1; i < m2; i++)
            {
                var j = i + n - 1;
                var d = Len(i, j);

                if (d > l) break;
                if (d == l && SameDigits(s, i, j, min, max))
                {
                    return new[] { i, j };
                }
            }

            return new int[0];
        }

        private static int Len(int min, int max)
        {
            return Len(max) - Len(min - 1);
        }

        private static int Len(int n)
        {
            var s = 0;
            var m = 1;
            var d = 1;
            while (m * 10 <= n)
            {
                s += m * 9 * d;
                m *= 10;
                d++;
            }

            s += (n - m + 1) * d;

            return s;
        }
    
        private static IEnumerable<int> Digits(int n)
        {
            var p = (int)Math.Pow(10, Math.Floor(Math.Log10(n)));
            while (p > 0)
            {
                var d = (n - n % p) / p;

                yield return d;
                n = n - d * p;
                p = p / 10;
            }
        }

        private static bool SameDigits(string s, int i, int j, int min, int max)
        {
            var nums = Enumerable.Range(i, j - i + 1).ToHashSet();
            var r = new List<int>();

            var res = SameDigits(s, 0, nums, min, max, r);

            return res;
        }
    
        private static bool SameDigits(string s, int start, ISet<int> nums, int min, int max, IList<int> result)
        {
            if (nums.Count == 0) return true;
            var m = min;
            for(var i = start; i < s.Length; i++)
            {
                var d = GetNum(s, start, m);
                if (nums.Contains(d))
                {
                    nums.Remove(d);

                    if (SameDigits(s, start + m, nums, min, max, result))
                    {
                        result.Add(d);
                        return true;
                    }
                    nums.Add(d);
                }
                if (++m > max) break;
            }

            return false;
        }

        private static int GetNum(string s, in int start, in int m)
        {
            var d = 0;
            for (var i = start; i < start + m; i++)
            { 
                d = d * 10 + s[i] - '0';
            }

            return d;
        }
    }
}