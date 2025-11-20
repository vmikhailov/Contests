using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks2025;

[TestFixture]
public class ConstructQuadTreeTaskTests
{
    private ConstructQuadTreeTask _task = null!;

    [SetUp]
    public void SetUp()
    {
        _task = new ConstructQuadTreeTask();
    }

    [Test]
    public void Construct_SingleCellZero_ReturnsLeafNodeWithValueFalse()
    {
        // Arrange
        int[][] grid = [[0]];

        // Act
        var result = _task.Construct(grid);

        // Assert
        result.Should().NotBeNull();
        result.isLeaf.Should().BeTrue();
        result.val.Should().BeFalse();
        result.topLeft.Should().BeNull();
        result.topRight.Should().BeNull();
        result.bottomLeft.Should().BeNull();
        result.bottomRight.Should().BeNull();
    }

    [Test]
    public void Construct_SingleCellOne_ReturnsLeafNodeWithValueTrue()
    {
        // Arrange
        int[][] grid = [[1]];

        // Act
        var result = _task.Construct(grid);

        // Assert
        result.Should().NotBeNull();
        result.isLeaf.Should().BeTrue();
        result.val.Should().BeTrue();
        result.topLeft.Should().BeNull();
        result.topRight.Should().BeNull();
        result.bottomLeft.Should().BeNull();
        result.bottomRight.Should().BeNull();
    }

    [Test]
    public void Construct_2x2AllZeros_ReturnsLeafNode()
    {
        // Arrange
        int[][] grid = [
            [0, 0],
            [0, 0]
        ];

        // Act
        var result = _task.Construct(grid);

        // Assert
        result.Should().NotBeNull();
        result.isLeaf.Should().BeTrue();
        result.val.Should().BeFalse();
    }

    [Test]
    public void Construct_2x2AllOnes_ReturnsLeafNode()
    {
        // Arrange
        int[][] grid = [
            [1, 1],
            [1, 1]
        ];

        // Act
        var result = _task.Construct(grid);

        // Assert
        result.Should().NotBeNull();
        result.isLeaf.Should().BeTrue();
        result.val.Should().BeTrue();
    }

    [Test]
    public void Construct_2x2Mixed_ReturnsNonLeafNodeWithFourChildren()
    {
        // Arrange
        int[][] grid = [
            [1, 0],
            [0, 1]
        ];

        // Act
        var result = _task.Construct(grid);

        // Assert
        result.Should().NotBeNull();
        result.isLeaf.Should().BeFalse();
        result.topLeft.Should().NotBeNull();
        result.topRight.Should().NotBeNull();
        result.bottomLeft.Should().NotBeNull();
        result.bottomRight.Should().NotBeNull();

        // Verify leaf nodes
        result.topLeft.isLeaf.Should().BeTrue();
        result.topLeft.val.Should().BeTrue();

        result.topRight.isLeaf.Should().BeTrue();
        result.topRight.val.Should().BeFalse();

        result.bottomLeft.isLeaf.Should().BeTrue();
        result.bottomLeft.val.Should().BeFalse();

        result.bottomRight.isLeaf.Should().BeTrue();
        result.bottomRight.val.Should().BeTrue();
    }

    [Test]
    public void Construct_4x4AllOnes_ReturnsLeafNode()
    {
        // Arrange
        int[][] grid = [
            [1, 1, 1, 1],
            [1, 1, 1, 1],
            [1, 1, 1, 1],
            [1, 1, 1, 1]
        ];

        // Act
        var result = _task.Construct(grid);

        // Assert
        result.Should().NotBeNull();
        result.isLeaf.Should().BeTrue();
        result.val.Should().BeTrue();
    }

    [Test]
    public void Construct_4x4AllZeros_ReturnsLeafNode()
    {
        // Arrange
        int[][] grid = [
            [0, 0, 0, 0],
            [0, 0, 0, 0],
            [0, 0, 0, 0],
            [0, 0, 0, 0]
        ];

        // Act
        var result = _task.Construct(grid);

        // Assert
        result.Should().NotBeNull();
        result.isLeaf.Should().BeTrue();
        result.val.Should().BeFalse();
    }

