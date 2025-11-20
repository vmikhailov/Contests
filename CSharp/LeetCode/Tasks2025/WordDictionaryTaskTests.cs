using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks2025;

[TestFixture]
public class WordDictionaryTaskTests
{
    private WordDictionaryTask _dictionary = null!;

    [SetUp]
    public void SetUp()
    {
        _dictionary = new WordDictionaryTask();
    }

    [Test]
    public void AddWord_SingleWord_CanBeSearched()
    {
        // Arrange & Act
        _dictionary.AddWord("bad");

        // Assert
        _dictionary.Search("bad").Should().BeTrue();
    }

    [Test]
    public void Search_NonExistentWord_ReturnsFalse()
    {
        // Arrange
        _dictionary.AddWord("bad");

        // Act & Assert
        _dictionary.Search("good").Should().BeFalse();
    }

    [Test]
    public void Search_EmptyDictionary_ReturnsFalse()
    {
        // Act & Assert
        _dictionary.Search("word").Should().BeFalse();
    }

    [Test]
    public void Search_WithWildcard_SingleCharacter_ReturnsTrue()
    {
        // Arrange
        _dictionary.AddWord("bad");
        _dictionary.AddWord("dad");
        _dictionary.AddWord("mad");

        // Act & Assert
        _dictionary.Search(".ad").Should().BeTrue();
        _dictionary.Search("b.d").Should().BeTrue();
        _dictionary.Search("ba.").Should().BeTrue();
    }

    [Test]
    public void Search_WithWildcard_MultipleCharacters_ReturnsTrue()
    {
        // Arrange
        _dictionary.AddWord("bad");
        _dictionary.AddWord("dad");
        _dictionary.AddWord("mad");

        // Act & Assert
        _dictionary.Search("...").Should().BeTrue();
        _dictionary.Search("..d").Should().BeTrue();
    }

    [Test]
    public void Search_WithWildcard_NoMatch_ReturnsFalse()
    {
        // Arrange
        _dictionary.AddWord("bad");

        // Act & Assert
        _dictionary.Search(".at").Should().BeFalse();
        _dictionary.Search("ba..").Should().BeFalse();
    }

    [Test]
    public void Search_WildcardAtBeginning_ReturnsTrue()
    {
        // Arrange
        _dictionary.AddWord("pad");
        _dictionary.AddWord("bad");

        // Act & Assert
        _dictionary.Search(".ad").Should().BeTrue();
    }

    [Test]
    public void Search_WildcardAtEnd_ReturnsTrue()
    {
        // Arrange
        _dictionary.AddWord("bad");
        _dictionary.AddWord("bat");

        // Act & Assert
        _dictionary.Search("ba.").Should().BeTrue();
    }

    [Test]
    public void Search_WildcardInMiddle_ReturnsTrue()
    {
        // Arrange
        _dictionary.AddWord("bad");
        _dictionary.AddWord("bed");

        // Act & Assert
        _dictionary.Search("b.d").Should().BeTrue();
    }

    [Test]
    public void Search_AllWildcards_ReturnsTrue()
    {
        // Arrange
        _dictionary.AddWord("abc");

        // Act & Assert
        _dictionary.Search("...").Should().BeTrue();
    }

    [Test]
    public void Search_AllWildcards_WrongLength_ReturnsFalse()
    {
        // Arrange
        _dictionary.AddWord("abc");

        // Act & Assert
        _dictionary.Search("....").Should().BeFalse();
        _dictionary.Search("..").Should().BeFalse();
    }

    [Test]
    public void AddWord_MultipleWords_AllCanBeSearched()
    {
        // Arrange
        _dictionary.AddWord("bad");
        _dictionary.AddWord("dad");
        _dictionary.AddWord("mad");

        // Act & Assert
        _dictionary.Search("bad").Should().BeTrue();
        _dictionary.Search("dad").Should().BeTrue();
        _dictionary.Search("mad").Should().BeTrue();
    }

    [Test]
    public void AddWord_WordsWithCommonPrefix_BothCanBeSearched()
    {
        // Arrange
        _dictionary.AddWord("app");
        _dictionary.AddWord("apple");
        _dictionary.AddWord("application");

        // Act & Assert
        _dictionary.Search("app").Should().BeTrue();
        _dictionary.Search("apple").Should().BeTrue();
        _dictionary.Search("application").Should().BeTrue();
    }

    [Test]
    public void Search_PartialWord_ReturnsFalse()
    {
        // Arrange
        _dictionary.AddWord("application");

        // Act & Assert
        _dictionary.Search("app").Should().BeFalse();
        _dictionary.Search("apple").Should().BeFalse();
    }

