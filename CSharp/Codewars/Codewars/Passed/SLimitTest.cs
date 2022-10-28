using System;
using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    [TestFixture]
    public static class SLimitTest {

        private static Random rnd = new Random();
        public static void assertFuzzy(double m, double expect)
        {
            var merr = 1e-12;
            Console.WriteLine("Testing " + m);
            var actual = SLimit.Solve(m);
            Console.WriteLine("Actual: " + actual);
            Console.WriteLine("Expect: " + expect);
            var inrange = Math.Abs(actual - expect) <= merr;
            if (inrange == false)
                Console.WriteLine("Expected must be near " + expect + ", got " + actual);
            Console.WriteLine("-");
            Assert.AreEqual(true, inrange);
        }

        [Test]
        public static void test() {
            Console.WriteLine("Fixed Tests: solve"); 
            assertFuzzy(2.00, 5.000000000000e-01);
            assertFuzzy(4.00, 6.096117967978e-01);
            assertFuzzy(5.00, 6.417424305044e-01);
        }
    }
}