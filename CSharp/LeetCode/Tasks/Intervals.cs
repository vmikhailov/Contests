namespace LeetCode.Tasks;

public class Intervals
{
    public int[][] Merge(int[][] intervals)
    {
        var r = new List<int>();
        var m = new List<int>();

        foreach (var interval in intervals)
        {
            var indexes = new int[2];
            for (var i = 0; i < 2; i++)
            {
                var p = r.BinarySearch(interval[i]);
                if (p < 0)
                {
                    p = -p - 1;
                    r.Insert(p, interval[i]);
                    if(p > 0) m.Insert(p, m[p - 1]);
                    else m.Insert(p, 0);
                }

                indexes[i] = p;
            }

            for (var i = indexes[0]; i < indexes[1]; i++)
            {
                m[i] = 1;
            }
        }

        var v = new List<int[]>();
        var j = 0;
        while (j < m.Count)
        {
            var i = j;         
            while (m[j] == 1) j++;
            v.Add(new[] { r[i], r[j] });
            j++;
        }

        return v.ToArray();
    }
}