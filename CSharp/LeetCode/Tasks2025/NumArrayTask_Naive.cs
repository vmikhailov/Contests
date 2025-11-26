using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace LeetCode.Tasks;

public class NumArrayTask_Naive : INumArrayTask
{
    private readonly List<int> _nums;
    private readonly List<int> _sums;

    public NumArrayTask_Naive(int[] nums)
    {
        _nums = nums.ToList();
        _sums = new List<int>(nums.Length);
        var s = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            _sums.Add(s += _nums[i]);
        }
    }

    public void Update(int index, int val)
    {
        var old = _nums[index];
        _nums[index] = val;
        _sums[index] = index > 0 ? _sums[index - 1] + val : val;

        for (var i = index + 1; i < _sums.Count; i++)
        {
            _sums[i] += val - old;
        }
    }

    public int SumRange(int left, int right)
    {
        var s = left > 0 ? _sums[left - 1] : 0;
        return _sums[right] - s;
    }
}

// NUnit tests for NumArrayTask (10 tests). Implementation is intentionally not modified.
