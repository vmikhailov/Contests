namespace LeetCode.Tasks2025;

public class SummaryRangesTask
{
    public IList<string> SummaryRanges(int[] nums)
    {
        if (nums.Length == 0) return [];
        if (nums.Length == 2) return [$"{nums[0]}", $"{nums[1]}"];

        var p = 0;
        var c = 1;
        var r = new List<string>();

        for (var i = 1; i <= nums.Length; i++)
        {
            if (i < nums.Length && nums[p] + c == nums[i])
            {
                c++;
            }
            else
            {
                if (nums[i - 1] - nums[p] > 0)
                {
                    r.Add($"{nums[p]}->{nums[i - 1]}");
                }
                else
                {
                    r.Add($"{nums[p]}");
                }

                p = i;
                c = 1;
            }
        }

        return r;
    }
}
