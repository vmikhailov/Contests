using NUnit.Framework;
using FluentAssertions;

namespace LeetCode.Tasks2025;

public class RandomizedSetTaskTests
{
    private RandomizedSetTask.RandomizedSet _set = null!;

    [SetUp]
    public void SetUp()
    {
        _set = new RandomizedSetTask.RandomizedSet();
    }

    [Test]
    public void Insert_NewValue_ReturnsTrue()
    {
        // Act
        var result = _set.Insert(1);

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void Insert_DuplicateValue_ReturnsFalse()
    {
        // Arrange
        _set.Insert(1);

        // Act
        var result = _set.Insert(1);

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    public void Insert_MultipleDistinctValues_ReturnsTrue()
    {
        // Act & Assert
        _set.Insert(1).Should().BeTrue();
        _set.Insert(2).Should().BeTrue();
        _set.Insert(3).Should().BeTrue();
    }

    [Test]
    public void Remove_ExistingValue_ReturnsTrue()
    {
        // Arrange
        _set.Insert(1);

        // Act
        var result = _set.Remove(1);

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void Remove_NonExistingValue_ReturnsFalse()
    {
        // Act
        var result = _set.Remove(1);

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    public void Remove_AlreadyRemovedValue_ReturnsFalse()
    {
        // Arrange
        _set.Insert(1);
        _set.Remove(1);

        // Act
        var result = _set.Remove(1);

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    public void Insert_AfterRemoval_ReturnsTrue()
    {
        // Arrange
        _set.Insert(1);
        _set.Remove(1);

        // Act
        var result = _set.Insert(1);

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void GetRandom_SingleElement_ReturnsThatElement()
    {
        // Arrange
        _set.Insert(5);

        // Act
        var result = _set.GetRandom();

        // Assert
        result.Should().Be(5);
    }

    [Test]
    public void GetRandom_MultipleElements_ReturnsOneOfThem()
    {
        // Arrange
        _set.Insert(1);
        _set.Insert(2);
        _set.Insert(3);

        // Act
        var result = _set.GetRandom();

        // Assert
        result.Should().BeOneOf(1, 2, 3);
    }

    [Test]
    public void GetRandom_AfterRemoval_DoesNotReturnRemovedElement()
    {
        // Arrange
        _set.Insert(1);
        _set.Insert(2);
        _set.Insert(3);
        _set.Remove(2);

        // Act
        var results = new HashSet<int>();

        for (int i = 0; i < 100; i++)
        {
            results.Add(_set.GetRandom());
        }

        // Assert
        results.Should().NotContain(2);
        results.Should().BeSubsetOf(new[] { 1, 3 });
    }

    [Test]
    public void GetRandom_RepeatedCalls_ReturnsDistribution()
    {
        // Arrange
        _set.Insert(1);
        _set.Insert(2);
        _set.Insert(3);

        // Act
        var results = new HashSet<int>();

        for (int i = 0; i < 1000; i++)
        {
            results.Add(_set.GetRandom());
        }

        // Assert - all values should appear with enough iterations
        results.Should().Contain(1);
        results.Should().Contain(2);
        results.Should().Contain(3);
        results.Should().HaveCount(3);
    }

    [Test]
    public void OperationSequence_Example1_WorksCorrectly()
    {
        // Arrange & Act
        _set.Insert(1).Should().BeTrue();
        _set.Remove(2).Should().BeFalse();
        _set.Insert(2).Should().BeTrue();
        var random1 = _set.GetRandom();
        random1.Should().BeOneOf(1, 2);
        _set.Remove(1).Should().BeTrue();
        _set.Insert(2).Should().BeFalse();
        var random2 = _set.GetRandom();

        // Assert
        random2.Should().Be(2);
    }

    [Test]
    public void Remove_LastElement_WorksCorrectly()
    {
        // Arrange
        _set.Insert(1);
        _set.Insert(2);
        _set.Insert(3);

        // Act
        _set.Remove(3).Should().BeTrue();

        // Assert
        var result = _set.GetRandom();
        result.Should().BeOneOf(1, 2);
    }

    [Test]
    public void Remove_FirstElement_WorksCorrectly()
    {
        // Arrange
        _set.Insert(1);
        _set.Insert(2);
        _set.Insert(3);

        // Act
        _set.Remove(1).Should().BeTrue();

        // Assert
        var result = _set.GetRandom();
        result.Should().BeOneOf(2, 3);
    }

    [Test]
    public void Remove_MiddleElement_WorksCorrectly()
    {
        // Arrange
        _set.Insert(1);
        _set.Insert(2);
        _set.Insert(3);

        // Act
        _set.Remove(2).Should().BeTrue();

        // Assert
        var result = _set.GetRandom();
        result.Should().BeOneOf(1, 3);
    }

    [Test]
    public void Insert_NegativeNumbers_WorksCorrectly()
    {
        // Act
        _set.Insert(-1).Should().BeTrue();
        _set.Insert(-2).Should().BeTrue();

        // Assert
        var result = _set.GetRandom();
        result.Should().BeOneOf(-1, -2);
    }

    [Test]
    public void Insert_Zero_WorksCorrectly()
    {
        // Act
        _set.Insert(0).Should().BeTrue();

        // Assert
        _set.GetRandom().Should().Be(0);
    }

    [Test]
    public void LargeSet_InsertAndRemove_WorksCorrectly()
    {
        // Arrange - insert many elements
        for (int i = 0; i < 1000; i++)
        {
            _set.Insert(i).Should().BeTrue();
        }

        // Act - remove half of them
        for (int i = 0; i < 500; i++)
        {
            _set.Remove(i).Should().BeTrue();
        }

        // Assert - random should only return from remaining half
        var results = new HashSet<int>();

        for (int i = 0; i < 100; i++)
        {
            var random = _set.GetRandom();
            results.Add(random);
            random.Should().BeGreaterOrEqualTo(500);
            random.Should().BeLessThan(1000);
        }
    }

    [Test]
    public void RemoveAll_ThenInsert_WorksCorrectly()
    {
        // Arrange
        _set.Insert(1);
        _set.Insert(2);
        _set.Insert(3);
        _set.Remove(1);
        _set.Remove(2);
        _set.Remove(3);

        // Act
        _set.Insert(10).Should().BeTrue();

        // Assert
        _set.GetRandom().Should().Be(10);
    }

    [Test]
    public void AlternatingInsertRemove_WorksCorrectly()
    {
        // Act & Assert
        _set.Insert(1).Should().BeTrue();
        _set.Remove(1).Should().BeTrue();
        _set.Insert(2).Should().BeTrue();
        _set.Remove(2).Should().BeTrue();
        _set.Insert(3).Should().BeTrue();

        // Assert
        _set.GetRandom().Should().Be(3);
    }

    [Test]
    public void Insert_MaxValue_WorksCorrectly()
    {
        // Act
        _set.Insert(int.MaxValue).Should().BeTrue();

        // Assert
        _set.GetRandom().Should().Be(int.MaxValue);
    }

    [Test]
    public void Insert_MinValue_WorksCorrectly()
    {
        // Act
        _set.Insert(int.MinValue).Should().BeTrue();

        // Assert
        _set.GetRandom().Should().Be(int.MinValue);
    }

    [Test]
    public void ComplexSequence_MaintainsCorrectState()
    {
        // Arrange & Act
        _set.Insert(10).Should().BeTrue();
        _set.Insert(20).Should().BeTrue();
        _set.Insert(30).Should().BeTrue();
        _set.Remove(20).Should().BeTrue();
        _set.Insert(40).Should().BeTrue();
        _set.Remove(10).Should().BeTrue();
        _set.Insert(50).Should().BeTrue();

        // Assert - only 30, 40, 50 should remain
        var results = new HashSet<int>();

        for (int i = 0; i < 100; i++)
        {
            results.Add(_set.GetRandom());
        }

        results.Should().BeSubsetOf(new[] { 30, 40, 50 });
        results.Should().HaveCount(3);
    }

    [Test]
    public void Remove_RepeatedOnSameElement_OnlyFirstSucceeds()
    {
        // Arrange
        _set.Insert(1);

        // Act & Assert
        _set.Remove(1).Should().BeTrue();
        _set.Remove(1).Should().BeFalse();
        _set.Remove(1).Should().BeFalse();
    }

    [Test]
    public void GetRandom_MultipleCallsOnSingleElement_AlwaysReturnsSame()
    {
        // Arrange
        _set.Insert(42);

        // Act & Assert
        for (int i = 0; i < 10; i++)
        {
            _set.GetRandom().Should().Be(42);
        }
    }

    [Test]
    public void ComplexOperationSequence_LeetCodeTestCase_WorksCorrectly()
    {
        // This test case comes from LeetCode and tests a complex sequence of operations
        var operations = new[]
        {
            "RandomizedSet", "insert", "insert", "remove", "remove", "insert", "insert", "remove", "insert", "remove",
            "insert", "getRandom", "getRandom", "getRandom", "insert", "getRandom", "getRandom", "remove", "getRandom",
            "remove", "insert", "getRandom", "insert", "getRandom", "getRandom", "insert", "remove", "getRandom",
            "insert", "insert", "getRandom", "insert", "remove", "insert", "getRandom", "insert", "insert", "insert",
            "insert", "remove", "getRandom", "getRandom", "insert", "insert", "getRandom", "getRandom", "insert",
            "remove", "insert", "insert", "remove", "remove", "getRandom", "insert", "insert", "insert", "remove",
            "getRandom", "remove", "insert", "getRandom", "insert", "insert", "remove", "remove", "getRandom", "insert",
            "getRandom", "remove", "insert", "getRandom", "getRandom", "insert", "insert", "insert", "insert", "remove",
            "remove", "insert", "insert", "getRandom", "getRandom", "insert", "insert", "insert", "remove", "remove",
            "remove", "remove", "insert", "remove", "remove", "getRandom", "insert", "getRandom", "insert", "getRandom",
            "getRandom", "insert", "remove", "getRandom", "insert", "remove", "remove", "getRandom", "getRandom",
            "getRandom", "insert", "getRandom", "insert", "insert", "insert", "getRandom", "getRandom", "insert",
            "remove", "remove", "insert", "getRandom", "insert", "getRandom", "remove", "getRandom", "insert", "insert",
            "insert", "insert", "remove", "insert", "getRandom", "getRandom", "getRandom", "getRandom", "insert",
            "insert", "getRandom", "getRandom", "remove", "remove", "remove", "getRandom", "getRandom", "insert",
            "getRandom", "insert", "remove", "insert", "getRandom", "insert", "insert", "insert", "getRandom", "insert",
            "getRandom", "getRandom", "remove", "insert", "getRandom", "insert", "remove", "remove", "remove", "remove",
            "remove", "insert", "remove", "remove", "remove", "getRandom", "insert", "insert", "getRandom", "insert",
            "getRandom", "remove", "remove", "insert", "getRandom", "remove", "getRandom", "insert", "insert", "remove",
            "remove", "remove", "remove", "remove", "remove", "remove", "getRandom", "getRandom", "remove", "remove",
            "getRandom", "remove", "insert", "remove", "remove", "getRandom", "insert", "insert", "remove", "insert",
            "remove", "remove", "insert", "remove", "insert", "remove", "getRandom", "insert", "remove", "remove",
            "insert", "insert", "insert", "insert", "insert", "insert", "insert", "getRandom", "remove", "getRandom",
            "insert", "getRandom", "remove", "insert", "insert", "remove", "remove", "getRandom", "remove", "remove",
            "getRandom", "getRandom", "insert", "insert", "getRandom", "getRandom", "insert", "getRandom", "insert",
            "remove", "getRandom", "insert", "insert", "remove", "insert", "insert", "getRandom", "remove", "insert",
            "getRandom", "getRandom", "getRandom", "getRandom", "getRandom", "insert", "remove", "getRandom", "insert",
            "getRandom", "insert", "getRandom", "insert", "remove", "insert", "insert", "insert", "insert", "remove",
            "insert", "insert", "getRandom", "insert", "getRandom", "getRandom", "remove", "insert", "getRandom",
            "getRandom", "getRandom", "insert", "insert", "getRandom", "getRandom", "insert", "insert", "getRandom",
            "getRandom", "remove", "getRandom", "insert", "insert", "remove", "getRandom", "remove", "getRandom",
            "remove", "getRandom", "insert", "getRandom", "insert", "getRandom", "remove", "remove", "getRandom",
            "remove", "insert", "getRandom", "remove", "insert", "remove", "getRandom", "getRandom", "insert"
        };

        var values = new int?[]
        {
            null, -20, -47, -20, -47, -119, -119, -119, -99, -99, -121, null, null, null, 144, null, null, -121, null,
            144, 154, null, -13, null, null, 16, 16, null, -78, 44, null, 57, 154, -25, null, 142, 142, -84, -84, -78,
            null, null, -115, 110, null, null, 26, -13, -122, -14, 26, -115, null, -4, -102, -35, 44, null, -84, 153,
            null, -28, -69, -122, -4, null, 138, null, -102, 76, null, null, 133, 115, 31, -59, 138, -59, 147, 109,
            null, null, 84, -35, -113, 110, 147, -25, 109, 66, 133, 84, null, -71, null, -19, null, null, -138, -138,
            null, 80, -71, 31, null, null, null, -31, null, 104, 104, 142, null, null, 55, -35, -69, -92, null, -91,
            null, 55, null, -59, 104, 126, 14, -91, 60, null, null, null, null, 135, 57, null, null, 60, 60, -92, null,
            null, -127, null, -113, -14, -77, null, 79, -20, 25, null, 100, null, null, 126, -93, null, 128, -59, 14,
            57, 80, 128, -60, -60, -28, -19, null, -131, 86, null, -69, null, -77, -77, 11, null, -31, null, 90, -20,
            76, -20, -20, -93, 153, 25, 115, null, null, -127, 104, null, 86, -95, -131, -131, null, 47, 112, 90, -105,
            -69, -69, 28, -95, 67, 142, null, 118, -105, 118, 149, -113, -8, 150, 150, 0, 0, null, 11, null, 35, null,
            0, 76, 128, -113, -113, null, 66, 28, null, null, 111, 111, null, null, 50, null, -76, 112, null, 46, 157,
            150, -36, -123, null, 149, 134, null, null, null, null, null, 48, 128, null, -135, null, -133, null, -127,
            -36, 97, 97, 38, 38, -127, 150, 75, null, -75, null, null, 111, 63, null, null, null, -107, -107, null,
            null, -42, 127, null, null, -133, null, 62, 106, 135, null, 79, null, 35, null, -32, null, -47, null, 97,
            -47, null, -32, -31, null, 75, -118, -107, null, null, 152
        };

        // Track which values should currently be in the set
        var expectedSet = new HashSet<int>();

        for (int i = 1; i < operations.Length; i++) // Start from 1 to skip constructor
        {
            var op = operations[i];
            var val = values[i];

            switch (op)
            {
                case "insert":
                    var insertResult = _set.Insert(val!.Value);

                    if (expectedSet.Contains(val.Value))
                    {
                        insertResult.Should().BeFalse($"Value {val.Value} already exists at operation {i}");
                    }
                    else
                    {
                        insertResult.Should()
                            .BeTrue($"Value {val.Value} should be inserted successfully at operation {i}");
                        expectedSet.Add(val.Value);
                    }

                    break;

                case "remove":
                    var removeResult = _set.Remove(val!.Value);

                    if (expectedSet.Contains(val.Value))
                    {
                        removeResult.Should()
                            .BeTrue($"Value {val.Value} should be removed successfully at operation {i}");
                        expectedSet.Remove(val.Value);
                    }
                    else
                    {
                        removeResult.Should().BeFalse($"Value {val.Value} does not exist at operation {i}");
                    }

                    break;

                case "getRandom":
                    if (expectedSet.Count > 0)
                    {
                        var randomResult = _set.GetRandom();

                        expectedSet.Should().Contain(randomResult,
                            $"getRandom should return a value from the set at operation {i}");
                    }

                    break;
            }
        }

        // Final validation - verify the set has the expected size
        var finalValues = new HashSet<int>();

        for (int i = 0; i < Math.Min(100, expectedSet.Count * 10); i++)
        {
            finalValues.Add(_set.GetRandom());
        }

        finalValues.Should().BeSubsetOf(expectedSet);
    }
}
