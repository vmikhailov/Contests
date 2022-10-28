using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Codewars.Passed
{
    public class Atkin2 : IEnumerable<int>
    {
        private readonly int limit;
        private readonly List<int> primes;

        public Atkin2(int limit)
        {
            this.limit = limit;
            primes = new List<int>();
        }


        public IEnumerator<int> GetEnumerator()
        {
            if (!primes.Any())

            {
                FindPrimes();
            }

            foreach (var p in primes)
            {
                yield return p;
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void FindPrimes()
        {
            primes.Add(2);
            primes.Add(3);
        
            // Initialise the sieve array with 
            // false values 
            var sieve = new bool[limit];

            for (var i = 0; i < limit; i++)
            {
                sieve[i] = false;
            }

            /* Mark siev[n] is true if one of the 
        following is true: 
        a) n = (4*x*x)+(y*y) has odd number  
           of solutions, i.e., there exist  
           odd number of distinct pairs  
           (x, y) that satisfy the equation  
           and    n % 12 = 1 or n % 12 = 5. 
        b) n = (3*x*x)+(y*y) has odd number  
           of solutions and n % 12 = 7 
        c) n = (3*x*x)-(y*y) has odd number  
           of solutions, x > y and n % 12 = 11 */
            for (var x = 1; x * x < limit; x++)
            {
                for (var y = 1; y * y < limit; y++)
                {
                    // Main part of Sieve of Atkin 
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

            // Mark all multiples of squares as 
            // non-prime 
            for (var r = 5; r * r < limit; r++)
            {
                if (sieve[r])
                {
                    for (var i = r * r;
                         i < limit;
                         i += r * r)
                    {
                        sieve[i] = false;
                    }
                }
            }

            // Print primes using sieve[] 
            for (var a = 5; a < limit; a++)
            {
                if (sieve[a])
                {
                    primes.Add(a);
                }
            }
        }
    }
}
