using LeetCode.Tasks2025;

namespace LeetCode.Tasks;

public class NumArrayTaskSegmentTree : INumArrayTask
{
    private readonly SegmentTree<int> _segmentTree;

    public NumArrayTaskSegmentTree(int[] nums)
    {
        _segmentTree = new(nums, (a, b) => a + b, 0);
    }

    public void Update(int index, int val)
    {
        _segmentTree.Update(index, val);
    }

    public int SumRange(int l, int r)
    {
        return _segmentTree.Query(l, r);
    }
}
