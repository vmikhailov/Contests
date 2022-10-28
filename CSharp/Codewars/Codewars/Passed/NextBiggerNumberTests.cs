using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    [TestFixture]
    public class NextBiggerNumberTests
    {
        [Test]
        public void Test1()
        {
            Console.WriteLine("****** Small Number");
            Assert.AreEqual(21, Kata.NextBiggerNumber(12));
            Assert.AreEqual(531, Kata.NextBiggerNumber(513));
            Assert.AreEqual(2071, Kata.NextBiggerNumber(2017));
            Assert.AreEqual(441, Kata.NextBiggerNumber(414));
            Assert.AreEqual(414, Kata.NextBiggerNumber(144));
        }
    }

    public static partial class Kata
    {
        public static long NextBiggerNumber(long n)
        {
            var d = Digits(n).ToList();
            for (var i = d.Count - 2; i >= 0; i--)
            {
                for (var j = d.Count - 1; j >= i; j--)
                {
                    if (d[j] > d[i])
                    {
                        var s = d[i];
                        d[i] = d[j];
                        d[j] = s;

                        return long.Parse(string.Join("", d));
                    }
                }
            }

            return -1;
        }
    
        private static IEnumerable<int> Digits(long n)
        {
            var p = (long)Math.Pow(10, Math.Floor(Math.Log10(n)));
            while (p > 0)
            {
                var d = (n - n % p) / p;

                yield return (int)d;
                n = n - d * p;
                p = p / 10;
            }
        }
    }
}