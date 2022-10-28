using System;

namespace Codewars.Entry
{
    public static class MathGame
    {
        public static bool Compute(long b, long c, out long x1, out long x2)
        {
            // x^2 - b*x + c = 0
            x1 = 0;
            x2 = 0;
            var d = b * b - 4 * c;

            if (d <= 0) return false;
            var s = (long)Math.Truncate(Math.Sqrt(d));

            if (s * s != d || (b + s) % 2 == 1) return false;
            x1 = (b - s) / 2;
            x2 = (b + s) / 2;

            return true;
        }

        public static void Main1()
        {
            var b = long.Parse(Console.ReadLine());
            var c = long.Parse(Console.ReadLine());
            
            if(Compute(b, c, out var x1, out var x2))
            {
                Console.WriteLine($"{x1} {x2}");    
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}