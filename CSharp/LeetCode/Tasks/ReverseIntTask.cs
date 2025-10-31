using NUnit.Framework.Legacy;
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
        ClassicAssert.AreEqual(321, _task.Reverse(123));
    }

    [Test]
    public void Reverse_Overflow_ReturnsZero()
    {
        ClassicAssert.AreEqual(0, _task.Reverse(1534236469));
    }

    [Test]
    public void Reverse_NegativeNumber_ReturnsReversed()
    {
        ClassicAssert.AreEqual(-321, _task.Reverse(-123));
    }

    [Test]
    public void Reverse_Zero_ReturnsZero()
    {
        ClassicAssert.AreEqual(0, _task.Reverse(0));
    }

    [Test]
    public void Reverse_TrailingZeros_ReturnsCorrect()
    {
        ClassicAssert.AreEqual(21, _task.Reverse(120));
    }
}
