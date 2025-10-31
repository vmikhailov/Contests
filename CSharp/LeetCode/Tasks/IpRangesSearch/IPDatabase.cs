namespace LeetCode.Tasks;

public interface IIPDatabase
{
    void Init(IList<IPRange> ranges);

    IPRange? Find(IPAddress address);
}

public class IPDatabase : IIPDatabase
{
    private readonly List<IPRange> _data = new();
    private IPRangeNode? _root;

    public void Init(IList<IPRange> ranges)
    {
        _data.AddRange(ranges);
    }

    public IPRange? Find(IPAddress address)
    {
        return _data.FirstOrDefault(r => address.CompareTo(r.From) != -1 && address.CompareTo(r.To) != 1);
    }
}

public class IPDatabase2 : IIPDatabase
{
    private IPRangeNode? _root;

    public void Init(IList<IPRange> ranges)
    {
        _root = new(ranges);
        Console.WriteLine($"Depth = {_root.Depth} MaxSize={_root.MaxSize}");
    }

    public IPRange? Find(IPAddress address)
    {
        return _root?.Search(address);
    }
}

public class IPDatabase3 : IIPDatabase
{
    private readonly List<uint> _data = new();
    
    public int Overlapped { get; private set; }

    public void Init(IList<IPRange> ranges)
    {
        foreach (var r in ranges)
        {
            Add(r);
        }
        Console.WriteLine($"Overlapped = {Overlapped}");
    }

    private void Add(IPRange range)
    {
        var pos1 = _data.BinarySearch(range.From.Value);
        if (pos1 < 0)
        {
            pos1 = ~pos1;
        }

        //else pos1 += pos1 & 1;

        var pos2 = _data.BinarySearch(range.To.Value);
        if (pos2 < 0)
        {
            pos2 = ~pos2;
        }

        //else pos2 -= pos2 & 1;

        var p1inside = pos1 % 2 == 1;
        var p2inside = pos2 % 2 == 1;

        if (p1inside || p2inside)
        {
            Overlapped++;
        }

        if (!p1inside)
        {
            _data.Insert(pos1, range.From.Value); 
            pos2++;
        }

        if (pos2 - pos1 - 1 > 0)
        {
            _data.RemoveRange(pos1 + 1, pos2 - pos1 - 1);
        }

        if (!p2inside)
        {
            if (p1inside)
            {
                _data[pos1] = range.To.Value;
            }
            else
            {
                _data.Insert(pos1 + 1, range.To.Value);
            }
        }
    }

    public IPRange? Find(IPAddress address)
    {
        var pos1 = _data.BinarySearch(address.Value);
        if (pos1 < 0)
        {
            pos1 = ~pos1;
        }
        else
        {
            var offset = pos1 % 2;
            return new (new(_data[pos1 - offset]), new(_data[pos1 + 1 - offset]));
        }

        return pos1 % 2 == 1 && pos1 > 0 && pos1 < _data.Count
            ? new IPRange(new(_data[pos1 - 1]), new(_data[pos1]))
            : null;
    }
}