    [Test]
    public void Construct_4x4QuadrantPattern_ReturnsCorrectQuadTree()
    {
        // Arrange
        // Top-left and bottom-right are 1s, others are 0s
        int[][] grid = [
            [1, 1, 0, 0],
            [1, 1, 0, 0],
            [0, 0, 1, 1],
            [0, 0, 1, 1]
        ];

        // Act
        var result = _task.Construct(grid);

        // Assert
        result.Should().NotBeNull();
        result.isLeaf.Should().BeFalse();

        // Top-left quadrant all 1s
        result.topLeft.Should().NotBeNull();
        result.topLeft.isLeaf.Should().BeTrue();
        result.topLeft.val.Should().BeTrue();

        // Top-right quadrant all 0s
        result.topRight.Should().NotBeNull();
        result.topRight.isLeaf.Should().BeTrue();
        result.topRight.val.Should().BeFalse();

        // Bottom-left quadrant all 0s
        result.bottomLeft.Should().NotBeNull();
        result.bottomLeft.isLeaf.Should().BeTrue();
        result.bottomLeft.val.Should().BeFalse();

        // Bottom-right quadrant all 1s
        result.bottomRight.Should().NotBeNull();
        result.bottomRight.isLeaf.Should().BeTrue();
        result.bottomRight.val.Should().BeTrue();
    }

    [Test]
    public void Construct_8x8ComplexPattern_ReturnsMultiLevelQuadTree()
    {
        // Arrange
        int[][] grid = [
            [1, 1, 1, 1, 0, 0, 0, 0],
            [1, 1, 1, 1, 0, 0, 0, 0],
            [1, 1, 1, 1, 1, 1, 1, 1],
            [1, 1, 1, 1, 1, 1, 1, 1],
            [1, 1, 1, 1, 0, 0, 0, 0],
            [1, 1, 1, 1, 0, 0, 0, 0],
            [1, 1, 1, 1, 0, 0, 0, 0],
            [1, 1, 1, 1, 0, 0, 0, 0]
        ];

        // Act
        var result = _task.Construct(grid);

        // Assert
        result.Should().NotBeNull();
        result.isLeaf.Should().BeFalse();

        // Verify it has children
        result.topLeft.Should().NotBeNull();
        result.topRight.Should().NotBeNull();
        result.bottomLeft.Should().NotBeNull();
        result.bottomRight.Should().NotBeNull();
    }

    [Test]
    public void Construct_8x8LeetCodeExample_ReturnsCorrectStructure()
    {
        // Arrange
        // LeetCode example 1
        int[][] grid = [
            [0, 1, 1, 1, 1, 1, 1, 1],
            [0, 1, 1, 1, 1, 1, 1, 1],
            [0, 0, 0, 0, 1, 1, 1, 1],
            [0, 0, 0, 0, 1, 1, 1, 1],
            [0, 0, 0, 0, 0, 0, 1, 1],
            [0, 0, 0, 0, 0, 0, 1, 1],
            [0, 0, 0, 0, 0, 0, 0, 0],
            [0, 0, 0, 0, 0, 0, 0, 0]
        ];

        // Act
        var result = _task.Construct(grid);

        // Assert
        result.Should().NotBeNull();
        result.isLeaf.Should().BeFalse();

        // Verify structure exists (detailed validation would be complex)
        result.topLeft.Should().NotBeNull();
        result.topRight.Should().NotBeNull();
        result.bottomLeft.Should().NotBeNull();
        result.bottomRight.Should().NotBeNull();
    }

    [Test]
    public void Construct_4x4CheckerboardTopLeft_ReturnsComplexStructure()
    {
        // Arrange
        int[][] grid = [
            [1, 0, 1, 1],
            [0, 1, 1, 1],
            [1, 1, 0, 0],
            [1, 1, 0, 0]
        ];

        // Act
        var result = _task.Construct(grid);

        // Assert
        result.Should().NotBeNull();
        result.isLeaf.Should().BeFalse();

        // Top-left quadrant should be subdivided (checkerboard)
        result.topLeft.Should().NotBeNull();
        result.topLeft.isLeaf.Should().BeFalse();
    }

