using NUnit.Framework;
using FluentAssertions;

namespace LeetCode.Tasks2025;

public class KSmallestPairTaskTest
{
    private static bool ListsEqual(IList<IList<int>> list1, IList<IList<int>> list2)
    {
        if (list1.Count != list2.Count) return false;
        for (int i = 0; i < list1.Count; i++)
        {
            if (list1[i].Count != list2[i].Count) return false;
            for (int j = 0; j < list1[i].Count; j++)
            {
                if (list1[i][j] != list2[i][j]) return false;
            }
        }
        return true;
    }

    [Test]
    public void Test_Example1()
    {
        var task = new KSmallestPairTask();
        var nums1 = new[] { 1, 7, 11 };
        var nums2 = new[] { 2, 4, 6 };
        var k = 3;

        var result = task.KSmallestPairs(nums1, nums2, k);

        var expected = new List<IList<int>> { new List<int> { 1, 2 }, new List<int> { 1, 4 }, new List<int> { 1, 6 } };
        ListsEqual(result, expected).Should().BeTrue("Should return 3 smallest pairs");
    }

    [Test]
    public void Test_Example2()
    {
        var task = new KSmallestPairTask();
        var nums1 = new[] { 1, 1, 2 };
        var nums2 = new[] { 1, 2, 3 };
        var k = 2;

        var result = task.KSmallestPairs(nums1, nums2, k);

        var expected = new List<IList<int>> { new List<int> { 1, 1 }, new List<int> { 1, 1 } };
        ListsEqual(result, expected).Should().BeTrue("Should return 2 smallest pairs");
    }

    [Test]
    public void Test_Example3()
    {
        var task = new KSmallestPairTask();
        var nums1 = new[] { 1, 2 };
        var nums2 = new[] { 3 };
        var k = 3;

        var result = task.KSmallestPairs(nums1, nums2, k);

        var expected = new List<IList<int>> { new List<int> { 1, 3 }, new List<int> { 2, 3 } };
        ListsEqual(result, expected).Should().BeTrue("Should return all available pairs when k exceeds total pairs");
    }

    [Test]
    public void Test_SingleElementArrays()
    {
        var task = new KSmallestPairTask();
        var nums1 = new[] { 1 };
        var nums2 = new[] { 2 };
        var k = 1;

        var result = task.KSmallestPairs(nums1, nums2, k);

        var expected = new List<IList<int>> { new List<int> { 1, 2 } };
        ListsEqual(result, expected).Should().BeTrue("Should return the only pair");
    }

    [Test]
    public void Test_KEqualsOne()
    {
        var task = new KSmallestPairTask();
        var nums1 = new[] { 1, 2, 3 };
        var nums2 = new[] { 4, 5, 6 };
        var k = 1;

        var result = task.KSmallestPairs(nums1, nums2, k);

        var expected = new List<IList<int>> { new List<int> { 1, 4 } };
        ListsEqual(result, expected).Should().BeTrue("Should return only the smallest pair");
    }

    [Test]
    public void Test_LargeK()
    {
        var task = new KSmallestPairTask();
        var nums1 = new[] { 1, 2, 3 };
        var nums2 = new[] { 1, 2, 3 };
        var k = 9;

        var result = task.KSmallestPairs(nums1, nums2, k);

        result.Count.Should().Be(9, "Should return all 9 possible pairs");
        result[0].Should().BeEquivalentTo(new List<int> { 1, 1 });
    }

    [Test]
    public void Test_DifferentSizedArrays()
    {
        var task = new KSmallestPairTask();
        var nums1 = new[] { 1, 2, 3, 4, 5 };
        var nums2 = new[] { 10, 20 };
        var k = 5;

        var result = task.KSmallestPairs(nums1, nums2, k);

        result.Count.Should().Be(5, "Should return 5 pairs");
        result[0].Should().BeEquivalentTo(new List<int> { 1, 10 });
    }

    [Test]
    public void Test_NegativeNumbers()
    {
        var task = new KSmallestPairTask();
        var nums1 = new[] { -3, -2, -1 };
        var nums2 = new[] { -3, -2, -1 };
        var k = 4;

        var result = task.KSmallestPairs(nums1, nums2, k);

        result.Count.Should().Be(4, "Should return 4 smallest pairs");
        result[0].Should().BeEquivalentTo(new List<int> { -3, -3 });
    }

    [Test]
    public void Test_MixedPositiveNegative()
    {
        var task = new KSmallestPairTask();
        var nums1 = new[] { -1, 1, 2 };
        var nums2 = new[] { -2, 0, 3 };
        var k = 5;

        var result = task.KSmallestPairs(nums1, nums2, k);

        result.Count.Should().Be(5, "Should return 5 smallest pairs");
        result[0].Should().BeEquivalentTo(new List<int> { -1, -2 });
    }

    [Test]
    public void Test_DuplicateValues()
    {
        var task = new KSmallestPairTask();
        var nums1 = new[] { 1, 1, 1 };
        var nums2 = new[] { 2, 2, 2 };
        var k = 4;

        var result = task.KSmallestPairs(nums1, nums2, k);

        result.Count.Should().Be(4, "Should return 4 pairs");
        foreach (var pair in result)
        {
            pair.Should().BeEquivalentTo(new List<int> { 1, 2 });
        }
    }
}

