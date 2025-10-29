namespace LeetCode.Tasks;

public record IPAddress(uint Value) : IComparable<IPAddress>
{
    public static IPAddress Parse(string str)
    {
        var value = str.Split(".").Select(uint.Parse).Aggregate(0u, (x, y) => x * 256 + y);
        return new(value);
    }

    public int CompareTo(IPAddress? other)
    {
        return Comparer<uint>.Default.Compare(Value, other?.Value ?? 0);
    }

    public override string ToString()
    {
        IList<uint> parts = new List<uint>(4);
        for (var v = Value; v > 0; v /= 256)
        {
            parts.Add(v % 256);
        }

        return string.Join(".", parts.Reverse());
    }
}