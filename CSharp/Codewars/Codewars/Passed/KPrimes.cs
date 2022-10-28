using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Codewars.Passed
{
    public class KPrimes
    {
        public static long[] CountKprimes(int k, long start, long end)
        {
            ComputePrimes((int)Math.Sqrt(end));
            var list = new List<long>();
            for (var n = start; n <= end; n++)
            {
                var p = PrimeDividers(n);
                if (p.Select(x => x.power).Sum() == k)
                {
                    list.Add(n);
                }
            }

            return list.ToArray();
        }

        public static int Puzzle(int s)
        {
            var aa = CountKprimes(1, 2, s);
            var bb = CountKprimes(3, 2, s);
            var cc = CountKprimes(7, 2, s);

            var cnt = 0;
        
            foreach (var a in aa)
            foreach (var b in bb)
            foreach (var c in cc)
                cnt += a + b + c == s ? 1 : 0;

            return cnt;
        }

        private static readonly IList<long> Primes = new List<long>() { 2 };

        private static IList<(long divider, int power)> PrimeDividers(long n)
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
