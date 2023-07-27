namespace LeetCode.Tasks;

public class FirstMissingPositive
{
    public int Compute(int[] nums)
    {
        var n = nums.Length;
        var i = 0;
        var v = nums[0];
        while (true)
        {
            if (v > n || v <= 0)
            {
                nums[i] = 0;
                v = i + 1;
            }
            
            var j = v - 1;
            if (i == j)
            {
                if (++i == n) break;
                v = nums[i];
                continue;
            }
           
            var f = nums[j];
            if (v == f)
            {
                nums[i] = 0;
                if (++i == n) break;
                v = nums[i];
            }
            else
            {
                nums[j] = v;
                v = f;
            }
        }

        for (i = 0; i < n; i++)
        {
            if (nums[i] == 0) return i + 1;
        }

        return n + 1;
    }
}