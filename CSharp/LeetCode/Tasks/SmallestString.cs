namespace LeetCode;

public class SmallestString
{
    public string GetSmallestString(int n, int k)
    {
        var digits = new char[n];
        var m = 26;
        var i = n - 1;

        while (i >= 0)
        {
            var t = i - 1 + m * (i - n + 2);
            if (t < k)
            {
                digits[i] = (char)(m + 'a' - 1);
                k -= m;
                n--;
                i--;
            }
            else
            {
                m--;
            }
        }

        return new string(digits);
    }

    public int MinDifference(int[] nums)
    {
        var n = nums.Length;
        if (n <= 4) return 0;
        Array.Sort(nums);
        var min = int.MaxValue;
        for (var k = 0; k <= 3; k++)
        {
            for (var l = 0; l <= k; l++)
            {
                var m = nums[n - k + l - 1] - nums[l];
                if (m < min) min = m;
            }
        }

        return min;
    }
}