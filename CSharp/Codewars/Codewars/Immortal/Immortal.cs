using NUnit.Framework;

namespace Codewars.Codewars.Immortal
{
    public class Immortal
    {
        public void Solve(long m, long n, long t)
        {
            var f = 0L;
            var s = 0L;
            var d = 0L;
            for (var i = 0L; i < m; i++)
            {
                for (var j = 0L; j < n; j++)
                {
                    var v = i ^ j;
                    v = v > t ? v - t : 0;
                    s += v;
                    f += (v) % 8;
                    d += (v) / 8;
                    TestContext.Write($"{v / 16, 2}");
                    //TestContext.Write($"{(i^j) , 2}");
                    //if(j < n)  TestContext.Write("");
                }
                TestContext.WriteLine("");
            }
            TestContext.WriteLine($"s = {s} {f} {d} {f*2+d}");
        }
    }
}