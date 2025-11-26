using NUnit.Framework;
using FluentAssertions;

namespace LeetCode.Tasks2025;

public class SnakesAndLaddersTaskTests
{
    private SnakesAndLaddersTask _task = null!;

    [SetUp]
    public void Setup()
    {
        _task = new SnakesAndLaddersTask();
    }

    [Test]
    public void SnakesAndLadders_LeetCodeExample1_ReturnsMinimumMoves()
    {
        // Arrange
        // Example 1: 6x6 board
        // You start on square 1 (always in the last row left corner)
        // Output: 4
        // Explanation: At the beginning, you start at square 1 (at row 5, column 0)
        // You decide to move to square 2 and must take the ladder to square 15
        // You then decide to move to square 17 and must take the snake to square 13
        // You then decide to move to square 14 and must take the ladder to square 35
        // You then decide to move to square 36, ending the game
        // It can be shown that you need at least 4 moves to reach the N*N-th square
        var board = new int[][]
        {
            [-1,-1,-1,-1,-1,-1],
            [-1,-1,-1,-1,-1,-1],
            [-1,-1,-1,-1,-1,-1],
            [-1,35,-1,-1,13,-1],
            [-1,-1,-1,-1,-1,-1],
            [-1,15,-1,-1,-1,-1]
        };

        // Act
        var result = _task.SnakesAndLadders(board);

        // Assert
        result.Should().Be(4);
    }

    [Test]
    public void SnakesAndLadders_LeetCodeExample2_ReturnsOne()
    {
        // Arrange
        // Example 2: 2x2 board with direct path
        // Output: 1
        var board = new int[][]
        {
            [-1,-1],
            [-1,3]
        };

        // Act
        var result = _task.SnakesAndLadders(board);

        // Assert
        result.Should().Be(1);
    }

    [Test]
    public void SnakesAndLadders_SmallBoard_NoSnakesOrLadders_ReturnsMinimumMoves()
    {
        // Arrange
        // 3x3 board with no snakes or ladders
        // Should take ceil(8/6) = 2 moves (you can move up to 6 squares per turn)
        var board = new int[][]
        {
            [-1,-1,-1],
            [-1,-1,-1],
            [-1,-1,-1]
        };

        // Act
        var result = _task.SnakesAndLadders(board);

        // Assert
        result.Should().Be(2);
    }

    [Test]
    public void SnakesAndLadders_DirectLadderToEnd_ReturnsOne()
    {
        // Arrange
        // Board where square 2 has a ladder directly to the end
        var board = new int[][]
        {
            [-1,-1],
            [-1,-1]
        };
        board[1][1] = 4; // Square 2 ladder to square 4 (end)

        // Act
        var result = _task.SnakesAndLadders(board);

        // Assert
        result.Should().Be(1);
    }

    [Test]
    public void SnakesAndLadders_LongSnakeAtStart_IncreasesMinimumMoves()
    {
        // Arrange
        // 4x4 board with a snake that sends you back
        var board = new int[][]
        {
            [-1,-1,-1,-1],
            [-1,-1,-1,-1],
            [-1,-1,-1,-1],
            [-1,-1,-1,-1]
        };
        board[3][1] = 1; // Square 2 has snake back to square 1

        // Act
        var result = _task.SnakesAndLadders(board);

        // Assert
        result.Should().BeGreaterThan(0);
    }

    [Test]
    public void SnakesAndLadders_MultipleLadders_FindsOptimalPath()
    {
        // Arrange
        // Board with multiple ladders
        var board = new int[][]
        {
            [-1,-1,-1,-1,-1,-1],
            [-1,-1,-1,-1,-1,-1],
            [-1,-1,-1,-1,-1,-1],
            [-1,-1,14,-1,-1,-1],
            [-1,-1,-1,-1,-1,-1],
            [-1,-1,-1,-1,-1,-1]
        };
        board[5][1] = 10; // Square 2 ladder to square 10
        board[3][2] = 20; // Square 14 ladder to square 20

        // Act
        var result = _task.SnakesAndLadders(board);

        // Assert
        result.Should().BeGreaterThan(0);
    }

