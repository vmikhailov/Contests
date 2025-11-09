namespace LeetCode.Tasks2025;

public class LRUCache
{
    private readonly LinkedList<int> _lruList;
    private readonly Dictionary<int, CacheItem> _cache;
    private readonly int _capacity;

    class CacheItem
    {
        public required int Value { get; set; }
        public required LinkedListNode<int> LruNode { get; init; }
    }

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _cache = [];
        _lruList = [];
    }

    public int Get(int key)
    {
        if (!_cache.TryGetValue(key, out var item))
        {
            return -1;
        }

        _lruList.Remove(item.LruNode);
        _lruList.AddFirst(item.LruNode);
        return item.Value;
    }

    public void Put(int key, int value)
    {
        if (_cache.TryGetValue(key, out var existingItem))
        {
            existingItem.Value = value;
            _lruList.Remove(existingItem.LruNode);
            _lruList.AddFirst(existingItem.LruNode);
        }
        else
        {
            _cache[key] = new()
            {
                Value = value,
                LruNode = _lruList.AddFirst(key)
            };
        }

        while (_cache.Count > _capacity)
        {
            var lruKey = _lruList.Last!.Value;
            _lruList.RemoveLast();
            _cache.Remove(lruKey);
        }
    }
}
