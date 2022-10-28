using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Codewars.Passed
{
    public class DigPow
    {
        public static long digPow(int n, int p)
        {
            var sum = (int)Digits(n).Select(x => Math.Pow(x, p++)).Sum();

            return sum % n == 0 ? sum / n : -1;
        }

        public static int SquareDigits(int n)
        {
            return int.Parse(string.Join("", Digits(n).Select(x => x * x)));
        }


        public static int DescendingOrder(int num)
        {
            return Digits(num).Reverse().Select((x, i) => x * (int)Math.Pow(10, i)).Sum();
        }

        public static long[] SumDigPow(long a, long b)
        {
            var list = new List<long>();
            for (var i = a; i < b; i++)
            {
                if (IsNice(i))
                {
                    list.Add(i);
                }
            }

            return list.ToArray();
        }

        private static bool IsNice(long n)
        {
            var p = Digits(n).Select((x, i) => (long)Math.Pow(x, i + 1)).Sum();

            return p == n;
        }

        private static IEnumerable<int> Digits(int n)
        {
            var p = (int)Math.Pow(10, Math.Floor(Math.Log10(n)));
            while (p > 0)
            {
                var d = (n - n % p) / p;

                yield return d;
                n = n - d * p;
                p = p / 10;
            }
        }
    
        private static IEnumerable<long> Digits(long n)
        {
            var p = (long)Math.Pow(10, Math.Floor(Math.Log10(n)));
            while (p > 0)
            {
                var d = (n - n % p) / p;

                yield return d;
                n = n - d * p;
                p = p / 10;
            }
        }
    
        public static int DuplicateCount(string str)
        {
            return str.Where(char.IsLetterOrDigit).ToLookup(char.ToUpper).Count(x => x.Count() > 1);
        }
    
        public static int[] DeleteNth(int[] arr, int x) 
        {
            var list = new List<int>();
            var map = new Dictionary<int, int>();
            foreach (var d in arr)
            {
                if (!map.TryGetValue(d, out var cnt))
                {
                    cnt = 0;
                }

                if (++cnt > x)
                {
                    continue;
                }
                list.Add(d);

                map[d] = cnt;
            }

            return list.ToArray();
        }
    
        public static string PrinterError(String s)
        {
            return $"{s.Count(x => x > 'm')}/{s.Length}";
        }

    }
}