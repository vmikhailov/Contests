using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Codewars.Entry
{
    public static class NothingToDo
    {
        public static IEnumerable<int[]> Build(int w, int h)
        {
            var s = 1;
            var z = w + h - 1;
            var mh = Math.Min(w, h);
            var mw = Math.Min(w - 1, h);
            var r = new int[w];
            for (var j = 0; j < h; j++)
            {
                var t = s;
                for (var i = 0; i < w; i++)
                {
                    r[i] = t;
                    var k = i + j + 1;
                    k = (z - Math.Abs(z - 2 * k)) / 2;
                    t += Math.Min(k, mw);
                }

                yield return r;
                s += Math.Min(j + 2, mh);
            }
        }

        public static void Main1()
        {
            var v = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            
            foreach (var s in Build(v[0], v[1]))
            {
                Console.WriteLine(string.Join(" ", s));
            }
        }
    }

    public static class NothingToDoTest
    {
        public static void Test1()
        {
            var r = new Random();
            for (int i = 0; i < 1000; i++)
            {
                var w = r.Next(100) + 1;
                var h = r.Next(100) + 1;
                var m = w * h;
                var s = NothingToDo.Build(w, h);

                var s1 = s.SelectMany(x => x).Distinct().Sum();
                var s2 = m * (m + 1) / 2;
                Assert.AreEqual(s1, s2);
            }
        }
    }
}