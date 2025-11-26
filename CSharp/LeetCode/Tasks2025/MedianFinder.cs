namespace LeetCode.Tasks2025;

public class MedianFinder
{
    private readonly PriorityQueue<int, int> _maxHeap; // lower half (max heap)
    private readonly PriorityQueue<int, int> _minHeap; // upper half (min heap)


    public MedianFinder()
    {
        _minHeap = new();
        _maxHeap = new(Comparer<int>.Create((a, b) => b.CompareTo(a)));
    }

    public void AddNum(int num)
    {
        // we check to what heap to add the number
        if (_maxHeap.Count == 0 || num <= _maxHeap.Peek())
        {
            _maxHeap.Enqueue(num, num);
        }
        else
        {
            _minHeap.Enqueue(num, num);
        }

        // balance the heaps
        if(_maxHeap.Count > _minHeap.Count + 1)
        {
            var v = _maxHeap.Dequeue();
            _minHeap.Enqueue(v, v);
        }
        else if(_minHeap.Count > _maxHeap.Count)
        {
            var v = _minHeap.Dequeue();
            _maxHeap.Enqueue(v, v);
        }
    }


    public double FindMedian()
    {
        if (_maxHeap.Count > _minHeap.Count)
        {
            return _maxHeap.Peek();
        }

        return (_maxHeap.Peek() + _minHeap.Peek()) / 2.0;
    }
}
