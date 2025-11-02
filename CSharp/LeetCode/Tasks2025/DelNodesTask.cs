using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks2025;

public class DelNodesTask
{
    /**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
    public IList<TreeNode> DelNodes(TreeNode? root, int[] to_delete) {
        var toDeleteSet = new HashSet<int>(to_delete);
        var result = new List<TreeNode?>();

        Add(DeleteNodes(root));
        return result;

        TreeNode? DeleteNodes(TreeNode? node)
        {
            if (node == null) return null;

            var newLeft = DeleteNodes(node.left);
            var newRight = DeleteNodes(node.right);

            if (!toDeleteSet.Contains(node.val))
            {
                return new(node.val, newLeft, newRight);
            }

            Add(newLeft);
            Add(newRight);
            return null;
        }

        void Add(TreeNode? node)
        {
            if(node != null) result.Add(node);
        }
    }
}

[TestFixture]
public class DelNodesTaskTests
{
    private DelNodesTask _task = null!;

    [SetUp]
    public void SetUp() => _task = new DelNodesTask();

    [Test]
    public void DelNodes_Example1_DeletesNodesCorrectly()
    {
        // Tree:       1
        //           /   \
        //          2     3
        //         / \   / \
        //        4   5 6   7
        // Delete [3,5] -> Result: [[1,2,null,4], [6], [7]]
        var root = new TreeNode(1)
        {
            left = new TreeNode(2)
            {
                left = new TreeNode(4),
                right = new TreeNode(5)
            },
            right = new TreeNode(3)
            {
                left = new TreeNode(6),
                right = new TreeNode(7)
            }
        };

        var result = _task.DelNodes(root, [3, 5]);

        result.Should().HaveCount(3);

        // Check that we have trees with roots 1, 6, 7
        var values = result.Select(n => n.val).OrderBy(v => v).ToList();
        values.Should().Equal([1, 6, 7]);

        // First tree: [1,2,null,4]
        var tree1 = result.FirstOrDefault(n => n.val == 1);
        tree1.Should().NotBeNull();
        tree1!.left!.val.Should().Be(2);
        tree1.left!.left!.val.Should().Be(4);
        tree1.left!.right.Should().BeNull();
        tree1.right.Should().BeNull();

        // Second tree: [6]
        var tree6 = result.FirstOrDefault(n => n.val == 6);
        tree6.Should().NotBeNull();
        tree6!.left.Should().BeNull();
        tree6.right.Should().BeNull();

        // Third tree: [7]
        var tree7 = result.FirstOrDefault(n => n.val == 7);
        tree7.Should().NotBeNull();
        tree7!.left.Should().BeNull();
        tree7.right.Should().BeNull();
    }

    [Test]
    public void DelNodes_Example2_DeletesRoot()
    {
        // Tree:     1
        //          / \
        //         2   3
        // Delete [1] -> Result: [[2], [3]]
        var root = new TreeNode(1)
        {
            left = new TreeNode(2),
            right = new TreeNode(3)
        };

        var result = _task.DelNodes(root, [1]);

        result.Should().HaveCount(2);
        var values = result.Select(n => n.val).OrderBy(v => v).ToList();
        values.Should().Equal([2, 3]);
    }

    [Test]
    public void DelNodes_DeleteLeafNodes_ReturnsRestOfTree()
    {
        // Tree:       1
        //           /   \
        //          2     3
        //         / \
        //        4   5
        // Delete [4,5] -> Result: [[1,2,3]]
        var root = new TreeNode(1)
        {
            left = new TreeNode(2)
            {
                left = new TreeNode(4),
                right = new TreeNode(5)
            },
            right = new TreeNode(3)
        };

        var result = _task.DelNodes(root, [4, 5]);

        result.Should().HaveCount(1);
        result[0].val.Should().Be(1);
        result[0].left!.val.Should().Be(2);
        result[0].right!.val.Should().Be(3);
        result[0].left!.left.Should().BeNull();
        result[0].left!.right.Should().BeNull();
    }

    [Test]
    public void DelNodes_DeleteAllNodes_ReturnsEmpty()
    {
        // Tree:    1
        //         / \
        //        2   3
        // Delete [1,2,3] -> Result: []
        var root = new TreeNode(1)
        {
            left = new TreeNode(2),
            right = new TreeNode(3)
        };

        var result = _task.DelNodes(root, [1, 2, 3]);

        result.Should().BeEmpty();
    }

    [Test]
    public void DelNodes_DeleteNoNodes_ReturnsOriginalTree()
    {
        // Tree:    1
        //         / \
        //        2   3
        // Delete [] -> Result: [[1,2,3]]
        var root = new TreeNode(1)
        {
            left = new TreeNode(2),
            right = new TreeNode(3)
        };

        var result = _task.DelNodes(root, []);

        result.Should().HaveCount(1);
        result[0].val.Should().Be(1);
        result[0].left!.val.Should().Be(2);
        result[0].right!.val.Should().Be(3);
    }

    [Test]
    public void DelNodes_SingleNodeNotDeleted_ReturnsSingleNode()
    {
        var root = new TreeNode(1);

        var result = _task.DelNodes(root, []);

        result.Should().HaveCount(1);
        result[0].val.Should().Be(1);
    }

    [Test]
    public void DelNodes_SingleNodeDeleted_ReturnsEmpty()
    {
        var root = new TreeNode(1);

        var result = _task.DelNodes(root, [1]);

        result.Should().BeEmpty();
    }

    [Test]
    public void DelNodes_DeleteMiddleNodes_CreatesMultipleTrees()
    {
        // Tree:         1
        //             /   \
        //            2     3
        //           / \   / \
        //          4   5 6   7
        // Delete [2,3] -> Result: [[1], [4], [5], [6], [7]]
        var root = new TreeNode(1)
        {
            left = new TreeNode(2)
            {
                left = new TreeNode(4),
                right = new TreeNode(5)
            },
            right = new TreeNode(3)
            {
                left = new TreeNode(6),
                right = new TreeNode(7)
            }
        };

        var result = _task.DelNodes(root, [2, 3]);

        result.Should().HaveCount(5);
        var values = result.Select(n => n.val).OrderBy(v => v).ToList();
        values.Should().Equal([1, 4, 5, 6, 7]);
    }

    [Test]
    public void DelNodes_LeftSkewedTree_DeletesCorrectly()
    {
        // Tree:  1
        //       /
        //      2
        //     /
        //    3
        // Delete [2] -> Result: [[1], [3]]
        var root = new TreeNode(1)
        {
            left = new TreeNode(2)
            {
                left = new TreeNode(3)
            }
        };

        var result = _task.DelNodes(root, [2]);

        result.Should().HaveCount(2);
        var values = result.Select(n => n.val).OrderBy(v => v).ToList();
        values.Should().Equal([1, 3]);

        var tree1 = result.FirstOrDefault(n => n.val == 1);
        tree1.Should().NotBeNull();
        tree1!.left.Should().BeNull();

        var tree3 = result.FirstOrDefault(n => n.val == 3);
        tree3.Should().NotBeNull();
    }

    [Test]
    public void DelNodes_RightSkewedTree_DeletesCorrectly()
    {
        // Tree:  1
        //         \
        //          2
        //           \
        //            3
        // Delete [2] -> Result: [[1], [3]]
        var root = new TreeNode(1)
        {
            right = new TreeNode(2)
            {
                right = new TreeNode(3)
            }
        };

        var result = _task.DelNodes(root, [2]);

        result.Should().HaveCount(2);
        var values = result.Select(n => n.val).OrderBy(v => v).ToList();
        values.Should().Equal([1, 3]);

        var tree1 = result.FirstOrDefault(n => n.val == 1);
        tree1.Should().NotBeNull();
        tree1!.right.Should().BeNull();

        var tree3 = result.FirstOrDefault(n => n.val == 3);
        tree3.Should().NotBeNull();
    }

    [Test]
    public void DelNodes_ComplexTree_MultipleDeleteLevels()
    {
        // Tree:           1
        //              /     \
        //             2       3
        //            / \     / \
        //           4   5   6   7
        //          /
        //         8
        // Delete [5,6] -> Result: [[1,2,3]] with full structure
        var root = new TreeNode(1)
        {
            left = new TreeNode(2)
            {
                left = new TreeNode(4)
                {
                    left = new TreeNode(8)
                },
                right = new TreeNode(5)
            },
            right = new TreeNode(3)
            {
                left = new TreeNode(6),
                right = new TreeNode(7)
            }
        };

        var result = _task.DelNodes(root, [5, 6]);

        result.Should().HaveCount(1);

        // Tree: [1,2,3] with children
        var tree1 = result.FirstOrDefault(n => n.val == 1);
        tree1.Should().NotBeNull();
        tree1!.left!.val.Should().Be(2);
        tree1.right!.val.Should().Be(3);
        tree1.left!.left!.val.Should().Be(4);
        tree1.left!.left!.left!.val.Should().Be(8);
        tree1.right!.right!.val.Should().Be(7);
    }

    [Test]
    public void DelNodes_DeleteOnlyRightChild_KeepsLeftSubtree()
    {
        // Tree:    1
        //         / \
        //        2   3
        //       /
        //      4
        // Delete [3] -> Result: [[1,2,null,4]]
        var root = new TreeNode(1)
        {
            left = new TreeNode(2)
            {
                left = new TreeNode(4)
            },
            right = new TreeNode(3)
        };

        var result = _task.DelNodes(root, [3]);

        result.Should().HaveCount(1);
        result[0].val.Should().Be(1);
        result[0].left!.val.Should().Be(2);
        result[0].left!.left!.val.Should().Be(4);
        result[0].right.Should().BeNull();
    }
}
