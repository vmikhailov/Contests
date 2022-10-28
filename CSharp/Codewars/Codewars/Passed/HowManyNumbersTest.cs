using System.Collections.Generic;
using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    public class HowManyNumbersTest
    {
        [Test]
        public void ExampleTests()
        {
            // Assert.AreEqual(new List<long> { 8L, 118L, 334L }, HowManyNumbers.FindAll(10, 3));
            // Assert.AreEqual(new List<long> { 1L, 999L, 999L }, HowManyNumbers.FindAll(27, 3));
            // Assert.AreEqual(new List<long> { }, HowManyNumbers.FindAll(84, 4));
            // Assert.AreEqual(new List<long> { 123L, 116999L, 566666L }, HowManyNumbers.FindAll(35, 6));
            Assert.AreEqual(new List<long> { 123L, 116999L, 566666L }, HowManyNumbers.FindAll(53, 8));
        }
    }
}