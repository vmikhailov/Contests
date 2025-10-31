using FluentAssertions;
using NUnit.Framework;

namespace LeetCode;

public class CheckBinSearchTree
{
	public bool IsValidBST(TreeNode root)
	{
		return IsValidBST(root, root.val, null, null);
	}

	public bool IsValidBST(TreeNode root, int val, int? min, int? max)
	{
		var v = (min.HasValue ? min < val : true)
		     && (max.HasValue ? val < max : true);

		if (v && root.left != null)
		{
			v = root.left.val < val
			 && IsValidBST(root.left, root.left.val, min, val);
		}

		if (v && root.right != null)
		{
			v = root.val < root.right.val
			 && IsValidBST(root.right, root.right.val, val, max);
		}

		return v;
	}
}

[TestFixture]
public class CheckBinSearchTreeTests
{
	private CheckBinSearchTree _task = null!;

	[SetUp]
	public void SetUp() => _task = new CheckBinSearchTree();

	[Test]
	public void IsValidBST_ValidTree_ReturnsTrue()
	{
		var root = new TreeNode(2)
		{
			left = new TreeNode(1),
			right = new TreeNode(3)
		};
		_task.IsValidBST(root).Should().BeTrue();
	}

	[Test]
	public void IsValidBST_InvalidTree_ReturnsFalse()
	{
		var root = new TreeNode(5)
		{
			left = new TreeNode(1),
			right = new TreeNode(4)
			{
				left = new TreeNode(3),
				right = new TreeNode(6)
			}
		};
		_task.IsValidBST(root).Should().BeFalse();
	}

	[Test]
	public void IsValidBST_SingleNode_ReturnsTrue()
	{
		var root = new TreeNode(1);
		_task.IsValidBST(root).Should().BeTrue();
	}

	[Test]
	public void IsValidBST_OnlyLeftChild_ReturnsCorrect()
	{
		var root = new TreeNode(2)
		{
			left = new TreeNode(1)
		};
		_task.IsValidBST(root).Should().BeTrue();
	}

	[Test]
	public void IsValidBST_OnlyRightChild_ReturnsCorrect()
	{
		var root = new TreeNode(1)
		{
			right = new TreeNode(2)
		};
		_task.IsValidBST(root).Should().BeTrue();
	}

	[Test]
	public void IsValidBST_MinValueNode_ReturnsTrue()
	{
		var root = new TreeNode(int.MinValue);
		_task.IsValidBST(root).Should().BeTrue();
	}
}