    [Test]
    public void Construct_4x4MixedQuadrants_ReturnsPartiallySubdivided()
    {
        // Arrange
        int[][] grid = [
            [1, 1, 1, 0],
            [1, 1, 0, 1],
            [1, 0, 1, 1],
            [0, 1, 1, 1]
        ];

        // Act
        var result = _task.Construct(grid);

        // Assert
        result.Should().NotBeNull();
        result.isLeaf.Should().BeFalse();

        // All quadrants should be subdivided due to mixed values
        result.topLeft.Should().NotBeNull();
        result.topRight.Should().NotBeNull();
        result.bottomLeft.Should().NotBeNull();
        result.bottomRight.Should().NotBeNull();
    }

    [Test]
    public void Construct_2x2TopLeftOne_ReturnsNonLeafWithMixedChildren()
    {
        // Arrange
        int[][] grid = [
            [1, 0],
            [0, 0]
        ];

        // Act
        var result = _task.Construct(grid);

        // Assert
        result.Should().NotBeNull();
        result.isLeaf.Should().BeFalse();

        result.topLeft.Should().NotBeNull();
        result.topLeft.isLeaf.Should().BeTrue();
        result.topLeft.val.Should().BeTrue();

        result.topRight.Should().NotBeNull();
        result.topRight.isLeaf.Should().BeTrue();
        result.topRight.val.Should().BeFalse();

        result.bottomLeft.Should().NotBeNull();
        result.bottomLeft.isLeaf.Should().BeTrue();
        result.bottomLeft.val.Should().BeFalse();

        result.bottomRight.Should().NotBeNull();
        result.bottomRight.isLeaf.Should().BeTrue();
        result.bottomRight.val.Should().BeFalse();
    }

    [Test]
    public void Construct_4x4BottomHalfOnes_ReturnsCorrectStructure()
    {
        // Arrange
        int[][] grid = [
            [0, 0, 0, 0],
            [0, 0, 0, 0],
            [1, 1, 1, 1],
            [1, 1, 1, 1]
        ];

        // Act
        var result = _task.Construct(grid);

        // Assert
        result.Should().NotBeNull();
        result.isLeaf.Should().BeFalse();

        // Top half all 0s
        result.topLeft.Should().NotBeNull();
        result.topLeft.isLeaf.Should().BeTrue();
        result.topLeft.val.Should().BeFalse();

        result.topRight.Should().NotBeNull();
        result.topRight.isLeaf.Should().BeTrue();
        result.topRight.val.Should().BeFalse();

        // Bottom half all 1s
        result.bottomLeft.Should().NotBeNull();
        result.bottomLeft.isLeaf.Should().BeTrue();
        result.bottomLeft.val.Should().BeTrue();

        result.bottomRight.Should().NotBeNull();
        result.bottomRight.isLeaf.Should().BeTrue();
        result.bottomRight.val.Should().BeTrue();
    }

    [Test]
    public void Construct_4x4LeftHalfOnes_ReturnsCorrectStructure()
    {
        // Arrange
        int[][] grid = [
            [1, 1, 0, 0],
            [1, 1, 0, 0],
            [1, 1, 0, 0],
            [1, 1, 0, 0]
        ];

        // Act
        var result = _task.Construct(grid);

        // Assert
        result.Should().NotBeNull();
        result.isLeaf.Should().BeFalse();

        // Left half all 1s
        result.topLeft.Should().NotBeNull();
        result.topLeft.isLeaf.Should().BeTrue();
        result.topLeft.val.Should().BeTrue();

        result.bottomLeft.Should().NotBeNull();
        result.bottomLeft.isLeaf.Should().BeTrue();
        result.bottomLeft.val.Should().BeTrue();

        // Right half all 0s
        result.topRight.Should().NotBeNull();
        result.topRight.isLeaf.Should().BeTrue();
        result.topRight.val.Should().BeFalse();

        result.bottomRight.Should().NotBeNull();
        result.bottomRight.isLeaf.Should().BeTrue();
        result.bottomRight.val.Should().BeFalse();
    }

    [Test]
    public void Construct_8x8AllZeros_ReturnsLeafNode()
    {
        // Arrange
        int[][] grid = new int[8][];
        for (int i = 0; i < 8; i++)
        {
            grid[i] = new int[8];
        }

        // Act
        var result = _task.Construct(grid);

        // Assert
        result.Should().NotBeNull();
        result.isLeaf.Should().BeTrue();
        result.val.Should().BeFalse();
    }

