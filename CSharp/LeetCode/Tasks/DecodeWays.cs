namespace CodeForcesSimple.LeetCode;

public class DecodeWays
{
	public static int Decode(string s)
	{
		int Decode(string s, int i)
		{
			if (i < 0)
			{
				return 0;
			}
			
			var d = s[i] - '0';

			var f = Decode(s, i - 1);
			if (f >= 0)
			{
				return d + f * 10;
			}

			if (i == 0)
			{
				return -1;
			}
			
			d += (s[i - 1] - '0') * 10;
			if (d > 26)
			{
				return -1;
			}

			f = Decode(s, i - 2);
			if (f >= 0)
			{
				return d + f * 100;
			}

			return -1;
		}

		return Decode(s, s.Length - 1);
	}
}