using System;

namespace Codewars.Codewars.Passed
{
    public class SLimit
    {
        public static double Solve(double m)
        {
            var a = m;
            var b = -2 * m - 1;
            var c = m;
            var d = Math.Sqrt(b * b - 4 * a * c);
            var x = (-b - d) / 2 / m;
            return x;
        }
    
        private const double delta = 1e-12;
        public static double Solve1(double m)
        {
            var x2 = 1 - delta;
            var x1 = delta;
            double x = 0;
            while (x2 - x1 > delta)
            {
                x = (x1 + x2) / 2;
                var l = Sum(x, delta);
                if (m > l)
                {
                    x1 = x;
                }
                else
                {
                    x2 = x;
                }
            }

            return x;
        }

        public static double Sum(double x, double delta)
        {
            double s = 0;
            var y = x;
            var n = 1;
            while (true)
            {
                var d = n * y;
                if (Math.Abs(d) < delta)
                {
                    return s;
                }

                s += d;
                n++;
                y *= x;
            }
        }
    }
}