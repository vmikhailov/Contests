using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks;

public class FindKthSmallestTask
{
    public int FindKthSmallest(int[] a, int[] b, int k)
    {
        var i = 0;
        var j = 0;

        while (i < a.Length && j < b.Length)
        {
            var c = a[i] < b[j] ? a[i++] : b[j++];
            if (--k == 0)
            {
                return c;
            }
        }

        while (i < a.Length)
        {
            if (--k == 0)
            {
                return a[i];
            }

            i++;
        }

        while (j < b.Length)
        {
            if (--k == 0)
            {
                return b[j];
            }

            j++;
        }

        return -1;
    }
}

[TestFixture]
public class FindKthSmallestTaskTests
{
    private FindKthSmallestTask _task = null!;

    [SetUp]
    public void SetUp() => _task = new FindKthSmallestTask();

    [Test]
    public void FindKthSmallest_SmallestElement_ReturnsCorrect()
    {
        var result = _task.FindKthSmallest([2, 3, 4], [1, 5, 6], 1);
        result.Should().Be(1);
    }

    [Test]
    public void FindKthSmallest_LastElement_ReturnsCorrect()
    {
        var result = _task.FindKthSmallest([1, 2], [3, 4], 4);
        result.Should().Be(4);
    }

    [Test]
    public void FindKthSmallest_OneArraySmaller_ReturnsCorrect()
    {
        var result = _task.FindKthSmallest([1], [2, 3, 4, 5], 3);
        result.Should().Be(3);
    }

    [Test]
    public void FindKthSmallest_DuplicateValues_ReturnsCorrect()
    {
        var result = _task.FindKthSmallest([1, 3, 3], [2, 3, 4], 4);
        result.Should().Be(3);
    }

    [Test]
    public void FindKthSmallest_EmptySecondArray_ReturnsCorrect()
    {
        var result = _task.FindKthSmallest([1, 2, 3, 4], [], 3);
        result.Should().Be(3);
    }

    [Test]
    public void FindKthSmallest_KAtBoundaryOfSecondArray_ReturnsCorrect()
    {
        var result = _task.FindKthSmallest([5, 6, 7], [1, 2, 3], 3);
        result.Should().Be(3);
    }

    [Test]
    public void FindKthSmallest_KAtBoundaryOfFirstArray_ReturnsCorrect()
    {
        var result = _task.FindKthSmallest([1, 2, 3], [5, 6, 7], 3);
        result.Should().Be(3);
    }
}
