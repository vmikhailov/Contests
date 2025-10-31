using FluentAssertions;
using NUnit.Framework;

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

[TestFixture]
public class TopKFreqTests
{
	private TopKFreq _task = null!;

	[SetUp]
	public void SetUp() => _task = new TopKFreq();

	[Test]
	public void GetTopK_BasicCase_ReturnsTopKFrequent()
	{
		var result = _task.GetTopK([1, 1, 1, 2, 2, 3], 2);
		result.Should().HaveCount(2);
		result.Should().Contain(1);
		result.Should().Contain(2);
	}

	[Test]
	public void GetTopK_SingleElement_ReturnsElement()
	{
		var result = _task.GetTopK([1], 1);
		result.Should().Equal(new[] { 1 });
	}

	[Test]
	public void GetTopK_AllUnique_ReturnsFirst()
	{
		var result = _task.GetTopK([1, 2, 3, 4], 2);
		result.Should().HaveCount(2);
	}

	[Test]
	public void GetTopK_AllSame_ReturnsOne()
	{
		var result = _task.GetTopK([4, 4, 4, 4], 1);
		result.Should().Equal(new[] { 4 });
	}
}

