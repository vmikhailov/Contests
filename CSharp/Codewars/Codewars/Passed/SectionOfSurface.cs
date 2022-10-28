using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Codewars.Passed
{
    class SectionOfSurface
    {
        public static int C(long k)
        {
            ComputePrimes((long)Math.Sqrt(k) + 1);
        
            if (k <= 0) return 0;
            if (k == 1) return 1;
        
            var f = Factors(k);
            if(f.Any(x => x.power % 2 != 0)) return 0;

            return f.Select(x => x.power * 3 / 2 + 1).Aggregate((x, y) =>  x * y);
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