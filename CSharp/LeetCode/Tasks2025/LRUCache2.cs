namespace LeetCode.Tasks2025;

public class LRUCache2
{
     private sealed class Node
    {
        public int Key;
        public int Value;
        public Node? Prev;
        public Node? Next;
    }

    private readonly int _capacity;
    private readonly Dictionary<int, Node> _map;
    private Node? _head; // MRU
    private Node? _tail; // LRU

    public LRUCache2(int capacity)
    {
        _capacity = capacity;
        _map = new(capacity);
    }

    public int Get(int key)
    {
        if (!_map.TryGetValue(key, out var node))
            return -1;

        MoveToFront(node);
        return node.Value;
    }

    public void Put(int key, int value)
    {
        if (_map.TryGetValue(key, out var existing))
        {
            existing.Value = value;
            MoveToFront(existing);
            return;
        }

        // Evict first if at capacity.
        if (_map.Count == _capacity)
            EvictTail();

        var node = new Node { Key = key, Value = value };
        AddToFront(node);
        _map[key] = node;
    }

    private void AddToFront(Node node)
    {
        node.Prev = null;
        node.Next = _head;
        if (_head != null) _head.Prev = node;
        _head = node;
        if (_tail == null) _tail = node;
    }

    private void MoveToFront(Node node)
    {
        if (node == _head) return;

        // Detach
        var prev = node.Prev;
        var next = node.Next;
        if (prev != null) prev.Next = next;
        if (next != null) next.Prev = prev;
        if (node == _tail) _tail = prev;

        // Insert at front
        node.Prev = null;
        node.Next = _head;
        if (_head != null) _head.Prev = node;
        _head = node;
    }

    private void EvictTail()
    {
        var tail = _tail!;
        _map.Remove(tail.Key);

        var prev = tail.Prev;
        if (prev != null)
        {
            prev.Next = null;
            _tail = prev;
        }
        else
        {
            // Cache becomes empty.
            _head = null;
            _tail = null;
        }
    }
}
