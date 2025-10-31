namespace LeetCode;

public class MinHeap<T> where T : IComparable<T>
{
    private readonly List<T> _data = [];
    private readonly Func<T, IComparable> _keySelector;

    public int Count => _data.Count;

    public MinHeap(Func<T, IComparable>? keySelector = null)
    {
        _keySelector = keySelector ?? (x => (IComparable)x);
    }

    public void Push(T val)
    {
        _data.Add(val);
        HeapifyUp(_data.Count - 1);
    }

    public T Pop()
    {
        if (_data.Count == 0)
        {
            throw new InvalidOperationException("Heap is empty");
        }

        var root = _data[0];
        _data[0] = _data[^1];
        _data.RemoveAt(_data.Count - 1);

        if (_data.Count > 0)
        {
            HeapifyDown(0);
        }

        return root;
    }

    public T Peek()
    {
        return _data.Count == 0 ? throw new InvalidOperationException("Heap is empty") : _data[0];
    }

    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            var parent = (index - 1) / 2;

            var keyIndex = _keySelector(_data[index]);
            var keyParent = _keySelector(_data[parent]);
            if (keyIndex.CompareTo(keyParent) >= 0)
            {
                break;
            }

            (_data[index], _data[parent]) = (_data[parent], _data[index]);
            index = parent;
        }
    }

    private void HeapifyDown(int index)
    {
        var last = _data.Count - 1;

        while (true)
        {
            var left = 2 * index + 1;
            var right = 2 * index + 2;
            var smallest = index;

            var keySmallest = _keySelector(_data[smallest]);

            if (left <= last)
            {
                var keyLeft = _keySelector(_data[left]);
                if (keyLeft.CompareTo(keySmallest) < 0)
                {
                    smallest = left;
                    keySmallest = keyLeft;
                }
            }

            if (right <= last)
            {
                var keyRight = _keySelector(_data[right]);
                if (keyRight.CompareTo(keySmallest) < 0)
                {
                    smallest = right;
                }
            }

            if (smallest == index)
            {
                break;
            }

            (_data[index], _data[smallest]) = (_data[smallest], _data[index]);
            index = smallest;
        }
    }

    public T[] ToArray()
    {
        return _data.ToArray();
    }
}

public static class MinHeapTest
{
    public static void Test()
    {
        var heap = new MinHeap<int>();
        heap.Push(5);
        heap.Push(3);
        heap.Push(8);
        heap.Push(1);

        Console.WriteLine(heap.Pop()); // 1
        Console.WriteLine(heap.Peek()); // 3
        Console.WriteLine(heap.Pop()); // 3
    }
}

public static class TopKFrequency
{
    public static IList<int> TopKFrequent(int[] nums, int k)
    {
        var freqMap = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            freqMap.TryAdd(num, 0);
            freqMap[num]++;
        }

        var minHeap = new MinHeap<int>(x => freqMap[x]);
        foreach (var kvp in freqMap)
        {
            minHeap.Push(kvp.Key);
            if (minHeap.Count > k)
            {
                minHeap.Pop();
            }
        }

        var result = new List<int>();
        while (minHeap.Count > 0)
        {
            result.Add(minHeap.Pop());
        }

        result.Reverse();
        return result;
    }

    public static void Test()
    {
        var nums = new[] { 1, 1, 1, 2, 2, 3 };
        var k = 2;
        var result = TopKFrequent(nums, k);
        Console.WriteLine(string.Join(", ", result)); // Expected output: 1, 2
    }
}
