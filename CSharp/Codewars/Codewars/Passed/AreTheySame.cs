using System;
using System.Linq;

namespace Codewars.Codewars.Passed
{
    class AreTheySame
    {
        public static bool comp(int[] a, int[] b)
        {
            a ??= new int[0];
            b ??= new int[0];
            if(a.Length != b.Length)
            {
                return false; 
            }

            var pairs = a.OrderBy(Math.Abs).Zip(b.OrderBy(x => x)).ToList();

            return pairs.All(x => x.First * x.First == x.Second);
        }
    }
}
