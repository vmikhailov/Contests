using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks;

public class ListNode
{
	public int val;
	public ListNode? next;

	public ListNode(int val = 0, ListNode? next = null)
	{
		this.val = val;
		this.next = next;
	}
}

public class RotateListTask
{
	public ListNode? RotateRight(ListNode? head, int k)
	{
		if (head == null)
		{
			return head;
		}

		var n = 0;
		ListNode? prev = null;
		var next = head;
		while (next != null)
		{
			n++;
			prev = next;
			next = next.next;
		}

		k = k % n!;

		if (k == 0)
		{
			return head;
		}

		prev!.next = head;
		while (--k >= 0)
		{
			prev = head;
			head = head.next;
		}

		prev!.next = null;

		return head;
	}
}

[TestFixture]
public class RotateListTaskTests
{
	private RotateListTask _task = null!;

	[SetUp]
	public void SetUp() => _task = new RotateListTask();

	private static ListNode CreateList(params int[] values)
	{
		if (values.Length == 0) return null!;
		var head = new ListNode(values[0]);
		var current = head;
		for (int i = 1; i < values.Length; i++)
		{
			current.next = new ListNode(values[i]);
			current = current.next;
		}
		return head;
	}

	private static int[] ListToArray(ListNode? head)
	{
		var result = new List<int>();
		while (head != null)
		{
			result.Add(head.val);
			head = head.next;
		}
		return result.ToArray();
	}

	[Test]
	public void RotateRight_BasicCase_ReturnsRotated()
	{
		var head = CreateList(1, 2, 3, 4, 5);
		var result = _task.RotateRight(head, 2);
		ListToArray(result).Should().Equal(new[] { 4, 5, 1, 2, 3 });
	}

	[Test]
	public void RotateRight_FullRotation_ReturnsSameList()
	{
		var head = CreateList(1, 2, 3);
		var result = _task.RotateRight(head, 3);
		ListToArray(result).Should().Equal(new[] { 1, 2, 3 });
	}

	[Test]
	public void RotateRight_NullHead_ReturnsNull()
	{
		var result = _task.RotateRight(null, 5);
		result.Should().BeNull();
	}

	[Test]
	public void RotateRight_ZeroRotation_ReturnsSameList()
	{
		var head = CreateList(1, 2, 3);
		var result = _task.RotateRight(head, 0);
		ListToArray(result).Should().Equal(new[] { 1, 2, 3 });
	}

	[Test]
	public void RotateRight_LargeK_ReturnsCorrect()
	{
		var head = CreateList(1, 2);
		var result = _task.RotateRight(head, 5);
		ListToArray(result).Should().Equal(new[] { 2, 1 });
	}
}