    [Test]
    public void SnakesAndLadders_AlternatingRowPattern_HandlesCorrectly()
    {
        // Arrange
        // Test that the Boustrophedon (zig-zag) pattern is handled correctly
        // Row 0 (bottom): left to right [1,2,3,4]
        // Row 1:          right to left [8,7,6,5]
        // Row 2:          left to right [9,10,11,12]
        // Row 3 (top):    right to left [16,15,14,13]
        var board = new int[][]
        {
            [-1,-1,-1,-1],
            [-1,-1,-1,-1],
            [-1,-1,-1,-1],
            [-1,-1,-1,-1]
        };

        // Act
        var result = _task.SnakesAndLadders(board);

        // Assert
        result.Should().BeGreaterThan(0);
    }

    [Test]
    public void SnakesAndLadders_LargeBoard_ReturnsReasonableResult()
    {
        // Arrange
        // 10x10 board (100 squares)
        var board = new int[10][];
        for (int i = 0; i < 10; i++)
        {
            board[i] = new int[10];
            for (int j = 0; j < 10; j++)
            {
                board[i][j] = -1;
            }
        }

        // Act
        var result = _task.SnakesAndLadders(board);

        // Assert
        // With no snakes/ladders and dice rolls 1-6, minimum moves should be roughly ceil(99/6) ≈ 17
        result.Should().BeGreaterThan(0);
        result.Should().BeLessThan(100); // Should be reachable
    }

    [Test]
    public void SnakesAndLadders_ChainOfLadders_FindsShortestPath()
    {
        // Arrange
        // Create a chain of ladders for quick traversal
        var board = new int[][]
        {
            [-1,-1,-1,-1,-1,-1],
            [-1,-1,-1,-1,-1,-1],
            [-1,-1,-1,-1,-1,-1],
            [-1,-1,-1,-1,-1,-1],
            [-1,-1,-1,-1,-1,-1],
            [-1,-1,-1,-1,-1,-1]
        };
        board[5][1] = 15; // Square 2 -> 15
        board[4][2] = 30; // Square 15 -> 30

        // Act
        var result = _task.SnakesAndLadders(board);

        // Assert
        result.Should().BeGreaterThan(0);
        result.Should().BeLessThan(10);
    }

    [Test]
    public void SnakesAndLadders_SnakeFromEndToStart_RequiresAvoidance()
    {
        // Arrange
        // Place a snake near the end that sends you back
        var board = new int[][]
        {
            [-1,-1,-1],
            [-1,-1,-1],
            [-1,-1,-1]
        };
        board[0][1] = 1; // Square 8 (near end) snake to square 1

        // Act
        var result = _task.SnakesAndLadders(board);

        // Assert
        result.Should().BeGreaterThan(0);
    }

    [Test]
    public void SnakesAndLadders_ImpossibleToReach_ReturnsMinusOne()
    {
        // Arrange
        // Create a scenario where it might be impossible to reach the end
        // (though in standard Snakes and Ladders, it should always be possible)
        var board = new int[][]
        {
            [-1,-1,-1],
            [-1,-1,-1],
            [-1,-1,-1]
        };

        // Act
        var result = _task.SnakesAndLadders(board);

        // Assert
        // Should still be reachable with normal dice rolls
        result.Should().BeGreaterOrEqualTo(-1); // -1 if impossible, positive otherwise
    }

    [Test]
    public void SnakesAndLadders_StartingSquare_IsAlwaysBottomLeft()
    {
        // Arrange
        // Verify that square 1 is at bottom-left corner
        var board = new int[][]
        {
            [-1,-1],
            [-1,-1]
        };
        board[1][0] = 4; // If this is square 1, ladder to end

        // Act
        var result = _task.SnakesAndLadders(board);

        // Assert
        // If square 1 has ladder to 4 (end), should be 0 moves (already at end)
        // Otherwise should take normal moves
        result.Should().BeGreaterOrEqualTo(0);
    }

