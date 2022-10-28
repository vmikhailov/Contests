namespace LeetCode;

public class KFirst
{
	public int[] GetTopK(int[] nums, int k)
	{
		var low = 0;
		var high = nums.Length - 1;
		while (low < high)
		{
			var pi = (low + high) / 2;
			pi = Partition(nums, low, high, pi);
			if(pi == k) return nums[..k];
			if (k < pi)
			{
				high = pi - 1;
			}
			else
			{
				low = pi + 1;
			}
		}

		return nums[..low];
	}

	private int Partition(int[] arr, int low, int high, int pi)
	{
		var pivot = arr[pi];
		(arr[pi], arr[high]) = (arr[high], arr[pi]);

		var i = low;

		for (var j = low; j < high; j++)
		{
			if (arr[j] < pivot)
			{
				(arr[j], arr[i]) = (arr[i], arr[j]);
				i++;
			}
		}

		// swapping pivot to the readonly pivot location
		(arr[high], arr[i]) = (arr[i], arr[high]);

		return i;
	}
}