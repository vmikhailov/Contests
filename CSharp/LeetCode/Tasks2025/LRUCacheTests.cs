using NUnit.Framework;
using FluentAssertions;

namespace LeetCode.Tasks2025;

public class LRUCacheTests
{
    [Test]
    public void Get_NonExistentKey_ReturnsMinusOne()
    {
        // Arrange
        var cache = new LRUCache(2);

        // Act
        var result = cache.Get(1);

        // Assert
        result.Should().Be(-1);
    }

    [Test]
    public void Put_ThenGet_ReturnsCorrectValue()
    {
        // Arrange
        var cache = new LRUCache(2);
        cache.Put(1, 100);

        // Act
        var result = cache.Get(1);

        // Assert
        result.Should().Be(100);
    }

    [Test]
    public void Put_UpdateExistingKey_ReturnsNewValue()
    {
        // Arrange
        var cache = new LRUCache(2);
        cache.Put(1, 100);
        cache.Put(1, 200);

        // Act
        var result = cache.Get(1);

        // Assert
        result.Should().Be(200);
    }

    [Test]
    public void Put_ExceedsCapacity_EvictsLeastRecentlyUsed()
    {
        // Arrange
        var cache = new LRUCache(2);
        cache.Put(1, 100);
        cache.Put(2, 200);

        // Act
        cache.Put(3, 300); // Should evict key 1

        // Assert
        cache.Get(1).Should().Be(-1, "key 1 should be evicted");
        cache.Get(2).Should().Be(200, "key 2 should still exist");
        cache.Get(3).Should().Be(300, "key 3 should exist");
    }

    [Test]
    public void Get_UpdatesRecency_PreventsEviction()
    {
        // Arrange
        var cache = new LRUCache(2);
        cache.Put(1, 100);
        cache.Put(2, 200);

        // Act
        cache.Get(1); // Makes key 1 most recently used
        cache.Put(3, 300); // Should evict key 2, not key 1

        // Assert
        cache.Get(1).Should().Be(100, "key 1 should still exist (was accessed)");
        cache.Get(2).Should().Be(-1, "key 2 should be evicted (least recently used)");
        cache.Get(3).Should().Be(300, "key 3 should exist");
    }

    [Test]
    public void Put_UpdateExisting_UpdatesRecency()
    {
        // Arrange
        var cache = new LRUCache(2);
        cache.Put(1, 100);
        cache.Put(2, 200);

        // Act
        cache.Put(1, 150); // Update key 1, making it most recently used
        cache.Put(3, 300); // Should evict key 2

        // Assert
        cache.Get(1).Should().Be(150, "key 1 should exist with updated value");
        cache.Get(2).Should().Be(-1, "key 2 should be evicted");
        cache.Get(3).Should().Be(300, "key 3 should exist");
    }

    [Test]
    public void LRUCache_Capacity1_WorksCorrectly()
    {
        // Arrange
        var cache = new LRUCache(1);

        // Act & Assert
        cache.Put(1, 100);
        cache.Get(1).Should().Be(100);

        cache.Put(2, 200); // Evicts key 1
        cache.Get(1).Should().Be(-1);
        cache.Get(2).Should().Be(200);

        cache.Put(3, 300); // Evicts key 2
        cache.Get(2).Should().Be(-1);
        cache.Get(3).Should().Be(300);
    }

    [Test]
    public void LRUCache_MultipleOperations_MaintainsCorrectState()
    {
        // Arrange
        var cache = new LRUCache(3);

        // Act & Assert - Following LeetCode example
        cache.Put(1, 1);
        cache.Put(2, 2);
        cache.Get(1).Should().Be(1);
        cache.Put(3, 3);
        cache.Get(2).Should().Be(2);
        cache.Put(4, 4); // Evicts key 1 (least recently used)
        cache.Get(1).Should().Be(-1, "key 1 should be evicted");
        cache.Get(3).Should().Be(3);
        cache.Get(4).Should().Be(4);
    }

    [Test]
    public void LRUCache_SequentialAccess_MaintainsOrder()
    {
        // Arrange
        var cache = new LRUCache(3);
        cache.Put(1, 100);
        cache.Put(2, 200);
        cache.Put(3, 300);

        // Act - Access in sequence, then add new item
        cache.Get(1); // Order now: 1, 3, 2
        cache.Get(2); // Order now: 2, 1, 3
        cache.Get(3); // Order now: 3, 2, 1
        cache.Put(4, 400); // Should evict key 1

        // Assert
        cache.Get(1).Should().Be(-1, "key 1 should be evicted");
        cache.Get(2).Should().Be(200);
        cache.Get(3).Should().Be(300);
        cache.Get(4).Should().Be(400);
    }

    [Test]
    public void LRUCache_AlternatingPutAndGet_WorksCorrectly()
    {
        // Arrange
        var cache = new LRUCache(2);

        // Act & Assert
        cache.Put(1, 1);
        cache.Put(2, 2);
        cache.Get(1).Should().Be(1);       // Order: 1, 2
        cache.Put(3, 3);                   // Evicts 2, Order: 3, 1
        cache.Get(2).Should().Be(-1);
        cache.Put(4, 4);                   // Evicts 1, Order: 4, 3
        cache.Get(1).Should().Be(-1);
        cache.Get(3).Should().Be(3);
        cache.Get(4).Should().Be(4);
    }

