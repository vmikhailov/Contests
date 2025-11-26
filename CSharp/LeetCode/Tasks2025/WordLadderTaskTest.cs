using NUnit.Framework;
using FluentAssertions;

namespace LeetCode.Tasks2025;

public class WordLadderTaskTest
{
    [Test]
    public void Test_Example1()
    {
        var task = new WordLadderTask();
        var beginWord = "hit";
        var endWord = "cog";
        var wordList = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" };

        var result = task.LadderLength(beginWord, endWord, wordList);

        result.Should().Be(5, "Shortest path: hit -> hot -> dot -> dog -> cog");
    }

    [Test]
    public void Test_Example2()
    {
        var task = new WordLadderTask();
        var beginWord = "hit";
        var endWord = "cog";
        var wordList = new List<string> { "hot", "dot", "dog", "lot", "log" };

        var result = task.LadderLength(beginWord, endWord, wordList);

        result.Should().Be(0, "endWord is not in wordList, no transformation possible");
    }

    [Test]
    public void Test_SingleStep()
    {
        var task = new WordLadderTask();
        var beginWord = "hit";
        var endWord = "hot";
        var wordList = new List<string> { "hot" };

        var result = task.LadderLength(beginWord, endWord, wordList);

        result.Should().Be(2, "Direct transformation: hit -> hot");
    }

    [Test]
    public void Test_NoPath()
    {
        var task = new WordLadderTask();
        var beginWord = "hit";
        var endWord = "cog";
        var wordList = new List<string> { "hot", "dot", "dog" };

        var result = task.LadderLength(beginWord, endWord, wordList);

        result.Should().Be(0, "No path exists from hit to cog");
    }

    [Test]
    public void Test_TwoSteps()
    {
        var task = new WordLadderTask();
        var beginWord = "hot";
        var endWord = "dog";
        var wordList = new List<string> { "hot", "dog", "dot" };

        var result = task.LadderLength(beginWord, endWord, wordList);

        result.Should().Be(3, "Two-step path: hot -> dot -> dog");
    }

    [Test]
    public void Test_BeginWordEqualsEndWord()
    {
        var task = new WordLadderTask();
        var beginWord = "hot";
        var endWord = "hot";
        var wordList = new List<string> { "hot", "dot", "dog" };

        var result = task.LadderLength(beginWord, endWord, wordList);

        result.Should().Be(1, "Begin word equals end word");
    }

    [Test]
    public void Test_LongerPath()
    {
        var task = new WordLadderTask();
        var beginWord = "a";
        var endWord = "c";
        var wordList = new List<string> { "a", "b", "c" };

        var result = task.LadderLength(beginWord, endWord, wordList);

        result.Should().Be(2, "Path: a -> c");
    }

    [Test]
    public void Test_MultiplePathsSameLength()
    {
        var task = new WordLadderTask();
        var beginWord = "red";
        var endWord = "tax";
        var wordList = new List<string> { "ted", "tex", "red", "tax", "tad", "den", "rex", "pee" };

        var result = task.LadderLength(beginWord, endWord, wordList);

        result.Should().Be(4, "Shortest path: red -> ted -> tex -> tax or red -> rex -> tex -> tax");
    }

    [Test]
    public void Test_EmptyWordList()
    {
        var task = new WordLadderTask();
        var beginWord = "hit";
        var endWord = "cog";
        var wordList = new List<string>();

        var result = task.LadderLength(beginWord, endWord, wordList);

        result.Should().Be(0, "Empty word list means no path");
    }

    [Test]
    public void Test_LongWords()
    {
        var task = new WordLadderTask();
        var beginWord = "teach";
        var endWord = "place";
        var wordList = new List<string> { "teach", "peach", "peace", "place", "plage" };

        var result = task.LadderLength(beginWord, endWord, wordList);

        result.Should().BeGreaterThan(0, "Should find a path through teach -> peach -> peace -> place");
    }

    [Test]
    public void Test_BeginWordNotInList()
    {
        var task = new WordLadderTask();
        var beginWord = "hit";
        var endWord = "hot";
        var wordList = new List<string> { "hot", "dot", "dog" };

        var result = task.LadderLength(beginWord, endWord, wordList);

        result.Should().Be(2, "beginWord doesn't need to be in wordList");
    }

    [Test]
    public void Test_ThreeLetterWords()
    {
        var task = new WordLadderTask();
        var beginWord = "hot";
        var endWord = "dog";
        var wordList = new List<string> { "hot", "dog", "cog", "pot", "dot" };

        var result = task.LadderLength(beginWord, endWord, wordList);

        result.Should().BeGreaterThan(0, "Should find path from hot to dog");
    }

    [Test]
    public void Test_LargeWordList()
    {
        var task = new WordLadderTask();
        var beginWord = "qa";
        var endWord = "sq";
        var wordList = new List<string>
        {
            "si", "go", "se", "cm", "so", "ph", "mt", "db", "mb", "sb", "kr", "ln", "tm", "le", "av", "sm",
            "ar", "ci", "ca", "br", "ti", "ba", "to", "ra", "fa", "yo", "ow", "sn", "ya", "cr", "po", "fe",
            "ho", "ma", "re", "or", "rn", "au", "ur", "rh", "sr", "tc", "lt", "lo", "as", "fr", "nb", "yb",
            "if", "pb", "ge", "th", "pm", "rb", "sh", "co", "ga", "li", "ha", "hz", "no", "bi", "di", "hi",
            "qa", "pi", "os", "uh", "wm", "an", "me", "mo", "na", "la", "st", "er", "sc", "ne", "mn", "mi",
            "am", "ex", "pt", "io", "be", "fm", "ta", "tb", "ni", "mr", "pa", "he", "lr", "sq", "ye"
        };

        var result = task.LadderLength(beginWord, endWord, wordList);

        result.Should().BeGreaterThan(0, "Should find path from qa to sq in large word list");
    }
}

