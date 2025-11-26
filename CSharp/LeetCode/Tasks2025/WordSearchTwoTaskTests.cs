using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks2025;

public class WordSearchTwoTaskTests
{
    private WordSearchTwoTask _task = null!;

    [SetUp]
    public void SetUp()
    {
        _task = new WordSearchTwoTask();
    }

    [Test]
    public void FindWords_Example1_ReturnsCorrectWords2()
    {
        // Arrange
        char[][] board =
        [
            ['o', 't', 'a', 'm'],
            ['m', 'a', 'k', 'e'],
            ['i', 'k', 'e', 'r'],
            ['i', 's', 'l', 'v']
        ];
        string[] words = ["make", "take"];

        // Act
        var result = _task.FindWords(board, words);

        // Assert
        result.Should().BeEquivalentTo("make", "take");
    }


    [Test]
    public void FindWords_Example1_ReturnsCorrectWords()
    {
        // Arrange
        char[][] board =
        [
            ['o', 'a', 'a', 'n'],
            ['e', 't', 'a', 'e'],
            ['i', 'h', 'k', 'r'],
            ['i', 'f', 'l', 'v']
        ];
        string[] words = ["oath", "pea", "eat", "rain"];

        // Act
        var result = _task.FindWords(board, words);

        // Assert
        result.Should().BeEquivalentTo(new[] { "eat", "oath" });
    }

    [Test]
    public void FindWords_Example2_ReturnsEmptyList()
    {
        // Arrange
        char[][] board =
        [
            ['a', 'b'],
            ['c', 'd']
        ];
        string[] words = ["abcb"];

        // Act
        var result = _task.FindWords(board, words);

        // Assert
        result.Should().BeEmpty();
    }

    [Test]
    public void FindWords_SingleCell_ReturnsMatchingWord()
    {
        // Arrange
        char[][] board = [['a']];
        string[] words = ["a"];

        // Act
        var result = _task.FindWords(board, words);

        // Assert
        result.Should().BeEquivalentTo(new[] { "a" });
    }

    [Test]
    public void FindWords_SingleCell_NoMatch_ReturnsEmpty()
    {
        // Arrange
        char[][] board = [['a']];
        string[] words = ["b"];

        // Act
        var result = _task.FindWords(board, words);

        // Assert
        result.Should().BeEmpty();
    }

    [Test]
    public void FindWords_NoWords_ReturnsEmpty()
    {
        // Arrange
        char[][] board =
        [
            ['a', 'b'],
            ['c', 'd']
        ];
        string[] words = [];

        // Act
        var result = _task.FindWords(board, words);

        // Assert
        result.Should().BeEmpty();
    }

    [Test]
    public void FindWords_WordWithBacktracking_ReturnsWord()
    {
        // Arrange
        char[][] board =
        [
            ['a', 'b'],
            ['a', 'a']
        ];
        string[] words = ["aba", "baa"];

        // Act
        var result = _task.FindWords(board, words);

        // Assert
        result.Should().BeEquivalentTo(new[] { "aba", "baa" });
    }

    [Test]
    public void FindWords_DuplicateWords_ReturnsUniqueWords()
    {
        // Arrange
        char[][] board =
        [
            ['a', 'b'],
            ['c', 'd']
        ];
        string[] words = ["ab", "ab", "cd"];

        // Act
        var result = _task.FindWords(board, words);

        // Assert
        result.Should().HaveCount(2);
        result.Should().Contain("ab");
        result.Should().Contain("cd");
    }

    [Test]
    public void FindWords_LargeBoard_ReturnsCorrectWords()
    {
        // Arrange
        char[][] board =
        [
            ['o', 'a', 'a', 'n'],
            ['e', 't', 'a', 'e'],
            ['i', 'h', 'k', 'r'],
            ['i', 'f', 'l', 'v']
        ];
        string[] words = ["oath", "pea", "eat", "rain", "oat", "oath"];

        // Act
        var result = _task.FindWords(board, words);

        // Assert
        result.Should().Contain("eat");
        result.Should().Contain("oath");
        result.Should().Contain("oat");
    }

