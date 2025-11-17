using NUnit.Framework;
using FluentAssertions;

namespace LeetCode.Tasks2025;

public class TrappingRainWaterTaskTests
{
    private TrappingRainWaterTask _task = null!;

    [SetUp]
    public void SetUp()
    {
        _task = new TrappingRainWaterTask();
    }

    [Test]
    public void Trap_Example1_Returns6()
    {
        // Arrange
        int[] height = [0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1];

        // Act
        var result = _task.Trap(height);

        // Assert
        result.Should().Be(6);
    }

    [Test]
    public void Trap_Example2_Returns9()
    {
        // Arrange
        int[] height = [4, 2, 0, 3, 2, 5];

        // Act
        var result = _task.Trap(height);

        // Assert
        result.Should().Be(9);
    }

    [Test]
    public void Trap_FlatGround_Returns0()
    {
        // Arrange
        int[] height = [0, 0, 0, 0];

        // Act
        var result = _task.Trap(height);

        // Assert
        result.Should().Be(0);
    }

    [Test]
    public void Trap_SingleBar_Returns0()
    {
        // Arrange
        int[] height = [5];

        // Act
        var result = _task.Trap(height);

        // Assert
        result.Should().Be(0);
    }

    [Test]
    public void Trap_TwoBars_Returns0()
    {
        // Arrange
        int[] height = [3, 5];

        // Act
        var result = _task.Trap(height);

        // Assert
        result.Should().Be(0);
    }

    [Test]
    public void Trap_SimpleValley_Returns1()
    {
        // Arrange
        int[] height = [2, 1, 2];

        // Act
        var result = _task.Trap(height);

        // Assert
        result.Should().Be(1);
    }

    [Test]
    public void Trap_DeepValley_Returns5()
    {
        // Arrange
        int[] height = [5, 0, 5];

        // Act
        var result = _task.Trap(height);

        // Assert
        result.Should().Be(5);
    }

    [Test]
    public void Trap_AscendingOrder_Returns0()
    {
        // Arrange
        int[] height = [1, 2, 3, 4, 5];

        // Act
        var result = _task.Trap(height);

        // Assert
        result.Should().Be(0);
    }

    [Test]
    public void Trap_DescendingOrder_Returns0()
    {
        // Arrange
        int[] height = [5, 4, 3, 2, 1];

        // Act
        var result = _task.Trap(height);

        // Assert
        result.Should().Be(0);
    }

    [Test]
    public void Trap_MultipleValleys_Returns7()
    {
        // Arrange
        int[] height = [3, 0, 2, 0, 4];

        // Act
        var result = _task.Trap(height);

        // Assert
        result.Should().Be(7);
    }

    [Test]
    public void Trap_WideValley_Returns6()
    {
        // Arrange
        int[] height = [3, 1, 1, 1, 3];

        // Act
        var result = _task.Trap(height);

        // Assert
        result.Should().Be(6);
    }

    [Test]
    public void Trap_StaircasePattern_Returns1()
    {
        // Arrange
        int[] height = [1, 2, 1, 2];

        // Act
        var result = _task.Trap(height);

        // Assert
        result.Should().Be(1);
    }

    [Test]
    public void Trap_EmptyArray_Returns0()
    {
        // Arrange
        int[] height = [];

        // Act
        var result = _task.Trap(height);

        // Assert
        result.Should().Be(0);
    }

    [Test]
    public void Trap_AllZeros_Returns0()
    {
        // Arrange
        int[] height = [0, 0, 0, 0, 0];

        // Act
        var result = _task.Trap(height);

        // Assert
        result.Should().Be(0);
    }

    [Test]
    public void Trap_PeakInMiddle_Returns0()
    {
        // Arrange
        int[] height = [1, 2, 3, 2, 1];

        // Act
        var result = _task.Trap(height);

        // Assert
        result.Should().Be(0);
    }

    [Test]
    public void Trap_ComplexPattern_Returns14()
    {
        // Arrange
        int[] height = [5, 2, 1, 2, 1, 5];

        // Act
        var result = _task.Trap(height);

        // Assert
        result.Should().Be(14);
    }
}

