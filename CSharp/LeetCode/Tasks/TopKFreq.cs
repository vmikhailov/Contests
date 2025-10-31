namespace LeetCode;

public class TopKFreq
{
	public int[] GetTopK(int[] nums, int k)
	{
		var d = new Dictionary<int, int>();
		for (var i = 0; i < nums.Length; i++)
		{
			var n = d.GetValueOrDefault(nums[i], 0);

			d[nums[i]] = n + 1;
		}

		var r = d.OrderByDescending(x => x.Value).Take(k).Select(x => x.Key).ToArray();

		var rr = r.GetEnumerator();
		return r;
	}
}
