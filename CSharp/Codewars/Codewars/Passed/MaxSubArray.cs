using System;

namespace Codewars.Codewars.Passed
{
    public class MaxSubArray
    {
        private static int Max(int a, int b, int c) => Math.Max(Math.Max(a, b), c);

        private static int MaxCrossingSum(int[] arr, int l, int m, int h)
        {
            var sum = 0;
            var left_sum = -1;
            for (var i = m; i >= l; i--)
            {
                sum = sum + arr[i];
                if (sum > left_sum)
                {
                    left_sum = sum;
                }
            }

            sum = 0;
            var right_sum = -1;
            for (var i = m + 1; i <= h; i++)
            {
                sum = sum + arr[i];
                if (sum > right_sum)
                {
                    right_sum = sum;
                }
            }

            return Max(left_sum + right_sum, left_sum, right_sum);
        }

        public static int MaxSubArraySum(int[] arr, int l, int h)
        {
            if (l == h)
            {
                return arr[l];
            }

            // Find middle point 
            var m = (l + h) / 2;

            return Max(
                MaxSubArraySum(arr, l, m),
                MaxSubArraySum(arr, m + 1, h),
                MaxCrossingSum(arr, l, m, h));
        }
        
        public static int MaxSequence(int[] arr)
        {
            return MaxSubArraySum(arr, 0, arr.Length - 1);
        }
    }
}