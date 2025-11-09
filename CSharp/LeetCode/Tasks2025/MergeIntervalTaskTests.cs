using NUnit.Framework;
using FluentAssertions;

namespace LeetCode.Tasks2025;

public class MergeIntervalTaskTests
{
    private MergeIntervalTask _task = null!;

    [SetUp]
    public void SetUp()
    {
        _task = new MergeIntervalTask();
    }

    [Test]
    public void Merge_OverlappingIntervals_MergesThem()
    {
        // Arrange
        int[][] intervals = [[1, 3], [2, 6], [8, 10], [15, 18]];

        // Act
        var result = _task.Merge(intervals);

        // Assert
        result.Should().HaveCount(3);
        result[0].Should().Equal([1, 6]);
        result[1].Should().Equal([8, 10]);
        result[2].Should().Equal([15, 18]);
    }

    [Test]
    public void Merge_AdjacentIntervals_MergesThem()
    {
        // Arrange
        int[][] intervals = [[1, 4], [4, 5]];

        // Act
        var result = _task.Merge(intervals);

        // Assert
        result.Should().HaveCount(1);
        result[0].Should().Equal([1, 5]);
    }

    [Test]
    public void Merge_NonOverlapping_KeepsSeparate()
    {
        // Arrange
        int[][] intervals = [[1, 2], [3, 4]];

        // Act
        var result = _task.Merge(intervals);

        // Assert
        result.Should().HaveCount(2);
        result[0].Should().Equal([1, 2]);
        result[1].Should().Equal([3, 4]);
    }

    [Test]
    public void Merge_SingleInterval_ReturnsSame()
    {
        // Arrange
        int[][] intervals = [[1, 5]];

        // Act
        var result = _task.Merge(intervals);

        // Assert
        result.Should().HaveCount(1);
        result[0].Should().Equal([1, 5]);
    }

    [Test]
    public void Merge_NestedIntervals_MergesIntoOne()
    {
        // Arrange
        int[][] intervals = [[1, 10], [2, 3], [4, 5], [6, 7]];

        // Act
        var result = _task.Merge(intervals);

        // Assert
        result.Should().HaveCount(1);
        result[0].Should().Equal([1, 10]);
    }

    [Test]
    public void Merge_MultipleOverlappingGroups_MergesEachGroup()
    {
        // Arrange
        int[][] intervals = [[1, 4], [2, 3], [8, 10], [9, 12], [15, 18]];

        // Act
        var result = _task.Merge(intervals);

        // Assert
        result.Should().HaveCount(3);
        result[0].Should().Equal([1, 4]);
        result[1].Should().Equal([8, 12]);
        result[2].Should().Equal([15, 18]);
    }

    [Test]
    public void Merge_UnsortedIntervals_MergesCorrectly()
    {
        // Arrange
        int[][] intervals = [[2, 6], [1, 3], [15, 18], [8, 10]];

        // Act
        var result = _task.Merge(intervals);

        // Assert
        result.Should().HaveCount(3);
        result[0].Should().Equal([1, 6]);
        result[1].Should().Equal([8, 10]);
        result[2].Should().Equal([15, 18]);
    }

    [Test]
    public void Merge_AllIntervalsOverlap_MergesIntoOne()
    {
        // Arrange
        int[][] intervals = [[1, 4], [2, 5], [3, 6], [4, 7]];

        // Act
        var result = _task.Merge(intervals);

        // Assert
        result.Should().HaveCount(1);
        result[0].Should().Equal([1, 7]);
    }

    [Test]
    public void Merge_TwoIdenticalIntervals_MergesIntoOne()
    {
        // Arrange
        int[][] intervals = [[1, 4], [1, 4]];

        // Act
        var result = _task.Merge(intervals);

        // Assert
        result.Should().HaveCount(1);
        result[0].Should().Equal([1, 4]);
    }

    [Test]
    public void Merge_PartialOverlap_MergesCorrectly()
    {
        // Arrange
        int[][] intervals = [[1, 3], [3, 5], [5, 7]];

        // Act
        var result = _task.Merge(intervals);

        // Assert
        result.Should().HaveCount(1);
        result[0].Should().Equal([1, 7]);
    }
}

