using NUnit.Framework.Legacy;
using NUnit.Framework;

namespace LeetCode.Tasks;

public class LargestMultipleOfThreeTask
{
	public string LargestMultipleOfThree(int[] digits)
	{
		var d = digits.OrderBy(x => x).ToList();
		while (d.Any())
		{
			var r = d.Sum() % 3;
			if (r == 0)
			{
				return MakeLargest(d);
			}

			var toExclude = d.Where(x => x % 3 == r).OrderBy(x => x).Take(1).ToList();
			if (!toExclude.Any())
			{
				toExclude = d.Where(x => x % 3 == 3 - r).OrderBy(x => x).Take(2).ToList();
			}

			foreach (var a in toExclude)
			{
				d.Remove(a);
			}
		}

		return "";
	}

	private string MakeLargest(IReadOnlyList<int> digits)
	{
		return string.Join("", digits.Reverse().SkipWhile(x => x == 0));
	}
}

[TestFixture]
public class LargestMultipleOfThreeTaskTests
{
	private LargestMultipleOfThreeTask _task = null!;

	[SetUp]
	public void SetUp() => _task = new LargestMultipleOfThreeTask();

	[Test]
	public void LargestMultipleOfThree_BasicCase_ReturnsCorrect()
	{
		var result = _task.LargestMultipleOfThree([8, 1, 9]);
		ClassicAssert.AreEqual("981", result);
	}

	[Test]
	public void LargestMultipleOfThree_WithZeros_ReturnsCorrect()
	{
		var result = _task.LargestMultipleOfThree([8, 6, 7, 1, 0]);
		ClassicAssert.AreEqual("8760", result);
	}

	[Test]
	public void LargestMultipleOfThree_AllZeros_ReturnsZero()
	{
		var result = _task.LargestMultipleOfThree([0, 0, 0, 0]);
		ClassicAssert.AreEqual("", result);
	}

	[Test]
	public void LargestMultipleOfThree_SingleDigit_ReturnsCorrect()
	{
		var result = _task.LargestMultipleOfThree([3]);
		ClassicAssert.AreEqual("3", result);
	}

	[Test]
	public void LargestMultipleOfThree_NoValidResult_ReturnsEmpty()
	{
		var result = _task.LargestMultipleOfThree([1, 1]);
		ClassicAssert.AreEqual("", result);
	}
}
