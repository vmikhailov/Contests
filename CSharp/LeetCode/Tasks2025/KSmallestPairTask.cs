using NUnit.Framework;

namespace LeetCode.Tasks2025;

public class KSmallestPairTask
{
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k) {
        var s = new PriorityQueue<(int i, int j), int>();
        var r = new List<IList<int>>();

        var n1 = nums1.Length;
        var n2 = nums2.Length;

        var f = new HashSet<(int, int)>();

        s.Enqueue((0,0), nums1[0] + nums2[0]);
        f.Add((0,0));

        while(k-- > 0 && s.Count > 0)
        {
            var (i, j) = s.Dequeue();
            r.Add([nums1[i], nums2[j]]);

            if(i < n1 - 1 && f.Add((i + 1, j))) s.Enqueue((i + 1, j), nums1[i + 1] + nums2[j]);
            if(j < n2 - 1 && f.Add((i, j + 1))) s.Enqueue((i, j + 1), nums1[i] + nums2[j + 1]);
        }

        var w = "abcdeghijklmnopqrstuvwxyz";

        var vv = w[..3] + "." + w[3..];
        return r;
    }
}
