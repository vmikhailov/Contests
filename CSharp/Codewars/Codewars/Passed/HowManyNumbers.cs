using System.Collections.Generic;

namespace Codewars.Codewars.Passed
{
    class HowManyNumbers
    {
        public static List<long> FindAll(int sumDigits, int numDigits)
        {
            var min = GetMinNumber(sumDigits, numDigits);
            var max = GetMaxNumber(sumDigits, numDigits);
            var n = 0;
            var nmin = 0L;
            var nmax = 0L;
        
            for (var i = min; i < max; i++)
            {
                if(!CheckSum(i, sumDigits)) continue;

                if (nmin == 0) nmin = i;
                nmax = i;
                n++;
            }
        
            return n > 0 ? new List<long>{ n, nmin, nmax } : new List<long>();
        }

        private static long GetMaxNumber(int sum, int num)
        {
            var r = 0L;
            while (sum > 0)
            {
                var d = sum / num;
                r = 10*r + d;
                sum -= d;
                num--;
            }

            return r;
        }
    
        private static long GetMinNumber(int sum, int num)
        {
            var r = 0L;
            var p = 1L;
            while (sum > 0)
            {
                var d = sum / num;
                if (d >= 1)
                {
                    d = 9;
                    r += p * d;
                }

                p *= 10;
                sum -= d;
                num--;
            }

            return r;
        }

        private static bool CheckSum(long n, long sum)
        {
            var r = 0L;
            var p = 10L;
            while (n > 0)
            {
                var d = n % 10;

                if (d > p) return false;
                p = d;
                r += d;

                if (r > sum) return false;
                n /= 10;
            }

            return r == sum;
        }
    }
}