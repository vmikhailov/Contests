namespace LeetCode.Tasks2025;

public class MinimumPathSumTask
{
    /*Given a m x n grid filled with non-negative numbers, find a path from top left
     to bottom right, which minimizes the sum of all numbers along its path.

     Note: You can only move either down or right at any point in time.
    */

    public int MinPathSum(int[][] grid)
    {
        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                grid[i][j] += (i, j) switch
                {
                    (0, 0) => 0,
                    (0, _) => grid[i][j - 1],
                    (_, 0) => grid[i - 1][j],
                    _ => Math.Min(grid[i - 1][j], grid[i][j - 1])
                };
            }
        }

        return grid[^1][^1];
    }

    public int MinPathSum2(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var q = new Queue<(int X, int Y)>();
        var v = new HashSet<(int X, int Y)>();

        q.Enqueue((m - 1, n - 1));

        while (q.Count > 0)
        {
            var (x, y) = q.Dequeue();
            SetMinSum(x, y);
            PopulateWayBack(x, y);
        }

        return grid[0][0];

        void PopulateWayBack(int x, int y)
        {
            if (x > 0 && v.Add((x - 1, y)))
            {
                q.Enqueue((x - 1, y));
            }

            if (y > 0 && v.Add((x, y - 1)))
            {
                q.Enqueue((x, y - 1));
            }
        }

        void SetMinSum(int x, int y)
        {
            var min = 0;

            if (x < m - 1 && y < n - 1)
            {
                min = Math.Min(grid[x + 1][y], grid[x][y + 1]);
            }
            else if (x == m - 1 && y < n - 1)
            {
                min = grid[x][y + 1];
            }
            else if (x < m - 1 && y == n - 1)
            {
                min = grid[x + 1][y];
            }

            grid[x][y] += min;
        }
    }
}
