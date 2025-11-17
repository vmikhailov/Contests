namespace LeetCode.Tasks2025;

/*
 * Alternative LFUCache implementation that uses built-in LinkedList<T>
 * for each frequency bucket instead of a custom doubly-linked list.
 *
 * Complexity: All Get / Put operations run in amortized O(1).
 */
public sealed class LFUCacheLinkedList : ILFUCache
{
    private sealed class Entry
    {
        public int Key;
        public int Value;
        public int Freq = 1;
    }

    private readonly int _capacity;
    private int _size;
    private int _minFreq = 0;

    private readonly Dictionary<int, (Entry entry, LinkedListNode<Entry> node)> _items;
    private readonly Dictionary<int, LinkedList<Entry>> _freqLists;

    public LFUCacheLinkedList(int capacity)
    {
        _capacity = capacity;
        _items = new Dictionary<int, (Entry, LinkedListNode<Entry>)>(capacity);
        _freqLists = new();
    }

    public int Get(int key)
    {
        if (!_items.TryGetValue(key, out var tuple)) return -1;

        Promote(tuple.entry, tuple.node);
        return tuple.entry.Value;
    }

    public void Put(int key, int value)
    {
        if (_capacity == 0) return;

        if (_items.TryGetValue(key, out var existing))
        {
            existing.entry.Value = value;
            Promote(existing.entry, existing.node);
            return;
        }

        if (_size == _capacity)
        {
            // Evict least recently used from the lowest frequency list.
            var list = _freqLists[_minFreq];
            var lruNode = list.Last!; // tail = least recent
            list.RemoveLast();
            _items.Remove(lruNode.Value.Key);
            _size--;
        }

        var entry = new Entry { Key = key, Value = value, Freq = 1 };
        var list1 = GetList(1);
        var node = list1.AddFirst(entry);
        _items[key] = (entry, node);
        _minFreq = 1;
        _size++;
    }

    private void Promote(Entry entry, LinkedListNode<Entry> node)
    {
        var oldFreq = entry.Freq;
        var oldList = _freqLists[oldFreq];
        oldList.Remove(node);

        if (oldFreq == _minFreq && oldList.Count == 0)
        {
            _minFreq = oldFreq + 1;
        }

        entry.Freq++;
        var newList = GetList(entry.Freq);
        var newNode = newList.AddFirst(entry);
        _items[entry.Key] = (entry, newNode);
    }

    private LinkedList<Entry> GetList(int freq)
    {
        if (!_freqLists.TryGetValue(freq, out var list))
        {
            list = new LinkedList<Entry>();
            _freqLists[freq] = list;
        }

        return list;
    }
}
