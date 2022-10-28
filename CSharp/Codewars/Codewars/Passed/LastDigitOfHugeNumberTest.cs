using System;
using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    [TestFixture]
    public class LastDigitOfHugeNumberTest
    {
        private struct LDCase
        {
            public int[] test;
            public int expect;

            public LDCase(int[] t, int e)
            {
                test = t;
                expect = e;
            }
        }


        [TestCase(new int[0], 1)]
        [TestCase(new[] { 0, 0 }, 1)]
        [TestCase(new[] { 0, 0, 0 }, 0)]
        [TestCase(new[] { 1, 2 }, 1)]
        [TestCase(new[] { 3, 3, 1 }, 7)]
        [TestCase(new[] { 3, 4, 5 }, 1)]
        [TestCase(new[] { 4, 3, 6 }, 4)]
        [TestCase(new[] { 7, 6, 21 }, 1)]
        [TestCase(new[] { 12, 30, 21 }, 6)]
        [TestCase(new[] { 2, 2, 2, 0 }, 4)]
        [TestCase(new[] { 2, 2, 1 }, 4)]
        [TestCase(new[] { 4, 4, 4 }, 6)]
        [TestCase(new[] { 2, 0, 1, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1 }, 1)]
        [TestCase(new[] { 937640, 767456, 981242 }, 0)]
        [TestCase(new[] { 123232, 694022, 140249 }, 6)]
        [TestCase(new[] { 499942, 898102, 846073 }, 6)]
        [TestCase(new[] { 925603, 644216, 17944, 462250, 250838, 663141, 504044, 209438, 235040 }, 1)]
        public void SampleTest(int[] powers, int expected)
        {
            var actual = LastDigitOfHugeNumber.LastDigit(powers);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RandomTest()
        {
            var rnd = new Random();
            for (var i = 0; i < 1000; i++)
            {
                var rand1 = rnd.Next(0, 100);
                var rand2 = rnd.Next(0, 10);

                Assert.AreEqual(rand1 % 10, LastDigitOfHugeNumber.LastDigit(new[] { rand1 }));
                Assert.AreEqual((int)Math.Pow(rand1 % 10, rand2) % 10, LastDigitOfHugeNumber.LastDigit(new[] { rand1, rand2 }));
            }
        }
    }
}