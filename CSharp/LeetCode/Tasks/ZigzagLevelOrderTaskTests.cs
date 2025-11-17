using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks;

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
        result.Should().HaveCount(3);
        result[0].Should().Equal([3]);
        result[1].Should().Equal([20, 9]);
        result[2].Should().Equal([15, 7]);
    }

    [Test]
    public void ZigzagLevelOrder_SingleNode_ReturnsOneLevel()
    {
        var root = new TreeNode(1);
        var result = _task.ZigzagLevelOrder(root);
        result.Should().HaveCount(1);
        result[0].Should().Equal([1]);
    }

    [Test]
    public void ZigzagLevelOrder_NullRoot_ReturnsEmpty()
    {
        var result = _task.ZigzagLevelOrder(null);
        result.Should().BeEmpty();
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
        result.Should().HaveCount(3);
        result[0].Should().Equal([1]);
        result[1].Should().Equal([2]);
        result[2].Should().Equal([3]);
    }
}
