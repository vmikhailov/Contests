using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Codewars.Other
{
    public class Lamps11
    {
        public static void Compute(int n, int k)
        {
            var v = 0;
            Fill(0, 0, n, k, ref v);
            TestContext.WriteLine(v);
        }

        private static void Fill(int i, int p, int n, int k, ref int v)
        {
            if (i == n)
            {
                v++;
            }
            else
            {
                for (var j = 1; j <= k; j++)
                {
                    if(i > 0 && p == j) continue;
                    Fill(i + 1, j, n, k, ref v);
                }
            }
        }
    }

    [TestFixture]
    public class Lamps11Test
    {
        private int n = 11;

        [Test]
        public void Test1()
        {
            Lamps11.Compute(n, 3);
        }
    }
}