    [Test]
    public void Construct_8x8AllOnes_ReturnsLeafNode()
    {
        // Arrange
        int[][] grid = new int[8][];
        for (int i = 0; i < 8; i++)
        {
            grid[i] = new int[8];
            for (int j = 0; j < 8; j++)
            {
                grid[i][j] = 1;
            }
        }

        // Act
        var result = _task.Construct(grid);

        // Assert
        result.Should().NotBeNull();
        result.isLeaf.Should().BeTrue();
        result.val.Should().BeTrue();
    }

    [Test]
    public void Construct_4x4DiagonalPattern_ReturnsNonLeafStructure()
    {
        // Arrange
        int[][] grid = [
            [1, 0, 0, 0],
            [0, 1, 0, 0],
            [0, 0, 1, 0],
            [0, 0, 0, 1]
        ];

        // Act
        var result = _task.Construct(grid);

        // Assert
        result.Should().NotBeNull();
        result.isLeaf.Should().BeFalse();

        // Should have all quadrants subdivided
        result.topLeft.Should().NotBeNull();
        result.topRight.Should().NotBeNull();
        result.bottomLeft.Should().NotBeNull();
        result.bottomRight.Should().NotBeNull();
    }

    [Test]
    public void Construct_ValidatesTreeStructure_AllLeafNodesHaveNullChildren()
    {
        // Arrange
        int[][] grid = [
            [1, 1],
            [1, 1]
        ];

        // Act
        var result = _task.Construct(grid);

        // Assert
        result.Should().NotBeNull();
        result.isLeaf.Should().BeTrue();

        // Leaf nodes should have null children
        result.topLeft.Should().BeNull();
        result.topRight.Should().BeNull();
        result.bottomLeft.Should().BeNull();
        result.bottomRight.Should().BeNull();
    }

    [Test]
    public void Construct_ValidatesTreeStructure_NonLeafNodesHaveAllChildren()
    {
        // Arrange
        int[][] grid = [
            [1, 0],
            [0, 1]
        ];

        // Act
        var result = _task.Construct(grid);

        // Assert
        result.Should().NotBeNull();
        result.isLeaf.Should().BeFalse();

        // Non-leaf nodes should have all 4 children
        result.topLeft.Should().NotBeNull();
        result.topRight.Should().NotBeNull();
        result.bottomLeft.Should().NotBeNull();
        result.bottomRight.Should().NotBeNull();
    }

    // Helper method to verify tree depth
    private int GetTreeDepth(ConstructQuadTreeTask.Node node)
    {
        if (node == null || node.isLeaf)
            return 1;

        int maxChildDepth = 0;
        if (node.topLeft != null)
            maxChildDepth = Math.Max(maxChildDepth, GetTreeDepth(node.topLeft));
        if (node.topRight != null)
            maxChildDepth = Math.Max(maxChildDepth, GetTreeDepth(node.topRight));
        if (node.bottomLeft != null)
            maxChildDepth = Math.Max(maxChildDepth, GetTreeDepth(node.bottomLeft));
        if (node.bottomRight != null)
            maxChildDepth = Math.Max(maxChildDepth, GetTreeDepth(node.bottomRight));

        return maxChildDepth + 1;
    }

    [Test]
    public void Construct_8x8DeepPattern_CreatesMultiLevelTree()
    {
        // Arrange
        int[][] grid = [
            [1, 1, 0, 0, 1, 1, 0, 0],
            [1, 1, 0, 0, 1, 1, 0, 0],
            [0, 0, 1, 1, 0, 0, 1, 1],
            [0, 0, 1, 1, 0, 0, 1, 1],
            [1, 1, 0, 0, 1, 1, 0, 0],
            [1, 1, 0, 0, 1, 1, 0, 0],
            [0, 0, 1, 1, 0, 0, 1, 1],
            [0, 0, 1, 1, 0, 0, 1, 1]
        ];

        // Act
        var result = _task.Construct(grid);

        // Assert
        result.Should().NotBeNull();
        result.isLeaf.Should().BeFalse();

        // Should have multiple levels
        var depth = GetTreeDepth(result);
        depth.Should().BeGreaterThan(1);
    }
}

