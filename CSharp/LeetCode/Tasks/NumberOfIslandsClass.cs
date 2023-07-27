namespace LeetCode.Tasks;

public class NumberOfIslandsClass
{
    public int NumIslands(char[][] grid)
    {
        var k = 0;
        var yy = grid.Length;
        var xx = grid[0].Length;
        for (var y = 0; y < yy; y++)
        {
            for (var x = 0; x < xx; x++)
            {
                if (grid[y][x] == '1')
                {
                    MarkIsland(x, y, xx, yy, grid);
                    k++;
                }
            }
        }

        return k;
    }

    private void MarkIsland(int x, int y, int xx, int yy, char[][] grid)
    {
        if (x < 0 || x >= xx || y < 0 || y >= yy || grid[y][x] != '1') return;

        grid[y][x] = '*';
        MarkIsland(x - 1, y, xx, yy, grid);
        MarkIsland(x, y - 1, xx, yy, grid);
        MarkIsland(x + 1, y, xx, yy, grid);
        MarkIsland(x, y + 1, xx, yy, grid);
    }
}