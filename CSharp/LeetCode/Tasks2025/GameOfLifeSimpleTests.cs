using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks2025;

[TestFixture]
public class GameOfLifeSimpleTests
{
	[Test]
	public void Test_SingleCellDies()
	{
		var task = new GameOfLifeTask();
		var board = new[] { new[] { 1 } };

		task.GameOfLife(board);

		Console.WriteLine($"Result: {board[0][0]}");
		board[0][0].Should().Be(0);
	}

	[Test]
	public void Test_Example1()
	{
		var task = new GameOfLifeTask();
		var board = new[]
		{
			new[] { 0, 1, 0 },
			new[] { 0, 0, 1 },
			new[] { 1, 1, 1 },
			new[] { 0, 0, 0 }
		};

		Console.WriteLine("Before:");
		PrintBoard(board);

		task.GameOfLife(board);

		Console.WriteLine("After:");
		PrintBoard(board);

		Console.WriteLine("Expected:");
		Console.WriteLine("[0, 0, 0]");
		Console.WriteLine("[1, 0, 1]");
		Console.WriteLine("[0, 1, 1]");
		Console.WriteLine("[0, 1, 0]");
	}

	private void PrintBoard(int[][] board)
	{
		foreach (var row in board)
		{
			Console.WriteLine($"[{string.Join(", ", row)}]");
		}
	}
}

