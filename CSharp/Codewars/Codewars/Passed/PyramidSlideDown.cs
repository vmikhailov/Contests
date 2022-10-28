using System;

namespace Codewars.Codewars.Passed
{
    public class PyramidSlideDown
    {
        public static int LongestSlideDown(int[][] pyramid)
        {
            for (var i = pyramid.Length - 2; i >= 0; i--)
            {
                for (var j = 0; j < i + 1; j++)
                {
                    pyramid[i][j] += Math.Max(pyramid[i+1][j], pyramid[i+1][j + 1]);
                }
            }

            return pyramid[0][0];
        }
    }
}