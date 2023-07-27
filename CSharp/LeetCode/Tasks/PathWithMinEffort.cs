namespace LeetCode.Tasks;

public class PathWithMinEffort
{
    public int MinimumEffortPath(int[][] heights)
    {
        var nRows = heights.Length;
        var nCols = heights[0].Length;
        var cost = new int[nRows][];

        for (var i = 0; i < nRows; i++)
        {
            cost[i] = new int[nCols];
            Array.Fill(cost[i], int.MaxValue);
        }

        cost[0][0] = 0;

        var queue = new Queue<(int X, int Y)>();
        queue.Enqueue((0, 0));

        while (queue.Any())
        {
            var c1 = queue.Dequeue();
            var a = heights[c1.Y][c1.X];
            var v1 = cost[c1.Y][c1.X];

            foreach (var c2 in EnumCells(c1.X, c1.Y))
            {
                var b = heights[c2.Y][c2.X];
                var v2 = Math.Max(v1, Math.Min(cost[c2.Y][c2.X], Math.Abs(b - a)));
                if (v2 < cost[c2.Y][c2.X])
                {
                    cost[c2.Y][c2.X] = v2;
                    queue.Enqueue(c2);
                }
            }
        }

        return cost[nRows - 1][nCols - 1];

        IEnumerable<(int X, int Y)> EnumCells(int x, int y)
        {
            if (x > 0) yield return (x - 1, y);
            if (y > 0) yield return (x, y - 1);
            if (x < nCols - 1) yield return (x + 1, y);
            if (y < nRows - 1) yield return (x, y + 1);
        }
    }
}