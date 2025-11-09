namespace LeetCode.Tasks;

public class MostBeautifulItemForEachQuery
{
    public class FirstComparer : IComparer<int[]>
    {
        public int Compare(int[]? x, int[]? y)
        {
            var comparison = Comparer<int>.Default.Compare(x![0], y![0]);
            return comparison != 0 ? comparison : -Comparer<int>.Default.Compare(x[1], y[1]);
        }
    }
    
    public class SecondComparer : IComparer<int[]>
    {
        public int Compare(int[]? x, int[]? y)
        {
            if (x != null && y != null)
            {
                return Comparer<int>.Default.Compare(x[0], y[0]);
            }

            return ReferenceEquals(x, y) ? 0 : x is null ? -1 : 1;
        }
    }

    public int[] MaximumBeauty(int[][] items, int[] queries)
    {
        Array.Sort(items, new FirstComparer());
        var m = 0;

        foreach (var t in items)
        {
            t[1] = m = Math.Max(m, t[1]);
        }

        var cmp = new SecondComparer();
        var r = new int[queries.Length];
        for (var i = 0; i < queries.Length; i++)
        {
            var q = queries[i];
            var j = Array.BinarySearch(items, [q, 0], cmp);
            r[i] = j >= 0 ? items[j][1] : j <= -2 ? items[-j - 2][1] : 0;
        }

        return r;
    }

    public int[] MaximumBeauty1(int[][] items, int[] queries)
    {
        var ord = items.OrderBy(x => x[0]).ThenByDescending(x => x[1]).ToList();
        var n = items.Length;
        var p = new int[n];
        var b = new int[n];

        var m = 0;
        for (var i = 0; i < p.Length; i++)
        {
            p[i] = ord[i][0];
            b[i] = m = Math.Max(m, ord[i][1]);
        }

        var r = new int[queries.Length];
        for (var i = 0; i < queries.Length; i++)
        {
            var q = queries[i];
            var j = Array.BinarySearch(p, q);
            r[i] = j >= 0 ? b[j] : j <= -2 ? b[-j - 2] : 0;
        }

        return r;
    }


    public int[] MaximumBeauty2(int[][] items, int[] queries)
    {
        var ord = items.OrderBy(x => x[0]).ThenByDescending(x => x[1]).ToList();
        var n = items.Length;
        var p = new int[n];
        var b = new int[n];

        var m = 0;
        for (var i = 0; i < ord.Count; i++)
        {
            p[i] = items[i][0];
            b[i] = m = Math.Max(m, items[i][1]);
        }

        var r = new int[queries.Length];
        for (var i = 0; i < queries.Length; i++)
        {
            var q = queries[i];
            var j = Array.BinarySearch(p, q);
            r[i] = j >= 0 ? b[j] : j <= -2 ? b[-j - 2] : 0;
        }

        return r;
    }
}
