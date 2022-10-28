using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Codewars.Passed
{
    public class PalindromicSumOfPowers
    {
        public static int values(int n)
        {
            var count = 0;
            var found = new HashSet<int>();
            var m = (int)Math.Sqrt(n);
            for (var i = 1; i < m; i++)
            {
                for (var j = i + 1; j < m; j++)
                {
                    var s = Enumerable.Range(i, j - i + 1).Select(x => x * x).Sum();

                    if (s >= n) break;
                    if (!found.Contains(s) && IsPalindromic(s))
                    {
                        found.Add(s);
                        count++;
                    }
                }
            }

            return count;
        }

        private static bool IsPalindromic(int n)
        {
            var d = (int)Math.Pow(10, (int)Math.Log10(n));
            while (d > 1)
            {
                var n1 = n / d;
                var n2 = n % 10;

                if (n1 != n2) return false;
                n = (n - n1 * d) / 10;
                d /= 100;
            }

            return true;
        }
    }
}