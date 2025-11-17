using NUnit.Framework;
using FluentAssertions;

namespace LeetCode.Tasks2025;

public class MinimumPathSumTaskTests
{
    private MinimumPathSumTask _task = null!;

    [SetUp]
    public void SetUp()
    {
        _task = new MinimumPathSumTask();
    }

    [Test]
    public void MinPathSum_SingleCell_ReturnsCellValue()
    {
        // Arrange
        var grid = new int[][]
        {
            [5]
        };

        // Act
        var result = _task.MinPathSum(grid);

        // Assert
        result.Should().Be(5);
    }

    [Test]
    public void MinPathSum_SingleRow_ReturnsSum()
    {
        // Arrange
        var grid = new int[][]
        {
            [1, 2, 3]
        };

        // Act
        var result = _task.MinPathSum(grid);

        // Assert
        result.Should().Be(6);
    }

    [Test]
    public void MinPathSum_SingleColumn_ReturnsSum()
    {
        // Arrange
        var grid = new int[][]
        {
            [1],
            [2],
            [3]
        };

        // Act
        var result = _task.MinPathSum(grid);

        // Assert
        result.Should().Be(6);
    }

    [Test]
    public void MinPathSum_Example3x3_Returns7()
    {
        // Arrange
        var grid = new int[][]
        {
            [1, 3, 1],
            [1, 5, 1],
            [4, 2, 1]
        };

        // Act
        var result = _task.MinPathSum(grid);

        // Assert
        result.Should().Be(7);
    }

    [Test]
    public void MinPathSum_Rectangular2x3_Returns12()
    {
        // Arrange
        var grid = new int[][]
        {
            [1, 2, 3],
            [4, 5, 6]
        };

        // Act
        var result = _task.MinPathSum(grid);

        // Assert
        result.Should().Be(12);
    }

    [Test]
    public void MinPathSum_AllZeros_Returns0()
    {
        // Arrange
        var grid = new int[][]
        {
            [0, 0],
            [0, 0]
        };

        // Act
        var result = _task.MinPathSum(grid);

        // Assert
        result.Should().Be(0);
    }

    [Test]
    public void MinPathSum_LargerGrid_Check()
    {
        // Arrange
        var grid = new int[][]
        {
            [1, 4, 2, 3],
            [2, 1, 8, 1],
            [3, 2, 1, 1]
        };

        // Expected minimal path: 1 -> 2 -> 1 -> 2 -> 1 -> 1 = 8 (one valid minimal path)
        // Act
        var result = _task.MinPathSum(grid);

        // Assert
        result.Should().Be(8);
    }
}
