namespace Codewars.Entry2022;

public class Task_E1
{
	public static void Run1()
	{
		var s = Console.ReadLine()!;

		var k = 0;
		var i = 0;
		var l = s.Length;
		while (true)
		{
			i++;
			if (2 * i > l) break;

			if (s[i] != '0')
			{
				if (2 * i < l)
				{
					k++;
					continue;
				}

				var less = true;
				for (var j = 0; j < i; j++)
				{
					if (s[j] > s[l - i + j])
					{
						less = false;
						break;
					}

					if (s[j] < s[l - i + j])
					{
						break;
					}
				}

				if (less)
				{
					k++;
				}

				break;
			}
		}

		Console.WriteLine(k);
	}
	
	public static void Run()
	{
		var s = Console.ReadLine()!;

		var k = 0;
		var i = 1;
		var l = s.Length;
		
		if (l % 2 == 0)
		{
			var less = true;
			for (var j = 0; j < l / 2; j++)
			{
				if (s[j] > s[l - i + j])
				{
					less = false;
					break;
				}

				if (s[j] < s[l - i + j])
				{
					break;
				}
			}

			if (less) k++;
		}
		
		while (true)
		{
			if (2 * i >= l) break;
		
			if (s[i] != 0 & 2 * i < l)
			{
				i++;
				k++;
				continue;
			}

			if (s[i] == 0 & 2 * i + 2 < l)
			{
				i += 2;
				k++;
			}
		}

		Console.WriteLine(k);
	}
}