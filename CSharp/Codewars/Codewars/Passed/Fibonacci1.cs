using System.Numerics;

namespace Codewars.Codewars.Passed
{
    public class Fibonacci1
    {
        public static BigInteger fibOld(int n)
        {
            if (n == 0) return 0;
            if (n == 1 || n == -1) return 1;
            BigInteger f1 = 0, f2 = 1, f3 = 1;
            var nn = n > 0 ? n : -n;
            while (--nn > 0)
            {
                f3 = f1 + f2;
                f1 = f2;
                f2 = f3;
            }

            return n < 0 ? (n % 2 == 0 ? -1 : 1) * f3 : f3;
        }
    }
}
