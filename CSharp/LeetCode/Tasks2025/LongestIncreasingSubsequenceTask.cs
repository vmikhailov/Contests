namespace LeetCode.Tasks2025;

public class LongestIncreasingSubsequenceTask
{
    public int LengthOfLIS(int[] nums) {
        var n = nums.Length;
        var dp = new int[n + 1];

        for(var i = 1; i <= nums.Length; i++)
        {
            var v = nums[i - 1];
            var p = 0;
            for(var j = i - 1; j > 0; j--)
            {
                if(nums[j - 1] < v)
                {
                    p = Math.Max(p, dp[j]);
                }
            }
            dp[i] = p + 1;
        }

        return dp.Max();
    }
}

