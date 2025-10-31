using FluentAssertions;
using NUnit.Framework;

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
			if(pi == k)
			{
				return nums[..k];
			}

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

[TestFixture]
public class KFirstTests
{
	private KFirst _task = null!;

	[SetUp]
	public void SetUp() => _task = new KFirst();

	[Test]
	public void GetTopK_BasicCase_ReturnsFirstK()
	{
		var result = _task.GetTopK([3, 2, 1, 5, 6, 4], 2);
		result.Should().HaveCount(2);
	}

	[Test]
	public void GetTopK_SingleElement_ReturnsElement()
	{
		var result = _task.GetTopK([1], 1);
		result.Should().Equal(new[] { 1 });
	}

	[Test]
	public void GetTopK_AllElements_ReturnsAll()
	{
		var arr = new[] { 1, 2, 3 };
		var result = _task.GetTopK(arr, 3);
		result.Should().HaveCount(3);
	}

	[Test]
	public void GetTopK_UnsortedArray_ReturnsCorrect()
	{
		var result = _task.GetTopK([3, 2, 3, 1, 2, 4, 5, 5, 6], 4);
		result.Should().HaveCount(4);
	}
}
