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
		if (head == null) return head;
		
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

		if (k == 0) return head;

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
