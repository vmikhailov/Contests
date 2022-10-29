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