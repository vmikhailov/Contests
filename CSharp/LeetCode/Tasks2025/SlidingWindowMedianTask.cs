using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Tasks2025;

public class SlidingWindowMedianTask
{
    public class Solution
    {
        private readonly SortedSet<(int, int)> _minHeap = new();
        private readonly SortedSet<(int, int)> _maxHeap = new(Comparer<(int, int)>.Create((x, y) => y.CompareTo(x)));

        public double[] MedianSlidingWindow(int[] nums, int k)
        {
            var result = new double[nums.Length - k + 1];

            for (var i = 0; i < nums.Length; i++)
            {
                AddNum(nums[i], i);

                if (i < k - 1)
                {
                    continue;
                }

                var j = i - k + 1;
                result[j] = GetMedian();
                Remove(nums[j], j);
            }

            return result;
        }

        private void AddNum(int v, int i)
        {
            if (_maxHeap.Count == 0 || v <= _maxHeap.First().Item1)
            {
                _maxHeap.Add((v, i));
            }
            else
            {
                _minHeap.Add((v, i));
            }

            Rebalance();
        }

        private void Remove(int x, int i)
        {
            if (_maxHeap.Contains((x, i)))
            {
                _maxHeap.Remove((x, i));
            }
            else if (_minHeap.Contains((x, i)))
            {
                _minHeap.Remove((x, i));
            }

            Rebalance();
        }

        private void Rebalance()
        {
            // we want _maxHeap.Count == _minHeap.Count or _maxHeap.Count == _minHeap.Count + 1
            if (_maxHeap.Count > _minHeap.Count + 1)
            {
                var v = _maxHeap.First();
                _maxHeap.Remove(v);
                _minHeap.Add(v);
            }
            else if (_maxHeap.Count < _minHeap.Count)
            {
                var v = _minHeap.First();
                _minHeap.Remove(v);
                _maxHeap.Add(v);
            }
        }

        private double GetMedian()
        {
            if (_maxHeap.Count > _minHeap.Count)
            {
                return _maxHeap.First().Item1;
            }

            return (_maxHeap.First().Item1 * 1.0 + _minHeap.First().Item1) / 2.0;
        }
    }

    public class Solution1
    {
        private readonly PriorityQueue<int, int> _maxHeap = new(); // max-heap via negative priority
        private readonly PriorityQueue<int, int> _minHeap = new(); // min-heap via positive priority

        public double[] MedianSlidingWindow(int[] nums, int k)
        {
            var result = new List<double>();

            for (var i = 0; i < nums.Length; i++)
            {
                AddNum(nums[i]);

                // when we've filled the first window (i == k-1) and for each subsequent element
                if (i >= k - 1)
                {
                    result.Add(GetMedian());

                    // remove the element that moves out of the window
                    Remove(nums[i - k + 1]);
                }
            }

            return result.ToArray();
        }

        private void AddNum(int v)
        {
            if (_maxHeap.Count == 0 || v <= _maxHeap.Peek())
            {
                // use negative priority to simulate max-heap
                _maxHeap.Enqueue(v, -v);
            }
            else
            {
                _minHeap.Enqueue(v, v);
            }

            Rebalance();
        }

        private void Remove(int x)
        {
            // try remove from either heap; if found, rebalance
            if (!(_maxHeap.Remove(x, out _, out _) || _minHeap.Remove(x, out _, out _)))
                return; // if not found, inputs might be inconsistent

            Rebalance();
        }

        private void Rebalance()
        {
            // we want _maxHeap.Count == _minHeap.Count or _maxHeap.Count == _minHeap.Count + 1
            if (_maxHeap.Count > _minHeap.Count + 1)
            {
                var v = _maxHeap.Dequeue();
                _minHeap.Enqueue(v, v);
            }
            else if (_maxHeap.Count < _minHeap.Count)
            {
                var v = _minHeap.Dequeue();
                _maxHeap.Enqueue(v, -v);
            }
        }

        private double GetMedian()
        {
            if (_maxHeap.Count > _minHeap.Count)
            {
                return _maxHeap.Peek();
            }

            return (_maxHeap.Peek() + _minHeap.Peek()) / 2.0;
        }
    }
}

// NUnit tests for SlidingWindowMedianTask.Solution using FluentAssertions
