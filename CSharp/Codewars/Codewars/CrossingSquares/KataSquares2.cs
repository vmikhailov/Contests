using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Codewars.Codewars.CrossingSquares
{
    public static class KataSquares2
    {
        public static long Calculate(IEnumerable<int[]> rectangles)
        {
            var list = rectangles.ToList();
            var xx = GetCoords(list, 0, 2).OrderBy(x => x).ToArray();
            var yy = GetCoords(list, 1, 3).OrderBy(x => x).ToArray();

            var map = new BitArray[xx.Length];

            foreach (var r in list)
            {
                var x1 = Array.BinarySearch(xx, r[0]);
                var x2 = Array.BinarySearch(xx, r[2]);
                var y1 = Array.BinarySearch(yy, r[1]);
                var y2 = Array.BinarySearch(yy, r[3]);
                for (var x = x1; x < x2; x++)
                {
                    var bits = map[x] ??= new BitArray(yy.Length);
                    for (var y = y1; y < y2; y++) bits.Set(y, true);
                }
            }
            
            var s = 0L;
            for (var x = 0; x < map.Length - 1; x++)
            {
                if(map[x] == null) continue;
                for (var y = 0; y < map[x].Length - 1; y++)
                {
                    if (map[x].Get(y))
                    {
                        s += (xx[x + 1] - xx[x]) * (yy[y + 1] - yy[y]);
                    }
                }
            }

            return s;
        }

        private static IEnumerable<int> GetCoords(IEnumerable<int[]> rectangles, int c1, int c2)
        {
            foreach (var r in rectangles)
            {
                yield return r[c1];
                yield return r[c2];
            }
        }

        private static void Print(BitArray[] map, int rowlen)
        {
            Debug.WriteLine("-------------------");
            for (var x = 0; x < map.Length; x++)
            {
                var bits = map[x] ??= new BitArray(rowlen);
                for (var y = 0; y < bits.Length; y++)
                {
                    Debug.Write(bits.Get(y) ? "+" : "-");
                }

                Debug.WriteLine("");
            }
            
        }
    }
}