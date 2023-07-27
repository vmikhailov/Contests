namespace LeetCode.Tasks;

public class NextGreaterElement1
{
    // public int[] NextGreaterElement(int[] nums1, int[] nums2)
    // {
    //     //Array.Sort(nums2);
    //     // var sorted = new List<int>();
    //     // var nextGreater = new int[nums2.Length];
    //     // var n = 0;
    //     // for (var i = nums2.Length - 1; i >= 0; i--)
    //     // {
    //     //     var p = sorted.BinarySearch(nums2[i]);
    //     //     p = p <= 0 ? -p - 1 : p;
    //     //     sorted.Insert(p, nums2[i]);
    //     //     nextGreater[i] = p + 1 < sorted.Count ? sorted[p + 1] : -1;
    //     // }
    //
    //     var result = new int[nums1.Length];
    //
    //     for (int i = 0; i < nums1.Length; i++)
    //     {
    //         var p = Array.BinarySearch(nums2, nums1[i]);
    //         result[i] = p >= 0 ? p + 1 : -1;
    //     }
    //
    //     return result;
    // }
    
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        var nextGreater = new Dictionary<int, int>();
        for (var i = 0; i < nums2.Length; i++)
        {
            var v = nums2[i];
            var g = -1;
            for (var j = i + 1; j < nums2.Length; j++)
            {
                if (nums2[j] > v)
                {
                    g = nums2[j];
                    break;
                }
            }

            nextGreater[v] = g;
        }

        var result = new int[nums1.Length];
        for (var i = 0; i < nums1.Length; i++)
        {
            result[i] = nextGreater[nums1[i]];
        }

        return result;
    }
}