namespace LeetCode.Tasks;

public class ZigzagLevelOrderTask
{
	public IList<IList<int>> ZigzagLevelOrder(TreeNode? root) 
	{
		var q = new Queue<TreeNode>();
		var r = new List<IList<int>>();
		
		var f = false;
		if(root == null) return r;
		
		q.Enqueue(root);
		
		while(q.Any())
		{
			IList<int> v = new List<int>();
			var p = q;
			q = new (); 
            
			foreach(var node in p)
			{
				v.Add(node.val);
				if(node.left != null) q.Enqueue(node.left);
				if(node.right != null) q.Enqueue(node.right);
			}

			f = !f;
			var a = (f ? p.ToList() : p.Reverse()).Select(x => x.val).ToList();
			r.Add(a);
		}
        
		return r;
	}
}