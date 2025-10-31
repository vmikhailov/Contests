using NUnit.Framework.Legacy;
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
        ClassicAssert.AreEqual(3, _task.LengthOfLongestSubstring("abcabcbb"));
    }

    [Test]
    public void LengthOfLongestSubstring_WithSpecialChars_ReturnsCorrect()
    {
        ClassicAssert.AreEqual(3, _task.LengthOfLongestSubstring("aabaab!bb"));
    }

    [Test]
    public void LengthOfLongestSubstring_AllSame_ReturnsOne()
    {
        ClassicAssert.AreEqual(1, _task.LengthOfLongestSubstring("bbbbb"));
    }

    [Test]
    public void LengthOfLongestSubstring_AllUnique_ReturnsLength()
    {
        ClassicAssert.AreEqual(5, _task.LengthOfLongestSubstring("abcde"));
    }

    [Test]
    public void LengthOfLongestSubstring_EmptyString_ReturnsZero()
    {
        ClassicAssert.AreEqual(0, _task.LengthOfLongestSubstring(""));
    }

    [Test]
    public void LengthOfLongestSubstring_SingleChar_ReturnsOne()
    {
        ClassicAssert.AreEqual(1, _task.LengthOfLongestSubstring("a"));
    }
}
