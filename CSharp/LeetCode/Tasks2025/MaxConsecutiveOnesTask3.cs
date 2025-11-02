using NUnit.Framework;
using FluentAssertions;

namespace LeetCode.Tasks2025;

public class MaxConsecutiveOnesTask3
{
    // Given a binary array nums and an integer k, return the maximum number of consecutive 1's
    // in the array if you can flip at most k 0's.
    public int LongestOnes(int[] nums, int k)
    {
        var i = 0;
        var j = 0;
        var z = 0;
        var m = 0;
        while(j < nums.Length)
        {
            if(nums[j] == 0)
            {
                if(z == k)
                {
                    m = Math.Max(m, j - i);
                    while(i < j && nums[i] == 1) i++;
                    i++;
                    z--;
                }
                z++;
            }
            j++;
        }

        m = Math.Max(m, j - i);
        return m;
    }
}

[TestFixture]
public class MaxConsecutiveOnesTask3Tests
{
    private MaxConsecutiveOnesTask3 _task = null!;

    [SetUp]
    public void SetUp() => _task = new MaxConsecutiveOnesTask3();

    [Test]
    public void LongestOnes_Example1_Returns6()
    {
        // Arrange
        var nums = new[] { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 };
        var k = 2;

        // Act
        var result = _task.LongestOnes(nums, k);

        // Assert
        result.Should().Be(6);
        // Explanation: [1,1,1,0,0,1,1,1,1,1,1]
        // Flipped the two zeros at indices 4 and 5
    }

    [Test]
    public void LongestOnes_Example2_Returns10()
    {
        // Arrange
        var nums = new[] { 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1 };
        var k = 3;

        // Act
        var result = _task.LongestOnes(nums, k);

        // Assert
        result.Should().Be(10);
        // Explanation: [0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,1,1,1,1]
        // Flipped the three zeros at indices 4, 5, and 9
    }

    [Test]
    public void LongestOnes_AllOnes_ReturnsArrayLength()
    {
        // Arrange
        var nums = new[] { 1, 1, 1, 1, 1 };
        var k = 2;

        // Act
        var result = _task.LongestOnes(nums, k);

        // Assert
        result.Should().Be(5);
    }

    [Test]
    public void LongestOnes_AllZeros_ReturnsK()
    {
        // Arrange
        var nums = new[] { 0, 0, 0, 0, 0 };
        var k = 2;

        // Act
        var result = _task.LongestOnes(nums, k);

        // Assert
        result.Should().Be(2);
    }

    [Test]
    public void LongestOnes_KIsZero_ReturnsLongestConsecutiveOnes()
    {
        // Arrange
        var nums = new[] { 1, 1, 0, 0, 1, 1, 1, 0, 1 };
        var k = 0;

        // Act
        var result = _task.LongestOnes(nums, k);

        // Assert
        result.Should().Be(3);
        // Explanation: Cannot flip any zeros, longest sequence is 1,1,1
    }

    [Test]
    public void LongestOnes_SingleElement_One_Returns1()
    {
        // Arrange
        var nums = new[] { 1 };
        var k = 0;

        // Act
        var result = _task.LongestOnes(nums, k);

        // Assert
        result.Should().Be(1);
    }

    [Test]
    public void LongestOnes_SingleElement_Zero_WithK1_Returns1()
    {
        // Arrange
        var nums = new[] { 0 };
        var k = 1;

        // Act
        var result = _task.LongestOnes(nums, k);

        // Assert
        result.Should().Be(1);
    }

    [Test]
    public void LongestOnes_SingleElement_Zero_WithK0_Returns0()
    {
        // Arrange
        var nums = new[] { 0 };
        var k = 0;

        // Act
        var result = _task.LongestOnes(nums, k);

        // Assert
        result.Should().Be(0);
    }

    [Test]
    public void LongestOnes_KLargerThanZerosCount_ReturnsArrayLength()
    {
        // Arrange
        var nums = new[] { 1, 0, 1, 0, 1 };
        var k = 5;

        // Act
        var result = _task.LongestOnes(nums, k);

        // Assert
        result.Should().Be(5);
        // Explanation: Can flip all zeros since k is large enough
    }

    [Test]
    public void LongestOnes_AlternatingPattern_Returns5()
    {
        // Arrange
        var nums = new[] { 0, 1, 0, 1, 0, 1, 0 };
        var k = 2;

        // Act
        var result = _task.LongestOnes(nums, k);

        // Assert
        result.Should().Be(5);
        // Explanation: Can flip two zeros to get sequence of 5
    }

    [Test]
    public void LongestOnes_ZerosAtEnd_Returns7()
    {
        // Arrange
        var nums = new[] { 1, 1, 1, 1, 0, 0, 0 };
        var k = 2;

        // Act
        var result = _task.LongestOnes(nums, k);

        // Assert
        result.Should().Be(6);
        // Explanation: Flip the two zeros at indices 4 and 5
    }

    [Test]
    public void LongestOnes_ZerosAtStart_Returns6()
    {
        // Arrange
        var nums = new[] { 0, 0, 0, 1, 1, 1, 1 };
        var k = 2;

        // Act
        var result = _task.LongestOnes(nums, k);

        // Assert
        result.Should().Be(6);
        // Explanation: Flip the two zeros at indices 1 and 2
    }

    [Test]
    public void LongestOnes_ManualTrace_Example1()
    {
        // This test traces through the first example manually
        // nums = [1,1,1,0,0,0,1,1,1,1,0], k = 2
        // Expected: 6
        // The optimal window should be indices 5-10: [0,1,1,1,1,0] = 6 elements with 2 zeros
        var nums = new[] { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 };
        var k = 2;

        var result = _task.LongestOnes(nums, k);

        result.Should().Be(6);
    }

    [Test]
    public void LongestOnes_EndWithOnes_Returns8()
    {
        // nums = [0,0,1,1,1,1,1,1], k = 2
        // Expected: 8 (flip both zeros at start)
        var nums = new[] { 0, 0, 1, 1, 1, 1, 1, 1 };
        var k = 2;

        var result = _task.LongestOnes(nums, k);

        result.Should().Be(8);
    }

    [Test]
    public void LongestOnes_StartWithZeroEndWithOne_Returns5()
    {
        // nums = [0,1,1,1,1], k = 1
        // Expected: 5 (flip the zero at index 0)
        var nums = new[] { 0, 1, 1, 1, 1 };
        var k = 1;

        var result = _task.LongestOnes(nums, k);

        result.Should().Be(5);
    }
}
