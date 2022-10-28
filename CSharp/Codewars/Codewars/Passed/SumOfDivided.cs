using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Codewars.Passed
{
    public class SumOfDivided
    {

        public static string sumOfDivided(int[] lst)
        {
            if ((lst?.Length ?? 0) == 0) return "";

            var max = lst.Select(Math.Abs).Max();
            ComputePrimes((int)Math.Sqrt(max));

            var result = lst.SelectMany(x => Factors(x).Select(y => new { d = y.divider, v = x }))
                            .ToLookup(x => x.d, x => x.v)
                            .OrderBy(x => x.Key)
                            .Select(x => $"({x.Key} {x.Sum()})")
                            .Aggregate((x, r) => $"{x}{r}");

            return result;
        }

        private static readonly IList<int> Primes = new List<int>() { 2 };

        private static IList<(int divider, int power)> Factors(int n)
        {
            // var dd = new Dictionary<int, int>();
            var dd = new List<int>();
            while (true)
            {
                var d = FindDivider(n);
                if (d == 1)
                {
                    dd.Add(n);

                    break;
                }

                dd.Add(d);
                n /= d;
            }

            return dd.GroupBy(x => x).Select(x => (x.Key, x.Count())).ToList();
        }

        private static void ComputePrimes(int n)
        {
            for (var i = 3; i <= n; i++)
            {
                if (FindDivider(i) == 1) Primes.Add(i);
            }
        }

        private static int FindDivider(int n)
        {
            foreach (var p in Primes)
            {
                if (p > Math.Sqrt(n)) return 1;
                if (n % p == 0) return p;
            }

            return 1;
        }
    }
}