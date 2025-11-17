using NUnit.Framework;
using FluentAssertions;
using LeetCode.Tasks;

namespace LeetCode.Tasks2025;

public class SortListTaskTests
{
    private SortListTask _task = null!;

    [SetUp]
    public void Setup()
    {
        _task = new SortListTask();
    }

    // Helper method to create a linked list from an array
    private static ListNode? CreateList(params int[] values)
    {
        if (values.Length == 0) return null;

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
    public void SortList_EmptyList_ReturnsNull()
    {
        // Arrange
        ListNode? head = null;

        // Act
        var result = _task.SortList(head);

        // Assert
        result.Should().BeNull();
    }

    [Test]
    public void SortList_SingleElement_ReturnsSameElement()
    {
        // Arrange
        var head = CreateList(5);

        // Act
        var result = _task.SortList(head);

        // Assert
        ToArray(result).Should().Equal(5);
    }

    [Test]
    public void SortList_TwoElementsInOrder_ReturnsSameOrder()
    {
        // Arrange
        var head = CreateList(1, 2);

        // Act
        var result = _task.SortList(head);

        // Assert
        ToArray(result).Should().Equal(1, 2);
    }

    [Test]
    public void SortList_TwoElementsReversed_ReturnsSorted()
    {
        // Arrange
        var head = CreateList(2, 1);

        // Act
        var result = _task.SortList(head);

        // Assert
        ToArray(result).Should().Equal(1, 2);
    }

    [Test]
    public void SortList_ThreeElementsUnsorted_ReturnsSorted()
    {
        // Arrange
        var head = CreateList(3, 1, 2);

        // Act
        var result = _task.SortList(head);

        // Assert
        ToArray(result).Should().Equal(1, 2, 3);
    }

    [Test]
    public void SortList_LeetCodeExample1_ReturnsSorted()
    {
        // Arrange
        // Input: head = [4,2,1,3]
        // Output: [1,2,3,4]
        var head = CreateList(4, 2, 1, 3);

        // Act
        var result = _task.SortList(head);

        // Assert
        ToArray(result).Should().Equal(1, 2, 3, 4);
    }

    [Test]
    public void SortList_LeetCodeExample2_ReturnsSorted()
    {
        // Arrange
        // Input: head = [-1,5,3,4,0]
        // Output: [-1,0,3,4,5]
        var head = CreateList(-1, 5, 3, 4, 0);

        // Act
        var result = _task.SortList(head);

        // Assert
        ToArray(result).Should().Equal(-1, 0, 3, 4, 5);
    }

    [Test]
    public void SortList_AlreadySorted_ReturnsSameOrder()
    {
        // Arrange
        var head = CreateList(1, 2, 3, 4, 5);

        // Act
        var result = _task.SortList(head);

        // Assert
        ToArray(result).Should().Equal(1, 2, 3, 4, 5);
    }

    [Test]
    public void SortList_ReverseSorted_ReturnsSorted()
    {
        // Arrange
        var head = CreateList(5, 4, 3, 2, 1);

        // Act
        var result = _task.SortList(head);

        // Assert
        ToArray(result).Should().Equal(1, 2, 3, 4, 5);
    }

    [Test]
    public void SortList_DuplicateElements_ReturnsSorted()
    {
        // Arrange
        var head = CreateList(3, 1, 2, 1, 3, 2);

        // Act
        var result = _task.SortList(head);

        // Assert
        ToArray(result).Should().Equal(1, 1, 2, 2, 3, 3);
    }

    [Test]
    public void SortList_AllSameElements_ReturnsSameElements()
    {
        // Arrange
        var head = CreateList(5, 5, 5, 5);

        // Act
        var result = _task.SortList(head);

        // Assert
        ToArray(result).Should().Equal(5, 5, 5, 5);
    }

    [Test]
    public void SortList_NegativeNumbers_ReturnsSorted()
    {
        // Arrange
        var head = CreateList(-5, -1, -3, -2, -4);

        // Act
        var result = _task.SortList(head);

        // Assert
        ToArray(result).Should().Equal(-5, -4, -3, -2, -1);
    }

    [Test]
    public void SortList_MixedPositiveAndNegative_ReturnsSorted()
    {
        // Arrange
        var head = CreateList(3, -1, 2, -5, 0, 4);

        // Act
        var result = _task.SortList(head);

        // Assert
        ToArray(result).Should().Equal(-5, -1, 0, 2, 3, 4);
    }

    [Test]
    public void SortList_LargeList_ReturnsSorted()
    {
        // Arrange
        var values = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, -1, -2, -3, -4, -5 };
        var head = CreateList(values);

        // Act
        var result = _task.SortList(head);

        // Assert
        ToArray(result).Should().Equal(-5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
    }

    [Test]
    public void SortList_RandomOrder_ReturnsSorted()
    {
        // Arrange
        var head = CreateList(7, 2, 9, 1, 5, 3, 8, 4, 6);

        // Act
        var result = _task.SortList(head);

        // Assert
        ToArray(result).Should().Equal(1, 2, 3, 4, 5, 6, 7, 8, 9);
    }

    [Test]
    public void SortList_EvenNumberOfElements_ReturnsSorted()
    {
        // Arrange
        var head = CreateList(6, 4, 2, 8);

        // Act
        var result = _task.SortList(head);

        // Assert
        ToArray(result).Should().Equal(2, 4, 6, 8);
    }

    [Test]
    public void SortList_OddNumberOfElements_ReturnsSorted()
    {
        // Arrange
        var head = CreateList(6, 4, 2, 8, 1);

        // Act
        var result = _task.SortList(head);

        // Assert
        ToArray(result).Should().Equal(1, 2, 4, 6, 8);
    }

    [Test]
    public void SortList_WithZeros_ReturnsSorted()
    {
        // Arrange
        var head = CreateList(0, -1, 0, 1, 0);

        // Act
        var result = _task.SortList(head);

        // Assert
        ToArray(result).Should().Equal(-1, 0, 0, 0, 1);
    }

    [Test]
    public void SortList_VeryLargeList_ReturnsSorted()
    {
        // Arrange - create a list of 100 elements in random order
        var random = new Random(42); // Fixed seed for reproducibility
        var values = Enumerable.Range(1, 100).OrderBy(x => random.Next()).ToArray();
        var head = CreateList(values);

        // Act
        var result = _task.SortList(head);

        // Assert
        var sorted = ToArray(result);
        sorted.Should().HaveCount(100);
        sorted.Should().BeInAscendingOrder();
        sorted.Should().Equal(Enumerable.Range(1, 100));
    }

    [Test]
    public void SortList_TwoElements_Equal_ReturnsSameOrder()
    {
        // Arrange
        var head = CreateList(5, 5);

        // Act
        var result = _task.SortList(head);

        // Assert
        ToArray(result).Should().Equal(5, 5);
    }

    [Test]
    public void SortList_PartiallyOrdered_ReturnsSorted()
    {
        // Arrange
        var head = CreateList(1, 2, 5, 3, 4);

        // Act
        var result = _task.SortList(head);

        // Assert
        ToArray(result).Should().Equal(1, 2, 3, 4, 5);
    }

    [Test]
    public void SortList_MinMaxValues_ReturnsSorted()
    {
        // Arrange
        var head = CreateList(int.MaxValue, 0, int.MinValue, 1, -1);

        // Act
        var result = _task.SortList(head);

        // Assert
        ToArray(result).Should().Equal(int.MinValue, -1, 0, 1, int.MaxValue);
    }
}

