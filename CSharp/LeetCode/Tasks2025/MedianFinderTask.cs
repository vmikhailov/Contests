using NUnit.Framework;

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

public class MedianFinderTaskTests
{
    [Test]
    public void AddNum_SingleElement_ReturnsCorrectMedian()
    {
        // Arrange
        var mf = new MedianFinder();

        // Act
        mf.AddNum(5);
        var median = mf.FindMedian();

        // Assert
        Assert.That(median, Is.EqualTo(5.0));
    }

    [Test]
    public void AddNum_TwoElements_ReturnsAverage()
    {
        // Arrange
        var mf = new MedianFinder();

        // Act
        mf.AddNum(1);
        mf.AddNum(2);
        var median = mf.FindMedian();

        // Assert
        Assert.That(median, Is.EqualTo(1.5));
    }

    [Test]
    public void AddNum_ThreeElements_ReturnsMiddleValue()
    {
        // Arrange
        var mf = new MedianFinder();

        // Act
        mf.AddNum(1);
        mf.AddNum(2);
        mf.AddNum(3);
        var median = mf.FindMedian();

        // Assert
        Assert.That(median, Is.EqualTo(2.0));
    }

    [Test]
    public void AddNum_BasicExample_ReturnsCorrectMedians()
    {
        // Arrange
        var mf = new MedianFinder();

        // Act & Assert
        mf.AddNum(1);
        Assert.That(mf.FindMedian(), Is.EqualTo(1.0));

        mf.AddNum(2);
        Assert.That(mf.FindMedian(), Is.EqualTo(1.5));

        mf.AddNum(3);
        Assert.That(mf.FindMedian(), Is.EqualTo(2.0));
    }

    [Test]
    public void AddNum_UnsortedSequence_ReturnsCorrectMedian()
    {
        // Arrange
        var mf = new MedianFinder();

        // Act
        mf.AddNum(5);
        mf.AddNum(2);
        mf.AddNum(8);
        mf.AddNum(1);
        mf.AddNum(3);
        var median = mf.FindMedian();

        // Assert - sorted: [1,2,3,5,8], median is 3
        Assert.That(median, Is.EqualTo(3.0));
    }

    [Test]
    public void AddNum_DuplicateValues_ReturnsCorrectMedian()
    {
        // Arrange
        var mf = new MedianFinder();

        // Act
        mf.AddNum(5);
        mf.AddNum(5);
        mf.AddNum(5);
        var median = mf.FindMedian();

        // Assert
        Assert.That(median, Is.EqualTo(5.0));
    }

    [Test]
    public void AddNum_NegativeNumbers_ReturnsCorrectMedian()
    {
        // Arrange
        var mf = new MedianFinder();

        // Act
        mf.AddNum(-1);
        mf.AddNum(-2);
        mf.AddNum(-3);
        mf.AddNum(-4);
        var median = mf.FindMedian();

        // Assert - sorted: [-4,-3,-2,-1], median is (-3 + -2) / 2 = -2.5
        Assert.That(median, Is.EqualTo(-2.5));
    }

    [Test]
    public void AddNum_MixedPositiveNegative_ReturnsCorrectMedian()
    {
        // Arrange
        var mf = new MedianFinder();

        // Act
        mf.AddNum(-5);
        mf.AddNum(10);
        mf.AddNum(-3);
        mf.AddNum(7);
        mf.AddNum(0);
        var median = mf.FindMedian();

        // Assert - sorted: [-5,-3,0,7,10], median is 0
        Assert.That(median, Is.EqualTo(0.0));
    }

    [Test]
    public void AddNum_LargeSequence_ReturnsCorrectMedian()
    {
        // Arrange
        var mf = new MedianFinder();

        // Act - add numbers 1 through 10
        for (var i = 1; i <= 10; i++)
        {
            mf.AddNum(i);
        }

        var median = mf.FindMedian();

        // Assert - sorted: [1,2,3,4,5,6,7,8,9,10], median is (5 + 6) / 2 = 5.5
        Assert.That(median, Is.EqualTo(5.5));
    }

    [Test]
    public void AddNum_AlternatingSmallLarge_ReturnsCorrectMedian()
    {
        // Arrange
        var mf = new MedianFinder();

        // Act & Assert
        mf.AddNum(100);
        Assert.That(mf.FindMedian(), Is.EqualTo(100.0));

        mf.AddNum(1);
    }
}
