namespace LeetCode.Tasks;

public class MaximumCount
{
    public int Compute(int[] nums)
    {
        var a = nums.Length - CountPositive(nums, 0, nums.Length) - 1;
        var b = CountNegative(nums, 0, nums.Length);

        return Math.Max(a, b);
    }

    public int CountPositive(int[] nums, int min, int max)
    {
        while (true)
        {
            var m = (min + max) / 2;
            
            if (nums[m] <= 0 && (m >= nums.Length - 1 || nums[m + 1] > 0)) return m;
            if (max - min <= 1) 
                return min - 1;
            
            if (nums[m] <= 0) min = m;
            else max = m;
        }
    }

    public int CountNegative(int[] nums, int min, int max)
    {
        while (true)
        {
            var m = (min + max) / 2;
            
            if (nums[m] >= 0 && (m <= 0 || nums[m - 1] < 0)) return m;
            if (max - min <= 1) return max;
            
            if (nums[m] >= 0) max = m;
            else min = m;
        }
    }
}