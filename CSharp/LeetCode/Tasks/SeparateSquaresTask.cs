using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks;

public class SeparateSquaresTask
{
    public double SeparateSquares(int[][] squares) {

        var sq = squares.OrderBy(x => x[1]).ToList();
        var yy = sq.Select(x => x[1]).ToList();
        var left = (double)sq[0][1];
        var right = (double)sq[^1][1];

        while(true)
        {

        }

        (int, int) Calculate()
        {
            var m = (left + right) / 2;

            var p1 = yy.BinarySearch((int)m);
            if(p1 < 0)
            {
                p1 = ~p1;
            }
            else
            {
                while(p1 > 0 && yy[p1 - 1] == (int)m)
                {
                    p1--;
                }
            }


            var p2 = yy.BinarySearch((int)m + 1);

            return (0, 0);
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
    public void SeparateSquares_EmptyInput_ReturnsDefault()
    {
        // The method is incomplete, so we expect default value (0)
        _task.SeparateSquares([]).Should().Be(0);
    }

    [Test]
    public void SeparateSquares_SingleSquare_ReturnsY()
    {
        // Expect the y of the single square (if logic is median)
        var squares = new[] { new[] { 0, 5 } };
        _task.SeparateSquares(squares).Should().Be(5);
    }

    [Test]
    public void SeparateSquares_TwoSquares_ReturnsMiddleY()
    {
        var squares = new[] { new[] { 0, 2 }, new[] { 0, 8 } };
        // If logic is median, expect 5
        _task.SeparateSquares(squares).Should().Be(5);
    }

    [Test]
    public void SeparateSquares_MultipleSquares_SameY_ReturnsY()
    {
        var squares = new[] { new[] { 0, 3 }, new[] { 1, 3 }, new[] { 2, 3 } };
        _task.SeparateSquares(squares).Should().Be(3);
    }

    [Test]
    public void SeparateSquares_MultipleSquares_DifferentY_ReturnsMedian()
    {
        var squares = new[] { new[] { 0, 1 }, new[] { 0, 3 }, new[] { 0, 5 }, new[] { 0, 7 } };
        // Median of [1,3,5,7] is (3+5)/2 = 4
        _task.SeparateSquares(squares).Should().Be(4);
    }
}
