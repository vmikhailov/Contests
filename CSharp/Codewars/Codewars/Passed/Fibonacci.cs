using System;
using System.Numerics;

namespace Codewars.Codewars.Passed
{
    public class Fibonacci
    {
        public static BigInteger[] fibs;
        public static BigInteger fib(int n)
        {
            var k = Math.Abs(n);
            fibs = new BigInteger[k + 1]; 
            var v = fibCore(k);
            return n > 0 ? v : (k % 2 == 0 ? -1 : 1) * v;
        }
    
        public static BigInteger fibCore(int n)
        {
            if (n == 0) return 0;
            if (n == 1 || n == 2) return (fibs[n] = 1);
            if (fibs[n] != 0) return fibs[n];

            var k = (n & 1) == 1 ? (n + 1) / 2 : n / 2;

            fibs[n] = (n & 1) == 1
                ? (fibCore(k) * fibCore(k) + fibCore(k - 1) * fibCore(k - 1))
                : (2 * fibCore(k - 1) + fibCore(k)) * fibCore(k);

            return fibs[n];
        }
    }
}