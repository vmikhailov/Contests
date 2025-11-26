using NUnit.Framework;

namespace LeetCode.Tasks2025;

[TestFixture]
public class RansomNoteTaskTests
{
    private RansomNoteTask _task;

    [SetUp]
    public void SetUp()
    {
        _task = new RansomNoteTask();
    }

    [Test]
    public void CanConstruct_WithSufficientLetters_ReturnsTrue()
    {
        var result = _task.CanConstruct("aa", "aab");
        Assert.That(result, Is.True);
    }

    [Test]
    public void CanConstruct_WithInsufficientLetters_ReturnsFalse()
    {
        var result = _task.CanConstruct("aa", "ab");
        Assert.That(result, Is.False);
    }

    [Test]
    public void CanConstruct_WithMissingLetter_ReturnsFalse()
    {
        var result = _task.CanConstruct("a", "b");
        Assert.That(result, Is.False);
    }

    [Test]
    public void CanConstruct_WithExactMatch_ReturnsTrue()
    {
        var result = _task.CanConstruct("abc", "abc");
        Assert.That(result, Is.True);
    }

    [Test]
    public void CanConstruct_WithEmptyRansomNote_ReturnsTrue()
    {
        var result = _task.CanConstruct("", "abc");
        Assert.That(result, Is.True);
    }

    [Test]
    public void CanConstruct_WithMultipleOccurrences_ReturnsTrue()
    {
        var result = _task.CanConstruct("aab", "baa");
        Assert.That(result, Is.True);
    }

    [Test]
    public void CanConstruct_WithComplexString_ReturnsTrue()
    {
        var result = _task.CanConstruct("ransom", "randomnotes");
        Assert.That(result, Is.True);
    }
}
