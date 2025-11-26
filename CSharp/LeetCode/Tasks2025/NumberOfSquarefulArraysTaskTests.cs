using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks2025;

public class NumberOfSquarefulArraysTaskTests
{
    private NumberOfSquarefulArraysTask _task = null!;

    [SetUp]
    public void SetUp()
    {
        _task = new NumberOfSquarefulArraysTask();
    }

    [Test]
    public void NumSquarefulPerms_Example1_Returns2()
    {
        // Arrange
        int[] nums = [1, 17, 8];

        // Act
        var result = _task.NumSquarefulPerms(nums);

        // Assert
        result.Should().Be(2);
    }

    [Test]
    public void NumSquarefulPerms_Example2_Returns1()
    {
        // Arrange
        int[] nums = [2, 2, 2];

        // Act
        var result = _task.NumSquarefulPerms(nums);

        // Assert
        result.Should().Be(1);
    }

    [Test]
    public void NumSquarefulPerms_SingleElement_Returns1()
    {
        // Arrange
        int[] nums = [1];

        // Act
        var result = _task.NumSquarefulPerms(nums);

        // Assert
        result.Should().Be(1);
    }

    [Test]
    public void NumSquarefulPerms_TwoElementsSquareful_Returns2()
    {
        // Arrange
        int[] nums = [1, 8]; // 1+8=9 which is 3^2

        // Act
        var result = _task.NumSquarefulPerms(nums);

        // Assert
        result.Should().Be(2);
    }

    [Test]
    public void NumSquarefulPerms_TwoElementsNotSquareful_Returns0()
    {
        // Arrange
        int[] nums = [2, 3]; // 2+3=5 which is not a perfect square

        // Act
        var result = _task.NumSquarefulPerms(nums);

        // Assert
        result.Should().Be(0);
    }

    [Test]
    public void NumSquarefulPerms_AllZeros_ReturnsCorrect()
    {
        // Arrange
        int[] nums = [0, 0, 0];

        // Act
        var result = _task.NumSquarefulPerms(nums);

        // Assert
        result.Should().Be(1);
    }

    [Test]
    public void NumSquarefulPerms_MixedWithZero_ReturnsCorrect()
    {
        // Arrange
        int[] nums = [0, 1, 4]; // 0+1=1 (1^2), 0+4=4 (2^2), 1+4=5 (not perfect square)

        // Act
        var result = _task.NumSquarefulPerms(nums);

        // Assert
        result.Should().Be(2); // [1,0,4] and [4,0,1]
    }

    [Test]
    public void NumSquarefulPerms_LargerArray_ReturnsCorrect()
    {
        // Arrange
        int[] nums = [1, 8, 17, 15]; // 1+8=9, 1+15=16, 8+17=25

        // Act
        var result = _task.NumSquarefulPerms(nums);

        // Assert
        result.Should().Be(2); // [15,1,8,17] and [17,8,1,15]
    }

    [Test]
    public void NumSquarefulPerms_ConsecutiveNumbers_ReturnsCorrect()
    {
        // Arrange
        int[] nums = [8, 17, 19, 30]; // 8+17=25 (5^2), 17+19=36 (6^2), 19+30=49 (7^2)

        // Act
        var result = _task.NumSquarefulPerms(nums);

        // Assert
        result.Should().Be(2); // [8,17,19,30] and [30,19,17,8]
    }

    [Test]
    public void NumSquarefulPerms_DuplicateValues_ReturnsCorrect()
    {
        // Arrange
        int[] nums = [1, 1, 8, 8];

        // Act
        var result = _task.NumSquarefulPerms(nums);

        // Assert
        result.Should().Be(3);
    }

    [Test]
    public void NumSquarefulPerms_WithDuplicateFives_ReturnsCorrect()
    {
        // Arrange
        // 5+11=16 (4^2), 5+4=9 (3^2), but 11+4=15 (not a perfect square)
        // Array has three 5s, one 11, and one 4
        // No valid complete path possible with all 5 elements
        int[] nums = [5, 11, 5, 4, 5];

        // Act
        var result = _task.NumSquarefulPerms(nums);

        // Assert
        result.Should().Be(2);
    }
}
