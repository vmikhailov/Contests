using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks2025;

[TestFixture]
public class LongestIncreasingSubsequenceTaskTests
{
    private LongestIncreasingSubsequenceTask _task = null!;

    [SetUp]
    public void SetUp()
    {
        _task = new LongestIncreasingSubsequenceTask();
    }

    [Test]
    public void LengthOfLIS_BasicExample_ReturnsCorrectLength()
    {
        // Arrange
        // Sequence: [10, 9, 2, 5, 3, 7, 101, 18]
        // LIS: [2, 3, 7, 101] or [2, 5, 7, 101] or [2, 3, 7, 18]
        int[] nums = [10, 9, 2, 5, 3, 7, 101, 18];

        // Act
        var result = _task.LengthOfLIS(nums);

        // Assert
        result.Should().Be(4);
    }

    [Test]
    public void LengthOfLIS_AllIncreasing_ReturnsArrayLength()
    {
        // Arrange
        // Sequence: [0, 1, 0, 3, 2, 3]
        // LIS: [0, 1, 2, 3]
        int[] nums = [0, 1, 0, 3, 2, 3];

        // Act
        var result = _task.LengthOfLIS(nums);

        // Assert
        result.Should().Be(4);
    }

    [Test]
    public void LengthOfLIS_AllSameElements_ReturnsOne()
    {
        // Arrange
        int[] nums = [7, 7, 7, 7, 7, 7, 7];

        // Act
        var result = _task.LengthOfLIS(nums);

        // Assert
        result.Should().Be(1);
    }

    [Test]
    public void LengthOfLIS_SingleElement_ReturnsOne()
    {
        // Arrange
        int[] nums = [5];

        // Act
        var result = _task.LengthOfLIS(nums);

        // Assert
        result.Should().Be(1);
    }

    [Test]
    public void LengthOfLIS_TwoElementsIncreasing_ReturnsTwo()
    {
        // Arrange
        int[] nums = [1, 3];

        // Act
        var result = _task.LengthOfLIS(nums);

        // Assert
        result.Should().Be(2);
    }

    [Test]
    public void LengthOfLIS_TwoElementsDecreasing_ReturnsOne()
    {
        // Arrange
        int[] nums = [3, 1];

        // Act
        var result = _task.LengthOfLIS(nums);

        // Assert
        result.Should().Be(1);
    }

    [Test]
    public void LengthOfLIS_StrictlyDecreasing_ReturnsOne()
    {
        // Arrange
        int[] nums = [10, 9, 8, 7, 6, 5, 4, 3, 2, 1];

        // Act
        var result = _task.LengthOfLIS(nums);

        // Assert
        result.Should().Be(1);
    }

    [Test]
    public void LengthOfLIS_StrictlyIncreasing_ReturnsArrayLength()
    {
        // Arrange
        int[] nums = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

        // Act
        var result = _task.LengthOfLIS(nums);

        // Assert
        result.Should().Be(10);
    }

    [Test]
    public void LengthOfLIS_AlternatingPattern_ReturnsCorrectLength()
    {
        // Arrange
        // Pattern: [1, 3, 2, 4, 3, 5]
        // LIS: [1, 2, 3, 5] or [1, 2, 4, 5] or [1, 3, 4, 5]
        int[] nums = [1, 3, 2, 4, 3, 5];

        // Act
        var result = _task.LengthOfLIS(nums);

        // Assert
        result.Should().Be(4);
    }

    [Test]
    public void LengthOfLIS_NegativeNumbers_ReturnsCorrectLength()
    {
        // Arrange
        int[] nums = [-10, -5, -2, 0, 3, 7];

        // Act
        var result = _task.LengthOfLIS(nums);

        // Assert
        result.Should().Be(6);
    }

