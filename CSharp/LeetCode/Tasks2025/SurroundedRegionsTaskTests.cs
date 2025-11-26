using NUnit.Framework;
using FluentAssertions;

namespace LeetCode.Tasks2025;

public class SurroundedRegionsTaskTests
{
    private static char[][] CreateBoard(string[] rows)
    {
        return rows.Select(r => r.ToCharArray()).ToArray();
    }

    private static bool BoardsEqual(char[][] board1, char[][] board2)
    {
        if (board1.Length != board2.Length) return false;
        for (int i = 0; i < board1.Length; i++)
        {
            if (board1[i].Length != board2[i].Length) return false;
            for (int j = 0; j < board1[i].Length; j++)
            {
                if (board1[i][j] != board2[i][j]) return false;
            }
        }
        return true;
    }

    [Test]
    public void Test_SimpleSurroundedRegion()
    {
        var task = new SurroundedRegionsTask();
        var board = CreateBoard([
            "XXXX",
            "XOOX",
            "XXXX"
        ]);

        task.Solve(board);

        var expected = CreateBoard([
            "XXXX",
            "XXXX",
            "XXXX"
        ]);

        BoardsEqual(board, expected).Should().BeTrue("All O's should become X's");
    }

    [Test]
    public void Test_RegionTouchingBorder()
    {
        var task = new SurroundedRegionsTask();
        var board = CreateBoard([
            "XOXX",
            "XOOX",
            "XXXX"
        ]);

        task.Solve(board);

        var expected = CreateBoard([
            "XOXX",
            "XOOX",
            "XXXX"
        ]);

        BoardsEqual(board, expected).Should().BeTrue("O's touching border should remain O's");
    }

    [Test]
    public void Test_LeetCodeExample1()
    {
        var task = new SurroundedRegionsTask();
        var board = CreateBoard([
            "XXXX",
            "XOOX",
            "XXOX",
            "XOXX"
        ]);

        task.Solve(board);

        var expected = CreateBoard([
            "XXXX",
            "XXXX",
            "XXXX",
            "XOXX"
        ]);

        BoardsEqual(board, expected).Should().BeTrue("Surrounded regions should be captured");
    }

    [Test]
    public void Test_SingleCell()
    {
        var task = new SurroundedRegionsTask();
        var board = CreateBoard(["X"]);

        task.Solve(board);

        var expected = CreateBoard(["X"]);

        BoardsEqual(board, expected).Should().BeTrue("Single cell should remain unchanged");
    }

    [Test]
    public void Test_AllOsTouchingBorder()
    {
        var task = new SurroundedRegionsTask();
        var board = CreateBoard([
            "OOO",
            "OOO",
            "OOO"
        ]);

        task.Solve(board);

        var expected = CreateBoard([
            "OOO",
            "OOO",
            "OOO"
        ]);

        BoardsEqual(board, expected).Should().BeTrue("All O's touching border should remain O's");
    }

    [Test]
    public void Test_ComplexConnectedRegionTouchingBorder()
    {
        var task = new SurroundedRegionsTask();
        var board = CreateBoard([
            "OXXXXX",
            "OOXXXX",
            "XOOOXO",
            "XXXXXO"
        ]);

        task.Solve(board);

        var expected = CreateBoard([
            "OXXXXX",
            "OOXXXX",
            "XOOOXO",
            "XXXXXO"
        ]);

        BoardsEqual(board, expected).Should().BeTrue("All O's connected to border should remain O's");
    }

    [Test]
    public void Test_LargeSurroundedRegion()
    {
        var task = new SurroundedRegionsTask();
        var board = CreateBoard([
            "XXXXXX",
            "XOOOOX",
            "XOOOOX",
            "XOOOOX",
            "XXXXXX"
        ]);

        task.Solve(board);

        var expected = CreateBoard([
            "XXXXXX",
            "XXXXXX",
            "XXXXXX",
            "XXXXXX",
            "XXXXXX"
        ]);

        BoardsEqual(board, expected).Should().BeTrue("Large surrounded region should be captured");
    }

    [Test]
    public void Test_SingleOSurrounded()
    {
        var task = new SurroundedRegionsTask();
        var board = CreateBoard([
            "XXX",
            "XOX",
            "XXX"
        ]);

        task.Solve(board);

        var expected = CreateBoard([
            "XXX",
            "XXX",
            "XXX"
        ]);

        BoardsEqual(board, expected).Should().BeTrue("Single surrounded O should become X");
    }

    [Test]
    public void Test_NoOs()
    {
        var task = new SurroundedRegionsTask();
        var board = CreateBoard([
            "XXX",
            "XXX",
            "XXX"
        ]);

        task.Solve(board);

        var expected = CreateBoard([
            "XXX",
            "XXX",
            "XXX"
        ]);

        BoardsEqual(board, expected).Should().BeTrue("Board with no O's should remain unchanged");
    }

    [Test]
    public void Test_MixedRegionsWithBorderConnection()
    {
        var task = new SurroundedRegionsTask();
        var board = CreateBoard([
            "XXXX",
            "XOOX",
            "XXOX",
            "XOXX"
        ]);

        task.Solve(board);

        var expected = CreateBoard([
            "XXXX",
            "XXXX",
            "XXXX",
            "XOXX"
        ]);

        BoardsEqual(board, expected).Should().BeTrue("O at bottom touches border, middle O's should be captured");
    }
}

