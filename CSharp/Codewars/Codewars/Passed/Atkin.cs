using System.Collections.Generic;

namespace Codewars.Codewars.Passed
{
    public class Atkin
    {
        public List<int> Primes { get; private set; }

        public void FindPrimes(int limit)
        {
            Primes = new List<int>(60_000_000) { 2, 3 };

            var sieve = new bool[limit];

            for (var x = 1; x * x < limit; x++)
            {
                for (var y = 1; y * y < limit; y++)
                {
                    var n = 4 * x * x + y * y;
                    if (n <= limit && (n % 12 == 1 || n % 12 == 5))
                    {
                        sieve[n] ^= true;
                    }

                    n = 3 * x * x + y * y;
                    if (n <= limit && n % 12 == 7)
                    {
                        sieve[n] ^= true;
                    }

                    n = 3 * x * x - y * y;
                    if (x > y && n <= limit && n % 12 == 11)
                    {
                        sieve[n] ^= true;
                    }
                }
            }

            for (long r = 5; r * r < limit; r++)
            {
                if (sieve[r])
                {
                    for (var i = r * r; i < limit; i += r * r) sieve[i] = false;
                }
            }

            for (var a = 5; a < limit; a++)
            {
                if (sieve[a])
                {
                    Primes.Add(a);
                }
            }
        }
    }
}