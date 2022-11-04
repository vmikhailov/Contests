namespace LeetCode.Tasks;

public class LargestMultipleOfThreeTask
{
	public string LargestMultipleOfThree(int[] digits)
	{
		var d = digits.OrderBy(x => x).ToList();
		while (d.Any())
		{
			var r = d.Sum() % 3;
			if (r == 0) return MakeLargest(d);

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