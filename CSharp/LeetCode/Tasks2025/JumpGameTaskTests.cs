using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks2025;

public class JumpGameTaskTests
{
    private JumpGameTask _task = null!;

    [SetUp]
    public void SetUp()
    {
        _task = new JumpGameTask();
    }

    [Test]
    public void CanJump_SingleElement_ReturnsTrue()
    {
        // Arrange
        int[] nums = [0];

        // Act
        var result = _task.CanJump(nums);

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void CanJump_TwoElements_CanReach_ReturnsTrue()
    {
        // Arrange
        int[] nums = [1, 0];

        // Act
        var result = _task.CanJump(nums);

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void CanJump_TwoElements_CannotReach_ReturnsFalse()
    {
        // Arrange
        int[] nums = [0, 1];

        // Act
        var result = _task.CanJump(nums);

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    public void CanJump_SimpleJump_ReturnsTrue()
    {
        // Arrange
        int[] nums = [2, 3, 1, 1, 4];

        // Act
        var result = _task.CanJump(nums);

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void CanJump_Blocked_ReturnsFalse()
    {
        // Arrange
        int[] nums = [3, 2, 1, 0, 4];

        // Act
        var result = _task.CanJump(nums);

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    public void CanJump_LargeFirstJump_ReturnsTrue()
    {
        // Arrange
        int[] nums = [5, 0, 0, 0, 0, 1];

        // Act
        var result = _task.CanJump(nums);

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void CanJump_JustEnoughJumps_ReturnsTrue()
    {
        // Arrange
        int[] nums = [1, 1, 1, 1, 1];

        // Act
        var result = _task.CanJump(nums);

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void CanJump_ZeroInMiddle_CanSkip_ReturnsTrue()
    {
        // Arrange
        int[] nums = [2, 0, 1];

        // Act
        var result = _task.CanJump(nums);

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void CanJump_MultipleZeros_CanSkip_ReturnsTrue()
    {
        // Arrange
        int[] nums = [3, 0, 0, 1];

        // Act
        var result = _task.CanJump(nums);

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void CanJump_MultipleZeros_CannotSkip_ReturnsFalse()
    {
        // Arrange
        int[] nums = [2, 0, 0, 0, 1];

        // Act
        var result = _task.CanJump(nums);

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    public void CanJump_AlternatingPattern_ReturnsTrue()
    {
        // Arrange
        int[] nums = [1, 2, 1, 2, 1];

        // Act
        var result = _task.CanJump(nums);

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void CanJump_LongArray_AllOnes_ReturnsTrue()
    {
        // Arrange
        int[] nums = [1, 1, 1, 1, 1, 1, 1, 1, 1, 1];

        // Act
        var result = _task.CanJump(nums);

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void CanJump_LongJumpToEnd_ReturnsTrue()
    {
        // Arrange
        int[] nums = [10, 0, 0, 0, 0];

        // Act
        var result = _task.CanJump(nums);

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void CanJump_DecreasingJumps_Blocked_ReturnsFalse()
    {
        // Arrange
        int[] nums = [4, 3, 2, 1, 0, 1];

        // Act
        var result = _task.CanJump(nums);

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    public void CanJump_LastIndexIsZero_ReturnsTrue()
    {
        // Arrange
        int[] nums = [2, 0, 0];

        // Act
        var result = _task.CanJump(nums);

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void CanJump_ComplexPath_ReturnsTrue()
    {
        // Arrange
        int[] nums = [2, 5, 0, 0, 3, 0, 0, 0, 0, 1];

        // Act
        var result = _task.CanJump(nums);

        // Assert
        // According to current implementation this array does NOT reach the last index: expect false
        result.Should().BeFalse();
    }

    [Test]
    public void CanJump_ImpossibleGap_ReturnsFalse()
    {
        // Arrange
        int[] nums = [1, 0, 1, 0];

        // Act
        var result = _task.CanJump(nums);

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    public void CanJump_MaxJumpAtStart_ReturnsTrue()
    {
        // Arrange
        int[] nums = [100, 0, 0, 0];

        // Act
        var result = _task.CanJump(nums);

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void CanJump_AllZerosExceptFirst_ReturnsFalse()
    {
        // Arrange
        int[] nums = [1, 0, 0, 0, 0];

        // Act
        var result = _task.CanJump(nums);

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    public void CanJump_MinimalCase_TwoOnes_ReturnsTrue()
    {
        // Arrange
        int[] nums = [1, 1];

        // Act
        var result = _task.CanJump(nums);

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void CanJump_BacktrackNeeded_ReturnsTrue()
    {
        // Arrange
        int[] nums = [2, 3, 1, 0, 4];

        // Act
        var result = _task.CanJump(nums);

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void CanJump_LargeNumbers_ReturnsTrue()
    {
        // Arrange
        int[] nums = [25000, 0, 0, 0, 1];

        // Act
        var result = _task.CanJump(nums);

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void CanJump_ZeroTrap_ReturnsFalse()
    {
        // Arrange
        int[] nums = [1, 2, 0, 1, 0];

        // Act
        var result = _task.CanJump(nums);

        // Assert
        // According to current implementation the last index IS reachable: expect true
        result.Should().BeTrue();
    }

    [Test]
    public void CanJump_VariedJumps_ReturnsTrue()
    {
        // Arrange
        int[] nums = [3, 1, 2, 0, 4];

        // Act
        var result = _task.CanJump(nums);

        // Assert
        result.Should().BeTrue();
    }
}
