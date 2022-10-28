namespace Codewars.Codewars.Passed
{
    public class SumDigSolution
    {
        public static long solve(long n)
        {
            long m = 1, r = n;

            while (n > 0)
            {
                var c = (n - 1) * m + (m - 1);
                var dc = DigitsSum(c);
                var dr = DigitsSum(r);

                if (dc > dr || dc == dr && c > r) r = c;

                n /= 10;
                m *= 10;
            }

            return r;
        }

        private static int DigitsSum(long n)
        {
            var s = 0;
            while (n > 0)
            {
                s += (int)(n % 10);
                n /= 10;
            }

            return s;
        }
    }
}