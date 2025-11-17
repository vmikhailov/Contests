namespace LeetCode.Tasks2025;

public class GameOfLifeTask
{
    public void GameOfLife(int[][] board)
    {
        var m = board.Length;
        var n = board[0].Length;

        (int dr, int dc)[] dirs =
        [
            (-1, -1), (-1, 0), (-1, 1),
            (0, -1), (0, 1),
            (1, -1), (1, 0), (1, 1),
        ];

        for (var j = 0; j < m; j++)
        {
            for (var i = 0; i < n; i++)
            {
                var k = GetAliveNeighbors(j, i);
                var c = board[j][i];
                var isAlive = (c & 1) == 1;

                switch (isAlive)
                {
                    // Set bit 1 (next state) based on Game of Life rules
                    case true when (k == 2 || k == 3):
                    // Dead cell becomes alive with exactly 3 neighbors
                    case false when k == 3:
                        // Live cell survives with 2-3 neighbors
                        c |= 2;
                        break;
                }

                board[j][i] = c;
            }
        }

        for (var j = 0; j < m; j++)
        {
            for (var i = 0; i < n; i++)
            {
                board[j][i] >>= 1;
            }
        }

        return;

        int GetAliveNeighbors(int r, int c)
        {
            var count = 0;

            foreach (var (dr, dc) in dirs)
            {
                var nr = r + dr;
                var nc = c + dc;

                if ((uint)nr < m && (uint)nc < n)
                {
                    count += board[nr][nc] & 1;
                }
            }

            return count;
        }
    }
}
