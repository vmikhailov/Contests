using NUnit.Framework;
using FluentAssertions;

namespace LeetCode.Tasks2025;

public class InsertIntervalTaskTests
{
    private InsertIntervalTask _task = null!;

    [SetUp]
    public void SetUp()
    {
        _task = new InsertIntervalTask();
    }

    [Test]
    public void Insert_NoOverlap_InsertsAtBeginning()
    {
        // Arrange
        int[][] intervals = [[3, 5], [6, 9]];
        int[] newInterval = [1, 2];

        // Act
        var result = _task.Insert(intervals, newInterval);

        // Assert
        result.Should().HaveCount(3);
        result[0].Should().Equal([1, 2]);
        result[1].Should().Equal([3, 5]);
        result[2].Should().Equal([6, 9]);
    }

    [Test]
    public void Insert_NoOverlap_InsertsInMiddle()
    {
        // Arrange
        int[][] intervals = [[1, 2], [6, 9]];
        int[] newInterval = [3, 5];

        // Act
        var result = _task.Insert(intervals, newInterval);

        // Assert
        result.Should().HaveCount(3);
        result[0].Should().Equal([1, 2]);
        result[1].Should().Equal([3, 5]);
        result[2].Should().Equal([6, 9]);
    }

    [Test]
    public void Insert_NoOverlap_InsertsAtEnd()
    {
        // Arrange
        int[][] intervals = [[1, 2], [3, 5]];
        int[] newInterval = [6, 9];

        // Act
        var result = _task.Insert(intervals, newInterval);

        // Assert
        result.Should().HaveCount(3);
        result[0].Should().Equal([1, 2]);
        result[1].Should().Equal([3, 5]);
        result[2].Should().Equal([6, 9]);
    }

    [Test]
    public void Insert_OverlapsSingleInterval_MergesThem()
    {
        // Arrange
        int[][] intervals = [[1, 3], [6, 9]];
        int[] newInterval = [2, 5];

        // Act
        var result = _task.Insert(intervals, newInterval);

        // Assert
        result.Should().HaveCount(2);
        result[0].Should().Equal([1, 5]);
        result[1].Should().Equal([6, 9]);
    }

    [Test]
    public void Insert_OverlapsMultipleIntervals_MergesAll()
    {
        // Arrange
        int[][] intervals = [[1, 2], [3, 5], [6, 7], [8, 10], [12, 16]];
        int[] newInterval = [4, 8];

        // Act
        var result = _task.Insert(intervals, newInterval);

        // Assert
        result.Should().HaveCount(3);
        result[0].Should().Equal([1, 2]);
        result[1].Should().Equal([3, 10]);
        result[2].Should().Equal([12, 16]);
    }

    [Test]
    public void Insert_CompletelyInside_NoChange()
    {
        // Arrange
        int[][] intervals = [[1, 5]];
        int[] newInterval = [2, 3];

        // Act
        var result = _task.Insert(intervals, newInterval);

        // Assert
        result.Should().HaveCount(1);
        result[0].Should().Equal([1, 5]);
    }

    [Test]
    public void Insert_CompletelyEngulfs_ReplacesAll()
    {
        // Arrange
        int[][] intervals = [[2, 3], [4, 5], [6, 7]];
        int[] newInterval = [1, 8];

        // Act
        var result = _task.Insert(intervals, newInterval);

        // Assert
        result.Should().HaveCount(1);
        result[0].Should().Equal([1, 8]);
    }

    [Test]
    public void Insert_EmptyIntervals_ReturnsNewInterval()
    {
        // Arrange
        int[][] intervals = [];
        int[] newInterval = [5, 7];

        // Act
        var result = _task.Insert(intervals, newInterval);

        // Assert
        result.Should().HaveCount(1);
        result[0].Should().Equal([5, 7]);
    }

    [Test]
    public void Insert_TouchesLeftBoundary_Merges()
    {
        // Arrange
        int[][] intervals = [[3, 5], [6, 9]];
        int[] newInterval = [1, 3];

        // Act
        var result = _task.Insert(intervals, newInterval);

        // Assert
        result.Should().HaveCount(2);
        result[0].Should().Equal([1, 5]);
        result[1].Should().Equal([6, 9]);
    }

