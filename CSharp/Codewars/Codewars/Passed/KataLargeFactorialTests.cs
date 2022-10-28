using System.Diagnostics;
using NUnit.Framework;

namespace Codewars.Codewars.Passed 
{
    [TestFixture]
    public class KataLargeFactorialTests
    {
        [Test]
        public void BasicTests()
        {
            var x0 = KataLargeFactorial.FF(6);
            var x3 = KataLargeFactorial.Factorial(6);
            var x4 = KataLargeFactorial.Factorial2(6);
          
            var sw = Stopwatch.StartNew();
            var n = 500;
            for (var i = 10; i < n; i++)
            {
                var f1 = KataLargeFactorial.Factorial(i);
            }
            sw.Stop();
            TestContext.WriteLine(sw.ElapsedMilliseconds);
            
            sw.Restart();
            for (var i = 10; i < n; i++)
            {
                var f1 = KataLargeFactorial.Factorial2(i);
            }
            sw.Stop();
            TestContext.WriteLine(sw.ElapsedMilliseconds);
            
            sw.Restart();
            for (var i = 10; i < n; i++)
            {
                var f1 = KataLargeFactorial.FF(i);
            }
            sw.Stop();
            TestContext.WriteLine(sw.ElapsedMilliseconds);
            

            KataLargeFactorial.Factorial(50);
            KataLargeFactorial.Factorial(150);
            Assert.AreEqual("1307674368000", KataLargeFactorial.Factorial(15));
            
            Assert.AreEqual("1", KataLargeFactorial.Factorial(1));
            Assert.AreEqual("120", KataLargeFactorial.Factorial(5));
            Assert.AreEqual("362880", KataLargeFactorial.Factorial(9));
            Assert.AreEqual("1307674368000", KataLargeFactorial.Factorial(15));
        }
    }
}