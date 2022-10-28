using System;
using System.Diagnostics;
using NUnit.Framework;

namespace Codewars.Codewars
{
    [TestFixture]
    public class SquareSumsTests
    {
        [TestCase(16)]
        [TestCase(23)]
        [TestCase(24)]
        [TestCase(25)]
        [TestCase(28)]
        [TestCase(40)]
        [TestCase(45)]
        [TestCase(51)]
        [TestCase(400)]
        [TestCase(1400)]
        public void TestCW(int n, int median = 0)
        {
            var sw = Stopwatch.StartNew();
            var result = SquareSumsFromCW.GetPermutation(n);
            if (n < 15 || n > 17 && n < 25 && n != 23)
            {
                Assert.IsNull(result);

                return;
            }
            
            Assert.IsNotNull(result);
            for (var i = 0; i < result.Length - 1; i++)
            {
                var s = result[i] + result[i + 1];
                var t = (int)Math.Sqrt(s);
                Assert.AreEqual(t * t, s);
            }

            var rr = string.Join("-", result);
            TestContext.WriteLine(rr);
            sw.Stop();
            s += sw.ElapsedMilliseconds;
            
        }

        [TestCase(16)]
        [TestCase(23)]
        [TestCase(24)]
        [TestCase(25)]
        [TestCase(28)]
        [TestCase(40)]
        [TestCase(45)]
        [TestCase(51)]
        [TestCase(400)]
        [TestCase(1400)]
        public void Test(int n, int median = 0)
        {
            var sw = Stopwatch.StartNew();
            var result = SquareSums.Decompose(n, median);
            if (n < 15 || n > 17 && n < 25 && n != 23)
            {
                Assert.IsNull(result);

                return;
            }
            
            Assert.IsNotNull(result);
            for (var i = 0; i < result.Length - 1; i++)
            {
                var s = result[i] + result[i + 1];
                var t = (int)Math.Sqrt(s);
                Assert.AreEqual(t * t, s);
            }

            var rr = string.Join("-", result);
            TestContext.WriteLine(rr);
            sw.Stop();
            s += sw.ElapsedMilliseconds;
            //TestContext.WriteLine($"{n,3} time = {sw.ElapsedMilliseconds}");
        }

        private static long s = 0;
        [TestCase(25, 1500)]
        [TestCase(25, 1000)]
        [TestCase(25, 500)]
        [TestCase(1, 50)]
        public void TestWithCodes(int n1, int n2)
        {
            s = 0;
            for (var n = n1; n <= n2; n++)
            {
                TestCW(n);
            }
            TestContext.WriteLine($"Total time {s}");
        }
    }
}