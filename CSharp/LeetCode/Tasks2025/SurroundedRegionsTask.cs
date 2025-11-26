namespace LeetCode.Tasks2025;

public class SurroundedRegionsTask
{
    public void Solve(char[][] board)
    {
        var m = board.Length;
        var n = board[0].Length;
        var v = new bool[m, n];
        var f = new bool[m, n];

        for (var i = 0; i < m; i++)
        {
            TryMarkRegion(i, 0);
            TryMarkRegion(i, n - 1);
        }

        for (var j = 0; j < n; j++)
        {
            TryMarkRegion(0, j);
            TryMarkRegion(m - 1, j);
        }

        for(var i = 0; i < m; i++)
        {
            for(var j = 0; j < n; j++)
            {
                if(board[i][j] == 'O' && !f[i,j])
                {
                    board[i][j] = 'X';
                }
            }
        }

        return;

        void TryMarkRegion(int i, int j)
        {
            var q = new Queue<(int I, int J)>();
            q.Enqueue((i, j));

            while (q.Count > 0)
            {
                (i, j) = q.Dequeue();

                if (board[i][j] != 'O' || v[i, j]) continue;

                f[i, j] = true;
                v[i, j] = true;

                if (i > 0) q.Enqueue((i - 1, j));
                if (j > 0) q.Enqueue((i, j - 1));
                if (i < m - 1) q.Enqueue((i + 1, j));
                if (j < n - 1) q.Enqueue((i, j + 1));
            }
        }
    }


    public void Solve1(char[][] board)
    {
        var m = board.Length;
        var n = board[0].Length;
        var v = new bool[m, n];

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (board[i][j] == 'O' && !v[i, j])
                {
                    TryCollapseRegion(i, j);
                }
            }
        }

        return;

        void TryCollapseRegion(int i, int j)
        {
            var cells = new List<(int I, int J)>();
            int iMin = m, iMax = 0, jMin = n, jMax = 0;
            var q = new Queue<(int I, int J)>();

            q.Enqueue((i, j));

            while (q.Count > 0)
            {
                (i, j) = q.Dequeue();

                if (board[i][j] != 'O' || v[i, j]) continue;

                cells.Add((i, j));
                v[i, j] = true;
                iMin = Math.Min(iMin, i);
                iMax = Math.Max(iMax, i);
                jMin = Math.Min(jMin, j);
                jMax = Math.Max(jMax, j);

                if (i > 0) q.Enqueue((i - 1, j));
                if (j > 0) q.Enqueue((i, j - 1));
                if (i < m - 1) q.Enqueue((i + 1, j));
                if (j < n - 1) q.Enqueue((i, j + 1));
            }

            // try collapse
            var isCollapsible = iMin > 0 && jMin > 0 && iMax < m - 1 && jMax < n - 1;

            if (!isCollapsible)
            {
                return;
            }

            foreach (var c in cells)
            {
                board[c.I][c.J] = 'X';
            }
        }
    }
}
