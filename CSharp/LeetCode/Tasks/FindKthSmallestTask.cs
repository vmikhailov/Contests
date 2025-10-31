namespace LeetCode.Tasks;

public class FindKthSmallestTask
{
    public static int FindKthSmallest(int[] a, int[] b, int k)
    {
        var i = 0;
        var j = 0;

        while (i < a.Length && j < b.Length)
        {
            var c = a[i] < b[j] ? a[i++] : b[j++];
            if (--k == 0) return c;
        }

        while (i < a.Length)
        {
            if (--k == 0) return a[i];
            i++;
        }

        while (j < b.Length)
        {
            if (--k == 0) return b[j];
            j++;
        }

        return -1;
    }

    public static void Test()
    {
        // Test case 2: K = 1 (smallest element)
        var result2 = FindKthSmallest([2, 3, 4], [1, 5, 6], 1);
        Console.WriteLine($"Test 2: {result2} (Expected: 1)");

        // Test case 3: K equals total length
        var result3 = FindKthSmallest([1, 2], [3, 4], 4);
        Console.WriteLine($"Test 3: {result3} (Expected: 4)");

        // Test case 4: One array is smaller
        var result4 = FindKthSmallest([1], [2, 3, 4, 5], 3);
        Console.WriteLine($"Test 4: {result4} (Expected: 3)");

        // Test case 5: Duplicate values
        var result5 = FindKthSmallest([1, 3, 3], [2, 3, 4], 4);
        Console.WriteLine($"Test 5: {result5} (Expected: 3)");

        // Test case 7: Empty array B
        var result7 = FindKthSmallest([1, 2, 3, 4], [], 3);
        Console.WriteLine($"Test 7: {result7} (Expected: 3)");

        // Test case 8: K at boundary of array B
        var result8 = FindKthSmallest([5, 6, 7], [1, 2, 3], 3);
        Console.WriteLine($"Test 8: {result8} (Expected: 3)");

        // Test case 9: K at boundary of array A
        var result9 = FindKthSmallest([1, 2, 3], [5, 6, 7], 3);
        Console.WriteLine($"Test 9: {result9} (Expected: 3)");
    }
}
