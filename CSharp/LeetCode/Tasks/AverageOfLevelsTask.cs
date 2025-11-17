namespace LeetCode.Tasks;

public class AverageOfLevelsTask
{
    public IList<double> AverageOfLevels(TreeNode root)
    {
        var result = new List<double>();
        var queue = new Queue<TreeNode>();

        queue.Enqueue(root);

        while(queue.Count > 0)
        {
            var levelSum = 0L;
			
            var levelSize = queue.Count;

            for(var i = 0; i < levelSize; i++)
            {
                var node = queue.Dequeue();
                levelSum += node.val;
				
                if(node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if(node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }

            result.Add(levelSum * 1.0 / levelSize);
        }

        return result;
    }
}
