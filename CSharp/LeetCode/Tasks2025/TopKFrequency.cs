namespace LeetCode;

public static class TopKFrequency
{
    public static IList<int> TopKFrequent(int[] nums, int k)
    {
        var freqMap = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            freqMap.TryAdd(num, 0);
            freqMap[num]++;
        }

        var minHeap = new MinHeap<int>(x => freqMap[x]);
        foreach (var kvp in freqMap)
        {
            minHeap.Push(kvp.Key);
            if (minHeap.Count > k)
            {
                minHeap.Pop();
            }
        }

        var result = new List<int>();
        while (minHeap.Count > 0)
        {
            result.Add(minHeap.Pop());
        }

        result.Reverse();
        return result;
    }

    public static void Test()
    {
        var nums = new[] { 1, 1, 1, 2, 2, 3 };
        var k = 2;
        var result = TopKFrequent(nums, k);
        Console.WriteLine(string.Join(", ", result)); // Expected output: 1, 2
    }
}