    [Test]
    public void Search_LongerThanAddedWord_ReturnsFalse()
    {
        // Arrange
        _dictionary.AddWord("app");

        // Act & Assert
        _dictionary.Search("apple").Should().BeFalse();
    }

    [Test]
    public void Search_WithWildcard_MultipleMatches_ReturnsTrue()
    {
        // Arrange
        _dictionary.AddWord("bad");
        _dictionary.AddWord("dad");
        _dictionary.AddWord("mad");
        _dictionary.AddWord("sad");

        // Act & Assert
        _dictionary.Search(".ad").Should().BeTrue();
    }

    [Test]
    public void Search_WithMultipleWildcards_ReturnsTrue()
    {
        // Arrange
        _dictionary.AddWord("hello");

        // Act & Assert
        _dictionary.Search("h.ll.").Should().BeTrue();
        _dictionary.Search(".e.l.").Should().BeTrue();
        _dictionary.Search("h....").Should().BeTrue();
    }

    [Test]
    public void StartsWith_ExistingPrefix_ReturnsTrue()
    {
        // Arrange
        _dictionary.AddWord("apple");

        // Act & Assert
        _dictionary.StartsWith("app").Should().BeTrue();
        _dictionary.StartsWith("a").Should().BeTrue();
        _dictionary.StartsWith("apple").Should().BeTrue();
    }

    [Test]
    public void StartsWith_NonExistingPrefix_ReturnsFalse()
    {
        // Arrange
        _dictionary.AddWord("apple");

        // Act & Assert
        _dictionary.StartsWith("ban").Should().BeFalse();
        _dictionary.StartsWith("apples").Should().BeFalse();
    }

    [Test]
    public void StartsWith_EmptyDictionary_ReturnsFalse()
    {
        // Act & Assert
        _dictionary.StartsWith("test").Should().BeFalse();
    }

    [Test]
    public void AddWord_EmptyString_SearchReturnsFalse()
    {
        // Arrange
        _dictionary.AddWord("");

        // Act & Assert
        _dictionary.Search("").Should().BeFalse();
        _dictionary.Search("a").Should().BeFalse();
    }

    [Test]
    public void Search_SingleCharacterWords_WorksCorrectly()
    {
        // Arrange
        _dictionary.AddWord("a");
        _dictionary.AddWord("b");

        // Act & Assert
        _dictionary.Search("a").Should().BeTrue();
        _dictionary.Search("b").Should().BeTrue();
        _dictionary.Search("c").Should().BeFalse();
        _dictionary.Search(".").Should().BeTrue();
    }

    [Test]
    public void Search_LongWord_WorksCorrectly()
    {
        // Arrange
        var longWord = "abcdefghijklmnopqrstuvwxyz";
        _dictionary.AddWord(longWord);

        // Act & Assert
        _dictionary.Search(longWord).Should().BeTrue();
        _dictionary.Search("abcdefghijklmnopqrstuvwxy.").Should().BeTrue();
        _dictionary.Search("..........................").Should().BeTrue();
    }

    [Test]
    public void Search_WildcardWithNoMatchingBranch_ReturnsFalse()
    {
        // Arrange
        _dictionary.AddWord("abc");
        _dictionary.AddWord("def");

        // Act & Assert
        _dictionary.Search(".bc").Should().BeTrue();
        _dictionary.Search(".ef").Should().BeTrue();
        _dictionary.Search(".xy").Should().BeFalse();
    }

    [Test]
    public void Search_ComplexWildcardPattern_WorksCorrectly()
    {
        // Arrange
        _dictionary.AddWord("test");
        _dictionary.AddWord("text");
        _dictionary.AddWord("task");

        // Act & Assert
        _dictionary.Search("t.st").Should().BeTrue();
        _dictionary.Search("t.xt").Should().BeTrue();
        _dictionary.Search("t.sk").Should().BeTrue();
        _dictionary.Search("ta..").Should().BeTrue();
        _dictionary.Search("te..").Should().BeTrue();
    }

    [Test]
    public void AddWord_DuplicateWords_SearchStillWorks()
    {
        // Arrange
        _dictionary.AddWord("word");
        _dictionary.AddWord("word");
        _dictionary.AddWord("word");

        // Act & Assert
        _dictionary.Search("word").Should().BeTrue();
        _dictionary.Search("w...").Should().BeTrue();
    }

    [Test]
    public void Search_CaseSensitive_LowercaseOnly()
    {
        // Arrange
        _dictionary.AddWord("abc");

        // Act & Assert
        _dictionary.Search("abc").Should().BeTrue();
        // Assuming lowercase only based on Idx(char c) => c - 'a'
    }

