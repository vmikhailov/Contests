using NUnit.Framework;
using FluentAssertions;
using LeetCode.Tasks;

namespace LeetCode.Tasks2025;

public class ReverseNodesInKGroupTaskTests
{
    private ReverseNodesInKGroupTask _task = null!;

    [SetUp]
    public void Setup()
    {
        _task = new ReverseNodesInKGroupTask();
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
            current.next = new ListNode(values[i]);
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
    public void ReverseKGroup_Example1_ReturnsCorrectList()
    {
        // Arrange
        var head = CreateList(1, 2, 3, 4, 5);
        int k = 2;

        // Act
        var result = _task.ReverseKGroup(head, k);

        // Assert
        ToArray(result).Should().Equal(2, 1, 4, 3, 5);
    }

    [Test]
    public void ReverseKGroup_Example2_ReturnsCorrectList()
    {
        // Arrange
        var head = CreateList(1, 2, 3, 4, 5);
        int k = 3;

        // Act
        var result = _task.ReverseKGroup(head, k);

        // Assert
        ToArray(result).Should().Equal(3, 2, 1, 4, 5);
    }

    [Test]
    public void ReverseKGroup_KEquals1_ReturnsUnchangedList()
    {
        // Arrange
        var head = CreateList(1, 2, 3, 4, 5);
        int k = 1;

        // Act
        var result = _task.ReverseKGroup(head, k);

        // Assert
        ToArray(result).Should().Equal(1, 2, 3, 4, 5);
    }

    [Test]
    public void ReverseKGroup_KEqualsListLength_ReturnsFullyReversedList()
    {
        // Arrange
        var head = CreateList(1, 2, 3, 4, 5);
        int k = 5;

        // Act
        var result = _task.ReverseKGroup(head, k);

        // Assert
        ToArray(result).Should().Equal(5, 4, 3, 2, 1);
    }

    [Test]
    public void ReverseKGroup_KGreaterThanListLength_ReturnsUnchangedList()
    {
        // Arrange
        var head = CreateList(1, 2, 3);
        int k = 4;

        // Act
        var result = _task.ReverseKGroup(head, k);

        // Assert
        ToArray(result).Should().Equal(1, 2, 3);
    }

    [Test]
    public void ReverseKGroup_SingleElement_ReturnsUnchangedList()
    {
        // Arrange
        var head = CreateList(1);
        int k = 1;

        // Act
        var result = _task.ReverseKGroup(head, k);

        // Assert
        ToArray(result).Should().Equal(1);
    }

    [Test]
    public void ReverseKGroup_TwoElements_K2_ReturnsReversedList()
    {
        // Arrange
        var head = CreateList(1, 2);
        int k = 2;

        // Act
        var result = _task.ReverseKGroup(head, k);

        // Assert
        ToArray(result).Should().Equal(2, 1);
    }

    [Test]
    public void ReverseKGroup_EvenlyDivisible_ReturnsFullyReversedGroups()
    {
        // Arrange
        var head = CreateList(1, 2, 3, 4, 5, 6, 7, 8);
        int k = 4;

        // Act
        var result = _task.ReverseKGroup(head, k);

        // Assert
        ToArray(result).Should().Equal(4, 3, 2, 1, 8, 7, 6, 5);
    }

    [Test]
    public void ReverseKGroup_NotEvenlyDivisible_ReturnsCorrectList()
    {
        // Arrange
        var head = CreateList(1, 2, 3, 4, 5, 6, 7);
        int k = 3;

        // Act
        var result = _task.ReverseKGroup(head, k);

        // Assert
        ToArray(result).Should().Equal(3, 2, 1, 6, 5, 4, 7);
    }

    [Test]
    public void ReverseKGroup_LongerList_ReturnsCorrectList()
    {
        // Arrange
        var head = CreateList(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        int k = 3;

        // Act
        var result = _task.ReverseKGroup(head, k);

        // Assert
        ToArray(result).Should().Equal(3, 2, 1, 6, 5, 4, 9, 8, 7, 10);
    }
}

