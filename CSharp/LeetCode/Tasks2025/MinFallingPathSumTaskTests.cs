using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks2025;

[TestFixture]
public class MinFallingPathSumTaskTests
{
    private MinFallingPathSumTask _task = null!;

    [SetUp]
    public void SetUp() => _task = new MinFallingPathSumTask();

    [Test]
    public void MinFallingPathSum_2x2Matrix_ReturnsMinPath()
    {
        // [[2,1],[3,4]]
        // Possible paths: 2->3=5, 2->4=6, 1->3=4, 1->4=5
        // Min = 4
        var matrix = new int[][] { [2, 1], [3, 4] };
        _task.MinFallingPathSum(matrix).Should().Be(4);
    }

    [Test]
    public void MinFallingPathSum_3x3Matrix_Example1_ReturnsMinPath()
    {
        // [[-19,57],[-40,-5]]
        // Min path: -19 -> -40 = -59
        var matrix = new int[][] { [-19, 57], [-40, -5] };
        _task.MinFallingPathSum(matrix).Should().Be(-59);
    }

    [Test]
    public void MinFallingPathSum_3x3Matrix_Example2_ReturnsMinPath()
    {
        // [[100,-42,-46,-41],[31,97,10,-10],[-58,-51,82,89],[51,81,69,-51]]
        var matrix = new int[][]
        {
            [100, -42, -46, -41],
            [31, 97, 10, -10],
            [-58, -51, 82, 89],
            [51, 81, 69, -51]
        };
        _task.MinFallingPathSum(matrix).Should().Be(-36);
    }

    [Test]
    public void MinFallingPathSum_SingleElement_ReturnsElement()
    {
        var matrix = new int[][] { [5] };
        _task.MinFallingPathSum(matrix).Should().Be(5);
    }

    [Test]
    public void MinFallingPathSum_SingleRow_ReturnsMinElement()
    {
        var matrix = new int[][] { [1, 2, 3] };
        _task.MinFallingPathSum(matrix).Should().Be(1);
    }

    [Test]
    public void MinFallingPathSum_AllNegative_ReturnsMinimumSum()
    {
        var matrix = new int[][]
        {
            [-1, -2, -3],
            [-4, -5, -6],
            [-7, -8, -9]
        };
        // DP calculation from bottom to top:
        // Row 2: [-7, -8, -9]
        // Row 1: [-4+min(-7,-8)=-12, -5+min(-7,-8,-9)=-14, -6+min(-8,-9)=-15]
        // Row 0: [-1+min(-12,-14)=-15, -2+min(-12,-14,-15)=-17, -3+min(-14,-15)=-18]
        // Min of row 0: min(-15, -17, -18) = -18
        // Path: -3 -> -6 -> -9 = -18 (most negative sum)
        _task.MinFallingPathSum(matrix).Should().Be(-18);
    }

    [Test]
    public void MinFallingPathSum_AllPositive_ReturnsMinPath()
    {
        var matrix = new int[][]
        {
            [1, 2, 3],
            [4, 5, 6],
            [7, 8, 9]
        };
        // Path: 1 -> 4 -> 7 = 12
        _task.MinFallingPathSum(matrix).Should().Be(12);
    }

    [Test]
    public void MinFallingPathSum_MixedValues_ReturnsMinPath()
    {
        var matrix = new int[][]
        {
            [2, 1, 3],
            [6, 5, 4],
            [7, 8, 9]
        };
        // DP calculation from bottom to top:
        // Row 2: [7, 8, 9]
        // Row 1: [6+7=13, 5+7=12, 4+8=12]
        // Row 0: [2+12=14, 1+12=13, 3+12=15]
        // Min = 13 (path: 1 -> 5 -> 7)
        _task.MinFallingPathSum(matrix).Should().Be(13);
    }

    [Test]
    public void MinFallingPathSum_DiagonalPath_Works()
    {
        var matrix = new int[][]
        {
            [10, 20, 30],
            [1, 100, 100],
            [100, 100, 1]
        };
        // DP calculation from bottom to top:
        // Row 2: [100, 100, 1]
        // Row 1: [1+100=101, 100+1=101, 100+1=101]
        // Row 0: [10+101=111, 20+101=121, 30+101=131]
        // Min = 111 (path: 10 -> 1 -> 100 or 10 -> 100 -> 100)
        _task.MinFallingPathSum(matrix).Should().Be(111);
    }

    [Test]
    public void MinFallingPathSum_4x4Matrix_ReturnsMinPath()
    {
        var matrix = new int[][]
        {
            [1, 2, 3, 4],
            [5, 6, 7, 8],
            [9, 10, 11, 12],
            [13, 14, 15, 16]
        };
        // Path: 1 -> 5 -> 9 -> 13 = 28
        _task.MinFallingPathSum(matrix).Should().Be(28);
    }

    [Test]
    public void MinFallingPathSum_WithZeros_ReturnsMinPath()
    {
        var matrix = new int[][]
        {
            [0, 0, 0],
            [1, 2, 1],
            [3, 4, 3]
        };
        // Path: 0 -> 1 -> 3 = 4
        _task.MinFallingPathSum(matrix).Should().Be(4);
    }

    [Test]
    public void MinFallingPathSum_LargeNegative_ReturnsMinPath()
    {
        var matrix = new int[][]
        {
            [-100, 1, 1],
            [1, -100, 1],
            [1, 1, -100]
        };
        // Path: -100 -> -100 -> -100 = -300 (diagonal)
        _task.MinFallingPathSum(matrix).Should().Be(-300);
    }

    [Test]
    public void MinFallingPathSum_5x5Matrix_ReturnsMinPath()
    {
        var matrix = new int[][]
        {
            [1, 2, 3, 4, 5],
            [6, 7, 8, 9, 10],
            [11, 12, 13, 14, 15],
            [16, 17, 18, 19, 20],
            [21, 22, 23, 24, 25]
        };
        // Path: 1 -> 6 -> 11 -> 16 -> 21 = 55
        _task.MinFallingPathSum(matrix).Should().Be(55);
    }
}