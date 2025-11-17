using LeetCode.Tasks;

namespace LeetCode.Tasks2025;

public class SortListTask
{
    public ListNode? SortList(ListNode? head)
    {
        var n = Count(head);
        if(n < 2) return head;

        while (!IsSorted(head))
        {
            head = Merge(Split(head, n));
        }

        return head;


        int Count(ListNode? node)
        {
            var c = 0;

            while (node is not null)
            {
                node = node.next;
                c++;
            }

            return c;
        }

        bool IsSorted(ListNode? node)
        {
            if (node is null) return true;

            var prev = node;
            node = node.next;

            while (node is not null)
            {
                if (prev.val > node.val) return false;
                prev = node;
                node = node.next;
            }

            return true;
        }

        (ListNode?, ListNode?) Split(ListNode? node, int cnt)
        {
            var left = node;
            ListNode? prev = null;

            for (var i = 0; i < cnt / 2; i++)
            {
                prev = node;
                node = node!.next;
            }

            if (prev is not null) prev.next = null;

            return (SortList(left), SortList(node));
        }

        ListNode? Merge((ListNode? Left, ListNode? Right) nodes)
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
}
