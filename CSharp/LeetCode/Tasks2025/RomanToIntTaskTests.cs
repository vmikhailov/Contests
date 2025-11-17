// filepath: c:\Work\Personal\Contests\CSharp\LeetCode\Tasks2025\RomanToIntTaskTests.cs
using NUnit.Framework;
using FluentAssertions;

namespace LeetCode.Tasks2025;

public class RomanToIntTaskTests
{
    private RomanToIntTask _task = null!;

    [SetUp]
    public void SetUp()
    {
        _task = new RomanToIntTask();
    }

    [Test]
    public void RomanToInt_III_Returns3()
    {
        // Arrange
        var s = "III";

        // Act
        var result = _task.RomanToInt(s);

        // Assert
        result.Should().Be(3);
    }

    [Test]
    public void RomanToInt_IV_Returns4()
    {
        var s = "IV";
        var result = _task.RomanToInt(s);
        result.Should().Be(4);
    }

    [Test]
    public void RomanToInt_IX_Returns9()
    {
        var s = "IX";
        var result = _task.RomanToInt(s);
        result.Should().Be(9);
    }

    [Test]
    public void RomanToInt_LVIII_Returns58()
    {
        var s = "LVIII"; // L=50, V=5, III=3
        var result = _task.RomanToInt(s);
        result.Should().Be(58);
    }

    [Test]
    public void RomanToInt_MCMXCIV_Returns1994()
    {
        var s = "MCMXCIV"; // 1000 + (900) + (90) + 4
        var result = _task.RomanToInt(s);
        result.Should().Be(1994);
    }

    [Test]
    public void RomanToInt_CM_Returns900()
    {
        var s = "CM";
        var result = _task.RomanToInt(s);
        result.Should().Be(900);
    }

    [Test]
    public void RomanToInt_XL_Returns40()
    {
        var s = "XL";
        var result = _task.RomanToInt(s);
        result.Should().Be(40);
    }

    [Test]
    public void RomanToInt_I_Returns1()
    {
        var s = "I";
        var result = _task.RomanToInt(s);
        result.Should().Be(1);
    }

    [Test]
    public void RomanToInt_EmptyString_Returns0()
    {
        var s = string.Empty;
        var result = _task.RomanToInt(s);
        result.Should().Be(0);
    }
}