    [Test]
    public void LRUCache_LargeCapacity_WorksCorrectly()
    {
        // Arrange
        var cache = new LRUCache(10);

        // Act - Fill cache
        for (var i = 1; i <= 10; i++)
        {
            cache.Put(i, i * 100);
        }

        // Assert - All items should exist
        for (var i = 1; i <= 10; i++)
        {
            cache.Get(i).Should().Be(i * 100);
        }

        // Act - Add one more item
        cache.Put(11, 1100);

        // Assert - First item should be evicted
        cache.Get(1).Should().Be(-1, "first item should be evicted");
        cache.Get(11).Should().Be(1100);
    }

    [Test]
    public void LRUCache_RepeatedGetOnSameKey_DoesNotAffectOthers()
    {
        // Arrange
        var cache = new LRUCache(2);
        cache.Put(1, 100);
        cache.Put(2, 200);

        // Act - Access key 1 multiple times
        cache.Get(1);
        cache.Get(1);
        cache.Get(1);
        cache.Put(3, 300);

        // Assert
        cache.Get(1).Should().Be(100, "key 1 should still exist");
        cache.Get(2).Should().Be(-1, "key 2 should be evicted");
    }

    [Test]
    public void LRUCache_RepeatedPutSameKey_UpdatesValue()
    {
        // Arrange
        var cache = new LRUCache(2);

        // Act
        cache.Put(1, 100);
        cache.Put(1, 200);
        cache.Put(1, 300);

        // Assert
        cache.Get(1).Should().Be(300);
    }

    [Test]
    public void LRUCache_ZeroAndNegativeValues_WorksCorrectly()
    {
        // Arrange
        var cache = new LRUCache(3);

        // Act
        cache.Put(1, 0);
        cache.Put(2, -100);
        cache.Put(3, -999);

        // Assert
        cache.Get(1).Should().Be(0);
        cache.Get(2).Should().Be(-100);
        cache.Get(3).Should().Be(-999);
    }

    [Test]
    public void LRUCache_LargeKeyValues_WorksCorrectly()
    {
        // Arrange
        var cache = new LRUCache(2);

        // Act
        cache.Put(1000000, 999999);
        cache.Put(2000000, 888888);

        // Assert
        cache.Get(1000000).Should().Be(999999);
        cache.Get(2000000).Should().Be(888888);
    }

    [Test]
    public void LRUCache_GetAfterMultipleEvictions_ReturnsMinusOne()
    {
        // Arrange
        var cache = new LRUCache(2);
        cache.Put(1, 100);
        cache.Put(2, 200);
        cache.Put(3, 300); // Evicts 1
        cache.Put(4, 400); // Evicts 2

        // Act & Assert
        cache.Get(1).Should().Be(-1);
        cache.Get(2).Should().Be(-1);
        cache.Get(3).Should().Be(300);
        cache.Get(4).Should().Be(400);
    }

    [Test]
    public void LRUCache_ComplexScenario_MaintainsCorrectLRUOrder()
    {
        // Arrange
        var cache = new LRUCache(3);

        // Act & Assert - Complex scenario
        cache.Put(1, 10);
        cache.Put(2, 20);
        cache.Put(3, 30);              // Order: 3, 2, 1
        cache.Get(2).Should().Be(20);  // Order: 2, 3, 1
        cache.Put(4, 40);              // Evicts 1, Order: 4, 2, 3
        cache.Get(1).Should().Be(-1);
        cache.Get(3).Should().Be(30);  // Order: 3, 4, 2
        cache.Put(5, 50);              // Evicts 2, Order: 5, 3, 4
        cache.Get(2).Should().Be(-1);
        cache.Get(3).Should().Be(30);
        cache.Get(4).Should().Be(40);
        cache.Get(5).Should().Be(50);
    }

    [Test]
    public void LRUCache_UpdateKeepsMostRecent_EvictsCorrectly()
    {
        // Arrange
        var cache = new LRUCache(2);
        cache.Put(1, 100);
        cache.Put(2, 200);

        // Act - Update key 1 twice
        cache.Put(1, 150);
        cache.Put(1, 175);
        cache.Put(3, 300); // Should evict key 2

        // Assert
        cache.Get(1).Should().Be(175, "key 1 should have latest value");
        cache.Get(2).Should().Be(-1, "key 2 should be evicted");
        cache.Get(3).Should().Be(300);
    }

    [Test]
    public void LRUCache_InterleavedOperations_WorksCorrectly()
    {
        // Arrange
        var cache = new LRUCache(2);

        // Act & Assert
        cache.Put(2, 1);
        cache.Put(1, 1);
        cache.Put(2, 3);
        cache.Put(4, 1);
        cache.Get(1).Should().Be(-1, "key 1 should be evicted");
        cache.Get(2).Should().Be(3, "key 2 should exist with updated value");
    }
}

