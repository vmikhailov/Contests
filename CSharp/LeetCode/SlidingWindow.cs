namespace LeetCode;

using System;
using System.Collections.Generic;

public static class SlidingWindow
{
    // Returns max of each window of size k
    public static int[] MaxSlidingWindow(int[] nums, int k)
    {
        if (nums.Length == 0 || k <= 0) return [];
        if (k == 1) return nums;

        var dq = new LinkedList<int>(); // holds indices; values are decreasing
        var res = new int[nums.Length - k + 1];
        var ri = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            // 1) Pop from back while current value is greater
            while (dq.Count > 0 && nums[dq.Last!.Value] <= nums[i])
            {
                dq.RemoveLast();
            }

            dq.AddLast(i);

            // 2) Remove front if it fell out of window (i - k + 1 is left bound)
            if (dq.First!.Value <= i - k)
            {
                dq.RemoveFirst();
            }

            // 3) Record result when first window completes
            if (i >= k - 1)
            {
                res[ri++] = nums[dq.First!.Value];
            }
        }

        return res;
    }

    public static void Test()
    {
        var nums = new[] { 1, 3, -1, -3, 5, 3, 6, 7 };
        var k = 3;
        var result = MaxSlidingWindow(nums, k);
        Console.WriteLine(string.Join(", ", result)); // Expected output: 3, 3, 5, 5, 6, 7
    }
}
