namespace LeetCode.Tasks2025;

public sealed class LRUCache3
{
    private sealed class Node
    {
        public int Key, Value;
        public Node Prev = null!;
        public Node Next = null!;
    }

    private readonly int _capacity;
    private readonly Dictionary<int, Node> _map;
    private readonly Node _head; // sentinel: MRU ближе к head
    private readonly Node _tail; // sentinel: LRU ближе к tail

    public LRUCache3(int capacity)
    {
        _capacity = capacity;
        _map = new Dictionary<int, Node>(capacity > 0 ? capacity : 0);

        _head = new Node();
        _tail = new Node();
        _head.Next = _tail;
        _tail.Prev = _head;
    }

    public int Get(int key)
    {
        if (!_map.TryGetValue(key, out var node)) return -1;
        Remove(node);
        InsertAfter(_head, node); // в MRU
        return node.Value;
    }

    public void Put(int key, int value)
    {
        if (_capacity == 0) return;

        if (_map.TryGetValue(key, out var node))
        {
            node.Value = value;
            Remove(node);
            InsertAfter(_head, node);
            return;
        }

        if (_map.Count == _capacity)
        {
            var lru = _tail.Prev;        // всегда не null при _capacity>0 и Count==capacity
            Remove(lru);
            _map.Remove(lru.Key);
        }

        var n = new Node { Key = key, Value = value };
        InsertAfter(_head, n);
        _map[key] = n;
    }

    private static void Remove(Node n)
    {
        n.Prev.Next = n.Next;
        n.Next.Prev = n.Prev;
    }

    private static void InsertAfter(Node at, Node n)
    {
        n.Next = at.Next;
        n.Prev = at;
        at.Next.Prev = n;
        at.Next = n;
    }
}
