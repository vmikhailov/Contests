using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace Codewars.Entry
{
    public static class FibonacciSpecial
    {
        private static Dictionary<BigInteger, BigInteger> Fibs;

        public static BigInteger Calculate(BigInteger n, BigInteger m)
        {
            Fibs = new Dictionary<BigInteger, BigInteger>();
            var v = Fib(n, m) % m;

            return v;
        }

        private static BigInteger Fib(BigInteger n, BigInteger m)
        {
            if (n == 0) return 0;
            if (n == 1 || n == 2) return (Fibs[n] = 1);
            if (Fibs.TryGetValue(n, out var v)) return v;

            var k = (n & 1) == 1 ? (n + 1) / 2 : n / 2;

            v = (n & 1) == 1
                ? (Fib(k, m) * Fib(k, m) + Fib(k - 1, m) * Fib(k - 1, m))
                : (2 * Fib(k - 1, m) + Fib(k, m)) * Fib(k, m);

            Fibs[n] = v % m;

            return v;
        }
    }

    public static class LostTask2
    {
        public static void Main2()
        {
            var s = Console.ReadLine().Split(' ');
            var n = BigInteger.Parse(s[0]);
            var m = BigInteger.Parse(s[1]);
            var f = FibonacciSpecial.Calculate(n, m);
            Console.WriteLine(f);
        }

        public static void Main1()
        {
            var r = new Random();
            while (true)
            {
                var s = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                BigInteger n = 0;
                BigInteger m = 0;
                if (s.Length == 0)
                {
                    n = BigInteger.One * r.Next(int.MaxValue / 100);
                    m = BigInteger.One * r.Next(int.MaxValue / 10);
                    Console.WriteLine($"Random n = {n} m = {m}");
                }
                else
                {
                    n = BigInteger.Parse(s[0]);

                    if (n == 0) return;
                    m = BigInteger.Parse(s[1]);
                }

                var sw1 = Stopwatch.StartNew();
                var f1 = FibonacciSpecial.Calculate(n, m);
                sw1.Stop();
                BigInteger f2 = 0;
                var sw2 = Stopwatch.StartNew();
                if (n < int.MaxValue)
                {
                    f2 = Fibonacci.Calculate((int)n);
                }
                else
                {
                    Console.WriteLine("Too big for int");
                }

                sw2.Stop();

                Console.WriteLine($"{f1}, {f2 % m} {f2.ToByteArray().Length} {sw1.ElapsedMilliseconds} {sw2.ElapsedMilliseconds}");
            }
        }
    }
}