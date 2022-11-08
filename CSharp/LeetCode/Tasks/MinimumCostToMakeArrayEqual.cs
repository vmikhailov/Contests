namespace LeetCode.Tasks;

public class MinimumCostToMakeArrayEqual
{
	public long MinCost(int[] nums, int[] cost)
	{
		var min = nums.Min();
		var max = nums.Max();
		if (min == max) return 0;
		long avgCost1 = 0, avgCost2 = 0;

		while (min < max)
		{
			var avg = (min + max) / 2;
			avgCost1 = GetCost(avg);
			avgCost2 = GetCost(avg + 1);
			if (avgCost1 < avgCost2)
			{
				max = avg;
			}
			else
			{
				min = avg + 1;
			}
		}

		return Math.Min(avgCost1, avgCost2);

		long GetCost(int avg) =>
			nums.Zip(cost).Select(x => 1L * Math.Abs(avg - x.First) * x.Second).Sum();
	}
}