namespace LeetCode.Tasks2025;

public class MinFallingPathSumTask
{
    /*
     * Given an n x n array of integers matrix, return the minimum sum of any falling path through matrix.

       A falling path starts at any element in the first row and chooses the element in the next row that is
       either directly below or diagonally left/right. Specifically, the next element
       from position (row, col) will be (row + 1, col - 1), (row + 1, col), or (row + 1, col + 1).
     */
    public int MinFallingPathSum(int[][] matrix)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;
        var d = new int[m,n];
        var j = m - 1;

        for(var i = 0; i < n; i++)
        {
            d[j, i] = matrix[j][i];
        }

        while(--j >= 0)
        {
            for(var i = 0; i < n; i++)
            {
                var v1 = i > 0 ? d[j + 1, i - 1] : int.MaxValue;
                var v2 = d[j + 1, i];
                var v3 = i < n - 1 ? d[j + 1, i + 1] : int.MaxValue;

                d[j, i] = matrix[j][i] + Min(v1, v2, v3);
            }
        }

        var r = d[0,0];
        for(var i = 1; i < n; i++)
        {
            r = Math.Min(r, d[0, i]);
        }
        return r;
    }

    private static int Min(int v1, int v2, int v3)
    {
        return Math.Min(v1, Math.Min(v2, v3));
    }
}
