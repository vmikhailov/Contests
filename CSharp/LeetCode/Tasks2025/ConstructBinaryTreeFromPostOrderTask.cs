namespace LeetCode.Tasks2025;

public class ConstructBinaryTreeFromPostOrderTask
{
    // Original recursive approach with index tracking - O(n) time, O(n) space
    public TreeNode? BuildTree_Original(int[] inorder, int[] postorder)
    {
        var map = inorder.Select((x, i) => (x, i)).ToDictionary(x => x.x, x => x.i);

        return Build(0, inorder.Length - 1, 0, postorder.Length - 1);

        TreeNode? Build(int inL, int inR, int postL, int postR)
        {
            if(inL > inR || postL > postR) return null;

            // most right in postorder is the root
            var v = postorder[postR];
            var i = map[v];

            var offset = i - inL;

            return new(v)
            {
                left = Build(inL, i - 1, postL, postL + offset - 1),
                right = Build(i + 1, inR, postL + offset, postR - 1)
            };
        }
    }

    // Optimized stack-based approach - O(n) time, O(n) space, cleaner logic
    public TreeNode? BuildTree(int[] inorder, int[] postorder)
    {
        if (postorder.Length == 0) return null;

        var stack = new Stack<TreeNode>();
        var root = new TreeNode(postorder[^1]);
        stack.Push(root);

        var inorderIdx = inorder.Length - 1;

        // Process postorder from right to left (reverse)
        for (var i = postorder.Length - 2; i >= 0; i--)
        {
            var node = new TreeNode(postorder[i]);
            var parent = stack.Peek();

            // If current value is not the inorder value, it's a right child
            if (parent.val != inorder[inorderIdx])
            {
                parent.right = node;
            }
            else
            {
                // Pop until we find the correct parent for left child
                TreeNode? lastPopped = null;
                while (stack.Count > 0 && stack.Peek().val == inorder[inorderIdx])
                {
                    lastPopped = stack.Pop();
                    inorderIdx--;
                }
                lastPopped!.left = node;
            }

            stack.Push(node);
        }

        return root;
    }
}

