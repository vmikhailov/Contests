using NUnit.Framework.Legacy;
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
        ClassicAssert.IsTrue(_task.LemonadeChange([5, 5, 5, 5]));
    }

    [Test]
    public void LemonadeChange_ValidSequence_ReturnsTrue()
    {
        ClassicAssert.IsTrue(_task.LemonadeChange([5, 5, 10, 10, 20]));
    }

    [Test]
    public void LemonadeChange_ImpossibleChange_ReturnsFalse()
    {
        ClassicAssert.IsFalse(_task.LemonadeChange([5, 5, 10, 10, 20, 20]));
    }

    [Test]
    public void LemonadeChange_NoChange_ReturnsFalse()
    {
        ClassicAssert.IsFalse(_task.LemonadeChange([10]));
    }

    [Test]
    public void LemonadeChange_ComplexSequence_ReturnsCorrect()
    {
        ClassicAssert.IsTrue(_task.LemonadeChange([5, 5, 5, 10, 20]));
    }
}
