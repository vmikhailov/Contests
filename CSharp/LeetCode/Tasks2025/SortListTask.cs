using LeetCode.Tasks;

namespace LeetCode.Tasks2025;

public class SortListTask
{
    public ListNode? SortList(ListNode? head)
    {
        if (head?.next is null) return head;

        var size = 1;

        while (true)
        {
            var dummy = new ListNode();
            var tail = dummy;
            var current = head;
            var mergeCount = 0;

            while (current is not null)
            {
                var (left, rest1) = Split(current, size);
                var (right, rest2) = Split(rest1, size);

                if (right is not null) mergeCount++;

                tail.next = Merge((left, right));

                while (tail.next is not null) tail = tail.next;

                current = rest2;
            }

            head = dummy.next;

            // Если не было слияний, список отсортирован
            if (mergeCount == 0) break;

            size *= 2;
        }

        return head;
    }

    private static (ListNode?, ListNode?) Split(ListNode? node, int size)
    {
        var left = node;
        ListNode? prev = null;

        for (var i = 0; i < size && node is not null; i++)
        {
            prev = node;
            node = node.next;
        }

        if (prev is not null) prev.next = null;

        return (left, node);
    }

    private static ListNode? Merge((ListNode? Left, ListNode? Right) nodes)
    {
        var (left, right) = nodes;
        if (left is null) return right;
        if (right is null) return left;

        var dummy = new ListNode();
        var tail = dummy;

        while (left is not null && right is not null)
        {
            if (left.val <= right.val)
            {
                tail.next = left;
                left = left.next;
            }
            else
            {
                tail.next = right;
                right = right.next;
            }

            tail = tail.next!;

            // Cut any stale linkage to avoid accidental cycles during merge
            tail.next = null;
        }

        tail.next = left ?? right;
        return dummy.next;
    }
}
