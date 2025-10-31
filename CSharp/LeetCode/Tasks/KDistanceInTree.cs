namespace LeetCode.Tasks;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class KDistanceInTree
{
    public IList<int> DistanceK(TreeNode root, TreeNode target, int k) {
        var map = new Dictionary<int, IList<int>>();
        map[root.val] = new List<int>();

        Traverse(root, map);

        var list = map[target.val];
        var visited = new HashSet<int>() { target.val };
        while(--k > 0)
        {
            var next = list.SelectMany(x => map[x]).Except(visited).ToList();
            foreach (var v in list)
            {
                visited.Add(v);
            }

            list = next;
        }
        return list;
    }

    private void Traverse(TreeNode root, IDictionary<int, IList<int>> map)
    {
        Process(root.left);
        Process(root.right);

        void Process(TreeNode node)
        {
            if(node is not null)
            {
                Add(root.val, node.val);
                Add(node.val, root.val);
                Traverse(node, map);
            }
        }

        void Add(int key, int val)
        {
            if(!map.TryGetValue(key, out var list))
            {
                list = new List<int>();
                map[key] = list;
            }
            list.Add(val);
        }
    }
}