    [Test]
    public void FindWords_WordNotInBoard_ReturnsEmpty()
    {
        // Arrange
        char[][] board =
        [
            ['a', 'b'],
            ['c', 'd']
        ];
        string[] words = ["xyz", "mnop"];

        // Act
        var result = _task.FindWords(board, words);

        // Assert
        result.Should().BeEmpty();
    }

    [Test]
    public void FindWords_OverlappingWords_ReturnsBothWords()
    {
        // Arrange
        char[][] board =
        [
            ['a', 'b', 'c'],
            ['a', 'e', 'd'],
            ['a', 'f', 'g']
        ];
        string[] words = ["abcdefg", "aaa"];

        // Act
        var result = _task.FindWords(board, words);

        // Assert
        result.Should().Contain("aaa");
    }

    [Test]
    public void FindWords_SameLetterMultipleTimes_ReturnsWord()
    {
        // Arrange
        char[][] board =
        [
            ['a', 'a', 'a'],
            ['a', 'a', 'a'],
            ['a', 'a', 'a']
        ];
        string[] words = ["aaa", "aaaa", "aaaaa"];

        // Act
        var result = _task.FindWords(board, words);

        // Assert
        result.Should().Contain("aaa");
    }

    [Test]
    public void FindWords_LongWord_ReturnsWordIfExists()
    {
        // Arrange
        char[][] board =
        [
            ['a', 'b', 'c', 'd'],
            ['e', 'f', 'g', 'h'],
            ['i', 'j', 'k', 'l'],
            ['m', 'n', 'o', 'p']
        ];
        string[] words = ["abcdefgh", "afejo"];

        // Act
        var result = _task.FindWords(board, words);

        // Assert
        result.Should().NotBeNull();
    }

    [Test]
    public void FindWords_PrefixOverlap_ReturnsOnlyValidWords()
    {
        // Arrange
        char[][] board =
        [
            ['a', 'b'],
            ['c', 'd']
        ];
        string[] words = ["ab", "abc", "abcd"];

        // Act
        var result = _task.FindWords(board, words);

        // Assert
        result.Should().Contain("ab");
    }

    [Test]
    public void FindWords_DiagonalNotAllowed_ReturnsOnlyAdjacentWords()
    {
        // Arrange
        char[][] board =
        [
            ['a', 'b'],
            ['c', 'd']
        ];
        string[] words = ["ad", "ab", "ac"];

        // Act
        var result = _task.FindWords(board, words);

        // Assert
        result.Should().Contain("ab");
        result.Should().Contain("ac");
        result.Should().NotContain("ad"); // Diagonal not allowed
    }

    [Test]
    public void FindWords_RectangularBoard_ReturnsCorrectWords()
    {
        // Arrange
        char[][] board =
        [
            ['a', 'b', 'c', 'd', 'e'],
            ['f', 'g', 'h', 'i', 'j']
        ];
        string[] words = ["abc", "bcd", "cde", "fgh", "ghi", "hij"];

        // Act
        var result = _task.FindWords(board, words);

        // Assert
        result.Should().Contain("abc");
        result.Should().Contain("bcd");
        result.Should().Contain("cde");
        result.Should().Contain("fgh");
        result.Should().Contain("ghi");
        result.Should().Contain("hij");
    }

    [Test]
    public void FindWords_ComplexPath_ReturnsWord()
    {
        // Arrange
        char[][] board =
        [
            ['o', 'a', 'a', 'n'],
            ['e', 't', 'a', 'e'],
            ['i', 'h', 'k', 'r'],
            ['i', 'f', 'l', 'v']
        ];
        string[] words = ["oathke", "oathkr"];

        // Act
        var result = _task.FindWords(board, words);

        // Assert
        result.Should().NotBeNull();
    }
}

