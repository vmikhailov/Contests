using System.Linq;
using NUnit.Framework;

namespace Codewars.Entry
{
    [TestFixture]
    public class GraphCodeTest
    {
        [Test]
        public void Test1()
        {
            var r = new[]
            {
                new[] { 2, 1 },
                new[] { 1, 4 },
                new[] { 4, 5 },
                new[] { 5, 3 },
                new[] { 5, 6 },
            };

            Assert.AreEqual(new[] { 1, 4, 5, 5 }, GraphCode.GetCode(6, r.ToList()));
        }
    }
}