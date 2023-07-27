namespace LeetCode.Tasks;

public class SameLine
{
    public bool CheckStraightLine(int[][] coordinates)
    {
        if (coordinates.Length < 3) return true;

        for (var i = 0; i < coordinates.Length - 2; i++)
        {
            if (GetDeterminant(coordinates[i..]) != 0) return false;
        }

        return true;
    }

    private int GetDeterminant(ReadOnlySpan<int[]> c)
    {
        var m00 = c[0][0];
        var m01 = c[0][1];
        var m10 = c[1][0];
        var m11 = c[1][1];
        var m20 = c[2][0];
        var m21 = c[2][1];
  
        var d1 = m00 * m11 + m10 * m21 + m20 * m01;
        var d2 = m11 * m20 + m21 * m00 + m01 * m10;
        return d1 - d2;
    }
}