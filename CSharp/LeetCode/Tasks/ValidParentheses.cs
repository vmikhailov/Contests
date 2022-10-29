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