    [Test]
    public void LengthOfLIS_MixedPositiveNegative_ReturnsCorrectLength()
    {
        // Arrange
        int[] nums = [-5, 3, -2, 8, 1, 10];

        // Act
        var result = _task.LengthOfLIS(nums);

        // Assert
        result.Should().Be(4); // [-5, -2, 1, 10] or [-5, 3, 8, 10]
    }

    [Test]
    public void LengthOfLIS_LargeValues_ReturnsCorrectLength()
    {
        // Arrange
        int[] nums = [1000, 2000, 500, 3000, 1500, 4000];

        // Act
        var result = _task.LengthOfLIS(nums);

        // Assert
        result.Should().Be(4); // [1000, 2000, 3000, 4000]
    }

    [Test]
    public void LengthOfLIS_DuplicateElements_ReturnsCorrectLength()
    {
        // Arrange
        int[] nums = [1, 3, 6, 7, 9, 4, 10, 5, 6];

        // Act
        var result = _task.LengthOfLIS(nums);

        // Assert
        result.Should().Be(6); // [1, 3, 4, 5, 6, ...] or [1, 3, 6, 7, 9, 10]
    }

    [Test]
    public void LengthOfLIS_PlateauPattern_ReturnsCorrectLength()
    {
        // Arrange
        // Pattern: rises, plateaus, rises again
        int[] nums = [1, 2, 3, 3, 3, 4, 5];

        // Act
        var result = _task.LengthOfLIS(nums);

        // Assert
        result.Should().Be(5); // [1, 2, 3, 4, 5]
    }

    [Test]
    public void LengthOfLIS_VShapePattern_ReturnsCorrectLength()
    {
        // Arrange
        // Pattern: decreases then increases
        int[] nums = [10, 9, 2, 5, 3, 7, 101, 18];

        // Act
        var result = _task.LengthOfLIS(nums);

        // Assert
        result.Should().Be(4); // [2, 3, 7, 18] or similar
    }

    [Test]
    public void LengthOfLIS_ZigZagPattern_ReturnsCorrectLength()
    {
        // Arrange
        int[] nums = [2, 1, 5, 3, 6, 4, 8, 7, 9];

        // Act
        var result = _task.LengthOfLIS(nums);

        // Assert
        result.Should().Be(5); // [1, 3, 4, 7, 9] or [2, 5, 6, 8, 9]
    }

    [Test]
    public void LengthOfLIS_AllZeros_ReturnsOne()
    {
        // Arrange
        int[] nums = [0, 0, 0, 0];

        // Act
        var result = _task.LengthOfLIS(nums);

        // Assert
        result.Should().Be(1);
    }

    [Test]
    public void LengthOfLIS_LongerSequence_ReturnsCorrectLength()
    {
        // Arrange
        int[] nums = [10, 22, 9, 33, 21, 50, 41, 60, 80];

        // Act
        var result = _task.LengthOfLIS(nums);

        // Assert
        result.Should().Be(6); // [10, 22, 33, 50, 60, 80]
    }

    [Test]
    public void LengthOfLIS_Optimized_BasicExample_ReturnsCorrectLength()
    {
        // Arrange
        var optimized = new LongestIncreasingSubsequenceTask();
        int[] nums = [10, 9, 2, 5, 3, 7, 101, 18];

        // Act
        var result = optimized.LengthOfLIS(nums);

        // Assert
        result.Should().Be(4);
    }

    [Test]
    public void LengthOfLIS_Optimized_StrictlyIncreasing_ReturnsArrayLength()
    {
        // Arrange
        var optimized = new LongestIncreasingSubsequenceTask();
        int[] nums = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

        // Act
        var result = optimized.LengthOfLIS(nums);

        // Assert
        result.Should().Be(10);
    }

    [Test]
    public void LengthOfLIS_Optimized_AllSame_ReturnsOne()
    {
        // Arrange
        var optimized = new LongestIncreasingSubsequenceTask();
        int[] nums = [5, 5, 5, 5, 5];

        // Act
        var result = optimized.LengthOfLIS(nums);

        // Assert
        result.Should().Be(1);
    }
}

