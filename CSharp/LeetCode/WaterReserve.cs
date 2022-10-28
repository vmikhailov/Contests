using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Entry
{
    public static class ContainerWithMostWater
    {
        public static int MaxArea(int[] height)
        {
            return MaxArea(height.Length, height, 0, height.Length - 1, 0);
        }
        
        public static int MaxArea(int n, int[] height, int l, int r, int t)
        {
            if (l >= r) return 0;
            
            var (m, i) = Max(height, l, r);
            if (t == 1)
            {
                //left
                return MaxArea(n, height, l, i - 1, 1) + Sum(height, m, i, r);
            }
            else if (t == 2)
            {
                //right   
                return Sum(height, m, l, i) + MaxArea(n, height, i + 1, r, 2);
            }

            return MaxArea(n, height, l, i - 1, 1) + MaxArea(n, height, i + 1, r, 2);
        }

        private static int Sum(int[] height, int m,  int i, int j)
        {
            var s = 0;
            for (var k = i; k <= j; k++)
            {
                s += m - height[k];
            }

            return s;
        }

        private static (int, int) Max(int[] height, int l, int r)
        {
            var m = int.MinValue;
            var j = -1;
            for (var i = l; i <= r; i++)
            {
                if (m < height[i])
                {
                    m = height[i];
                    j = i;
                }
            }

            return (m, j);
        }
    }
}