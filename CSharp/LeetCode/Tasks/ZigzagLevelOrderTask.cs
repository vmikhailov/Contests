using NUnit.Framework.Legacy;
using NUnit.Framework;

namespace LeetCode.Tasks;

public class ZigzagLevelOrderTask
{
	public IList<IList<int>> ZigzagLevelOrder(TreeNode? root) 
	{
		var q = new Queue<TreeNode>();
		var r = new List<IList<int>>();
		
		var f = false;
		if(root == null)
		{
			return r;
		}

		q.Enqueue(root);
		
		while(q.Any())
		{
			IList<int> v = new List<int>();
			var p = q;
			q = new (); 
            
			foreach(var node in p)
			{
				v.Add(node.val);
				if(node.left != null)
				{
					q.Enqueue(node.left);
				}

				if(node.right != null)
				{
					q.Enqueue(node.right);
				}
			}

			f = !f;
			var a = (f ? p.ToList() : p.Reverse()).Select(x => x.val).ToList();
			r.Add(a);
		}
        
		return r;
	}
}

[TestFixture]
public class ZigzagLevelOrderTaskTests
{
	private ZigzagLevelOrderTask _task = null!;

	[SetUp]
	public void SetUp() => _task = new ZigzagLevelOrderTask();

	[Test]
	public void ZigzagLevelOrder_BasicTree_ReturnsZigzag()
	{
		var root = new TreeNode(3)
		{
			left = new TreeNode(9),
			right = new TreeNode(20)
			{
				left = new TreeNode(15),
				right = new TreeNode(7)
			}
		};
		var result = _task.ZigzagLevelOrder(root);
		ClassicAssert.AreEqual(3, result.Count);
		CollectionClassicAssert.AreEqual(new[] { 3 }, result[0]);
		CollectionClassicAssert.AreEqual(new[] { 20, 9 }, result[1]);
		CollectionClassicAssert.AreEqual(new[] { 15, 7 }, result[2]);
	}

	[Test]
	public void ZigzagLevelOrder_SingleNode_ReturnsOneLevel()
	{
		var root = new TreeNode(1);
		var result = _task.ZigzagLevelOrder(root);
		ClassicAssert.AreEqual(1, result.Count);
		CollectionClassicAssert.AreEqual(new[] { 1 }, result[0]);
	}

	[Test]
	public void ZigzagLevelOrder_NullRoot_ReturnsEmpty()
	{
		var result = _task.ZigzagLevelOrder(null);
		ClassicAssert.AreEqual(0, result.Count);
	}

	[Test]
	public void ZigzagLevelOrder_OnlyLeftChildren_ReturnsZigzag()
	{
		var root = new TreeNode(1)
		{
			left = new TreeNode(2)
			{
				left = new TreeNode(3)
			}
		};
		var result = _task.ZigzagLevelOrder(root);
		ClassicAssert.AreEqual(3, result.Count);
		CollectionClassicAssert.AreEqual(new[] { 1 }, result[0]);
		CollectionClassicAssert.AreEqual(new[] { 2 }, result[1]);
		CollectionClassicAssert.AreEqual(new[] { 3 }, result[2]);
	}
}
