using System.Collections.Generic;

namespace Codewars.Codewars.Passed
{
    public class Primes
    {
        public static Atkin generator;
        public static IEnumerable<int> Stream()
        {
            if (generator == null)
            {
                generator = new Atkin();
                generator.FindPrimes(1_000_000_000);
            }

            return generator.Primes;
        }
    }
}