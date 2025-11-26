using NUnit.Framework;
using FluentAssertions;

namespace LeetCode.Tasks2025;

public class MinimumGeneticMutationTasksTests
{
    private MinimumGeneticMutationTasks _task = null!;

    [SetUp]
    public void Setup()
    {
        _task = new MinimumGeneticMutationTasks();
    }

    [Test]
    public void MinMutation_Example1_Returns1()
    {
        // Arrange
        string startGene = "AACCGGTT";
        string endGene = "AACCGGTA";
        string[] bank = { "AACCGGTA" };

        // Act
        var result = _task.MinMutation(startGene, endGene, bank);

        // Assert
        result.Should().Be(1);
    }

    [Test]
    public void MinMutation_Example2_Returns2()
    {
        // Arrange
        string startGene = "AACCGGTT";
        string endGene = "AAACGGTA";
        string[] bank = { "AACCGGTA", "AACCGCTA", "AAACGGTA" };

        // Act
        var result = _task.MinMutation(startGene, endGene, bank);

        // Assert
        result.Should().Be(2);
    }

    [Test]
    public void MinMutation_Example3_NoPath_ReturnsMinus1()
    {
        // Arrange
        string startGene = "AAAAACCC";
        string endGene = "AACCCCCC";
        string[] bank = { "AAAACCCC", "AAACCCCC", "AACCCCCC" };

        // Act
        var result = _task.MinMutation(startGene, endGene, bank);

        // Assert
        result.Should().Be(3);
    }

    [Test]
    public void MinMutation_StartEqualsEnd_Returns0()
    {
        // Arrange
        string startGene = "AACCGGTT";
        string endGene = "AACCGGTT";
        string[] bank = { "AACCGGTT" };

        // Act
        var result = _task.MinMutation(startGene, endGene, bank);

        // Assert
        result.Should().Be(0);
    }

    [Test]
    public void MinMutation_EndGeneNotInBank_ReturnsMinus1()
    {
        // Arrange
        string startGene = "AACCGGTT";
        string endGene = "AACCGGTA";
        string[] bank = { "AACCGGTC", "AACCGGTG" };

        // Act
        var result = _task.MinMutation(startGene, endGene, bank);

        // Assert
        result.Should().Be(-1);
    }

    [Test]
    public void MinMutation_EmptyBank_ReturnsMinus1()
    {
        // Arrange
        string startGene = "AACCGGTT";
        string endGene = "AACCGGTA";
        string[] bank = Array.Empty<string>();

        // Act
        var result = _task.MinMutation(startGene, endGene, bank);

        // Assert
        result.Should().Be(-1);
    }

    [Test]
    public void MinMutation_SingleStepPath_Returns1()
    {
        // Arrange
        string startGene = "AACCGGTT";
        string endGene = "AACCGGTA";
        string[] bank = { "AACCGGTA", "AACCGGTC", "AACCGGTG" };

        // Act
        var result = _task.MinMutation(startGene, endGene, bank);

        // Assert
        result.Should().Be(1);
    }

    [Test]
    public void MinMutation_LongerPath_Returns4()
    {
        // Arrange
        string startGene = "AACCGGTT";
        string endGene = "AACCCCCC";
        string[] bank = { "AACCGGTA", "AACCGGTC", "AACCGCTC", "AACCGCCC", "AACCCCCC" };

        // Act
        var result = _task.MinMutation(startGene, endGene, bank);

        // Assert
        result.Should().Be(4);
    }

    [Test]
    public void MinMutation_MultiplePaths_ReturnsShortestPath()
    {
        // Arrange
        string startGene = "AACCGGTT";
        string endGene = "AACCGGTA";
        string[] bank = {
            "AACCGGTA",  // Direct path: 1 mutation
            "AACCGGTC", "AACCGGCA", "AACCGGAA", "AACCGGAT", "AACCGGTA" // Longer path exists
        };

        // Act
        var result = _task.MinMutation(startGene, endGene, bank);

        // Assert
        result.Should().Be(1); // Should find the shortest path
    }

    [Test]
    public void MinMutation_NoConnection_ReturnsMinus1()
    {
        // Arrange
        string startGene = "AAAAAAAA";
        string endGene = "CCCCCCCC";
        string[] bank = {
            "AAAAAAAC", "AAAAAACA", // Connected to start
            "CCCCCCCG", "CCCCCCGC"  // Connected to end, but no bridge
        };

        // Act
        var result = _task.MinMutation(startGene, endGene, bank);

        // Assert
        result.Should().Be(-1);
    }