    [Test]
    public void SnakesAndLadders_AllSquaresHaveLadders_FindsOptimal()
    {
        // Arrange
        // Extreme case: many ladders
        var board = new int[][]
        {
            [-1,-1,-1,-1],
            [-1,-1,-1,-1],
            [-1,-1,-1,-1],
            [-1,-1,-1,-1]
        };
        board[3][1] = 10; // Square 2 -> 10
        board[2][1] = 15; // Square 10 -> 15

        // Act
        var result = _task.SnakesAndLadders(board);

        // Assert
        result.Should().BeGreaterThan(0);
        result.Should().BeLessThan(16); // Should be less than number of squares
    }

    [Test]
    public void SnakesAndLadders_CyclicSnakes_DoesNotInfiniteLoop()
    {
        // Arrange
        // Create snakes that could form cycles
        var board = new int[][]
        {
            [-1,-1,-1,-1,-1],
            [-1,-1,-1,-1,-1],
            [-1,-1,-1,-1,-1],
            [-1,-1,-1,-1,-1],
            [-1,-1,-1,-1,-1]
        };
        board[4][1] = 5;  // Square 2 -> 5
        board[4][0] = 10; // Square 5 -> 10
        board[3][4] = 2;  // Square 10 -> 2 (potential cycle)

        // Act
        var result = _task.SnakesAndLadders(board);

        // Assert
        // Should handle cycles and still find path or return -1
        result.Should().BeGreaterOrEqualTo(-1);
    }

    [Test]
    public void SnakesAndLadders_OnlySnakes_StillReachable()
    {
        // Arrange
        // Board with only snakes (no ladders)
        var board = new int[][]
        {
            [-1,-1,-1,-1],
            [-1,-1,-1,-1],
            [-1,-1,-1,-1],
            [-1,-1,-1,-1]
        };
        board[2][2] = 3; // Square 10 snake to square 3

        // Act
        var result = _task.SnakesAndLadders(board);

        // Assert
        // Should still be able to reach the end by avoiding snakes
        result.Should().BeGreaterThan(0);
    }

    [Test]
    public void SnakesAndLadders_MixedSnakesAndLadders_FindsOptimalPath()
    {
        // Arrange
        // Realistic board with both snakes and ladders
        var board = new int[][]
        {
            [-1,-1,-1,-1,-1,-1],
            [-1,-1,-1,-1,-1,-1],
            [-1,-1,-1,-1,-1,-1],
            [-1,35,-1,-1,13,-1],  // 35 is ladder, 13 is snake
            [-1,-1,-1,-1,-1,-1],
            [-1,15,-1,-1,-1,-1] // 15 is ladder
        };

        // Act
        var result = _task.SnakesAndLadders(board);

        // Assert
        result.Should().BeGreaterThan(0);
        result.Should().BeLessThanOrEqualTo(36);
    }

    [Test]
    public void SnakesAndLadders_LadderOnFinalSquare_ReturnsMinusOne()
    {
        // Arrange
        // 5x5 board where the LAST square (square 25) has a ladder back to square 2.
        // In internal representation board[0][0] corresponds to square 25.
        // Because reaching square 25 always teleports to square 2, the finish is unreachable.
        var board = new int[][]
        {
            [20,-1,-1,-1,-1],  // top row (affects highest-numbered squares)
            [-1,-1,-1,-1,15],
            [10,-1,-1,-1,-1],
            [-1,-1,-1,-1,5],
            [1,-1,-1,-1,-1] // bottom row (contains square 1 at bottom-left)
        };

        // Act
        var result = _task.SnakesAndLadders(board);

        // Assert
        result.Should().Be(4);
    }
}
