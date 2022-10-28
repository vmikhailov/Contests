using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Codewars.Passed
{
    public class Fracts
    {
        private static readonly IList<long> Primes = new List<long>() { 2 };

        public static string convertFrac(long[,] lst)
        {
            var numerators = new List<long>();
            var denominators = new List<long>();
            for (var i = 0; i < lst.GetLength(0); i++)
            {
                numerators.Add(lst[i, 0]);
                denominators.Add(lst[i, 1]);
            }

            ComputePrimes((long)Math.Sqrt(denominators.Max()));

            var dd = denominators.SelectMany(PrimeDividers)
                                 .GroupBy(x => x.divider)
                                 .Select(x => new { divider = x.Key, x.OrderByDescending(y => y.power).First().power })
                                 .Select(x => Math.Pow(x.divider, x.power))
                                 .Aggregate((x, r) => x * r);

            return denominators.Zip(numerators)
                               .Select(x => x.Second * dd / x.First)
                               .Select(x => $"({x},{dd})")
                               .Aggregate((x, r) => $"{x}{r}");
        }

        private static IList<(long divider, int power)> PrimeDividers(long n)
        {
            var dd = new List<long>();
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

        private static void ComputePrimes(long n)
        {
            for (var i = 3; i < n; i++)
            {
                if (FindDivider(n) == 1) Primes.Add(i);
            }
        }

        private static long FindDivider(long n)
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
