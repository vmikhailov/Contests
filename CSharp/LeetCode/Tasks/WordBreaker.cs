using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks;

public class WordBreaker
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        if(!wordDict.All(x => s.Contains(x)))
        {
            return false;
        }

        var st = wordDict.ToHashSet();

        var q = new Stack<string>();
        return Parse(0);

        bool Parse(int i)
        {
            if (i == s.Length)
            {
                return true;
            }

            for (var j = i + 1; j <= s.Length; j++)
            {
                var w = s[i..j];
                if (st.Contains(w))
                {
                    q.Push(w);
                    if(Parse(j))
                    {
                        return true;
                    }

                    q.Pop();
                }
            }
            return false;
        }
    }
}

[TestFixture]
public class WordBreakerTests
{
    private WordBreaker _task = null!;

    [SetUp]
    public void SetUp() => _task = new WordBreaker();

    [Test]
    public void WordBreak_ValidBreak_ReturnsTrue()
    {
        _task.WordBreak("leetcode", new List<string> { "leet", "code" }).Should().BeTrue();
    }

    [Test]
    public void WordBreak_MultipleBreaks_ReturnsTrue()
    {
        _task.WordBreak("applepenapple", new List<string> { "apple", "pen" }).Should().BeTrue();
    }

    [Test]
    public void WordBreak_InvalidBreak_ReturnsFalse()
    {
        _task.WordBreak("catsandog", new List<string> { "cats", "dog", "sand", "and", "cat" }).Should().BeFalse();
    }

    [Test]
    public void WordBreak_EmptyString_ReturnsTrue()
    {
        _task.WordBreak("", new List<string> { "a" }).Should().BeTrue();
    }

    [Test]
    public void WordBreak_SingleWord_ReturnsTrue()
    {
        _task.WordBreak("a", new List<string> { "a" }).Should().BeTrue();
    }
}

