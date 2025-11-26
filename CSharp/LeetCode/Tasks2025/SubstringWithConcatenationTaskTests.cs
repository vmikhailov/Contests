using NUnit.Framework;
using FluentAssertions;

namespace LeetCode.Tasks2025;

public class SubstringWithConcatenationTaskTests
{
    private static bool ListsEqual(IList<int> list1, IList<int> list2)
    {
        if (list1.Count != list2.Count) return false;

        var sorted1 = list1.OrderBy(x => x).ToList();
        var sorted2 = list2.OrderBy(x => x).ToList();

        for (int i = 0; i < sorted1.Count; i++)
        {
            if (sorted1[i] != sorted2[i]) return false;
        }

        return true;
    }

    [Test]
    public void Test_Example1()
    {
        var task = new SubstringWithConcatenationTask();
        var s = "barfoothefoobarman";
        var words = new[] { "foo", "bar" };

        var result = task.FindSubstring(s, words);

        var expected = new List<int> { 0, 9 };
        ListsEqual(result, expected).Should().BeTrue("Should find concatenations at positions 0 and 9");
    }

    [Test]
    public void Test_Example2()
    {
        var task = new SubstringWithConcatenationTask();
        var s = "wordgoodgoodgoodbestword";
        var words = new[] { "word", "good", "best", "word" };

        var result = task.FindSubstring(s, words);

        var expected = new List<int>();
        ListsEqual(result, expected).Should().BeTrue("Should find no valid concatenations");
    }

    [Test]
    public void Test_Example3()
    {
        var task = new SubstringWithConcatenationTask();
        var s = "barfoofoobarthefoobarman";
        var words = new[] { "bar", "foo", "the" };

        var result = task.FindSubstring(s, words);

        var expected = new List<int> { 6, 9, 12 };
        ListsEqual(result, expected).Should().BeTrue("Should find concatenations at positions 6, 9, and 12");
    }

    [Test]
    public void Test_SingleWord()
    {
        var task = new SubstringWithConcatenationTask();
        var s = "abcabc";
        var words = new[] { "abc" };

        var result = task.FindSubstring(s, words);

        var expected = new List<int> { 0, 3 };
        ListsEqual(result, expected).Should().BeTrue("Should find single word at positions 0 and 3");
    }

    [Test]
    public void Test_NoMatch()
    {
        var task = new SubstringWithConcatenationTask();
        var s = "abcdef";
        var words = new[] { "xyz", "abc" };

        var result = task.FindSubstring(s, words);

        var expected = new List<int>();
        ListsEqual(result, expected).Should().BeTrue("Should find no matches");
    }

    [Test]
    public void Test_AllSameCharactersTwoWords()
    {
        var task = new SubstringWithConcatenationTask();
        var s = "aaaaaaaaaaaaaa";
        var words = new[] { "aa", "aa" };

        var result = task.FindSubstring(s, words);

        int[] expected = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        ListsEqual(result, expected).Should().BeTrue("Should find all positions with two 'aa' words in sequence");
    }

    [Test]
    public void Test_OverlappingMatches()
    {
        var task = new SubstringWithConcatenationTask();
        var s = "abababab";
        var words = new[] { "ab", "ab" };

        var result = task.FindSubstring(s, words);

        var expected = new List<int> { 0, 2, 4 };
        ListsEqual(result, expected).Should().BeTrue("Should find overlapping concatenations");
    }

    [Test]
    public void Test_SingleCharacterWords()
    {
        var task = new SubstringWithConcatenationTask();
        var s = "abcabc";
        var words = new[] { "a", "b", "c" };

        var result = task.FindSubstring(s, words);

        var expected = new List<int> { 0, 1, 2, 3 };
        ListsEqual(result, expected).Should().BeTrue("Should handle single character words at all valid positions");
    }

    [Test]
    public void Test_LongerWords()
    {
        var task = new SubstringWithConcatenationTask();
        var s = "wordgoodgoodgoodbestword";
        var words = new[] { "word", "good", "best", "good" };

        var result = task.FindSubstring(s, words);

        var expected = new List<int> { 8 };
        ListsEqual(result, expected).Should().BeTrue("Should find concatenation with longer words");
    }

    [Test]
    public void Test_StringTooShort()
    {
        var task = new SubstringWithConcatenationTask();
        var s = "ab";
        var words = new[] { "abc", "def" };

        var result = task.FindSubstring(s, words);

        var expected = new List<int>();
        ListsEqual(result, expected).Should().BeTrue("String is too short to contain all words");
    }

    [Test]
    public void Test_ExactMatch()
    {
        var task = new SubstringWithConcatenationTask();
        var s = "foobar";
        var words = new[] { "foo", "bar" };

        var result = task.FindSubstring(s, words);

        var expected = new List<int> { 0 };
        ListsEqual(result, expected).Should().BeTrue("String exactly matches the concatenation");
    }

    [Test]
    public void Test_MultiplePermutations()
    {
        var task = new SubstringWithConcatenationTask();
        var s = "abcdabdcabcdabcd";
        var words = new[] { "ab", "cd" };

        var result = task.FindSubstring(s, words);

        result.Should().Contain(0, "abcd at position 0");
        result.Should().Contain(8, "abcd at position 8");
        result.Should().Contain(12, "abcd at position 12");
    }

    [Test]
    public void Test_ThreeWords()
    {
        var task = new SubstringWithConcatenationTask();
        var s = "abcdefabcdef";
        var words = new[] { "ab", "cd", "ef" };

        var result = task.FindSubstring(s, words);

        var expected = new List<int> { 0, 2, 4, 6 };
        ListsEqual(result, expected).Should().BeTrue("Should find all overlapping three-word concatenations");
    }

    [Test]
    public void Test_RepeatedPattern()
    {
        var task = new SubstringWithConcatenationTask();
        var s = "ababababab";
        var words = new[] { "ab", "ab", "ab" };

        var result = task.FindSubstring(s, words);

        var expected = new List<int> { 0, 2, 4 };
        ListsEqual(result, expected).Should().BeTrue("Should find all repeated patterns");
    }

    [Test]
    public void Test_DifferentPermutation()
    {
        var task = new SubstringWithConcatenationTask();
        var s = "wordgoodgoodgoodbestword";
        var words = new[] { "word", "good", "best", "good" };

        var result = task.FindSubstring(s, words);

        var expected = new List<int> { 8 };
        ListsEqual(result, expected).Should().BeTrue("Should find permutation at position 8: goodgoodbestword");
    }

    [Test]
    public void Test_DifferentPermutation2()
    {
        var task = new SubstringWithConcatenationTask();
        var s = "lingmindraboofooowingdingbarrwingmonkeypoundcake";
        string[] words = ["fooo", "barr", "wing", "ding", "wing"];

        var result = task.FindSubstring(s, words);

        var expected = new List<int> { 13 };
        ListsEqual(result, expected).Should().BeTrue("Should find permutation at position 13: goodgoodbestword");
    }
}
