using NUnit.Framework;
using FluentAssertions;

namespace LeetCode.Tasks2025;

public class SubsetsTask2Tests
{
    private SubsetsTask2 _task = null!;

    [SetUp]
    public void SetUp()
    {
        _task = new SubsetsTask2();
    }

    [Test]
    public void SubsetsWithDup_BasicExample_ReturnsAllUniqueSubsets()
    {
        // Arrange
        int[] nums = [1, 2, 2];

        // Act
        var result = _task.SubsetsWithDup(nums);

        // Assert
        result.Should().HaveCount(6);
        result.Should().ContainEquivalentOf(new List<int>());
        result.Should().ContainEquivalentOf(new List<int> { 1 });
        result.Should().ContainEquivalentOf(new List<int> { 2 });
        result.Should().ContainEquivalentOf(new List<int> { 1, 2 });
        result.Should().ContainEquivalentOf(new List<int> { 2, 2 });
        result.Should().ContainEquivalentOf(new List<int> { 1, 2, 2 });
    }

    [Test]
    public void SubsetsWithDup_NoDuplicates_ReturnsAllSubsets()
    {
        // Arrange
        int[] nums = [1, 2, 3];

        // Act
        var result = _task.SubsetsWithDup(nums);

        // Assert
        result.Should().HaveCount(8); // 2^3 = 8
        result.Should().ContainEquivalentOf(new List<int>());
        result.Should().ContainEquivalentOf(new List<int> { 1 });
        result.Should().ContainEquivalentOf(new List<int> { 2 });
        result.Should().ContainEquivalentOf(new List<int> { 3 });
        result.Should().ContainEquivalentOf(new List<int> { 1, 2 });
        result.Should().ContainEquivalentOf(new List<int> { 1, 3 });
        result.Should().ContainEquivalentOf(new List<int> { 2, 3 });
        result.Should().ContainEquivalentOf(new List<int> { 1, 2, 3 });
    }

    [Test]
    public void SubsetsWithDup_SingleElement_ReturnsTwoSubsets()
    {
        // Arrange
        int[] nums = [0];

        // Act
        var result = _task.SubsetsWithDup(nums);

        // Assert
        result.Should().HaveCount(2);
        result.Should().ContainEquivalentOf(new List<int>());
        result.Should().ContainEquivalentOf(new List<int> { 0 });
    }

    [Test]
    public void SubsetsWithDup_AllDuplicates_ReturnsCorrectSubsets()
    {
        // Arrange
        int[] nums = [1, 1, 1];

        // Act
        var result = _task.SubsetsWithDup(nums);

        // Assert
        result.Should().HaveCount(4);
        result.Should().ContainEquivalentOf(new List<int>());
        result.Should().ContainEquivalentOf(new List<int> { 1 });
        result.Should().ContainEquivalentOf(new List<int> { 1, 1 });
        result.Should().ContainEquivalentOf(new List<int> { 1, 1, 1 });
    }

    [Test]
    public void SubsetsWithDup_MultipleDuplicatePairs_ReturnsUniqueSubsets()
    {
        // Arrange
        int[] nums = [4, 4, 4, 1, 4];

        // Act
        var result = _task.SubsetsWithDup(nums);

        // Assert
        result.Should().HaveCount(10);
        result.Should().ContainEquivalentOf(new List<int>());
        result.Should().ContainEquivalentOf(new List<int> { 1 });
        result.Should().ContainEquivalentOf(new List<int> { 4 });
        result.Should().ContainEquivalentOf(new List<int> { 1, 4 });
        result.Should().ContainEquivalentOf(new List<int> { 4, 4 });
        result.Should().ContainEquivalentOf(new List<int> { 1, 4, 4 });
        result.Should().ContainEquivalentOf(new List<int> { 4, 4, 4 });
        result.Should().ContainEquivalentOf(new List<int> { 1, 4, 4, 4 });
        result.Should().ContainEquivalentOf(new List<int> { 4, 4, 4, 4 });
        result.Should().ContainEquivalentOf(new List<int> { 1, 4, 4, 4, 4 });
    }

    [Test]
    public void SubsetsWithDup_NegativeNumbers_ReturnsCorrectSubsets()
    {
        // Arrange
        int[] nums = [-1, -1, 2];

        // Act
        var result = _task.SubsetsWithDup(nums);

        // Assert
        result.Should().HaveCount(6);
        result.Should().ContainEquivalentOf(new List<int>());
        result.Should().ContainEquivalentOf(new List<int> { -1 });
        result.Should().ContainEquivalentOf(new List<int> { -1, -1 });
        result.Should().ContainEquivalentOf(new List<int> { 2 });
        result.Should().ContainEquivalentOf(new List<int> { -1, 2 });
        result.Should().ContainEquivalentOf(new List<int> { -1, -1, 2 });
    }

    [Test]
    public void SubsetsWithDup_UnsortedInput_ReturnsCorrectSubsets()
    {
        // Arrange
        int[] nums = [4, 1, 4];

        // Act
        var result = _task.SubsetsWithDup(nums);

        // Assert
        result.Should().HaveCount(6);
        result.Should().ContainEquivalentOf(new List<int>());
        result.Should().ContainEquivalentOf(new List<int> { 1 });
        result.Should().ContainEquivalentOf(new List<int> { 4 });
        result.Should().ContainEquivalentOf(new List<int> { 1, 4 });
        result.Should().ContainEquivalentOf(new List<int> { 4, 4 });
        result.Should().ContainEquivalentOf(new List<int> { 1, 4, 4 });
    }

    [Test]
    public void SubsetsWithDup_EmptySubsetAlwaysIncluded()
    {
        // Arrange
        int[] nums = [5];

        // Act
        var result = _task.SubsetsWithDup(nums);

        // Assert
        result.Should().Contain(subset => subset.Count == 0);
    }

    [Test]
    public void SubsetsWithDup_TwoPairsOfDuplicates_ReturnsCorrectCount()
    {
        // Arrange
        int[] nums = [1, 1, 2, 2];

        // Act
        var result = _task.SubsetsWithDup(nums);

        // Assert
        result.Should().HaveCount(9);
        result.Should().ContainEquivalentOf(new List<int>());
        result.Should().ContainEquivalentOf(new List<int> { 1 });
        result.Should().ContainEquivalentOf(new List<int> { 1, 1 });
        result.Should().ContainEquivalentOf(new List<int> { 2 });
        result.Should().ContainEquivalentOf(new List<int> { 2, 2 });
        result.Should().ContainEquivalentOf(new List<int> { 1, 2 });
        result.Should().ContainEquivalentOf(new List<int> { 1, 1, 2 });
        result.Should().ContainEquivalentOf(new List<int> { 1, 2, 2 });
        result.Should().ContainEquivalentOf(new List<int> { 1, 1, 2, 2 });
    }
}

