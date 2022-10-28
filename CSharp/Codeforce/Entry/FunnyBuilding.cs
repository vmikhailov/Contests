using System;

namespace Codewars.Entry
{
    public class FunnyBuilding
    {
        public static int Compute(int n, int m)
        {
            return n * m + (n + 1) / 2;
        }

        public static void Main1()
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());
            Console.WriteLine(Compute(n, m));
        }
    }
}