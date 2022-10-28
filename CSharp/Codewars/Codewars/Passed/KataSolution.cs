using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Codewars.Codewars.Passed
{
    public class KataSolution
    {
        private static string pattern = @"\((-?)([\d]*)([a-z]{1})(\+|-)([\d]+)\)\^([\d]+)";

        public static string Expand(string expr)
        {
            var match = Regex.Match(expr, pattern);

            if (!match.Success) return null;
            var g1 = match.Groups[1].Value == "-"; //minus
            var g2 = match.Groups[2].Value; //a
            var g3 = match.Groups[3].Value; //x
            var g4 = match.Groups[4].Value == "-"; //+-
            var g5 = match.Groups[5].Value; //b
            var g6 = match.Groups[6].Value; //n

            var a = (string.IsNullOrEmpty(g2) ? 1 : long.Parse(g2)) * (g1 ? -1 : 1);
            var x = g3;
            var b = long.Parse(g5) * (g4 ? -1 : 1);
            var n = long.Parse(g6);

            var aa = (long)Math.Pow(a, n);
            var bb = 1L;

            if (n == 0) return "1";
            if (b == 0) return $"{aa}{x}^{n}";

            var cc = 1L;

            var sb = new StringBuilder();
            for (var i = 0; i <= n; i++)
            {
                var k = aa * bb * cc;

                if (k > 0 && i > 0) sb.Append("+");
                if (k != 1 && k != -1 && i < n) sb.Append($"{k}");
                if (k == -1 && i < n) sb.Append($"-");
                if (i == n) sb.Append($"{k}");
                if (i < n - 1) sb.Append($"{x}^{n - i}");
                if (i == n - 1) sb.Append($"{x}");

                aa /= a;
                bb *= b;
                cc = cc * (n - i) / (i + 1);
            }

            return sb.ToString();
        }
    }
}