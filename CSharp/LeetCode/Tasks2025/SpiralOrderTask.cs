

namespace LeetCode.Tasks2025;

public class SpiralOrderTask
{
    //Given an m x n matrix, return all elements of the matrix in spiral order.
    public IList<int> SpiralOrder(int[][] matrix)
    {
        var r = new List<(int x, int y)>();
        GetSpiral(0, 0, matrix[0].Length - 1, matrix.Length - 1, r);

        return r.Select(p => matrix[p.y][p.x]).ToList();
    }

    void GetSpiral(int x1, int y1, int x2, int y2, List<(int, int)> r)
    {
        while (x1 <= x2 && y1 <= y2)
        {
            var x = x1;
            var y = y1;
            while (x <= x2) r.Add((x++, y));

            x--;
            y++;
            while (y <= y2) r.Add((x, y++));

            if (y1 < y2)
            {
                y--;
                x--;
                while (x >= x1) r.Add((x--, y));
            }

            if (x1 < x2)
            {
                x++;
                y--;
                while (y >= y1 + 1) r.Add((x, y--));
            }

            x1++;
            y1++;
            x2--;
            y2--;
        }
    }
}
