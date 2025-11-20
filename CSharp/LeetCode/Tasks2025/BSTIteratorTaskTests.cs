using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks2025;

[TestFixture]
public class BSTIteratorTaskTests
{
    [Test]
    public void BSTIterator_SimpleTree_IteratesInOrder()
    {
        // Arrange
        //     7
        //    / \
        //   3   15
        //      /  \
        //     9   20
        var root = new TreeNode(7,
            new(3),
            new(15,
                new(9),
                new(20)
            )
        );

        var iterator = new BSTIteratorTask.BSTIterator(root);

        // Act & Assert
        iterator.Next().Should().Be(3);
        iterator.Next().Should().Be(7);
        iterator.HasNext().Should().BeTrue();
        iterator.Next().Should().Be(9);
        iterator.HasNext().Should().BeTrue();
        iterator.Next().Should().Be(15);
        iterator.HasNext().Should().BeTrue();
        iterator.Next().Should().Be(20);
        iterator.HasNext().Should().BeFalse();
    }

    [Test]
    public void BSTIterator_SingleNode_IteratesCorrectly()
    {
        // Arrange
        var root = new TreeNode(5);
        var iterator = new BSTIteratorTask.BSTIterator(root);

        // Act & Assert
        iterator.Next().Should().Be(5);
        iterator.HasNext().Should().BeFalse();
    }

    [Test]
    public void BSTIterator_LeftSkewedTree_IteratesInOrder()
    {
        // Arrange
        //       5
        //      /
        //     4
        //    /
        //   3
        //  /
        // 2
        var root = new TreeNode(5,
            new(4,
                new(3,
                    new(2)
                )
            )
        );

        var iterator = new BSTIteratorTask.BSTIterator(root);

        // Act & Assert
        iterator.Next().Should().Be(2);
        iterator.Next().Should().Be(3);
        iterator.Next().Should().Be(4);
        iterator.Next().Should().Be(5);
        iterator.HasNext().Should().BeFalse();
    }

    [Test]
    public void BSTIterator_RightSkewedTree_IteratesInOrder()
    {
        // Arrange
        // 2
        //  \
        //   3
        //    \
        //     4
        //      \
        //       5
        var root = new TreeNode(2,
            null,
            new(3,
                null,
                new(4,
                    null,
                    new(5)
                )
            )
        );

        var iterator = new BSTIteratorTask.BSTIterator(root);

        // Act & Assert
        iterator.Next().Should().Be(2);
        iterator.Next().Should().Be(3);
        iterator.Next().Should().Be(4);
        iterator.Next().Should().Be(5);
        iterator.HasNext().Should().BeFalse();
    }

    [Test]
    public void BSTIterator_BalancedTree_IteratesInOrder()
    {
        // Arrange
        //       4
        //      / \
        //     2   6
        //    / \ / \
        //   1  3 5  7
        var root = new TreeNode(4,
            new(2,
                new(1),
                new(3)
            ),
            new(6,
                new(5),
                new(7)
            )
        );

        var iterator = new BSTIteratorTask.BSTIterator(root);

        // Act & Assert
        var result = new List<int>();
        while (iterator.HasNext())
        {
            result.Add(iterator.Next());
        }

        result.Should().Equal(1, 2, 3, 4, 5, 6, 7);
    }

    [Test]
    public void BSTIterator_HasNextAfterEachNext_ReturnsCorrectly()
    {
        // Arrange
        //     5
        //    / \
        //   3   7
        var root = new TreeNode(5,
            new(3),
            new(7)
        );

        var iterator = new BSTIteratorTask.BSTIterator(root);

        // Act & Assert
        iterator.Next().Should().Be(3);
        iterator.HasNext().Should().BeTrue();
        iterator.Next().Should().Be(5);
        iterator.HasNext().Should().BeTrue();
        iterator.Next().Should().Be(7);
        iterator.HasNext().Should().BeFalse();
    }

    [Test]
    public void BSTIterator_LargerTree_IteratesAllElementsInOrder()
    {
        // Arrange
        //        10
        //       /  \
        //      5    15
        //     / \   / \
        //    3   7 12  20
        //   /     \
        //  1       9
        var root = new TreeNode(10,
            new(5,
                new(3,
                    new(1)
                ),
                new(7,
                    null,
                    new(9)
                )
            ),
            new(15,
                new(12),
                new(20)
            )
        );

        var iterator = new BSTIteratorTask.BSTIterator(root);

        // Act
        var result = new List<int>();
        result.Add(iterator.Next());
        while (iterator.HasNext())
        {
            result.Add(iterator.Next());
        }

        // Assert
        result.Should().Equal(1, 3, 5, 7, 9, 10, 12, 15, 20);
    }

    [Test]
    public void BSTIterator_TwoNodeTree_IteratesCorrectly()
    {
        // Arrange - Root with left child
        //   2
        //  /
        // 1
        var root = new TreeNode(2, new(1));
        var iterator = new BSTIteratorTask.BSTIterator(root);

        // Act & Assert
        iterator.Next().Should().Be(1);
        iterator.HasNext().Should().BeTrue();
        iterator.Next().Should().Be(2);
        iterator.HasNext().Should().BeFalse();
    }

    [Test]
    public void BSTIterator_TwoNodeTreeRightChild_IteratesCorrectly()
    {
        // Arrange - Root with right child
        // 1
        //  \
        //   2
        var root = new TreeNode(1, null, new(2));
        var iterator = new BSTIteratorTask.BSTIterator(root);

        // Act & Assert
        iterator.Next().Should().Be(1);
        iterator.HasNext().Should().BeTrue();
        iterator.Next().Should().Be(2);
        iterator.HasNext().Should().BeFalse();
    }

    [Test]
    public void BSTIterator_MultipleHasNextCalls_DoesNotSkipElements()
    {
        // Arrange
        //   2
        //  / \
        // 1   3
        var root = new TreeNode(2,
            new(1),
            new(3)
        );

        var iterator = new BSTIteratorTask.BSTIterator(root);

        // Act & Assert - Multiple HasNext calls should not affect iteration
        iterator.Next().Should().Be(1);
        iterator.HasNext().Should().BeTrue();
        iterator.HasNext().Should().BeTrue();
        iterator.Next().Should().Be(2);
        iterator.HasNext().Should().BeTrue();
        iterator.Next().Should().Be(3);
        iterator.HasNext().Should().BeFalse();
        iterator.HasNext().Should().BeFalse();
    }
}

