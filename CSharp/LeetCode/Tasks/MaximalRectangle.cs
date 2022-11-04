namespace LeetCode.Tasks;

public class MaximalRectangleTask
{
	public int MaximalRectangle(char[][] matrix)
	{
		var max = 0;
		var visited = new HashSet<(int, int)>();
		for (var y = 0; y < matrix.Length; y++)
		{
			for (var x = 0; x < matrix[y].Length; x++)
			{
				if (visited.Add((x, y)) && IsMarked(x, y))
				{
					max = Math.Max(GrowRectangle(x, y, x, y, true, true), max);
				}
			}
		}

		return max;

		bool IsMarked(int x, int y)
		{
			if (y >= matrix.Length) return false;
			if (x >= matrix[y].Length) return false;
			return matrix[y][x] == '1';
		}

		bool AllMarked(int x1, int y1, int x2, int y2)
		{
			for (var y = y1; y <= y2; y++)
			{
				for (var x = x1; x <= x2; x++)
				{
					if (!IsMarked(x, y))
					{
						return false;
					}
				}
			}

			return true;
		}

		int GrowRectangle(int x1, int y1, int x2, int y2, bool tryX, bool tryY)
		{
			var canGrowX = AllMarked(x2 + 1, y1, x2 + 1, y2);
			var canGrowY = AllMarked(x1, y2 + 1, x2, y2 + 1);

			var max = (x2 - x1 + 1) * (y2 - y1 + 1);
			if (canGrowX)
			{
				max = Math.Max(GrowRectangle(x1, y1, x2 + 1, y2, true, canGrowY), max);
				MarkVisited(x2 + 1, y1, x2 + 1, y2);
			}

			if (canGrowY)
			{
				max = Math.Max(GrowRectangle(x1, y1, x2, y2 + 1, canGrowX, true), max);
				MarkVisited(x1, y2 + 1, x2, y2 + 1);
			}

			return max;
		}

		void MarkVisited(int x1, int y1, int x2, int y2)
		{
			for (var y = y1; y <= y2; y++)
			{
				for (var x = x1; x <= x2; x++)
				{
					visited.Add((x, y));
				}
			}
		}
	}

	public char[][] ReadTestData(string file)
	{
		var f = File.OpenText(file);
		var d = f.ReadLine()!
		         .Trim('[', ']')
		         .Replace("],[", "$")
		         .Split('$')
		         .Select(x => x.Trim('[', ']').Split(',').Select(x => x.Trim('"')[0]).ToArray())
		         .ToArray();
		
		return d;
	}
}