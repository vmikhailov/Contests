namespace LeetCode.Tasks2025;

public class InsertIntervalTask
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        var result = new List<int[]>();
        var start = newInterval[0];
        var end = newInterval[1];
        var i = 0;

        // Add all intervals that end before newInterval starts
        while (i < intervals.Length && intervals[i][1] < newInterval[0])
        {
            result.Add(intervals[i]);
            i++;
        }

        // Merge all overlapping intervals
        while (i < intervals.Length && intervals[i][0] <= newInterval[1])
        {
            start = Math.Min(start, intervals[i][0]);
            end = Math.Max(end, intervals[i][1]);
            i++;
        }
        result.Add([start, end]);

        // Add remaining intervals
        while (i < intervals.Length)
        {
            result.Add(intervals[i]);
            i++;
        }

        return result.ToArray();

    }
}