    [Test]
    public void Search_WildcardWithDifferentLengthWords_ReturnsCorrectResults()
    {
        // Arrange
        _dictionary.AddWord("a");
        _dictionary.AddWord("ab");
        _dictionary.AddWord("abc");
        _dictionary.AddWord("abcd");

        // Act & Assert
        _dictionary.Search(".").Should().BeTrue();
        _dictionary.Search("..").Should().BeTrue();
        _dictionary.Search("...").Should().BeTrue();
        _dictionary.Search("....").Should().BeTrue();
        _dictionary.Search(".....").Should().BeFalse();
    }

    [Test]
    public void Search_MultipleWildcardsInDifferentPositions_ReturnsTrue()
    {
        // Arrange
        _dictionary.AddWord("pattern");

        // Act & Assert
        _dictionary.Search("p.ttern").Should().BeTrue();
        _dictionary.Search("pa.tern").Should().BeTrue();
        _dictionary.Search("pat.ern").Should().BeTrue();
        _dictionary.Search("patt.rn").Should().BeTrue();
        _dictionary.Search("patte.n").Should().BeTrue();
        _dictionary.Search("patter.").Should().BeTrue();
    }

    [Test]
    public void StartsWith_WildcardsNotSupported_SearchesLiterally()
    {
        // Arrange
        _dictionary.AddWord("apple");

        // Act & Assert
        // StartsWith should search literally, not support wildcards
        _dictionary.StartsWith("ap").Should().BeTrue();
        _dictionary.StartsWith("app").Should().BeTrue();
    }

    [Test]
    public void Search_TrieStructure_HandlesComplexBranching()
    {
        // Arrange
        _dictionary.AddWord("cat");
        _dictionary.AddWord("car");
        _dictionary.AddWord("card");
        _dictionary.AddWord("care");
        _dictionary.AddWord("careful");

        // Act & Assert
        _dictionary.Search("cat").Should().BeTrue();
        _dictionary.Search("car").Should().BeTrue();
        _dictionary.Search("card").Should().BeTrue();
        _dictionary.Search("care").Should().BeTrue();
        _dictionary.Search("careful").Should().BeTrue();
        _dictionary.Search("ca.").Should().BeTrue();
        _dictionary.Search("car.").Should().BeTrue();
        _dictionary.Search("care...").Should().BeTrue();
    }

    [Test]
    public void Search_WildcardExploresAllBranches_FindsMatch()
    {
        // Arrange
        _dictionary.AddWord("bad");
        _dictionary.AddWord("dad");
        _dictionary.AddWord("mad");
        _dictionary.AddWord("pad");
        _dictionary.AddWord("sad");

        // Act & Assert
        _dictionary.Search(".ad").Should().BeTrue();
        _dictionary.Search("..d").Should().BeTrue();
        _dictionary.Search(".a.").Should().BeTrue();
    }

    [Test]
    public void Search_NoWordsMatchWildcardPattern_ReturnsFalse()
    {
        // Arrange
        _dictionary.AddWord("abc");
        _dictionary.AddWord("def");
        _dictionary.AddWord("ghi");

        // Act & Assert
        _dictionary.Search("xyz").Should().BeFalse();
        _dictionary.Search(".yz").Should().BeFalse();
        _dictionary.Search("..z").Should().BeFalse();
    }

    [Test]
    public void LeetCodeSequence_ComplexOperations_ReturnsExpectedResults()
    {
        // Test sequence from LeetCode:
        // ["WordDictionary","addWord","addWord","addWord","addWord","search","search","addWord","search","search","search","search","search","search"]
        // [[],["at"],["and"],["an"],["add"],["a"],[".at"],["bat"],[".at"],["an."],["a.d."],["b."],["a.d"],["."]]

        // Arrange - Add initial words
        _dictionary.AddWord("at");
        _dictionary.AddWord("and");
        _dictionary.AddWord("an");
        _dictionary.AddWord("add");

        // Act & Assert - First set of searches
        _dictionary.Search("a").Should().BeFalse();     // "a" not in dictionary
        _dictionary.Search(".at").Should().BeFalse();   // ".at" requires 3 chars, but "at" is only 2

        // Add another word
        _dictionary.AddWord("bat");

        // Act & Assert - Second set of searches
        _dictionary.Search(".at").Should().BeTrue();    // Matches "bat"
        _dictionary.Search("an.").Should().BeTrue();    // Matches "and"
        _dictionary.Search("a.d.").Should().BeFalse();  // "a.d." requires 4 chars, no match
        _dictionary.Search("b.").Should().BeFalse();    // "b." requires 2 chars starting with 'b', no match
        _dictionary.Search("a.d").Should().BeTrue();    // Matches "add" or "and"
        _dictionary.Search(".").Should().BeFalse();     // "." requires 1 char, no single char words
    }
}

