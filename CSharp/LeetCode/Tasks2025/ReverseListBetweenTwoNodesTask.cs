using LeetCode.Tasks;

namespace LeetCode.Tasks2025;

public class ReverseListBetweenTwoNodesTask
{
    public ListNode ReverseBetween(ListNode head, int left, int right)
    {
        var curr = head = new(0, head); // dummy node
        var st = new Stack<ListNode>();

        for (var i = 1; i < left; i++)
        {
            curr = curr!.next;
        }

        var start = curr;
        curr = curr!.next;

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
