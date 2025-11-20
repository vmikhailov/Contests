namespace LeetCode.Tasks2025;

public class JumpGameTask
{
    public bool CanJump(int[] nums)
    {
        var dp = new bool[nums.Length];

        dp[0] = true;

        for (var i = 0; i < nums.Length; i++)
        {
            if (!dp[i]) continue;

            for (var j = i + 1; j < nums.Length && (j - i) <= nums[i]; j++)
            {
                dp[j] = true;
            }
        }

        return dp[nums.Length - 1];
    }
}
