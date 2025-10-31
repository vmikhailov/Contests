namespace LeetCode.Tasks;

public class ListToTreeHelper
{
    public static TreeNode ToTree(params int[] nodes)
    {
        var node = new TreeNode(nodes[0]);
        var queue = new Queue<TreeNode>();
        queue.Enqueue(node);
        var i = 1;
        while (queue.TryPeek(out var next))
        {
            //queue.
        }

        return node;
    }
}