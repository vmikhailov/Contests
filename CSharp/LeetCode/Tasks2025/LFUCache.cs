namespace LeetCode.Tasks2025;

public sealed class LFUCache : ILFUCache
{
    private sealed class Node
    {
        public int Key;
        public int Value;
        public int Freq = 1;
        public Node? Prev;
        public Node? Next;
    }

    private sealed class DoubleLinkedList
    {
        private readonly Node _head = new();
        private readonly Node _tail = new();
        public int Count { get; private set; }

        public DoubleLinkedList()
        {
            _head.Next = _tail;
            _tail.Prev = _head;
        }

        public void AddFirst(Node n)
        {
            n.Next = _head.Next;
            n.Prev = _head;
            _head.Next!.Prev = n;
            _head.Next = n;
            Count++;
        }

        public void Remove(Node n)
        {
            n.Prev!.Next = n.Next;
            n.Next!.Prev = n.Prev;
            n.Prev = n.Next = null;
            Count--;
        }

        public Node RemoveLast() // LRU в этом freq
        {
            var lru = _tail.Prev!;
            Remove(lru);
            return lru;
        }
    }

    private readonly int _capacity;
    private int _size;
    private int _minFreq = 0;

    private readonly Dictionary<int, Node> _nodes;
    private readonly Dictionary<int, DoubleLinkedList> _freq;

    public LFUCache(int capacity)
    {
        _capacity = capacity;
        _nodes = new(capacity);
        _freq  = new();
    }

    public int Get(int key)
    {
        if (!_nodes.TryGetValue(key, out var n)) return -1;
        Touch(n);
        return n.Value;
    }

    public void Put(int key, int value)
    {
        if (_nodes.TryGetValue(key, out var existing))
        {
            existing.Value = value;
            Touch(existing);
            return;
        }

        if (_size == _capacity)
        {
            var list = _freq[_minFreq];
            var evict = list.RemoveLast();
            _nodes.Remove(evict.Key);
            _size--;
        }

        var n = new Node { Key = key, Value = value, Freq = 1 };
        var l1 = GetList(1);

        l1.AddFirst(n);
        _nodes[key] = n;
        _minFreq = 1;
        _size++;
    }

    private void Touch(Node n)
    {
        var f = n.Freq;
        var list = _freq[f];
        list.Remove(n);

        if (f == _minFreq && list.Count == 0)
        {
            _minFreq = f + 1;
        }

        n.Freq = f + 1;
        GetList(n.Freq).AddFirst(n);
    }

    private DoubleLinkedList GetList(int f)
    {
        if (_freq.TryGetValue(f, out var list))
        {
            return list;
        }

        return _freq[f] = new();
    }
}
