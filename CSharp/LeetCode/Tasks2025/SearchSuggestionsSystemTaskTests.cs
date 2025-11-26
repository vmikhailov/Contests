using NUnit.Framework;
using FluentAssertions;

namespace LeetCode.Tasks2025;

public class SearchSuggestionsSystemTaskTests
{
    private SearchSuggestionsSystemTask _task = null!;

    [SetUp]
    public void SetUp()
    {
        _task = new SearchSuggestionsSystemTask();
    }

    [Test]
    public void SuggestedProducts_BasicExample_ReturnsTopThreeLexicographically()
    {
        // Arrange
        string[] products = ["mobile", "mouse", "moneypot", "monitor", "mousepad"];
        string searchWord = "mouse";

        // Act
        var result = _task.SuggestedProducts(products, searchWord);

        // Assert
        result.Should().HaveCount(5);
        result[0].Should().Equal(["mobile", "moneypot", "monitor"]);
        result[1].Should().Equal(["mobile", "moneypot", "monitor"]);
        result[2].Should().Equal(["mouse", "mousepad"]);
        result[3].Should().Equal(["mouse", "mousepad"]);
        result[4].Should().Equal(["mouse", "mousepad"]);
    }

    [Test]
    public void SuggestedProducts_NoMatchingProducts_ReturnsEmptyLists()
    {
        // Arrange
        string[] products = ["mobile", "mouse", "moneypot", "monitor", "mousepad"];
        string searchWord = "xyz";

        // Act
        var result = _task.SuggestedProducts(products, searchWord);

        // Assert
        result.Should().HaveCount(3);
        result[0].Should().BeEmpty();
        result[1].Should().BeEmpty();
        result[2].Should().BeEmpty();
    }

    [Test]
    public void SuggestedProducts_AllProductsMatch_ReturnsTopThree()
    {
        // Arrange
        string[] products = ["havana"];
        string searchWord = "havana";

        // Act
        var result = _task.SuggestedProducts(products, searchWord);

        // Assert
        result.Should().HaveCount(6);
        result[0].Should().Equal(["havana"]);
        result[1].Should().Equal(["havana"]);
        result[2].Should().Equal(["havana"]);
        result[3].Should().Equal(["havana"]);
        result[4].Should().Equal(["havana"]);
        result[5].Should().Equal(["havana"]);
    }

    [Test]
    public void SuggestedProducts_LessThanThreeMatches_ReturnsAllMatches()
    {
        // Arrange
        string[] products = ["bags", "baggage", "banner", "box", "cloths"];
        string searchWord = "bags";

        // Act
        var result = _task.SuggestedProducts(products, searchWord);

        // Assert
        result.Should().HaveCount(4);
        result[0].Should().Equal(["baggage", "bags", "banner"]);
        result[1].Should().Equal(["baggage", "bags", "banner"]);
        result[2].Should().Equal(["baggage", "bags"]);
        result[3].Should().Equal(["bags"]);
    }

    [Test]
    public void SuggestedProducts_MoreThanThreeMatches_ReturnsOnlyTopThree()
    {
        // Arrange
        string[] products = ["apple", "application", "apply", "app", "apricot"];
        string searchWord = "app";

        // Act
        var result = _task.SuggestedProducts(products, searchWord);

        // Assert
        result.Should().HaveCount(3);
        result[0].Should().Equal(["app", "apple", "application"]);
        result[1].Should().Equal(["app", "apple", "application"]);
        result[2].Should().Equal(["app", "apple", "application"]);
    }

    [Test]
    public void SuggestedProducts_SingleCharacterSearch_FiltersCorrectly()
    {
        // Arrange
        string[] products = ["bat", "cat", "hat", "ball", "can"];
        string searchWord = "b";

        // Act
        var result = _task.SuggestedProducts(products, searchWord);

        // Assert
        result.Should().HaveCount(1);
        result[0].Should().Equal(["ball", "bat"]);
    }

    [Test]
    public void SuggestedProducts_MatchesNarrowDown_ReturnsProgressiveResults()
    {
        // Arrange
        string[] products = ["car", "card", "care", "careful", "cart", "cat"];
        string searchWord = "care";

        // Act
        var result = _task.SuggestedProducts(products, searchWord);

        // Assert
        result.Should().HaveCount(4);
        result[0].Should().Equal(["car", "card", "care"]);
        result[1].Should().Equal(["car", "card", "care"]);
        result[2].Should().Equal(["car", "card", "care"]);
        result[3].Should().Equal(["care", "careful"]);
    }

    [Test]
    public void SuggestedProducts_EmptyProducts_ReturnsEmptyLists()
    {
        // Arrange
        string[] products = [];
        string searchWord = "test";

        // Act
        var result = _task.SuggestedProducts(products, searchWord);

        // Assert
        result.Should().HaveCount(4);
        result[0].Should().BeEmpty();
        result[1].Should().BeEmpty();
        result[2].Should().BeEmpty();
        result[3].Should().BeEmpty();
    }

    [Test]
    public void SuggestedProducts_SingleProduct_ReturnsCorrectly()
    {
        // Arrange
        string[] products = ["test"];
        string searchWord = "test";

        // Act
        var result = _task.SuggestedProducts(products, searchWord);

        // Assert
        result.Should().HaveCount(4);
        result[0].Should().Equal(["test"]);
        result[1].Should().Equal(["test"]);
        result[2].Should().Equal(["test"]);
        result[3].Should().Equal(["test"]);
    }

    [Test]
    public void SuggestedProducts_SearchWordLongerThanAllProducts_ReturnsEmptyAtEnd()
    {
        // Arrange
        string[] products = ["aa", "aaa", "aaaa"];
        string searchWord = "aaaaa";

        // Act
        var result = _task.SuggestedProducts(products, searchWord);

        // Assert
        result.Should().HaveCount(5);
        result[0].Should().Equal(["aa", "aaa", "aaaa"]);
        result[1].Should().Equal(["aa", "aaa", "aaaa"]);
        result[2].Should().Equal(["aaa", "aaaa"]);
        result[3].Should().Equal(["aaaa"]);
        result[4].Should().BeEmpty();
    }

    [Test]
    public void SuggestedProducts_MixedLengths_ReturnsSortedResults()
    {
        // Arrange
        string[] products = ["abcd", "abdc", "ab", "abc"];
        string searchWord = "ab";

        // Act
        var result = _task.SuggestedProducts(products, searchWord);

        // Assert
        result.Should().HaveCount(2);
        result[0].Should().Equal(["ab", "abc", "abcd"]);
        result[1].Should().Equal(["ab", "abc", "abcd"]);
    }
}

