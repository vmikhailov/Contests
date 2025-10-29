using System;
using System.Collections;
using System.Collections.Generic;

namespace Codewars.Codewars.Passed
{
    public class Atkin
    {
        public List<int> Primes { get; private set; }

        public void FindPrimes(int limit)
        {
            var estimatedCount = (int)(limit / (Math.Log(limit) - 1.5));
      
            Primes = new(estimatedCount) { 2, 3 };

            var sieve = new BitArray(limit);

            for (var x = 1; x * x < limit; x++)
            {
                for (var y = 1; y * y < limit; y++)
                {
                    var n = 4L * x * x + y * y;
                    if (n <= limit && (n % 12 == 1 || n % 12 == 5))
                    {
                        sieve[(int)n] ^= true;
                    }

                    n = 3L * x * x + y * y;
                    if (n <= limit && n % 12 == 7)
                    {
                        sieve[(int)n] ^= true;
                    }

                    n = 3L * x * x - y * y;
                    if (x > y && n <= limit && n % 12 == 11)
                    {
                        sieve[(int)n] ^= true;
                    }
                }
            }

            for (var r = 5; r * r < limit; r++)
            {
                if (sieve[r])
                {
                    for (var i = r * r; i < limit && i >= 0; i += r * r) sieve[i] = false;
                }
            }

            for (var a = 5; a < limit; a++)
            {
                if (sieve[a])
                {
                    Primes.Add(a);
                }
            }
            
            //Console.WriteLine($"Estimated diff {estimatedCount - Primes.Count}");
        }
    }
}