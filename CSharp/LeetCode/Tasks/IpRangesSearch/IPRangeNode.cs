namespace LeetCode.Tasks;

public class IPRangeNode
{
    public IPRange MinMax { get; }

    public IPRangeNode? Left { get; }

    public IPRangeNode? Right { get; }

    public IList<IPRange>? Ranges { get; }

    public IPRangeNode(IList<IPRange> ranges)
    {
        var median = (uint)ranges.Select(x => ((long)x.From.Value + x.To.Value) / 2).Average();

        var left = new List<IPRange>();
        var right = new List<IPRange>();
        var center = new List<IPRange>();
        foreach (var r in ranges)
        {
            if (r.To.Value < median)
            {
                left.Add(r);
            }
            else if (r.From.Value > median)
            {
                right.Add(r);
            }
            else
            {
                center.Add(r);
            }
        }

        if (center.Any())
        {
            var min = center.Select(x => x.From.Value).Min();
            var max = center.Select(x => x.To.Value).Max();

            MinMax = new(new(min), new(max));
        }
        else
        {
            MinMax = new(new(median), new(median));
            center = null;
        }

        Left = left.Any() ? new(left) : null;
        Right = right.Any() ? new(right) : null;
        Ranges = center;
    }

    public int Depth => Math.Max(Left?.Depth ?? 0, Right?.Depth ?? 0) + 1;

    public int MaxSize => Math.Max(Ranges?.Count ?? 0, Math.Max(Left?.MaxSize ?? 0, Right?.MaxSize ?? 0));

    public IPRange? Search(IPAddress address)
    {
        if (MinMax.From.Value > address.Value)
        {
            return Left?.Search(address);
        }
        else if (address.Value > MinMax.To.Value)
        {
            return Right?.Search(address);
        }
        else
        {
            return SearchLocal(address);
        }
    }

    private IPRange? SearchLocal(IPAddress address)
    {
        if (Ranges is not null)
        {
            foreach (var r in Ranges)
            {
                if (r.From.Value <= address.Value && address.Value <= r.To.Value)
                {
                    return r;
                }
            }
        }

        return null;
    }
}