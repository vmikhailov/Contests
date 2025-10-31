using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks;

public class ReverseIntTask
{
    public int Reverse(int x)
    {
        var y = 0;
        while (x != 0)
        {
            var d = x % 10;

            if (x > 0 && y > (int.MaxValue - d) / 10)
            {
                return 0;
            }

            x /= 10;
            y = y * 10 + d;
        }

        return y;
    }
}

[TestFixture]
public class ReverseIntTaskTests
{
    private ReverseIntTask _task = null!;

    [SetUp]
    public void SetUp() => _task = new ReverseIntTask();

    [Test]
    public void Reverse_PositiveNumber_ReturnsReversed()
    {
        _task.Reverse(123).Should().Be(321);
    }

    [Test]
    public void Reverse_Overflow_ReturnsZero()
    {
        _task.Reverse(1534236469).Should().Be(0);
    }

    [Test]
    public void Reverse_NegativeNumber_ReturnsReversed()
    {
        _task.Reverse(-123).Should().Be(-321);
    }

    [Test]
    public void Reverse_Zero_ReturnsZero()
    {
        _task.Reverse(0).Should().Be(0);
    }

    [Test]
    public void Reverse_TrailingZeros_ReturnsCorrect()
    {
        _task.Reverse(120).Should().Be(21);
    }
}
