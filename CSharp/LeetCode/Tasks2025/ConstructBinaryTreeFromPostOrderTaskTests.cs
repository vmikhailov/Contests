using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks2025;

[TestFixture]
public class ConstructBinaryTreeFromPostOrderTaskTests
{
    private ConstructBinaryTreeFromPostOrderTask _task = null!;

    [SetUp]
    public void SetUp()
    {
        _task = new ConstructBinaryTreeFromPostOrderTask();
    }

    [Test]
    public void BuildTree_BasicExample_ReturnsCorrectTree()
    {
        // Arrange
        // Tree:    3
        //         / \
        //        9  20
        //          /  \
        //         15   7
        int[] inorder = [9, 3, 15, 20, 7];
        int[] postorder = [9, 15, 7, 20, 3];

        // Act
        var result = _task.BuildTree(inorder, postorder);

        // Assert
        result.Should().NotBeNull();
        result!.val.Should().Be(3);
        result.left!.val.Should().Be(9);
        result.left.left.Should().BeNull();
        result.left.right.Should().BeNull();
        result.right!.val.Should().Be(20);
        result.right.left!.val.Should().Be(15);
        result.right.right!.val.Should().Be(7);

        // Verify using helper
        var expectedInorder = new List<int> { 9, 3, 15, 20, 7 };
        var actualInorder = InorderTraversal(result);
        actualInorder.Should().Equal(expectedInorder);
    }

    [Test]
    public void BuildTree_Original_BasicExample_ReturnsCorrectTree()
    {
        // Arrange
        int[] inorder = [9, 3, 15, 20, 7];
        int[] postorder = [9, 15, 7, 20, 3];

        // Act
        var result = _task.BuildTree_Original(inorder, postorder);

        // Assert
        var actualInorder = InorderTraversal(result!);
        actualInorder.Should().Equal(inorder);

        var actualPostorder = PostorderTraversal(result);
        actualPostorder.Should().Equal(postorder);
    }

    [Test]
    public void BuildTree_SingleNode_ReturnsSingleNodeTree()
    {
        // Arrange
        int[] inorder = [-1];
        int[] postorder = [-1];

        // Act
        var result = _task.BuildTree(inorder, postorder);

        // Assert
        result.Should().NotBeNull();
        result!.val.Should().Be(-1);
        result.left.Should().BeNull();
        result.right.Should().BeNull();
    }

    [Test]
    public void BuildTree_LeftSkewedTree_ReturnsCorrectTree()
    {
        // Arrange
        // Tree:    3
        //         /
        //        2
        //       /
        //      1
        int[] inorder = [1, 2, 3];
        int[] postorder = [1, 2, 3];

        // Act
        var result = _task.BuildTree(inorder, postorder);

        // Assert
        result.Should().NotBeNull();
        result!.val.Should().Be(3);
        result.left!.val.Should().Be(2);
        result.left.left!.val.Should().Be(1);
        result.left.left.left.Should().BeNull();
        result.left.left.right.Should().BeNull();
        result.left.right.Should().BeNull();
        result.right.Should().BeNull();
    }

    [Test]
    public void BuildTree_RightSkewedTree_ReturnsCorrectTree()
    {
        // Arrange
        // Tree: 1
        //        \
        //         2
        //          \
        //           3
        int[] inorder = [1, 2, 3];
        int[] postorder = [3, 2, 1];

        // Act
        var result = _task.BuildTree(inorder, postorder);

        // Assert
        result.Should().NotBeNull();
        result!.val.Should().Be(1);
        result.left.Should().BeNull();
        result.right!.val.Should().Be(2);
        result.right.left.Should().BeNull();
        result.right.right!.val.Should().Be(3);
        result.right.right.left.Should().BeNull();
        result.right.right.right.Should().BeNull();
    }

    [Test]
    public void BuildTree_TwoNodes_LeftChild_ReturnsCorrectTree()
    {
        // Arrange
        // Tree: 2
        //      /
        //     1
        int[] inorder = [1, 2];
        int[] postorder = [1, 2];

        // Act
        var result = _task.BuildTree(inorder, postorder);

        // Assert
        result.Should().NotBeNull();
        result!.val.Should().Be(2);
        result.left!.val.Should().Be(1);
        result.right.Should().BeNull();
    }

    [Test]
    public void BuildTree_TwoNodes_RightChild_ReturnsCorrectTree()
    {
        // Arrange
        // Tree: 1
        //        \
        //         2
        int[] inorder = [1, 2];
        int[] postorder = [2, 1];

        // Act
        var result = _task.BuildTree(inorder, postorder);

        // Assert
        result.Should().NotBeNull();
        result!.val.Should().Be(1);
        result.left.Should().BeNull();
        result.right!.val.Should().Be(2);
    }

    [Test]
    public void BuildTree_BalancedTree_ReturnsCorrectTree()
    {
        // Arrange
        // Tree:      4
        //          /   \
        //         2     6
        //        / \   / \
        //       1   3 5   7
        int[] inorder = [1, 2, 3, 4, 5, 6, 7];
        int[] postorder = [1, 3, 2, 5, 7, 6, 4];

        // Act
        var result = _task.BuildTree(inorder, postorder);

        // Assert
        result.Should().NotBeNull();
        result!.val.Should().Be(4);
        result.left!.val.Should().Be(2);
        result.left.left!.val.Should().Be(1);
        result.left.right!.val.Should().Be(3);
        result.right!.val.Should().Be(6);
        result.right.left!.val.Should().Be(5);
        result.right.right!.val.Should().Be(7);

        var actualInorder = InorderTraversal(result);
        actualInorder.Should().Equal(inorder);

        var actualPostorder = PostorderTraversal(result);
        actualPostorder.Should().Equal(postorder);
    }

