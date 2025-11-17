namespace LeetCode.Tasks;

public class ZigzagLevelOrderTask
{
	public IList<IList<int>> ZigzagLevelOrder(TreeNode? root) 
	{
		var result = new List<IList<int>>();

		if(root == null)
		{
			return result;
		}

		var leftToRight = true;

		var queue = new Queue<TreeNode>();
		queue.Enqueue(root);
		
		while(queue.Count > 0)
		{
			var level = new List<int>();
			var levelSize = queue.Count;

			for(var i = 0; i < levelSize; i++)
			{
				var node = queue.Dequeue();
				level.Add(node.val);
				if(node.left != null)
				{
					queue.Enqueue(node.left);
				}

				if(node.right != null)
				{
					queue.Enqueue(node.right);
				}
			}

			if (!leftToRight)
			{
				level.Reverse();
			}

			result.Add(level);

			leftToRight = !leftToRight;
		}
        
		return result;
	}
}
