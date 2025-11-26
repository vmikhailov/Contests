namespace LeetCode.Tasks2025;

public class LargestElementAfterMergeTask
{
    // 2789. Largest Element After Merge Operations
    public long MaxArrayValue(int[] nums)
    {
        var list = new LinkedList<int>(nums);
        var change = true;
        var n = nums.Length;


        while(change)
        {
            change = false;
            var tail = list.Last;

            while(tail is { Previous: not null })
            {
                var a = tail.Value;
                tail = tail.Previous;

                var b = tail.Value;
                if(b <= a)
                {
                    change = true;
                    tail.Value = a + b;
                    list.Remove(tail.Next!);
                    n--;
                }
            }
        }

        return list.Max();
    }
}
