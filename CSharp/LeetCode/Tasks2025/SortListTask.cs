using LeetCode.Tasks;

namespace LeetCode.Tasks2025;

public class SortListTask
{
    public ListNode SortList(ListNode head)
    {
        var n = Count(head);
        if(n < 2) return head;
        while (Merge(Split(head, n), out head));
        return head;

        int Count(ListNode node)
        {
            var c = 0;

            while (node is not null)
            {
                node = node.next;
                c++;
            }

            return c;
        }

        (ListNode, ListNode) Split(ListNode node, int n)
        {
            var left = node;
            ListNode? prev = null;

            for (var i = 0; i < n / 2; i++)
            {
                prev = node;
                node = node.next;
            }

            if (prev is not null) prev.next = null;

            return (SortList(left), SortList(node));
        }

        bool Merge((ListNode Left, ListNode Right) nodes, out ListNode result)
        {
            var (left, right) = nodes;
            result = null;
            ListNode curr = null;
            var reordered = false;

            while (left != null && right != null)
            {
                if (left.val < right.val)
                {
                    if (curr is not null) curr.next = left;
                    else result = left;
                    curr = left;
                    left = left.next;
                }
                else
                {
                    reordered = true;
                    if (curr is not null) curr.next = right;
                    else result = right;
                    curr = right;
                    right = right.next;
                }
            }

            while (left != null)
            {
                if (curr is not null) curr.next = left;
                else result = left;
                curr = left;
                left = left.next;
            }

            while (right != null)
            {
                if (curr is not null) curr.next = right;
                else result = right;
                curr = right;
                right = right.next;
            }

            return reordered;
        }
    }
}
