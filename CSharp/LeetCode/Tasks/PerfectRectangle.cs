namespace LeetCode.Tasks;

public class PerfectRectangle
{
	public bool IsRectangleCover(int[][] rectangles)
	{
		var xx = rectangles.Select(x => x[0]).Union(rectangles.Select(x => x[2])).Distinct().OrderBy(x => x).ToArray();
		var yy = rectangles.Select(x => x[1]).Union(rectangles.Select(x => x[3])).Distinct().OrderBy(x => x).ToArray();
		
		var s = (xx.Length - 1) * (yy.Length - 1);

		var field = new int[]?[yy.Length];

		foreach (var r in rectangles)
		{
			var x1 = Array.BinarySearch(xx, Math.Min(r[0], r[2]));
			var x2 = Array.BinarySearch(xx, Math.Max(r[0], r[2]));
			
			var y1 = Array.BinarySearch(yy, Math.Min(r[1], r[3]));
			var y2 = Array.BinarySearch(yy, Math.Max(r[1], r[3]));
			
			for (var y = y1; y < y2; y++)
			{
				for (var x = x1; x < x2; x++)
				{
					var row = field[y];
					if (row == null) field[y] = row = new int[xx.Length];
					if (row[x] != 0) return false;
					row[x] = 1;
					s--;
				}
			}
			
			//Print(field);
		}

		return s == 0;
	}

	public int[][] ReadTestData(string file)
	{
		var f = File.OpenText(file);
		var d = f.ReadLine()!
		         .Trim('[', ']')
		         .Replace("],[", "$")
		         .Split('$')
		         .Select(x => x.Trim('[', ']').Split(',').Select(int.Parse).ToArray())
		         .ToArray();
		
		return d;
	}
	
	private void Print(int[]?[] field)
	{
		foreach (var row in field)
		{
			if (row != null)
			{
				Console.Write(string.Join(" ", row));
			}
			Console.WriteLine();
		}
		Console.WriteLine();
	}
}