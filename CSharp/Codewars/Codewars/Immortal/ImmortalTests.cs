using NUnit.Framework;

namespace Codewars.Codewars.Immortal
{
    [TestFixture]
    public class ImmortalTests
    {
        [TestCase(8, 8, 2)]
        [TestCase(8, 16, 10)]
        [TestCase(16, 16, 10)]
        [TestCase(33, 33, 10)]
        [TestCase(64, 64, 10)]
        public void TrySolve(long m, long n, long t)
        {
            var im = new Immortal();
            im.Solve(m, n, t);
        }
    }
}