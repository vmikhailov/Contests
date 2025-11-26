using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks2025;

public class MinimumWindowSubstringTaskTests
{
    private MinimumWindowSubstringTask _task = null!;

    [SetUp]
    public void SetUp()
    {
        _task = new MinimumWindowSubstringTask();
    }

    [Test]
    public void MinWindow_Example1_ReturnsBANC()
    {
        // Arrange
        string s = "ADOBECODEBANC";
        string t = "ABC";

        // Act
        var result = _task.MinWindow(s, t);

        // Assert
        result.Should().Be("BANC");
    }

    [Test]
    public void MinWindow_Example2_ReturnsA()
    {
        // Arrange
        string s = "a";
        string t = "a";

        // Act
        var result = _task.MinWindow(s, t);

        // Assert
        result.Should().Be("a");
    }

    [Test]
    public void MinWindow_Example3_ReturnsEmpty()
    {
        // Arrange
        string s = "a";
        string t = "aa";

        // Act
        var result = _task.MinWindow(s, t);

        // Assert
        result.Should().Be("");
    }

    [Test]
    public void MinWindow_EmptyT_ReturnsEmpty()
    {
        // Arrange
        string s = "abc";
        string t = "";

        // Act
        var result = _task.MinWindow(s, t);

        // Assert
        result.Should().Be("");
    }

    [Test]
    public void MinWindow_NoMatch_ReturnsEmpty()
    {
        // Arrange
        string s = "abc";
        string t = "xyz";

        // Act
        var result = _task.MinWindow(s, t);

        // Assert
        result.Should().Be("");
    }

    [Test]
    public void MinWindow_SingleCharMatch_ReturnsChar()
    {
        // Arrange
        string s = "abcdef";
        string t = "c";

        // Act
        var result = _task.MinWindow(s, t);

        // Assert
        result.Should().Be("c");
    }

    [Test]
    public void MinWindow_MultipleOccurrences_ReturnsMinimum()
    {
        // Arrange
        string s = "ABAACBAB";
        string t = "ABC";

        // Act
        var result = _task.MinWindow(s, t);

        // Assert
        result.Should().Be("ACB");
    }

    [Test]
    public void MinWindow_DuplicateCharsInS_ReturnsCorrect()
    {
        // Arrange
        string s = "aaabcbbbccc";
        string t = "abc";

        // Act
        var result = _task.MinWindow(s, t);

        // Assert
        result.Should().Be("abc");
    }

    [Test]
    public void MinWindow_EntireStringIsWindow_ReturnsString()
    {
        // Arrange
        string s = "abc";
        string t = "abc";

        // Act
        var result = _task.MinWindow(s, t);

        // Assert
        result.Should().Be("abc");
    }

    [Test]
    public void MinWindow_WindowAtStart_ReturnsCorrect()
    {
        // Arrange
        string s = "abcdefgh";
        string t = "abc";

        // Act
        var result = _task.MinWindow(s, t);

        // Assert
        result.Should().Be("abc");
    }

    [Test]
    public void MinWindow_WindowAtEnd_ReturnsCorrect()
    {
        // Arrange
        string s = "xyzabc";
        string t = "abc";

        // Act
        var result = _task.MinWindow(s, t);

        // Assert
        result.Should().Be("abc");
    }

    [Test]
    public void MinWindow_RepeatingCharsInT_ReturnsCorrect()
    {
        // Arrange
        string s = "aaaaabc";
        string t = "aa";

        // Act
        var result = _task.MinWindow(s, t);

        // Assert
        result.Should().Be("aa");
    }

    [Test]
    public void MinWindow_LongString_ReturnsCorrect()
    {
        // Arrange
        string s = "ADOBECODEBANCXYZABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string t = "ABC";

        // Act
        var result = _task.MinWindow(s, t);

        // Assert
        result.Should().Be("ABC");
    }

    [Test]
    public void MinWindow_AllSameChar_ReturnsCorrect()
    {
        // Arrange
        string s = "aaaaaaa";
        string t = "aaa";

        // Act
        var result = _task.MinWindow(s, t);

        // Assert
        result.Should().Be("aaa");
    }

    [Test]
    public void MinWindow_TLongerThanS_ReturnsEmpty()
    {
        // Arrange
        string s = "ab";
        string t = "abc";

        // Act
        var result = _task.MinWindow(s, t);

        // Assert
        result.Should().Be("");
    }

    [Test]
    public void MinWindow_CaseSensitive_ReturnsCorrect()
    {
        // Arrange
        string s = "AaBbCc";
        string t = "ABC";

        // Act
        var result = _task.MinWindow(s, t);

        // Assert
        result.Should().Be("AaBbC");
    }

    [Test]
    public void MinWindow_ComplexPattern_ReturnsCorrect()
    {
        // Arrange
        string s = "cabwefgewcwaefgcf";
        string t = "cae";

        // Act
        var result = _task.MinWindow(s, t);

        // Assert
        result.Should().Be("cwae");
    }

    [Test]
    public void MinWindow_MultipleAsWithDuplicatesInT_ReturnsCorrect()
    {
        // Arrange
        string s = "aaaaaaaaaaaabbbbbcdd";
        string t = "abcdd";

        // Act
        var result = _task.MinWindow(s, t);

        // Assert
        result.Should().Be("abbbbbcdd");
    }
}
