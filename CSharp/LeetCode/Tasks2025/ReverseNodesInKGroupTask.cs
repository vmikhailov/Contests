using LeetCode.Tasks;

namespace LeetCode.Tasks2025;

public class ReverseNodesInKGroupTask
{
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        var dummy = new ListNode(0, head);
        var groupPrev = dummy;

        while (true)
        {
            // Check if there are at least k nodes left
            var temp = groupPrev;
            var count = 0;

            for (var i = 0; i < k; i++)
            {
                temp = temp.next;
                if (temp is null)
                    break;
                count++;
            }

            if (count < k)
                break;

            // Push k nodes onto the stack
            var st = new Stack<ListNode>();
            var curr = groupPrev.next!;
            for (var i = 0; i < k; i++)
            {
                st.Push(curr);
                curr = curr.next!;
            }

            // Pop from stack to reverse the nodes
            var tail = groupPrev;
            while (st.Count > 0)
            {
                var n = st.Pop();
                tail.next = n;
                tail = n;
            }

            // Connect the tail of reversed group to remaining nodes
            tail.next = curr;

            // Move groupPrev to the tail of the reversed group for next iteration
            groupPrev = tail;
        }

        return dummy.next!;
    }

    public ListNode ReverseBetween(ListNode head, int left, int right)
    {
        var curr = head = new ListNode(0, head); // dummy node
        var st = new Stack<ListNode>();

        for (var i = 1; i < left; i++)
        {
            curr = curr.next!;
        }

        var start = curr;
        curr = curr.next!;

        for (var i = left; i <= right && curr is not null; i++)
        {
            st.Push(curr);
            curr = curr.next;
        }

        var end = curr;
        curr = start;

        // a -> b -> c
        while (st.Count > 0)
        {
            var n = st.Pop();

            curr.next = n;
            curr = n;
        }

        curr.next = end;

        return head.next!;
    }
}
