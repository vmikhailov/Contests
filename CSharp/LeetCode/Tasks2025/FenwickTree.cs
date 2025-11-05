using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks2025;

public class FenwickTree
{
    private readonly int[] _tree;

    public FenwickTree(int n)
    {
        _tree = new int[n + 1]; // indexing from 1
    }

    // Lowbit extracts the lowest set bit of x.
    // This is used to efficiently traverse and update the Fenwick Tree.
    // For example, if x = 12 (1100 in binary), -x = (~x + 1) = 100 in binary,
    // so x & -x = 1100 & 0100 = 0100 = 4.
    // In Fenwick Tree, this helps move to the next node responsible for a range.
    private static int Lowbit(int x) => x & -x;

    // Add 'delta' to index 'i' in the tree.
    // This method updates all responsible nodes that cover index 'i'.
    // It repeatedly adds 'delta' to _tree[i] and moves to the next responsible node using Lowbit.
    // Time complexity: O(log n)
    public void Add(int i, int delta)
    {
        while (i < _tree.Length)
        {
            _tree[i] += delta;
            i += Lowbit(i);
        }
    }

    // Computes the prefix sum from index 1 to i (inclusive).
    // Traverses the tree by subtracting Lowbit(i) at each step, accumulating the sum.
    // If i is out of bounds, clamps to the valid range.
    // Time complexity: O(log n)
    public int PrefixSum(int i)
    {
        i = Math.Clamp(i, 0, _tree.Length - 1);

        var s = 0;
        while (i > 0)
        {
            s += _tree[i];
            i -= Lowbit(i); // Move to parent node
        }
        return s;
    }

    public int RangeSum(int l, int r)
    {
        return PrefixSum(r) - PrefixSum(l - 1);
    }

    public static FenwickTree FromArray(int[] arr)
    {
        var tree = new FenwickTree(arr.Length);
        for (var i = 0; i < arr.Length; i++)
        {
            tree.Add(i + 1, arr[i]);
        }
        return tree;
    }
}

[TestFixture]
public class FenwickTreeTests
{
    [Test]
    public void Add_And_PrefixSum_Basic()
    {
        var tree = new FenwickTree(5);
        tree.Add(1, 2);
        tree.Add(2, 3);
        tree.Add(3, 5);
        tree.PrefixSum(1).Should().Be(2);
        tree.PrefixSum(2).Should().Be(5);
        tree.PrefixSum(3).Should().Be(10);
        tree.PrefixSum(4).Should().Be(10);
        tree.PrefixSum(5).Should().Be(10);
    }

    [Test]
    public void RangeSum_Basic()
    {
        var tree = new FenwickTree(5);
        tree.Add(1, 1);
        tree.Add(2, 2);
        tree.Add(3, 3);
        tree.Add(4, 4);
        tree.Add(5, 5);
        tree.RangeSum(1, 3).Should().Be(6); // 1+2+3
        tree.RangeSum(2, 5).Should().Be(14); // 2+3+4+5
        tree.RangeSum(3, 3).Should().Be(3);
        tree.RangeSum(1, 5).Should().Be(15);
    }

    [Test]
    public void Add_NegativeValues_Works()
    {
        var tree = new FenwickTree(3);
        tree.Add(1, 5);
        tree.Add(2, -3);
        tree.Add(3, 2);
        tree.PrefixSum(3).Should().Be(4); // 5 + (-3) + 2
        tree.RangeSum(2, 3).Should().Be(-1); // -3 + 2
    }

    [Test]
    public void EdgeCases_ZeroAndOutOfBounds()
    {
        var tree = new FenwickTree(3);
        tree.PrefixSum(0).Should().Be(0);
        tree.RangeSum(1, 0).Should().Be(0);
        tree.Add(1, 1);
        tree.PrefixSum(4).Should().Be(1); // Out of bounds, should not throw
    }

    [Test]
    public void MultipleUpdates_CorrectlyAccumulates()
    {
        var tree = new FenwickTree(4);
        tree.Add(2, 1);
        tree.Add(2, 2);
        tree.Add(2, 3);
        tree.PrefixSum(2).Should().Be(6);
        tree.RangeSum(2, 2).Should().Be(6);
    }

    [Test]
    public void BuildFromArray_WorksCorrectly()
    {
        int[] arr = { 2, 3, 5, 7, 11 };
        var tree = FenwickTree.FromArray(arr);
        tree.PrefixSum(1).Should().Be(2);
        tree.PrefixSum(2).Should().Be(5);
        tree.PrefixSum(3).Should().Be(10);
        tree.PrefixSum(4).Should().Be(17);
        tree.PrefixSum(5).Should().Be(28);
        tree.RangeSum(2, 4).Should().Be(15); // 3+5+7
    }
}
