namespace LeetCode.Tasks;

public class FindWord
{
    public bool Exist(char[][] board, string word)
    {
        var n = word.Length;
        var nr = board.Length;
        var nc = board[0].Length;
        var visited = new bool[nc, nr];
        var paths = new (int X, int Y)[nc, nr][];

        paths[0, 0] = new[] { (1, 0), (0, 1) };
        paths[nc - 1, 0] = new[] { (-1, 0), (0, 1) };
        paths[0, nr - 1] = new[] { (1, 0), (0, -1) };
        paths[nc - 1, nr - 1] = new[] { (-1, 0), (0, -1) };

        var noLeft = new[] { (1, 0), (0, 1), (0, -1) };
        var noRight = new[] { (-1, 0), (0, 1), (0, -1) };
        var noTop = new[] { (1, 0), (0, 1), (-1, 0) };
        var noBottom = new[] { (1, 0), (0, -1), (-1, 0) };

        for (var x = 1; x < nc - 1; x++)
        {
            paths[x, 0] = noTop;
            paths[x, nr - 1] = noBottom;
        }

        for (var y = 1; y < nr - 1; y++)
        {
            paths[0, y] = noLeft;
            paths[nc - 1, y] = noRight;
        }

        var allWays = new[] { (-1, 0), (0, -1), (1, 0), (0, 1) };
        for (var y = 1; y < nr - 1; y++)
        {
            for (var x = 1; x < nc - 1; x++)
            {
                paths[x, y] = allWays;
            }
        }

        for (var y = 0; y < nr; y++)
        {
            for (var x = 0; x < nc; x++)
            {
                if (Check(x, y, 0)) return true;
            }
        }

        return false;

        bool Check(int x, int y, int i)
        {
            if (visited[x, y]) return false;
            if (i == n) return true;
            if (word[i] != board[y][x]) return false;
            if (i == n - 1) return true;

            visited[x, y] = true;
            foreach (var d in paths[x, y])
            {
                if (Check(x + d.X, y + d.Y, i + 1)) return true;
            }

            visited[x, y] = false;
            return false;
        }
    }
}