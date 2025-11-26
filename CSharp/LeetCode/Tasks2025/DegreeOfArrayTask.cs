namespace LeetCode.Tasks2025;

public class DegreeOfArrayTask
{
    // 697. Degree of an Array
    public int FindShortestSubArray(int[] nums) {
        var nn = 50000;
        var count = nums.Length;
        var stat = new int[nn];

        foreach(var n in nums)
        {
            stat[n]++;
        }

        var maxFreq = 0;
        for(var i = 0; i < nn; i++) maxFreq = Math.Max(maxFreq, stat[i]);

        var maxes = new Dictionary<int, (int F, int L)>();
        for(var i = 0; i < nn; i++)
            if(maxFreq == stat[i])
                maxes[i] = (count - 1, 0);

        for(var i = 0; i < count; i++)
        {
            if(maxes.TryGetValue(nums[i], out var p))
            {
                var f = Math.Min(p.F, i);
                var l = Math.Max(p.L, i);
                maxes[nums[i]] = (f, l);
            }
        }

        return maxes.Select(x => x.Value.L - x.Value.F + 1).Min();
    }
}
/*
[
 [0,0,0,0,0,1,0,0],
 [0,0,0,0,1,0,0,1],
 [0,0,0,0,1,0,0,0],
 [1,0,0,0,1,0,0,0],
 [0,0,1,1,0,0,0,0]
]
*/
