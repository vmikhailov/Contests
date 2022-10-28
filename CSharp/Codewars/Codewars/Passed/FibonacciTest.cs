using System.Numerics;
using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    public class FibonacciTest
    {

        [Test]
        public void testFib0()
        {
            testFib(0, 0);
        }

        [Test]
        public void testFib1()
        {
            testFib(1, 1);
        }

        [Test]
        public void testFib2()
        {
            testFib(1, 2);
        }

        [Test]
        public void testFib3()
        {
            testFib(2, 3);
        }

        [Test]
        public void testFib4()
        {
            testFib(610, 15);
            testFib(-6, -6);
            testFib2(610, 1500000000);
            testFib(610, -15);
        }

        [Test]
        public void testFib5()
        {
            testFib(12586269025, 50);
        }

        private static void testFib(long expected, int input)
        {
            var found = Fibonacci.fib(input);
            Assert.AreEqual(new BigInteger(expected), found);
        }
    
        private static void testFib2(long expected, int input)
        {
            var found = Fibonacci.fib(input);
            Assert.AreEqual(new BigInteger(expected), found);
        }

    }
}