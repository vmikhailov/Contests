using NUnit.Framework;
using FluentAssertions;

namespace LeetCode.Tasks2025;

public class MinimumCostToCutTaskTests
{
    private MinimumCostToCutTask _task = null!;

    [SetUp]
    public void SetUp()
    {
        _task = new MinimumCostToCutTask();
    }

    [Test]
    public void MinCost_Example1_Returns16()
    {
        // Arrange
        // Stick length 7, cuts at [1,3,4,5]
        // Optimal: cut at 1 (cost 7), then cut at 3 (cost 6), then cut at 4 (cost 4), then cut at 5 (cost 4)
        // But better order exists
        var n = 7;
        int[] cuts = [1, 3, 4, 5];

        // Act
        var result = _task.MinCost(n, cuts);

        // Assert
        result.Should().Be(16);
    }

    [Test]
    public void MinCost_Example2_Returns22()
    {
        // Arrange
        var n = 9;
        int[] cuts = [5, 6, 1, 4, 2];

        // Act
        var result = _task.MinCost(n, cuts);

        // Assert
        result.Should().Be(22);
    }

    [Test]
    public void MinCost_SingleCut_ReturnsStickLength()
    {
        // Arrange
        // Only one cut, cost is the length of the stick
        var n = 10;
        int[] cuts = [5];

        // Act
        var result = _task.MinCost(n, cuts);

        // Assert
        result.Should().Be(10);
    }

    [Test]
    public void MinCost_TwoCutsAtEnds_Returns19()
    {
        // Arrange
        var n = 10;
        int[] cuts = [1, 9];

        // Act
        var result = _task.MinCost(n, cuts);

        // Assert
        result.Should().Be(19);
    }

    [Test]
    public void MinCost_TwoCutsInMiddle_Returns16()
    {
        // Arrange
        var n = 10;
        int[] cuts = [4, 6];

        // Act
        var result = _task.MinCost(n, cuts);

        // Assert
        result.Should().Be(16);
    }

    [Test]
    public void MinCost_ThreeCutsEvenlySpaced_Returns20()
    {
        // Arrange
        var n = 10;
        int[] cuts = [2, 5, 8];

        // Act
        var result = _task.MinCost(n, cuts);

        // Assert
        result.Should().Be(20);
    }

    [Test]
    public void MinCost_SmallStick_Returns4()
    {
        // Arrange
        var n = 3;
        int[] cuts = [1];

        // Act
        var result = _task.MinCost(n, cuts);

        // Assert
        result.Should().Be(3);
    }

    [Test]
    public void MinCost_ManyCutsInSequence_Returns40()
    {
        // Arrange
        var n = 20;
        int[] cuts = [5, 10, 15];

        // Act
        var result = _task.MinCost(n, cuts);

        // Assert
        result.Should().Be(40);
    }

    [Test]
    public void MinCost_CutsAtBothEnds_Returns15()
    {
        // Arrange
        var n = 8;
        int[] cuts = [1, 7];

        // Act
        var result = _task.MinCost(n, cuts);

        // Assert
        result.Should().Be(15);
    }

    [Test]
    public void MinCost_FourCuts_Returns24()
    {
        // Arrange
        var n = 10;
        int[] cuts = [2, 4, 6, 8];

        // Act
        var result = _task.MinCost(n, cuts);

        // Assert
        result.Should().Be(24);
    }

    [Test]
    public void MinCost_UnsortedCuts_ReturnsOptimal()
    {
        // Arrange
        var n = 7;
        int[] cuts = [5, 3, 1, 4];

        // Act
        var result = _task.MinCost(n, cuts);

        // Assert
        result.Should().Be(16);
    }

    [Test]
    public void MinCost_CutInMiddle_ReturnsStickLength()
    {
        // Arrange
        var n = 6;
        int[] cuts = [3];

        // Act
        var result = _task.MinCost(n, cuts);

        // Assert
        result.Should().Be(6);
    }

    [Test]
    public void MinCost_TwoCutsCloseToStart_Returns12()
    {
        // Arrange
        var n = 10;
        int[] cuts = [1, 2];

        // Act
        var result = _task.MinCost(n, cuts);

        // Assert
        result.Should().Be(12);
    }

    [Test]
    public void MinCost_LargeStickWithFewCuts_ReturnsOptimal()
    {
        // Arrange
        var n = 100;
        int[] cuts = [25, 50, 75];

        // Act
        var result = _task.MinCost(n, cuts);

        // Assert
        result.Should().Be(200);
    }

    [Test]
    public void MinCost_ConsecutiveCuts_Returns13()
    {
        // Arrange
        var n = 7;
        int[] cuts = [2, 3, 4];

        // Act
        var result = _task.MinCost(n, cuts);

        // Assert
        result.Should().Be(13);
    }

    [Test]
    public void MinCost_TwoCutsSymmetric_Returns17()
    {
        // Arrange
        var n = 10;
        int[] cuts = [3, 7];

        // Act
        var result = _task.MinCost(n, cuts);

        // Assert
        result.Should().Be(17);
    }
}

