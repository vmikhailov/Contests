 using NUnit.Framework;
using FluentAssertions;
using LeetCode.Tasks;

namespace LeetCode.Tasks2025;

public class RotateListTwoTaskTests
{
    private RotateListTwoTask _task = null!;

    [SetUp]
    public void SetUp()
    {
        _task = new RotateListTwoTask();
    }

    [Test]
    public void ReverseBetween_ReverseMiddleSection_ReturnsReversedList()
    {
        // Arrange
        var head = CreateList(1, 2, 3, 4, 5);
        int left = 2;
        int right = 4;

        // Act
        var result = _task.ReverseBetween(head, left, right);

        // Assert
        var expected = new[] { 1, 4, 3, 2, 5 };
        ListToArray(result).Should().Equal(expected);
    }

    [Test]
    public void ReverseBetween_ReverseEntireList_ReturnsReversedList()
    {
        // Arrange
        var head = CreateList(1, 2, 3, 4, 5);
        int left = 1;
        int right = 5;

        // Act
        var result = _task.ReverseBetween(head, left, right);

        // Assert
        var expected = new[] { 5, 4, 3, 2, 1 };
        ListToArray(result).Should().Equal(expected);
    }

    [Test]
    public void ReverseBetween_SingleNode_ReturnsUnchangedList()
    {
        // Arrange
        var head = CreateList(5);
        int left = 1;
        int right = 1;

        // Act
        var result = _task.ReverseBetween(head, left, right);

        // Assert
        var expected = new[] { 5 };
        ListToArray(result).Should().Equal(expected);
    }

    [Test]
    public void ReverseBetween_ReverseFirstTwoNodes_ReturnsReversedList()
    {
        // Arrange
        var head = CreateList(1, 2, 3, 4, 5);
        int left = 1;
        int right = 2;

        // Act
        var result = _task.ReverseBetween(head, left, right);

        // Assert
        var expected = new[] { 2, 1, 3, 4, 5 };
        ListToArray(result).Should().Equal(expected);
    }

    [Test]
    public void ReverseBetween_ReverseLastTwoNodes_ReturnsReversedList()
    {
        // Arrange
        var head = CreateList(1, 2, 3, 4, 5);
        int left = 4;
        int right = 5;

        // Act
        var result = _task.ReverseBetween(head, left, right);

        // Assert
        var expected = new[] { 1, 2, 3, 5, 4 };
        ListToArray(result).Should().Equal(expected);
    }

    [Test]
    public void ReverseBetween_ReverseTwoNodeList_ReturnsReversedList()
    {
        // Arrange
        var head = CreateList(3, 5);
        int left = 1;
        int right = 2;

        // Act
        var result = _task.ReverseBetween(head, left, right);

        // Assert
        var expected = new[] { 5, 3 };
        ListToArray(result).Should().Equal(expected);
    }

    [Test]
    public void ReverseBetween_ReverseOneNodeInMiddle_ReturnsUnchangedList()
    {
        // Arrange
        var head = CreateList(1, 2, 3, 4, 5);
        int left = 3;
        int right = 3;

        // Act
        var result = _task.ReverseBetween(head, left, right);

        // Assert
        var expected = new[] { 1, 2, 3, 4, 5 };
        ListToArray(result).Should().Equal(expected);
    }

    [Test]
    public void ReverseBetween_LargerList_ReturnsReversedList()
    {
        // Arrange
        var head = CreateList(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        int left = 3;
        int right = 7;

        // Act
        var result = _task.ReverseBetween(head, left, right);

        // Assert
        var expected = new[] { 1, 2, 7, 6, 5, 4, 3, 8, 9, 10 };
        ListToArray(result).Should().Equal(expected);
    }

    [Test]
    public void ReverseBetween_ReverseFromFirstToMiddle_ReturnsReversedList()
    {
        // Arrange
        var head = CreateList(1, 2, 3, 4, 5);
        int left = 1;
        int right = 3;

        // Act
        var result = _task.ReverseBetween(head, left, right);

        // Assert
        var expected = new[] { 3, 2, 1, 4, 5 };
        ListToArray(result).Should().Equal(expected);
    }

    [Test]
    public void ReverseBetween_ReverseFromMiddleToEnd_ReturnsReversedList()
    {
        // Arrange
        var head = CreateList(1, 2, 3, 4, 5);
        int left = 3;
        int right = 5;

        // Act
        var result = _task.ReverseBetween(head, left, right);

        // Assert
        var expected = new[] { 1, 2, 5, 4, 3 };
        ListToArray(result).Should().Equal(expected);
    }

    // Helper method to create a linked list from an array of values
    private static ListNode CreateList(params int[] values)
    {
        if (values.Length == 0)
            throw new ArgumentException("Values array cannot be empty");

        var head = new ListNode(values[0]);
        var current = head;

        for (int i = 1; i < values.Length; i++)
        {
            current.next = new ListNode(values[i]);
            current = current.next;
        }

        return head;
    }

    // Helper method to convert a linked list to an array for easier assertion
    private static int[] ListToArray(ListNode? head)
    {
        var result = new List<int>();
        var current = head;

        while (current != null)
        {
            result.Add(current.val);
            current = current.next;
        }

        return result.ToArray();
    }
}

