namespace LeetCode.Tasks2025;

public class MaxPointsTask
{
    /*
     Given an array of points where points[i] = [xi, yi] represents a point on the X-Y plane,
     return the maximum number of points that lie on the same straight line.
    */
    public int MaxPoints(int[][] points)
    {
        if (points.Length <= 2) return points.Length;

        var n = points.Length;
        var lines = new Dictionary<(long a, long b, long c), HashSet<int>>();

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                // Coefficients (a, b, c) of the line through points[i] and points[j].
                // The line equation is: a * x + b * y + c = 0
                long a = points[j][1] - points[i][1]; // y2 - y1
                long b = points[i][0] - points[j][0]; // x1 - x2
                long c = (long)points[j][0] * points[i][1] - (long)points[i][0] * points[j][1]; // x2*y1 - x1*y2

                // Normalize coefficients
                var gcd = GCD(GCD(Math.Abs(a), Math.Abs(b)), Math.Abs(c));
                if (gcd > 0)
                {
                    a /= gcd;
                    b /= gcd;
                    c /= gcd;
                }

                // Ensure canonical form: first non-zero coefficient should be positive
                if (a < 0 || (a == 0 && b < 0))
                {
                    a = -a;
                    b = -b;
                    c = -c;
                }

                var line = (a, b, c);
                if (!lines.TryGetValue(line, out var value))
                {
                    lines[line] = value = [];
                }

                value.Add(i);
                value.Add(j);
            }
        }

        return lines.Values.Max(set => set.Count);
    }

    private long GCD(long a, long b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}
