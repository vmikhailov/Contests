using System;
using System.Collections.Generic;
using System.Numerics;

namespace Codewars.Codewars.Passed
{
    public class BlockSeq
    {
        public static int solve(long n)
        {
            var m = n;
            long k1 = 1, k2 = (long)Math.Sqrt(long.MaxValue);
            while (k2 - k1 > 1)
            {
                var k = (k1 + k2) / 2;
                var s2 = CountDigits(k2); 
                var s1 = CountDigits(k);
                if (s2 > n && n >= s1)
                {
                    k1 = k;
                }
                else
                {
                    k2 = k;
                }
            }
        
            var s = CountDigits(k1);
            var p = (int)(n - s);
            var w = GetLength(k1);

            // var n2 = GetNumbers(k2).ToList();
            // var n1 = GetNumbers(k1).ToList();
            //var nn = p == 0 ? n1.Last() : n2.Skip(p-1).First();

            var r = p == 0 ? GetDigit(k1, GetLength(k1)) : GetDigit(k2, p);
            return r;
        }
    
        public static IEnumerable<int> GetNumbers(long n)
        {
            for (long i = 1; i <= n; i++)
            {
                foreach (var d in Digits(i))
                {
                    yield return d;
                }
            }
        }
    
        private static IEnumerable<int> Digits(long n)
        {
            var p = (long)Math.Pow(10, Math.Floor(Math.Log10(n)));
            while (p > 0)
            {
                var d = (n - n % p) / p;

                yield return (int)d;
                n = n - d * p;
                p = p / 10;
            }
        }

        private static int GetDigit(long n, long pos)
        {
            long l = 1L, p = 1;
            while (l <= n)
            {
                var m = l * 10;
                var posNext = pos - (m - l) * p;
                if (posNext > 0)
                {
                    pos = posNext;
                }
                else
                {
                    var r = pos / p;
                    var f = pos % p;
                    if (f == 0)
                    {
                        r--;
                        f = p;
                    }
                    var k = l + r;
                    var z = (long)Math.Pow(10, p - 1);
                    var d = 0;
                    while (f-- > 0)
                    {
                        d = (int)(k / z);
                        k -= d * z;
                        z /= 10;
                    }

                    return d;
                }
                p++;
                l *= 10;
            }

            return 1;
        }
    
        private static BigInteger CountDigits(long n)
        {
            BigInteger l = 1L, s = 0, p = 0;
            while (l <= n)
            {
                var m = l * 10;
                var k = m <= n ? m - 1 : n;
                BigInteger ss = 0L;

                for (var i = 1; i <= p; i++)
                {
                    ss += (long)(Math.Pow(10, i) - Math.Pow(10, i - 1)) * (BigInteger)i;
                }

                var z = (k - l + 1) * (2 * ss + (k - l + 2) * (p + 1)) / 2;
                s += z;
                p++;
                l *= 10;
            }

            return s;
        }

        public static long GetLength(long n)
        {
            var p = (int)Math.Log10(n) + 1;
            var d =  p * n - ((long)Math.Pow(10, p) - 1) / 9 + p;
            return d;
        }
    
    
    }
}