namespace LeetCode.Tasks;

public class SimpleSqrt
{
    public int MySqrt(int x)
    {
        var a = 1;
        var b = x;
        while (true)
        {
            var c = (a + b) / 2;
            var q = (long)c * c;
            var p = (long)(c + 1) * (c + 1);
            if (q <= x && p > x) return c;
            if (q < x) a = c;
            else b = c;
        }
    }
}