    [Test]
    public void Insert_TouchesRightBoundary_Merges()
    {
        // Arrange
        int[][] intervals = [[1, 2], [3, 5]];
        int[] newInterval = [5, 7];

        // Act
        var result = _task.Insert(intervals, newInterval);

        // Assert
        result.Should().HaveCount(2);
        result[0].Should().Equal([1, 2]);
        result[1].Should().Equal([3, 7]);
    }

    [Test]
    public void Insert_SpansBetweenTwo_MergesBoth()
    {
        // Arrange
        int[][] intervals = [[1, 2], [5, 6]];
        int[] newInterval = [2, 5];

        // Act
        var result = _task.Insert(intervals, newInterval);

        // Assert
        result.Should().HaveCount(1);
        result[0].Should().Equal([1, 6]);
    }

    [Test]
    public void Insert_SingleInterval_NoOverlap_Before()
    {
        // Arrange
        int[][] intervals = [[5, 7]];
        int[] newInterval = [1, 2];

        // Act
        var result = _task.Insert(intervals, newInterval);

        // Assert
        result.Should().HaveCount(2);
        result[0].Should().Equal([1, 2]);
        result[1].Should().Equal([5, 7]);
    }

    [Test]
    public void Insert_SingleInterval_NoOverlap_After()
    {
        // Arrange
        int[][] intervals = [[1, 2]];
        int[] newInterval = [5, 7];

        // Act
        var result = _task.Insert(intervals, newInterval);

        // Assert
        result.Should().HaveCount(2);
        result[0].Should().Equal([1, 2]);
        result[1].Should().Equal([5, 7]);
    }

    [Test]
    public void Insert_SingleInterval_Overlap()
    {
        // Arrange
        int[][] intervals = [[1, 5]];
        int[] newInterval = [3, 7];

        // Act
        var result = _task.Insert(intervals, newInterval);

        // Assert
        result.Should().HaveCount(1);
        result[0].Should().Equal([1, 7]);
    }

    [Test]
    public void Insert_AdjacentIntervals_NotTouching()
    {
        // Arrange
        int[][] intervals = [[1, 2], [4, 5]];
        int[] newInterval = [6, 7];

        // Act
        var result = _task.Insert(intervals, newInterval);

        // Assert
        result.Should().HaveCount(3);
        result[0].Should().Equal([1, 2]);
        result[1].Should().Equal([4, 5]);
        result[2].Should().Equal([6, 7]);
    }

    [Test]
    public void Insert_LargeGap_InsertsCorrectly()
    {
        // Arrange
        int[][] intervals = [[1, 5]];
        int[] newInterval = [10, 15];

        // Act
        var result = _task.Insert(intervals, newInterval);

        // Assert
        result.Should().HaveCount(2);
        result[0].Should().Equal([1, 5]);
        result[1].Should().Equal([10, 15]);
    }

    [Test]
    public void Insert_ExtendsLeft_MergesWithPrevious()
    {
        // Arrange
        int[][] intervals = [[3, 5], [6, 9]];
        int[] newInterval = [2, 4];

        // Act
        var result = _task.Insert(intervals, newInterval);

        // Assert
        result.Should().HaveCount(2);
        result[0].Should().Equal([2, 5]);
        result[1].Should().Equal([6, 9]);
    }

    [Test]
    public void Insert_ExtendsRight_MergesWithNext()
    {
        // Arrange
        int[][] intervals = [[1, 2], [6, 9]];
        int[] newInterval = [5, 7];

        // Act
        var result = _task.Insert(intervals, newInterval);

        // Assert
        result.Should().HaveCount(2);
        result[0].Should().Equal([1, 2]);
        result[1].Should().Equal([5, 9]);
    }

    [Test]
    public void Insert_ExactMatch_NoChange()
    {
        // Arrange
        int[][] intervals = [[1, 3], [6, 9]];
        int[] newInterval = [6, 9];

        // Act
        var result = _task.Insert(intervals, newInterval);

        // Assert
        result.Should().HaveCount(2);
        result[0].Should().Equal([1, 3]);
        result[1].Should().Equal([6, 9]);
    }

    [Test]
    public void Insert_MergesThreeIntervals()
    {
        // Arrange
        int[][] intervals = [[1, 2], [3, 5], [6, 7], [8, 10]];
        int[] newInterval = [2, 8];

        // Act
        var result = _task.Insert(intervals, newInterval);

        // Assert
        result.Should().HaveCount(1);
        result[0].Should().Equal([1, 10]);
    }
}

