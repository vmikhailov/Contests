using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Entry
{
    public static class WaterReserve
    {
        public static long Compute(int n, IList<long> bars)
        {
            return Compute(n, bars, 0, bars.Count - 1, 0);
        }
        
        public static long Compute(int n, IList<long> bars, int l, int r, int t)
        {
            if (l >= r) return 0;
            
            var (m, i) = Max(bars, l, r);
            if (t == 1)
            {
                //left
                return Compute(n, bars, l, i - 1, 1) + Sum(bars, m, i, r);
            }
            else if (t == 2)
            {
                //right   
                return Sum(bars, m, l, i) + Compute(n, bars, i + 1, r, 2);
            }

            return Compute(n, bars, l, i - 1, 1) + Compute(n, bars, i + 1, r, 2);
        }

        private static long Sum(IList<long> bars, long m,  int i, int j)
        {
            var s = 0L;
            for (var k = i; k <= j; k++)
            {
                s += m - bars[k];
            }

            return s;
        }

        private static (long, int) Max(IList<long> bars, int l, int r)
        {
            var m = long.MinValue;
            var j = -1;
            for (var i = l; i <= r; i++)
            {
                if (m < bars[i])
                {
                    m = bars[i];
                    j = i;
                }
            }

            return (m, j);
        }

        public static void Main1()
        {
            var n = int.Parse(Console.ReadLine());
            var p = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            
            Console.WriteLine(Compute(n, p));
        }

        public static void Test1()
        {
            Compute(8, new List<long>() { 4, 2, 3, 1, 5, 2, 3, 1 });
        }
    }
}