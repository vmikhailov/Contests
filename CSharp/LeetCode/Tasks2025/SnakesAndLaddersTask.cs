namespace LeetCode.Tasks2025;

public class SnakesAndLaddersTask
{
    //  909. Snakes and Ladders
    public int SnakesAndLadders1(int[][] board)
    {
        var n = board.Length;
        var nn = n * n;
        var line = new int[nn];

        for(var i = 0; i < n; i++)
        {
            for(var j = 0; j < n; j++)
            {
                var y = n - i - 1;
                var x = (i & 1) == 1 ? n - j - 1 : j;
                line[i * n + j] = board[y][x];
            }
        }

        var queue = new Queue<(int pos, int moves)>();
        var visited = new bool[nn];
        queue.Enqueue((0, 0));
        visited[0] = true;

        while(queue.Count > 0)
        {
            var (pos, moves) = queue.Dequeue();
            if(pos == nn - 1)
            {
                return moves;
            }

            var c1 = pos + 1;
            var c2 = Math.Min(pos + 6, nn - 1);
            for(var k = c1; k <= c2; k++)
            {
                var next = line[k] != -1 ? line[k] - 1 : k;
                if(visited[next]) continue;
                visited[next] = true;
                queue.Enqueue((next, moves + 1));
            }
        }

        return -1;
    }

    public int SnakesAndLadders(int[][] board)
    {
        var n = board.Length;
        var nn = n * n;
        var line = GetLine(board, n).ToArray();

        var queue = new Queue<(int pos, int moves)>();
        var visited = new bool[nn];
        queue.Enqueue((0, 0));
        visited[0] = true;

        while(queue.Count > 0)
        {
            var (pos, moves) = queue.Dequeue();
            if(pos == nn - 1)
            {
                return moves;
            }

            var c1 = pos + 1;
            var c2 = Math.Min(pos + 6, nn - 1);
            for(var k = c1; k <= c2; k++)
            {
                var next = line[k] != -1 ? line[k] - 1 : k;
                if(visited[next]) continue;
                visited[next] = true;
                queue.Enqueue((next, moves + 1));
            }
        }

        return -1;
    }

    private static IEnumerable<int> GetLine(int[][] board, int n)
    {
        for(var i = 0; i < n; i++)
        {
            for(var j = 0; j < n; j++)
            {
                var y = n - i - 1;
                var x = (i & 1) == 1 ? n - j - 1 : j;
                yield return board[y][x];
            }
        }
    }


}
