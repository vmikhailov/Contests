using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks;

[TestFixture]
public class AverageOfLevelsTaskTests
{
    private AverageOfLevelsTask _task = null!;

    [SetUp]
    public void SetUp() => _task = new AverageOfLevelsTask();

    [Test]
    public void AverageOfLevels_BasicTree_ReturnsCorrectAverages()
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
        var result = _task.AverageOfLevels(root);
        result.Should().HaveCount(3);
        result[0].Should().Be(3.0);
        result[1].Should().Be(14.5);
        result[2].Should().Be(11.0);
    }

    [Test]
    public void AverageOfLevels_SingleNode_ReturnsSingleAverage()
    {
        var root = new TreeNode(1);
        var result = _task.AverageOfLevels(root);
        result.Should().HaveCount(1);
        result[0].Should().Be(1.0);
    }

    [Test]
    public void AverageOfLevels_TwoLevels_ReturnsCorrectAverages()
    {
        var root = new TreeNode(3)
        {
            left = new TreeNode(9),
            right = new TreeNode(20)
        };
        var result = _task.AverageOfLevels(root);
        result.Should().HaveCount(2);
        result[0].Should().Be(3.0);
        result[1].Should().Be(14.5);
    }

    [Test]
    public void AverageOfLevels_OnlyLeftChildren_ReturnsCorrectAverages()
    {
        var root = new TreeNode(1)
        {
            left = new TreeNode(2)
            {
                left = new TreeNode(3)
            }
        };
        var result = _task.AverageOfLevels(root);
        result.Should().HaveCount(3);
        result[0].Should().Be(1.0);
        result[1].Should().Be(2.0);
        result[2].Should().Be(3.0);
    }

    [Test]
    public void AverageOfLevels_OnlyRightChildren_ReturnsCorrectAverages()
    {
        var root = new TreeNode(1)
        {
            right = new TreeNode(2)
            {
                right = new TreeNode(3)
            }
        };
        var result = _task.AverageOfLevels(root);
        result.Should().HaveCount(3);
        result[0].Should().Be(1.0);
        result[1].Should().Be(2.0);
        result[2].Should().Be(3.0);
    }

    [Test]
    public void AverageOfLevels_FullBinaryTree_ReturnsCorrectAverages()
    {
        var root = new TreeNode(1)
        {
            left = new TreeNode(2)
            {
                left = new TreeNode(4),
                right = new TreeNode(5)
            },
            right = new TreeNode(3)
            {
                left = new TreeNode(6),
                right = new TreeNode(7)
            }
        };
        var result = _task.AverageOfLevels(root);
        result.Should().HaveCount(3);
        result[0].Should().Be(1.0);
        result[1].Should().Be(2.5);
        result[2].Should().Be(5.5);
    }

    [Test]
    public void AverageOfLevels_NegativeValues_ReturnsCorrectAverages()
    {
        var root = new TreeNode(-5)
        {
            left = new TreeNode(-10),
            right = new TreeNode(10)
        };
        var result = _task.AverageOfLevels(root);
        result.Should().HaveCount(2);
        result[0].Should().Be(-5.0);
        result[1].Should().Be(0.0);
    }

    [Test]
    public void AverageOfLevels_LargeNumbers_ReturnsCorrectAverages()
    {
        var root = new TreeNode(2147483647)
        {
            left = new TreeNode(2147483647),
            right = new TreeNode(2147483647)
        };
        var result = _task.AverageOfLevels(root);
        result.Should().HaveCount(2);
        result[0].Should().Be(2147483647.0);
        result[1].Should().Be(2147483647.0);
    }
}
