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

    // Optimization 1: Space-optimized O(n) instead of O(m*n)
    // Since we only need the previous row to compute the current row, we can use rolling arrays
    public int MinFallingPathSumSpaceOptimized(int[][] matrix)
    {
        var n = matrix[0].Length;
        var prev = new int[n];
        var curr = new int[n];

        // Initialize with last row
        Array.Copy(matrix[^1], prev, n);

        // Process from second-to-last row to first row
        for (var row = matrix.Length - 2; row >= 0; row--)
        {
            for (var col = 0; col < n; col++)
            {
                var left = col > 0 ? prev[col - 1] : int.MaxValue;
                var middle = prev[col];
                var right = col < n - 1 ? prev[col + 1] : int.MaxValue;

                curr[col] = matrix[row][col] + Min(left, middle, right);
            }

            // Swap arrays for next iteration
            (prev, curr) = (curr, prev);
        }

        // Find minimum in the first row (which is now in prev)
        return prev.Min();
    }

    // Optimization 2: In-place modification (modifies input matrix)
    // Space: O(1) - no extra space needed
    public int MinFallingPathSumInPlace(int[][] matrix)
    {
        var n = matrix[0].Length;

        // Process from second-to-last row to first row
        for (var row = matrix.Length - 2; row >= 0; row--)
        {
            for (var col = 0; col < n; col++)
            {
                var left = col > 0 ? matrix[row + 1][col - 1] : int.MaxValue;
                var middle = matrix[row + 1][col];
                var right = col < n - 1 ? matrix[row + 1][col + 1] : int.MaxValue;

                matrix[row][col] += Min(left, middle, right);
            }
        }

        return matrix[0].Min();
    }

    // Optimization 3: Single array space-optimized with manual min tracking
    // Avoids LINQ Min() call for better performance
    public int MinFallingPathSumOptimized(int[][] matrix)
    {
        var n = matrix[0].Length;
        var dp = new int[n];

        // Initialize with last row
        for (var i = 0; i < n; i++)
        {
            dp[i] = matrix[^1][i];
        }

        // Process from second-to-last row to first row
        for (var row = matrix.Length - 2; row >= 0; row--)
        {
            var newDp = new int[n];
            for (var col = 0; col < n; col++)
            {
                var minPrev = dp[col]; // middle
                if (col > 0 && dp[col - 1] < minPrev)
                    minPrev = dp[col - 1]; // left
                if (col < n - 1 && dp[col + 1] < minPrev)
                    minPrev = dp[col + 1]; // right

                newDp[col] = matrix[row][col] + minPrev;
            }
            dp = newDp;
        }

        // Find minimum manually
        var result = dp[0];
        for (var i = 1; i < n; i++)
        {
            if (dp[i] < result)
                result = dp[i];
        }
        return result;
    }

    // Optimization 4: ArrayPool for zero-allocation performance
    public int MinFallingPathSumArrayPool(int[][] matrix)
    {
        var n = matrix[0].Length;
        var pool = System.Buffers.ArrayPool<int>.Shared;

        var prev = pool.Rent(n);
        var curr = pool.Rent(n);

        try
        {
            // Initialize with last row
            Array.Copy(matrix[^1], prev, n);

            // Process from second-to-last row to first row
            for (var row = matrix.Length - 2; row >= 0; row--)
            {
                for (var col = 0; col < n; col++)
                {
                    var minPrev = prev[col]; // middle
                    if (col > 0 && prev[col - 1] < minPrev)
                        minPrev = prev[col - 1]; // left
                    if (col < n - 1 && prev[col + 1] < minPrev)
                        minPrev = prev[col + 1]; // right

                    curr[col] = matrix[row][col] + minPrev;
                }

                (prev, curr) = (curr, prev);
            }

            // Find minimum
            var result = prev[0];
            for (var i = 1; i < n; i++)
            {
                if (prev[i] < result)
                    result = prev[i];
            }
            return result;
        }
        finally
        {
            pool.Return(prev);
            pool.Return(curr);
        }
    }

    private static int Min(int v1, int v2, int v3)
    {
        return Math.Min(v1, Math.Min(v2, v3));
    }
}
