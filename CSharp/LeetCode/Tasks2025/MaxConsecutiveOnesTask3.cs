namespace LeetCode.Tasks2025;

public class MaxConsecutiveOnesTask3
{
    // Given a binary array nums and an integer k, return the maximum number of consecutive 1's
    // in the array if you can flip at most k 0's.
    public int LongestOnes(int[] nums, int k)
    {
        var i = 0;
        var j = 0;
        var z = 0;
        var m = 0;
        while(j < nums.Length)
        {
            if(nums[j] == 0)
            {
                if(z == k)
                {
                    m = Math.Max(m, j - i);
                    while(i < j && nums[i] == 1) i++;
                    i++;
                    z--;
                }
                z++;
            }
            j++;
        }

        m = Math.Max(m, j - i);
        return m;
    }
}
