using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks2025;

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