namespace Codewars.Entry2022;

public class Task_D1
{
	public static void Run()
	{
		var p = Console.ReadLine()!.Split(" ");
		var n = int.Parse(p[0]);
		var t = int.Parse(p[1]);
		var s = Console.ReadLine()!.Split(" ").Select(int.Parse).ToArray();
		var w = new LinkedList<int>();
		var d = new LinkedListNode<int>[n];
		for (var i = 1; i <= n; i++)
		{
			d[i - 1] = w.AddLast(i);
		}

		foreach (var c in s)
		{
			var node = d[c - 1];
			var list = node.List!;
			list.Remove(node);
			list.AddLast(node);
		}

		Console.WriteLine(string.Join(" ", w));
	}
}