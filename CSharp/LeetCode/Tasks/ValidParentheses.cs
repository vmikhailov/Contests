using FluentAssertions;
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
		ValidParentheses.IsValid("()").Should().BeTrue();
		ValidParentheses.IsValid("()[]{}").Should().BeTrue();
	}

	[Test]
	public void IsValid_NestedParentheses_ReturnsTrue()
	{
		ValidParentheses.IsValid("{[]}").Should().BeTrue();
		ValidParentheses.IsValid("([{}])").Should().BeTrue();
	}

	[Test]
	public void IsValid_MismatchedParentheses_ReturnsFalse()
	{
		ValidParentheses.IsValid("(]").Should().BeFalse();
		ValidParentheses.IsValid("([)]").Should().BeFalse();
	}

	[Test]
	public void IsValid_UnclosedParentheses_ReturnsFalse()
	{
		ValidParentheses.IsValid("(").Should().BeFalse();
		ValidParentheses.IsValid("((").Should().BeFalse();
	}

	[Test]
	public void IsValid_ExtraClosing_ReturnsFalse()
	{
		ValidParentheses.IsValid(")").Should().BeFalse();
		ValidParentheses.IsValid("())").Should().BeFalse();
	}

	[Test]
	public void IsValid_EmptyString_ReturnsTrue()
	{
		ValidParentheses.IsValid("").Should().BeTrue();
	}
}
