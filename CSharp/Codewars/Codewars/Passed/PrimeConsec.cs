using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Codewars.Passed
{
    class PrimeConsec
    {
        public static int ConsecKprimes(int k, long[] arr)
        {
            if (arr.Length == 0) return 0;
            ComputePrimes((int)Math.Sqrt(arr.Max())*2);

            var list = new List<(long n, long p, int r)>();
            var rank = 0;
            long prev = 0;
            foreach (var n in arr)
            {
                var p = Factors(n).Select(x => x.power).Sum();
                if (p != prev) rank++;

                prev = p;
                list.Add((n, p, rank));
            }

            var result = list.Where(x => x.p == k)
                             .GroupBy(x => x.r)
                             .Select(x => x.Count() - 1)
                             .Sum();

            return result;
        }

        private static readonly IList<long> Primes = new List<long>() { 2 };

        private static IList<(long divider, int power)> Factors(long n)
        {
            // var dd = new Dictionary<long, int>();
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
                if (FindDivider(i) == 1) Primes.Add(i);
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
