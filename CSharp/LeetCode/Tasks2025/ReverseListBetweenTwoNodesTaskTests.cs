using NUnit.Framework;
using FluentAssertions;
using LeetCode.Tasks;

namespace LeetCode.Tasks2025;

public class ReverseListBetweenTwoNodesTaskTests
{
    private ReverseListBetweenTwoNodesTask _task = null!;

    [SetUp]
    public void Setup()
    {
        _task = new();
    }

    // Helper method to create a linked list from an array
    private static ListNode CreateList(params int[] values)
    {
        if (values.Length == 0)
            throw new ArgumentException("List must have at least one element");

        var head = new ListNode(values[0]);
        var current = head;
        for (var i = 1; i < values.Length; i++)
        {
            current.next = new(values[i]);
            current = current.next;
        }
        return head;
    }

    // Helper method to convert linked list to array for assertions
    private static int[] ToArray(ListNode? head)
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

    [Test]
    public void ReverseBetween_Example1_ReturnsCorrectList()
    {
        // Arrange
        var head = CreateList(1, 2, 3, 4, 5);
        int left = 2, right = 4;

        // Act
        var result = _task.ReverseBetween(head, left, right);

        // Assert
        ToArray(result).Should().Equal(1, 4, 3, 2, 5);
    }

    [Test]
    public void ReverseBetween_Example2_SingleElement_ReturnsCorrectList()
    {
        // Arrange
        var head = CreateList(5);
        int left = 1, right = 1;

        // Act
        var result = _task.ReverseBetween(head, left, right);

        // Assert
        ToArray(result).Should().Equal(5);
    }

    [Test]
    public void ReverseBetween_ReverseEntireList_ReturnsReversedList()
    {
        // Arrange
        var head = CreateList(1, 2, 3, 4, 5);
        int left = 1, right = 5;

        // Act
        var result = _task.ReverseBetween(head, left, right);

        // Assert
        ToArray(result).Should().Equal(5, 4, 3, 2, 1);
    }

    [Test]
    public void ReverseBetween_ReverseFromStart_ReturnsCorrectList()
    {
        // Arrange
        var head = CreateList(1, 2, 3, 4, 5);
        int left = 1, right = 3;

        // Act
        var result = _task.ReverseBetween(head, left, right);

        // Assert
        ToArray(result).Should().Equal(3, 2, 1, 4, 5);
    }

    [Test]
    public void ReverseBetween_ReverseToEnd_ReturnsCorrectList()
    {
        // Arrange
        var head = CreateList(1, 2, 3, 4, 5);
        int left = 3, right = 5;

        // Act
        var result = _task.ReverseBetween(head, left, right);

        // Assert
        ToArray(result).Should().Equal(1, 2, 5, 4, 3);
    }

    [Test]
    public void ReverseBetween_TwoElements_ReturnsCorrectList()
    {
        // Arrange
        var head = CreateList(1, 2);
        int left = 1, right = 2;

        // Act
        var result = _task.ReverseBetween(head, left, right);

        // Assert
        ToArray(result).Should().Equal(2, 1);
    }

    [Test]
    public void ReverseBetween_ReverseMiddleTwoElements_ReturnsCorrectList()
    {
        // Arrange
        var head = CreateList(1, 2, 3, 4, 5);
        int left = 2, right = 3;

        // Act
        var result = _task.ReverseBetween(head, left, right);

        // Assert
        ToArray(result).Should().Equal(1, 3, 2, 4, 5);
    }

    [Test]
    public void ReverseBetween_ReverseSingleElementInMiddle_ReturnsUnchangedList()
    {
        // Arrange
        var head = CreateList(1, 2, 3, 4, 5);
        int left = 3, right = 3;

        // Act
        var result = _task.ReverseBetween(head, left, right);

        // Assert
        ToArray(result).Should().Equal(1, 2, 3, 4, 5);
    }

    [Test]
    public void ReverseBetween_LongerList_ReturnsCorrectList()
    {
        // Arrange
        var head = CreateList(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        int left = 3, right = 7;

        // Act
        var result = _task.ReverseBetween(head, left, right);

        // Assert
        ToArray(result).Should().Equal(1, 2, 7, 6, 5, 4, 3, 8, 9, 10);
    }

    [Test]
    public void ReverseBetween_AdjacentReversalPairs_ReturnsCorrectList()
    {
        // Arrange
        var head = CreateList(1, 2, 3, 4);
        int left = 1, right = 2;

        // Act
        var result = _task.ReverseBetween(head, left, right);

        // Assert
        ToArray(result).Should().Equal(2, 1, 3, 4);
    }
}

