using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using NUnit.Framework;
using FluentAssertions;
using LeetCode.Tasks2025;

namespace LeetCode.Tasks;

public interface INumArrayTask
{
    void Update(int index, int val);

    int SumRange(int left, int right);
}

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

public class NumArrayTaskSegmentTree : INumArrayTask
{
    private readonly SegmentTree<int> _segmentTree;

    public NumArrayTaskSegmentTree(int[] nums)
    {
        _segmentTree = new(nums, (a, b) => a + b, 0);
    }

    public void Update(int index, int val)
    {
        _segmentTree.Update(index, val);
    }

    public int SumRange(int l, int r)
    {
        return _segmentTree.Query(l, r);
    }
}



// NUnit tests for NumArrayTask (10 tests). Implementation is intentionally not modified.
[TestFixture]
public class NumArrayTaskTests
{
    private INumArrayTask Create(int[] nums) => new NumArrayTaskSegmentTree(nums);

    [Test]
    public void SumRange_Basic()
    {
        var nums = new[] { 1, 3, 5 };
        var t = Create(nums);
        t.SumRange(0, 2).Should().Be(9);
    }

    [Test]
    public void Update_Then_SumRange()
    {
        var nums = new[] { 1, 3, 5 };
        var t = Create(nums);
        t.Update(1, 2); // intended resulting nums -> [1,2,5]
        t.SumRange(0, 2).Should().Be(8);
    }

    [Test]
    public void SingleElement_UpdateAndQuery()
    {
        var nums = new[] { 5 };
        var t = Create(nums);
        t.SumRange(0, 0).Should().Be(5);
        t.Update(0, 10);
        t.SumRange(0, 0).Should().Be(10);
    }

    [Test]
    public void UpdateAtStart()
    {
        var nums = new[] { 1, 2, 3 };
        var t = Create(nums);
        t.Update(0, 5);
        t.SumRange(0, 1).Should().Be(7); // expect [5,2]
    }

    [Test]
    public void ManyRandom()
    {
        const int n = 100000;
        var nums = Enumerable.Range(1, n).Select(x => Random.Shared.Next(n / 10)).ToArray();
        var t = Create(nums);
        var n1 = Random.Shared.Next(n);
        var n2 = Random.Shared.Next(n);

        if (n1 > n2)
        {
            (n1, n2) = (n2, n1);
        }

        t.SumRange(n1, n2).Should().Be(nums.Skip(n1).Take(n2 - n1 + 1).Sum());
    }

    [Test]
    public void Sequence()
    {
        var nums = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        var t = Create(nums);
        t.SumRange(1, 5).Should().Be(20);
        t.SumRange(0, 7).Should().Be(36);
    }

    [Test]
    public void UpdateAtEnd()
    {
        var nums = new[] { 1, 2, 3 };
        var t = Create(nums);
        t.Update(2, 10);
        t.SumRange(1, 2).Should().Be(12); // expect [2,10]
    }

    [Test]
    public void NegativeNumbers()
    {
        var nums = new[] { -2, 0, 3 };
        var t = Create(nums);
        t.SumRange(0, 2).Should().Be(1);
        t.Update(0, -5);
        t.SumRange(0, 1).Should().Be(-5); // expect [-5,0]
    }

    [Test]
    public void MultipleUpdates()
    {
        var nums = new[] { 1, 1, 1, 1 };
        var t = Create(nums);
        t.Update(1, 3); // expect [1,3,1,1]
        t.Update(2, 4); // expect [1,3,4,1]
        t.SumRange(0, 3).Should().Be(9);
        t.SumRange(1, 2).Should().Be(7);
    }

    [Test]
    public void LargeValues()
    {
        var nums = new[] { 1000000000, 1000000000 };
        var t = Create(nums);
        t.SumRange(0, 1).Should().Be(2000000000);
    }

    [Test]
    public void RangeSingleIndex()
    {
        var nums = new[] { 2, 4, 6, 8 };
        var t = Create(nums);
        t.SumRange(2, 2).Should().Be(6);
    }

    [Test]
    public void ManyUpdatesAndQueries_Deterministic()
    {
        var nums = Enumerable.Range(1, 10).ToArray();
        var t = Create(nums);

        // perform deterministic updates (replace semantics expected)
        for (var i = 0; i < 10; i++)
        {
            t.Update(i % nums.Length, i);
        }

        // compute expected manually assuming Update replaces
        var expected = nums.ToList();

        for (var i = 0; i < 10; i++)
        {
            expected[i % expected.Count] = i;
        }

        t.SumRange(0, 5).Should().Be(expected.Take(6).Sum());
    }
}
