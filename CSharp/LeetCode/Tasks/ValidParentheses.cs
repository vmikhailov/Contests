using NUnit.Framework.Legacy;
using NUnit.Framework;

namespace CodeForcesSimple.LeetCode;

public class ValidParentheses
{
	public static bool IsValid(string s) {
		var br = new Stack<int>();
		var braces = new[] { '(', ')', '[', ']', '{', '}' };
		foreach(var c in s)
		{
			var i = Array.IndexOf(braces, c);
			if (i % 2 == 0)
			{
				br.Push(i);
			}
			else
			{
				if(!br.TryPop(out var p) || p != i - 1)
				{
					return false;
				}
			}
		}

		return true;
	}
}

[TestFixture]
public class ValidParenthesesTests
{
	[Test]
	public void IsValid_MatchingParentheses_ReturnsTrue()
	{
		ClassicAssert.IsTrue(ValidParentheses.IsValid("()"));
		ClassicAssert.IsTrue(ValidParentheses.IsValid("()[]{}"));
	}

	[Test]
	public void IsValid_NestedParentheses_ReturnsTrue()
	{
		ClassicAssert.IsTrue(ValidParentheses.IsValid("{[]}"));
		ClassicAssert.IsTrue(ValidParentheses.IsValid("([{}])"));
	}

	[Test]
	public void IsValid_MismatchedParentheses_ReturnsFalse()
	{
		ClassicAssert.IsFalse(ValidParentheses.IsValid("(]"));
		ClassicAssert.IsFalse(ValidParentheses.IsValid("([)]"));
	}

	[Test]
	public void IsValid_UnclosedParentheses_ReturnsFalse()
	{
		ClassicAssert.IsFalse(ValidParentheses.IsValid("("));
		ClassicAssert.IsFalse(ValidParentheses.IsValid("(("));
	}

	[Test]
	public void IsValid_ExtraClosing_ReturnsFalse()
	{
		ClassicAssert.IsFalse(ValidParentheses.IsValid(")"));
		ClassicAssert.IsFalse(ValidParentheses.IsValid("())"));
	}

	[Test]
	public void IsValid_EmptyString_ReturnsTrue()
	{
		ClassicAssert.IsTrue(ValidParentheses.IsValid(""));
	}
}
