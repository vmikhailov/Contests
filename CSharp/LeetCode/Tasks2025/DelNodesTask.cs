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
    public IList<TreeNode> DelNodes(TreeNode? root, int[] toDelete)
    {
        var toDeleteSet = new HashSet<int>(toDelete);
        var result = new List<TreeNode>();

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
            if (node != null) result.Add(node);
        }
    }
}
