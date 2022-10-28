using System;
using System.Collections.Generic;

namespace Codewars.Codewars.Passed
{
    // sum of squares 
    public class Decompose {
  
        public string decompose(long n)
        {
            var r = new SortedSet<long>();
            decomposeImpl(n * n, n - 1, r);
            return string.Join(" ", r);
        }
    
        private bool decomposeImpl(long n, long s, ISet<long> nums)
        {
            if (n == 0) return true;
            s = Math.Min(s, (long)Math.Sqrt(n));

            while(true)
            {
                while (nums.Contains(s)) s--;

                if (s == 0) return false;

                nums.Add(s);

                if (decomposeImpl(n - s * s, s, nums)) return true;
            
                nums.Remove(s--);
            }
        }
    }
}