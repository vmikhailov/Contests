using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Codewars
{
    public class FactorialDecomposition
    {
        public static string Decomp(int n)
        {
            ComputePrimes((int)Math.Sqrt(n) + 1);

            return Enumerable.Range(2, n - 1)
                             .SelectMany(Factors)
                             .GroupBy(x => x.divider)
                             .OrderBy(x => x.Key)
                             .Select(x => (div: x.Key, power: x.Sum(y => y.power)))
                             .Select(x => x.power > 1 ? $"{x.div}^{x.power}" : $"{x.div}")
                             .Aggregate((x, r) => $"{x} * {r}");
        }

        public static string factors(int n)
        {
            ComputePrimes((int)Math.Sqrt(n) + 1);

            return Factors(n).Select(x => x.power > 1 ? $"({x.divider}**{x.power})" : $"({x.divider})")
                             .Aggregate((x, r) => $"{x}{r}");
        }

        public static int zeroes(int bs, int n)
        {
            ComputePrimes((int)Math.Sqrt(n) + 1);

            var factors = Enumerable.Range(2, n - 1)
                                    .SelectMany(Factors)
                                    .GroupBy(x => x.divider)
                                    .ToDictionary(x => x.Key, x => x.Sum(y => y.power));

            var baseFactors = Factors(bs).ToDictionary(x => x.divider, x => x.power);
            
            var zeros = 0;
            while (true)
            {
                foreach (var bf in baseFactors)
                {
                    if (factors[bf.Key] < bf.Value) return zeros;
                    factors[bf.Key] -= bf.Value;
                }

                zeros++;
            }
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