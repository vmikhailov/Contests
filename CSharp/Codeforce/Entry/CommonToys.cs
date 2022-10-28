using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Entry
{
    public static class CommonToys
    {
        public static long Compute(int n, IList<long[]> coords)
        {
            var x1 = coords.Select(_ => _[0]).Max();
            var y1 = coords.Select(_ => _[1]).Max();
            
            var x2 = coords.Select(_ => _[2]).Min();
            var y2 = coords.Select(_ => _[3]).Min();

            return y2 < y1 || x2 < x1 ? 0 : (y2 - y1) * (x2 - x1);
        }

        public static void Main1()
        {
            var n = int.Parse(Console.ReadLine());
            var coords = new List<long[]>();
            for (var i = 0; i < n; i++)
            {
                coords.Add(Console.ReadLine().Split(' ').Select(long.Parse).ToArray());
            }

            Console.WriteLine(Compute(n, coords));
        }
    }
}