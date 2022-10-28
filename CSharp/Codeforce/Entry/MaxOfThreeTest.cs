using System;
using NUnit.Framework;

namespace Codewars.Entry
{
    [TestFixture]
    public class MaxOfThreeTest
    {
        [Test]
        public void Test1()
        {
            var a = MaxOfThree.Calculate(
                new []
                {
                    new []{ 1, 2, 3 },
                    new []{ 4, 5, 6 },
                    new []{ 3, 6, 7 }
                });
            
            Assert.AreEqual(19, a);
        }
        
        
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(5000)]
        [TestCase(10000)]
        [TestCase(20000)]
        [TestCase(40000)]
        public void Test2(int n)
        {
            var r = new Random();
            var m = new int[n][];
            for (var i = 0; i < n; i++)
            {
                m[i] = new int[n];
                for (var j = 0; j < n; j++)
                {
                    m[i][j] = r.Next(n);
                }
            }

            var a = MaxOfThree.Calculate(m);
        }
    }
}