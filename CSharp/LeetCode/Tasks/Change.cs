using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks;

public class Change
{
    public bool LemonadeChange(int[] bills)
    {
        var b5 = 0;
        var b10 = 0;
        var b20 = 0;
        foreach (var p in bills)
        {
            if (p == 20)
            {
                b20++;
                if (b10 == 0)
                {
                    b5 -= 3;
                }
                else
                {
                    b5--;
                    b10--;
                }
            }
            else if (p == 10)
            {
                b10++;
                b5--;
            }
            else
            {
                b5++;
            }

            if (b5 < 0 || b10 < 0 || b20 < 0)
            {
                return false;
            }
        }

        return true;
    }
}

[TestFixture]
public class ChangeTests
{
    private Change _task = null!;

    [SetUp]
    public void SetUp() => _task = new Change();

    [Test]
    public void LemonadeChange_AllFives_ReturnsTrue()
    {
        _task.LemonadeChange([5, 5, 5, 5]).Should().BeTrue();
    }

    [Test]
    public void LemonadeChange_ValidSequence_ReturnsTrue()
    {
        _task.LemonadeChange([5, 5, 10, 10, 20]).Should().BeTrue();
    }

    [Test]
    public void LemonadeChange_ImpossibleChange_ReturnsFalse()
    {
        _task.LemonadeChange([5, 5, 10, 10, 20, 20]).Should().BeFalse();
    }

    [Test]
    public void LemonadeChange_NoChange_ReturnsFalse()
    {
        _task.LemonadeChange([10]).Should().BeFalse();
    }

    [Test]
    public void LemonadeChange_ComplexSequence_ReturnsCorrect()
    {
        _task.LemonadeChange([5, 5, 5, 10, 20]).Should().BeTrue();
    }
}
