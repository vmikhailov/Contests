using NUnit.Framework;
using FluentAssertions;

namespace LeetCode.Tasks2025;

public class LFUCacheTests
{
    private ILFUCache Create(Type t, int capacity)
    {
        return (ILFUCache)Activator.CreateInstance(t, capacity)!;
    }

    [TestCase(typeof(LFUCache))]
    [TestCase(typeof(LFUCacheLinkedList))]
    public void Basic_GetPut_Works(Type t)
    {
        var cache = Create(t, 2);
        cache.Put(1, 10);
        cache.Put(2, 20);
        cache.Get(1).Should().Be(10);
        cache.Put(3, 30); // evicts key 2 (freq 1 vs key 1 freq 2)
        cache.Get(2).Should().Be(-1);
        cache.Get(3).Should().Be(30);
        cache.Get(1).Should().Be(10);
    }

    [TestCase(typeof(LFUCache))]
    [TestCase(typeof(LFUCacheLinkedList))]
    public void UpdateValue_IncreasesFrequency(Type t)
    {
        var cache = Create(t, 2);
        cache.Put(1, 1);
        cache.Put(2, 2);
        cache.Get(1); // 1:freq2, 2:freq1
        cache.Put(3, 3); // evict 2
        cache.Get(2).Should().Be(-1);
        cache.Get(3).Should().Be(3);
        cache.Get(1).Should().Be(1);

        cache.Put(3, 33);
        cache.Get(3).Should().Be(33);
    }

    [TestCase(typeof(LFUCache))]
    [TestCase(typeof(LFUCacheLinkedList))]
    public void TieBreaks_ByLRUWithinSameFrequency(Type t)
    {
        var cache = Create(t, 2);
        cache.Put(1, 1); // 1: f1
        cache.Put(2, 2); // 2: f1 (order: 2 MRU, 1 LRU in f1)
        cache.Put(3, 3); // evict 1 (least recent among freq1)
        cache.Get(1).Should().Be(-1);
        cache.Get(2).Should().Be(2);
        cache.Get(3).Should().Be(3);
    }

    [TestCase(typeof(LFUCache), typeof(LFUCacheLinkedList))]
    [TestCase(typeof(LFUCacheLinkedList), typeof(LFUCache))]
    public void CrossValidate_WithNodeBasedImplementation(Type typeA, Type typeB)
    {
        var cap = 3;
        var a = Create(typeA, cap);
        var b = Create(typeB, cap);

        // Sequence of mixed operations
        void Put(int k, int v)
        {
            a.Put(k, v);
            b.Put(k, v);
        }
        int Get(int k)
        {
            var ra = a.Get(k);
            var rb = b.Get(k);
            ra.Should().Be(rb, $"Mismatch on Get({k})");
            return ra;
        }

        Put(1, 10); // 1:f1
        Put(2, 20); // 2:f1
        Put(3, 30); // 3:f1
        Get(1);     // 1:f2
        Get(2);     // 2:f2
        Put(4, 40); // evict 3 (lowest freq)
        Get(3).Should().Be(-1);
        Get(1).Should().Be(10);
        Get(2).Should().Be(20);
        Get(4).Should().Be(40);

        Put(2, 22); // update value, keeps/increases freq
        Get(2).Should().Be(22);

        Get(4);     // bump 4
        Put(5, 50); // evict lowest (1 vs 2 vs 4 -> 1 is lowest)
        Get(1).Should().Be(-1);
        Get(2).Should().Be(22);
        Get(4).Should().Be(40);
        Get(5).Should().Be(50);
    }
}
