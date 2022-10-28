using System;

namespace Codewars.Codewars.Passed
{
    public class KataQueue
    {
        public static long QueueTime(int[] customers, int n)
        {
            if ((customers?.Length ?? 0) == 0 || n == 0) return 0L;
        
            var units = new int[n];
            foreach (var c in customers)
            {
                units[0] += c;
                Array.Sort(units);
            }

            return units[n - 1];
        }
    }
}