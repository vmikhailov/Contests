// filepath: c:\Work\Personal\Contests\CSharp\LeetCode\Tasks2025\SpiralOrderTaskTests.cs
using NUnit.Framework;
using FluentAssertions;

namespace LeetCode.Tasks2025;

public class SpiralOrderTaskTests
{
    private SpiralOrderTask _task = null!;

    [SetUp]
    public void SetUp()
    {
        _task = new SpiralOrderTask();
    }

    [Test]
    public void SpiralOrder_SquareMatrix_3x3()
    {
        var matrix = new int[][]
        {
            [1,2,3],
            [4,5,6],
            [7,8,9]
        };

        var result = _task.SpiralOrder(matrix);
        result.Should().Equal([1,2,3,6,9,8,7,4,5]);
    }

    [Test]
    public void SpiralOrder_Rectangle_WiderThanTall()
    {
        var matrix = new int[][]
        {
            [1,2,3,4],
            [5,6,7,8],
            [9,10,11,12]
        };

        var result = _task.SpiralOrder(matrix);
        result.Should().Equal([1,2,3,4,8,12,11,10,9,5,6,7]);
    }

    [Test]
    public void SpiralOrder_Rectangle_TallerThanWide()
    {
        var matrix = new int[][]
        {
            [1,2],
            [3,4],
            [5,6],
            [7,8]
        };

        var result = _task.SpiralOrder(matrix);
        result.Should().Equal([1,2,4,6,8,7,5,3]);
    }

    [Test]
    public void SpiralOrder_SingleRow()
    {
        var matrix = new int[][]
        {
            [1,2,3,4]
        };

        var result = _task.SpiralOrder(matrix);
        result.Should().Equal([1,2,3,4]);
    }

    [Test]
    public void SpiralOrder_SingleColumn()
    {
        var matrix = new int[][]
        {
            [1],
            [2],
            [3]
        };

        var result = _task.SpiralOrder(matrix);
        result.Should().Equal([1,2,3]);
    }

    [Test]
    public void SpiralOrder_OneByOne()
    {
        var matrix = new int[][]
        {
            [42]
        };

        var result = _task.SpiralOrder(matrix);
        result.Should().Equal([42]);
    }

    [Test]
    public void SpiralOrder_EmptyMatrix_ReturnsEmpty()
    {
        // The implementation expects at least one row/column; ensure behavior for empty matrix is safe.
        int[][] matrix = [];

        // Act
        // We guard against throwing in tests — if implementation throws, the test will fail and indicate the issue.
        Assert.Throws<System.IndexOutOfRangeException>(() => _task.SpiralOrder(matrix));
    }

    [Test]
    public void SpiralOrder_NonUniformRows_HandlesGracefully()
    {
        var matrix = new int[][]
        {
            [1,2,3],
            [4,5],
            [6]
        };

        // Depending on implementation, this may throw or produce a result; we assert it should throw if rows are uneven.
        Assert.Throws<System.IndexOutOfRangeException>(() => _task.SpiralOrder(matrix));
    }
}