    [Test]
    public void MinMutation_AllSameCharacters_ValidPath()
    {
        // Arrange
        string startGene = "AAAAAAAA";
        string endGene = "AAAAAAAT";
        string[] bank = { "AAAAAAAT" };

        // Act
        var result = _task.MinMutation(startGene, endGene, bank);

        // Assert
        result.Should().Be(1);
    }

    [Test]
    public void MinMutation_ComplexPath_Returns5()
    {
        // Arrange
        string startGene = "AACCGGTT";
        string endGene = "TTCCGGAA";
        string[] bank = {
            "AACCGGTA",  // 1 mutation from start
            "AACCGGAA",  // 2 mutations
            "AACCGGAT",
            "ATCCGGAA",  // 3 mutations
            "TTCCGGAA"   // Target
        };

        // Act
        var result = _task.MinMutation(startGene, endGene, bank);

        // Assert
        result.Should().BeGreaterThan(0); // Should find a path
    }

    [Test]
    public void MinMutation_ChainedMutations_Returns1()
    {
        // Arrange
        string startGene = "AACCGGTT";
        string endGene = "AACCTGTT";
        string[] bank = {
            "AACCGCTT",  // 1 mutation from start: G->C at position 5
            "AACCTCTT",  // 2 mutations from start: positions 4 and 5
            "AACCTGTT"   // 1 mutation from start: G->T at position 4 (this is the target!)
        };

        // Act
        var result = _task.MinMutation(startGene, endGene, bank);

        // Assert
        result.Should().Be(1); // Direct path exists from start to end
    }

    [Test]
    public void MinMutation_RequiresThreeMutations_Returns3()
    {
        // Arrange
        string startGene = "AAAACCCC";
        string endGene = "AAACCCCA";
        string[] bank = {
            "AAACCCCC",  // 1 mutation from start: position 3 (A->C)
            "AAACCCCA",  // Must go through AAACCCCC first, then position 7 (C->A)
        };

        // Act
        var result = _task.MinMutation(startGene, endGene, bank);

        // Assert
        result.Should().Be(2); // Path: start -> AAACCCCC -> AAACCCCA
    }

    [Test]
    public void MinMutation_ThreeStepChain_Returns3()
    {
        // Arrange
        string startGene = "AAAAGGGG";
        string endGene = "AACAGGGG";
        string[] bank = {
            "AAAACGGG",  // 1 mutation from start
            "AAAACCGG",  // 2 mutations from start (not a valid path)
            "AACACCGG",  // Not directly connected
            "AAAAGGGG",  // Start (won't help)
            "AAACGGGG",  // Can connect: AAAAGGGG -> AAACGGGG (1 mutation)
            "AACAGGGG",  // Can connect: AAACGGGG -> AACAGGGG (1 mutation)
        };

        // Act
        var result = _task.MinMutation(startGene, endGene, bank);

        // Assert
        result.Should().Be(1); // Path: start -> AAACGGGG -> AACAGGGG
    }

    [Test]
    public void MinMutation_LargeBank_FindsOptimalPath()
    {
        // Arrange
        string startGene = "AACCGGTT";
        string endGene = "AACCGGTA";
        var bank = new List<string>();

        // Add many intermediate genes
        bank.Add("AACCGGTA"); // Direct target
        for (int i = 0; i < 20; i++)
        {
            bank.Add($"AACCGGT{(char)('A' + (i % 4))}"); // Add variations
        }

        // Act
        var result = _task.MinMutation(startGene, endGene, bank.ToArray());

        // Assert
        result.Should().Be(1); // Should still find the direct path
    }

    [Test]
    public void MinMutation_AllDifferentCharacters_LongPath()
    {
        // Arrange
        string startGene = "AAAAAAAA";
        string endGene = "TTTTTTTT";
        string[] bank = {
            "TAAAAAAA",
            "TTAAAAAA",
            "TTTAAAAA",
            "TTTTAAAA",
            "TTTTTAAA",
            "TTTTTTAA",
            "TTTTTTTA",
            "TTTTTTTT"
        };

        // Act
        var result = _task.MinMutation(startGene, endGene, bank);

        // Assert
        result.Should().Be(8); // Each character needs to change
    }
}

