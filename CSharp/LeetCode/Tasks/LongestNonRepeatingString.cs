using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks;

public class LongestNonRepeatingString {
    public int LengthOfLongestSubstring(string s) {
        var h = new HashSet<char>();
        var i = 0;
        var j = 0;
        var t = 0;
        var m = 0;
        while(j < s.Length)
        {
            var c = s[j];
            if(h.Add(c))
            {
                j++;
                t++;
            }
            else
            {
                while(s[i] != c)
                {
                    h.Remove(s[i]);
                    i++;
                    t--;
                }

                i++;
                j++;
            }
            m = Math.Max(m, t);
        }
        return m;
    }
}

[TestFixture]
public class LongestNonRepeatingStringTests
{
    private LongestNonRepeatingString _task = null!;

    [SetUp]
    public void SetUp() => _task = new LongestNonRepeatingString();

    [Test]
    public void LengthOfLongestSubstring_RepeatingCharacters_ReturnsCorrect()
    {
        _task.LengthOfLongestSubstring("abcabcbb").Should().Be(3);
    }

    [Test]
    public void LengthOfLongestSubstring_WithSpecialChars_ReturnsCorrect()
    {
        _task.LengthOfLongestSubstring("aabaab!bb").Should().Be(3);
    }

    [Test]
    public void LengthOfLongestSubstring_AllSame_ReturnsOne()
    {
        _task.LengthOfLongestSubstring("bbbbb").Should().Be(1);
    }

    [Test]
    public void LengthOfLongestSubstring_AllUnique_ReturnsLength()
    {
        _task.LengthOfLongestSubstring("abcde").Should().Be(5);
    }

    [Test]
    public void LengthOfLongestSubstring_EmptyString_ReturnsZero()
    {
        _task.LengthOfLongestSubstring("").Should().Be(0);
    }

    [Test]
    public void LengthOfLongestSubstring_SingleChar_ReturnsOne()
    {
        _task.LengthOfLongestSubstring("a").Should().Be(1);
    }
}
