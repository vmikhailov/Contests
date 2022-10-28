using System;
using System.Linq;

namespace Codewars.Entry
{
    public class UnfairSharing
    {
        public static int Compute(int[] values)
        {
            return values.Select(x => x * Math.Sign((int)x)).Sum();
        }

        public static void Main1()
        {
            var n = int.Parse(Console.ReadLine());
            var v = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine(Compute(v));
        }
    }
}