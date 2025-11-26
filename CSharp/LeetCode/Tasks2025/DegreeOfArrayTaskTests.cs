using NUnit.Framework;
using FluentAssertions;

namespace LeetCode.Tasks2025;

public class DegreeOfArrayTaskTests
{
    private DegreeOfArrayTask _task = null!;

    [SetUp]
    public void Setup()
    {
        _task = new DegreeOfArrayTask();
    }

    [Test]
    public void FindShortestSubArray_Example1_Returns2()
    {
        // Arrange
        int[] nums = [1, 2, 2, 3, 1];

        // Act
        var result = _task.FindShortestSubArray(nums);

        // Assert
        result.Should().Be(2);
        // Explanation: Degree is 2 (both 1 and 2 appear twice)
        // Shortest subarray with degree 2: [2, 2] or [1, 2, 2, 3, 1]
        // The shortest is [2, 2] with length 2
    }

    [Test]
    public void FindShortestSubArray_Example2_Returns6()
    {
        // Arrange
        int[] nums = [1, 2, 2, 3, 1, 4, 2];

        // Act
        var result = _task.FindShortestSubArray(nums);

        // Assert
        result.Should().Be(6);
        // Explanation: Degree is 3 (2 appears 3 times)
        // Shortest subarray: [2, 2, 3, 1, 4, 2] with length 6
    }

    [Test]
    public void FindShortestSubArray_SingleElement_Returns1()
    {
        // Arrange
        int[] nums = [1];

        // Act
        var result = _task.FindShortestSubArray(nums);

        // Assert
        result.Should().Be(1);
        // Explanation: Single element array has degree 1
    }

    [Test]
    public void FindShortestSubArray_AllSameElements_ReturnsFullLength()
    {
        // Arrange
        int[] nums = [5, 5, 5, 5];

        // Act
        var result = _task.FindShortestSubArray(nums);

        // Assert
        result.Should().Be(4);
        // Explanation: All elements are the same, degree is 4, need full array
    }

    [Test]
    public void FindShortestSubArray_AllDifferentElements_Returns1()
    {
        // Arrange
        int[] nums = [1, 2, 3, 4, 5];

        // Act
        var result = _task.FindShortestSubArray(nums);

        // Assert
        result.Should().Be(1);
        // Explanation: All elements appear once, degree is 1, any single element works
    }

    [Test]
    public void FindShortestSubArray_TwoElementsSame_Returns2()
    {
        // Arrange
        int[] nums = [1, 1];

        // Act
        var result = _task.FindShortestSubArray(nums);

        // Assert
        result.Should().Be(2);
        // Explanation: Degree is 2, need both elements
    }

    [Test]
    public void FindShortestSubArray_MultipleCandidates_ReturnsShortestLength()
    {
        // Arrange
        int[] nums = [1, 3, 2, 2, 3, 1];

        // Act
        var result = _task.FindShortestSubArray(nums);

        // Assert
        result.Should().Be(2);
        // Explanation: Degree is 2 (1, 2, and 3 all appear twice)
        // Shortest subarray: [3, 2, 2, 3] or [2, 2] with length 2
    }

    [Test]
    public void FindShortestSubArray_DegreeAtStart_ReturnsCorrectLength()
    {
        // Arrange
        int[] nums = [7, 7, 1, 2, 3];

        // Act
        var result = _task.FindShortestSubArray(nums);

        // Assert
        result.Should().Be(2);
        // Explanation: Degree is 2 (7 appears twice)
        // Shortest subarray: [7, 7] at the start
    }

    [Test]
    public void FindShortestSubArray_DegreeAtEnd_ReturnsCorrectLength()
    {
        // Arrange
        int[] nums = [1, 2, 3, 8, 8];

        // Act
        var result = _task.FindShortestSubArray(nums);

        // Assert
        result.Should().Be(2);
        // Explanation: Degree is 2 (8 appears twice)
        // Shortest subarray: [8, 8] at the end
    }

    [Test]
    public void FindShortestSubArray_DegreeInMiddle_ReturnsCorrectLength()
    {
        // Arrange
        int[] nums = [1, 9, 9, 9, 2];

        // Act
        var result = _task.FindShortestSubArray(nums);

        // Assert
        result.Should().Be(3);
        // Explanation: Degree is 3 (9 appears three times)
        // Shortest subarray: [9, 9, 9]
    }

