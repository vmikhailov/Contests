using System;
using System.Linq;

namespace Codewars.Codewars.Passed
{
    public class Intervals
    {
        public static int SumIntervals((int, int)[] intervals)
        {
            var intrv = intervals.OrderBy(x => x.Item1).Select(x => new Interval(x.Item1, x.Item2)).ToList();

            for (var i = 0; i < intrv.Count - 1;)
            {
                if (intrv[i].HasIntersection(intrv[i + 1]))
                {
                    intrv[i].Merge(intrv[i + 1]);
                    intrv.RemoveAt(i + 1);
                    i = 0;
                }
                else
                {
                    i++;
                }
            }

            var len = intrv.Select(x => x.Length).Sum();

            return len;
        }

        public class Interval
        {
            public int Left { get; private set; }
            public int Right { get; private set; }

            public Interval(int left, int right)
            {
                Left = left;
                Right = right;
            }

            public bool HasIntersection(Interval interval)
            {
                return !(interval.Right < Left || Right < interval.Left);
            }

            public void Merge(Interval interval)
            {
                if (HasIntersection(interval))
                {
                    Left = Math.Min(Left, interval.Left);
                    Right = Math.Max(Right, interval.Right);
                }
            }

            public int Length => Right - Left;
        }
    }
}