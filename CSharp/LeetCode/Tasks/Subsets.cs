using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks;

public class SubsetsTask
{
	public IList<IList<int>> Subsets(int[] nums) 
	{
		var r = new List<IList<int>>();
		r.Add(new int[0]);
        
		for(var i = 1; i < nums.Length; i++)
		{
			FillSubsets(r, new(), 0, i);
		}
                        
		r.Add(nums);
        
		return r;
        
		void FillSubsets(IList<IList<int>> r, Stack<int> c, int k, int n)
		{
			if (n == 0)
			{
				r.Add(c.Reverse().ToList());
				return;
			}

			for(var i = k; i < nums.Length; i++)
			{
				c.Push(nums[i]);
				FillSubsets(r, c, i + 1, n - 1);
				c.Pop();
			}
		}
	}
}

[TestFixture]
public class SubsetsTaskTests
{
	private SubsetsTask _task = null!;

	[SetUp]
	public void SetUp() => _task = new SubsetsTask();

	[Test]
	public void Subsets_ThreeElements_ReturnsAllSubsets()
	{
		var result = _task.Subsets([1, 2, 3]);
		result.Should().HaveCount(8);
		result.Should().Contain(s => s.Count == 0);
		result.Should().Contain(s => s.SequenceEqual(new[] { 1, 2, 3 }));
	}

	[Test]
	public void Subsets_TwoElements_ReturnsCorrect()
	{
		var result = _task.Subsets([0, 1]);
		result.Should().HaveCount(4);
	}

	[Test]
	public void Subsets_SingleElement_ReturnsTwo()
	{
		var result = _task.Subsets([1]);
		result.Should().HaveCount(2);
	}
}
