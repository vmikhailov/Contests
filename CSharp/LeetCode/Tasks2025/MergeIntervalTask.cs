namespace LeetCode.Tasks2025;

public class MergeIntervalTask
{
    // Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals,
    // and return an array of the non-overlapping intervals that cover all the intervals in the input.
    public int[][] Merge(int[][] intervals)
    {
        if (intervals.Length == 0) return [];

        Array.Sort(intervals, (a, b) =>
        {
            var cmp = a[0].CompareTo(b[0]);
            return cmp != 0 ? cmp : b[1].CompareTo(a[1]);
        });

        var result = new List<int[]>();

        var cs = intervals[0][0];
        var ce = intervals[0][1];

        for (var i = 1; i < intervals.Length; i++)
        {
            var ns = intervals[i][0];
            var ne = intervals[i][1];

            // if interval overlaps or touches
            if (ns <= ce)
            {
                ce = Math.Max(ce, ne);
            }
            else
            {
                // add current interval
                result.Add([cs, ce]);
                // start new interval
                cs = ns;
                ce = ne;
            }
        }

        return result.Append([cs, ce]).ToArray();
    }
}


