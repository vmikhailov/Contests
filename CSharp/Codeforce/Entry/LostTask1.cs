using System;
using System.Numerics;

namespace Codewars.Entry
{
    public static class Fibonacci
    {
        private static BigInteger[] Fibs;
        
        public static BigInteger Calculate(int n)
        {
            var k = Math.Abs(n);
            Fibs = new BigInteger[k + 1];
            var v = Fib(k);

            return n > 0 ? v : (k % 2 == 0 ? -1 : 1) * v;
        }

        private static BigInteger Fib(int n)
        {
            if (n == 0) return 0;
            if (n == 1 || n == 2) return (Fibs[n] = 1);
            if (Fibs[n] != 0) return Fibs[n];

            BigInteger f;
            if (n % 2 == 1)
            {
                var k = (n + 1) / 2;
                f = Fib(k) * Fib(k) + Fib(k - 1) * Fib(k - 1);
            }
            else
            {
                var k = n / 2;
                f = (2 * Fib(k - 1) + Fib(k)) * Fib(k);
            }

            return Fibs[n] = f;
        }
    }

    public static class LostTask1
    {
        public static void Main1()
        {
            var s = Console.ReadLine().Split(' ');
            var n = int.Parse(s[0]);
            var m = BigInteger.Parse(s[1]);
            var r = Fibonacci.Calculate(n) % m;
            Console.WriteLine(r);
        }
    }
}