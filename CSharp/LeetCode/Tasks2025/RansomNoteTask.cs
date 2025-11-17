using NUnit.Framework;

namespace LeetCode.Tasks2025;

public class RansomNoteTask
{
    public bool CanConstruct(string ransomNote, string magazine)
    {
        var f1 = ransomNote.ToLookup(x => x).ToDictionary(x => x.Key, x => x.Count());
        var f2 = magazine.ToLookup(x => x).ToDictionary(x => x.Key, x => x.Count());

        foreach(var (k,v) in f1)
        {
            if (!f2.TryGetValue(k, out var v2) || v2 < v)
            {
                return false;
            }
        }

        Queue<int> q = new Queue<int>();

        return true;
    }
}

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
