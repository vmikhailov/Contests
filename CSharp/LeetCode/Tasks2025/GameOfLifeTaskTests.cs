using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks2025;

[TestFixture]
public class GameOfLifeTaskTests
{
    private GameOfLifeTask _task = null!;

    [SetUp]
    public void SetUp() => _task = new GameOfLifeTask();

    [Test]
    public void GameOfLife_Example1_ReturnsCorrectNextState()
    {
        var board = new int[][]
        {
            [0, 1, 0],
            [0, 0, 1],
            [1, 1, 1],
            [0, 0, 0]
        };

        _task.GameOfLife(board);

        board.Should().BeEquivalentTo(new int[][]
        {
            [0, 0, 0],
            [1, 0, 1],
            [0, 1, 1],
            [0, 1, 0]
        });
    }

    [Test]
    public void GameOfLife_Example2_ReturnsCorrectNextState()
    {
        var board = new int[][]
        {
            [1, 1],
            [1, 0]
        };

        _task.GameOfLife(board);

        board.Should().BeEquivalentTo(new int[][]
        {
            [1, 1],
            [1, 1]
        });
    }

    [Test]
    public void GameOfLife_SingleCell_Dies()
    {
        var board = new int[][]
        {
            [1]
        };

        _task.GameOfLife(board);

        board.Should().BeEquivalentTo(new int[][]
        {
            [0]
        });
    }

    [Test]
    public void GameOfLife_AllDead_StaysDead()
    {
        var board = new int[][]
        {
            [0, 0, 0],
            [0, 0, 0],
            [0, 0, 0]
        };

        _task.GameOfLife(board);

        board.Should().BeEquivalentTo(new int[][]
        {
            [0, 0, 0],
            [0, 0, 0],
            [0, 0, 0]
        });
    }

    [Test]
    public void GameOfLife_Block_StaysStable()
    {
        var board = new int[][]
        {
            [0, 0, 0, 0],
            [0, 1, 1, 0],
            [0, 1, 1, 0],
            [0, 0, 0, 0]
        };

        _task.GameOfLife(board);

        board.Should().BeEquivalentTo(new int[][]
        {
            [0, 0, 0, 0],
            [0, 1, 1, 0],
            [0, 1, 1, 0],
            [0, 0, 0, 0]
        });
    }

    [Test]
    public void GameOfLife_Blinker_Oscillates()
    {
        var board = new int[][]
        {
            [0, 0, 0, 0, 0],
            [0, 0, 1, 0, 0],
            [0, 0, 1, 0, 0],
            [0, 0, 1, 0, 0],
            [0, 0, 0, 0, 0]
        };

        _task.GameOfLife(board);

        board.Should().BeEquivalentTo(new int[][]
        {
            [0, 0, 0, 0, 0],
            [0, 0, 0, 0, 0],
            [0, 1, 1, 1, 0],
            [0, 0, 0, 0, 0],
            [0, 0, 0, 0, 0]
        });
    }

    [Test]
    public void GameOfLife_Glider_Moves()
    {
        var board = new int[][]
        {
            [0, 1, 0, 0, 0],
            [0, 0, 1, 0, 0],
            [1, 1, 1, 0, 0],
            [0, 0, 0, 0, 0],
            [0, 0, 0, 0, 0]
        };

        _task.GameOfLife(board);

        board.Should().BeEquivalentTo(new int[][]
        {
            [0, 0, 0, 0, 0],
            [1, 0, 1, 0, 0],
            [0, 1, 1, 0, 0],
            [0, 1, 0, 0, 0],
            [0, 0, 0, 0, 0]
        });
    }

    [Test]
    public void GameOfLife_Underpopulation_CellDies()
    {
        var board = new int[][]
        {
            [0, 0, 0],
            [0, 1, 0],
            [0, 0, 0]
        };

        _task.GameOfLife(board);

        board.Should().BeEquivalentTo(new int[][]
        {
            [0, 0, 0],
            [0, 0, 0],
            [0, 0, 0]
        });
    }

    [Test]
    public void GameOfLife_TwoNeighbors_CellSurvives()
    {
        var board = new int[][]
        {
            [1, 1, 0],
            [0, 1, 0],
            [0, 0, 0]
        };

        _task.GameOfLife(board);

        board.Should().BeEquivalentTo(new int[][]
        {
            [1, 1, 0],
            [1, 1, 0],
            [0, 0, 0]
        });
    }

    [Test]
    public void GameOfLife_ThreeNeighbors_DeadCellBecomesAlive()
    {
        var board = new int[][]
        {
            [1, 1, 0],
            [1, 0, 0],
            [0, 0, 0]
        };

        _task.GameOfLife(board);

        board.Should().BeEquivalentTo(new int[][]
        {
            [1, 1, 0],
            [1, 1, 0],
            [0, 0, 0]
        });
    }

    [Test]
    public void GameOfLife_Overpopulation_CellDies()
    {
        var board = new int[][]
        {
            [1, 1, 1],
            [1, 1, 1],
            [1, 1, 1]
        };

        _task.GameOfLife(board);

        board.Should().BeEquivalentTo(new int[][]
        {
            [1, 0, 1],
            [0, 0, 0],
            [1, 0, 1]
        });
    }

    [Test]
    public void GameOfLife_SingleRow_HandlesCorrectly()
    {
        var board = new int[][]
        {
            [1, 1, 1]
        };

        _task.GameOfLife(board);

        board.Should().BeEquivalentTo(new int[][]
        {
            [0, 1, 0]
        });
    }

    [Test]
    public void GameOfLife_SingleColumn_HandlesCorrectly()
    {
        var board = new int[][]
        {
            [1],
            [1],
            [1]
        };

        _task.GameOfLife(board);

        board.Should().BeEquivalentTo(new int[][]
        {
            [0],
            [1],
            [0]
        });
    }

    [Test]
    public void GameOfLife_LargeEmptyBoard_StaysDead()
    {
        var board = new int[][]
        {
            [0, 0, 0, 0, 0],
            [0, 0, 0, 0, 0],
            [0, 0, 0, 0, 0],
            [0, 0, 0, 0, 0],
            [0, 0, 0, 0, 0]
        };

        _task.GameOfLife(board);

        board.Should().BeEquivalentTo(new int[][]
        {
            [0, 0, 0, 0, 0],
            [0, 0, 0, 0, 0],
            [0, 0, 0, 0, 0],
            [0, 0, 0, 0, 0],
            [0, 0, 0, 0, 0]
        });
    }

    [Test]
    public void GameOfLife_CornerCells_HandlesCorrectly()
    {
        var board = new int[][]
        {
            [1, 0, 1],
            [0, 0, 0],
            [1, 0, 1]
        };

        _task.GameOfLife(board);

        board.Should().BeEquivalentTo(new int[][]
        {
            [0, 0, 0],
            [0, 0, 0],
            [0, 0, 0]
        });
    }

    [Test]
    public void GameOfLife_EdgeCells_HandlesCorrectly()
    {
        var board = new int[][]
        {
            [0, 1, 0],
            [0, 1, 0],
            [0, 1, 0]
        };

        _task.GameOfLife(board);

        board.Should().BeEquivalentTo(new int[][]
        {
            [0, 0, 0],
            [1, 1, 1],
            [0, 0, 0]
        });
    }
}
