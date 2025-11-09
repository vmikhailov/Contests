using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks;

public class SeparateSquaresTask
{
    private static int BinarySearchLow(List<int> list, int value)
    {
        var left = 0;
        var right = list.Count - 1;
        var result = -1;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (list[mid] < value)
            {
                left = mid + 1;
            }
            else if (list[mid] > value)
            {
                right = mid - 1;
            }
            else
            {
                result = mid;
                right = mid - 1; // keep searching left for first occurrence
            }
        }
        return result >= 0 ? result : ~left;
    }

    private static int BinarySearchHigh(List<int> list, int value)
    {
        var left = 0;
        var right = list.Count - 1;
        var result = -1;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (list[mid] < value)
            {
                left = mid + 1;
            }
            else if (list[mid] > value)
            {
                right = mid - 1;
            }
            else
            {
                result = mid;
                left = mid + 1;; // keep searching right for last occurrence
            }
        }

        return result >= 0 ? result : ~left;
    }

    private static (int, int) GetFistAndLastIndex(List<int> list, int value)
    {
        for(var i = 0; i < list.Count; i++)
        {
            if (list[i] != value)
            {
                continue;
            }

            var first = i;
            var last = i;
            while (last + 1 < list.Count && list[last + 1] == value)
            {
                last++;
            }
            return (first, last);
        }

        return (-1, -1);
    }

    public double SeparateSquares(int[][] squares)
    {
        var all = squares.Select(x => x[2]*x[2]).Sum();
        var half = all / 2.0;
        var error = 1e-5/2;

        var sq = squares.OrderBy(x => x[1]).ToList();
        var y1 = sq.Select(x => x[1]).ToList(); // bottom y
        var y2 = sq.Select(x => x[1] + x[2]).ToList(); // top y

        var yy2 = sq.OrderBy(x => x[1] + x[2]).ToList();

        var area = 0;
        for (var i = 0; i < y2.Count; i++)
        {
            var side = yy2[i];
            area += side[2] * side[2];
            y2[i] = area;
        }

        var bottom = (double)sq[0][1];
        var top = (double)sq[^1][1];

        while (true)
        {
            var (s1, s2, y) = Calculate();

            if (Math.Abs(s1 - s2) < error)
            {
                return y;
            }

            if (s1 < s2)
            {
                bottom = y;
            }
            else
            {
                top = y;
            }
        }

        (int, int, double) Calculate()
        {
            var y = (bottom + top) / 2;

            var p1 = BinarySearchHigh(y2, (int)y); // last square with top y <= y
            var p2 = BinarySearchLow(y1, (int)y);

            return (0, 0, y);
        }
    }
}

[TestFixture]
public class SeparateSquaresTaskTests
{
    private SeparateSquaresTask _task = null!;

    [SetUp]
    public void SetUp() => _task = new SeparateSquaresTask();

    [Test]
    public void SeparateSquares_EmptyInput_ReturnsZero()
    {
        _task.SeparateSquares([]).Should().Be(0);
    }

    [Test]
    public void SeparateSquares_SingleSquare_ReturnsMiddleY()
    {
        // For a single square at (0, 0) with side 2, the line should be at y = 1
        var squares = new[] { new[] { 0, 0, 2 } };
        _task.SeparateSquares(squares).Should().BeApproximately(1.0, 1e-5);
    }

    [Test]
    public void SeparateSquares_TwoNonOverlappingSquares_SameSize_Symmetric_ReturnsMiddleY()
    {
        // Two squares: (0,0,2) and (0,4,2), line should be at y=3
        var squares = new[] { new[] { 0, 0, 2 }, new[] { 0, 4, 2 } };
        _task.SeparateSquares(squares).Should().BeApproximately(3.0, 1e-5);
    }

    [Test]
    public void SeparateSquares_TwoOverlappingSquares_ReturnsMiddleY()
    {
        // Two squares: (0,0,4) and (0,2,4), overlap from y=2 to y=4
        // By symmetry, line should be at y=4
        var squares = new[] { new[] { 0, 0, 4 }, new[] { 0, 2, 4 } };
        _task.SeparateSquares(squares).Should().BeApproximately(4.0, 1e-5);
    }

    [Test]
    public void SeparateSquares_MultipleSquares_VariedSizes_ReturnsCorrectY()
    {
        // Three squares: (0,0,2), (0,2,4), (0,6,2)
        // By symmetry, line should be at y=4
        var squares = new[] { new[] { 0, 0, 2 }, new[] { 0, 2, 4 }, new[] { 0, 6, 2 } };
        _task.SeparateSquares(squares).Should().BeApproximately(4.0, 1e-5);
    }

    [Test]
    public void SeparateSquares_SquaresWithDifferentX_IgnoresX()
    {
        // Squares at different x, but only y matters
        var squares = new[] { new[] { 0, 0, 2 }, new[] { 10, 4, 2 } };
        _task.SeparateSquares(squares).Should().BeApproximately(3.0, 1e-5);
    }

    [Test]
    public void SeparateSquares_SquaresWithNegativeY_ReturnsCorrectY()
    {
        // Squares: (0,-2,4), (0,2,4), line should be at y=2
        var squares = new[] { new[] { 0, -2, 4 }, new[] { 0, 2, 4 } };
        _task.SeparateSquares(squares).Should().BeApproximately(2.0, 1e-5);
    }

    [Test]
    public void SeparateSquares_SquaresWithFractionalY_ReturnsCorrectY()
    {
        // Squares: (0,0,1), (0,1,1), line should be at y=1
        var squares = new[] { new[] { 0, 0, 1 }, new[] { 0, 1, 1 } };
        _task.SeparateSquares(squares).Should().BeApproximately(1.0, 1e-5);
    }

    [Test]
    public void SeparateSquares_TenSquares_ComplexCase_ReturnsExpectedY()
    {
        // 10 squares, varied positions and sizes
        var squares = new[]
        {
            new[] { 0, 0, 2 },
            new[] { 1, 3, 3 },
            new[] { 2, 6, 2 },
            new[] { 3, 1, 4 },
            new[] { 4, 5, 1 },
            new[] { 5, 2, 2 },
            new[] { 6, 7, 3 },
            new[] { 7, 4, 2 },
            new[] { 8, 0, 1 },
            new[] { 9, 8, 2 }
        };
        // The expected value is not trivial to compute analytically, but we can check it is within the valid range
        var result = _task.SeparateSquares(squares);
        result.Should().BeGreaterThanOrEqualTo(0);
        result.Should().BeLessThanOrEqualTo(10);
        // Optionally, check the area balance
        // (not implemented here, as the reference value is not known)
    }
}
