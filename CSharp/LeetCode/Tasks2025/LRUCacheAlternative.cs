namespace LeetCode.Tasks2025;

/// <summary>
/// Alternative LRUCache implementation storing key-value pairs directly in LinkedList nodes.
/// Slightly more memory efficient but less readable.
/// </summary>
public class LRUCacheAlternative
{
    private readonly LinkedList<KeyValuePair<int, int>> _list;
    private readonly Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> _map;
    private readonly int _capacity;

    public LRUCacheAlternative(int capacity)
    {
        _capacity = capacity;
        _list = new LinkedList<KeyValuePair<int, int>>();
        _map = new Dictionary<int, LinkedListNode<KeyValuePair<int, int>>>(capacity);
    }

    public int Get(int key)
    {
        if (!_map.TryGetValue(key, out var node))
            return -1;

        // Move to front by removing and re-adding the node
        _list.Remove(node);
        _list.AddFirst(node);

        return node.Value.Value;
    }

    public void Put(int key, int value)
    {
        if (_map.TryGetValue(key, out var node))
        {
            // Update value in the node and move to front
            _list.Remove(node);
            node.Value = new KeyValuePair<int, int>(key, value);
            _list.AddFirst(node);
        }
        else
        {
            // Evict LRU if at capacity
            if (_map.Count >= _capacity)
            {
                var last = _list.Last!;
                _list.RemoveLast();
                _map.Remove(last.Value.Key);
            }

            // Add new entry
            var newNode = _list.AddFirst(new KeyValuePair<int, int>(key, value));
            _map[key] = newNode;
        }
    }
}
