namespace LeetCode.Tasks;

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
public class LcaNodes 
{
    public TreeNode SubtreeWithAllDeepest(TreeNode root)
    {
        return Dfs(root).Node;
    }

    private (TreeNode Node, int Depth) Dfs(TreeNode node) =>
        node is null
            ? (null, 0)
            : (Dfs(node.left), Dfs(node.right)) switch
            {
                (var l, var r) when l.Depth > r.Depth => (l.Node, l.Depth + 1),
                (var l, var r) when l.Depth < r.Depth => (r.Node, r.Depth + 1),
                (var l, var r) => new(node, l.Depth + 1),
            };

    public TreeNode LcaDeepestLeaves(TreeNode root) 
    {
        var leaves = new List<IList<TreeNode>>();
        var stack = new Stack<TreeNode>();
        Traverse(root);

        var maxDepth = leaves.Select(x => x.Count()).Max();
        var dd = leaves.Where(x => x.Count() == maxDepth).ToList();

        if(dd.Count() == 1)
        {
            return dd[0].Reverse().First();
        }

        var lca = GetLca(dd[0], dd[1]);
        for(var i = 2; i < dd.Count(); i++)
        {
            lca = GetLca(lca, dd[i]);
        }

        return lca.Reverse().First();

        IList<TreeNode> GetLca(IList<TreeNode> a, IList<TreeNode> b)
        {
            var i = 0;
            while(i < a.Count() && i < b.Count() && a[i] == b[i]) i++;
            return a.Take(i).ToList();
        }

        void Traverse(TreeNode node)
        {
            if(node is null) return;
            stack.Push(node);
            if(node.left is null && node.right is null)
            {
                leaves.Add(stack.Reverse().ToList());
            }
            else
            {
                Traverse(node.left);
                Traverse(node.right);
            }
            stack.Pop();
        }
    }
}