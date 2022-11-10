namespace LeetCode.Tasks;

public class ZigzagLevelOrderTask
{
	public IList<IList<int>> ZigzagLevelOrder(TreeNode root) 
	{
		var q = new Queue<TreeNode>();
		var r = new List<IList<int>>();
		var f = 1;
		if(root == null) return r;
		q.Enqueue(root);
		while(q.Any())
		{
			IList<int> v = new List<int>();
			var p = f == 1 ? q.Reverse() : q;
			q = new Queue<TreeNode>(); 
            
			foreach(var node in p)
			{
				v.Add(node.val);
				if(f == 1)
				{
					if(node.right != null) q.Enqueue(node.right);
					if(node.left != null) q.Enqueue(node.left);
				}
				else
				{
					if(node.left != null) q.Enqueue(node.left);
					if(node.right != null) q.Enqueue(node.right);
				}
			}
			
			r.Add(f == 1 ? v.Reverse().ToList() : v);
			f = -f;
			
		}
        
		return r;
	}
}