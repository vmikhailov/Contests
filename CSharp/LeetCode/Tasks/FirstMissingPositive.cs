using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks;

public class FirstMissingPositive
{
    public int Compute(int[] nums)
    {
        var n = nums.Length;
        var i = 0;
        var v = nums[0];
        while (true)
        {
            if (v > n || v <= 0)
            {
                nums[i] = 0;
                v = i + 1;
            }
            
            var j = v - 1;
            if (i == j)
            {
                if (++i == n)
                {
                    break;
                }

                v = nums[i];
                continue;
            }
           
            var f = nums[j];
            if (v == f)
            {
                nums[i] = 0;
                if (++i == n)
                {
                    break;
                }

                v = nums[i];
            }
            else
            {
                nums[j] = v;
                v = f;
            }
        }

        for (i = 0; i < n; i++)
        {
            if (nums[i] == 0)
            {
                return i + 1;
            }
        }

        return n + 1;
    }
}

[TestFixture]
public class FirstMissingPositiveTests
{
    private FirstMissingPositive _task = null!;

    [SetUp]
    public void SetUp() => _task = new FirstMissingPositive();

    [Test]
    public void Compute_BasicCase_ReturnsFirstMissing()
    {
        _task.Compute([1, 2, 0]).Should().Be(3);
    }

    [Test]
    public void Compute_ConsecutiveNumbers_ReturnsNextNumber()
    {
        _task.Compute([3, 4, -1, 1]).Should().Be(2);
    }

    [Test]
    public void Compute_AllPositive_ReturnsNextNumber()
    {
        _task.Compute([1, 2]).Should().Be(3);
    }

    [Test]
    public void Compute_SingleElement_ReturnsCorrect()
    {
        _task.Compute([1]).Should().Be(2);
        _task.Compute([2]).Should().Be(1);
    }

    [Test]
    public void Compute_AllNegative_ReturnsOne()
    {
        _task.Compute([-1, -2, -3]).Should().Be(1);
    }

    [Test]
    public void Compute_WithDuplicates_ReturnsCorrect()
    {
        _task.Compute([1, 1, 2, 2]).Should().Be(3);
    }
}
