using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks2025;

public class LargestElementAfterMergeTaskTests
{
    private LargestElementAfterMergeTask _task = null!;

    [SetUp]
    public void SetUp()
    {
        _task = new LargestElementAfterMergeTask();
    }

    [Test]
    public void MaxArrayValue_SingleElement_ReturnsSameElement()
    {
        // Arrange
        int[] nums = [5];

        // Act
        var result = _task.MaxArrayValue(nums);

        // Assert
        result.Should().Be(5);
    }

    [Test]
    public void MaxArrayValue_Example1_Returns50()
    {
        // Arrange
        int[] nums = [2, 3, 7, 9, 3];

        // Act
        var result = _task.MaxArrayValue(nums);

        // Assert
        result.Should().Be(21);
    }

    [Test]
    public void MaxArrayValue_Example2_Returns11()
    {
        // Arrange
        int[] nums = [5, 3, 3];

        // Act
        var result = _task.MaxArrayValue(nums);

        // Assert
        result.Should().Be(11);
    }

    [Test]
    public void MaxArrayValue_AllIncreasing_ReturnsSumOfAll()
    {
        // Arrange
        int[] nums = [1, 2, 3, 4, 5];

        // Act
        var result = _task.MaxArrayValue(nums);

        // Assert
        result.Should().Be(15); // [1,2,3,4,5] -> [1,2,3,9] -> [1,2,12] -> [1,14] -> [15]
    }

    [Test]
    public void MaxArrayValue_AllDecreasing_ReturnsFirst()
    {
        // Arrange
        int[] nums = [5, 4, 3, 2, 1];

        // Act
        var result = _task.MaxArrayValue(nums);

        // Assert
        result.Should().Be(5); // No merges possible since each element > next element
    }

    [Test]
    public void MaxArrayValue_AllEqual_ReturnsSumOfAll()
    {
        // Arrange
        int[] nums = [3, 3, 3, 3];

        // Act
        var result = _task.MaxArrayValue(nums);

        // Assert
        result.Should().Be(12);
    }

    [Test]
    public void MaxArrayValue_TwoElements_FirstLessOrEqual_ReturnsSum()
    {
        // Arrange
        int[] nums = [2, 5];

        // Act
        var result = _task.MaxArrayValue(nums);

        // Assert
        result.Should().Be(7);
    }

    [Test]
    public void MaxArrayValue_TwoElements_FirstGreater_ReturnsFirst()
    {
        // Arrange
        int[] nums = [10, 3];

        // Act
        var result = _task.MaxArrayValue(nums);

        // Assert
        result.Should().Be(10);
    }

    [Test]
    public void MaxArrayValue_AlternatingValues_ReturnsCorrect()
    {
        // Arrange
        int[] nums = [1, 5, 2, 8, 3];

        // Act
        var result = _task.MaxArrayValue(nums);

        // Assert
        result.Should().Be(16); // [1,5,2,8,3] -> [1,5,10,3] -> [1,15,3] -> [16,3] -> max=16
    }

    [Test]
    public void MaxArrayValue_WithZeros_ReturnsCorrect()
    {
        // Arrange
        int[] nums = [0, 0, 5, 3];

        // Act
        var result = _task.MaxArrayValue(nums);

        // Assert
        result.Should().Be(5);
    }

    [Test]
    public void MaxArrayValue_LargeNumbers_ReturnsCorrect()
    {
        // Arrange
        int[] nums = [999998, 999999, 1000000]; // Changed to increasing order

        // Act
        var result = _task.MaxArrayValue(nums);

        // Assert
        result.Should().Be(2999997); // All can merge: [999998,999999,1000000] -> [999998,1999999] -> [2999997]
    }

    [Test]
    public void MaxArrayValue_MixedPattern_ReturnsCorrect()
    {
        // Arrange
        int[] nums = [10, 5, 8, 3, 12];

        // Act
        var result = _task.MaxArrayValue(nums);

        // Assert
        result.Should().Be(38); // [10,5,8,3,12] -> [10,5,8,15] -> [10,5,23] -> [10,28] -> [38]
    }

    [Test]
    public void MaxArrayValue_LongArray_ReturnsCorrect()
    {
        // Arrange
        int[] nums = [1, 2, 1, 3, 2, 5, 4, 8, 7, 10];

        // Act
        var result = _task.MaxArrayValue(nums);

        // Assert
        result.Should().Be(43); // Complex merge pattern
    }

    [Test]
    public void MaxArrayValue_AllOnes_ReturnsSumOfAll()
    {
        // Arrange
        int[] nums = [1, 1, 1, 1, 1, 1];

        // Act
        var result = _task.MaxArrayValue(nums);

        // Assert
        result.Should().Be(6);
    }

    [Test]
    public void MaxArrayValue_PeakInMiddle_ReturnsCorrect()
    {
        // Arrange
        int[] nums = [1, 2, 10, 3, 4];

        // Act
        var result = _task.MaxArrayValue(nums);

        // Assert
        result.Should().Be(13);
    }
}
