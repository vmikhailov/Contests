namespace Codewars.Entry2022;

public class Task_H2
{
	public static void Run()
	{
		var n = int.Parse(Console.ReadLine()!);
		var p = Console.ReadLine()!.Split(" ").Select(long.Parse).ToArray();
		var change = true;
		while (change)
		{
			change = false;
			for (var i = 0; i < n - 1 && !change; i++)
			{
				if (p[i] == i + 1 || p[i + 1] == i + 2 || p[i] <= p[i + 1]) continue;

				var canChange = p[i] != i + 2 && p[i + 1] != i + 1;
				if (!canChange && p[i] == i + 2 && p.Skip(i + 2).All(x => x > i + 2))
				{
					canChange = true;
				}

				if (!canChange && p[i + 1] == i + 1 && p.Take(i).All(x => x < i + 1))
				{
					canChange = true;
				}

				if (canChange)
				{
					var s = p[i];
					p[i] = p[i + 1];
					p[i + 1] = s;
					Console.WriteLine($"{i + 1} {i + 2}");
					change = true;
				}
			}
		}
	}
	
	public static void RunTest()
	{
		var r = new Random();
		var n = r.Next(100) + 1;

		var used = new HashSet<int>();
		for (var i = 0; i < n; i++)
		{
			var v = r.Next(n) + 1;
			if(i + 1 == v || !used.Add(v)) continue;
			//if()
		}
		
	}
}