using NUnit.Framework;
using FluentAssertions;

namespace LeetCode.Tasks2025;

public class CountOfDigitOneTaskTests
{
    private CountOfDigitOneTask _task = null!;

    [SetUp]
    public void SetUp()
    {
        _task = new CountOfDigitOneTask();
    }

    [Test]
    public void CountDigitOne_Zero_ReturnsZero()
    {
        // Arrange & Act
        var result = _task.CountDigitOne(0);

        // Assert
        result.Should().Be(0);
    }

    [Test]
    public void CountDigitOne_One_ReturnsOne()
    {
        // Arrange & Act
        var result = _task.CountDigitOne(1);

        // Assert
        result.Should().Be(1);
    }

    [Test]
    public void CountDigitOne_Thirteen_ReturnsCorrectCount()
    {
        // Arrange & Act
        var result = _task.CountDigitOne(13);

        // Assert
        // Numbers with 1: 1, 10, 11 (has two 1s), 12, 13
        // Total count: 1 + 1 + 2 + 1 + 1 = 6
        result.Should().Be(6);
    }

    [Test]
    public void CountDigitOne_Ten_ReturnsTwo()
    {
        // Arrange & Act
        var result = _task.CountDigitOne(10);

        // Assert
        // Numbers with 1: 1, 10
        // Total count: 1 + 1 = 2
        result.Should().Be(2);
    }

    [Test]
    public void CountDigitOne_Twenty_ReturnsCorrectCount()
    {
        // Arrange & Act
        var result = _task.CountDigitOne(20);

        // Assert
        // Numbers with 1: 1, 10, 11 (has two 1s), 12, 13, 14, 15, 16, 17, 18, 19
        // Total count: 1 + 1 + 2 + 1 + 1 + 1 + 1 + 1 + 1 + 1 + 1 = 12
        result.Should().Be(12);
    }

    [Test]
    public void CountDigitOne_Hundred_ReturnsCorrectCount()
    {
        // Arrange & Act
        var result = _task.CountDigitOne(100);

        // Assert
        // 1-9: 1 occurrence (just "1")
        // 10-19: 11 occurrences (10, 11 has two, 12-19)
        // 20-99: 8 occurrences (21, 31, 41, 51, 61, 71, 81, 91)
        // 100: 1 occurrence
        // Total: 1 + 11 + 8 = 20, plus 100 = 21
        result.Should().Be(21);
    }

    [Test]
    public void CountDigitOne_NinetyNine_ReturnsCorrectCount()
    {
        // Arrange & Act
        var result = _task.CountDigitOne(99);

        // Assert
        // 1-9: 1 occurrence (just "1")
        // 10-19: 11 occurrences
        // 20-99: 8 occurrences (21, 31, 41, 51, 61, 71, 81, 91)
        // Total: 1 + 11 + 8 = 20
        result.Should().Be(20);
    }

    [Test]
    public void CountDigitOne_NumberWithMultipleOnesLike111_ReturnsCorrectCount()
    {
        // Arrange & Act
        var result = _task.CountDigitOne(111);

        // Assert
        // This should count all occurrences of digit 1 in all numbers from 1 to 111
        result.Should().Be(36);
    }

    [Test]
    public void CountDigitOne_Five_ReturnsOne()
    {
        // Arrange & Act
        var result = _task.CountDigitOne(5);

        // Assert
        // Only number with 1: 1
        result.Should().Be(1);
    }

    [Test]
    public void CountDigitOne_SingleDigitRangeNine_ReturnsOne()
    {
        // Arrange & Act
        var result = _task.CountDigitOne(9);

        // Assert
        // Only number with 1: 1
        result.Should().Be(1);
    }

    [TestCase(5555)]
    [TestCase(100000)]
    [TestCase(100_000_000)]
    public void CountDigitOne_CountBig(int n)
    {
        var result = _task.CountDigitOne(n);

        result.Should().BeGreaterOrEqualTo(1);
    }
}

