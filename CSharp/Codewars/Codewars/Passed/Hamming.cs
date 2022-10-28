using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Codewars.Codewars.Passed
{
    public class Hamming
    {
        private static List<(BigInteger, int, int, int)> numbers = new List<(BigInteger, int, int, int)>();
        public static long hamming(int n)
        {
            if (!numbers.Any())
            {
                for (var i = 0; i < 50; i++)
                {
                    for (var j = 0; j < 30; j++)
                    {
                        for (var k = 0; k < 20; k++)
                        {
                            var d = GetHamming(i, j, k);
                            numbers.Add((d, i, j, k));
                        }
                    }
                }
                numbers = numbers.OrderBy(x => x.Item1).ToList();
            }

            return (long)numbers[n - 1].Item1;
        }

        public static BigInteger GetHamming(int i, int j, int k)
        {
            return BigInteger.Pow(2, i) * BigInteger.Pow(3, j) * BigInteger.Pow(5, k);
        }
    }
}