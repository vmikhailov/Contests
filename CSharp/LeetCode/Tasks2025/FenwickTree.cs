namespace LeetCode.Tasks2025;

public class FenwickTree
{
    private readonly int[] _tree;

    public FenwickTree(int n)
    {
        _tree = new int[n + 1]; // indexing from 1
    }

    // Lowbit extracts the lowest set bit of x.
    // This is used to efficiently traverse and update the Fenwick Tree.
    // For example, if x = 12 (1100 in binary), -x = (~x + 1) = 100 in binary,
    // so x & -x = 1100 & 0100 = 0100 = 4.
    // In Fenwick Tree, this helps move to the next node responsible for a range.
    private static int Lowbit(int x) => x & -x;

    // Add 'delta' to index 'i' in the tree.
    // This method updates all responsible nodes that cover index 'i'.
    // It repeatedly adds 'delta' to _tree[i] and moves to the next responsible node using Lowbit.
    // Time complexity: O(log n)
    public void Add(int i, int delta)
    {
        while (i < _tree.Length)
        {
            _tree[i] += delta;
            i += Lowbit(i);
        }
    }

    // Computes the prefix sum from index 1 to i (inclusive).
    // Traverses the tree by subtracting Lowbit(i) at each step, accumulating the sum.
    // If i is out of bounds, clamps to the valid range.
    // Time complexity: O(log n)
    public int PrefixSum(int i)
    {
        i = Math.Clamp(i, 0, _tree.Length - 1);

        var s = 0;
        while (i > 0)
        {
            s += _tree[i];
            i -= Lowbit(i); // Move to parent node
        }
        return s;
    }

    public int RangeSum(int l, int r)
    {
        return PrefixSum(r) - PrefixSum(l - 1);
    }

    public static FenwickTree FromArray(int[] arr)
    {
        var tree = new FenwickTree(arr.Length);
        for (var i = 0; i < arr.Length; i++)
        {
            tree.Add(i + 1, arr[i]);
        }
        return tree;
    }
}
