using System;
using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    [TestFixture]
    public static class PrimeConsecTests
    {
        private static void testing(int k, long[] arr, int expected)
        {
            Assert.AreEqual(expected, PrimeConsec.ConsecKprimes(k, arr));
        }

        [Test]
        public static void test1()
        {
            Console.WriteLine("Basic Tests ConsecKprimes");
            testing(5, new long[] { 10116, 10108, 10092, 10104, 10100, 10096, 10088 }, 6);
        
            testing(4, new long[] { 10005, 10030, 10026, 10008, 10016, 10028, 10004 }, 3);
            testing(
                2,
                new long[]
                {
                    10081, 10071, 10077, 10065, 10060, 10070, 10086, 10083, 10078,
                    10076, 10089, 10085, 10063, 10074, 10068, 10073, 10072, 10075
                },
                2);
            testing(6, new long[] { 10098 }, 0);
            testing(6, new long[] { 10176, 10164 }, 0);
      
            testing(5, new long[] { 10188, 10192, 10212, 10184, 10200, 10208 }, 1);
            testing(4, new long[] { 10175, 10185, 10180, 10197 }, 3);
        }
    }
}