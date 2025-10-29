namespace LeetCode.Tasks;

public static class IPGenerator
{
    public static IEnumerable<IPRange> GenerateRanges(int n, uint d, uint? max = null)
    {
        var r = new Random();
        max ??= uint.MaxValue - d; 
        while (n-- > 0)
        {
            var ip1 = (uint)r.NextInt64(max.Value);
            yield return new(new(ip1), new(ip1 + d));
        }
    }

    public static IEnumerable<IPAddress> GenerateIP(int n = int.MaxValue)
    {
        var r = new Random();
        while (n-- > 0)
        {
            var ip = (uint)r.NextInt64(uint.MaxValue);
            yield return new(ip);
        }
    }
}