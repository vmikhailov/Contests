using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks2025;

[TestFixture]
public class PopulatingNextRightTaskTests
{
    private PopulatingNextRightTask _task = null!;

    [SetUp]
    public void SetUp()
    {
        _task = new();
    }

    [Test]
    public void Connect_PerfectBinaryTreeThreeLevels_ConnectsAllNextPointers()
    {
        // Arrange
        //       1
        //      / \
        //     2   3
        //    / \ / \
        //   4  5 6  7
        var root = new PopulatingNextRightTask.Node
        {
            val = 1,
            left = new()
            {
                val = 2,
                left = new() { val = 4 },
                right = new() { val = 5 }
            },
            right = new()
            {
                val = 3,
                left = new() { val = 6 },
                right = new() { val = 7 }
            }
        };

        // Act
        var result = _task.Connect(root);

        // Assert
        // Level 1
        result.next.Should().BeNull();

        // Level 2
        result.left!.next.Should().Be(result.right);
        result.right!.next.Should().BeNull();

        // Level 3
        result.left.left!.next.Should().Be(result.left.right);
        result.left.right!.next.Should().Be(result.right.left);
        result.right.left!.next.Should().Be(result.right.right);
        result.right.right!.next.Should().BeNull();
    }

    [Test]
    public void Connect_SingleNode_ReturnsNodeWithNullNext()
    {
        // Arrange
        var root = new PopulatingNextRightTask.Node { val = 1 };

        // Act
        var result = _task.Connect(root);

        // Assert
        result.next.Should().BeNull();
        result.val.Should().Be(1);
    }

    [Test]
    public void Connect_TwoLevelTree_ConnectsNextPointers()
    {
        // Arrange
        //    1
        //   / \
        //  2   3
        var root = new PopulatingNextRightTask.Node
        {
            val = 1,
            left = new() { val = 2 },
            right = new() { val = 3 }
        };

        // Act
        var result = _task.Connect(root);

        // Assert
        result.next.Should().BeNull();
        result.left!.next.Should().Be(result.right);
        result.right!.next.Should().BeNull();
    }

    [Test]
    public void Connect_LeftSkewedTree_ConnectsNextPointers()
    {
        // Arrange
        //     1
        //    /
        //   2
        //  /
        // 3
        var root = new PopulatingNextRightTask.Node
        {
            val = 1,
            left = new()
            {
                val = 2,
                left = new() { val = 3 }
            }
        };

        // Act
        var result = _task.Connect(root);

        // Assert
        result.next.Should().BeNull();
        result.left!.next.Should().BeNull();
        result.left.left!.next.Should().BeNull();
    }

    [Test]
    public void Connect_RightSkewedTree_ConnectsNextPointers()
    {
        // Arrange
        // 1
        //  \
        //   2
        //    \
        //     3
        var root = new PopulatingNextRightTask.Node
        {
            val = 1,
            right = new()
            {
                val = 2,
                right = new() { val = 3 }
            }
        };

        // Act
        var result = _task.Connect(root);

        // Assert
        result.next.Should().BeNull();
        result.right!.next.Should().BeNull();
        result.right.right!.next.Should().BeNull();
    }

