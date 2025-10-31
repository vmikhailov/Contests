using NUnit.Framework.Legacy;
using System.Text;
using NUnit.Framework;

namespace LeetCode.Tasks;

public class WordPatternTask
{
	public bool WordPattern(string pattern, string s)
	{
		var ss = s.Split(" ");
		var r = new StringBuilder();
		if (ss.Length != pattern.Length)
		{
			return false;
		}

		var d = new Dictionary<char, string>();
		var f = new Dictionary<string, char>();

		for (var i = 0; i < ss.Length; i++)
		{
			var a = pattern[i];
			var b = ss[i];

			var x1 = d.TryGetValue(a, out var c);
			var x2 = f.TryGetValue(b, out var e);

			if (x1 || x2)
			{
				if (x1 != x2 && (c != b || e != a))
				{
					return false;
				}
			}

			d[a] = b;
			f[b] = a;
			r.Append(a);
		}

		return r.ToString() == pattern;
	}
}

[TestFixture]
public class WordPatternTaskTests
{
	private WordPatternTask _task = null!;

	[SetUp]
	public void SetUp() => _task = new WordPatternTask();

	[Test]
	public void WordPattern_ValidPattern_ReturnsTrue()
	{
		ClassicAssert.IsTrue(_task.WordPattern("abba", "dog cat cat dog"));
	}

	[Test]
	public void WordPattern_InvalidPattern_ReturnsFalse()
	{
		ClassicAssert.IsFalse(_task.WordPattern("abba", "dog cat cat fish"));
	}

	[Test]
	public void WordPattern_LengthMismatch_ReturnsFalse()
	{
		ClassicAssert.IsFalse(_task.WordPattern("aaaa", "dog cat cat dog"));
	}

	[Test]
	public void WordPattern_OneToManyMapping_ReturnsFalse()
	{
		ClassicAssert.IsFalse(_task.WordPattern("abba", "dog dog dog dog"));
	}

	[Test]
	public void WordPattern_SingleCharacter_ReturnsTrue()
	{
		ClassicAssert.IsTrue(_task.WordPattern("a", "dog"));
	}
}
