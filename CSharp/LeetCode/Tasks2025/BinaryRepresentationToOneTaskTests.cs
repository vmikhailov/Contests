using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks2025;

public class BinaryRepresentationToOneTaskTests
{
    private BinaryRepresentationToOneTask _task = null!;

    [SetUp]
    public void SetUp()
    {
        _task = new BinaryRepresentationToOneTask();
    }

    [Test]
    public void NumSteps_SingleOne_ReturnsZero()
    {
        // Arrange
        string s = "1";

        // Act
        var result = _task.NumSteps(s);

        // Assert
        result.Should().Be(0);
    }

    [Test]
    public void NumSteps_Example1_Returns6()
    {
        // Arrange
        string s = "1101";

        // Act
        var result = _task.NumSteps(s);

        // Assert
        result.Should().Be(6);
    }

    [Test]
    public void NumSteps_Example2_Returns1()
    {
        // Arrange
        string s = "10";

        // Act
        var result = _task.NumSteps(s);

        // Assert
        result.Should().Be(1);
    }

    [Test]
    public void NumSteps_Example3_Returns4()
    {
        // Arrange
        string s = "1111";

        // Act
        var result = _task.NumSteps(s);

        // Assert
        result.Should().Be(5);
    }

    [Test]
    public void NumSteps_PowerOfTwo_ReturnsCorrectSteps()
    {
        // Arrange
        string s = "1000"; // 8 in binary

        // Act
        var result = _task.NumSteps(s);

        // Assert
        result.Should().Be(3);
    }

    [Test]
    public void NumSteps_LargeNumber_ReturnsCorrectSteps()
    {
        // Arrange
        string s = "1111011110000011100000111001110111";

        // Act
        var result = _task.NumSteps(s);

        // Assert
        result.Should().Be(49);
    }

    [Test]
    public void NumSteps_AlternatingBits_ReturnsCorrectSteps()
    {
        // Arrange
        string s = "10101"; // 21 in binary

        // Act
        var result = _task.NumSteps(s);

        // Assert
        result.Should().Be(8);
    }
}

