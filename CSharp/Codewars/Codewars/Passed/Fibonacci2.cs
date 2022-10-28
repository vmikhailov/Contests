using System.Numerics;

namespace Codewars.Codewars.Passed
{
    public class Fibonacci2
    {
        public static BigInteger fib(int n)
        {
            return n >= 0 ? fibCore(n) : (n % 2 == 0 ? -1 : 1) * fibCore(-n);
        }

        public static BigInteger fibCore(int n)
        {
            var f = new BigInteger[,]
            {
                { 1, 1 },
                { 1, 0 }
            };

            if (n == 0) return 0;

            Power(f, n - 1);

            return f[0, 0];
        }

        static void Multiply(BigInteger[,] f, BigInteger[,] m)
        {
            var x = f[0, 0] * m[0, 0] + f[0, 1] * m[1, 0];
            var y = f[0, 0] * m[0, 1] + f[0, 1] * m[1, 1];
            var z = f[1, 0] * m[0, 0] + f[1, 1] * m[1, 0];
            var w = f[1, 0] * m[0, 1] + f[1, 1] * m[1, 1];

            f[0, 0] = x;
            f[0, 1] = y;
            f[1, 0] = z;
            f[1, 1] = w;
        }

        private static void Power(BigInteger[,] F, int n)
        {
            int i;
            var m = new BigInteger[,]
            {
                { 1, 1 },
                { 1, 0 }
            };

            for (i = 2; i <= n; i++)
            {
                Multiply(F, m);
            }
        }
    }
}