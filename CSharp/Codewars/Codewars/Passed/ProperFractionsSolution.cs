using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Codewars.Passed
{
    public class ProperFractionsSolution
    {
        public static long ProperFractions(long n)
        {
            ComputePrimes((long)Math.Sqrt(n));

            var f = Factors(n);
            var pd = f.Select(x => x.divider).ToList();
            var c = 0L;
            for (int i = 1, s = 1; i <= pd.Count; i++, s = -s)
            {
                c += s * Combinations(pd, i).Select(x => x.Aggregate((y, r) => y * r)).Select(x => n/x).Sum();
            }

            return n - c;
        }

        private static readonly IList<long> Primes = new List<long>() { 2 };

        private static IList<(long divider, int power)> Factors(long n)
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
            for (var i = 3; i <= n; i++)
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

        public static IEnumerable<IEnumerable<T>> Combinations<T>(IReadOnlyCollection<T> data, int k)
        {
            var size = data.Count;

            IEnumerable<IEnumerable<T>> Runner(IEnumerable<T> list, int n)
            {
                var skip = 1;
                foreach (var headList in list.Take(size - k + 1).Select(h => new T[] { h }))
                {
                    if (n == 1)
                    {
                        yield return headList;
                    }
                    else
                    {
                        foreach (var tailList in Runner(list.Skip(skip), n - 1))
                        {
                            yield return headList.Concat(tailList);
                        }

                        skip++;
                    }
                }
            }

            return Runner(data, k);
        }
    }
}