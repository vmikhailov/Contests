using LeetCode.Tasks2025;

var task = new GameOfLifeTask();

// Test: Single cell dies
var board1 = new[] { new[] { 1 } };
task.GameOfLife(board1);
Console.WriteLine($"Test 1 (Single cell dies): {board1[0][0]} (expected: 0)");

// Test: Block stays stable
var board2 = new[]
{
	new[] { 0, 0, 0, 0 },
	new[] { 0, 1, 1, 0 },
	new[] { 0, 1, 1, 0 },
	new[] { 0, 0, 0, 0 }
};
task.GameOfLife(board2);
Console.WriteLine($"Test 2 (Block): [{board2[1][1]}, {board2[1][2]}, {board2[2][1]}, {board2[2][2]}] (expected: [1, 1, 1, 1])");

// Test: Example 1
var board3 = new[]
{
	new[] { 0, 1, 0 },
	new[] { 0, 0, 1 },
	new[] { 1, 1, 1 },
	new[] { 0, 0, 0 }
};
task.GameOfLife(board3);
Console.WriteLine("Test 3 (Example 1):");
for (var i = 0; i < board3.Length; i++)
{
	Console.WriteLine($"  [{string.Join(", ", board3[i])}]");
}
Console.WriteLine("Expected:");
Console.WriteLine("  [0, 0, 0]");
Console.WriteLine("  [1, 0, 1]");
Console.WriteLine("  [0, 1, 1]");
Console.WriteLine("  [0, 1, 0]");

Console.WriteLine("\n✓ Manual tests completed");

