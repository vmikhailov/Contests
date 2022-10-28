using System;
using System.Diagnostics;
using System.Linq;

namespace Codewars.Entry
{
    public static class BrokenStair
    {
        public static bool Compute(int n, int[] brokenIdx, int x, int y)
        {
            var accessible = new bool[n + 1];
            var broken = new bool[n + 1];
            foreach (var b in brokenIdx) broken[b] = true;
            
            accessible[0] = true;
            for (var i = 0; i <= n; i++)
            {
                if(broken[i]) continue;
                if(!accessible[i]) continue;

                if (Mark(n, i, broken, accessible, x) ||
                    Mark(n, i, broken, accessible, y)) return true;
            }

            return false;
        }

        public static bool Mark(int n, int i, bool[] broken, bool[] accessible, int x)
        {
            i += x;
            while (i <= n && !broken[i])
            {
                accessible[i] = true;

                if (i == n) return true;
                i += x;
            }

            return false;
        }


        public static void Main1()
        {
            var n = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var b = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var m = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Console.WriteLine(Compute(n[0], b, m[0], m[1]) ? "YES" : "NO");
        }

        public static void Test1()
        {
            Debug.Assert(Compute(5, new[] { 1, 3 }, 2, 1));
        }
    }
}