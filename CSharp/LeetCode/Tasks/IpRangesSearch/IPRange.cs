namespace LeetCode.Tasks;

public record IPRange(IPAddress From, IPAddress To) : IComparable<IPRange>
{
    public static IPRange Parse(string str)
    {
        var parts = str.Split(",").Select(IPAddress.Parse).ToArray();
        return new(parts[0], parts[1]);
    }

    public static IEnumerable<IPRange> ParseMany(IEnumerable<string> strings)
    {
        return strings.Select(Parse);
    }

    public override string ToString()
    {
        return $"{From},{To}";
    }

    public int CompareTo(IPRange? other)
    {
        var fromComparison = From.CompareTo(other!.From);
        if (fromComparison != 0)
        {
            return fromComparison;
        }

        return -To.CompareTo(other.To);
    }
}