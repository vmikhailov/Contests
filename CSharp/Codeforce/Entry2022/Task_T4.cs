using System.Collections;
using NUnit.Framework;

namespace Codewars.Entry2022;

public class Task_T4
{
	public static void Run()
	{
		var n = int.Parse(Console.ReadLine()!);
		var coords = new List<(int X, int Y)>();
		var polars = new List<(double R, double A, int N)>();

		for (var i = 0; i < n; i++)
		{
			var l = Console.ReadLine()!.Split(" ").Select(int.Parse).ToList();
			coords.Add((l[0], l[1]));
		}

		var xx = coords.Select(x => x.X).Average();
		var yy = coords.Select(x => x.Y).Average();

		for (var i = 0; i < n; i++)
		{
			var x = coords[i].X - xx;
			var y = coords[i].Y - yy;

			var r = Math.Sqrt(x * x + y * y);
			var a = Math.Asin(x / r);
			polars.Add((r, a, i));
		}

		var figure = polars.OrderBy(x => x.A).ToList();
		var nf = figure.Count();

		var k = 0;
		while (k < nf)
		{
			if (!AnglesIsLess180(coords, figure, k++, nf, xx, yy))
			{
				figure.RemoveAt(k % nf);
				nf--;
				k--;
			}
		}
	}

	private static bool AnglesIsLess180(
		List<(int X, int Y)> coords,
		List<(double R, double A, int N)> figure,
		int i,
		int n,
		double xx,
		double yy)
	{
		var c1 = coords[figure[i % n].N];
		var c2 = coords[figure[(i + 1) % n].N];
		var c3 = coords[figure[(i + 2) % n].N];

		double k;
		if (c3.Y - c1.Y != 0)
		{
			// a(y)
			var q = (c3.X - c1.X) / (double)(c1.Y - c3.Y);
			var sn = (c2.X - xx) + (c2.Y - yy) * q;
			if (sn == 0) return false; // c(x) + c(y)*q

			var fn = (c2.X - c1.X) + (c2.Y - c1.Y) * q; // b(x) + b(y)*q
			k = fn / sn;
		}
		else
		{
			if (c2.Y - yy == 0) return false; // b(y)
		}

		return true;
	}
}