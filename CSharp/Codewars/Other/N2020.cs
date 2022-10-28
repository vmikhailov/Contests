using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Codewars.Other
{
    public class N2020
    {
        public static void Compute1()
        {
            var n = 2020L;
            var m = 9876543210L / n;

            var list = new List<(long n, long d)>();
            for (var i = 1; i <= m; i++)
            {
                if (IsGood1(i * n, out var digits))
                {
                    list.Add((i * n, digits));
                }
            }

            var numbers = list.GroupBy(x => x.d).Where(x => x.Count() == 1).Select(x => x.First()).ToList();
            foreach (var num in numbers)
            {
                Debug.WriteLine($"{num.n}");  
            }
        }
        
        public static void Compute()
        {
            var n = 2020L;
            var m = 9876543210L / n;

            var a = IsGood(2156347980L, n);
            
            var list = new List<long>();
            for (var i = 1; i <= m; i++)
            {
                if (IsGood(i * n, n))
                {
                    list.Add(i * n);
                }
            }

            foreach (var num in list)
            {
                Debug.WriteLine($"{num}");  
            }
        }

        private static bool IsGood1(long k, out long digits)
        {
            var n = k;
            var used = new bool[10];
            digits = 0;
            while (n > 0)
            {
                var d = (int)(n % 10);
                if (used[d]) return false;
                used[d] = true;
                n = n / 10;
            }

            for (var i = 9; i >= 0; i--)
            {
                if (used[i])
                {
                    digits = digits * 10 + i;
                }
            }

            return true;
        }
        
        private static bool IsGood(long k, long m)
        {
            var n = k;
            var used = new bool[10];
            var digits = new List<int>(10);
            while (n > 0)
            {
                var d = (int)(n % 10);
                if (used[d]) return false;
                used[d] = true;
                digits.Add(d);
                n = n / 10;
            }

            for (var i = 0; i < digits.Count - 1; i++)
            {
                for (var j = i + 1; j < digits.Count; j++)
                {
                    var d = 0;
                    for (var l = 0; l < digits.Count; l++)
                    {
                        var v = digits.Count - (l == i ? j : l == j ? i : l) - 1;
                        d = d * 10 + digits[v];
                    }
                    if (d % m == 0) return false;
                }
            }

            return true;
        }
    }

    [TestFixture]
    public class N2020Tests
    {
        [Test]
        public void Test1()
        {
            N2020.Compute();
        }

        [Test]
        public async Task Test2()
        {
            var sw = Stopwatch.StartNew();
            
            void Finish(Task t, object state)
            {
                var n = (int)state;
                Debug.WriteLine($"Completed {n}. Time: {sw.ElapsedMilliseconds} ms");
            }
            
         
            var r = new Random();
            var tasks = Enumerable.Range(1, 30).Select(x =>
            {
                Debug.WriteLine($"Starting {x}. Time: {sw.ElapsedMilliseconds} ms");
                return Task.Delay(1500).ContinueWith(Finish, x);
            }).ToArray();
            
            await Task.WhenAll(tasks);
            sw.Stop();
            Debug.WriteLine($"Total time {sw.ElapsedMilliseconds} ms");
        }
    }
}