using System;
using System.Linq;

namespace Codewars.Codewars.Passed
{
    public class WeightSort
    {
        public static string orderWeight(string str)
        {
            var numbers = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var ordered = numbers.OrderByDescending(x => x.Select(y => (int)y - (int)'0').Sum())
                                 .ThenBy(x => x);

            return string.Join(" ", ordered);
        }
    }
}