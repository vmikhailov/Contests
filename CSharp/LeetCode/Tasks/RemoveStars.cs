namespace CodeForcesSimple.LeetCode;

public class RemoveStars
{
	public static string Remove(string str)
	{
		var chars = str.ToCharArray();
		var idx = Enumerable.Range(0, chars.Length).ToArray();
		var i = 0;

		while (true)
		{
			while (i < chars.Length && chars[i] != '*') i++;
			if (i == chars.Length) break;

			chars[i] = (char)0;
			if (i > 0)
			{
				var p = idx[i - 1];
				while (p >= 0 && chars[p] == 0)
				{
					p = idx[p];
				}

				chars[p] = (char)0;
				idx[i] = p - 1;
			}
		}

		return new(chars.Where(x => x != 0).ToArray());
	}
}