    [Test]
    public void FindShortestSubArray_LargeNumbers_ReturnsCorrectLength()
    {
        // Arrange
        int[] nums = [49999, 49999, 1, 2, 3];

        // Act
        var result = _task.FindShortestSubArray(nums);

        // Assert
        result.Should().Be(2);
        // Explanation: Degree is 2 (49999 appears twice)
    }

    [Test]
    public void FindShortestSubArray_SpreadOutDegree_ReturnsFullSpan()
    {
        // Arrange
        int[] nums = [1, 2, 3, 4, 1, 2, 3, 4, 1];

        // Act
        var result = _task.FindShortestSubArray(nums);

        // Assert
        result.Should().Be(9);
        // Explanation: Degree is 3 (1 appears three times)
        // Need full array from first 1 to last 1
    }

    [Test]
    public void FindShortestSubArray_ConsecutiveDuplicates_ReturnsConsecutiveLength()
    {
        // Arrange
        int[] nums = [1, 2, 2, 2, 3];

        // Act
        var result = _task.FindShortestSubArray(nums);

        // Assert
        result.Should().Be(3);
        // Explanation: Degree is 3 (2 appears three times)
        // Shortest subarray: [2, 2, 2]
    }

    [Test]
    public void FindShortestSubArray_MixedFrequencies_ReturnsCorrectLength()
    {
        // Arrange
        int[] nums = [1, 1, 2, 2, 2, 3, 3, 3, 3];

        // Act
        var result = _task.FindShortestSubArray(nums);

        // Assert
        result.Should().Be(4);
        // Explanation: Degree is 4 (3 appears four times)
        // Need all occurrences of 3
    }

    [Test]
    public void FindShortestSubArray_AlternatingPattern_ReturnsCorrectLength()
    {
        // Arrange
        int[] nums = [1, 2, 1, 2, 1];

        // Act
        var result = _task.FindShortestSubArray(nums);

        // Assert
        result.Should().Be(5);
        // Explanation: Degree is 3 (1 appears three times)
        // Need full array from first 1 to last 1
    }

    [Test]
    public void FindShortestSubArray_TwoElements_Returns1Or2()
    {
        // Arrange
        int[] nums = [1, 2];

        // Act
        var result = _task.FindShortestSubArray(nums);

        // Assert
        result.Should().Be(1);
        // Explanation: Each element appears once, degree is 1
    }

    [Test]
    public void FindShortestSubArray_LongerArraySameDegree_ReturnsShortestSubarray()
    {
        // Arrange
        int[] nums = [1, 2, 3, 4, 5, 5, 6, 7, 8];

        // Act
        var result = _task.FindShortestSubArray(nums);

        // Assert
        result.Should().Be(2);
        // Explanation: Degree is 2 (5 appears twice)
        // Shortest subarray: [5, 5]
    }

    [Test]
    public void FindShortestSubArray_MultipleMaxFrequencies_ReturnsShortestOfAll()
    {
        // Arrange
        int[] nums = [1, 1, 1, 2, 2, 2, 3, 3, 3];

        // Act
        var result = _task.FindShortestSubArray(nums);

        // Assert
        result.Should().Be(3);
        // Explanation: Degree is 3 (1, 2, and 3 all appear three times)
        // All subarrays have same length 3
    }

    [Test]
    public void FindShortestSubArray_ZeroInArray_HandlesZero()
    {
        // Arrange
        int[] nums = [0, 0, 1, 2, 3];

        // Act
        var result = _task.FindShortestSubArray(nums);

        // Assert
        result.Should().Be(2);
        // Explanation: Degree is 2 (0 appears twice)
    }

    [Test]
    public void FindShortestSubArray_LargeArray_ReturnsCorrectly()
    {
        // Arrange
        int[] nums = new int[100];
        for (int i = 0; i < 50; i++) nums[i] = 1;
        for (int i = 50; i < 100; i++) nums[i] = 2;

        // Act
        var result = _task.FindShortestSubArray(nums);

        // Assert
        result.Should().Be(50);
        // Explanation: Degree is 50 (both 1 and 2 appear 50 times)
    }
}

