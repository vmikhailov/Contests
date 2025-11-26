namespace LeetCode.Tasks2025;

/// <summary>
/// Improved LRUCache implementation with better node management and clearer logic.
/// This version always creates new LinkedListNodes instead of trying to reuse them.
/// </summary>
public class LRUCacheImproved
{
    private readonly LinkedList<int> _lruList;
    private readonly Dictionary<int, (int value, LinkedListNode<int> node)> _cache;
    private readonly int _capacity;

    public LRUCacheImproved(int capacity)
    {
        _capacity = capacity;
        _cache = new Dictionary<int, (int, LinkedListNode<int>)>(capacity);
        _lruList = new LinkedList<int>();
    }

    public int Get(int key)
    {
        if (!_cache.TryGetValue(key, out var entry))
        {
            return -1;
        }

        // Move to front (most recently used) by removing and creating new node
        _lruList.Remove(entry.node);
        var newNode = _lruList.AddFirst(key);
        _cache[key] = (entry.value, newNode);

        return entry.value;
    }

    public void Put(int key, int value)
    {
        if (_cache.TryGetValue(key, out var entry))
        {
            // Update existing: remove old node, add new one at front
            _lruList.Remove(entry.node);
            var newNode = _lruList.AddFirst(key);
            _cache[key] = (value, newNode);
        }
        else
        {
            // Evict LRU if at capacity
            if (_cache.Count >= _capacity)
            {
                var lruKey = _lruList.Last!.Value;
                _lruList.RemoveLast();
                _cache.Remove(lruKey);
            }

            // Add new entry
            var node = _lruList.AddFirst(key);
            _cache[key] = (value, node);
        }
    }
}
