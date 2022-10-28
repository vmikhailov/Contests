namespace LeetCode;

public class CheckSubArray
{
	public bool CheckSubarraySum(int[] nums, int k)
	{
		var primes = GetDividers(k);
		return true;
	}

	public List<int> GetDividers(int k)
	{
		var divs = new List<int>();
		for (var i = 2; i < (int)Math.Sqrt(k) + 1; i++)
		{
			if (k % i == 0)
			{
				divs.Add(i);
			}
		}

		return divs;
	}
}