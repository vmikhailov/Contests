using FluentAssertions;
using NUnit.Framework;

namespace LeetCode;

public class Permutations
{
	public IList<IList<int>> Permute(int[] nums)
	{
		var list = new List<IList<int>>();
		var used = new bool[nums.Length];
		var current = new int[nums.Length];
		BuildPermutations(nums, used, current, 0, list);
		return list;
	}

	private void BuildPermutations(int[] nums, bool[] used, int[] current, int p, List<IList<int>> list)
	{
		if (p == nums.Length)
		{
			list.Add(current.ToList());		
		}
		
		for (var i = 0; i < nums.Length; i++)
		{
			if (used[i])
			{
				continue;
			}

			used[i] = true;
			current[p] = nums[i];
			BuildPermutations(nums, used, current, p + 1, list);
			used[i] = false;
		}
	}
}

public class Permutations2
{
	public IList<IList<int>> Permute(int[] nums)
	{
		var list = new List<IList<int>>();
		var used = new bool[nums.Length];
		var current = new int[nums.Length];
		
		BuildPermutations(0);
		return list;
		
		void BuildPermutations(int p)
		{
			if (p == nums.Length)
			{
				list.Add(current.ToList());		
			}
		
			for (var i = 0; i < nums.Length; i++)
			{
				if (used[i])
				{
					continue;
				}

				used[i] = true;
				current[p] = nums[i];
				BuildPermutations(p + 1);
				used[i] = false;
			}
		}
	}
}

[TestFixture]
public class PermutationsTests
{
	private Permutations _task = null!;

	[SetUp]
	public void SetUp() => _task = new Permutations();

	[Test]
	public void Permute_ThreeElements_ReturnsSixPermutations()
	{
		var result = _task.Permute([1, 2, 3]);
		result.Should().HaveCount(6);
	}

	[Test]
	public void Permute_TwoElements_ReturnsTwoPermutations()
	{
		var result = _task.Permute([0, 1]);
		result.Should().HaveCount(2);
		result.Should().Contain(p => p.SequenceEqual(new[] { 0, 1 }));
		result.Should().Contain(p => p.SequenceEqual(new[] { 1, 0 }));
	}

	[Test]
	public void Permute_SingleElement_ReturnsOnePermutation()
	{
		var result = _task.Permute([1]);
		result.Should().HaveCount(1);
		result[0].Should().Equal(new[] { 1 });
	}
}

[TestFixture]
public class Permutations2Tests
{
	private Permutations2 _task = null!;

	[SetUp]
	public void SetUp() => _task = new Permutations2();

	[Test]
	public void Permute_ThreeElements_ReturnsSixPermutations()
	{
		var result = _task.Permute([1, 2, 3]);
		result.Should().HaveCount(6);
	}

	[Test]
	public void Permute_TwoElements_ReturnsTwoPermutations()
	{
		var result = _task.Permute([0, 1]);
		result.Should().HaveCount(2);
	}
}