    [Test]
    public void BuildTree_Original_BalancedTree_ReturnsCorrectTree()
    {
        // Arrange
        int[] inorder = [1, 2, 3, 4, 5, 6, 7];
        int[] postorder = [1, 3, 2, 5, 7, 6, 4];

        // Act
        var result = _task.BuildTree_Original(inorder, postorder);

        // Assert
        var actualInorder = InorderTraversal(result!);
        actualInorder.Should().Equal(inorder);

        var actualPostorder = PostorderTraversal(result);
        actualPostorder.Should().Equal(postorder);
    }

    [Test]
    public void BuildTree_ComplexAsymmetricTree_ReturnsCorrectTree()
    {
        // Arrange
        // Tree:        5
        //            /   \
        //           3     8
        //          / \     \
        //         1   4     10
        //          \       /
        //           2     9
        int[] inorder = [1, 2, 3, 4, 5, 8, 9, 10];
        int[] postorder = [2, 1, 4, 3, 9, 10, 8, 5];

        // Act
        var result = _task.BuildTree(inorder, postorder);

        // Assert
        result.Should().NotBeNull();

        var actualInorder = InorderTraversal(result!);
        actualInorder.Should().Equal(inorder);

        var actualPostorder = PostorderTraversal(result);
        actualPostorder.Should().Equal(postorder);
    }

    [Test]
    public void BuildTree_NegativeValues_ReturnsCorrectTree()
    {
        // Arrange
        // Tree:    0
        //         / \
        //       -3   2
        //       /     \
        //     -5       4
        int[] inorder = [-5, -3, 0, 2, 4];
        int[] postorder = [-5, -3, 4, 2, 0];

        // Act
        var result = _task.BuildTree(inorder, postorder);

        // Assert
        result.Should().NotBeNull();
        result!.val.Should().Be(0);
        result.left!.val.Should().Be(-3);
        result.left.left!.val.Should().Be(-5);
        result.right!.val.Should().Be(2);
        result.right.right!.val.Should().Be(4);

        var actualInorder = InorderTraversal(result);
        actualInorder.Should().Equal(inorder);
    }

    [Test]
    public void BuildTree_LargeValues_ReturnsCorrectTree()
    {
        // Arrange
        // Tree:     1000
        //          /    \
        //       500     2000
        int[] inorder = [500, 1000, 2000];
        int[] postorder = [500, 2000, 1000];

        // Act
        var result = _task.BuildTree(inorder, postorder);

        // Assert
        result.Should().NotBeNull();
        result!.val.Should().Be(1000);
        result.left!.val.Should().Be(500);
        result.right!.val.Should().Be(2000);
    }

    [Test]
    public void BuildTree_ThreeNodesPerfectTree_ReturnsCorrectTree()
    {
        // Arrange
        // Tree:   2
        //        / \
        //       1   3
        int[] inorder = [1, 2, 3];
        int[] postorder = [1, 3, 2];

        // Act
        var result = _task.BuildTree(inorder, postorder);

        // Assert
        result.Should().NotBeNull();
        result!.val.Should().Be(2);
        result.left!.val.Should().Be(1);
        result.right!.val.Should().Be(3);
        result.left.left.Should().BeNull();
        result.left.right.Should().BeNull();
        result.right.left.Should().BeNull();
        result.right.right.Should().BeNull();
    }

    [Test]
    public void BuildTree_FourLevelTree_ReturnsCorrectTree()
    {
        // Arrange
        // Tree:          8
        //              /   \
        //            4      12
        //           / \    /  \
        //          2   6  10  14
        //         /
        //        1
        int[] inorder = [1, 2, 4, 6, 8, 10, 12, 14];
        int[] postorder = [1, 2, 6, 4, 10, 14, 12, 8];

        // Act
        var result = _task.BuildTree(inorder, postorder);

        // Assert
        result.Should().NotBeNull();

        var actualInorder = InorderTraversal(result!);
        actualInorder.Should().Equal(inorder);

        var actualPostorder = PostorderTraversal(result);
        actualPostorder.Should().Equal(postorder);

        // Verify specific structure
        result.val.Should().Be(8);
        result.left!.val.Should().Be(4);
        result.left.left!.val.Should().Be(2);
        result.left.left.left!.val.Should().Be(1);
    }

    // Helper method to perform inorder traversal
    private static List<int> InorderTraversal(TreeNode? root)
    {
        var result = new List<int>();
        InorderHelper(root, result);
        return result;
    }

    private static void InorderHelper(TreeNode? node, List<int> result)
    {
        if (node == null) return;
        InorderHelper(node.left, result);
        result.Add(node.val);
        InorderHelper(node.right, result);
    }

    // Helper method to perform postorder traversal
    private static List<int> PostorderTraversal(TreeNode? root)
    {
        var result = new List<int>();
        PostorderHelper(root, result);
        return result;
    }

    private static void PostorderHelper(TreeNode? node, List<int> result)
    {
        if (node == null) return;
        PostorderHelper(node.left, result);
        PostorderHelper(node.right, result);
        result.Add(node.val);
    }
}