    [Test]
    public void Connect_FourLevelPerfectTree_ConnectsAllLevels()
    {
        // Arrange
        //         1
        //       /   \
        //      2     3
        //     / \   / \
        //    4   5 6   7
        //   /\  /\ /\ /\
        //  8 9 10 11 12 13 14 15
        var root = new PopulatingNextRightTask.Node
        {
            val = 1,
            left = new()
            {
                val = 2,
                left = new()
                {
                    val = 4,
                    left = new() { val = 8 },
                    right = new() { val = 9 }
                },
                right = new()
                {
                    val = 5,
                    left = new() { val = 10 },
                    right = new() { val = 11 }
                }
            },
            right = new()
            {
                val = 3,
                left = new()
                {
                    val = 6,
                    left = new() { val = 12 },
                    right = new() { val = 13 }
                },
                right = new()
                {
                    val = 7,
                    left = new() { val = 14 },
                    right = new() { val = 15 }
                }
            }
        };

        // Act
        var result = _task.Connect(root);

        // Assert
        // Level 1
        result.next.Should().BeNull();

        // Level 2
        result.left!.next.Should().Be(result.right);
        result.right!.next.Should().BeNull();

        // Level 3
        var node4 = result.left.left!;
        var node5 = result.left.right!;
        var node6 = result.right.left!;
        var node7 = result.right.right!;

        node4.next.Should().Be(node5);
        node5.next.Should().Be(node6);
        node6.next.Should().Be(node7);
        node7.next.Should().BeNull();

        // Level 4
        node4.left!.next.Should().Be(node4.right);
        node4.right!.next.Should().Be(node5.left);
        node5.left!.next.Should().Be(node5.right);
        node5.right!.next.Should().Be(node6.left);
        node6.left!.next.Should().Be(node6.right);
        node6.right!.next.Should().Be(node7.left);
        node7.left!.next.Should().Be(node7.right);
        node7.right!.next.Should().BeNull();
    }

    [Test]
    public void Connect_TreeWithOnlyLeftChildren_ConnectsCorrectly()
    {
        // Arrange
        //      1
        //     / \
        //    2   3
        //   /
        //  4
        var root = new PopulatingNextRightTask.Node
        {
            val = 1,
            left = new()
            {
                val = 2,
                left = new() { val = 4 }
            },
            right = new() { val = 3 }
        };

        // Act
        var result = _task.Connect(root);

        // Assert
        result.next.Should().BeNull();
        result.left!.next.Should().Be(result.right);
        result.right!.next.Should().BeNull();
        result.left.left!.next.Should().BeNull();
    }

    [Test]
    public void Connect_TreeWithMixedChildren_ConnectsCorrectly()
    {
        // Arrange
        //      1
        //     / \
        //    2   3
        //     \   \
        //      5   7
        var root = new PopulatingNextRightTask.Node
        {
            val = 1,
            left = new()
            {
                val = 2,
                right = new() { val = 5 }
            },
            right = new()
            {
                val = 3,
                right = new() { val = 7 }
            }
        };

        // Act
        var result = _task.Connect(root);

        // Assert
        result.next.Should().BeNull();
        result.left!.next.Should().Be(result.right);
        result.right!.next.Should().BeNull();
        result.left.right!.next.Should().Be(result.right.right);
        result.right.right!.next.Should().BeNull();
    }

    [Test]
    public void Connect_AsymmetricTree_ConnectsAllNodesInEachLevel()
    {
        // Arrange
        //       1
        //      / \
        //     2   3
        //    / \   \
        //   4   5   7
        //  /
        // 8
        var root = new PopulatingNextRightTask.Node
        {
            val = 1,
            left = new()
            {
                val = 2,
                left = new()
                {
                    val = 4,
                    left = new() { val = 8 }
                },
                right = new() { val = 5 }
            },
            right = new()
            {
                val = 3,
                right = new() { val = 7 }
            }
        };

        // Act
        var result = _task.Connect(root);

        // Assert
        result.next.Should().BeNull();
        result.left!.next.Should().Be(result.right);
        result.right!.next.Should().BeNull();
        result.left.left!.next.Should().Be(result.left.right);
        result.left.right!.next.Should().Be(result.right.right);
        result.right.right!.next.Should().BeNull();
        result.left.left.left!.next.Should().BeNull();
    }

    [Test]
    public void Connect_VerifyReturnsSameRootReference()
    {
        // Arrange
        var root = new PopulatingNextRightTask.Node
        {
            val = 1,
            left = new() { val = 2 },
            right = new() { val = 3 }
        };

        // Act
        var result = _task.Connect(root);

        // Assert
        result.Should().BeSameAs(root);
    }
}

