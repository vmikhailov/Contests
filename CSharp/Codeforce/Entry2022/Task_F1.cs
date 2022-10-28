namespace Codewars.Entry2022;

public class Task_F1
{
	public static void Run()
	{
		var n = int.Parse(Console.ReadLine()!);
		var p = Console.ReadLine()!.Split(" ").Select(long.Parse).ToArray();
		var fix = false;

		for (var i = 0; i <= n; i++)
		{
			if (i < n && p[i] == -1)
			{
				p[i] = (i > 0 ? p[i - 1] : 0) + 1;
				fix = i > 1 && i < n - 2;
			}
			else if (fix)
			{
				p[i - 1] = p[i] - p[i - 2];
			}

			if (i < n && p[i] <= (i > 0 ? p[i - 1] : 0))
			{
				Console.WriteLine("NO");
				return;
			}
		}

		Console.WriteLine("YES");
		var s = 0L;
		for (var i = 0; i < n; i++)
		{
			Console.Write($"{p[i] - s} ");
			s = p[i];
		}
	}
}